using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gauss_Jordan_Elimination
{
    class Program
    {
        static void Main(string[] args)
        {
            for (; ; )
            {
                try
                {
                    Console.WriteLine("Matrix (R*C)");
                    Console.WriteLine("Enter the Number of Rows (R) and Columns (C) : ");
                    Console.Write("R = ");
                    int row = int.Parse(Console.ReadLine());
                    Console.Write("C = ");
                    int column = int.Parse(Console.ReadLine());
                    double[,] a = new double[row, column];
                    Console.WriteLine("Enter the elements of the matrix");
                    for (int i = 0; i < row; i++)
                    {
                        for (int j = 0; j < column; j++)
                        {
                            Console.Write("- element [" + (i + 1) + "," + (j + 1) + "] = ");
                            a[i, j] = double.Parse(Console.ReadLine());
                        }
                        Console.WriteLine();
                    }
                    Console.BackgroundColor = ConsoleColor.DarkBlue;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("---------- The Matrix ----------\n");
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.Black;
                    for (int i = 0; i < row; i++)
                    {
                        for (int j = 0; j < column; j++)
                        {
                            Console.Write("\t" + a[i, j] + "\t");
                        }
                        Console.WriteLine();
                    }
                    Console.ResetColor();
                    Console.BackgroundColor = ConsoleColor.DarkBlue;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("\n---------- The Steps ----------");
                    //we use x in making the element =1
                    double x;
                    //we use key in gauss and in some ecxeptions..
                    int key = 0;
                    //we use key4 in swapping..
                    int key4 = 0;
                    //we use c1 in zero column..
                    int c1 = 0;
                    //we use exc in the exception "in the infinity and no solutiin cases"..
                    bool exc = false;
                    Console.BackgroundColor = ConsoleColor.DarkCyan;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.WriteLine("\n---------- Gauss method ----------\n");
                    //gauss..
                    //this loop represent each stage in gauss method..
                    for (int i = 0; i < row; i++)
                    {

                        key++;
                        //if there is a Zero Column..
                        int c = 0;
                        for (int u = i; u < row; u++)
                        {
                            if (a[u, i + c1] == 0)
                            {
                                c++;
                            }
                        }
                        if (c == (row - i))
                        {
                            c1++;
                        }
                        //exception..
                        if (key == row && a[row - 1, column - 2] == 0)
                        {
                            exc = true;
                            break;
                        }

                        //swapping..
                        if (a[i, i + c1] == 0 && key != row)
                        {
                            //we use temp to make another matrix with the same size and elements

                            double[,] temp = new double[row, column];
                            for (int r = 0; r < row; r++)
                            {
                                for (int b = 0; b < column; b++)
                                {
                                    temp[r, b] = a[r, b];
                                }
                            }
                            //key4 help us to start swapping or search for a suitable row 
                            key4++;
                            for (int k = key4; k < row; k++)
                            {
                                if (a[k, i + c1] != 0)
                                {
                                    for (int j = 0; j < column; j++)
                                    {
                                        a[i, j] = temp[k, j];
                                        a[k, j] = temp[i, j];
                                    }
                                    break;
                                }
                            }
                            //print
                            Console.BackgroundColor = ConsoleColor.DarkGray;
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.WriteLine("---------- Swapping ---------- ");
                            Console.BackgroundColor = ConsoleColor.White;
                            Console.ForegroundColor = ConsoleColor.Black;
                            for (int t = 0; t < row; t++)
                            {
                                for (int j = 0; j < column; j++)
                                {
                                    Console.Write("\t" + a[t, j] + "\t");
                                }
                                Console.WriteLine();
                            }
                            Console.ResetColor();
                            Console.WriteLine();
                        }
                        //make the first element = 1
                        if (a[i, i + c1] != 1)
                        {
                            /*the loop and the condition below are important in the case that the matrix is square
                             * because it end the operation("make the first element=1")
                             * in the last step in gauss method*/

                            for (int ii = 0; ii < 1; ii++)
                            {
                                if (key == row && row == column)
                                {
                                    break;
                                }
                                // x is like " ثابت " we use it to achieve the step " 1/ثابت x R ---> R " 
                                x = a[i, i + c1];
                                for (int j = 0; j < column; j++)
                                {
                                    a[i, j] = ((1 / x) * (a[i, j]));
                                }
                                //print
                                Console.BackgroundColor = ConsoleColor.DarkGray;
                                Console.ForegroundColor = ConsoleColor.Black;
                                Console.WriteLine("({1} x R{0})) -------> R{0} \n", i + 1, ("1/" + Math.Round(x, 2)));
                                Console.BackgroundColor = ConsoleColor.White;
                                Console.ForegroundColor = ConsoleColor.Black;
                                for (int t = 0; t < row; t++)
                                {
                                    for (int j = 0; j < column; j++)
                                    {
                                        Console.Write("\t" + Math.Round(a[t, j], 2) + "\t");
                                    }
                                    Console.WriteLine();
                                }
                                Console.ResetColor();
                                Console.WriteLine();
                            }

                        }
                        /*here we make the rest of the column element to be zero
                         * key is used to make the loop below move on each rows
                         *  k represent the negative value of the next element "non zero" in the column
                         *  and we then multiply it with the row that we use in gauss 
                         *  and then we add this row to the other "that we need to make it = 0 " */
                        for (int l = key; l < row; l++)
                        {
                            double k = -a[l, i + c1];
                            for (int j = 0; j < column; j++)
                            {
                                a[l, j] = k * a[i, j] + a[l, j];
                            }
                            //print
                            Console.BackgroundColor = ConsoleColor.DarkGray;
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.WriteLine("({0} x R{1}) + R{2} ------->R{2} \n", Math.Round(k, 2), i + 1, l + 1);
                            Console.BackgroundColor = ConsoleColor.White;
                            Console.ForegroundColor = ConsoleColor.Black;
                            for (int t = 0; t < row; t++)
                            {
                                for (int j = 0; j < column; j++)
                                {
                                    Console.Write("\t" + Math.Round(a[t, j], 2) + "\t");
                                }
                                Console.WriteLine();
                            }
                            Console.ResetColor();
                            Console.WriteLine();
                        }
                        /*this condition in the case that rows is more than columns
                         * we make (key = m-1) to prevent the error that "Index was outside the bounds of the array."  */
                        if (row > column)
                        {

                            key = row - 1;
                        }

                    }
                    Console.BackgroundColor = ConsoleColor.DarkCyan;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.WriteLine("---------- Jorden Method --------\n");
                    /* why m-1 ..?
                     * to know the element that we need it to be zero  */
                    int key2 = row - 1;
                    /* why m-2 ..?
                     * to make the loop turn in the rest of the column elements */
                    int key3 = row - 2;
                    //jorden
                    /*this loop represent each stage in jorden method..
                     *and (i=m-2) to determine the times that we use this method.. */
                    for (int i = row - 2; i >= 0; i--)
                    {
                        /*this condition check the exception in gauss "infinity or no solution"
                         *to end jorden method if it is true */
                        if (exc == true)
                        {
                            break;
                        }
                        //the use of k like in gauss..
                        for (int j = key3; j >= 0; j--)
                        {
                            double k = -a[j, key2 + c1];
                            for (int l = 0; l < column; l++)
                            {
                                a[j, l] = (k * a[key2, l]) + a[j, l];
                            }
                            //print
                            Console.BackgroundColor = ConsoleColor.DarkGray;
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.WriteLine("({0} x R{1}) + R{2} -----> R{2} \n", Math.Round(k, 2), key2 + 1, j + 1);
                            Console.BackgroundColor = ConsoleColor.White;
                            Console.ForegroundColor = ConsoleColor.Black;

                            for (int t = 0; t < row; t++)
                            {
                                for (int v = 0; v < column; v++)
                                {
                                    Console.Write("\t" + Math.Round(a[t, v], 2) + "\t");
                                }
                                Console.WriteLine();
                            }
                            Console.ResetColor();
                            Console.WriteLine();
                        }
                        key2--;
                        key3--;

                    }
                    //exception condition
                    if (exc == true)
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.ForegroundColor = ConsoleColor.White;
                        if (a[row - 1, column - 1] == 0 && a[row - 1, column - 2] == 0)
                        {
                            Console.WriteLine("---------- Infinity Solution ----------");
                        }
                        else
                        {
                            Console.WriteLine("---------- No Solution ----------");
                        }

                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.DarkGreen;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("---------- Final Solution ----------\n");

                        for (int i = 0; i < row; i++)
                        {
                            Console.Write("X{0} = {1}      ", i + 1, Math.Round(a[i, column - 1], 2));
                        }
                        Console.WriteLine();
                        Console.BackgroundColor = ConsoleColor.DarkGreen;
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    Console.WriteLine();

                    //print
                    for (int i = 0; i < row; i++)
                    {
                        for (int j = 0; j < column; j++)
                        {
                            Console.Write("\t" + Math.Round(a[i, j], 2) + "\t");
                        }
                        Console.WriteLine();
                    }
                    Console.ResetColor();
                }
                catch (Exception e)
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(e.Message);
                    Console.ResetColor();
                }
                int beeeb = 5000;
                int beeeep = 1000;

                Console.Beep(beeeb, beeeep);

                Console.BackgroundColor = ConsoleColor.DarkBlue;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\n\t\t\t\t\t If you want to solve another system,Press any key \t\t\t\t\t");
                Console.ResetColor();
                Console.ReadKey();
                Console.Clear();
            }

        }
    }
}
