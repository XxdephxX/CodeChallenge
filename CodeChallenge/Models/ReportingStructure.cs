namespace CodeChallenge.Models
{
    public class ReportingStructure
    {
        public Employee Employee { get; set; }
        public int NumberOfReports { get; set; }

        public ReportingStructure(Employee employee, int numberOfReports = 0)
        { 
            if (!string.IsNullOrWhiteSpace(employee.EmployeeId))
            { 
                Employee = employee; 
                NumberOfReports = numberOfReports;
            }
        }
    }
}
