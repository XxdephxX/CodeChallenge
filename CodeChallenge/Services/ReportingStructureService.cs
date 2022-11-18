using System;
using System.Linq;
using CodeChallenge.Models;
using Microsoft.Extensions.Logging;

namespace CodeChallenge.Services
{
    public interface IReportingStructureService
    {
        ReportingStructure GenerateReportingStructure(string employeeId);
    }

    public class ReportingStructureService : IReportingStructureService
    {
        private readonly ILogger<ReportingStructureService> _logger;
        private readonly IEmployeeService _employeeService;

        public ReportingStructureService(
            ILogger<ReportingStructureService> logger,
            IEmployeeService service)
        {
            _logger = logger;
            _employeeService = service;
        }

        public ReportingStructure GenerateReportingStructure(string employeeId)
        {
            var employee = _employeeService.GetById(employeeId);

            return new ReportingStructure(employee, CalculateDirectReports(employeeId));
        }

        public int CalculateDirectReports(string employeeId)
        {
            var total = 0;

            var employee = _employeeService.GetById(employeeId);

            Console.WriteLine(employee.FirstName);

            if (employee is null || !employee.DirectReports.Any()) return total;

            total += employee.DirectReports.Count;

            foreach (var e in employee.DirectReports)
            {
                total += CalculateDirectReports(e.EmployeeId);
            }

            return total;
        }
    }
}

