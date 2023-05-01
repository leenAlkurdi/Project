using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    public class StudentMarkCRUD
    {
        public static void AddStudenMark( )
        {
            try
            {
                var _context = new AppDbContext();
                var studentMark = new StudentMark();

                Console.WriteLine("Add :");
                Console.WriteLine("Enter the stuednt Id :");
                studentMark.StudentId = Convert.ToInt32(Console.ReadLine());
               
                Console.WriteLine("Enter the exam id:");
                studentMark.ExamId = Convert.ToInt32(Console.ReadLine());
             
                Console.WriteLine("Enter the mark:");
                studentMark.Mark = Convert.ToInt32(Console.ReadLine());
                _context.Add(studentMark);
                _context.SaveChanges();
                Console.WriteLine("Done");
                Console.WriteLine("\n" + "-----------------------------" + "\n");
            }catch(NullReferenceException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            { Console.WriteLine(ex.Message); }
        }
        public static void updateMark()
        {
            try
            {
                string ok;
                var _context = new AppDbContext();
                Console.WriteLine("Update :");
                Console.WriteLine("Enter the student Mark id to be updated ");
                var studentMark = _context.StudentMarks.Find(Convert.ToInt32(Console.ReadLine()));


                Console.WriteLine("Do you want update the student id? y/n");
                ok = Console.ReadLine();
                if (ok == "y")
                {
                    Console.WriteLine("Enter the new student id :");
                    studentMark.StudentId = Convert.ToInt32(Console.ReadLine());
                }
                Console.WriteLine("Do you want update the exam id? y/n");
                ok = Console.ReadLine();
                if (ok == "y")
                {
                    Console.WriteLine("Enter the new exam id :");
                    studentMark.ExamId = Convert.ToInt32(Console.ReadLine());
                }
                Console.WriteLine("Do you want update the mark? y/n");
                ok = Console.ReadLine();
                if (ok == "y")
                {
                    Console.WriteLine("Enter the mark :");
                    studentMark.Mark = Convert.ToInt32(Console.ReadLine());
                }

                _context.SaveChanges();
                Console.WriteLine("Done");
                Console.WriteLine("\n" + "-----------------------------" + "\n");
            }catch(NullReferenceException ex)
            {
                Console.WriteLine("there is no mark ");
            }catch(FormatException ex)
            {
                Console.WriteLine(ex.Message);
            }catch(Exception ex)
            { Console.WriteLine(ex.Message);}


        }
        public static void DeleteStudentMark()
        {
            try
            {
                var _context = new AppDbContext();
                Console.WriteLine("Delete :");
                Console.WriteLine("Enter the studnet mark id to be delete ");
                var studnentMark = _context.StudentMarks.Find(Convert.ToInt32(Console.ReadLine()));
                _context.StudentMarks.Remove(studnentMark);
                _context.SaveChanges();
                Console.WriteLine("Done");
                Console.WriteLine("\n" + "-----------------------------" + "\n");
            }
            catch (NullReferenceException ex)
            {
                Console.WriteLine("there is no mark  ");
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            { Console.WriteLine(ex.Message); }
        }
            public static void SelectMark()
        {
            int cnt = 0;
            var _context = new AppDbContext();
            var marks = _context.StudentMarks.ToList();
            foreach (var mark in marks)
            {
                var student = _context.students.Find(mark.StudentId);
                var exam = _context.Exams.Find(mark.ExamId);
                var subject= _context.Subjects.Find(exam.SubjectId);
                Console.WriteLine(
                    ++cnt
                    + "\n" + "student: " + student.FirstName +"  "+ student.LastName+ "\n"
                    + "\n" + "exam subject :" + subject.Name + "\n"
                     + "\n" + "exam date :" + exam.Date + "\n"
                    + "\n" + "mark : " + mark.Mark+ "\n"
                    );
            }
            Console.WriteLine("Done");
            Console.WriteLine("\n" + "-----------------------------" + "\n");

        }
       

    }
}
