using DataBaseExam.Entitities;
using Microsoft.EntityFrameworkCore;


namespace DataBaseExam.DbRecordManipulation
{
    public class RecordReadingService
    {
        public readonly static ApplicationDbContext _context = new ApplicationDbContext();
        public void ShowDeptStudents(string deptName)
        {
            var list =  _context.Depts.Where(n=>n.DeptName==deptName).Include(s=>s.Students).ToList();
            foreach (var d in list)
            {
                Console.WriteLine($"{d} Departments students are :");
                foreach(var s in d.Students)
                {
                    Console.WriteLine(s);
                }
            }
            
        }
        public void ShowDeptLectures(string deptName)
        {
            var list = _context.Depts.Where(n=>n.DeptName==deptName).Include(l=>l.Lectures).ToList();
            
            foreach(var d in list)
            {
                Console.WriteLine($"{d} Departments lectures are :");
                foreach(var l in d.Lectures)
                    Console.WriteLine(l);
            }
        }
        public void ShowStudentLectures(string studentName)
        {
            var students = _context.Students.Where(n => n.StudentName == studentName).Include(l => l.Lectures).ToList();
            foreach (var s in students)
            {
                Console.WriteLine($"{s} lectures are :");
                foreach(var l in s.Lectures)
                {
                    Console.WriteLine(l);
                }
            }
        }
    }
}
