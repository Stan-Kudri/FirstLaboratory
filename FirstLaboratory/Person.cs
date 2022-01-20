using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstLaboratory
{
    internal class Person
    {
        private string name;
        private string surname;
        private DateTime dataTime;

        public Person(string name, string surname, DateTime dateTime)
        {
            this.name = name;   
            this.surname = surname;
            this.dataTime = dateTime;
        }
        public Person()
        {

        }
        public string Name { get; set; }
        public string Surname { get; set;}
        public DateTime DataTime
        {
            get { return dataTime; }
            set
            {
                dataTime = value;
            }
        }
        public int Year
        {
            get 
            {
                return (int)dataTime.Year;
            }
            set
            {
                DateTime newDateTime = new DateTime(value, dataTime.Month, dataTime.Day);
                dataTime = newDateTime;
            }
        }
        public override string ToString()
        {
            return $"Имя:{name}; Фамилия:{surname}; Дата рождения:{dataTime}".ToString();
        }        
        public string ToShortString()
        {
            return $"Имя:{name}; Фамилия:{surname}".ToString();
        }
    }
}
