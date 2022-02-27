namespace Paylocity.Models
{
    public class EmployeeDependentsResponse
    {
        public Person Employee { get; set; }
        public List<Person> Dependents { get; set; }
        public bool HasError { get; set; }

        public EmployeeDependentsResponse()
        {
            Dependents = new List<Person>();
        }
    }
}
