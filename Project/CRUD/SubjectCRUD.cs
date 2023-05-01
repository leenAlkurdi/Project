using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    public class SubjectCRUD
    {
        public static void AddSubject()
        {
            try { 
            Console.WriteLine("Add :");
            var _context = new AppDbContext();
            var subject = new Subject();
            Console.WriteLine("Enter the name :");
            subject.Name = Console.ReadLine();

            Console.WriteLine("Enter the Department Id :");
            subject.DepartmentId = Convert.ToInt32(Console.ReadLine());
            var departmeant = _context.departments.Find(subject.DepartmentId);
                Console.WriteLine("Enter the min dgree :");
            subject.MinimumDegree = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter the Term number :");
            subject.Term = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter the Year :");
            subject.Year = Convert.ToInt32(Console.ReadLine());

            _context.Add(subject);
            _context.SaveChanges();
            Console.WriteLine("Done");
            Console.WriteLine("\n" + "-----------------------------" + "\n");
            }
            catch (NullReferenceException ex)
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
        public static void updateSubject()
        {
            try { 
            string ok;
            var _context = new AppDbContext();
            Console.WriteLine("Update :");
            Console.WriteLine("Enter the subject id to be updated ");
            var subject = _context.Subjects.Find(Convert.ToInt32(Console.ReadLine()));
            if (subject == null)
            {
                Console.WriteLine("there are no subject");
                Console.WriteLine("there is no subject" + "\n" + "do you want to add it y/n");
                string s = Console.ReadLine();
                if (s == "y") SubjectCRUD.AddSubject();
                else return;
            }
            Console.WriteLine("Do you want update the name? y/n");
            ok = Console.ReadLine();
            if (ok == "y")
            {
                Console.WriteLine("Enter the new  name :");
                subject.Name = Console.ReadLine();
            }

            Console.WriteLine("Do you want update the min dgree ? y/n");
            ok = Console.ReadLine();
            if (ok == "y")
            {
                Console.WriteLine("Enter the new min dgree :");
                subject.MinimumDegree = Convert.ToInt32(Console.ReadLine());
            }
            Console.WriteLine("Do you want update the term ? y/n");
            ok = Console.ReadLine();
            if (ok == "y")
            {
                Console.WriteLine("Enter the new term :");
                subject.Term = Convert.ToInt32(Console.ReadLine());
            }
            Console.WriteLine("Do you want update the year ? y/n");
            ok = Console.ReadLine();
            if (ok == "y")
            {
                Console.WriteLine("Enter the new year :");
                subject.Year = Convert.ToInt32(Console.ReadLine());
            }

            Console.WriteLine("Do you want update the department id? y/n");
            ok = Console.ReadLine();
            if (ok == "y")
            {
                Console.WriteLine("Enter the new depatment id :");
                subject.DepartmentId = Convert.ToInt32(Console.ReadLine());
            }

            _context.SaveChanges();
            Console.WriteLine("Done");
            Console.WriteLine("\n" + "-----------------------------" + "\n");
            }
            catch (NullReferenceException ex)
            {
                Console.WriteLine("there is no departmeant");
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.ToString());
            }
            catch (Exception ex)
            { Console.WriteLine(ex.ToString()); }



        }
        public static void DeleteSubject()
        {
            try
            {
                var _context = new AppDbContext();
                Console.WriteLine("Delete :");
                Console.WriteLine("Enter the subject id to be deleted ");
                int id = Convert.ToInt32(Console.ReadLine());
                var subject = _context.Subjects.Find(id);

                var exams = _context.Exams.Where(s => s.SubjectId == id);
                var subjectLectures = _context.SubjectLectures.Where(s => s.SubjectId == id);
                Console.WriteLine("are you sure ? All data related will be removed too y/n");
                string ok = Console.ReadLine();
                if (ok == "n") return;
                _context.Exams.RemoveRange(exams);
                _context.SubjectLectures.RemoveRange(subjectLectures);
                _context.Subjects.Remove(subject);
                _context.SaveChanges();
                Console.WriteLine("Done");
                Console.WriteLine("\n" + "-----------------------------" + "\n");
            }
            catch (NullReferenceException ex)
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
        public static void SelectSubject()
        {
            int cnt = 0;
            var _context = new AppDbContext();
            var subjects = _context.Subjects.ToList();
            foreach (var subject in subjects)
            {
                var departmeant = _context.departments.Find(subject.DepartmentId);

                Console.WriteLine(
                    ++cnt
                    + "\n" + "name : " + subject.Name + "\n"
                    + "\n" + "min degree :" + subject.MinimumDegree + "\n"
                    + "\n" + "term: " + subject.Term + "\n"
                    + "\n" + "year : " + subject.Year + "\n"
                    + "\n" + "Department : " + departmeant.Name + "\n"
                    );
            }
            Console.WriteLine("Done");
            Console.WriteLine("\n" + "-----------------------------" + "\n");

        }
        public static void Student_subject()
        {
            int cnt = 0;
            int avg = 0;
            Console.WriteLine("Enter student id");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter year");
            int year = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter term");
            int term = Convert.ToInt32(Console.ReadLine());
            var _context = new AppDbContext();
            var subjects = _context.Subjects.ToList();
            var student = _context.students.Find(id);
            var marks = _context.StudentMarks.ToList();
            var exams = _context.Exams.ToList();
            foreach (var subject in subjects)
            {
                if (student.DepartmentId == subject.DepartmentId && subject.Year == year && subject.Term == term)
                {
                    Console.WriteLine(

                    "name : " + subject.Name + "\n"
                    + "\n" + "min degree :" + subject.MinimumDegree + "\n"
                    );
                    foreach (var exam in exams)
                    {
                        if (exam.SubjectId == subject.Id)
                        {
                            foreach (var mark in marks)
                            {

                                if (mark.StudentId == id && mark.ExamId == exam.Id)
                                {
                                    cnt++;
                                    avg = (avg + mark.Mark);
                                }
                            }
                        }
                    }


                }
            }
            Console.WriteLine("avg = " + avg / cnt);

        }
        public static void count_lecture()
        {
            var _context = new AppDbContext();
            Console.WriteLine("Enter departmeant id");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter year");
            int year = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter term");
            int term = Convert.ToInt32(Console.ReadLine());
            var lectures = _context.SubjectLectures.ToList();
            int cnt = 0;
           
            var subjects = _context.Subjects.ToList();
            foreach (var subject in subjects)
            {
                cnt = 0;
                if (subject.Term == term && subject.Year == year && subject.DepartmentId == id)
                {
                    foreach (var lecture in lectures)
                    {
                        if (lecture.SubjectId == subject.Id)
                            cnt++;
                    }
                    Console.WriteLine(
                       "name : " + subject.Name 
                       + "\n" + "lecture count :" + cnt + "\n"
                       );
                }
            }
            Console.WriteLine("Done");
            Console.WriteLine("\n" + "-----------------------------" + "\n");

        }

    }      

}
