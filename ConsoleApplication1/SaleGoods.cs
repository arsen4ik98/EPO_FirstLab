using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class SaleGoods : Goods
    {
        public override int GetBonus(int _quantity, double _price)
        {
            int bonus = 0;
            return bonus = (int)(_quantity * _price * 0.01);
        }

        public override double GetDiscount(int _quantity, double _price)
        {
            double discount = 0;
            if (_quantity > 3)
                discount = _quantity * _price * 0.01; // 0.1%
            return discount;
        }
        public SaleGoods(string title)
            : base(title)
        { }
    }
}
