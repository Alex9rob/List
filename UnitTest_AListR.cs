using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ORT_06;
using NUnit.Framework;
namespace NUnitTestProject1
{
    //[TestFixture(typeof(AList0))]
    //[TestFixture(typeof(AList1))]
    //[TestFixture(typeof(AList2))]
    //[TestFixture(typeof(AListR))]
    //[TestFixture(typeof(LList1))]
    //[TestFixture(typeof(LList2))]
/*
    public class UnitTest_AListR //<T> where T : IList, new()
    {
        AListR lst = new AListR();
        [SetUp]
        public void SetUp()
        {
            lst.Clear();
        }

        [Test]
        [Category("init")]
        [TestCase(new int[] { 6, 2, 9, 4, 1, 6, 7 }, new int[] { 6, 2, 9, 4, 1, 6, 7 }, TestName = "init{ 6, 2, 9, 4, 1, 6, 7 }")]
        [TestCase(new int[] { 13, 66 }, new int[] { 13, 66 }, TestName = "init{ 13, 66 }")]
        [TestCase(new int[] { 1 }, new int[] { 1 }, TestName = "init{ 1 }")]
        [TestCase(new int[] { 0, 0, 0 }, new int[] { 0, 0, 0 }, TestName = "init{ 0, 0, 0 }")]
        [TestCase(null, new int[] { }, TestName = "initnull")]
        [TestCase(new int[] { }, new int[] { }, TestName = "init[0]")]
        public void TestMethod_init(int[] a, int[] b)
        {
            lst.Init(a);
            Assert.AreEqual(b, lst.ToArray());
        }

        [Test]
        [Category("clear")]
        [TestCase(new int[] { 6, 2, 9, 4, 1, 6, 7 }, new int[] { }, TestName = "clear{ 6, 2, 9, 4, 1, 6, 7 }")]
        [TestCase(new int[] { 13, 66 }, new int[] { }, TestName = "clear{ 13, 66 }")]
        [TestCase(new int[] { 1 }, new int[] { }, TestName = "clear{ 1 }")]
        [TestCase(new int[] { 0, 0, 0 }, new int[] { }, TestName = "clear{ 0, 0, 0 }")]
        [TestCase(null, new int[] { }, TestName = "clearnull")]
        [TestCase(new int[] { }, new int[] { }, TestName = "clear[0]")]
        public void TestMethod_clear(int[] a, int[] b)
        {
            lst.Init(a);
            lst.AddStart(8);
            lst.Clear();
            Assert.AreEqual(b, lst.ToArray());
        }

        [Test]
        [Category("ToString")]
        [TestCase(new int[] { 6, 2, 9, 4, 1, 6, 7 }, "8, 6, 2, 9, 4, 1, 6, 7", TestName = "ToString{ 6, 2, 9, 4, 1, 6, 7 }")]
        [TestCase(new int[] { 13, 66 }, "8, 13, 66", TestName = "ToString{ 13, 66 }")]
        [TestCase(new int[] { 1 }, "8, 1", TestName = "ToString{ 1 }")]
        [TestCase(new int[] { 0, 0, 0 }, "8, 0, 0, 0", TestName = "ToString{ 0, 0, 0 }")]
        [TestCase(null, "8", TestName = "ToString_null")]
        [TestCase(new int[] { }, "8", TestName = "ToString[0]")]
        public void TestMethod_ToString(int[] a, string b)
        {
            lst.Init(a);
            lst.AddStart(8);
            Assert.AreEqual(b, lst.ToString());
        }

        [Test]
        [Category("AddEnd")]
        [TestCase(new int[] { 6, 2, 9, 4, 1, 6, 7 }, 1, new int[] { 8, 6, 2, 9, 4, 1, 6, 7, 1 }, TestName = "AddEnd{ 6, 2, 9, 4, 1, 6, 7 }")]
        [TestCase(new int[] { 13, 66 }, 5, new int[] { 8, 13, 66, 5 }, TestName = "AddEnd{ 13, 66 }")]
        [TestCase(new int[] { 1 }, 88, new int[] { 8, 1, 88 }, TestName = "AddEnd{ 1 }")]
        [TestCase(new int[] { 0, 0, 0 }, 0, new int[] { 8, 0, 0, 0, 0 }, TestName = "AddEnd{ 0, 0, 0 }")]
        [TestCase(null, 5, new int[] { 8, 5 }, TestName = "AddEndnull")]
        [TestCase(new int[] { }, -8, new int[] { 8, -8 }, TestName = "AddEnd[0]")]
        public void TestMethod_AddEnd(int[] a, int b, int[] c)
        {
            lst.Init(a);
            lst.AddStart(8);
            lst.AddEnd(b);
            Assert.AreEqual(c, lst.ToArray());
        }

        [Test]
        [Category("AddStart")]
        [TestCase(new int[] { 6, 2, 9, 4, 1, 6, 7 }, 1, new int[] { 1, 8, 6, 2, 9, 4, 1, 6, 7 }, TestName = "AddStart{ 6, 2, 9, 4, 1, 6, 7 }")]
        [TestCase(new int[] { 13, 66 }, 5, new int[] { 5, 8, 13, 66 }, TestName = "AddStart{ 13, 66 }")]
        [TestCase(new int[] { 1 }, 88, new int[] { 88, 8, 1 }, TestName = "AddStart{ 1 }")]
        [TestCase(new int[] { 0, 0, 0 }, 0, new int[] { 0, 8, 0, 0, 0 }, TestName = "AddStart{ 0, 0, 0 }")]
        [TestCase(null, 5, new int[] { 5, 8 }, TestName = "AddStartnull")]
        [TestCase(new int[] { }, -8, new int[] { -8, 8 }, TestName = "AddStart[0]")]
        public void TestMethod_AddStart(int[] a, int b, int[] c)
        {
            lst.Init(a);
            lst.AddStart(8);
            lst.AddStart(b);
            Assert.AreEqual(c, lst.ToArray());
        }

        [Test]
        [Category("AddPos")]
        [TestCase(new int[] { 6, 2, 9, 4, 1, 6, 7 }, 3, 1, new int[] { 6, 2, 9, 1, 4, 1, 6, 7 }, TestName = "AddPos{ 6, 2, 9, 4, 1, 6, 7 }")]
        [TestCase(new int[] { 13, 66 }, 1, 5, new int[] { 13, 5, 66 }, TestName = "AddPos{ 13, 66 }")]
        [TestCase(new int[] { 1 }, 0, 88, new int[] { 88, 1 }, TestName = "AddPos{ 1 }")]
        [TestCase(new int[] { 0, 0, 0 }, 2, 10, new int[] { 0, 0, 10, 0 }, TestName = "AddPos{ 0, 0, 0 }")]
        [TestCase(null, 0, 5, new int[] { 5 }, TestName = "AddPosnull")]
        [TestCase(new int[] { }, 0, -8, new int[] { -8 }, TestName = "AddPos[0]")]
        public void TestMethod_AddPos(int[] a, int b, int c, int[] d)
        {
            lst.Init(a);
            lst.AddPos(b, c);
            Assert.AreEqual(d, lst.ToArray());
        }
        [Test]
        [Category("AddPos")]
        [TestCase(new int[] { 6, 2, 9, 4, 1, 6, 7 }, 3, 1, new int[] { 1, 2, 3, 1, 6, 2, 9, 4, 1, 6, 7 }, TestName = "AddPosM{ 6, 2, 9, 4, 1, 6, 7 }")]
        [TestCase(new int[] { 13, 66 }, 1, 5, new int[] { 1, 5, 2, 3, 13, 66 }, TestName = "AddPosM{ 13, 66 }")]
        [TestCase(new int[] { 1 }, 0, 88, new int[] { 88, 1, 2, 3, 1 }, TestName = "AddPosM{ 1 }")]
        [TestCase(new int[] { 0, 0, 0 }, 2, 10, new int[] { 1, 2, 10, 3, 0, 0, 0 }, TestName = "AddPosM{ 0, 0, 0 }")]
        [TestCase(null, 0, 5, new int[] { 5, 1, 2, 3 }, TestName = "AddPosMnull")]
        [TestCase(new int[] { }, 0, -8, new int[] { -8, 1, 2, 3 }, TestName = "AddPosM[0]")]
        public void TestMethod_AddPosM(int[] a, int b, int c, int[] d)
        {
            lst.Init(a);
            lst.AddStart(3);
            lst.AddStart(2);
            lst.AddStart(1);
            lst.AddPos(b, c);
            Assert.AreEqual(d, lst.ToArray());
        }
        [Test]
        [Category("AddPos")]
        [TestCase(new int[] { 6, 2, 9, 4, 1, 6, 7 }, 15, 6, TestName = "AddPos_Exception{ 6, 2, 9, 4, 1, 6, 7 }")]
        [TestCase(new int[] { 13, 66 }, -2, 4, TestName = "AddPos_Exception{ 13, 66 }")]
        public void TestMethod_AddPosexc_01(int[] a, int b, int c)
        {
            lst.Init(a);
            Assert.Throws(typeof(ArgumentOutOfRangeException), () => lst.AddPos(b, c));
        }

        [Test]
        [Category("DelStart")]
        [TestCase(new int[] { 6, 2, 9, 4, 1, 6, 7 }, new int[] { 2, 9, 4, 1, 6, 7 }, 6, TestName = "{ 6, 2, 9, 4, 1, 6, 7 }")]
        [TestCase(new int[] { 13, 66 }, new int[] { 66 }, 13, TestName = "DelStart{ 13, 66 }")]
        [TestCase(new int[] { 1 }, new int[] { }, 1, TestName = "DelStart{ 1 }")]
        [TestCase(new int[] { 0, 0, 0 }, new int[] { 0, 0 }, 0, TestName = "DelStart{ 0, 0, 0 }")]
        public void TestMethod_DelStart(int[] a, int[] b, int c)
        {
            lst.Init(a);
            int act = lst.DelStart();
            Assert.AreEqual(b, lst.ToArray());
            Assert.AreEqual(c, act);
        }
        [Test]
        [Category("DelStart")]
        [TestCase(new int[] { 6, 2, 9, 4, 1, 6, 7 }, new int[] { 6, 9, 4, 1, 6, 7 }, 6, TestName = "{ 6, 2, 9, 4, 1, 6, 7 }1")]
        [TestCase(new int[] { 13, 66 }, new int[] { 66 }, 13, TestName = "DelStart{ 13, 66 }1")]
        [TestCase(new int[] { 1 }, new int[] { }, 1, TestName = "DelStart{ 1 }1")]
        [TestCase(new int[] { 0, 0, 0 }, new int[] { 0, 0 }, 0, TestName = "DelStart{ 0, 0, 0 }1")]
        public void TestMethod_DelStart1(int[] a, int[] b, int c)
        {
            lst.Init(a);
            lst.AddStart(1);
            int act = lst.DelStart();
            Assert.AreEqual(a, lst.ToArray());
            Assert.AreEqual(1, act);
        }
        [Test]
        [Category("DelStart")]
        [TestCase(new int[] { 6, 2, 9, 4, 1, 6, 7 }, new int[] { 2, 6, 2, 9, 4, 1, 6, 7 }, 6, TestName = "{ 6, 2, 9, 4, 1, 6, 7 }2")]
        [TestCase(new int[] { 13, 66 }, new int[] { 2, 13, 66 }, 13, TestName = "DelStart{ 13, 66 }2")]
        [TestCase(new int[] { 1 }, new int[] { 2, 1 }, 1, TestName = "DelStart{ 1 }2")]
        [TestCase(new int[] { 0, 0, 0 }, new int[] { 2, 0, 0, 0 }, 0, TestName = "DelStart{ 0, 0, 0 }2")]
        public void TestMethod_DelStart2(int[] a, int[] b, int c)
        {
            lst.Init(a);
            lst.AddStart(2);
            lst.AddStart(1);
            int act = lst.DelStart();
            Assert.AreEqual(b, lst.ToArray());
            Assert.AreEqual(1, act);
        }
        [Test]
        [Category("DelStart")]
        [TestCase(new int[] { }, TestName = "DelStart_Exception[0]")]
        [TestCase(null, TestName = "DelStart_Exception_null")]
        public void TestMethod_DelStartexc_01(int[] a)
        {
            lst.Init(a);
            Assert.Throws(typeof(IndexOutOfRangeException), () => lst.DelStart());
        }

        [Test]
        [Category("DelEnd")]
        [TestCase(new int[] { 6, 2, 9, 4, 1, 6, 7 }, new int[] { 6, 2, 9, 4, 1, 6 }, 7, TestName = "DelEnd{ 6, 2, 9, 4, 1, 6, 7 }")]
        [TestCase(new int[] { 13, 66 }, new int[] { 13 }, 66, TestName = "DelEnd{ 13, 66 }")]
        [TestCase(new int[] { 1 }, new int[] { }, 1, TestName = "DelEnd{ 1 }")]
        [TestCase(new int[] { 0, 0, 0 }, new int[] { 0, 0 }, 0, TestName = "DelEnd{ 0, 0, 0 }")]
        public void TestMethod_DelEnd(int[] a, int[] b, int c)
        {
            lst.Init(a);
            int act = lst.DelEnd();
            Assert.AreEqual(b, lst.ToArray());
            Assert.AreEqual(c, act);
        }
        [Test]
        [Category("DelEnd")]
        [TestCase(new int[] { }, TestName = "DelEnd_Exception[0]")]
        [TestCase(null, TestName = "DelEnd_Exception_null")]
        public void TestMethod_DelEndexc_01(int[] a)
        {
            lst.Init(a);
            Assert.Throws(typeof(IndexOutOfRangeException), () => lst.DelEnd());
        }

        [Test]
        [Category("DelPos")]
        [TestCase(new int[] { 6, 2, 9, 4, 1, 6, 7 }, 4, new int[] { 6, 2, 9, 4, 6, 7 }, 1, TestName = "DelPos{ 6, 2, 9, 4, 1, 6, 7 }")]
        [TestCase(new int[] { 13, 66 }, 1, new int[] { 13 }, 66, TestName = "DelPos{ 13, 66 }")]
        [TestCase(new int[] { 1 }, 0, new int[] { }, 1, TestName = "DelPos{ 1 }")]
        [TestCase(new int[] { 0, 0, 0 }, 2, new int[] { 0, 0 }, 0, TestName = "DelPos{ 0, 0, 0 }")]
        public void TestMethod_DelPos(int[] a, int b, int[] c, int d)
        {
            lst.Init(a);
            int act = lst.DelPos(b);
            Assert.AreEqual(c, lst.ToArray());
            Assert.AreEqual(d, act);
        }

        [Test]
        [Category("DelPos")]
        [TestCase(new int[] { 6, 2, 9, 4, 1, 6, 7 }, 4, new int[] { 1, 2, 6, 2, 9, 4, 1, 6, 7 }, 1, TestName = "DelPos1{ 6, 2, 9, 4, 1, 6, 7 }")]
        [TestCase(new int[] { 13, 66 }, 1, new int[] { 1, 2, 13, 66 }, 66, TestName = "DelPos1{ 13, 66 }")]
        [TestCase(new int[] { 1 }, 0, new int[] { 1, 2, 1 }, 1, TestName = "DelPos1{ 1 }")]
        [TestCase(new int[] { 0, 0, 0 }, 2, new int[] { 1, 2, 0, 0, 0 }, 0, TestName = "DelPos1{ 0, 0, 0 }")]
        public void TestMethod_DelPos1(int[] a, int b, int[] c, int d)
        {
            lst.Init(a);
            lst.AddStart(3);
            lst.AddStart(2);
            lst.AddStart(1);
            int act = lst.DelPos(2);
            Assert.AreEqual(c, lst.ToArray());
            Assert.AreEqual(3, act);
        }

        [Test]
        [Category("DelPos")]
        [TestCase(new int[] { 6, 2, 9, 4, 1, 6, 7 }, 4, new int[] { 1, 3, 6, 2, 9, 4, 1, 6, 7 }, 1, TestName = "DelPos2{ 6, 2, 9, 4, 1, 6, 7 }")]
        [TestCase(new int[] { 13, 66 }, 1, new int[] { 1, 3, 13, 66 }, 66, TestName = "DelPos2{ 13, 66 }")]
        [TestCase(new int[] { 1 }, 0, new int[] { 1, 3, 1 }, 1, TestName = "DelPos2{ 1 }")]
        [TestCase(new int[] { 0, 0, 0 }, 2, new int[] { 1, 3, 0, 0, 0 }, 0, TestName = "DelPos2{ 0, 0, 0 }")]
        public void TestMethod_DelPos2(int[] a, int b, int[] c, int d)
        {
            lst.Init(a);
            lst.AddStart(3);
            lst.AddStart(2);
            lst.AddStart(1);
            int act = lst.DelPos(1);
            Assert.AreEqual(c, lst.ToArray());
            Assert.AreEqual(2, act);
        }
        [Test]
        [Category("DelPos")]
        [TestCase(new int[] { }, 0, TestName = "DelPos_Exception[0]")]
        [TestCase(null, 5, TestName = "DelPos_Exception_null")]
        public void TestMethod_DelPosexc_01(int[] a, int b)
        {
            lst.Init(a);
            Assert.Throws(typeof(IndexOutOfRangeException), () => lst.DelPos(b));
        }
        [Test]
        [Category("DelPos")]
        [TestCase(new int[] { 6, 2, 9, 4, 1, 6, 7 }, 15, TestName = "DelPos_Exception{ 6, 2, 9, 4, 1, 6, 7 }")]
        [TestCase(new int[] { 13, 66 }, -2, TestName = "DelPos_Exception{ 13, 66 }")]
        public void TestMethod_DelPosexc_02(int[] a, int b)
        {
            lst.Init(a);
            Assert.Throws(typeof(ArgumentOutOfRangeException), () => lst.DelPos(b));
        }

        [Test]
        [Category("Min")]
        [TestCase(new int[] { 6, 2, 9, 4, 1, 6, 7 }, 1, TestName = "Min{ 6, 2, 9, 4, 1, 6, 7 }")]
        [TestCase(new int[] { 13, 66 }, 13, TestName = "Min{ 13, 66 }")]
        [TestCase(new int[] { 1 }, 1, TestName = "Min{ 1 }")]
        [TestCase(new int[] { 0, 0, 0 }, 0, TestName = "Min{ 0, 0, 0 }")]
        public void TestMethod_Min(int[] a, int b)
        {
            lst.Init(a);
            Assert.AreEqual(b, lst.Min());
        }
        [Test]
        [Category("Min")]
        [TestCase(new int[] { 6, 2, 9, 4, 1, 6, 7 }, 1, TestName = "Min1{ 6, 2, 9, 4, 1, 6, 7 }")]
        [TestCase(new int[] { 13, 66 }, 13, TestName = "Min1{ 13, 66 }")]
        [TestCase(new int[] { 1 }, 1, TestName = "Min1{ 1 }")]
        [TestCase(new int[] { 0, 0, 0 }, 0, TestName = "Min1{ 0, 0, 0 }")]
        public void TestMethod_Min1(int[] a, int b)
        {
            lst.Init(a);
            lst.AddStart(22);
            lst.AddStart(88);
            lst.AddStart(52);
            Assert.AreEqual(b, lst.Min());
        }
        [Test]
        [Category("Min")]
        [TestCase(new int[] { 6, 2, 9, 4, 1, 6, 7 }, 1, TestName = "Min2{ 6, 2, 9, 4, 1, 6, 7 }")]
        [TestCase(new int[] { 13, 66 }, 13, TestName = "Min2{ 13, 66 }")]
        [TestCase(new int[] { 1 }, 1, TestName = "Min2{ 1 }")]
        [TestCase(new int[] { 0, 0, 0 }, 0, TestName = "Min2{ 0, 0, 0 }")]
        public void TestMethod_Min2(int[] a, int b)
        {
            lst.Init(a);
            lst.AddStart(-2200);
            lst.AddStart(-88);
            lst.AddStart(-5);
            Assert.AreEqual(-2200, lst.Min());
        }
        [Test]
        [Category("Min")]
        [TestCase(new int[] { }, TestName = "Min_Exception[0]")]
        [TestCase(null, TestName = "Min_Exception_null")]
        public void TestMethod_Minexc_01(int[] a)
        {
            lst.Init(a);
            Assert.Throws(typeof(IndexOutOfRangeException), () => lst.Min());
        }

        [Test]
        [Category("Max")]
        [TestCase(new int[] { 6, 2, 9, 4, 1, 6, 7 }, 9, TestName = "Max{ 6, 2, 9, 4, 1, 6, 7 }")]
        [TestCase(new int[] { 13, 66 }, 66, TestName = "Max{ 13, 66 }")]
        [TestCase(new int[] { 1 }, 1, TestName = "Max{ 1 }")]
        [TestCase(new int[] { 0, 0, 0 }, 0, TestName = "Max{ 0, 0, 0 }")]
        public void TestMethod_Max(int[] a, int b)
        {
            lst.Init(a);
            Assert.AreEqual(b, lst.Max());
        }
        [Test]
        [Category("Max")]
        [TestCase(new int[] { 96, 2, 9, 4, 1, 6, 7 }, 96, TestName = "Max1{ 6, 2, 9, 4, 1, 6, 7 }")]
        [TestCase(new int[] { 13, 66 }, 66, TestName = "Max1{ 13, 66 }")]
        [TestCase(new int[] { 1 }, 1, TestName = "Max1{ 1 }")]
        [TestCase(new int[] { 0, 0, 0 }, 0, TestName = "Max1{ 0, 0, 0 }")]
        public void TestMethod_Max1(int[] a, int b)
        {
            lst.Init(a);
            lst.AddStart(-22);
            lst.AddStart(-88);
            lst.AddStart(-52);
            Assert.AreEqual(b, lst.Max());
        }
        [Test]
        [Category("Max")]
        [TestCase(new int[] { 6, 2, 9, 4, 1, 6, 7 }, 9, TestName = "Max2{ 6, 2, 9, 4, 1, 6, 7 }")]
        [TestCase(new int[] { 13, 66 }, 66, TestName = "Max2{ 13, 66 }")]
        [TestCase(new int[] { 1 }, 1, TestName = "Max2{ 1 }")]
        [TestCase(new int[] { 0, 0, 0 }, 0, TestName = "Max2{ 0, 0, 0 }")]
        public void TestMethod_Max2(int[] a, int b)
        {
            lst.Init(a);
            lst.AddStart(2200);
            lst.AddStart(-88);
            lst.AddStart(-5);
            Assert.AreEqual(2200, lst.Max());
        }
        [Test]
        [Category("Max")]
        [TestCase(new int[] { }, TestName = "Max_Exception[0]")]
        [TestCase(null, TestName = "Max_Exception_null")]
        public void TestMethod_Maxexc_01(int[] a)
        {
            lst.Init(a);
            Assert.Throws(typeof(IndexOutOfRangeException), () => lst.Max());
        }
        [Test]
        [Category("MinInd")]
        [TestCase(new int[] { 6, 2, 9, 4, 1, 6, 7 }, 4, TestName = "MinInd{ 6, 2, 9, 4, 1, 6, 7 }")]
        [TestCase(new int[] { 13, 66 }, 0, TestName = "MinInd{ 13, 66 }")]
        [TestCase(new int[] { 1 }, 0, TestName = "MinInd{ 1 }")]
        [TestCase(new int[] { 0, 0, 0 }, 0, TestName = "MinInd{ 0, 0, 0 }")]
        public void TestMethod_MinInd(int[] a, int b)
        {
            lst.Init(a);
            Assert.AreEqual(b, lst.MinInd());
        }
        [Test]
        [Category("MinInd")]
        [TestCase(new int[] { 6, 2, 9, 4, 1, 6, 7 }, 4, TestName = "MinInd1{ 6, 2, 9, 4, 1, 6, 7 }")]
        [TestCase(new int[] { 13, 66 }, 0, TestName = "MinInd1{ 13, 66 }")]
        [TestCase(new int[] { 1 }, 0, TestName = "MinInd1{ 1 }")]
        [TestCase(new int[] { 0, 0, 0 }, 0, TestName = "MinInd1{ 0, 0, 0 }")]
        public void TestMethod_MinInd1(int[] a, int b)
        {
            lst.Init(a);
            lst.AddStart(22);
            lst.AddStart(88);
            lst.AddStart(52);
            Assert.AreEqual(b+3, lst.MinInd());
        }
        [Test]
        [Category("MinInd")]
        [TestCase(new int[] { 6, 2, 9, 4, 1, 6, 7 }, 4, TestName = "MinInd2{ 6, 2, 9, 4, 1, 6, 7 }")]
        [TestCase(new int[] { 13, 66 }, 0, TestName = "MinInd2{ 13, 66 }")]
        [TestCase(new int[] { 1 }, 0, TestName = "MinInd2{ 1 }")]
        [TestCase(new int[] { 0, 0, 0 }, 0, TestName = "MinInd2{ 0, 0, 0 }")]
        public void TestMethod_MinInd2(int[] a, int b)
        {
            lst.Init(a);
            lst.AddStart(-2200);
            lst.AddStart(-88);
            lst.AddStart(-5);
            Assert.AreEqual(2, lst.MinInd());
        }
        [Test]
        [Category("MinInd")]
        [TestCase(new int[] { }, TestName = "MinInd_Exception[0]")]
        [TestCase(null, TestName = "MinInd_Exception_null")]
        public void TestMethod_MinIndexc_01(int[] a)
        {
            lst.Init(a);
            Assert.Throws(typeof(IndexOutOfRangeException), () => lst.MinInd());
        }
        [Test]
        [Category("MaxInd")]
        [TestCase(new int[] { 6, 2, 9, 4, 1, 6, 7 }, 2, TestName = "MaxInd{ 6, 2, 9, 4, 1, 6, 7 }")]
        [TestCase(new int[] { 13, 66 }, 1, TestName = "MaxInd{ 13, 66 }")]
        [TestCase(new int[] { 1 }, 0, TestName = "MaxInd{ 1 }")]
        [TestCase(new int[] { 0, 0, 0 }, 0, TestName = "MaxInd{ 0, 0, 0 }")]
        public void TestMethod_MaxInd(int[] a, int b)
        {
            lst.Init(a);
            Assert.AreEqual(b, lst.MaxInd());
        }
        [Test]
        [Category("MaxInd")]
        [TestCase(new int[] { 6, 2, 9, 4, 1, 6, 7 }, 2, TestName = "MaxInd1{ 6, 2, 9, 4, 1, 6, 7 }")]
        [TestCase(new int[] { 13, 66 }, 1, TestName = "MaxInd1{ 13, 66 }")]
        [TestCase(new int[] { 1 }, 0, TestName = "MaxInd1{ 1 }")]
        [TestCase(new int[] { 0, 0, 0 }, 0, TestName = "MaxInd1{ 0, 0, 0 }")]
        public void TestMethod_MaxInd1(int[] a, int b)
        {
            lst.Init(a);
            lst.AddStart(-22);
            lst.AddStart(-88);
            lst.AddStart(-52);
            Assert.AreEqual(b+3, lst.MaxInd());
        }
        [Test]
        [Category("MaxInd")]
        [TestCase(new int[] { 6, 2, 9, 4, 1, 6, 7 }, 2, TestName = "MaxInd2{ 6, 2, 9, 4, 1, 6, 7 }")]
        [TestCase(new int[] { 13, 66 }, 1, TestName = "MaxInd2{ 13, 66 }")]
        [TestCase(new int[] { 1 }, 0, TestName = "MaxInd2{ 1 }")]
        [TestCase(new int[] { 0, 0, 0 }, 0, TestName = "MaxInd2{ 0, 0, 0 }")]
        public void TestMethod_MaxInd2(int[] a, int b)
        {
            lst.Init(a);
            lst.AddStart(2200);
            lst.AddStart(-88);
            lst.AddStart(-5);
            Assert.AreEqual(2, lst.MaxInd());
        }
        [Test]
        [Category("MaxInd")]
        [TestCase(new int[] { }, TestName = "MaxInd_Exception[0]")]
        [TestCase(null, TestName = "MaxInd_Exception_null")]
        public void TestMethod_MaxIndexc_01(int[] a)
        {
            lst.Init(a);
            Assert.Throws(typeof(IndexOutOfRangeException), () => lst.MaxInd());
        }

        [Test]
        [Category("Set")]
        [TestCase(new int[] { 6, 2, 9, 4, 1, 6, 7 }, 3, 1, new int[] { 6, 2, 9, 1, 1, 6, 7 }, TestName = "Set{ 6, 2, 9, 4, 1, 6, 7 }")]
        [TestCase(new int[] { 13, 66 }, 1, 8, new int[] { 13, 8 }, TestName = "Set{ 13, 66 }")]
        [TestCase(new int[] { 1 }, 0, 88, new int[] { 88 }, TestName = "Set{ 1 }")]
        [TestCase(new int[] { 0, 0, 0 }, 2, 10, new int[] { 0, 0, 10 }, TestName = "Set{ 0, 0, 0 }")]
        public void TestMethod_Set(int[] a, int b, int c, int[] d)
        {
            lst.Init(a);
            lst.Set(b, c);
            Assert.AreEqual(d, lst.ToArray());
        }
        [Test]
        [Category("Set")]
        [TestCase(new int[] { 6, 2, 9, 4, 1, 6, 7 }, 6, 66, new int[] { 1, 2, 3, 6, 2, 9, 66, 1, 6, 7 }, TestName = "Set1{ 6, 2, 9, 4, 1, 6, 7 }")]
        [TestCase(new int[] { 13, 66 }, 1, 8, new int[] { 1, 8, 3, 13, 66 }, TestName = "Set1{ 13, 66 }")]
        [TestCase(new int[] { 1 }, 0, 88, new int[] { 88, 2, 3, 1 }, TestName = "Set1{ 1 }")]
        [TestCase(new int[] { 0, 0, 0 }, 3, 10, new int[] { 1, 2, 3, 10, 0, 0 }, TestName = "Set1{ 0, 0, 0 }")]
        public void TestMethod_Set1(int[] a, int b, int c, int[] d)
        {
            lst.Init(a);
            lst.AddStart(3);
            lst.AddStart(2);
            lst.AddStart(1);
            lst.Set(b, c);
            Assert.AreEqual(d, lst.ToArray());
        }
        
        [Test]
        [Category("Set")]
        [TestCase(new int[] { 6, 2, 9, 4, 1, 6, 7 }, 15, 4, TestName = "Set_Exception{ 6, 2, 9, 4, 1, 6, 7 }")]
        [TestCase(new int[] { 13, 66 }, -2, 7, TestName = "Set_Exception{ 13, 66 }")]
        [TestCase(new int[] { }, 4, 0, TestName = "Set_Exception[0]")]
        [TestCase(null, 0, 3, TestName = "Set_Exception_null")]
        public void TestMethod_Setexc_01(int[] a, int b, int c)
        {
            lst.Init(a);
            Assert.Throws(typeof(ArgumentOutOfRangeException), () => lst.Set(b, c));
        }

        [Test]
        [Category("Get")]
        [TestCase(new int[] { 6, 2, 9, 4, 1, 6, 7 }, 3, 4, TestName = "Get{ 6, 2, 9, 4, 1, 6, 7 }")]
        [TestCase(new int[] { 13, 66 }, 1, 66, TestName = "Get{ 13, 66 }")]
        [TestCase(new int[] { 1 }, 0, 1, TestName = "Get{ 1 }")]
        [TestCase(new int[] { 0, 0, 0 }, 2, 0, TestName = "Get{ 0, 0, 0 }")]
        public void TestMethod_Get(int[] a, int b, int c)
        {
            lst.Init(a);
            Assert.AreEqual(c, lst.Get(b));
        }
        [Test]
        [Category("Get")]
        [TestCase(new int[] { 6, 2, 9, 4, 1, 6, 7 }, 3, 6, TestName = "Get1{ 6, 2, 9, 4, 1, 6, 7 }")]
        [TestCase(new int[] { 13, 66 }, 2, 3, TestName = "Get1{ 13, 66 }")]
        [TestCase(new int[] { 1 }, 1, 2, TestName = "Get1{ 1 }")]
        [TestCase(new int[] { 0, 0, 0 }, 0, 1, TestName = "Get1{ 0, 0, 0 }")]
        public void TestMethod_Get1(int[] a, int b, int c)
        {
            lst.Init(a);
            lst.AddStart(3);
            lst.AddStart(2);
            lst.AddStart(1);
            Assert.AreEqual(c, lst.Get(b));
        }
        [Test]
        [Category("Get")]
        [TestCase(new int[] { 6, 2, 9, 4, 1, 6, 7 }, 15, TestName = "Get_Exception{ 6, 2, 9, 4, 1, 6, 7 }")]
        [TestCase(new int[] { 13, 66 }, -2, TestName = "Get_Exception{ 13, 66 }")]
        [TestCase(new int[] { }, 4, TestName = "Get_Exception[0]")]
        [TestCase(null, 0, TestName = "Get_Exception_null")]
        public void TestMethod_Getexc_01(int[] a, int b)
        {
            lst.Init(a);
            Assert.Throws(typeof(ArgumentOutOfRangeException), () => lst.Get(b));
        }

        
        [Test]
        [Category("Reverse")]
        [TestCase(new int[] { 6, 2, 9, 4, 1, 6, 7, 3 }, new int[] { 3, 7, 6, 1, 4, 9, 2, 6 }, TestName = "Reverse{ 6, 2, 9, 4, 1, 6, 7, 3 }")]
        [TestCase(new int[] { 6, 2, 9, 4, 1, 6, 7 }, new int[] { 7, 6, 1, 4, 9, 2, 6 }, TestName = "Reverse{ 6, 2, 9, 4, 1, 6, 7 }")]
        [TestCase(new int[] { 13, 66 }, new int[] { 66, 13 }, TestName = "Reverse{ 13, 66 }")]
        [TestCase(new int[] { 1 }, new int[] { 1 }, TestName = "Reverse{ 1 }")]
        [TestCase(new int[] { 0, 0, 0 }, new int[] { 0, 0, 0 }, TestName = "Reverse{ 0, 0, 0 }")]
        [TestCase(null, new int[] { }, TestName = "Reversenull")]
        [TestCase(new int[] { }, new int[] { }, TestName = "Reverse[0]")]
        public void TestMethod_Reverse(int[] a, int[] c)
        {
            lst.Init(a);
            lst.Reverse();
            Assert.AreEqual(c, lst.ToArray());
        }
        [Test]
        [Category("Reverse")]
        [TestCase(new int[] { 6, 2, 9, 4, 1, 6, 7, 3 }, new int[] { 3, 7, 6, 1, 4, 9, 2, 6, 3, 2, 1 }, TestName = "Reverse1{ 6, 2, 9, 4, 1, 6, 7, 3 }")]
        [TestCase(new int[] { 6, 2, 9, 4, 1, 6, 7 }, new int[] { 7, 6, 1, 4, 9, 2, 6, 3, 2, 1 }, TestName = "Reverse1{ 6, 2, 9, 4, 1, 6, 7 }")]
        [TestCase(new int[] { 13, 66 }, new int[] { 66, 13, 3, 2, 1 }, TestName = "Reverse1{ 13, 66 }")]
        [TestCase(new int[] { 1 }, new int[] { 1, 3, 2, 1 }, TestName = "Reverse1{ 1 }")]
        [TestCase(new int[] { 0, 0, 0 }, new int[] { 0, 0, 0, 3, 2, 1 }, TestName = "Reverse1{ 0, 0, 0 }")]
        [TestCase(null, new int[] { 3, 2, 1 }, TestName = "Reverse1null")]
        [TestCase(new int[] { }, new int[] { 3, 2, 1 }, TestName = "Reverse1[0]")]
        public void TestMethod_Reverse1(int[] a, int[] c)
        {
            lst.Init(a);
            lst.AddStart(3);
            lst.AddStart(2);
            lst.AddStart(1);
            lst.Reverse();
            Assert.AreEqual(c, lst.ToArray());
        }
        [Test]
        [Category("HalfReverse")]
        [TestCase(new int[] { 6, 2, 9, 4, 1, 6, 7, 3 }, new int[] { 1, 6, 7, 3, 6, 2, 9, 4 }, TestName = "HalfReverse{ 6, 2, 9, 4, 1, 6, 7, 3 }")]
        [TestCase(new int[] { 6, 2, 9, 4, 1, 6, 7 }, new int[] { 1, 6, 7, 4, 6, 2, 9 }, TestName = "HalfReverse{ 6, 2, 9, 4, 1, 6, 7 }")]
        [TestCase(new int[] { 13, 66 }, new int[] { 66, 13 }, TestName = "HalfReverse{ 13, 66 }")]
        [TestCase(new int[] { 1 }, new int[] { 1 }, TestName = "HalfReverse{ 1 }")]
        [TestCase(new int[] { 0, 0, 0 }, new int[] { 0, 0, 0 }, TestName = "HalfReverse{ 0, 0, 0 }")]
        [TestCase(null, new int[] { }, TestName = "HalfReversenull")]
        [TestCase(new int[] { }, new int[] { }, TestName = "HalfReverse[0]")]
        public void TestMethod_HalfReverse(int[] a, int[] c)
        {
            lst.Init(a);
            lst.HalfReverse();
            Assert.AreEqual(c, lst.ToArray());
        }
        [Test]
        [Category("HalfReverse")]            
        [TestCase(new int[] { 6, 2, 9, 4, 1, 6, 7, 3 }, new int[] { 4, 1, 6, 7, 3, 9, 1, 2, 3, 6, 2 }, TestName = "HalfReverse1{ 6, 2, 9, 4, 1, 6, 7, 3 }")]
        [TestCase(new int[] { 6, 2, 9, 4, 1, 6, 7 }, new int[] { 9, 4, 1, 6, 7, 1, 2, 3, 6, 2 }, TestName = "HalfReverse1{ 6, 2, 9, 4, 1, 6, 7 }")]
        [TestCase(new int[] { 13, 66 }, new int[] { 13, 66, 3, 1, 2 }, TestName = "HalfReverse1{ 13, 66 }")]
        [TestCase(new int[] { 5 }, new int[] { 3, 5, 1, 2 }, TestName = "HalfReverse1{ 1 }")]
        [TestCase(new int[] { 0, 0, 0 }, new int[] { 0, 0, 0, 1, 2, 3 }, TestName = "HalfReverse1{ 0, 0, 0 }")]
        [TestCase(null, new int[] { 3, 2, 1 }, TestName = "HalfReverse1null")]
        [TestCase(new int[] { }, new int[] { 3, 2, 1 }, TestName = "HalfReverse1[0]")]
        public void TestMethod_HalfReverse1(int[] a, int[] c)
        {
            lst.Init(a);
            lst.AddStart(3);
            lst.AddStart(2);
            lst.AddStart(1);
            lst.HalfReverse();
            Assert.AreEqual(c, lst.ToArray());
        }
        [Test]
        [Category("Sort")]
        [TestCase(new int[] { 6, 2, 9, 4, 1, 6, 7, 3 }, new int[] { 1, 2, 3, 4, 6, 6, 7, 9 }, TestName = "Sort{ 6, 2, 9, 4, 1, 6, 7, 3 }")]
        [TestCase(new int[] { 6, 2, 9, 4, 1, 6, 7 }, new int[] { 1, 2, 4, 6, 6, 7, 9 }, TestName = "Sort{ 6, 2, 9, 4, 1, 6, 7 }")]
        [TestCase(new int[] { 13, 66 }, new int[] { 13, 66 }, TestName = "Sort{ 13, 66 }")]
        [TestCase(new int[] { 1 }, new int[] { 1 }, TestName = "Sort{ 1 }")]
        [TestCase(new int[] { 0, 0, 0 }, new int[] { 0, 0, 0 }, TestName = "Sort{ 0, 0, 0 }")]
        [TestCase(null, new int[] { }, TestName = "Sortnull")]
        [TestCase(new int[] { }, new int[] { }, TestName = "Sort[0]")]
        public void TestMethod_Sort(int[] a, int[] c)
        {
            lst.Init(a);
            lst.Sort();
            Assert.AreEqual(c, lst.ToArray());
        }
        [Test]
        [Category("Sort")]
        [TestCase(new int[] { 6, 2, 9, 4, 1, 6, 7, 3 }, new int[] { 1, 1,2, 2, 3,3, 4, 6, 6, 7, 9 }, TestName = "Sort1{ 6, 2, 9, 4, 1, 6, 7, 3 }")]
        [TestCase(new int[] { 6, 2, 9, 4, 1, 6, 7 }, new int[] { 1, 1, 2, 2, 3, 4, 6, 6, 7, 9 }, TestName = "Sort1{ 6, 2, 9, 4, 1, 6, 7 }")]
        [TestCase(new int[] { 13, 66 }, new int[] { 1,2,3,13, 66 }, TestName = "Sort1{ 13, 66 }")]
        [TestCase(new int[] { 1 }, new int[] { 1,1,2,3 }, TestName = "Sort1{ 1 }")]
        [TestCase(new int[] { 0, 0, 0 }, new int[] { 0, 0, 0,1,2,3 }, TestName = "Sort1{ 0, 0, 0 }")]
        [TestCase(null, new int[] { 1,2,3}, TestName = "Sort1null")]
        [TestCase(new int[] { }, new int[] { 1, 2, 3 }, TestName = "Sort1[0]")]
        public void TestMethod_Sort1(int[] a, int[] c)
        {
            lst.Init(a);
            lst.AddStart(3);
            lst.AddStart(2);
            lst.AddStart(1);
            lst.Sort();
            Assert.AreEqual(c, lst.ToArray());
        }

        [Test]
        [Category("AddPosAr")]
        [TestCase(new int[] { 6, 2, 9, 4, 1, 6, 7 }, 4, new int[] { 7, 5 }, new int[] { 6, 2, 9, 4, 7, 5, 1, 6, 7 }, TestName = "AddPosAr{ 6, 2, 9, 4, 1, 6, 7 }")]
        [TestCase(new int[] { 13, 66 }, 1, new int[] { 2 }, new int[] { 13, 2, 66 }, TestName = "AddPosAr{ 13, 66 }")]
        [TestCase(new int[] { 1 }, 0, new int[] { 6, 8, 5, 3, 4 }, new int[] { 6, 8, 5, 3, 4, 1 }, TestName = "AddPosAr{ 1 }")]
        [TestCase(new int[] { 0, 0, 0 }, 1, new int[] { 8 }, new int[] { 0, 8, 0, 0 }, TestName = "AddPosAr{ 0, 0, 0 }")]
        [TestCase(null, 0, new int[] { 6, 2, 9, 4, 1, 6, 7 }, new int[] { 6, 2, 9, 4, 1, 6, 7 }, TestName = "AddPosArnull")]
        [TestCase(new int[] { }, 0, new int[] { 7, 5 }, new int[] { 7, 5 }, TestName = "AddPosAr[0]")]
        public void TestMethod_AddPosAr(int[] a, int b, int[] c, int[] d)
        {
            lst.Init(a);
            lst.AddPos(b, c);
            Assert.AreEqual(d, lst.ToArray());
        }
        [Test]
        [Category("AddPosAr")]
        [TestCase(new int[] { 6, 2, 9, 4, 1, 6, 7 }, 15, TestName = "AddPosAr_Exception{ 6, 2, 9, 4, 1, 6, 7 }")]
        [TestCase(new int[] { 13, 66 }, -2, TestName = "AddPosAr_Exception{ 13, 66 }")]
        public void TestMethod_AddPosArexc_01(int[] a, int b)
        {
            lst.Init(a);
            Assert.Throws(typeof(ArgumentOutOfRangeException), () => lst.Get(b));
        }
        
        [Test]
        [Category("Size")]
        [TestCase(new int[] { 6, 2, 9, 4, 1, 6, 7 }, 7, TestName = "Size{ 6, 2, 9, 4, 1, 6, 7 }")]
        [TestCase(new int[] { 13, 66 }, 2, TestName = "Size{ 13, 66 }")]
        [TestCase(new int[] { 1 }, 1, TestName = "Size{ 1 }")]
        [TestCase(new int[] { 0, 0, 0 }, 3, TestName = "Size{ 0, 0, 0 }")]
        [TestCase(null, 0, TestName = "Sizenull")]
        [TestCase(new int[] { }, 0, TestName = "Size[0]")]
        public void TestMethod_Size(int[] a, int b)
        {
            AList0 lst = new AList0();
            lst.Init(a);
            Assert.AreEqual(b, lst.Size());
        }
        [Test]
        [Category("Size")]
        [TestCase(new int[] { 6, 2, 9, 4, 1, 6, 7 }, 7, TestName = "Size1{ 6, 2, 9, 4, 1, 6, 7 }")]
        [TestCase(new int[] { 13, 66 }, 2, TestName = "Size1{ 13, 66 }")]
        [TestCase(new int[] { 1 }, 1, TestName = "Size1{ 1 }")]
        [TestCase(new int[] { 0, 0, 0 }, 3, TestName = "Size1{ 0, 0, 0 }")]
        [TestCase(null, 0, TestName = "Size1null")]
        [TestCase(new int[] { }, 0, TestName = "Size1[0]")]
        public void TestMethod_Size1(int[] a, int b)
        {
            AList0 lst = new AList0();
            lst.Init(a);
            lst.AddStart(2);
            Assert.AreEqual(b + 1, lst.Size());
        }
        [Test]
        [Category("Size")]
        [TestCase(new int[] { 6, 2, 9, 4, 1, 6, 7 }, 7, TestName = "Size2{ 6, 2, 9, 4, 1, 6, 7 }")]
        [TestCase(new int[] { 13, 66 }, 2, TestName = "Size2{ 13, 66 }")]
        [TestCase(new int[] { 1 }, 1, TestName = "Size2{ 1 }")]
        [TestCase(new int[] { 0, 0, 0 }, 3, TestName = "Size2{ 0, 0, 0 }")]
        [TestCase(null, 0, TestName = "Size2null")]
        [TestCase(new int[] { }, 0, TestName = "Size2[0]")]
        public void TestMethod_Size2(int[] a, int b)
        {
            AList0 lst = new AList0();
            lst.Init(a);
            lst.AddStart(2);
            lst.AddStart(99);
            Assert.AreEqual(b + 2, lst.Size());
        }
        
    }*/
}
