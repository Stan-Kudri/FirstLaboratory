using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstLaboratory.Option1
{
    public class Exam
    {
        public string Subject { get; set; }
        public int Mark { get; set; }
        public DateTime ExamDate { get; set; }

        public Exam() : this("Unknown", 2, new DateTime(2022, 01, 01)) { }

        public Exam(string subject, int mark, DateTime dateTime)
        {
            Subject = subject; 
            Mark = mark;
            ExamDate = dateTime;
        }

        public Exam DeepCopy()
        {
            return new Exam()
            {
                Subject = Subject,
                Mark = Mark,
                ExamDate = ExamDate
            };
        }

        public override string ToString()
        {
            return $"Предмет:{Subject}; Оценка:{Mark}; Дата сдачи:{ExamDate}";
        }
    }
}
