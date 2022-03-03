namespace Paylocity.Models
{
    public class EmployeeDependentsResponse
    {        
        public List<Person> People { get; set; }
        public bool HasError { get; set; }

        public EmployeeDependentsResponse()
        {
            People = new List<Person>();
        }

        public int GetNumberPeopleDiscounted()
        {
            if (People == null)
            {
                throw new Exception("Invalid People");
            }
            return People.Where(x => x.IsDiscounted == true).ToList().Count();
        }

        public int GetNumberDependentsDiscounted()
        {
            if (People == null)
            {
                throw new Exception("Invalid People");
            }
            return People.Where(x => x.IsDiscounted == true && x.IsEmployee == false).ToList().Count();
        }
        public int GetNumberOfDependents()
        {

            if (People == null)
            {
                throw new Exception("Invalid People");
            }
            return People.Where(x => x.IsEmployee == false).ToList().Count();
        }

        public string GetAnnualCostSTring()
        {
            return GetAnnualCost().ToString("N2");
        }
        public double GetAnnualCost()
        {
            if (People == null)
            {
                throw new Exception("Invalid People");
            }
            return People.Select(x => x.Cost).Sum();
        }

        public string GetPaycheckAfterDeductions(double paycheckAnnual, double numPayChecksInYear)
        {
            double annualDeductions = People.Select(x => x.Cost).Sum();

            var paycheck = (paycheckAnnual - annualDeductions) / numPayChecksInYear;

            return Math.Round(paycheck, 2).ToString("N2");
        }

        public string GetDependentNames()
        {
            if (People == null)
            {
                throw new Exception("Invalid People");
            }
            var result = String.Join(", ", People.Where(x => x.IsEmployee == false).Select(x => x.Name));
            if(result.Length == 0)
            {
                return string.Empty;
            }
            return $"({result})";
        }

        public string GetCostPaycheck(double numPayChecksInYear)
        {
            if (People == null)
            {
                throw new Exception("Invalid People");
            }
            return Math.Round((GetAnnualCost() / numPayChecksInYear),2).ToString("N2");
        }
    }
}
