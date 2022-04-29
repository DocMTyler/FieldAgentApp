using FieldAgent.Core.Entities;
using FieldAgent.Core.Interfaces.DAL;
using FieldAgent.MVC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace FieldAgent.MVC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AliasController : ControllerBase
    {
        private readonly IAliasRepository aliasRepo;

        public AliasController(IAliasRepository _aliasRepo)
        {
            aliasRepo = _aliasRepo;
        }

        [HttpGet]
        public IActionResult Get(ViewAlias viewAlias)
        {
            var result = aliasRepo.Get(viewAlias.AliasID);

            if (result.Success)
            {
                return Ok(new ViewAlias
                {
                    AliasID = result.Data.AliasID,
                    AliasName = result.Data.AliasName,
                    InterpolID = result.Data.InterpolID,
                    AgentID = result.Data.AgentID,
                    Persona = result.Data.Persona
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
            var result = aliasRepo.GetByAgent(id);

            if (result.Success)
            {
                return Ok(result.Data.Select(
                    a => new ViewAlias()
                    {
                        AliasID = a.AliasID,
                        AliasName = a.AliasName,
                        InterpolID = a.InterpolID,
                        AgentID = a.AgentID,
                        Persona = a.Persona
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
        public IActionResult AddAlias(ViewAlias viewAlias)
        {
            Alias a = new Alias();
            a.AliasID = viewAlias.AliasID;
            a.AliasName = viewAlias.AliasName;
            a.InterpolID = viewAlias.InterpolID;
            a.AgentID = viewAlias.AgentID;
            a.Persona = viewAlias.Persona;

            var result = aliasRepo.Insert(a);

            return result.Success ? Ok(result.Data) : BadRequest(result.Message);
        }

        [HttpPut]
        public IActionResult EditAlias(ViewAlias viewAlias)
        {
            if (!aliasRepo.Get(viewAlias.AliasID).Success)
            {
                return NotFound($"Alias {viewAlias.AliasID} not found");
            }

            Alias a = new Alias();
            a.AliasID = viewAlias.AliasID;
            a.AliasName = viewAlias.AliasName;
            a.InterpolID = viewAlias.InterpolID;
            a.AgentID = viewAlias.AgentID;
            a.Persona = viewAlias.Persona;

            var result = aliasRepo.Update(a);

            return result.Success ? Ok(a) : BadRequest(result.Message);
        }

        [HttpDelete]
        public IActionResult DeleteAlias(ViewAlias viewAlias)
        {
            var foundAlias = aliasRepo.Get(viewAlias.AliasID);
            if (!foundAlias.Success)
            {
                return NotFound($"Alias {viewAlias.AliasID} not found");
            }

            var result = aliasRepo.Delete(foundAlias.Data.AliasID);

            return result.Success ? Ok(foundAlias) : BadRequest(result.Message);
        }
    }
}
