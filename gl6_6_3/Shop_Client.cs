using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gl6_6_3
{
    internal class Shop_Client : Ibonus
    {
        double summa_shop; // сумма покупок 
        double summa_buy; // сумма текущей покупки 
        public double Summa_buy
        { //свойство 
            get { return summa_buy; }
            set { summa_buy = value; }
        }
        public Shop_Client()
        { // конструктор 
            summa_shop = 0; summa_buy = 0;
        }

        // реализация метода интерфейса Ibonus  
        // Если сумма покупок больше 30000, но меньше  
        //40000, то скидка на покупку составляет 2%. 
        // Если сумма покупок > 40000, то скидка - 5%. 
        public double bonus()
        {
            double add_bonus = 0.0;
            if (summa_shop > 40000)
                add_bonus = summa_buy * 0.05;
            else
                 if (summa_shop > 30000)
                add_bonus = summa_buy * 0.02;
            return (add_bonus);
        }
        public void New_Buy()
        { // оплата покупки 
            Console.WriteLine("Введите сумму покупки");
            summa_buy = int.Parse(Console.ReadLine());
            summa_shop += summa_buy;
        }
    }
}
