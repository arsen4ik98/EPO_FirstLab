using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class RegularGoods : Goods
    {
        public override int GetBonus(int _quantity, double _price)
        {
            int bonus = 0;
            return bonus = (int)(_quantity * _price * 0.05);
        }

        public override double GetDiscount(int _quantity, double _price)
        {
            double discount = 0;
            if (_quantity > 2)
                discount = _quantity * _price * 0.03; // 3%
            return discount;
        }
        public RegularGoods(string title)
            : base(title)
        { }
    }
}
