using FirstLaboratory.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstLaboratory
{
    public class Person: IDateAndCopy
    {
        protected string _name;
        protected string _surname;
        protected DateTime _dataTime;
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }

        public string Surname
        {
            get
            {
                return _surname;
            }
            set
            {
                _surname = value;
            }
        }

        public DateTime Date
        {
            get { return _dataTime; }
            set
            {
                _dataTime = value;
            }
        }

        public Person()
        {

        }

        public Person(string name, string surname, DateTime dateTime)
        {
            _name = name;   
            _surname = surname;
            _dataTime = dateTime;
        }        



        public int Year
        {
            get 
            {
                return (int)_dataTime.Year;
            }
            set
            {
                DateTime newDateTime = new DateTime(value, _dataTime.Month, _dataTime.Day);
                _dataTime = newDateTime;
            }
        }

        public object DeepCopy()
        {
            return new Person() 
            {
                Name = _name,
                Surname = _surname,
                Date = new DateTime(_dataTime.Year, _dataTime.Month, _dataTime.Day) 
            };
        }

        public virtual bool Equals(object? obj)
        {
            if (obj is Person person)
                return Name == person.Name && Surname == person.Surname && Date == person.Date;
            return false;
        }


        public virtual int GetHashCode()
        {
            unchecked
            {
                return _name.GetHashCode() + _surname.GetHashCode() + _dataTime.GetHashCode();
            }
        }

        public static bool operator ==(Person leftItem, Person rightItem)
        {
            return leftItem.Date == rightItem.Date && leftItem.Surname == rightItem.Surname && leftItem.Name == rightItem.Name;
        }

        public static bool operator !=(Person leftItem, Person rightItem)
        {
            return !(leftItem == rightItem);
        }

        public virtual string ToString()
        {
            return $"Имя:{_name}; Фамилия:{_surname}; Дата рождения:{_dataTime}";
        }        

        public string ToShortString()
        {
            return $"Имя:{_name}; Фамилия:{_surname}";
        }

    }
}
