using Microsoft.VisualStudio.TestTools.UnitTesting;
using ChessBoardMatrix;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessBoardMatrix.Tests
{
    [TestClass()]
    public class ChessBMatrixTests
    {
        [TestMethod()]
        public void ConstructorTest()
        {
            ChessBMatrix mx = new ChessBMatrix();
            Assert.AreEqual(mx.GetSize(), 3);
            Assert.AreEqual(mx.GetNumOfVector(), 5);
            ChessBMatrix mx1 = new ChessBMatrix(6,1);
            Assert.AreEqual(mx1.GetSize(),6);
            Assert.AreEqual(mx1.GetNumOfVector(), 18);
            ChessBMatrix mx3 = new ChessBMatrix(5,1);
            Assert.AreEqual(mx3.GetSize(), 5);
            Assert.AreEqual(mx3.GetNumOfVector(), 13);
            List<int> list = new List<int>() { 5, 10, 15, 20, 25 };
            ChessBMatrix mx4 = new ChessBMatrix(list);
            Assert.AreEqual(mx4.GetSize(), 3);
            Assert.AreEqual(mx4.GetNumOfVector(), 5);

            try
            {
                List<int> ints = new List<int>() { 5,10, 15, };
                ChessBMatrix MT = new ChessBMatrix(ints);
                Assert.Fail("No Error ");

            }catch (Exception ex)
            {
                Assert.IsTrue(ex is ChessBMatrix.InvalidVectorException);
            }
            



        }
        [TestMethod]
        public void CopyConstructorTest()
        {
            ChessBMatrix matrix1 = new ChessBMatrix();
            ChessBMatrix matrix2 = new ChessBMatrix(matrix1);
            matrix1.SetElement(0, 0, 40);
            Assert.AreEqual(matrix2.GetSize(), 3);
            Assert.AreEqual(matrix2.GetNumOfVector(), 5);
            Assert.AreNotEqual(matrix2.GetElement(0, 0), 40);


        }


        [TestMethod]
        public void GetElementTest()
        {
            ChessBMatrix chessBMatrix = new ChessBMatrix();
            Assert.AreEqual(chessBMatrix.GetElement(0, 0), 1);
            Assert.AreNotEqual(chessBMatrix.GetElement(2, 2), 2);
            Assert.AreEqual(chessBMatrix.GetElement(1, 2), 0);
            chessBMatrix.SetElement(1, 1, 40);
            Assert.AreEqual(chessBMatrix.GetElement(1, 1), 40);
            try
            {
                Assert.AreEqual(chessBMatrix.GetElement(7,7), 7);
                Assert.Fail("No Error");

            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex is ChessBMatrix.InvalidIndexException);

            }
        }
        [TestMethod]
        public  void SetElementTest() 
        {
            ChessBMatrix atrix = new ChessBMatrix();
            atrix.SetElement(0, 0, 70);
            atrix.SetElement(0, 2, 60);
            Assert.AreEqual(atrix.GetElement(0, 0), 70);
            Assert.AreNotEqual(atrix.GetElement(0,2), 1);
            try
            {
                atrix.SetElement(7, 7, 2);
                Assert.Fail("No Error");

            }catch (Exception ex)
            {
                Assert.IsTrue(ex is ChessBMatrix.InvalidIndexException);
            }
            try
            {
                atrix.SetElement(0, 1, 2);
                Assert.Fail("No Error");

            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex is ChessBMatrix.ZeroCellException);
            }
        }
        [TestMethod]
        public void SumTest()
        {
            ChessBMatrix chess = new ChessBMatrix(8, 1);
            ChessBMatrix chess1 = new ChessBMatrix(8,   1);
            ChessBMatrix chess2 = new ChessBMatrix(4, 1);
            ChessBMatrix sum = ChessBMatrix.Sum(chess, chess1, 1,1);
            Assert.AreEqual(sum.GetElement(0, 0), 2);
            Assert.AreEqual(sum.GetElement(7, 1), 2);
            Assert.AreEqual(sum.GetElement(0, 1),0);
            try
            {
                ChessBMatrix sum2 = ChessBMatrix.Sum(chess1 , chess2,   1,1);
                Assert.Fail("No error ");

            }catch (Exception ex)
            {
                Assert.IsTrue(ex is ChessBMatrix.DimensionMisMatchException);
            }

            
        }
        [TestMethod]
        public void MultiplyTest()
        {

            ChessBMatrix chess = new ChessBMatrix();
            ChessBMatrix chess1 = new ChessBMatrix(3, 1);
            ChessBMatrix chess2 = new ChessBMatrix(4,  1);
            ChessBMatrix multiply = ChessBMatrix.Multiply(chess, chess1,1, 1);
            Assert.AreEqual(multiply.GetElement(0, 0), 2);
            Assert.AreEqual(multiply.GetElement(1, 1), 1);
            Assert.AreEqual(multiply.GetElement(0, 1), 0);
            try
            {
                ChessBMatrix multiply2 = ChessBMatrix.Multiply(chess1, chess2, 1,1);
                Assert.Fail("No error ");


            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex is ChessBMatrix.DimensionMisMatchException);

            }


        }
        [TestMethod]
        public void ExtremeSizeTest()
        {
            ChessBMatrix trix1 = new ChessBMatrix(10000,1);
            Assert.AreEqual(trix1.GetElement(9999, 9999), trix1.GetElement(9999, 9999));
            try
            {
                ChessBMatrix trix2 = new ChessBMatrix(-1,1);
                Assert.Fail("No error");
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex is ChessBMatrix.InvalidSizeException);
            }
            try
            {
                ChessBMatrix matrix3 = new ChessBMatrix(0,1);
                Assert.Fail("No error");
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex is ChessBMatrix.InvalidSizeException);
            }
        }



    }
}