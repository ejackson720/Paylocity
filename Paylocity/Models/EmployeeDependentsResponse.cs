namespace Paylocity.Models
{
    public class EmployeeDependentsResponse
    {        
        public List<Person> People { get; set; }
        public bool HasError { get; set; }

        public EmployeeDependentsResponse()
        {
            Dependents = new List<Person>();
        }
    }
}
