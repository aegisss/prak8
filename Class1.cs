using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class Text
    {
        public int x_pos_cursor;
        public int y_pos_cursor;
        public static List<char> AddText()
        {
            List<char> list = new List<char>();
            foreach (var element in File.ReadAllText("D:\\Text.txt"))
            {
                list.Add(element);
                Console.Write(element);
            }
            return (list);
        }
        public bool ReadText(List<char> list)
        {
            Console.Clear();
            Text.AddText();
            Console.SetCursorPosition(0, 0);
            for (int i = 0; i < list.Count(); i++)
            {
                Console.SetCursorPosition(x_pos_cursor, y_pos_cursor);

                char a = Console.ReadKey().KeyChar;

                while (a != list[i])
                {
                    Console.SetCursorPosition(x_pos_cursor, y_pos_cursor);

                    Console.Write(list[i]);

                    Console.SetCursorPosition(x_pos_cursor, y_pos_cursor);

                    a = Console.ReadKey().KeyChar;
                }

                if (x_pos_cursor == Console.WindowWidth - 1)
                {
                    x_pos_cursor = 0;
                    y_pos_cursor++;
                    Console.SetCursorPosition(x_pos_cursor, y_pos_cursor);
                }
                else
                {
                    x_pos_cursor++;
                }
            }
            return false;
        }
    }
}
