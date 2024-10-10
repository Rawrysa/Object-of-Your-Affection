using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Object_of_Your_Affection
{
    internal class Profile
    {

        private string username, city, pronouns;
        private int age;
        private List<string> hobbies;
        public Profile() { }

        public Profile(string username, string city, int age, string pronouns = "Not Disclosed") 
        {
            this.username = username;
            this.city = city;
            this.pronouns = pronouns;
            this.age = age;
            this.hobbies = new List<string>();
        }

        public void ViewProfile()
        {
            Console.WriteLine($"Username: {username}" +
                $"\ncity: {city}" +
                $"\nPronouns: {pronouns}" +
                $"\nAge: {age}" +
                $"\nHobbies: ");

            if(hobbies.Count > 0) { hobbies.ForEach(Console.WriteLine);  }
            else { Console.WriteLine("No hobbies disclosed"); }
        }

    }
}
