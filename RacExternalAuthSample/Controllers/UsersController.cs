using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Text;

namespace RacExternalAuthSample.Controllers
{
  [Route("rest/v1/[controller]")]
  [AllowAnonymous]
  public class UsersController : Controller
  {

    readonly dynamic user = new
    {
      Id = "1001",
      Name = "test",
      Password = "test@123"
    };

    /// <summary>
    /// Busca o identificador do usuário
    /// </summary>
    /// <param name="username">Nome do usuário</param>
    /// <returns>Código identificador do usuário</returns>
    [HttpGet("id/{username}")]
    public Stream GetUserId(string username) =>
      username == user.Name ?
        new MemoryStream(Encoding.UTF8.GetBytes(user.Id)) :
        null;

    /// <summary>
    /// Valida as credenciais do usuário
    /// </summary>
    /// <returns>Retorna true se as credenciais foram validadas pelo ERP</returns>
    [HttpPost("validate")]
    public bool Validate() =>
      new Func<bool>(() =>
        {
          using (StreamReader reader = new StreamReader(this.HttpContext.Request.Body, Encoding.UTF8))
          {
            string[] dataParsed = reader.ReadToEnd().Split('&');

            string username = dataParsed[0].Split('=')[1];
            string password = dataParsed[1].Split('=')[1];

            return username == user.Name && password == user.Password;
          }
        })();
  }
}
