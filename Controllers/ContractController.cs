using DutchCourse.Database.Entities;
using DutchCourse.Database.Repositories;
using DutchCourse.WebApi.Models;
using System;
using System.Web.Http;

namespace DutchCourse.WebApi.Controllers
{
    public class ContractController : ApiController
    {
        private readonly IContract _contract;

        public ContractController(IContract contract)
        {
            _contract = contract;
        }

        [HttpPost]
        public IHttpActionResult Post([FromBody] ContractModel contractModel)
        {
            if (contractModel == null)
                return NotFound();

            var contractEntity = new ContractEntity
            {
                ContractDate = DateTime.UtcNow,
                AdminCost = contractModel.AdminCost,
                CostPerHour = contractModel.CostPerHour,
                LesMaterialCost = contractModel.LesMaterialCost,
                TotalCost = contractModel.TotalCost,
                TotalHours = contractModel.TotalHours
            };

            _contract.Add(contractEntity);

            return Ok(new GenericResult() {Success = true});
        }

        [HttpGet]
        [Route("GetOne")]
        public IHttpActionResult GetOne([FromBody]int contractId)
        {
            var result = _contract.GetAll();
            return Ok(result);
        }

        [HttpGet]
        public IHttpActionResult GetAll()
        {
            var result = _contract.GetAll();
            return Ok(result);
        }
    }
}