using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Serialization
{
    public class Car
    {
        
        public int Year { get; set; }
        public string Model { get; set; }
        public string Vendor { get; set; }

        public override string ToString()
        {
            return $"{Model} - {Vendor} - {Year}";
        }
    }



    public class Program
    {
        static void Write()
        {
            //List<Car> cars = new List<Car>
            //{
            //    new Car
            //    {
            //        Model="Mustang",
            //        Vendor="Ford",
            //        Year=1969
            //    },
            //    new Car
            //    {
            //        Model="Chevrolet",
            //        Vendor="Camaro",
            //        Year=1969
            //    },
            //    new Car
            //    {
            //        Model="Mercedes",
            //        Vendor="AMG",
            //        Year=1969
            //    },
            //};



            //using (var writer=new XmlTextWriter("car.xml",Encoding.UTF8))
            //{
            //    writer.Formatting = Formatting.Indented;
            //    writer.WriteStartDocument();

            //    writer.WriteStartElement("Cars");

            //    foreach (var car in cars)
            //    {
            //        writer.WriteStartElement("Car");

            //        writer.WriteAttributeString(nameof(Car.Model), car.Model);
            //        writer.WriteAttributeString(nameof(Car.Vendor), car.Vendor);
            //        writer.WriteAttributeString(nameof(Car.Year), car.Year.ToString());

            //        writer.WriteEndElement();
            //    }


            //    writer.WriteEndElement();

            //    writer.WriteEndDocument();
            //}

        }


        static void Read()
        {
            List<Car> cars = new List<Car>();


            XmlDocument xml = new XmlDocument();
            xml.Load("car.xml");

            var root = xml.DocumentElement;

            if (root.HasChildNodes)
            {
                foreach (XmlNode car_node in root.ChildNodes)
                {
                    var car = new Car
                    {
                        Model = car_node.Attributes[0].Value,
                        Vendor = car_node.Attributes[1].Value,
                        Year = int.Parse(car_node.Attributes[2].Value)
                    };
                    cars.Add(car);
                }
            }

            foreach (var item in cars)
            {
                Console.WriteLine(item);
            }

        }



        static void XmlSerialize()
        {
            var army = new TranslatorArmy
            {
                Name = "STEP IT Academy",
                Location = "Koroglu Rehimov 71",
                Translators = new List<Translator>
                 {
                      new Translator("John", "Johnlu")
                      {
                            Subjects=new List<Subject>
                            {
                                new Subject
                                {
                                     Degree=30,
                                      Lessons=25,
                                      Name="C++"
                                },
                                new Subject
                                {
                                     Degree=30,
                                      Lessons=25,
                                      Name="C#"
                                }
                            }
                      },
                      new Translator("Leyla", "Eliyeva")
                      {
                            Subjects=new List<Subject>
                            {
                                new Subject
                                {
                                     Degree=30,
                                      Lessons=25,
                                      Name="Angular"
                                },
                                new Subject
                                {
                                     Degree=30,
                                      Lessons=25,
                                      Name="React"
                                }
                            }
                      }
                 }
            };



            var xml = new XmlSerializer(typeof(TranslatorArmy));
            using (var fs=new FileStream("Translators.xml",FileMode.OpenOrCreate))
            {
                xml.Serialize(fs, army);
            }


        }
        static void XmlDeserialize()
        {
            TranslatorArmy army = null;
            var xml = new XmlSerializer(typeof(TranslatorArmy));

            using (var fs=new FileStream("Translators.xml",FileMode.OpenOrCreate))
            {
                army = xml.Deserialize(fs) as TranslatorArmy;
                Console.WriteLine(army);
            }
        }
        static void JsonSerialize()
        {
            var army = new TranslatorArmy
            {
                Name = "STEP IT Academy",
                Location = "Koroglu Rehimov 71",
                Translators = new List<Translator>
                 {
                      new Translator("John", "Johnlu")
                      {
                            Subjects=new List<Subject>
                            {
                                new Subject
                                {
                                     Degree=30,
                                      Lessons=25,
                                      Name="C++"
                                },
                                new Subject
                                {
                                     Degree=30,
                                      Lessons=25,
                                      Name="C#"
                                }
                            }
                      },
                      new Translator("Leyla", "Eliyeva")
                      {
                            Subjects=new List<Subject>
                            {
                                new Subject
                                {
                                     Degree=30,
                                      Lessons=25,
                                      Name="Angular"
                                },
                                new Subject
                                {
                                     Degree=30,
                                      Lessons=25,
                                      Name="React"
                                }
                            }
                      }
                 }
            };


            var serializer=new JsonSerializer();

            using (var sw=new StreamWriter("army.json"))
            {
                using (var jw=new JsonTextWriter(sw))
                {
                    jw.Formatting = Newtonsoft.Json.Formatting.Indented;
                    serializer.Serialize(jw, army);
                }
            }

        }

        static void JsonDeserialize()
        {
            var serializer=new JsonSerializer();    
            TranslatorArmy army = null;
            using (var sr=new StreamReader("army.json"))
            {
                using (var jr=new JsonTextReader(sr))
                {
                    army = serializer.Deserialize<TranslatorArmy>(jr);
                    Console.WriteLine(army);
                }
            }
        }
        static void Main(string[] args)
        {
            //Write();
            // Read();
            //Serialization  

            //  XmlSerialize();
            // XmlDeserialize();


            //JsonSerialize();
           // JsonDeserialize();
        }
    }
}
