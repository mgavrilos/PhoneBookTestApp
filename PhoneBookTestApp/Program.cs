using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBookTestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = string.Empty;
            string phoneNumber = string.Empty;
            string address = string.Empty;

            try
            {
                DatabaseUtil.initializeDatabase();

                List<Person> lstPersons = new List<Person>();
                name = "Chris Johnson";
                phoneNumber = "(321) 231-7876";
                address = "452 Freeman Drive, Algonac, MI";
                AddPersonToList(lstPersons, name, phoneNumber, address);

                name = "Dave Williams";
                phoneNumber = "(231) 502 - 1236";
                address = "285 Huron St, Port Austin, MI";
                AddPersonToList(lstPersons, name, phoneNumber, address);

                name = "John Smith";
                phoneNumber = "(248) 123-4567";
                address = "1234 Sand Hill Dr, Royal Oak, MI";
                AddPersonToList(lstPersons, name, phoneNumber, address);

                name = "Cynthia Smith";
                phoneNumber = "(824) 128-8758";
                address = "875 Main St, Ann Arbor, MI";
                AddPersonToList(lstPersons, name, phoneNumber, address);

                // Add the phone records to DB
                PhoneBook phonebook = new PhoneBook();
                foreach (Person person1 in lstPersons)
                {
                    phonebook.addPerson(person1);
                }

                // Print all phones to System.out
                foreach (Person person2 in lstPersons)
                {
                    string prtString = string.Format("{0}, {1}, {2}", person2.name, person2.phoneNumber, person2.address);
                    Console.WriteLine(prtString);
                }

                // Find Cynthia ... and print it out.
                var fndPerson = phonebook.findPerson("Cynthia", "Smith");
                if (fndPerson != null)
                {
                    string prtString = string.Format("{0}, {1}, {2}", fndPerson.name, fndPerson.phoneNumber, fndPerson.address);
                    Console.WriteLine(prtString);
                }
            }
            catch (Exception ex)
            {
                string prtString = string.Format("Error: {0}", ex.Message);
                Console.WriteLine(prtString);
            }
            finally
            {
                DatabaseUtil.CleanUp();
            }
        }

        public static void AddPersonToList(List<Person> lstPersons, string name, string phoneNumber, string address)
        {
            Person person = new Person();
            person.name = name;
            person.phoneNumber = phoneNumber;
            person.address = address;
            lstPersons.Add(person);
        }
    }
}
