using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Text;

namespace RacExternalAuthSample.Controllers
{
  [Route("rest/v1/[controller]")]
  [AllowAnonymous]
  public class UsersController : Controller
  {
    /// <summary>
    /// Busca o identificador do usuário
    /// </summary>
    /// <param name="username">Nome do usuário</param>
    /// <returns>Código identificador do usuário</returns>
    [HttpGet("id/{username}")]
    public Stream GetUserId(string username) =>
      username == "test" ?
        new MemoryStream(Encoding.UTF8.GetBytes("1001")) :
        null;

    /// <summary>
    /// Valida as credenciais do usuário
    /// </summary>
    /// <returns>Retorna true se as credenciais foram validadas pelo ERP</returns>
    [HttpPost("validate")]
    public bool Validate()
    {
      using (StreamReader reader = new StreamReader(this.HttpContext.Request.Body, Encoding.UTF8))
      {
        string[] dataParsed = reader.ReadToEnd().Split('&');

        string username = dataParsed[0].Split('=')[1];
        string password = dataParsed[1].Split('=')[1];

        return username == "test" && password == "test@123";
      }
    }
  }
}
