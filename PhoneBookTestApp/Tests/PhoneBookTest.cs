using NUnit.Framework;
using PhoneBookTestApp;

namespace PhoneBookTestAppTests
{
    // ReSharper disable InconsistentNaming

    [TestFixture]
    public class PhoneBookTest
    {
        [Test]
        public void addPerson()
        {
            //Arrange
            PhoneBook phonebook = new PhoneBook();
            Person prs = new Person();
            prs.name = "firstname lastname";
            prs.phoneNumber = "myphone";
            prs.address = "myaddress";

            //Act
            phonebook.addPerson(prs);

            //Assert
            Assert.Pass();
        }

        [Test]
        public void findPerson()
        {
            //Arrange
            PhoneBook phonebook = new PhoneBook();
            Person prs = new Person();
            prs.name = "myfirstname mylastname";
            prs.phoneNumber = "myphone";
            prs.address = "myaddress";

            //Act
            phonebook.findPerson("myfirstname", "mylastname");

            //Assert
            Assert.Pass();
        }
    }

    // ReSharper restore InconsistentNaming 
}