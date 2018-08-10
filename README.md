# RacExternalAuthenticationSample
[![Build Status][travis-image]][travis-url] 

Código para demonstrando a implementação de um ERP para realizar a autenticação externa do RAC.

É necessário incluir algumas configurações no RAC
* **TnfExternalAuthentication.GetValidateCredentialAddress** com o valor **http://localhost:4987/rest/v1/users/validate**
* **TnfExternalAuthentication.IsEnabled** com o valor **true**
* **TnfExternalAuthentication.SourceName** com o valor **ERP**
* **TnfExternalAuthentication.GetUserInfoAddress** com o valor **http://localhost:4987/rest/v1/users**

Em seguida, ao acessar a tela de login do RAC o sistema irá utilizar essa aplicação para autenticar o usuário
Informe o usuário **test** e senha **test@123** e o login será realizado com sucesso.

Request e response da aplicação:
===

Validate
---

***Request***

**Method:** Post

**Url:** http://localhost:4987/rest/v1/users/validate

**Header:** Content-Type: text/plain

**Body:** username=test&password=test@123

***Response***

**Header:** Content-Type: text/plain

**Body:** true (Informando se as credenciais são válidas)

Get User Id
---

***Request***

**Method:** Get

**Url:** http://localhost:4987/rest/v1/users/id/test

***Response***

**Header:** Content-Type: text/plain

**Body:** 1001 (Representa o id do usuário nesse código exemplo)

[travis-image]:https://travis-ci.org/totvs/rac-external-authentication-sample.svg?branch=master
[travis-url]:https://travis-ci.org/totvs/rac-external-authentication-sample
