using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NAZAR_LAB;

namespace UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestDB_ServerConnection()
        {
            DB_ServerConnection dbc1 = DB_ServerConnection.getInstance();
            DB_ServerConnection dbc2 = DB_ServerConnection.getInstance();
            Assert.AreEqual(dbc1, dbc2);
        }
        [TestMethod]
        public void TestStudent()
        {
            Student student = new Student() { FirstName = "Oleg" };
            Assert.AreEqual(student.FirstName, "Oleg");
        }
        [TestMethod]
        public void TestStudent2()
        {
            Student student = new Student() { Age = "17" };
            Assert.AreEqual(student.Age, "17");
        }
        [TestMethod]
        public void TestStudent3()
        {
            List<Student> l = new List<Student>();
            Student student = new Student() { Login = "Stepan" };
            l.Add(student);
            Assert.AreEqual(l[0].Login, "Stepan");
        }
        [TestMethod]
        public void TestMakeStudentsFromList()
        {
            List<Student> l = DB_ServerConnection.MakeListFromString("");
            Assert.AreEqual(l.Count, 0);
        }
        [TestMethod]
        public void TestMakeStudentsFromList2()
        {
            List<Student> l = DB_ServerConnection.MakeListFromString("Настя/Будько/21/МТ-33/ІКТА/Метрологія/ВК11783344/");
            Assert.AreEqual(l.Count, 1);
        }
        [TestMethod]
        public void TestMakeStudentsFromList3()
        {
            List<Student> l = DB_ServerConnection.MakeListFromString("Настя/Будько/21/МТ-33/ІКТА/Метрологія/ВК11783344/");
            Assert.AreEqual(l[0].FirstName, "Настя");
        }
        [TestMethod]
        public void TestMakeStudentsFromList4()
        {
            List<Student> l = DB_ServerConnection.MakeListFromString("Настя/Будько/21/МТ-33/ІКТА/Метрологія/ВК11783344/Марія/Лега/20/МТ-33/ІКТА/Метрологія/ВК11663344/");
            Assert.AreEqual(l[1].FirstName, "Марія");
        }
        [TestMethod]
        public void TestSplit()
        {
            string str = "Настя/Будько/21/";
            string[] data = str.Split('/');
            Assert.AreEqual(data[0], "Настя");
        }
        [TestMethod]
        public void TestSplit2()
        {
            string str = "Настя/Будько/21";
            string[] data = str.Split('/');
            Assert.AreEqual(data.Length, 3);
        }
    }
}
