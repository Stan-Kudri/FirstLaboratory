using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstLaboratory.Option1
{
    public class Student: Person
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

        public Student(Person person, Education education, int groupNumber, Exam[] exams)
        {
            _person = person;
            _education = education;
            _groupNumber = groupNumber;
            CheckExamForException(exams);
            _exams = exams ;            
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
            CheckExamForException(addExams);
            CheckExamItemsExceprion(addExams);
            CheckExamForException(_exams);
            var newExem = new Exam[_exams.Length + addExams.Length];
            if(_exams.Length == 0)
            {
                Array.Copy(addExams, newExem, addExams.Length);
            }
            else
            {
                Array.Copy(_exams, newExem, _exams.Length);
                Array.Copy(addExams, 0, newExem, 1, addExams.Length);
            }
            Exams = newExem;
        }

        public Student DeepCopy()
        {
            return new Student()
            {
                Person = (Person)_person.DeepCopy(),
                Education = (Education)_education,
                GroupNumber = _groupNumber,
                Exams = _exams.Select(x => x.DeepCopy()).ToArray()
            };
        }

        public override int GetHashCode()
        {
            return _person.GetHashCode() + _education.GetHashCode() + _groupNumber.GetHashCode() + _exams.GetHashCode();
        }

        public override string? ToString()
        {
            StringBuilder str = new StringBuilder();
            str.AppendLine(Person.ToString())
                .Append("Education = ").AppendLine(Education.ToString())
                .Append("GroupNumber = ").AppendLine(GroupNumber.ToString());
            if (HaveAnyExam())
                str.Append("Exams:").AppendLine(String.Join(';', Exams.Select(x => x.Subject)));
            return str.ToString();
        }

        public string? ToShortString()
        {
            StringBuilder str = new StringBuilder();
            str.AppendLine(Person.ToString())
                .Append("Education = ").AppendLine(Education.ToString())
                .Append("GroupNumber = ").AppendLine(GroupNumber.ToString());
            if (HaveAnyExam())
                str.Append("AvarageMark: ").AppendLine(AverageMark.ToString());
            return str.ToString();
        }

        private void CheckExamForException(Exam [] exam)
        {
            if (exam == null)
                throw new ArgumentException("Exam Not Equal Null!");
            foreach (var item in exam)
            {
                if (item == null)
                    throw new ArgumentException("Element cannot be Null!");
            }
        }

        private void CheckExamItemsExceprion(Exam [] exam)
        {            
            if (exam.Length == 0)
                throw new ArgumentException("No items to add.");
        }

        private bool HaveAnyExam()
        {
            if (Exams == null || Exams.Length == 0)
                return false;
            return true;
        }

        private static Person CreateDefaulPerson()
        {
            return new Person() 
            {
                Name = "Sergey",
                Surname = "Shirokov",
                Date = new DateTime(1998, 01, 15) 
            };
        }

    }
}
