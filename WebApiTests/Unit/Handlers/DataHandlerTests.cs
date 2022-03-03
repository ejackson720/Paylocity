using NUnit.Framework;
using Paylocity.Handlers;
using Paylocity.Handlers.Interfaces;
using Paylocity.Models;
using System;

namespace WebApiTests.Unit.Handlers
{
    [TestFixture]
    [Category("Unit")]
    internal class DataHandlerTests
    {
        IRulesHandler _rulesHandler;
        IPersonHandler _personHandler;
        private DataHandler _dataHandler;
        private int PAYCHECK_ANNUAL = 2000;
        private int NUM_OF_PAYCHECK = 26;

        [SetUp]
        public void Setup()
        {            
            _rulesHandler = new RulesHandler();
            _personHandler = new PersonHandler(_rulesHandler);
            _dataHandler = new DataHandler(_personHandler);
        }

        [Test]
        public void ProcessEmployeeDependentsRequest_InvalidRequest_ReturnsError()
        {
            //Arrange           
            EmployeeDependentsRequest employeeDependentsRequest = new EmployeeDependentsRequest()
            {
                EmployeeName = string.Empty
            };
;
            //Act and Assert
            Assert.Throws<Exception>(() => { _dataHandler.ProcessEmployeeDependentsRequest(employeeDependentsRequest); });
        }

        [Test]
        public void ProcessEmployeeDependentsRequest_NullRequest_ReturnsError()
        {
          
            //Act and Assert
            Assert.Throws<Exception>(() => { _dataHandler.ProcessEmployeeDependentsRequest(null); });
        }
                

        [Test]
        public void ProcessEmployeeDependentsRequest_GoodRequest_ReturnsNoError()
        {
            //Arrange
            double exeptectedDeduction = 1000 + 1500;
            exeptectedDeduction = exeptectedDeduction / 26;
            double expectedPayCheck = 2000 - exeptectedDeduction;
            string expectedTotal = Math.Round(expectedPayCheck, 2).ToString("N2"); ;

            EmployeeDependentsRequest request = new EmployeeDependentsRequest()
            {
                EmployeeName = "Eric Smith",
                Dependents = new System.Collections.Generic.List<string>
                {
                    "John","Jacob","Junior"
                }
            };

            //Act
            EmployeeDependentsResponse employeeDependentsResponse = _dataHandler.ProcessEmployeeDependentsRequest(request);

            //Assert
            Assert.IsFalse(employeeDependentsResponse.HasError);
            Assert.AreEqual(expectedTotal, employeeDependentsResponse.GetPaycheckAfterDeductions(PAYCHECK_ANNUAL, NUM_OF_PAYCHECK));

        }

    }
    
}
