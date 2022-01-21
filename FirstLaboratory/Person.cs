﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstLaboratory
{
    public class Person
    {
        private string _name;
        private string _surname;
        private DateTime _dataTime;

        public Person(string name, string surname, DateTime dateTime)
        {
            _name = name;   
            _surname = surname;
            _dataTime = dateTime;
        }
        public Person()
        {

        }
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
        public DateTime DataTime
        {
            get { return _dataTime; }
            set
            {
                _dataTime = value;
            }
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
        public override string ToString()
        {
            return $"Имя:{_name}; Фамилия:{_surname}; Дата рождения:{_dataTime}".ToString();
        }        
        public string ToShortString()
        {
            return $"Имя:{_name}; Фамилия:{_surname}".ToString();
        }
    }
}
