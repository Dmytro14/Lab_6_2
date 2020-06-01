using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Lab_5_1
{
    interface Tours
    {
        List<TouringTrip> ReadDate(string path);
        void SaveDate(List<TouringTrip> Date, string path);
    }


    abstract public class Kiosk
    {
        public string Name { get; set; }
        public string Address { get; set; }

        public static List<TouringTrip> ReadDate(string path)
        {
            List<TouringTrip> g = new List<TouringTrip>();
            string text = "";
            using (StreamReader sr = new StreamReader(path))
            {
                text = sr.ReadToEnd();
            }
            string[] Times = text.Split('/');
            foreach (string s in Times)
            {
                string[] MetaDete = s.Split('|');
                if (MetaDete.Length == 5)
                {
                    TouringTrip d = new TouringTrip
                    {
                        Coment = MetaDete[0],
                        Time = MetaDete[1],
                        Count = Convert.ToInt32(MetaDete[2]),
                        Name = MetaDete[3],
                        Address = MetaDete[4]
                    };
                    g.Add(d);
                }
            }
            return g;
        }
        public static void SaveDate(List<TouringTrip> Time, string path)
        {
            using (StreamWriter sw = new StreamWriter(path, false, System.Text.Encoding.Default))
            {
                foreach (TouringTrip g in Time)
                {

                    sw.WriteLine(g.Coment.Trim() + "|" + g.Time + "|" + g.Count + "|" + g.Name + "|" + g.Address + "/");

                }
            }
        }
        public static void ChangeDate(List<TouringTrip> Time)
        {
            Console.WriteLine("Введiть час:");
            string Nam = Console.ReadLine();
            TouringTrip Choosen = new TouringTrip();
            Choosen.Name = "";
            foreach (TouringTrip g in Time)
            {
                if (g.Time == Nam)
                {
                    Choosen = g;
                    break;
                }
            }
            if (Choosen.Name != "")
            {
                Console.WriteLine();
                Console.WriteLine("1)Змiнити коментар\n2)Змiнити час\n3)Змiнити  кiлькiсть\n4)Змiнити прiзвище\n5)Змiнити адресу\n6)Видалити");
                char key = Console.ReadKey().KeyChar;
                Console.WriteLine("Введiть нове значення:");
                try
                {
                    if (key == '1')
                    {
                        Choosen.Coment = Console.ReadLine();
                    }
                    if (key == '2')
                    {

                        Choosen.Time = Console.ReadLine();
                    }
                    if (key == '3')
                    {
                        Choosen.Count = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine(Choosen.Count);

                    }
                    if (key == '4')
                    {
                        Choosen.Name = Console.ReadLine();
                    }
                    if (key == '5')
                    {
                        Choosen.Address = Console.ReadLine();
                    }
                    if (key == '6')
                    {
                        Time.Remove(Choosen);
                    }
                }
                catch
                {
                    Console.WriteLine("нове значення не правильне");
                }

            }
            else
            {
                Console.WriteLine("TouringTrip не знайдено");
            }

        }
        public static void AddNew(List<TouringTrip> Date)
        {
            Console.WriteLine("Введiть коментар");
            TouringTrip neww = new TouringTrip();
            neww.Coment = Console.ReadLine();
            Console.WriteLine("Введiть час");
            neww.Time = Console.ReadLine();
            Console.WriteLine("Введiть кiлькiсть");
            neww.Count = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введiть прiзвище");
            neww.Name = Console.ReadLine();
            Console.WriteLine("Введiть адресу");
            neww.Address = Console.ReadLine();
            Date.Add(neww);
        }
        public static void ShowTable(List<TouringTrip> TouringTrip)
        {
            int MaxI = 8;
            int MaxN = 4;
            int MaxW = 9;
            int MaxC = 10;
            int MaxL = 8;
            Console.WriteLine("|Коментар| Час |Кiлькiсть| Прiзвище | Адреса |");
            foreach (TouringTrip g in TouringTrip)
            {
                int ni = MaxI - Convert.ToString(g.Coment.Trim()).Length;
                int nn = MaxN - g.Time.Count();
                int nw = MaxW - Convert.ToString(g.Count).Length;
                int nc = MaxC - Convert.ToString(g.Name).Length;
                int nl = MaxL - Convert.ToString(g.Address).Length;
                Console.WriteLine("|" + Convert.ToString(g.Coment.Trim()) + PS(ni) + "|" + g.Time + PS(nn) + "|" +
                 Convert.ToString(g.Count) + PS(nw) + "|" + Convert.ToString(g.Name) + PS(nc) + "|"
                 + Convert.ToString(g.Address) + PS(nl) + "|");
            }
            Console.WriteLine(" p - Ред./Вид.\n d - Створити\n n - Загальна кiлькiсть\n m - Найменша кiлькiсть" +
                "\n t - Знайти коментар\nEnter - Вихiд");
        }
        public static string PS(int count)
        {
            string s = "";
            for (int i = 0; i < count; i++)
            {
                s += " ";
            }
            return s;
        }
        public abstract int Smallest(List<TouringTrip> lst);
        public abstract void ToComment(List<TouringTrip> lst);
        public abstract char Total(List<TouringTrip> lst);
    }
    //Похідний класс
    public class TouringTrip : Kiosk
    {
        public string Coment { get; set; }
        public string Time { get; set; }
        public int Count { get; set; }
        public override int Smallest(List<TouringTrip> lst)
        {
            Console.Clear();
            int IndexMin = 0;
            foreach (TouringTrip gs in lst)
            {
                if (lst[IndexMin].Count > gs.Count)
                {
                    IndexMin = lst.IndexOf(gs);
                }
            }
            int MaxI = 8;
            int MaxN = 4;
            int MaxW = 9;
            int MaxC = 10;
            int MaxL = 8;
            TouringTrip g = lst[IndexMin];
            Console.WriteLine("|Коментар| Час |Кiлькiсть| Прiзвище | Адреса |");
            int ni = MaxI - Convert.ToString(g.Coment.Trim()).Length;
            int nn = MaxN - g.Time.Count();
            int nw = MaxW - Convert.ToString(g.Count).Length;
            int nc = MaxC - Convert.ToString(g.Name).Length;
            int nl = MaxL - Convert.ToString(g.Address).Length;
            Console.WriteLine("|" + Convert.ToString(g.Coment.Trim()) + PS(ni) + "|" + g.Time + PS(nn) + "|" +
             Convert.ToString(g.Count) + PS(nw) + "|" + Convert.ToString(g.Name) + PS(nc) + "|"
             + Convert.ToString(g.Address) + PS(nl) + "|");
            return g.Count;
        }
        public override void ToComment(List<TouringTrip> lst)
        {

            Console.WriteLine("Введiть коментар");
            string cim = Console.ReadLine();
            Console.Clear();
            int MaxI = 8;
            int MaxN = 4;
            int MaxW = 9;
            int MaxC = 10;
            int MaxL = 8;
            Console.WriteLine("|Коментар| Час |Кiлькiсть| Прiзвище | Адреса |");
            foreach (TouringTrip g in lst)
            {
                if (g.Coment.Trim() == cim.Trim())
                {
                    int ni = MaxI - Convert.ToString(g.Coment.Trim()).Length;
                    int nn = MaxN - g.Time.Count();
                    int nw = MaxW - Convert.ToString(g.Count).Length;
                    int nc = MaxC - Convert.ToString(g.Name).Length;
                    int nl = MaxL - Convert.ToString(g.Address).Length;
                    Console.WriteLine("|" + Convert.ToString(g.Coment.Trim()) + PS(ni) + "|" + g.Time + PS(nn) + "|" +
                     Convert.ToString(g.Count) + PS(nw) + "|" + Convert.ToString(g.Name) + PS(nc) + "|"
                     + Convert.ToString(g.Address) + PS(nl) + "|");
                }

            }
            Console.WriteLine("Натиснiть будь-яку клавiшу");
            Console.ReadKey();
        }
        public override char Total(List<TouringTrip> lst)
        {
            Console.WriteLine("Загальна кiлькiсть:");
            Console.Clear();
            int t = 0;
            foreach (TouringTrip g in lst)
            {
                t += g.Count;
            }
            Console.WriteLine(t);
            Console.WriteLine("Натиснiть будь-яку клавiшу");
            Console.ReadLine();
            return 't';


        }
    }
    //Основна програма
    class Program
    {

        static void Main()
        {
            Console.Clear();
            task1();
            Console.WriteLine((Char)Console.ReadKey().KeyChar);
        }
        static void task1()
        {
            string path = "";
            List<TouringTrip> goods = new List<TouringTrip>();
            Console.WriteLine("Введiть шлях до файлу '' або натиснiть будь-яку клавiшу, щоб створити новий");
            path = Console.ReadLine();
            try
            {
                goods = Kiosk.ReadDate(path);
            }
            catch
            {
                path = "Data.txt";
            }

            while (true)
            {
                Console.Clear();
                Kiosk.ShowTable(goods);
                var press = Console.ReadKey().Key;
                if (press.ToString() == "Enter")
                {
                    Main();
                }
                if (press.ToString() == "P")
                {
                    Console.WriteLine();
                    Kiosk.ChangeDate(goods);
                    Kiosk.SaveDate(goods, path);
                }
                if (press.ToString() == "D")
                {
                    Console.WriteLine();
                    Kiosk.AddNew(goods);
                    Kiosk.SaveDate(goods, path);
                }
                if (press.ToString() == "M")
                {
                    Console.WriteLine();
                    if (goods.Count > 0)
                    {
                        goods[0].Smallest(goods);
                        Console.WriteLine("Натиснiть будь-яку клавiшу");
                        Console.ReadKey();
                    }
                    Kiosk.SaveDate(goods, path);
                }
                if (press.ToString() == "T")
                {
                    Console.WriteLine();
                    if (goods.Count > 0)
                    {
                        goods[0].ToComment(goods);
                    }
                    Kiosk.SaveDate(goods, path);
                }
                if (press.ToString() == "N")
                {
                    Console.WriteLine();
                    if (goods.Count > 0)
                    {
                        goods[0].Total(goods);
                    }
                    Kiosk.SaveDate(goods, path);
                }
            }
        }
    }
}