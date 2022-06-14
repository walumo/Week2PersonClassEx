using System;
using System.Collections.Generic;
using System.Linq;

namespace PersonClassEx1
{
    static class Program
    {
        static void Main(string[] args)
        {

            List<Person> list = new List<Person>();
            list.Add(new Person(fname: "Matti", lname: "Meikäläinen", email: "masa@g00gle.com", dob: DateTime.Now.AddYears(-57).AddMonths(-5)));
            list.Add(new Person(fname: "Teijo", lname: "Turhake", email: "teukka@saunatahti.fi", dob: DateTime.Now.AddYears(-45).AddMonths(-2)));
            list.Add(new Person(fname: "Jonne", lname: "Juolavehnä", email: "jonzki1337@yahhoo.com", dob: DateTime.Now.AddYears(-22).AddMonths(-1)));
            list.Add(new Person(fname: "Ritva", lname: "Virkavaurio", email: "ritva.virkavaurio@mela.fi", dob: DateTime.Now.AddYears(-63).AddMonths(-7)));
            list.Add(new Person(fname: "Kai", lname: "Kuu", email: "kaikuuko@suomi244.fi", dob: DateTime.Now.AddYears(-36).AddMonths(-11)));

            Console.Write("Person from index 0: ");
            Console.WriteLine(Person.GetAge(list[0]));
            Console.WriteLine(Environment.NewLine);

            IEnumerable<Person> overAvg = Person.OverAvg(list);


            Console.WriteLine("Persons with age over average of collection: ");

            foreach (Person person in overAvg.ToList())
            {
                Console.WriteLine(person.FirstName + " " + (DateTime.Now.Year - person.DateOfBirth.Year));
            }
            Console.WriteLine(Environment.NewLine);


            Console.WriteLine("All entries in collection: ");
            foreach (Person person in list)
            {
                Console.WriteLine(person.FirstName + " " + (DateTime.Now.Year - person.DateOfBirth.Year));
            }
            Console.WriteLine(Environment.NewLine);

        }
    }

    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Person(string fname, string lname, string email, DateTime dob)
        {
            this.FirstName = fname;
            this.LastName = lname;
            this.Email = email;
            this.DateOfBirth = dob;
        }
        public Person(string fname, string lname, string email)
        {
            this.FirstName = fname;
            this.LastName = lname;
            this.Email = email;
        }
        public Person(string fname, string lname, DateTime dob)
        {
            this.FirstName = fname;
            this.LastName = lname;
            this.DateOfBirth = dob;
        }

        public static string GetAge(Person person)
        {
            return person.FirstName + " " + (DateTime.Now.Year - person.DateOfBirth.Year).ToString();
        }
        public static IEnumerable<Person> OverAvg(List<Person> list)
        {
            int avg = default;
            foreach (Person person in list)
            {
                avg += DateTime.Now.Year - person.DateOfBirth.Year;
            }

            avg /= list.Count();

            return list.Where(pers => (DateTime.Now.Year - pers.DateOfBirth.Year) > avg);
        }

    }
}