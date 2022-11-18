using CodeChallenge.Models;
using CodeChallenge.Services;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CodeChallenge.Controllers
{
    [ApiController]
    [Route("api/compensation")]
    public class CompensationController : ControllerBase
    {
        private readonly ICompensationService _compensationService;

        public CompensationController(ICompensationService service)
        {
            _compensationService = service;
        }

        [HttpPost()]
        public IActionResult CreateCompensation([FromBody] Compensation compensation)
        {
            Console.WriteLine("hit - 1");

            try
            {
                return Ok(_compensationService.Create(compensation));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message + Environment.NewLine + e.InnerException?.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetCompensation(string id)
        {
            Console.WriteLine("hit - 2");

            try
            {
                return Ok(_compensationService.GetById(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message + Environment.NewLine + e.InnerException?.Message);
            }
        }
    }
}
