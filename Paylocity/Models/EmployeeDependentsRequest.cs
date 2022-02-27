namespace Paylocity.Models
{
    public class EmployeeDependentsRequest
    {
        public string EmployeeName { get; set; }
        public List<string> Dependents { get; set; }
    }
}
