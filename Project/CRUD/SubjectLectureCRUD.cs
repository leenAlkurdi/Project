using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    public class SubjectLectureCRUD
    {
        public static void AddSubjectLecture()
        {
            try
            {
                Console.WriteLine("Add");
                var _context = new AppDbContext();
                var subjectLecture = new SubjectLecture();
                Console.WriteLine("Enter the title :");
                subjectLecture.Title = Console.ReadLine();

                Console.WriteLine("Enter the Content :");
                subjectLecture.Content = Console.ReadLine();

                Console.WriteLine("Enter the Subject Id :");
                subjectLecture.SubjectId = Convert.ToInt32(Console.ReadLine());
                var subject = _context.Subjects.Find(subjectLecture.SubjectId);
                if (subject == null)
                {
                    Console.WriteLine("there is no subject" + "\n" + "do you want to add it y/n");
                    string ok = Console.ReadLine();
                    if (ok == "y") SubjectCRUD.AddSubject();
                }

                _context.Add(subjectLecture);
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
        public static void updateSubjectLecture()
        {
            try { 
            string ok;
            var _context = new AppDbContext();
            Console.WriteLine("Update :");
            Console.WriteLine("Enter the subject lecture id to be updated ");
            var subjectLecture = _context.SubjectLectures.Find(Convert.ToInt32(Console.ReadLine()));
            Console.WriteLine("Do you want update the title? y/n");
            ok = Console.ReadLine();
            if (ok == "y")
            {
                Console.WriteLine("Enter the new  title :");
                subjectLecture.Title = Console.ReadLine();
            }
            Console.WriteLine("Do you want update the Content? y/n");
            ok = Console.ReadLine();
            if (ok == "y")
            {
                Console.WriteLine("Enter the new  Content :");
                subjectLecture.Content = Console.ReadLine();
            }
            Console.WriteLine("Do you want update the subject id? y/n");
            ok = Console.ReadLine();
            if (ok == "y")
            {
                Console.WriteLine("Enter the new subject id :");
                subjectLecture.SubjectId = Convert.ToInt32(Console.ReadLine());
            }
            _context.SaveChanges();
            Console.WriteLine("Done");
            Console.WriteLine("\n" + "-----------------------------" + "\n");
            }
            catch (NullReferenceException ex)
            {
                Console.WriteLine("there is no lecture");
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.ToString());
            }
            catch (Exception ex)
            { Console.WriteLine(ex.ToString()); }

        }
        public static void DeleteSubjectLecture()
        {
            try
            {
                var _context = new AppDbContext();
                Console.WriteLine("Delete :");
                Console.WriteLine("Enter the SubjectLectur id to be delete ");

                var subjectLecture = _context.SubjectLectures.Find(Convert.ToInt32(Console.ReadLine()));


                _context.SubjectLectures.Remove(subjectLecture);

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
        public static void SelectLecture()
        {
            int cnt = 0;
            var _context = new AppDbContext();
            var lectures = _context.SubjectLectures.ToList();
            foreach (var lecture in lectures)
            {
                var subject = _context.Subjects.Find(lecture.SubjectId);

                Console.WriteLine(
                    ++cnt
                    + "\n" + "title : " + lecture.Title + "\n"
                    + "\n" + "content :" + lecture.Content + "\n"
                    + "\n" + "subject : " + subject.Name + "\n"
                    );
            }
            Console.WriteLine("Done");
            Console.WriteLine("\n" + "-----------------------------" + "\n");

        }
    }
}
