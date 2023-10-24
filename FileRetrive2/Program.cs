using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileRetrive2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string filePath = @"C:\Users\Dell\Documents\Practice\.NET\FileRetrive2\File_retrive.txt";

            if (File.Exists(filePath))
            {
                try
                {
                    List<string> studentData = new List<string>();
                    using (StreamReader sr = new StreamReader(filePath))
                    {
                        string line;
                        while ((line = sr.ReadLine()) != null)
                        {
                            studentData.Add(line);
                        }
                    }

                    // Sort the data alphabetically by student name
                    studentData.Sort();

                    Console.WriteLine("Sorted Student Data:");
                    foreach (var data in studentData)
                    {
                        Console.WriteLine(data);
                    }

                    Console.WriteLine("\nEnter a student name to search:");
                    string searchName = Console.ReadLine();

                    bool found = false;
                    foreach (var data in studentData)
                    {
                        if (data.StartsWith(searchName, StringComparison.OrdinalIgnoreCase))
                        {
                            Console.WriteLine("Found: " + data);
                            found = true;
                            break;
                        }
                    }

                    if (!found)
                    {
                        Console.WriteLine("Student not found.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("An error occurred: " + ex.Message);
                }
            }
            else
            {
                Console.WriteLine("File does not exist");
            }

            Console.ReadLine();
        }
    }
}
