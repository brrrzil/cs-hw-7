using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW7
{
    struct Worker
    {
        /// <summary> Идентификационный номер </summary>
        public int Id { get; set; }

        /// <summary> Дата добавления </summary>
        public string Date { get; set; }

        /// <summary> Фамилия, Имя, Отчество </summary>
        public string Fio { get; set; }

        /// <summary> Возраст </summary>
        public int Age { get; set; }

        /// <summary> Рост </summary>
        public int Height { get; set; }
        
        /// <summary> Дата рождения </summary>
        public string BirthDay { get; set; }

        /// <summary> Место рождения </summary>
        public string BirthPlace { get; set; }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="Date"></param>
        /// <param name="Fio"></param>
        /// <param name="Age"></param>
        /// <param name="Height"></param>
        /// <param name="BirthDay"></param>
        /// <param name="BirthPlace"></param>

        public Worker(int Id, string Date, string Fio, int Age, int Height, string BirthDay, string BirthPlace)
        {
            this.Id = Id;
            this.Date = Date;
            this.Fio = Fio;
            this.Age = Age;
            this.Height = Height;
            this.BirthDay = BirthDay;
            this.BirthPlace = BirthPlace;
        }

        public Worker(int Id, string Date, string Fio, int Age, int Height, string BirthDay) : this(Id, Date, Fio, Age, Height, BirthDay, "Tver")
        {

        }

        public Worker(int Id, string Date, string Fio, int Age, int Height) : this(Id, Date, Fio, Age, Height, "01.01.0001", "Tver")
        {

        }

        public Worker(int Id) : this(Id, "1983.04.25", "Имя не указано", 0, 0, "Дата рождения не указана", "Место рождения не указано")
        {

        }

        /// <summary> Возвращает строку со всеми данными сотрудника</summary>
        public string Print()
        {
            return (
                $"Дата добавления: {Date}, " +
                $"ID: {Id}, " +
                $"ФИО: {Fio}, " +
                $"Возраст: {Age}, " +
                $"Рост: {Height}, " +
                $"Дата рождения: {BirthDay}, " +
                $"Место рождения: {BirthPlace}\n"
                    );
        }

    }
}
