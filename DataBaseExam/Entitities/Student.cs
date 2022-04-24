
namespace DataBaseExam.Entitities
{
    public class Student
    {
        public int Id { get; set; }
        public string StudentName { get; set; }
        public Dept Dept { get; set; }
        public List<Lecture> Lectures { get; set; }

        public override string ToString()
        {
            return $"{StudentName}";
        }


    }
}
