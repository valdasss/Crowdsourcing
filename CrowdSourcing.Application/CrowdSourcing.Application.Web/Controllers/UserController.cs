using CrowdSourcing.Application.Web.Extension;
using CrowdSourcing.Application.Web.ViewModels;
using CrowdSourcing.Contract.Interfaces;
using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace CrowdSourcing.Application.Web.Controllers
{
    public class UserController : ApiController
    {
        private IPersonService _personService;
        private ISolutionService _solutionService;
        private IFileService _fileService;
        public UserController(IPersonService personService,ISolutionService solutionService,IFileService fileService)
        {
            _personService = personService;
            _solutionService = solutionService;
            _fileService = fileService;
        }
        [Route("User/Register")]
        [HttpPost]
        public async Task<IHttpActionResult> Register(AccountVM account)
        {

            var user = await _personService.AddPersonAsync(account.ToModel(), account.Password, account.Role);
            return Ok(user.ToAcoountVm());
        }
        
        [Authorize(Roles ="admin")]
        [Route("User/RegisterAdmin")]
        [HttpPost]
        public async Task<IHttpActionResult> RegisterAdmin(AccountVM account)
        {
            var user = await _personService.AddPersonAsync(account.ToModel(), account.Password, account.Role);
            return Ok(user.ToAcoountVm());
        }
        [Authorize]
        [Route("User/GetClaims")]
        [HttpGet]
        public async Task<IHttpActionResult> GetUserClaims()
        {
            var identityClaims = (ClaimsIdentity)User.Identity;
            var personId = identityClaims.FindFirst("Id").Value;
            var person = await _personService.GetPersonById(personId);
            UserVM model = new UserVM()
            {
                Id = personId,
                Email = person.Email,
                FirstName = person.Name,
                LastName = person.LastName,
                Role = identityClaims.FindFirst("MainRole").Value,
            };
            return Ok(model);
        }
        [Authorize(Roles = "admin")]
        [Route("User/GetAllPersons")]
        [HttpGet]
        public async Task<IHttpActionResult> GetAllPersons()
        {
            var identityClaims = (ClaimsIdentity)User.Identity;
            var personId = identityClaims.FindFirst("Id").Value;
            var persons = await _personService.GetAllPersonsExeptHimself(personId);
            return Ok(persons);
        }

        [Route("User/Login")]
        [HttpPost]
        public async Task<HttpResponseMessage> LoginUser(LoginVM model)
        {
            
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
        [Authorize(Roles ="admin")]
        [Route("User/GetExperts")]
        [HttpGet]
        public async Task<IHttpActionResult> GetExperts()
        {
            var experts = await _solutionService.GetAllExpertsWithRating();
            return Ok(experts);
        }
        [Authorize]
        [Route("User/Update")]
        [HttpPut]
        public async Task<IHttpActionResult> UpdatePersonInfo(UpdatePersonVM updatePerson)
        {
            var identityClaims = (ClaimsIdentity)User.Identity;
            var adminId = identityClaims.FindFirst("Id").Value;
            var person = await _personService.UpdatePersonAsync(adminId,updatePerson.Name, updatePerson.LastName, updatePerson.Email);          
            return Ok(person);
        }
        [Authorize]
        [Route("User/ChangePassword")]
        [HttpPut]
        public async Task<IHttpActionResult> ChangePassword(ChangePasswordVM changePass)
        {
            var identityClaims = (ClaimsIdentity)User.Identity;
            var adminId = identityClaims.FindFirst("Id").Value;
            var person = await _personService.ChangePassword(adminId, changePass.CurrentPassword, changePass.Password);
            return Ok(person);
        }
        [Authorize(Roles ="user")]
        [Route("User/GetUsersFilesHistory")]
        [HttpGet]
        public async Task<IHttpActionResult> GetUsersFilesHistory()
        {
            var identityClaims = (ClaimsIdentity)User.Identity;
            var userId = identityClaims.FindFirst("Id").Value;
            var UserFiles = await _fileService.GetUsersFileInfo(userId);
            return Ok(UserFiles);
        }
        [Authorize(Roles ="expert,admin")]
        [Route("User/GetExpertsSolutionsHistory")]
        [HttpGet]
        public async Task<IHttpActionResult> GetExpertsSolutionsHistory()
        {
            var identityClaims = (ClaimsIdentity)User.Identity;
            var userId = identityClaims.FindFirst("Id").Value;
            var expertSolutionHistory = await _solutionService.GetExpertsSolutionHistory(userId);
            return Ok(expertSolutionHistory);
        }
        [Authorize(Roles ="admin")]
        [Route("User/DeleteUser/{id}")]
        [HttpDelete]
        public async Task<IHttpActionResult> DeleteUser(string id)
        { 
            await _solutionService.DeleteUserData(id);
            return Ok();
        }
    }
}
