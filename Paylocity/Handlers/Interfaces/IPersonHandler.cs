﻿using Paylocity.Models;

namespace Paylocity.Handlers.Interfaces
{
    public interface IPersonHandler
    {
        Person GetPerson(string name, bool isDependent);
        Person GetEmployee(EmployeeDependentsResponse response);
        int GetNumberPeopleDiscounted(EmployeeDependentsResponse response);
        int GetNumberOfDependents(EmployeeDependentsResponse response);
        decimal GetAnnualCost(EmployeeDependentsResponse response);
    }
}
