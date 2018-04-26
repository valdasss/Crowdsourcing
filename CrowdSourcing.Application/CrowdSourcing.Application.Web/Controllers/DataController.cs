using CrowdSourcing.Contract.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace CrowdSourcing.Application.Web.Controllers
{
    [RoutePrefix("Data")]
    public class DataController : ApiController
    {
        private IDataService _dataService;

        public DataController(IDataService dataService)
        {
            _dataService = dataService;
        }

        [HttpGet]
        [Route("GetForDetails/{id}")]
        public async Task<IHttpActionResult> GetDataForDetails(int id)
        {
            var dataModel = await _dataService.GetDataForMoreDetailsBy(id);
            return Ok(dataModel);
        }

    }
}
