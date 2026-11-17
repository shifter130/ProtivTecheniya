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
            Loader loader = new Loader();
            Configurator configurator = new Configurator();
            Console.Title = "Против Течения - порт телеигры с РТС.Медиа";
            Console.WriteLine("Загрузка вопросов...");
            int totalq = loader.LoadQuestions();
            Console.WriteLine("ЗАГРУЖЕНО ВОПРОСОВ: " + totalq);
            Console.WriteLine("Загрузка конфигурации...");
            // TODO: догадайтесь с трёх раз
            if (configurator.Read("skipmenu") == "1")
            {
                if (!args.Contains("/noskip"))
                {
                    GameManager gamemanager = new GameManager(loader);
                    gamemanager.LetTheFlamesBegin();
                }
            }
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
                Console.WriteLine("4. Настройки (Config.txt)");
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
                    case "4":
                        SettingSelected();
                        break;
                    default:
                        continue;
                }
            }
        }

        static void SettingSelected() {
            Configurator configurator = new Configurator();
            Console.WriteLine("==============НАСТРОЙКИ==============");
            Console.WriteLine("Введите номер параметра для изменения.");
            Console.WriteLine("1. Пропуск игрового меню при запуске (skipmenu) - " + configurator.Read("skipmenu"));
            Console.WriteLine("2. Вернуться");
            Console.Write("Ваш выбор: ");
            var choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    Console.Write("Введите значение (1 либо 0): ");
                    var InputVal = Console.ReadLine();
                    configurator.OverrideWrite("skipmenu", InputVal);
                    Console.WriteLine("Надеюсь, записалось!");
                    return;
                case "2":
                    Console.WriteLine("Неправильный выбор, возвращаюсь в игровое меню...");
                    return;
                default:
                    break;
            }
            return;
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
