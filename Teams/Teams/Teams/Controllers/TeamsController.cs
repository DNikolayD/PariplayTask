using Microsoft.AspNetCore.Mvc;
using Services.Dtos;
using Services.Interfaces;
using System;
using System.Threading.Tasks;

namespace Teams.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class TeamsController : ControllerBase
    {
        private readonly ITeamsService _services;

        public TeamsController(ITeamsService service)
        {
            _services = service;
        }

        [HttpGet]
        public IActionResult GetTeams()
        {
            try
            {
                return Ok(_services.GetTeams());
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }

        }

        [HttpGet]
        public IActionResult GetTeamsOrderedByRank()
        {
            try
            {
                return Ok(_services.GetTeamsOrderedByRanking());
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }

        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetTeamsByIdAsync([FromRoute] string id)
        {
            try
            {
                return Ok(await _services.GetByIdAsync(id));
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateTeamAsync([FromForm] TeamsDto teamsDto)
        {
            try
            {
                await _services.CreateAsync(teamsDto);
                return Ok();
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateTeam([FromForm] TeamsDto teamsDto)
        {
            try
            {
                await _services.Update(teamsDto);
                return Ok();
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteTeam([FromRoute] string id)
        {
            try
            {
                await _services.DeleteAsync(id);
                return Ok();
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }
    }
}
