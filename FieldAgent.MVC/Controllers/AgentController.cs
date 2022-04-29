using FieldAgent.Core.Entities;
using FieldAgent.Core.Interfaces.DAL;
using FieldAgent.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace FieldAgent.MVC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgentController : ControllerBase
    {
        private readonly IAgentRepository agentRepo;

        public AgentController(IAgentRepository _agentRepo)
        {
            agentRepo = _agentRepo;
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetAgent(int id)
        {
            var result = agentRepo.Get(id);

            if (result.Success)
            {
                return Ok(new ViewAgent()
                {
                    AgentID = result.Data.AgentID,
                    FirstName = result.Data.FirstName,
                    LastName = result.Data.LastName,
                    DateOfBirth = result.Data.DateOfBirth,
                    Height = result.Data.Height
                });
            }
            else
            {
                return BadRequest(result.Message);
            }
        }

        [HttpGet]
        [Route("missions/{id}")]
        public IActionResult GetMissionsbyAgent(int id)
        {
            var result = agentRepo.GetMissions(id);

            if (result.Success)
            {
                return Ok(result.Data.Select(
                    m => new ViewMission()
                    {
                        MissionID = m.MissionID,
                        CodeName = m.CodeName,
                        Notes = m.Notes,
                        StartDate = m.StartDate,
                        ProjectedEndDate = m.ProjectedEndDate,
                        ActualEndDate = m.ActualEndDate,
                        OperationalCost = m.OperationalCost
                    }
                    )
                    );
            }
            else
            {
                return BadRequest("This is where it's happening");
            }
        }

        [HttpPost]
        public IActionResult AddAgent(ViewAgent viewAgent)
        {
            Agent a = new Agent();
            a.FirstName = viewAgent.FirstName;
            a.LastName = viewAgent.LastName;
            a.DateOfBirth = viewAgent.DateOfBirth;
            a.Height = viewAgent.Height;

            var result = agentRepo.Insert(a);

            if (result.Success)
            {
                return Ok(result.Data);
            }
            else
            {
                return BadRequest(result.Message);
            }
        }

        [HttpPut]
        public IActionResult EditAgent(ViewAgent viewAgent)
        {
            if (!agentRepo.Get(viewAgent.AgentID).Success)
            {
                return NotFound($"Agent {viewAgent.AgentID} not found");
            }
            
            Agent a = new Agent 
            { 
                AgentID = viewAgent.AgentID,
                FirstName = viewAgent.FirstName, 
                LastName = viewAgent.LastName, 
                DateOfBirth = viewAgent.DateOfBirth,
                Height = viewAgent.Height
            };

            var result = agentRepo.Update(a);

            if (result.Success)
            {
                return Ok(a);
            }
            else
            {
                return BadRequest(result.Message);
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteAgent(int id)
        {
            var foundAgent = agentRepo.Get(id);
            if (!foundAgent.Success)
            {
                return NotFound($"Agent {id} not found");
            }

            var result = agentRepo.Delete(id);

            if (result.Success)
            {
                return Ok(foundAgent);
            }
            else
            {
                return BadRequest(result.Message);
            }
        }
    }
}
