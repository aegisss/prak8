using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Timers;

namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool WorkReadText = false;
            bool start = true;
            List<char> list = new List<char>();

            Text txt = new Text();
            Users user = new Users();
            Stopwatch sw = new Stopwatch();

            Thread th = new Thread(_ =>
            {
                while (start)
                {
                    while (WorkReadText == true)
                    {
                        sw.Start();
                        Thread.Sleep(1000);
                        sw.Stop();
                        string time = String.Format("{0:00}:{1:00}", sw.Elapsed.Minutes, sw.Elapsed.Seconds);
                        Console.SetCursorPosition(0, 6);
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("           ");
                        Console.SetCursorPosition(0, 6);
                        Console.WriteLine(time);
                        if (time[1] == 2)
                        {
                            WorkReadText = false;
                        }
                        user.Time = time;
                        Console.SetCursorPosition(txt.x_pos_cursor, txt.y_pos_cursor);
                    }
                    txt.x_pos_cursor = 0;
                    txt.y_pos_cursor = 0;
                }
            });

            th.Start();
            while (start)
            {
                Console.Clear();
                Console.Write("Введите ваш ник : ");
                user.Name = Console.ReadLine();

                while (WorkReadText == false)
                {
                    Console.Clear();
                    list = Text.AddText();
                    Console.WriteLine();
                    Console.WriteLine("Чтобы начать нажмите Enter");
                    ConsoleKeyInfo key = Console.ReadKey();
                    if (key.Key == ConsoleKey.Enter)
                    {
                        WorkReadText = true;
                    }
                }
                sw.Restart();
                WorkReadText = txt.ReadText(list);
                List<Users> ListUsers = user.AddTableRecords(user);
                Console.Clear();
                while (WorkReadText == false && start == true)
                {
                    user.DrewTableRecords();
                    Console.WriteLine("Чтобы попробовать еще раз нажмите Enter");
                    Console.WriteLine("Чтобы выйти нажмите Escape");
                    ConsoleKeyInfo key = Console.ReadKey();
                    if (key.Key == ConsoleKey.Enter)
                    {
                        WorkReadText = true;
                    }
                    else if (key.Key == ConsoleKey.Escape)
                    {
                        Console.Clear();
                        start = false;
                    }
                    else
                    {
                        Console.Clear();
                    }
                }
                WorkReadText = false;
            }
        }
    }
}