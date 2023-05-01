using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    public class StudenCRUD
    {
        public static void AddStudent()
        {
            try
            {
                var student = new Student();
                var _context = new AppDbContext();
                Console.WriteLine("Add :");
                Console.WriteLine("Enter the user name :");
                student.UserName = Console.ReadLine();

                Console.WriteLine("Enter the First name :");
                student.FirstName = Console.ReadLine();

                Console.WriteLine("Enter the last name :");
                student.LastName = Console.ReadLine();

                Console.WriteLine("Enter the email :");
                student.Email = Console.ReadLine();

                Console.WriteLine("Enter the Phone :");
                student.Phone = Console.ReadLine();

                Console.WriteLine("Enter the Register Date :");
                student.RegisterDate = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Enter the Department Id :");
                _context.Add(student);
                _context.SaveChanges();
                Console.WriteLine("Done");
                Console.WriteLine("\n" + "-----------------------------" + "\n");
            }catch(NullReferenceException ex)
            {
                Console.WriteLine("there is no departmeant");
            }catch(FormatException ex)
            {
                Console.Write(ex.Message);
            }catch (Exception ex)
            { Console.WriteLine(ex.ToString());}
        }
        public static void updateStudent()
        {
            try
            {
                string ok;
                var _context = new AppDbContext();
                Console.WriteLine("Update :");
                Console.WriteLine("Enter the student id to be updated ");
                var student = _context.students.Find(Convert.ToInt32(Console.ReadLine()));
                Console.WriteLine("Do you want update the user name? y/n");
                ok = Console.ReadLine();
                if (ok == "y")
                {
                    Console.WriteLine("Enter the new user name :");
                    student.UserName = Console.ReadLine();
                }

                Console.WriteLine("Do you want update the first name? y/n");
                ok = Console.ReadLine();
                if (ok == "y")
                {
                    Console.WriteLine("Enter the new first name :");
                    student.FirstName = Console.ReadLine();
                }

                Console.WriteLine("Do you want update the last name? y/n");
                ok = Console.ReadLine();
                if (ok == "y")
                {
                    Console.WriteLine("Enter the new last name :");
                    student.LastName = Console.ReadLine();
                }

                Console.WriteLine("Do you want update the email? y/n");
                ok = Console.ReadLine();
                if (ok == "y")
                {
                    Console.WriteLine("Enter the new email :");
                    student.Email = Console.ReadLine();
                }
                Console.WriteLine("Do you want update the phone? y/n");
                ok = Console.ReadLine();
                if (ok == "y")
                {
                    Console.WriteLine("Enter the new phone :");
                    student.Phone = Console.ReadLine();
                }

                Console.WriteLine("Do you want update the Register Date? y/n");
                ok = Console.ReadLine();
                if (ok == "y")
                {
                    Console.WriteLine("Enter the new Register Date :");
                    student.RegisterDate = Convert.ToInt32(Console.ReadLine());
                }

                Console.WriteLine("Do you want update the department id? y/n");
                ok = Console.ReadLine();
                if (ok == "y")
                {
                    Console.WriteLine("Enter the new depatment id :");
                    student.DepartmentId = Convert.ToInt32(Console.ReadLine());
                }

                _context.SaveChanges();
                Console.WriteLine("Done");
                Console.WriteLine("\n" + "-----------------------------" + "\n");
            }
            catch (NullReferenceException ex)
            {
                Console.WriteLine("there is no student" );
              
            }
            catch (FormatException ex)
            {
                Console.Write(ex.Message);
            }
            catch (Exception ex)
            { Console.WriteLine(ex.ToString()); }



        }
        public static void DeleteStudent()
        {
            try
            {
                var _context = new AppDbContext();
                Console.WriteLine("Delete :");
                Console.WriteLine("Enter the department id to be delete ");
                int id = Convert.ToInt32(Console.ReadLine());
                var student = _context.students.Find(id);
                var studentMarks = _context.StudentMarks.Where(s => s.StudentId == id);
                Console.WriteLine("are you sure ? All data related will be removed too y/n");
                string ok = Console.ReadLine();
                if (ok == "n") return;
                _context.StudentMarks.RemoveRange(studentMarks);

                _context.students.Remove(student);

                _context.SaveChanges();
                Console.WriteLine("Done");
                Console.WriteLine("\n" + "-----------------------------" + "\n");
            }
            catch (NullReferenceException ex)
            {
                Console.WriteLine("there is no student" );
              
            }
            catch (FormatException ex)
            {
                Console.Write(ex.Message);
            }
            catch (Exception ex)
            { Console.WriteLine(ex.Message); }
        }
        public static void SelectStudent()
        {
            int cnt = 0;
            var _context = new AppDbContext();
            var students = _context.students.ToList();
            foreach (var student in students)
            {
                var departmeant = _context.departments.Find(student.DepartmentId);

                Console.WriteLine(
                    ++cnt
                    + "\n" + "user name : " + student.UserName + "\n"
                    + "\n" + "first name :" + student.FirstName + "\n"
                    + "\n" + "last name : " + student.LastName + "\n"
                    + "\n" + "email : " + student.Email + "\n"
                    + "\n" + "Phone : " + student.Phone + "\n"
                    + "\n" + "Register date : " + student.RegisterDate + "\n"
                    + "\n" + "Department : " + departmeant.Name + "\n"
                    );
            }
                Console.WriteLine("Done");
                Console.WriteLine("\n" + "-----------------------------" + "\n");
            
        }
        public static void Student_didnot_exam()
        {
            try
            {
                Console.WriteLine("enter id for exam");
                int id = Convert.ToInt32(Console.ReadLine());
                int cnt = 0;
                var _context = new AppDbContext();
                var marks = _context.StudentMarks.ToList();
                var students = _context.students.ToList();
                foreach (var mark in marks)
                {
                    if (mark.ExamId == id)
                    {
                        foreach (var student in students)
                        {
                            if (student.Id != mark.StudentId)
                            {
                                Console.WriteLine(
                                ++cnt
                                + "\n" + "first name :" + student.FirstName + "\n"
                                + "\n" + "last name : " + student.LastName + "\n"
                                );
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("there is no marks");
                    }
                }
                Console.WriteLine("Done");
                Console.WriteLine("\n" + "-----------------------------" + "\n");
            }
            catch (NullReferenceException ex)
            {
                Console.WriteLine("there is no exam");
            }
            catch (FormatException ex)
            {
                Console.Write(ex.Message);
            }
            catch (Exception ex)
            { Console.WriteLine(ex.ToString()); }
        }
        public static void Student_did_exam()
        {
            try
            {
                Console.WriteLine("enter id for exam");
                int id = Convert.ToInt32(Console.ReadLine());
                int cnt = 0;
                var _context = new AppDbContext();
                var marks = _context.StudentMarks.ToList();
                var students = _context.students.ToList();
                foreach (var mark in marks)
                {
                    if (mark.ExamId == id)
                    {
                        foreach (var student in students)
                        {
                            if (student.Id == mark.StudentId)
                            {
                                Console.WriteLine(
                                                       ++cnt
                                                       + "\n" + "first name :" + student.FirstName + "\n"
                                                       + "\n" + "last name : " + student.LastName + "\n"
                                                       );
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("there is no marks");
                    }
                }
                Console.WriteLine("Done");
                Console.WriteLine("\n" + "-----------------------------" + "\n");
            }
            catch (NullReferenceException ex)
            {
                Console.WriteLine("there is no exam" + "\n" + "do you want to add it y/n");
                string s = Console.ReadLine();
                if (s == "y") ExamCRUD.AddExam();
            }
            catch (FormatException ex)
            {
                Console.Write(ex.Message);
            }
            catch (Exception ex)
            { Console.WriteLine(ex.ToString()); }

        }
        public static void Student_Department()
        {
            int cnt_d = 0;
            int cnt_s=0;
            var _context = new AppDbContext();
            var departmeants = _context.departments.ToList();
            var students = _context.students.ToList();
            foreach (var department in departmeants)
            {
                Console.WriteLine(
                    ++cnt_d + ".Name : " + department.Name+"\n"
                    );
                foreach (var student in students)
                {
                   
                    if (student.DepartmentId == department.Id)
                    {
                        cnt_s++;
                        Console.WriteLine(          
                         "first name :" + student.FirstName
                        + "\n" + "last name : " + student.LastName + "\n"
                        +"***********"
                         );
                    }         
                }            
                Console.WriteLine("~~~~~~~~~~~~~~~~");
            }
            Console.WriteLine("Done");
            Console.WriteLine("\n" + "-----------------------------" + "\n");
        }


    }
}
