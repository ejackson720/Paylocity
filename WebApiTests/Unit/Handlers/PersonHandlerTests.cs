using NUnit.Framework;
using Paylocity.Handlers;
using Paylocity.Handlers.Interfaces;

namespace WebApiTests.Unit.Handlers
{
    [TestFixture]
    [Category("Unit")]
    internal class PersonHandlerTests
    {
        IPersonHandler _personHandler;
        IRulesHandler _rulesHandler;

        [SetUp]
        public void Setup()
        {
            _rulesHandler = new RulesHandler();
            _personHandler = new PersonHandler(_rulesHandler);
        }

        [Test]
        public void GetPerson_GoodDataEmployee_ReturnsPerson()
        {
            //Arrange
            string name = "Eric Jackson";

            //Act
            var person = _personHandler.GetPerson(name, false);

            //Assert
            Assert.IsTrue(person.Name == name && 
                person.IsDiscounted == false && 
                person.Cost == 1000 && 
                person.IsEmployee == true);
        }

        [Test]
        public void GetPerson_GoodDataNotEmployee_ReturnsPerson()
        {
            //Arrange
            string name = "Eric Smith";

            //Act
            var person = _personHandler.GetPerson(name, true);

            //Assert
            Assert.IsTrue(person.Name == name);
            Assert.IsTrue(person.IsDiscounted == false);
            Assert.IsTrue(person.Cost == 500);
            Assert.IsTrue(person.IsEmployee == false);
        }

        [Test]
        public void GetPerson_GoodDataNotEmployeeStartsWithA_ReturnsPerson()
        {
            //Arrange
            string name = "Amy Smith";

            //Act
            var person = _personHandler.GetPerson(name, true);

            //Assert
            Assert.IsTrue(person.Name == name);
            Assert.IsTrue(person.IsDiscounted == true);
            Assert.IsTrue(double.Equals(person.Cost, (500 * .9)));
            Assert.IsTrue(person.IsEmployee == false);
        }

        [Test]
        public void GetPerson_GoodDataEmployeeStartsWithA_ReturnsPerson()
        {
            //Arrange
            string name = "Amy Smith";

            //Act
            var person = _personHandler.GetPerson(name, false);

            //Assert
            Assert.IsTrue(person.Name == name);
            Assert.IsTrue(person.IsDiscounted == true);
            Assert.IsTrue(double.Equals(person.Cost, (1000 * .9)));
            Assert.IsTrue(person.IsEmployee == true);
        }
    }
}
