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

        public Student()
        {
            _person = new Person()
            {
                Name = "Sergey",
                Surname = "Shirokov",
                DataTime = new DateTime(1998, 01, 15),
            };
            _education = Education.Specialist;
            _groupNumber = 1;
            _exams = new Exam[] { new Exam()};
        }

        public Student(Person person, Education education, int groupNumber)
        {
            _person = person;
            _education = education;
            _groupNumber = groupNumber;
        }

        public double AverageMark
        {
            get
            {
                return Exams.Average(x => x.Mark);
            }
        }             

        public bool this[Education educationAccepted]
        { 
            get
            {
                return educationAccepted == Education;
            }
        }
        public void AddExem(params Exam[] addExams)
        {
            var newExem = new Exam[_exams.Length + addExams.Length];
            for (var i = 0; i < _exams.Length; i++)
            {
                newExem[i] = _exams[i];
            }
            int indexAddExam = 0;
            for (var i = _exams.Length; i < newExem.Length; i++)
            {
                newExem[i] = addExams[indexAddExam++];
            }
            Exams = new Exam[newExem.Length];
            Array.Copy(newExem,Exams,_exams.Length);
        }

        public override string ToString()
        {
            StringBuilder str = new StringBuilder($"{Person.ToString()}\nEducation = {Education.ToString()}\nGroupNumber = {GroupNumber}\nExams:{String.Join(';', Exams.Select(x=>x.Subject))}");
            return str.ToString();
        }

        public string ToShortString()
        {
            StringBuilder str = new StringBuilder($"{Person.ToString()}\nEducation = {Education.ToString()}\nGroupNumber = {GroupNumber}\nAvarageMark:{AverageMark.ToString()}");
            return str.ToString();
        }
    }
}
