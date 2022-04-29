using FieldAgent.Core.Entities;
using FieldAgent.Core.Interfaces.DAL;
using FieldAgent.MVC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace FieldAgent.MVC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgencyController : ControllerBase
    {
        private readonly IAgencyRepository agencyRepo;

        public AgencyController(IAgencyRepository _agencyRepo)
        {
            agencyRepo = _agencyRepo;
        }

        [HttpGet/*, Authorize*/]
        public IActionResult GetAgencies()
        {
            var result = agencyRepo.GetAll();

            if (result.Success)
            {
                return Ok(result.Data.Select(
                    a => new ViewAgency()
                    {
                        AgencyID = a.AgencyID,
                        ShortName = a.ShortName,
                        LongName = a.LongName
                    }));
            }
            else
            {
                return BadRequest(result.Message);
            }
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetAgency(int id)
        {
            var result = agencyRepo.Get(id);

            if (result.Success)
            {
                return Ok(new ViewAgency()
                {
                    AgencyID = result.Data.AgencyID,
                    ShortName = result.Data.ShortName,
                    LongName = result.Data.LongName
                });
            }
            else
            {
                return BadRequest(result.Message);
            }
        }

        [HttpPost]
        public IActionResult AddAgency(ViewAgency viewAgency)
        {
            Agency a = new();
            a.ShortName = viewAgency.ShortName;
            a.LongName = viewAgency.LongName;

            var result = agencyRepo.Insert(a);

            return result.Success ? Ok(result.Data) : BadRequest(result.Message);
        }

        [HttpPut]
        public IActionResult EditAgent(ViewAgency viewAgency)
        {
            if (!agencyRepo.Get(viewAgency.AgencyID).Success)
            {
                return NotFound($"Agency {viewAgency.AgencyID} not found");
            }

            Agency a = new Agency
            {
                AgencyID = viewAgency.AgencyID,
                ShortName = viewAgency.ShortName,
                LongName = viewAgency.LongName
            };

            var result = agencyRepo.Update(a);

            return result.Success ? Ok(a) : BadRequest(result.Message);
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteAgency(int id)
        {
            var foundAgency = agencyRepo.Get(id);
            if (!foundAgency.Success)
            {
                return NotFound($"Agent {id} not found");
            }

            var result = agencyRepo.Delete(id);

            return result.Success ? Ok(foundAgency) : BadRequest(result.Message);
        }
    }
}
