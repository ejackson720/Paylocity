using Paylocity.Models;

namespace Paylocity.Handlers
{
    public class CalculatorHandler
    {
        private const decimal PERCENT_DISCOUNT = 1/10;

        public static Person ProcessDiscount(Person person)
        {
            if(person == null)
            {
                return person;
            }

            if (person.IsDiscounted)
            {
                person.Cost = person.Cost * PERCENT_DISCOUNT;
            }
            return person;
        }
    }
}
