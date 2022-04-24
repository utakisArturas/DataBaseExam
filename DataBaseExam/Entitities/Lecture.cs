
namespace DataBaseExam.Entitities
{
    public class Lecture
    {
        public int Id { get; set; }
        public string LectureName { get; set; }
        public List<Dept> DeptList { get; set; }
        public List<Student> Students { get; set; }

        public override string ToString()
        {
            return $"{LectureName}";
        }


    }
}
