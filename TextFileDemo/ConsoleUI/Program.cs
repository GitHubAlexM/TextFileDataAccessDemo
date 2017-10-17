using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = @"C:\Users\Alex\Documents\visual studio 2017\Projects\TextFileDemo\demo.txt";
            ////with the @ symbol it tells us that this is a string literal with no escape chars
            //List<string> lines = File.ReadAllLines(filePath).ToList();
            ////reads all lines from the text file and converts it into a list
            //foreach (string line in lines)
            //    //loops each line and writes line from each lines
            //{
            //    Console.WriteLine(line);                
            //}
            //lines.Add("Hello Alex, this line is added into the text file.");
            //File.WriteAllLines(filePath, lines);

            List<Person> people = new List<Person>();
            List<string> lines = File.ReadAllLines(filePath).ToList();
            foreach (string line in lines)
            {
                string[] entries = line.Split(',');
                Person newPerson = new Person();
                newPerson.FirstName = entries[0];
                newPerson.LastName = entries[1];
                people.Add(newPerson);
            }

            Console.WriteLine("Read from text file");
            foreach (var person in people)
            {
                //person.FirstName + " " + person.LastName
                Console.WriteLine($"{person.FirstName} {person.LastName}");
            }
            people.Add(new Person { FirstName = "Greg", LastName = "Jones" });

            List<string> output = new List<string>();

            foreach (var person in people)
            {
                output.Add($"{person.FirstName},{person.LastName}");
            }
            Console.WriteLine("Writing to text file");
            File.WriteAllLines(filePath,output);
            Console.WriteLine("All entries written");
            Console.ReadLine();//stops application from closing
        }
    }
}
