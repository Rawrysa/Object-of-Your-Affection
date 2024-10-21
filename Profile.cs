using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Object_of_Your_Affection
{
    internal class Profile
    {
        private static List<Profile> profiles = new List<Profile>();
        public static List<Profile> Profiles
        { get { return profiles; } }

        private string username, city, pronouns;
        private int age;
        private List<string> hobbies;

        public Profile() { }

        public Profile(string username, string city, int age, string hobbies, string pronouns) 
        {
            this.username = username;
            this.city = city;
            this.pronouns = pronouns;
            this.age = age;
            this.hobbies = new List<string>();
            SetHobbies(hobbies);
        }

        public static bool CreateProfile(string username, string city, int age, string hobbies, string pronouns) 
        {
            if (!Profiles.Exists(x => x.username == username))
            {
                Profiles.Add(new Profile(username, city, age, hobbies, (pronouns!=string.Empty)? pronouns : "Not Disclosed"));
                return true;
            }
            else { return false; }
        }

        public static bool DeleteProfile(string username)
        {
            if(Profiles.Exists(x => x.username==username))
            {
                Profiles.RemoveAt(Profiles.FindIndex(x => x.username == username));
                return true;
            }
            else { return false; }
        }

        public static bool SearchProfile(string username, out List<Profile> profile)
        {
            if (Profiles.Exists(x => x.username == username))
            {
                profile = Profiles.Where(x => x.username == username).ToList();
                return true;
            }
            else { profile = null; return false; }
        }

        public void ViewProfile()
        {
            Console.WriteLine($"Username: {username}" +
                $"\ncity: {city}" +
                $"\nPronouns: {pronouns}" +
                $"\nAge: {age}" +
                $"\nHobbies: ");

            if (hobbies.Count > 0) { hobbies.ForEach(Console.WriteLine);  }
            else { Console.WriteLine("No hobbies disclosed"); }
            Console.WriteLine();
        }

        private void SetHobbies(string hobbies)
        {
            this.hobbies.AddRange(hobbies.Replace(" ","").Split(','));
        }

    }
}
