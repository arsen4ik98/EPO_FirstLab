﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class Bill
    {
        private List<Item> _items;
        private Customer _customer;
        public Bill(Customer customer)
        {
            this._customer = customer;
            this._items = new List<Item>();
        }

        public void addGoods(Item arg)
        {
            _items.Add(arg);
        }

        public string GetHeader()
        {
            string result = "Счет для " + _customer.getName() + "\n";
            result += "\t" + "Название" + "\t" + "Цена" +
            "\t" + "Кол-во" + "Стоимость" + "\t" + "Скидка" +
            "\t" + "Сумма" + "\t" + "Бонус" + "\n";
            return result;
        }
        public string GetFooter(double totalAmount, int totalBonus)
        {
            string result = "Сумма счета составляет " +
              totalAmount.ToString() + "\n" + "Вы заработали " + totalBonus.ToString() + " бонусных баллов";
            return result;
        }
        public string GetItemString(double thisAmount, double discount, int bonus, Item each)
        {
            string result = "\t" + each.getGoods().getTitle() + "\t" +
              "\t" + each.getPrice() + "\t" + each.getQuantity() +
              "\t" + (each.getQuantity() * each.getPrice()).ToString() +
              "\t" + discount.ToString() + "\t" + thisAmount.ToString() +
              "\t" + bonus.ToString() + "\n";
            return result;
        }

        public double GetDiscount(Item each)
        {
            double discount = 0;
            switch (each.getGoods().getPriceCode())
            {
                case Goods.REGULAR:
                    if (each.getQuantity() > 2)
                        discount =
                        (each.getQuantity() * each.getPrice()) * 0.03; // 3%
                    break;
                case Goods.SPECIAL_OFFER:
                    if (each.getQuantity() > 10)
                        discount =
                        (each.getQuantity() * each.getPrice()) * 0.005; // 0.5%
                    break;
                case Goods.SALE:
                    if (each.getQuantity() > 3)
                        discount =
                        (each.getQuantity() * each.getPrice()) * 0.01; // 1%
                    break;
            }
            return discount;
        }

        public int GetBonus(Item each)
        {
            int bonus = 0;
            switch (each.getGoods().getPriceCode())
            {
                case Goods.REGULAR:
                    bonus = (int)(GetSum(each) * 0.05);
                    break;
                case Goods.SALE:
                    bonus = (int)(GetSum(each) * 0.01);
                    break;
            }
            return bonus;
        }

        public double GetSum(Item each)
        {
            double getsum = each.getQuantity() * each.getPrice();
            return getsum;
        }

        public double GetUsedBonus(Item each, double thisAmount, double discount)
        {
            double usedBonus = 0;
            if ((each.getGoods().getPriceCode() == Goods.REGULAR) && each.getQuantity() > 5)
            {
                usedBonus += _customer.useBonus((int)(thisAmount - discount));
            }
            if ((each.getGoods().getPriceCode() == Goods.SPECIAL_OFFER) && each.getQuantity() > 1)
            {
                usedBonus += _customer.useBonus((int)(thisAmount - discount));
            }
            return usedBonus;
        }

        public String statement()
        {
            double totalAmount = 0;
            int totalBonus = 0;
            List<Item>.Enumerator items = _items.GetEnumerator();
            string result = GetHeader();
            while (items.MoveNext())
            {
                double sumWithDiscount = 0;
                double usedBonus = 0;
                double thisAmount = 0;

                Item each = (Item)items.Current;
                //определить сумму для каждой строки
                double discount = GetDiscount(each);
                int bonus = GetBonus(each);
                // сумма
                sumWithDiscount = GetSum(each) - discount;
                usedBonus = GetUsedBonus(each, sumWithDiscount, discount);
                // учитываем скидку
                thisAmount = sumWithDiscount - usedBonus;
                //показать результаты
                result += GetItemString(thisAmount, discount, bonus, each);
            
                totalAmount += thisAmount;
                totalBonus += bonus;
            }
            //добавить нижний колонтитул
            //Запомнить бонус клиента
            result += GetFooter(totalAmount, totalBonus);
            _customer.receiveBonus(totalBonus);
            return result;
        }

    }
}