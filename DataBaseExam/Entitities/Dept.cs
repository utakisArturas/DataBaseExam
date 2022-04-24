
namespace DataBaseExam.Entitities
{
    public class Dept
    {
        public int Id { get; set; }
        public string DeptName { get; set; }
        public List<Lecture> Lectures { get; set; }
        public List<Student> Students { get; set; }

        public override string ToString()
        {
            return $"{DeptName}";
        }

    }
}
