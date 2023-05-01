using System;

namespace Project
{
   class Program
    {
        static void Main(string []arg)
        {
          
            Console.WriteLine("Welcome To Tcc "+"\n"+"------------------------");
            while (true)
            {
                Console.WriteLine("Choose the table number you want :" + "\n" + "1.Departments" + "\n" +"2.Students" + "\n" + "3.Subjects" + "\n" + "4.Subject Lectures" + "\n" + "5.Exams" + "\n" + "6.Student Marks");
                int tableNum=Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("\n" + "-----------------------------" + "\n" );
                switch (tableNum)
                {
                    case 1:
                        
                        Console.WriteLine("The Departmens");
                        Console.WriteLine("Choose the operation number you want :" + "\n" + "1.Add" + "\n" + "2.Update" + "\n" + "3.Delete" + "\n" +"4.Show All Data");
                        int operationNum =Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("\n" + "-----------------------------" + "\n");
                        switch (operationNum)
                        {
                            case 1:
                                DepartmentCRUD.AddDepartment();
                                break;
                            case 2: 
                                DepartmentCRUD.UpdateDepartment();
                                break;
                            case 3:
                                DepartmentCRUD.DeleteDepartment();
                                break;
                            case 4:
                                DepartmentCRUD.SelectDepartment();
                                break;
                        }
                        break;
                    case 2:
                        Console.WriteLine("The Students");
                        Console.WriteLine("Choose the operation number you want :" + "\n" + "1.Add" + "\n" + "2.Update" + "\n" + "3.Delete" + "\n" + "4.Show All Data" + "\n" + "5.student who didn't exam" + "\n" + "6.student who did exam" + "\n"+"7.student in departmeant");
                        int OpStdNum = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("\n" + "-----------------------------" + "\n");
                        switch (OpStdNum)
                        {
                            case 1:
                                StudenCRUD.AddStudent();
                                break;
                            case 2:
                                StudenCRUD.updateStudent();
                                break;
                            case 3:
                                StudenCRUD.DeleteStudent();
                                break;
                            case 4:
                                StudenCRUD.SelectStudent();
                                break;
                            case 5:
                                StudenCRUD.Student_didnot_exam();
                                break;
                            case 6:
                                StudenCRUD.Student_did_exam();
                                break;
                            case 7:
                                StudenCRUD.Student_Department();
                                break;


                        }
                        break;
                    case 3:
                      
                        Console.WriteLine("The Subjects");
                        Console.WriteLine("Choose the operation number you want :" + "\n" + "1.Add" + "\n" + "2.Update" + "\n" + "3.Delete" + "\n" + "4.Show All Data" +"\n"+"5.student subject"+"\n"+"6.subject Count lectures");
                        int OpSjtNum = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("\n" + "-----------------------------" + "\n");
                        switch (OpSjtNum)
                        {
                            case 1:
                                SubjectCRUD.AddSubject();
                                break;
                            case 2:
                                SubjectCRUD.updateSubject();
                                break;
                            case 3:
                                SubjectCRUD.DeleteSubject();
                                break;
                            case 4:
                                SubjectCRUD.SelectSubject();
                                break;
                            case 5:
                                SubjectCRUD.Student_subject();
                                break;
                            case 6:
                                SubjectCRUD.count_lecture();
                                break;
                        }
                        break;
                    case 4:
                     
                        Console.WriteLine("The Subject lectures");
                        Console.WriteLine("Choose the operation number you want :" + "\n" + "1.Add" + "\n" + "2.Update" + "\n" + "3.Delete" + "\n" + "4.Show All Data");
                        int op_lecture_num = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("\n" + "-----------------------------" + "\n");
                        switch (op_lecture_num)
                        {
                            case 1:
                                SubjectLectureCRUD.AddSubjectLecture();
                                break;
                            case 2:
                                SubjectLectureCRUD.updateSubjectLecture();
                                break;
                            case 3:
                                SubjectLectureCRUD.DeleteSubjectLecture();
                                break;
                            case 4:
                                SubjectLectureCRUD.SelectLecture();
                                break;
                        }
                        break;
                    case 5:
                    
                        Console.WriteLine("The Exams");
                        Console.WriteLine("Choose the operation number you want :" + "\n" + "1.Add" + "\n" + "2.Update" + "\n" + "3.Delete" + "\n" + "4.Show All Data");
                        int op_exam_num = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("\n" + "-----------------------------" + "\n");
                        switch (op_exam_num)
                        {
                            case 1:
                                ExamCRUD.AddExam();
                                break;
                            case 2:
                                ExamCRUD.updateExam();
                                break;
                            case 3:
                                ExamCRUD.DeleteExam();
                                break;
                            case 4:
                                ExamCRUD.SelectExam();
                                break;
                        }
                        break;
                    case 6:
                        var studentMark = new StudentMark();
                        Console.WriteLine("The Student Mark");
                        Console.WriteLine("Choose the operation number you want :" + "\n" + "1.Add" + "\n" + "2.Update" + "\n" + "3.Delete" + "\n" + "4.Show All Data");
                        int op_mark_num = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("\n" + "-----------------------------" + "\n");
                        switch (op_mark_num)
                        {
                            case 1:
                           
                                StudentMarkCRUD.AddStudenMark();
                                
                                break;
                            case 2:
                                StudentMarkCRUD.updateMark();
                                break;
                            case 3:
                                StudentMarkCRUD.DeleteStudentMark();
                                break;
                            case 4:
                                StudentMarkCRUD.SelectMark();
                                break;
                           
                        }
                        break;

                }
                Console.WriteLine("do you want to continue ? y/n");
                string cont=Console.ReadLine();
                Console.WriteLine("\n" + "-----------------------------" + "\n");
                if (cont == "n")
                    break;
            }
            
        }
    }
}