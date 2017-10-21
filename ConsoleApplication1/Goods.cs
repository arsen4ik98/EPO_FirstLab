using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace ConsoleApplication1
{
    // Класс, который представляет данные о товаре
    public abstract class Goods
    {
        public string _title;
        public Goods(string title)
        {
            _title = title;
        }

        public string getTitle()
        {
            return _title;
        }
        public abstract int GetBonus(int _quantity, double _price);
        public abstract double GetDiscount(int _quantity, double _price);
    }
}