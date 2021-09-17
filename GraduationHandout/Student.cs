using System;
using System.Collections.Generic;
using System.Text;

namespace GraduationHandout
{
    public class Student
    {
        public string     FirstName{get; set;}
        public     string LastName {get; set;}
        public     String Major    {get; set;}
        public     double GPA      {get; set;}
        public Address Address { get; set; }


        public Student()
        {
            FirstName = string.Empty;
            LastName = string.Empty;
            Major = string.Empty;
            GPA = 0;
           Address = new Address(); 
        }

        public Student (string firstname, string lastname, string major, double gpa)
        {
            FirstName = firstname;
            LastName = lastname;
            Major = major;
            GPA = gpa;
            Address = new Address();
        }


        public string CalculateDist()
        {
            string dist;
            if (GPA > 3.80)
            {
                dist = "Summa Cum Laude";
            }
            
                else if (GPA >= 3.60)
                {
                dist = "Magna Cum Laude";
            }
            else if (GPA >= 3.40)
            {
                dist = "Cum Laude";
            }
            else
            {
                dist = " ";
            }

            return dist;
        }

        public void SetAddress (int streetnumber, string streetname, string state, string city, int zipcode)
        {
            Address = new Address(streetnumber, streetname, state, city, zipcode);
        }

        public override string ToString()
        {
            return $"{FirstName}, {LastName}, {Major}, {CalculateDist()}";
        }
    }
}
