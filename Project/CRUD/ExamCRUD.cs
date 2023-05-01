using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    public class ExamCRUD
    {
        public static void AddExam()
        {
            try
            {
                var _context = new AppDbContext();
                var exam = new Exam();
                Console.WriteLine("Add");

                Console.WriteLine("Enter the Subject Id :");
                exam.SubjectId = Convert.ToInt32(Console.ReadLine());
                var subject = _context.Subjects.Find(exam.SubjectId);
                Console.WriteLine("Enter the Term:");
                exam.Term = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Enter the date:");
                exam.Date = Convert.ToDateTime(Console.ReadLine());
                _context.Add(exam);
                _context.SaveChanges();
                Console.WriteLine("Done");
                Console.WriteLine("\n" + "-----------------------------" + "\n");
            }catch(NullReferenceException ex)
            {
                Console.WriteLine("there is no subject");
            }catch(FormatException ex)
            {
                Console.WriteLine(ex.ToString());
            }catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

        }
        public static void updateExam()
        {
            try
            {
                string ok;
                var _context = new AppDbContext();
                Console.WriteLine("Update :");
                Console.WriteLine("Enter the exam id to be updated ");
                var exam = _context.Exams.Find(Convert.ToInt32(Console.ReadLine()));
                Console.WriteLine("Do you want update the term? y/n");
                ok = Console.ReadLine();
                if (ok == "y")
                {
                    Console.WriteLine("Enter the new  term :");
                    exam.Term = Convert.ToInt32(Console.ReadLine());
                }
                Console.WriteLine("Do you want update the date? y/n");
                ok = Console.ReadLine();
                if (ok == "y")
                {
                    Console.WriteLine("Enter the new  date :");
                    exam.Date = Convert.ToDateTime(Console.ReadLine());
                }

                Console.WriteLine("Do you want update the subject id? y/n");
                ok = Console.ReadLine();
                if (ok == "y")
                {
                    Console.WriteLine("Enter the new subject id :");
                    exam.SubjectId = Convert.ToInt32(Console.ReadLine());
                }

                _context.SaveChanges();
                Console.WriteLine("Done");
                Console.WriteLine("\n" + "-----------------------------" + "\n");
            }
            catch (NullReferenceException ex)
            {
                Console.WriteLine("there is no exam" );
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }



        }
        public static void DeleteExam()
        {
            try
            {
                var _context = new AppDbContext();
                Console.WriteLine("Delete :");
                Console.WriteLine("Enter the exam id to be delete ");
                int id = Convert.ToInt32(Console.ReadLine());
                var department = _context.departments.Find(id);

                var studentMarks = _context.StudentMarks.Where(s => s.ExamId == id);
                Console.WriteLine("are you sure ? All data related will be removed too y/n");
                string ok = Console.ReadLine();
                if (ok == "n") return;

                _context.StudentMarks.RemoveRange(studentMarks);
                _context.departments.Remove(department);

                _context.SaveChanges();
                Console.WriteLine("Done");
                Console.WriteLine("\n" + "-----------------------------" + "\n");
            }
            catch (NullReferenceException ex)
            {
                Console.WriteLine("there is no exam");
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public static void SelectExam()
        {
            int cnt = 0;
            var _context = new AppDbContext();
            var exams = _context.Exams.ToList();
            foreach (var exam in exams)
            {
                var subject=_context.Subjects.Find(exam.SubjectId);

                Console.WriteLine(
                    ++cnt 
                    +"\n" + "date:" + exam.Date 
                    +"\n"+ "Term:" +exam.Term
                    + "\n"+ "Subject"+subject.Name + "\n"

                    );

            }
            Console.WriteLine("Done");
            Console.WriteLine("\n" + "-----------------------------" + "\n");
        }
    }
}
