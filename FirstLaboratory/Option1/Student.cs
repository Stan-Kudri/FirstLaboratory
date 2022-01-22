using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstLaboratory.Option1
{
    public class Student
    {
        private Person _person;
        private Education _education;
        private int _groupNumber;
        private Exam[] _exams;

        public Person Person
        {
            get { return _person; }
            set { _person = value; }
        }

        public Education Education
        {
            get { return _education; }
            set { _education = value; }
        }

        public int GroupNumber
        {
            get { return _groupNumber; }
            set { _groupNumber = value; }
        }

        public Exam[] Exams
        {
            get { return _exams; }
            set { _exams = value; }
        }
        
        public Student() : this
            (
                CreateDefaulPerson(),
                Education.Specialist,
                1,
                new Exam[] { new Exam() }
            )
        { }

        public Student(Person person, Education education, int groupNumber, Exam[] exems)
        {
            _person = person;
            _education = education;
            _groupNumber = groupNumber;
            _exams = exems ;
        }

        public double AverageMark => Exams.Average(x => x.Mark);

        public bool this[Education educationAccepted]
        { 
            get
            {
                return educationAccepted == Education;
            }
        }

        public void AddExam(params Exam[] addExams)
        {
            var newExem = new Exam[_exams.Length + addExams.Length];
            Array.Copy(_exams, newExem, _exams.Length);
            Array.Copy(addExams, 0, newExem, 1, addExams.Length);
            Exams = newExem;
        }

        public override string? ToString()
        {
            if (!CheckExam())
                return null;
            return new StringBuilder()
                .AppendLine(Person.ToString())
                .Append("Education = ").AppendLine(Education.ToString())
                .Append("GroupNumber = ").AppendLine(GroupNumber.ToString())
                .Append("Exams:").AppendLine(String.Join(';', Exams.Select(x => x.Subject)))
                .ToString();
        }

        public string? ToShortString()
        {
            if (!CheckExam())
                return null;
            return new StringBuilder()
                .AppendLine(Person.ToString())
                .Append("Education = ").AppendLine(Education.ToString())
                .Append("GroupNumber = ").AppendLine(GroupNumber.ToString())
                .Append("AvarageMark: ").AppendLine(AverageMark.ToString())
                .ToString();
        }

        private bool CheckExam()
        {
            if(Exams.Length == 0)
                return false;
            return true;
        }

        private static Person CreateDefaulPerson()
        {
            return new Person() { Name = "Sergey", Surname = "Shirokov", DataTime = new DateTime(1998, 01, 15) };
        }

    }
}
