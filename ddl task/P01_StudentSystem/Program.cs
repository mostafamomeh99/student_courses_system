using P01_StudentSystem.Data;
using P01_StudentSystem.models;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Text.RegularExpressions;

namespace P01_StudentSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string inputchoose = "start";
            // regular exprission
            string usernamePattern = @"^[a-zA-Z\s]{3,15}$";
            string datePattern = @"^(?:(\d{4}-\d{2}-\d{2})|(\d{2}/\d{2}/\d{4})|(\d{2}-\d{2}-\d{4}))$";
            string phonePattern = @"^\d{10}$";
            string pricePattern = @"^(?:\d{1,6}|\d{1,6}\.\d{2})$|^(\d{1,6}\.\d{2})$";
            //string priceInput = "152.50";

            //if (Regex.IsMatch(priceInput, pricePattern))
            //{
            //    Console.WriteLine("Valid price.");
            //    Console.WriteLine(decimal.Parse(priceInput));
            //}
            //else
            //{
            //    Console.WriteLine("Invalid price.");
            //}
            // student inputs

            string studentname = "nothing";
            string studentbirth = "nothing";
            string studentphone = "nothing";
            DateOnly studentregestrion = DateOnly.FromDateTime(DateTime.Now);


            // course inputs
            string coursename = "nothing";
            string coursedescription = "nothing";
            string courseprice = "nothing";
            string courseStartDate = "nothing";
            string courseendDate = "nothing";


            do
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("choose which one to submit data\n(s)student\n(c)course\n*-press anything to exit");
                Console.ResetColor();
                inputchoose = Console.ReadLine();

                ///////////////////////////////////////student

                if (inputchoose == "S" || inputchoose == "s")
                {
                    using (var data = new StudentSystemContext())
                    {

                        try
                        {
                            // name
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("enter name of student --15 length max");
                            Console.ResetColor();

                            studentname = Console.ReadLine();
                            if (Regex.IsMatch(studentname, usernamePattern))
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine($"{studentname} is a valid.");
                                Console.ResetColor();
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("not valid name , try another time");
                                Console.ResetColor();
                                studentphone = "nothing";
                                studentname = "nothing";
                                studentbirth = "nothing";
                                continue;
                            }
                            //PhoneNumber
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("enter phone of student -- 10 length max");
                            Console.ResetColor();
                            studentphone = Console.ReadLine();
                            if (Regex.IsMatch(studentphone, phonePattern))
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine($"{studentphone} is a valid.");
                                Console.ResetColor();
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("not valid PhoneNumber , try another time");
                                Console.ResetColor();
                                studentphone = "nothing";
                                studentname = "nothing";
                                studentbirth = "nothing";
                                continue;

                            }
                            // birthday
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("enter birthdate of student -- like this format DD/MM/YYYY");
                            Console.ResetColor();
                            studentbirth = Console.ReadLine();
                            if (Regex.IsMatch(studentbirth, datePattern))
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine($"{studentbirth} is a valid.");
                                Console.ResetColor();
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("not valid PhoneNumber , try another time");
                                Console.ResetColor();
                                studentphone = "nothing";
                                studentname = "nothing";
                                studentbirth = "nothing";
                                continue;

                            }
                            // Create a new student
                            var student = new Student()
                            {
                                Name = studentname,
                                Birthday = DateOnly.Parse(studentbirth),
                                PhoneNumber = studentphone,
                                RegestrionON = studentregestrion
                            };
                            // Add the student to the data
                            data.Students.Add(student);

                            // Save changes to the database
                            data.SaveChanges();
                            Console.WriteLine("Student added successfully!");
                        }
                        catch (FormatException e)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("not valid data , try another time");
                            Console.ResetColor();
                            studentphone = "nothing";
                            studentname = "nothing";
                            studentbirth = "nothing";
                            continue;
                        }

                    }
                }


                ///////////////////////////////////////course



                if (inputchoose == "C" || inputchoose == "c")
                {
                    using (var data = new StudentSystemContext())
                    {

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("enter name of course --15 length max");
                        Console.ResetColor();

                        try
                        {
                            // name
                            coursename = Console.ReadLine();
                            if (Regex.IsMatch(coursename, usernamePattern))
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine($"{coursename} is a valid.");
                                Console.ResetColor();
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("not valid name , try another time");
                                Console.ResetColor();
                                coursename = "nothing";
                                coursedescription = "nothing";
                                courseprice = "nothing";
                                continue;
                            }
                            //description
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("enter description of course --15 length max -- 10 length max");
                            Console.ResetColor();
                            coursedescription = Console.ReadLine();
                            if (Regex.IsMatch(coursedescription, usernamePattern))
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine($"{coursedescription} is a valid.");
                                Console.ResetColor();
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("not valid course description , try another time");
                                Console.ResetColor();
                                coursename = "nothing";
                                coursedescription = "nothing";
                                courseprice = "nothing";
                                courseStartDate = "nothing";
                                courseendDate = "nothing";
                                continue;

                            }
                            // price
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("enter price of course -- note max decimals like that dddddd.dd");
                            Console.ResetColor();
                            courseprice = Console.ReadLine();
                            if (Regex.IsMatch(courseprice, pricePattern))
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine($"{courseprice} is a valid.");
                                Console.ResetColor();
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("not valid price , try another time");
                                Console.ResetColor();
                                coursename = "nothing";
                                coursedescription = "nothing";
                                courseprice = "nothing";
                               courseStartDate = "nothing";
                                 courseendDate = "nothing";
                                continue;

                            }

                            // starting date
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("enter starting date of course --like this format DD/MM/YYYY ");
                            Console.ResetColor();
                            courseStartDate = Console.ReadLine();
                            if (Regex.IsMatch(courseStartDate, datePattern))
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine($"{courseStartDate} is a valid.");
                                Console.ResetColor();
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("not valid date , try another time");
                                Console.ResetColor();
                                coursename = "nothing";
                                coursedescription = "nothing";
                                courseprice = "nothing";
                                courseStartDate = "nothing";
                                courseendDate = "nothing";
                                continue;

                            }

                            // ending date
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("enter ending date of course --like this format DD/MM/YYYY ");
                            Console.ResetColor();
                            courseendDate = Console.ReadLine();
                            if (Regex.IsMatch(courseendDate, datePattern))
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine($"{courseendDate} is a valid.");
                                Console.ResetColor();
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("not valid date , try another time");
                                Console.ResetColor();
                                coursename = "nothing";
                                coursedescription = "nothing";
                                courseprice = "nothing";
                                courseStartDate = "nothing";
                                courseendDate = "nothing";
                                continue;

                            }


                            // Create a new course
                            var course = new Course()
                            {
                                Name = coursename,
                                Description= coursedescription,
                                Price=decimal.Parse(courseprice) ,
                                StartDate=DateOnly.Parse(courseStartDate),
                                EndDate= DateOnly.Parse(courseendDate)
                            };
                            // Add the student to the data
                            data.Courses.Add(course);

                            // Save changes to the database
                            data.SaveChanges();
                            Console.WriteLine("Course added successfully!");
                        }
                        catch (FormatException e)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("not valid data , try another time");
                            Console.ResetColor();
                            coursename = "nothing";
                            coursedescription = "nothing";
                            courseprice = "nothing";
                            courseStartDate = "nothing";
                            courseendDate = "nothing";
                            continue;
                        }

                    }
                }

            }
            while (inputchoose == "c" || inputchoose == "C" || inputchoose == "s" || inputchoose == "S"  );
        }
    }
}
