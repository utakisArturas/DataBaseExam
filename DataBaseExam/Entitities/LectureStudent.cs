
namespace DataBaseExam.Entitities
{
    public class LectureStudent
    {
        public Lecture Lecture { get; set; }
        public int LecturesId { get; set; }
        public Student Student { get; set; }
        public int StudentsId { get; set; }
    }
}
