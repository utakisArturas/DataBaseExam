using DataBaseExam.Entitities;
using Microsoft.EntityFrameworkCore;

namespace DataBaseExam.DbRecordManipulation
{
    public class RecordCreatingService
    {

        public readonly static ApplicationDbContext _context = new ApplicationDbContext();

        public Dept CreateDept(string deptName)
        {
            var dept = _context.Depts.SingleOrDefault(d=>d.DeptName == deptName);
            if (dept == null)
            {
                dept = new Dept()
                {
                    DeptName = deptName
                };
               _context.Depts.Add(dept);
               _context.SaveChanges();
            }
            return dept;
        }
        public Student CreateStudent(string deptName,string studentName)
        {
            var dept = _context.Depts.Where(n=>n.DeptName== deptName).SingleOrDefault();
            var student = _context.Students.SingleOrDefault(d => d.StudentName == studentName);
            if (student == null)
            {
                student = new Student()
                {
                    StudentName = studentName,
                    Dept = dept,
                    Lectures = new List<Lecture>()
                };
                _context.Students.Add(student);
                _context.SaveChanges();
            }
            return student;
        }
        public Lecture CreateLecture(string lectureName)
        {
            var lecture = _context.Lectures.SingleOrDefault(n => n.LectureName == lectureName);
            if(lecture == null)
            {
                lecture = new Lecture()
                {
                    LectureName = lectureName,

                };
                _context.Lectures.Add(lecture);
                _context.SaveChanges();
            }
            return lecture;
        }
        public void AddLectureToDept(Lecture lec, Dept dept)
        {
            var validDept = _context.Depts.Where(d=>d.DeptName==dept.DeptName).Include(dp=>dp.Lectures).SingleOrDefault();
            if (validDept != null)
            {
                var validLec = validDept.Lectures
                    .Where(i=>i.Id==lec.Id)
                    .SingleOrDefault();
                if(validLec == null)
                {
                    validDept.Lectures.Add(lec);
                    _context.SaveChanges();
                }
                
            }
        }
        public void AddDeptToLecture(Lecture lec,Dept dept)
        {
            var validLec = _context.Lectures.Where(l=>l.LectureName==lec.LectureName).Include(d=>d.DeptList).SingleOrDefault();
            if( validLec != null)
            {
                var validDept = validLec.DeptList
                    .Where(i => i.Id == dept.Id)
                    .SingleOrDefault();
                if(validDept == null)
                {
                    validLec.DeptList.Add(dept);
                    _context.SaveChanges();
                }
            }
        }
        public void AddLectureToStudent(Lecture lec,Student student)
        {
            var validStudent = _context.Students.Where(s=>s.StudentName==student.StudentName).Include(l=>l.Lectures).SingleOrDefault();
            if(validStudent != null)
            {
                var validLecture = validStudent.Lectures
                    .Where(i => i.Id == lec.Id)
                    .SingleOrDefault();
                if(validLecture == null)
                {
                    validStudent.Lectures.Add(lec);
                    _context.SaveChanges();
                }
            }
        }
        public void ChangeDeptToStudent(string studentName,string deptName)
        {
            var student = _context.Students.Where(n=>n.StudentName == studentName).SingleOrDefault();
            var dept = _context.Depts.Where(n=>n.DeptName==deptName).SingleOrDefault();
            student.Dept = dept;
            _context.Update(student);
            _context.SaveChanges();

        }


    }
}
