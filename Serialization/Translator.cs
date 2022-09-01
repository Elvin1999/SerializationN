using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serialization
{
    [Serializable]
    public class Translator
    {
        public Translator(string name, string surname)
        {
            Name = name;
            Surname = surname;
        }
        public Translator()
        {

        }
        public List<Subject> Subjects { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Fullname => $"{Name} - {Surname}";


        public override string ToString()
        {
            if (Subjects != null)
            {
                foreach (Subject subject in Subjects)
                {
                    Console.WriteLine($"\t\t\t{subject}");
                }
            }
            return Fullname;
        }
    }
}
