using NUnit.Framework;
using System;
using BullAndCows;
namespace TEST
{
    public class Tests
    {
        authorization form1;
        Game form2;
        [SetUp]
        public void Setup()
        {
            form1 = new authorization();
            form2 = new Game();
        }
        [Test]
        public void TestAuthorize()
        {
            string path = @"D:\bncUSER\bncUSER.txt";
            string login = "123";
            string pass = "321";
            Assert.IsTrue(form1.authoriz(path, login, pass));
            login = "12345";
            Assert.IsFalse(form1.authoriz(path, login, pass));
            login = "123";
            pass = "123";
            Assert.IsFalse(form1.authoriz(path, login, pass));
            login = "";
            pass = " ";
            Assert.IsFalse(form1.authoriz(path, login, pass));
        }
        [Test]
        public void TestRegistrate()
        {
            string path = @"D:\bncUSER\bncUSER.txt";
            string login = "123";
            string pass = "321";
            Assert.IsTrue(form1.registrate(path, login, pass));
            login = "1234";
            Assert.IsTrue(form1.registrate(path, login, pass));
            login = "";
            pass = " ";
            Assert.IsFalse(form1.registrate(path, login, pass));
        }
        [Test]
        public void TestCut()
        {
            int randomnumber = 1234;
            int expectednum1 = 1;
            int expectednum2 = 2;
            int expectednum3 = 3;
            int expectednum4 = 4;
            Assert.AreEqual(expectednum1, form2.Cut(randomnumber)[0]);
            Assert.AreEqual(expectednum2, form2.Cut(randomnumber)[1]);
            Assert.AreEqual(expectednum3, form2.Cut(randomnumber)[2]);
            Assert.AreEqual(expectednum4, form2.Cut(randomnumber)[3]);

        }
        [Test]
        public void TestCheckNum()
        {
            int number = 1;
            int randnum1 = 1;
            int randnum2 = 2;
            int randnum3 = 3;
            int randnum4 = 4;
            string expectedC = "Cow";
            string expectedB = "Bull";
            string expectedD = "default";
            Assert.AreEqual(expectedC, form2.CheckNum(number,randnum1, randnum2, randnum3, randnum4));
            Assert.AreEqual(expectedB, form2.CheckNum(number, randnum2, randnum1, randnum3, randnum4));
            number = 5;
            Assert.AreEqual(expectedD, form2.CheckNum(number, randnum1, randnum2, randnum3, randnum4));
        }
    }
}
