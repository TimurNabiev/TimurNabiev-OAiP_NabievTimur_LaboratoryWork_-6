using System.Diagnostics.Eventing.Reader;
using System.Runtime.InteropServices.Java;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace OAIP_Nabiev_4232_LAB6
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        // Тип треугольника
        private void Result(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(First_side.Text, out double First) &&
                double.TryParse(Second_Side.Text, out double Second) &&
                double.TryParse(Third_Side.Text, out double Third))
            {
                if (First > 0 && Second > 0 && Third > 0)
                {
                    if (First == Second && Second == Third)
                    {
                        MessageBox.Show("Ваш треугольник равносторонний");
                    }
                    else if (First == Second || Second == Third || First == Third)
                    {
                        MessageBox.Show("Ваш треугольник равнобедренный");
                    }
                    else
                    {
                        MessageBox.Show("Ваш треугольник разносторонний");
                    }
                }
                else
                {
                    MessageBox.Show("Введите существующие значения");
                }

            }
            else
            {
                MessageBox.Show("Введите корректные значения");
            }
        }
        // Совершенное число
        private void Check(object sender, RoutedEventArgs e)
        {
            int Count = 1;
            int Sum = 0;
            if (int.TryParse(Number.Text, out int Check_Number))
            {
                if (Check_Number > 0)
                {
                    for (int i = 0; i < Check_Number; i++)
                    {
                        if (Check_Number % Count == 0 && Count != Check_Number)
                        {
                            Sum += Count;
                        }
                        Count++;
                    }
                    if (Sum == Check_Number)
                    {
                        MessageBox.Show("Ваше число совершенное");
                    }
                    else
                    {
                        MessageBox.Show("Ваше число НЕ совершенное");
                    }
                }
                else
                {
                    MessageBox.Show("Введите корректное число");
                }

            }
            else
            {
                MessageBox.Show("Введите корректное число");
            }
        }
        private void Replace(object sender, RoutedEventArgs e)
        {
            string Check = Array.Text;
            if (int.TryParse(Count_Array.Text, out int Count_Arr))
            {
                string[] parts = Check.Split(',');

                if (parts.Length < Count_Arr)
                {
                    MessageBox.Show("Количество элементов не соответствует реальности");
                    return;
                }

                int[] Repl_Arr = new int[Count_Arr];

                for (int i = 0; i < Count_Arr; i++)
                {
                    if (!int.TryParse(parts[i].Trim(), out Repl_Arr[i]))
                    {
                        MessageBox.Show($"Элемент {parts[i].Trim()} не является числом");
                        return;
                    }
                }

                for (int i = 0; i < Count_Arr; i++)
                {
                    if (Repl_Arr[i] < 0)
                    {
                        Repl_Arr[i] = Repl_Arr[i] * (-1);
                    }
                }

                int MinEl = Repl_Arr[0];
                int MinIndex = 0;

                for (int i = 1; i < Count_Arr; i++)
                {
                    if (Repl_Arr[i] < MinEl)
                    {
                        MinEl = Repl_Arr[i];
                        MinIndex = i;
                    }
                }

                It_Arr.ItemsSource = Repl_Arr;
                It_MinEl.Text = $"Минимальный элемент: {MinEl}";
                It_Index.Text = $"Индекс минимального элемента: {MinIndex}";
            }
            else
            {
                MessageBox.Show("Введите корректное число");
            }
        }
        // Уравнение
        public class Equation
        {
            public double A { get; set; }
            public double B { get; set; }
            public static double Function1(double A, double B)
            {
                double X = (-(B)) / A;
                return X;
            }
        }
        private void Equat(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(Arg1.Text, out double A))
            {
                if (A != 0)
                {
                    if (double.TryParse(Arg2.Text, out double B))
                    {
                        if (double.IsInfinity(A) || double.IsInfinity(B))
                        {
                            MessageBox.Show("Вы вышли зв пределы разумных значений");
                            return;
                        }
                        Equation Sqrt_Res = new Equation();
                        Sqrt_Res.A = A;
                        Sqrt_Res.B = B;
                        double Fin_Res = Equation.Function1(A, B);
                        MessageBox.Show($"Результат выражения:{Fin_Res}");
                    }
                    else { MessageBox.Show("Введите корректное значение"); }
                }
                else { MessageBox.Show("Введите корректное число"); }
            }
            else { MessageBox.Show("Введите корректное число"); }
        }

        // Матрица 9*9
        private void ArrRes(object sender, RoutedEventArgs e)
        {
            int Sum = 0;
            Random random = new Random();
            int[,] Matrix = new int[9, 9];
            int[] Hig = new int[36];
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    Matrix[i, j] = random.Next(-50, 50);
                    OriginalArray.Text += Matrix[i, j] + " ";
                }
                OriginalArray.Text += "\n";
            }
            int MaxLow = Matrix[2, 1];

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (i < j || i == j)
                    {
                        for (int t = 0; t < 36; t++)
                        {
                            Hig[i] = Matrix[i, j];
                        }
                    }
                    else if (i > j)
                    {
                        if (Matrix[i, j] > MaxLow)
                        {
                            MaxLow = Matrix[i, j];
                        }
                    }
                }

            }
            for (int i = 0; i < Hig.Length; i++)
            {
                if (Hig[i] > MaxLow)
                    Sum += Hig[i];
            }
            if (Sum == 0)
                MessageBox.Show("Таких элементов не существует");
            Arr_Res.Text = Sum.ToString();
        }
        // Поворот матрицы на 90
        private void Turn(object sender, RoutedEventArgs e)
        {
            Random random = new Random();
            if (int.TryParse(CountCol.Text.Trim(), out int Collumn) &&
                int.TryParse(CountRow.Text.Trim(), out int Row) &&
                Row > 0 && Collumn > 0)
            {
                int[,] RevArr = new int[Row, Collumn];
                int[,] ItRev = new int[Collumn, Row];
                for (int i = 0; i < RevArr.GetLength(0); i++)
                {
                    for (int j = 0; j < RevArr.GetLength(1); j++)
                    {
                        RevArr[i, j] = random.Next(-50, 51);
                    }
                }
                for (int i = 0; i < RevArr.GetLength(0); i++)
                {
                    for (int j = 0; j < RevArr.GetLength(1); j++)
                    {
                        Before90.Text += RevArr[i, j] + " ";
                    }
                    Before90.Text += "\n";
                }
                for (int i = 0; i < RevArr.GetLength(0); i++)
                {
                    for (int j = 0; j < RevArr.GetLength(1); j++)
                    {
                        ItRev[Collumn - 1 - j, i] = RevArr[i, j];
                    }
                }
                for (int i = 0; i < ItRev.GetLength(0); i++)
                {
                    for (int j = 0; j < ItRev.GetLength(1); j++)
                    {
                        After90.Text += ItRev[i, j] + " ";
                    }
                    After90.Text += "\n";
                }
            }
            else
            {
                MessageBox.Show("Введите корректные значения");
            }
        }
    }
}