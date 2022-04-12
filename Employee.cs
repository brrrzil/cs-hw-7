using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW7
{
    struct Employee
    {
        public int ID { get; set; }
        public DateTime CreateTime { get; set; }
        public string FullName { get; set; }
        //public DateTime BirthDate { get; set; }
        //public int Age { get; set; }
        //public string Birthplace { get; set; }


        public Employee(string input)
        {
            string[] arr = input.Split('#');

            ID = int.Parse(arr[0]);
            CreateTime = Convert.ToDateTime(arr[1]);
            FullName = arr[2];
            //BirthDate = DateTime.Parse(arr[3]);
            //Birthplace = arr[4];
            //Age = (DateTime.Now.Year - BirthDate.Year);                                                                                        // Вычисление
            //if (DateTime.Now.Month < BirthDate.Month || (DateTime.Now.Month == BirthDate.Month && DateTime.Now.Day < BirthDate.Day)) Age -- ;  //  возраста
        }

        public string Print()
        {
            return $"{ID}#{CreateTime.ToShortDateString()}#{FullName}";
            //return $"{ID}\t{CreateTime.ToString()}\t{FullName}\t{Age}\t{Birthplace}";
        }
    }
}