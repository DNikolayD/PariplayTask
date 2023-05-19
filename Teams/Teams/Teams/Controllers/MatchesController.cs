using Microsoft.AspNetCore.Mvc;
using Services.Dtos;
using Services.Interfaces;
using System;
using System.Threading.Tasks;

namespace Teams.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class MatchesController : ControllerBase
    {
        private readonly IMatchesService _services;

        public MatchesController(IMatchesService service)
        {
            _services = service;
        }

        [HttpGet]
        public IActionResult GetMatches()
        {
            try
            {
                return Ok(_services.GetAllMatches());
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }

        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetMatchesByTeamId([FromRoute] string id)
        {
            try
            {
                return Ok(_services.GetMatchesByTeamId(id));
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }

        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetMatchesByIdAsync([FromRoute] string id)
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
        public async Task<IActionResult> CreateMatchAsync([FromForm] MatchDto matchDto)
        {
            try
            {
                await _services.CreateAsync(matchDto);
                return Ok();
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }

        [HttpPut]
        public IActionResult UpdateMatch([FromForm] MatchDto matchDto)
        {
            try
            {
                _services.Update(matchDto);
                return Ok();
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteMatch([FromRoute] string id)
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
