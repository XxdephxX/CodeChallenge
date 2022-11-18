using CodeChallenge.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace CodeChallenge.Controllers
{
    [ApiController]
    [Route("api/reportingStructure")]
    public class ReportingStructureController : ControllerBase
    {
        private readonly ILogger<ReportingStructureController> _logger;
        private readonly IReportingStructureService _reportingService;

        public ReportingStructureController(
            ILogger<ReportingStructureController> logger,
            IReportingStructureService service)
        {
            _logger = logger;
            _reportingService = service;
        }

        [HttpGet("{id}")]
        public IActionResult GetReportingStructureByEmployeeById(string id)
        {
            try
            {
                var reportingStructure = _reportingService.GenerateReportingStructure(id);

                return Ok(reportingStructure);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message + Environment.NewLine + e.InnerException?.Message);
            }
        }
    }
}

