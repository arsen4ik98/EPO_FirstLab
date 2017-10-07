﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        public string GetFooter( double totalAmount, int totalBonus)
        {
         string  result = "Сумма счета составляет " +
           totalAmount.ToString() + "\n" + "Вы заработали " + totalBonus.ToString() + " бонусных баллов";
            return result;
        }
        public string GetItemString(Item each, double thisAmount, double discount, int bonus)
        {
          string  result = "\t" + each.getGoods().getTitle() + "\t" +
            "\t" + each.getPrice() + "\t" + each.getQuantity() +
            "\t" + (each.getQuantity() * each.getPrice()).ToString() +
            "\t" + discount.ToString() + "\t" + thisAmount.ToString() +
            "\t" + bonus.ToString() + "\n";
            return result;
        }
        public double GetBonus(Item each)
        {
            int bonus = 0;
             switch (each.getGoods().getPriceCode())
                {

                    case Goods.REGULAR:
                        if (each.getQuantity() > 2)
                        bonus =
                        (int)(each.getQuantity() * each.getPrice() * 0.05);
                        break;                     
                    case Goods.SALE:
                        if (each.getQuantity() > 3)
                        bonus =
                        (int)(each.getQuantity() * each.getPrice() * 0.01);
                        break;
                }
             return bonus;
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
                        (each.getQuantity() * each.getPrice()) * 0.01; // 0.1%
                    break;
            }
            if ((each.getGoods().getPriceCode() ==
                Goods.REGULAR) && each.getQuantity() > 5)
                    discount +=
                    _customer.useBonus((int)(each.getQuantity() * each.getPrice()));
                if ((each.getGoods().getPriceCode() ==
                Goods.SPECIAL_OFFER) && each.getQuantity() > 1)
                    discount =
                    _customer.useBonus((int)(each.getQuantity() * each.getPrice()));
            return discount;
        }
        public String statement()
        {
            double totalAmount = 0;
            string result = GetHeader();
        
            int totalBonus = 0;
            List<Item>.Enumerator items = _items.GetEnumerator();
            while (items.MoveNext())
            {
                double thisAmount,discount = 0;
                int bonus = 0;
                Item each = (Item)items.Current;
                //определить сумму для каждой строки

                // сумма
                thisAmount = each.getQuantity() * each.getPrice();
                // используем бонусы
                
                // учитываем скидку
                thisAmount =
                each.getQuantity() * each.getPrice() - discount;
                //показать результаты
                 result += GetItemString(each ,thisAmount, discount, bonus);
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