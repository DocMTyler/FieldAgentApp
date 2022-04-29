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
    public class MissionController : ControllerBase
    {
        private readonly IMissionRepository missionRepo;

        public MissionController(IMissionRepository _missionRepo)
        {
            missionRepo = _missionRepo;
        }

        [HttpGet]
        public IActionResult Get(ViewMission viewMission)
        {
            var result = missionRepo.Get(viewMission.MissionID);

            if (result.Success)
            {
                return Ok(new Mission
                {
                    MissionID = result.Data.MissionID,
                    AgencyID = result.Data.AgencyID,
                    CodeName = result.Data.CodeName,
                    Notes = result.Data.Notes,
                    StartDate = result.Data.StartDate,
                    ProjectedEndDate = result.Data.ProjectedEndDate,
                    ActualEndDate = result.Data.ActualEndDate,
                    OperationalCost = result.Data.OperationalCost
                });
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
            var result = missionRepo.GetByAgency(id);

            if (result.Success)
            {
                return Ok(result.Data.Select(
                    aa => new ViewMission()
                    {
                        MissionID =aa.MissionID,
                        AgencyID=aa.AgencyID,
                        CodeName=aa.CodeName,
                        Notes=aa.Notes,
                        StartDate=aa.StartDate,
                        ProjectedEndDate=aa.ProjectedEndDate,
                        ActualEndDate=aa.ActualEndDate,
                        OperationalCost=aa.OperationalCost
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
        [Route("agent/{id}")]
        public IActionResult GetByAgent(int id)
        {
            var result = missionRepo.GetByAgent(id);

            if (result.Success)
            {
                return Ok(result.Data.Select(
                    aa => new ViewMission()
                    {
                        MissionID = aa.MissionID,
                        AgencyID = aa.AgencyID,
                        CodeName = aa.CodeName,
                        Notes = aa.Notes,
                        StartDate = aa.StartDate,
                        ProjectedEndDate = aa.ProjectedEndDate,
                        ActualEndDate = aa.ActualEndDate,
                        OperationalCost = aa.OperationalCost
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
        public IActionResult AddMission(ViewMission viewMission)
        {
            Mission m = new Mission();
            m.MissionID = viewMission.MissionID;
            m.AgencyID = viewMission.AgencyID;
            m.CodeName = viewMission.CodeName;
            m.Notes = viewMission.Notes;
            m.StartDate = viewMission.StartDate;
            m.ProjectedEndDate = viewMission.ProjectedEndDate;
            m.ActualEndDate = viewMission.ActualEndDate;
            m.OperationalCost = viewMission.OperationalCost;

            var result = missionRepo.Insert(m);

            return result.Success ? Ok(result.Data) : BadRequest(result.Message);
        }

        [HttpPut]
        public IActionResult EditMission(ViewMission viewMission)
        {
            if (!missionRepo.Get(viewMission.MissionID).Success)
            {
                return NotFound($"Mission {viewMission.MissionID} not found");
            }

            Mission m = new Mission();
            m.MissionID = viewMission.MissionID;
            m.AgencyID = viewMission.AgencyID;
            m.CodeName = viewMission.CodeName;
            m.Notes = viewMission.Notes;
            m.StartDate = viewMission.StartDate;
            m.ProjectedEndDate = viewMission.ProjectedEndDate;
            m.ActualEndDate = viewMission.ActualEndDate;
            m.OperationalCost = viewMission.OperationalCost;

            var result = missionRepo.Update(m);

            return result.Success ? Ok(m) : BadRequest(result.Message);
        }

        [HttpDelete]
        public IActionResult DeleteMission(ViewMission viewMission)
        {
            var foundMission = missionRepo.Get(viewMission.MissionID);
            if (!missionRepo.Get(viewMission.MissionID).Success)
            {
                return NotFound($"Mission {viewMission.MissionID} not found");
            }

            var result = missionRepo.Delete(foundMission.Data.MissionID);

            return result.Success ? Ok(foundMission.Data) : BadRequest(result.Message);
        }
    }
}
