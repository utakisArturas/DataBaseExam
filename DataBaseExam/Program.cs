// See https://aka.ms/new-console-template for more information
using DataBaseExam;
using DataBaseExam.DbRecordManipulation;
using DataBaseExam.Entitities;


var rc = new RecordCreatingService();
var rr = new RecordReadingService();
rc.CreateDept("Sports"); //----------------------------> sukurti Departamentą
rc.CreateStudent("Sports", "Larry"); //----------------------------> sukurti studentą
rc.CreateLecture("Gymnastic"); //----------------------------> sukurti paskaitą
rc.CreateDept("Sociology"); //----------------------------> sukurti papildomą Departamentą
rc.CreateDept("Steam"); //----------------------------> sukurti papildomą Departamentą

var dept = new Dept();
dept.DeptName = "Sports";

var lecture = new Lecture();
lecture.LectureName = "Math";
rc.AddLectureToDept(lecture, dept); //----------------------------> pridėti paskaitą į departamentą

var lec1 = lecture;
var dept1 = new Dept()
{
    DeptName = "Sociology"
};
rc.AddDeptToLecture(lec1, dept1); //----------------------------> pridėti departamentą paskaitai

var student = new Student()
{
    StudentName = "Larry"
};
rc.AddLectureToStudent(lec1, student); //----------------------------> pridėti paskaitą studentui

rc.ChangeDeptToStudent("Larry", "Steam"); //----------------------------> pakeičiam departamentą studentui(Larry dept buvo ="Sports",dabar "Steam")

rr.ShowDeptStudents("Steam"); //----------------------------> Steam studentas Larry
rr.ShowDeptLectures("Sociology"); //----------------------------> sociologijai paskirta viena paskaita - Math
rr.ShowStudentLectures("Larry"); //----------------------------> Larriui paskirta viena paskaita - Math








