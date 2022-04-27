using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gl6_6_3
{
    internal class Bank_Client : Iaccount, Ibonus
    {
        /// <summary>
        /// Имя клиента
        /// </summary>
        string name;
        /// <summary>
        /// Номер паспорта
        /// </summary>
        int passport; 

        /// <summary>
        /// Сумма вклада
        /// </summary>
        double summa_bank;
        /// <summary>
        /// дата открытия счета 
        /// </summary>
        DateTime date;
        public double Summa_bank
        { // свойство 
            get { return summa_bank; }
        }
        // конструктор 
        /// <summary>
        /// Конструктор с параметрами
        /// </summary>
        /// <param name="name"></param>
        /// <param name="passport"></param>
        /// <param name="summa_bank"></param>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="day"></param>
        public Bank_Client (
            string name,
            int passport,
            double summa_bank,
            int year,
            int month,
            int day )
        {
            this.name = name;
            this.passport = passport;
            this.summa_bank = summa_bank;
            date = new DateTime(year, month, day);
        }
        /// <summary>
        ///  вывод информации о клиенте 
        /// </summary>
        public void Person_Display()
        {
            Console.WriteLine(" " + name + " " + passport +
                              " " + summa_bank + " " + date);
        }
        // реализация методов интерфейса Iaccount 
        /// <summary>
        /// Положить указанную сумму на счет 
        /// </summary>
        /// <param name="summa">приходная сумма</param>        
        public void put(double summa)
        {
            summa_bank += summa;
        }
        // Снять деньги со счета 
        public void get(double summa)
        {
            if (summa <= summa_bank)
                summa_bank -= summa;
        }
        // Начислить проценты в размере 10% годовых.    
        // Проценты начисляются один раз, если вклад   
        // пролежал год  
        public void percent()
        {
            DateTime today = DateTime.Today;
            if ((today - date).Days == 365)
                summa_bank *= 1.1;
        }
        // реализация метода интерфейса Ibonus 
        // Начислить бонус в размере 0,5% в последний   
        // день  года, если вклад более 1000000 рублей 
        // пролежал более 6 месяцев 
        public double bonus()
        {
            double add_bonus = 0.0;
            DateTime today = DateTime.Today;
            DateTime endOfYear =
                    new DateTime(today.Year, 12, 31);
            if (today == endOfYear)
            {
                int summa_days =
                       (endOfYear - date).Days;
                if (summa_bank > 1000000 &&
                                  summa_days > 180)
                    add_bonus = summa_bank * 0.005;
                Console.WriteLine
                    (" Бонус начислен" + add_bonus);
            }
            return (add_bonus);
        }
    }

}
