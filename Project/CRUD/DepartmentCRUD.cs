using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    public class DepartmentCRUD
    {
        public static void AddDepartment()
        {
            Console.WriteLine("Add :");
            Console.WriteLine("Enter the name of department :");
           
            var _context = new AppDbContext();
            var department = new Department
            {
                Name =Console.ReadLine(),
            };
            _context.Add(department);
            _context.SaveChanges();
            Console.WriteLine("Done");
            Console.WriteLine("\n" + "-----------------------------" + "\n");
        }
        public static void UpdateDepartment()
        {
            try
            {
                var _context = new AppDbContext();
                Console.WriteLine("Update :");
                Console.WriteLine("Enter the department id to be updated ");
                var department = _context.departments.Find(Convert.ToInt32(Console.ReadLine()));
                Console.WriteLine("Enter the new name of department");
                department.Name = Console.ReadLine();
                _context.SaveChanges();
                Console.WriteLine("Done");
                Console.WriteLine("\n" + "-----------------------------" + "\n");
            }catch (NullReferenceException ex)
            {
                Console.WriteLine("there is no departmeant");
            }catch(FormatException ex)
            {
                Console.WriteLine(ex.ToString());
            }catch(Exception ex)
            { Console.WriteLine(ex.ToString());}
        }
        public static void DeleteDepartment()
        {
            try
            {
                var _context = new AppDbContext();
                Console.WriteLine("Delete :");
                Console.WriteLine("Enter the department id to be delete ");
                int id = Convert.ToInt32(Console.ReadLine());
                var department = _context.departments.Find(id);
                var subjects = _context.Subjects.Where(s => s.DepartmentId == id);
                var students = _context.students.Where(s => s.DepartmentId == id);
                Console.WriteLine("are you sure ? All data related will be removed too y/n");
                string ok = Console.ReadLine();
                if (ok == "n") return;
                
                    _context.Subjects.RemoveRange(subjects);
                    _context.students.RemoveRange(students);
                    _context.departments.Remove(department);
                
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
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            { Console.WriteLine(ex.Message); }
        }
        public static void SelectDepartment()
        {
            int cnt = 0;
            var _context = new AppDbContext();
            var departmeants=_context.departments.ToList();
            foreach (var department in departmeants)
            {
                
                Console.WriteLine(
                    ++cnt +".Name:"+department.Name
                    );
            }
            Console.WriteLine("Done");
            Console.WriteLine("\n" + "-----------------------------" + "\n");
        }
       


    }
}

