using System;
using System.Data.SQLite;

namespace PhoneBookTestApp
{
    public class PhoneBook : IPhoneBook
    {
        public void addPerson(Person person)
        {
            string insertSQL = string.Format("INSERT INTO PHONEBOOK (NAME, PHONENUMBER, ADDRESS) " +
                    "VALUES('{0}','{1}','{2}')", person.name, person.phoneNumber, person.address);

            SQLiteCommand command = new SQLiteCommand(insertSQL, DatabaseUtil.GetConnection());
            command.ExecuteNonQuery();
        }

        public Person findPerson(string firstName, string lastName)
        {
            string sql = string.Format("SELECT * FROM PHONEBOOK WHERE name = '{0} {1}'", firstName, lastName);
            SQLiteCommand command = new SQLiteCommand(sql, DatabaseUtil.GetConnection());
            SQLiteDataReader rdr = command.ExecuteReader();

            Person prs = null;
            while(rdr.Read())
            {
                prs = new Person();
                prs.name = rdr.GetString(0);
                prs.phoneNumber = rdr.GetString(1);
                prs.address = rdr.GetString(2);
            }

            return prs;
        }
    }
}