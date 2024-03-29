﻿using NUnit.Framework;
using Paylocity.Handlers;
using Paylocity.Handlers.Interfaces;

namespace WebApiTests.Unit.Handlers
{
    [TestFixture]
    [Category("Unit")]
    internal class RulesHandlerTests
    {
        IRulesHandler _rulesHandler;
        IPersonHandler _personHandler;
        [SetUp]
        public void Setup()
        {            
            _rulesHandler = new RulesHandler();
            _personHandler = new PersonHandler(_rulesHandler);
        }

        [Test]
        public void IsDiscounted_StartsWitA_ReturnsTrue()
        {
            //Arrange
            string name = "Amy Smith";

            //Act
            var isDiscounted = _rulesHandler.IsDiscounted(name);

            //Assert
            Assert.IsTrue(isDiscounted);

        }

        [Test]
        public void IsDiscounted_DoesNotStartsWitA_ReturnsFalse()
        {
            //Arrange
            string name = "Eric Smith";

            //Act
            var isDiscounted = _rulesHandler.IsDiscounted(name);

            //Assert
            Assert.IsFalse(isDiscounted);

        }

        [Test]
        public void IsDiscounted_StartsWithaLowerCase_ReturnsTrue()
        {
            //Arrange
            string name = "amy Smith";

            //Act
            var isDiscounted = _rulesHandler.IsDiscounted(name);

            //Assert
            Assert.IsFalse(isDiscounted);
        }

        [Test]
        public void IsDiscounted_DoesNotStartsWithALowerCase_ReturnsFalse()
        {
            //Arrange
            string name = "eric Smith";

            //Act
            var isDiscounted = _rulesHandler.IsDiscounted(name);

            //Assert
            Assert.IsFalse(isDiscounted);
        }


        [Test]
        public void GetCostAnnual_EmployeeNotDiscounted_Returns1000()
        {
            //Arrange
            string name = "eric Smith";

            //Act
            double total = _rulesHandler.GetCostAnnual("Eric Smith", false);

            //Assert
            Assert.AreEqual(total, 1000);
        }

        [Test]
        public void GetCostAnnual_EmployeeDiscounted_Returns950()
        {
            //Arrange
            string name = "eric Smith";

            //Act
            double total = _rulesHandler.GetCostAnnual("Amy Smith", false);

            //Assert
            Assert.AreEqual(900, total);
        }
    }
    
}
