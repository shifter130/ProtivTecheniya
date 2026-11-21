using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProtivTecheniya
{
    class Rulesetator
    {
        public static int jackpot;
        public static int ostatok;
        public static int decrspeed;
        public static bool freezeab;
        public static int atfreezefrom;
        public static int firstTimer;
        public static int secondTimer;

        public static void RestoreRuleset() {
            Configurator configurator = new Configurator();
            try
            {
                jackpot = Convert.ToInt32(configurator.Read("jackpot"));
                ostatok = Convert.ToInt32(configurator.Read("ostatok"));
                decrspeed = Convert.ToInt32(configurator.Read("decrspeed"));
                freezeab = Convert.ToBoolean(configurator.Read("freezeab"));
                atfreezefrom = Convert.ToInt32(configurator.Read("atfreezefrom"));
                firstTimer = Convert.ToInt32(configurator.Read("firstTimer"));
                secondTimer = Convert.ToInt32(configurator.Read("secondTimer"));
            }
            catch (FormatException ex) {
                Console.WriteLine("Конфигурация рулсетов повреждена. Восстановите параметры через настройки.");
                Console.WriteLine("Нажмите любую клавишу . . .");
                Console.ReadKey();
                Environment.Exit(1);
            }
            return;
        }

        //извините за тавтологию в названии следующего метода xd
        public static void SetRuleset()
        {
            Configurator configurator = new Configurator();
            Console.WriteLine("Введите номер рулсета, или любые данные для выода.");
            Console.WriteLine("1. 1 сезон (250/150/1/false/0/150/150)");
            Console.WriteLine("2. 1 сезон (новогодние) (600/300/2/false/0/150/150)");
            Console.Write("Ваш выбор: ");
            var choice = Console.ReadLine();
            switch (choice) { 
                case "1":
                    configurator.OverrideWrite("jackpot", "250");
                    configurator.OverrideWrite("ostatok", "150");
                    configurator.OverrideWrite("decrspeed", "1");
                    configurator.OverrideWrite("freezeab", "false");
                    configurator.OverrideWrite("atfreezefrom", "0");
                    configurator.OverrideWrite("firstTimer", "150");
                    configurator.OverrideWrite("secondTimer", "150");
                    Console.WriteLine("Перезапустите игру для применения настроек!");
                    break;
                case "2":
                    configurator.OverrideWrite("jackpot", "600");
                    configurator.OverrideWrite("ostatok", "300");
                    configurator.OverrideWrite("decrspeed", "2");
                    configurator.OverrideWrite("freezeab", "false");
                    configurator.OverrideWrite("atfreezefrom", "0");
                    configurator.OverrideWrite("firstTimer", "150");
                    configurator.OverrideWrite("secondTimer", "150");
                    Console.WriteLine("Перезапустите игру для применения настроек!");
                    break;
                default:
                    Console.WriteLine("Неверный ввод, выходим в меню");
                    return;
            }
            return;
        }
    }
}
