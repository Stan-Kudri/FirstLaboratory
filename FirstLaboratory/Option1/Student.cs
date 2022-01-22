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
                new Person() { Name = "Sergey", Surname = "Shirokov", DataTime = new DateTime(1998, 01, 15) },
                Education.Specialist,
                1,
                new Exam[] { new Exam() }
            )
        { }

        public Student(Person person, Education education, int groupNumber, Exam[] exems)
        {
            this._person = person;
            this._education = education;
            this._groupNumber = groupNumber;
            this._exams = exems ;
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

        public override string ToString()
        {
            StringBuilder str = new StringBuilder();
            str.AppendLine(Person.ToString())
                .AppendLine("Education = " + Education.ToString())
                .AppendLine("GroupNumber = " + GroupNumber)
                .AppendLine("Exams:" + String.Join(';', Exams.Select(x => x.Subject)));            
            return str.ToString();
        }

        public string ToShortString()
        {
            StringBuilder str = new StringBuilder();
            str.AppendLine(Person.ToString())
                .AppendLine("Education = " + Education.ToString())
                .AppendLine("GroupNumber = " + GroupNumber)
                .AppendLine("AvarageMark: " + AverageMark.ToString());
            return str.ToString();
        }
    }
}
