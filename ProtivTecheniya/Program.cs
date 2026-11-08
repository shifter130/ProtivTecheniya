using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProtivTecheniya.Questionator;
using System.IO;

namespace ProtivTecheniya
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.Title = "Против Течения - порт телеигры с РТС.Медиа";
            Loader loader = new Loader();
            Console.WriteLine("Загрузка вопросов...");
            int totalq = loader.LoadQuestions();
            Console.WriteLine("ЗАГРУЖЕНО ВОПРОСОВ: " + totalq);
            int i = 0;
            while (i < 5) {
                Console.BackgroundColor = ConsoleColor.DarkRed;
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("ПРОТИВ ТЕЧЕНИЯ");
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("/*/");
                Console.BackgroundColor = ConsoleColor.Cyan;
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write("ПРОТИВ ТЕЧЕНИЯ \n");
                i++;
            }
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Порт телеигры с РТC.Медиа");
            Console.WriteLine("Джекпот и правила из 1 сезона.");
            Console.WriteLine("Ознакомьтесь с правилами на сайте GameShows.ru: http://clck.ru/3WtLjy");
            while (true) {
                Console.Title = "Против Течения - порт телеигры с РТС.Медиа";
                Console.WriteLine("=====ИГРОВОЕ МЕНЮ=====");
                Console.WriteLine("1. Начать игру");
                Console.WriteLine("2. Выйти");
                Console.WriteLine("3. Рекорды");
                Console.Write("Ваш выбор: ");
                var choice = Console.ReadLine();
                switch (choice) { 
                    case "1":
                        GameManager gamemanager = new GameManager(loader);
                        gamemanager.LetTheFlamesBegin();
                        break;
                    case "2":
                        Environment.Exit(0);
                        break;
                    case "3":
                        ReadRecords();
                        break;
                    default:
                        continue;
                }
            }
        }

        static void ReadRecords() {
            Console.WriteLine("===============РЕКОРДЫ===============");
            try
            {
                string[] lines = File.ReadAllLines("records.txt");

                foreach (string line in lines)
                {
                    if (line == "")
                    {
                        continue;
                    }
                    string[] parts = line.Split(new string[] { " >> " }, StringSplitOptions.None);
                    Console.WriteLine("Рекорд поставлен " + parts[0] + " игроком " + parts[1] + ", он получил " + parts[2]);
                }
            }
            catch (Exception ex) {
                Console.WriteLine("Не получилось прочитать рекорды: " + ex.Message);
            }
            return;
        }
    }
}
