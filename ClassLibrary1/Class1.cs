using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using ConsoleApplication1;

namespace ClassLibrary1
{

    [TestFixture]
    public class test
    {
        [Test()]

        public void Test_PepsiCola1()
        {
            Goods cola = new RegularGoods("Cola");
            Goods pepsi = new SaleGoods("Pepsi");
            Item i1 = new Item(cola, 1, 65);
            Item i2 = new Item(pepsi, 4, 50);
            Customer x = new Customer("test", 10);
            Bill b1 = new Bill(x);
            b1.addGoods(i1);
            b1.addGoods(i2);
            string actual = b1.statement();
            string expected = "Счет для test\n\tНазвание\tЦена\tКол-воСтоимость\tСкидка\tСумма\tБонус\n\tCola\t\t65\t1\t65\t0\t65\t3\n\tPepsi\t\t50\t4\t200\t2\t198\t2\nСумма счета составляет 263\nВы заработали 5 бонусных баллов";
            Assert.AreEqual(expected, actual);
        }
       [Test()]
        public void Test_PepsiCola()
        {
            Goods cola = new RegularGoods("Cola");
            Goods pepsi = new SaleGoods("Pepsi");
            Item i1 = new Item(cola, 6, 65);
            Item i2 = new Item(pepsi, 3, 50);
            Customer x = new Customer("test", 10);
            Bill b1 = new Bill(x);
            b1.addGoods(i1);
            b1.addGoods(i2);
            string actual = b1.statement();
            string expected = "Счет для test\n\tНазвание\tЦена\tКол-воСтоимость\tСкидка\tСумма\tБонус\n\tCola\t\t65\t6\t390\t11,7\t368,3\t19\n\tPepsi\t\t50\t3\t150\t0\t150\t1\nСумма счета составляет 518,3\nВы заработали 20 бонусных баллов";
            Assert.AreEqual(expected, actual);
        }
        [Test()]
        public void Test_Cola()
        {
            Goods cola = new RegularGoods("Cola");
            Item i1 = new Item(cola, 6, 65);
            Customer x = new Customer("test", 10);
            Bill b1 = new Bill(x);
            b1.addGoods(i1);
            string actual = b1.statement();
            string expected = "Счет для test\n\tНазвание\tЦена\tКол-воСтоимость\tСкидка\tСумма\tБонус\n\tCola\t\t65\t6\t390\t11,7\t368,3\t19\nСумма счета составляет 368,3\nВы заработали 19 бонусных баллов";
            Assert.AreEqual(expected, actual);
        }
        [Test()]
        public void Test_Pepsi()
        {
            Goods pepsi = new RegularGoods("Pepsi");
            Item i2 = new Item(pepsi, 3, 50);
            Customer x = new Customer("test", 10);
            Bill b2 = new Bill(x);
            b2.addGoods(i2);
            string actual = b2.statement();
            string expected = "Счет для test\n\tНазвание\tЦена\tКол-воСтоимость\tСкидка\tСумма\tБонус\n\tPepsi\t\t50\t3\t150\t4,5\t145,5\t7\nСумма счета составляет 145,5\nВы заработали 7 бонусных баллов";
            Assert.AreEqual(expected, actual);
        }
        [Test()]
        public void Test_Fanta()
        {
            Goods fanta = new RegularGoods("Fanta");
            Item i2 = new Item(fanta, 1, 35);
            Customer x = new Customer("test", 10);
            Bill b2 = new Bill(x);
            b2.addGoods(i2);
            string actual = b2.statement();
            string expected = "Счет для test\n\tНазвание\tЦена\tКол-воСтоимость\tСкидка\tСумма\tБонус\n\tFanta\t\t35\t1\t35\t0\t35\t1\nСумма счета составляет 35\nВы заработали 1 бонусных баллов";
            Assert.AreEqual(expected, actual);
        }
        [Test()]
        public void Test_ColaFanta()
        {
            Goods cola = new RegularGoods("Cola");
            Goods fanta = new SaleGoods("Fanta");
            Item i1 = new Item(cola, 6, 65);
            Item i2 = new Item(fanta, 1, 35);
            Customer x = new Customer("test", 10);
            Bill b1 = new Bill(x);
            b1.addGoods(i1);
            b1.addGoods(i2);
            string actual = b1.statement();
            string expected = "Счет для test\n\tНазвание\tЦена\tКол-воСтоимость\tСкидка\tСумма\tБонус\n\tCola\t\t65\t6\t390\t11,7\t368,3\t19\n\tFanta\t\t35\t1\t35\t0\t35\t0\nСумма счета составляет 403,3\nВы заработали 19 бонусных баллов";
            Assert.AreEqual(expected, actual);
        }
        [Test()]
        public void Test_PepsiFanta()
        {
            Goods pepsi = new RegularGoods("Pepsi");
            Goods fanta = new SaleGoods("Fanta");
            Item i1 = new Item(pepsi, 3, 50);
            Item i2 = new Item(fanta, 1, 35);
            Customer x = new Customer("test", 10);
            Bill b1 = new Bill(x);
            b1.addGoods(i1);
            b1.addGoods(i2);
            string actual = b1.statement();
            string expected = "Счет для test\n\tНазвание\tЦена\tКол-воСтоимость\tСкидка\tСумма\tБонус\n\tPepsi\t\t50\t3\t150\t4,5\t145,5\t7\n\tFanta\t\t35\t1\t35\t0\t35\t0\nСумма счета составляет 180,5\nВы заработали 7 бонусных баллов";
            Assert.AreEqual(expected, actual);
        }
        [Test()]
        public void Test_PepsiColaFanta()
        {
            Goods cola = new RegularGoods("Cola");
            Goods pepsi = new SaleGoods("Pepsi");
            Goods fanta = new RegularGoods("Fanta");
            Item i1 = new Item(cola, 6, 65);
            Item i2 = new Item(pepsi, 3, 50);
            Item i3 = new Item(fanta, 1, 35);
            Customer x = new Customer("test", 10);
            Bill b1 = new Bill(x);
            b1.addGoods(i1);
            b1.addGoods(i2);
            b1.addGoods(i3);
            string actual = b1.statement();
            string expected = "Счет для test\n\tНазвание\tЦена\tКол-воСтоимость\tСкидка\tСумма\tБонус\n\tCola\t\t65\t6\t390\t11,7\t368,3\t19\n\tPepsi\t\t50\t3\t150\t0\t150\t1\n\tFanta\t\t35\t1\t35\t0\t35\t1\nСумма счета составляет 553,3\nВы заработали 21 бонусных баллов";
            Assert.AreEqual(expected, actual);
        }
        [Test()]
        public void Test_PepsiCola_Offer()
        {
            Goods cola = new RegularGoods("Cola");
            Goods pepsi = new SpecialOrderGoods("Pepsi");
            Item i1 = new Item(cola, 6, 65);
            Item i2 = new Item(pepsi, 3, 50);
            Customer x = new Customer("test", 10);
            Bill b1 = new Bill(x);
            b1.addGoods(i1);
            b1.addGoods(i2);
            string actual = b1.statement();
            string expected = "Счет для test\n\tНазвание\tЦена\tКол-воСтоимость\tСкидка\tСумма\tБонус\n\tCola\t\t65\t6\t390\t11,7\t368,3\t19\n\tPepsi\t\t50\t3\t150\t0\t150\t0\nСумма счета составляет 518,3\nВы заработали 19 бонусных баллов";
            Assert.AreEqual(expected, actual);
        }
        [Test()]
        public void Test_PepsiCola_Offer_EF()
        {
            Goods cola = new RegularGoods("Cola");
            Goods pepsi = new SpecialOrderGoods("Pepsi");
            Item i1 = new Item(cola, 6, 65);
            Item i2 = new Item(pepsi, 11, 50);
            Customer x = new Customer("test", 10);
            Bill b1 = new Bill(x);
            b1.addGoods(i1);
            b1.addGoods(i2);
            string actual = b1.statement();
            string expected = "Счет для test\n\tНазвание\tЦена\tКол-воСтоимость\tСкидка\tСумма\tБонус\n\tCola\t\t65\t6\t390\t11,7\t368,3\t19\n\tPepsi\t\t50\t11\t550\t2,75\t547,25\t0\nСумма счета составляет 915,55\nВы заработали 19 бонусных баллов";
            Assert.AreEqual(expected, actual);
        }
    }
}