using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Практика_2;

namespace Модульные_тесты
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CreateCertainMatrix()
        {
            Matrix m = new Matrix(3, 5);
            Assert.AreEqual(3, m.Rows);
            Assert.AreEqual(5, m.Columns);
        }

        [TestMethod]
        public void CheckIsSquared1()
        {
            double[,] array = { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
            Matrix m = new Matrix(array);
            Assert.AreEqual(true, m.IsSquared);
        }

        [TestMethod]
        public void CheckIsSquared2()
        {
            double[,] array = { { 1, 2, 3 }, { 4, 5, 6 } };
            Matrix m = new Matrix(array);
            Assert.AreEqual(false, m.IsSquared);
        }

        [TestMethod]
        public void CheckIsEmpty1()
        {
            double[,] array = { { 0, 0 }, { 0, 0} };
            Matrix m = new Matrix(array);
            Assert.AreEqual(true, m.IsEmpty);
        }

        [TestMethod]
        public void CheckIsIsEmpty2()
        {
            double[,] array = { { 1, 2, 3 }, { 4, 5, 6 } };
            Matrix m = new Matrix(array);
            Assert.AreEqual(false, m.IsEmpty);
        }

        [TestMethod]
        public void CheckIsUnity1()
        {
            double[,] array = { { 1, 0 }, { 0, 1 } };
            Matrix m = new Matrix(array);
            Assert.AreEqual(true, m.IsUnity);
        }

        [TestMethod]
        public void CheckIsUnity2()
        {
            double[,] array = { { 1, 2, 3 }, { 4, 5, 6 } };
            Matrix m = new Matrix(array);
            Assert.AreEqual(false, m.IsUnity);
        }

        [TestMethod]
        public void CheckIsSymmetric1()
        {
            double[,] array = { { 1, 2 }, { 2, 1 } };
            Matrix m = new Matrix(array);
            Assert.AreEqual(true, m.IsSymmetric);
        }

        [TestMethod]
        public void CheckIsSymmetric2()
        {
            double[,] array = { { 1, 2 }, { 4, 5 } };
            Matrix m = new Matrix(array);
            Assert.AreEqual(false, m.IsSymmetric);
        }

        [TestMethod]
        public void CheckTranspose()
        {
            double[,] array = { {1, 2, 3}, {4, 5, 6}, {7, 8, 9} };
            double[,] arrayT = { {1, 4, 7}, {2, 5, 8}, {3, 6, 9} };
            Matrix m = new Matrix(array);
            Matrix mT = new Matrix(arrayT);
            Matrix mm = m.Transpose();
            bool b = true;

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (mT[i, j] != mm[i, j])
                        b = false;
                }
            }
            Assert.AreEqual(true, b);
        }

        [TestMethod]
        public void CheckSum()
        {
            double[,] array1 = { { 1, 1 }, { 1, 1 } };
            double[,] array2 = { { 1, 1 }, { 1, 1 } };
            double[,] arrayS = { { 2, 2 }, { 2, 2 } };
            Matrix m1 = new Matrix(array1);
            Matrix m2 = new Matrix(array2);
            Matrix mS = m1 + m2;
            Matrix m = new Matrix(arrayS);
            bool b = true;

            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    if (mS[i, j] != m[i, j])
                        b = false;
                }
            }
            Assert.AreEqual(true, b);
        }

        [TestMethod]
        public void CheckToString ()
        {
            double[,] array = { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
            Matrix m = new Matrix(array);
            string str = "1 2 3\n4 5 6\n7 8 9";
            Assert.AreEqual(str, m.ToString());
        }

        [TestMethod]
        public void CheckGetUnity()
        {
            double[,] array = { { 1, 0, 0 }, { 0, 1, 0 }, { 0, 0, 1 } };
            Matrix m = new Matrix(array);
            Matrix mU = Matrix.GetUnity(3);
            bool b = true;

            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    if (mU[i, j] != m[i, j])
                        b = false;
                }
            }
            Assert.AreEqual(true, b);
        }

        [TestMethod]
        public void CheckGetEmpty()
        {
            double[,] array = { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } };
            Matrix m = new Matrix(array);
            Matrix mE = Matrix.GetEmpty(3);
            bool b = true;

            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    if (mE[i, j] != m[i, j])
                        b = false;
                }
            }
            Assert.AreEqual(true, b);
        }

        [TestMethod]
        public void CheckParse()
        {
            double[,] array = { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
            Matrix m = new Matrix(array);
            Matrix mP = Matrix.Parse("1 2 3, 4 5 6, 7 8 9");
            bool b = true;

            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    if (mP[i, j] != m[i, j])
                        b = false;
                }
            }
            Assert.AreEqual(true, b);
        }
    }
}
