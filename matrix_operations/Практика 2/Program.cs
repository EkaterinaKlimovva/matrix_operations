// 4 вариант
using System;

namespace Практика_2
{
    public class Matrix
    {
        private double[,] data;

        //Конструкторы
        public Matrix(int nRows, int nCols)
        {
            data = new double[nRows, nCols];
        }

        public Matrix(double[,] initData)
        {
            data = initData;
        }

        //Свойства
        public double this[int i, int j]
        {
            get { return data[i, j]; }
            set { data[i, j] = value; }
        }

        public int Rows
        {
            get { return data.GetLength(0); }
        }
        public int Columns
        {
            get { return data.GetLength(1); }
        }
        // размер квадратной матрицы
        public int? Size
        {
            get { return data.Length; }
        }

        // Является ли матрица квадратной
        public bool IsSquared
        {
            get
            {
                if (data.GetLength(0) == data.GetLength(1))
                    return true;
                else
                    return false;
            }
        }
        // Является ли матрица нулевой
        public bool IsEmpty
        {
            get
            {
                bool em = true;
                for (int i = 0; i < data.GetLength(0); i++)
                {
                    for (int j = 0; j < data.GetLength(1); j++)
                    {
                        if (data[i, j] != 0)
                            em = false;
                    }
                }
                return em;
            }
        }
        // Является ли матрица единичной
        public bool IsUnity
        {
            get
            {
                bool em = true;
                for (int i = 0; i < data.GetLength(0); i++)
                {
                    for (int j = 0; j < data.GetLength(1); j++)
                    {
                        if ((i == j && data[i, j] != 1) || (i != j && data[i, j] != 0) || data.GetLength(0) != data.GetLength(1))
                            em = false;
                    }
                }
                return em;
            }
        }
        // Является ли матрица симметричной
        public bool IsSymmetric
        {
            get
            {
                bool em = true;
                if (data.GetLength(0) != data.GetLength(1))
                {
                    return false;
                }
                else
                {
                    for (int i = 0; i < data.GetLength(0); i++)
                    {
                        for (int j = 0; j < data.GetLength(1); j++)
                        {
                            if (data[i, j] != data[j, i])
                                em = false;
                        }
                    }
                    return em;
                }
            }
        }

        //Сложение матриц
        public static Matrix operator +(Matrix m1, Matrix m2)
        {
            Matrix array;
            if ((m1.Rows != m2.Rows) || (m1.Columns != m2.Columns))
            {
                return null;
            }
            else
            {
                array = new Matrix(m1.Rows, m1.Columns);
                for (int i = 0; i < m1.Rows; i++)
                {
                    for (int j = 0; j < m1.Columns; j++)
                    {
                        array[i, j] = m1[i, j] + m2[i, j];
                    }
                }
                return array;
            }
        }

        //Преобразование типов
        public static explicit operator Matrix(double[,] arr)
        {
            return new Matrix(arr);
        }

        //Транспонирование матрицы
        public Matrix Transpose()
        {
            Matrix array = new Matrix(Rows, Columns);
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    array[i, j] = this[j, i];
                }
            }
            return array;
        }

        //Преобразование матрицы в строку
        public override string ToString()
        {
            string str = "";
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    if (j != Columns - 1)
                        str += this[i, j] + " ";
                    else
                        str += this[i, j];
                }
                if (i != Rows - 1)
                    str += "\n";
                else
                    str += "";
            }
            return str;
        }

        //Порождение единичной марицы
        public static Matrix GetUnity(int Size)
        {
            Matrix array = new Matrix(Size, Size);

            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    if (i == j)
                        array[i, j] = 1;
                    else
                        array[i, j] = 0;
                }
            }
            return array;
        }

        //Порождение нулевой марицы
        public static Matrix GetEmpty(int Size)
        {
            Matrix array = new Matrix(Size, Size);

            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    array[i, j] = 0;
                }
            }
            return array;
        }

        //Создание матрицы по строчке
        public static Matrix Parse(string s)
        {
            try
            {
                int r = s.Split(',').Length;
                int c = s.Split(' ').Length / r;
                Matrix array = new Matrix(r, c);

                string[] str = s.Split(',');

                for (int i = 0; i < str.Length; i++)
                {
                    str[i] = str[i].Trim(' ');
                    string[] sb = str[i].Split(' ');
                    for (int j = 0; j < sb.Length; j++)
                    {
                        array[i, j] = Convert.ToDouble(sb[j]);
                    }
                }

                return array;
            }
            catch (Exception)
            {
                Console.WriteLine("Ошибка!");
                return null;
            }
        }

    }

    class Program
    {
        static void Exit()
        {
            Environment.Exit(0);
        }
        //Вывод информации о матрице
        static void Info()
        {
            Matrix array;
            Console.WriteLine("Введите матрицу в виде: а11 а12 а13 ... а1m, а21 а22 а23 ... а2m, ... an1 an2 an3 ... anm");
            Console.WriteLine("Например: 1 2 3, 4 5 6, 7 8 9");
            array = Matrix.Parse(Console.ReadLine());
            if (array == null)
            {
                Console.WriteLine("Нажмите любую кнопку для выхода в меню");
                Console.ReadKey(true);
                Main();
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("Введённая матрица: ");
                Console.WriteLine(array.ToString());
                Console.WriteLine("    количество строк: " + array.Rows);
                Console.WriteLine("    количество столбцов: " + array.Columns);

                if (array.IsSquared)
                    Console.WriteLine("    квадратная");
                else
                    Console.WriteLine("    неквадратная");

                if (array.IsEmpty)
                    Console.WriteLine("    нулевая");
                else
                    Console.WriteLine("    ненулевая");

                if (array.IsUnity)
                    Console.WriteLine("    единичная");
                else
                    Console.WriteLine("    неединичная");

                if (array.IsSymmetric)
                    Console.WriteLine("    симметричная");
                else
                    Console.WriteLine("    несимметричная");

                Console.WriteLine();
                Console.WriteLine("Нажмите любую кнопку для выхода в меню");
                Console.ReadKey(true);
                Main();
            }
        }

        //Суммирование матриц
        static void SumM()
        {
            Matrix m1;
            Matrix m2;
            Matrix m;
            Console.WriteLine("Введите матрицы в виде: а11 а12 а13 ... а1m, а21 а22 а23 ... а2m, ... an1 an2 an3 ... anm");
            Console.WriteLine("Например: 1 2 3, 4 5 6, 7 8 9");
            Console.WriteLine();
            Console.WriteLine("Введите 1-ую матрицу: ");
            m1 = Matrix.Parse(Console.ReadLine());

            if (m1 == null)
            {
                Console.WriteLine();
                Console.WriteLine("Нажмите любую кнопку для выхода в меню");
                Console.ReadKey(true);
                Main();
            }
            else
            {
                Console.WriteLine("Введённая матрица: ");
                Console.WriteLine(m1.ToString());
            }

            Console.WriteLine();
            Console.WriteLine("Введите 2-ую матрицу: ");
            m2 = Matrix.Parse(Console.ReadLine());

            if (m2 == null)
            {
                Console.WriteLine();
                Console.WriteLine("Нажмите любую кнопку для выхода в меню");
                Console.ReadKey(true);
                Main();
            }
            else
            {
                Console.WriteLine("Введённая матрица: ");
                Console.WriteLine(m2.ToString());
            }

            m = m1 + m2;

            if (m != null)
            {
                Console.WriteLine();
                Console.WriteLine("Ответ: ");
                Console.WriteLine(m.ToString());
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("Ошибка!");
                Console.WriteLine("Нажмите любую кнопку для выхода в меню");
                Console.ReadKey(true);
                Main();
            }

            Console.WriteLine();
            Console.WriteLine("Нажмите любую кнопку для выхода в меню");
            Console.ReadKey(true);
            Main();
        }

        //Транспонирование матрицы
        static void Transroses()
        {
            Matrix array;
            Matrix arrayT;
            Console.WriteLine("Введите матрицу в виде: а11 а12 а13 ... а1m, а21 а22 а23 ... а2m, ... an1 an2 an3 ... anm");
            Console.WriteLine("Например: 1 2 3, 4 5 6, 7 8 9");
            array = Matrix.Parse(Console.ReadLine());

            Console.WriteLine();
            Console.WriteLine("Введённая матрица: ");
            Console.WriteLine(array.ToString());

            if (array.IsSquared)
            {
                arrayT = array.Transpose();
                Console.WriteLine();
                Console.WriteLine("Транспонированная матрица: ");
                Console.WriteLine(arrayT);
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("Ошибка!");
            }
            Console.WriteLine();
            Console.WriteLine("Нажмите любую кнопку для выхода в меню");
            Console.ReadKey(true);
            Main();
        }

        //Меню
        static void Main()
        {
            Console.WriteLine("1 - информация о матрице");
            Console.WriteLine("2 - сложение матриц");
            Console.WriteLine("3 - транспонирование матрицы");
            Console.WriteLine("0 - выход");

            while (true)
            {
                switch (char.ToLower(Console.ReadKey(true).KeyChar))
                {
                    case '1':
                        Console.Clear();
                        Info();
                        break;
                    case '2':
                        Console.Clear();
                        SumM();
                        break;
                    case '3':
                        Console.Clear();
                        Transroses();
                        break;
                    case '0':
                        Console.Clear();
                        Exit();
                        break;
                    default:
                        Console.WriteLine("");
                        Console.WriteLine("Неправильный ввод");
                        Console.WriteLine("Повторите ввод:");
                        break;
                }
            }
        }
    }
}