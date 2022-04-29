using FieldAgent.Core.Entities;
using FieldAgent.Core.Interfaces.DAL;
using FieldAgent.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace FieldAgent.MVC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgencyAgentController : Controller
    {
        private readonly IAgencyAgentRepository agencyAgentRepo;

        public AgencyAgentController(IAgencyAgentRepository _agencyAgentRepo)
        {
            agencyAgentRepo = _agencyAgentRepo;
        }

        [HttpGet]
        public IActionResult Get(ViewAgencyAgent viewAgencyAgent)
        {
            var result = agencyAgentRepo.Get(viewAgencyAgent.AgencyID, viewAgencyAgent.AgentID);

            if (result.Success)
            {
                return Ok(new ViewAgencyAgent
                {
                    AgencyID = result.Data.AgencyID,
                    AgentID = result.Data.AgentID,
                    BadgeID = result.Data.BadgeID,
                    SecurityClearanceID = result.Data.SecurityClearanceID,
                    ActivationDate = result.Data.ActivationDate,
                    DeactivationDate = result.Data.DeactivationDate,
                    IsActive = result.Data.IsActive
                });
            }
            else
            {
                return BadRequest(result.Message);
            }
        }

        [HttpGet]
        [Route("agent/{id}")]
        public IActionResult GetByAgent(int id)
        {
            var result = agencyAgentRepo.GetByAgent(id);

            if (result.Success)
            {
                return Ok(result.Data.Select(
                    aa => new ViewAgencyAgent()
                    {
                        AgencyID = aa.AgencyID,
                        AgentID = aa.AgentID,
                        BadgeID = aa.BadgeID,
                        SecurityClearanceID = aa.SecurityClearanceID,
                        ActivationDate = aa.ActivationDate,
                        DeactivationDate = aa.DeactivationDate,
                        IsActive = aa.IsActive
                    }
                    )
                    );
            }
            else
            {
                return BadRequest(result.Message);
            }
        }

        [HttpGet]
        [Route("agency/{id}")]
        public IActionResult GetByAgency(int id)
        {
            var result = agencyAgentRepo.GetByAgency(id);

            if (result.Success)
            {
                return Ok(result.Data.Select(
                    aa => new ViewAgencyAgent()
                    {
                        AgencyID = aa.AgencyID,
                        AgentID = aa.AgentID,
                        BadgeID = aa.BadgeID,
                        SecurityClearanceID = aa.SecurityClearanceID,
                        ActivationDate = aa.ActivationDate,
                        DeactivationDate = aa.DeactivationDate,
                        IsActive = aa.IsActive
                    }
                    )
                    );
            }
            else
            {
                return BadRequest(result.Message);
            }
        }

        [HttpPost]
        public IActionResult AddAgencyAgent(ViewAgencyAgent viewAgencyAgent)
        {
            AgencyAgent aa = new AgencyAgent();
            aa.AgencyID = viewAgencyAgent.AgencyID;
            aa.AgentID = viewAgencyAgent.AgentID;   
            aa.BadgeID = viewAgencyAgent.BadgeID;
            aa.SecurityClearanceID = viewAgencyAgent.SecurityClearanceID;
            aa.ActivationDate = viewAgencyAgent.ActivationDate;
            aa.DeactivationDate = viewAgencyAgent.DeactivationDate;
            aa.IsActive = viewAgencyAgent.IsActive;

            var result = agencyAgentRepo.Insert(aa);

            return result.Success ? Ok(result.Data) : BadRequest(result.Message);
        }

        [HttpPut]
        public IActionResult EditAgencyAgent(ViewAgencyAgent viewAgencyAgent)
        {
            if (!agencyAgentRepo.Get(viewAgencyAgent.AgencyID ,viewAgencyAgent.AgentID).Success)
            {
                return NotFound($"AgencyAgent of Agent ID {viewAgencyAgent.AgentID} not found");
            }

            AgencyAgent aa = new AgencyAgent
            {
                AgencyID = viewAgencyAgent.AgencyID,
                AgentID = viewAgencyAgent.AgentID,
                BadgeID = viewAgencyAgent.BadgeID,
                SecurityClearanceID = viewAgencyAgent.SecurityClearanceID,
                ActivationDate = viewAgencyAgent.ActivationDate,
                DeactivationDate = viewAgencyAgent.DeactivationDate,
                IsActive = viewAgencyAgent.IsActive
            };

            var result = agencyAgentRepo.Update(aa);

            return result.Success ? Ok(aa) : BadRequest(result.Message);
        }

        [HttpDelete]
        public IActionResult DeleteAgencyAgent(ViewAgencyAgent viewAgencyAgent)
        {
            var foundAgencyAgent = agencyAgentRepo.Get(viewAgencyAgent.AgencyID, viewAgencyAgent.AgentID);
            if (!foundAgencyAgent.Success)
            {
                return NotFound($"Agent {viewAgencyAgent.AgentID} and Agency {viewAgencyAgent.AgencyID} not found");
            }

            var result = agencyAgentRepo.Delete(foundAgencyAgent.Data.AgencyID, foundAgencyAgent.Data.AgentID);

            return result.Success ? Ok(foundAgencyAgent) : BadRequest(result.Message);
        }
    }
}
