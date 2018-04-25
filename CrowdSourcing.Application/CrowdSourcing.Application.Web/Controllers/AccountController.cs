using CrowdSourcing.Application.Web.Extension;
using CrowdSourcing.Application.Web.ViewModels;
using CrowdSourcing.Contract.Interfaces;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace CrowdSourcing.Application.Web.Controllers
{
    public class AccountController : ApiController
    {
        private IPersonService _personService;
        public AccountController(IPersonService personService)
        {
            _personService = personService;
        }
        [Route("User/Register")]
        [HttpPost]
        public async Task<IHttpActionResult> Register(AccountVM account)
        {

            var user = await _personService.AddPersonAsync(account.ToModel(), account.Password, account.Role);
            return Ok(user.ToAcoountVm());
        }
        [Authorize]
        [Route("User/GetClaims")]
        [HttpGet]
        public IHttpActionResult GetUserClaims()
        {
            var identityClaims = (ClaimsIdentity)User.Identity;
            UserVM model = new UserVM()
            {
                Id = identityClaims.FindFirst("Id").Value,
                Email = identityClaims.FindFirst("Email").Value,
                FirstName = identityClaims.FindFirst("FirstName").Value,
                LastName = identityClaims.FindFirst("LastName").Value,
                Role = identityClaims.FindFirst("MainRole").Value,

            };
             return Ok(model);
        }

        [Route("User/Login")]
        [HttpPost]
            public async Task<HttpResponseMessage> LoginUser(LoginVM model)
            {
            // Invoke the "token" OWIN service to perform the login: /api/token
            // Ugly hack: I use a server-side HTTP POST because I cannot directly invoke the service (it is deeply hidden in the OAuthAuthorizationServerHandler class)
                HttpResponseMessage message;
                var request = HttpContext.Current.Request;
                var tokenServiceUrl = request.Url.GetLeftPart(UriPartial.Authority) + request.ApplicationPath + "/token";
                using (var client = new HttpClient())
                {
                    var requestParams = new List<KeyValuePair<string, string>>
                    {
                        new KeyValuePair<string, string>("grant_type", "password"),
                        new KeyValuePair<string, string>("username", model.Email),
                        new KeyValuePair<string, string>("password", model.Password)
                    };
                    var requestParamsFormUrlEncoded = new FormUrlEncodedContent(requestParams);
                    var tokenServiceResponse = await client.PostAsync(tokenServiceUrl, requestParamsFormUrlEncoded);
                    var responseString = await tokenServiceResponse.Content.ReadAsStringAsync();
                    var responseCode = tokenServiceResponse.StatusCode;
                    message = new HttpResponseMessage(responseCode)
                    {
                        Content = new StringContent(responseString, Encoding.UTF8, "application/json")
                    };
                                   
                }
                return message;
              
                
            }








        [AllowAnonymous]
        [HttpGet]
        [Route("api/data/forall")]
        public IHttpActionResult Get()
        {
            return Ok("Now server time is " + DateTime.Now.ToString());
        }
        [Authorize]
        [HttpGet]
        [Route("api/data/authenticate")]
        public IHttpActionResult GetForAuthenticate()
        {
            var identity = User.Identity.GetUserName();
            return Ok("Hi " +identity);
        }
        [Authorize(Roles ="admin")]
        [HttpGet]
        [Route("api/data/authorize")]
        public IHttpActionResult GetForAdmin()
        {
            var identity = (ClaimsIdentity)User.Identity;
            var roles = identity.Claims
                .Where(c => c.Type == ClaimTypes.Role)
                .Select(c => c.Value);
            return Ok("Hi " + identity.Name+" role:" + string.Join(",",roles.ToList()));
        }
    }
}
