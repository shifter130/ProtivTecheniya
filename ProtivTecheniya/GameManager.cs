using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProtivTecheniya.Questionator;
using System.Threading;
using System.IO;

namespace ProtivTecheniya
{
    class GameManager
    {
        // это короче надо чтобы принудительно не убивать поток и т.д., короче смотрите магию кода:
        protected bool GameOverFlag = false;
        protected bool JackpotFlag = true;

        protected Random random = new Random();
        private Loader loader;

        public int secondTimer;

        public GameManager(Loader loader)
        {
            this.loader = loader;
        }


        /// <summary>
        /// Запускает "game process"
        /// </summary>
        public void LetTheFlamesBegin() {
            Console.Clear();
            // Console.WriteLine("Вот, я хз как асинхронный таймер 150 секунд завести так шо придётся потоки юзать((");
            Console.WriteLine("Ознакомьтесь с файлами в мануале readme.pdf (согласно выбранному рулсету!). Как только прочитаете - нажмите любую кнопку.");
            Console.ReadKey();
            int qi = loader.questions.Count;
            while (qi > 1)
            {
                qi--;
                int j = random.Next(qi + 1);
                var temp = loader.questions[qi];
                loader.questions[qi] = loader.questions[j];
                loader.questions[j] = temp;
            }
            Thread bankandtimer = new Thread(TimerAndBank);
            bankandtimer.Start();
            for (int cq = 0; cq != 21; cq++)
            {
                if (GameOverFlag == true) {
                    Console.WriteLine("Игра окончена!!!");
                    Console.WriteLine("Вы проиграли!!!");
                    Console.WriteLine("Возвращаемся в главное меню...");
                    Program.Main(new string[] { "/noskip" });
                    break;
                }
                int friendlyCq = cq + 1;
                Console.WriteLine("ВОПРОС " + friendlyCq + "!");
                Console.WriteLine(loader.questions[cq].question + " " + ShuffleAnswers(loader.questions[cq].incorrect, loader.questions[cq].correct) + "?");
                string ans = Console.ReadLine();
                if (ans == loader.questions[cq].incorrect)
                {
                    Console.Clear();
                    Console.WriteLine("Отлично, идём дальше:");
                }
                else {
                    Console.Clear();
                    Console.WriteLine("Вы ответили верно, либо опечатались. Цепочка начинается сначала:");
                    cq = -1;
                }
            }
            if (JackpotFlag == true)
            {
                Console.WriteLine("Поздравляем! Вы выиграли джекпот: " + Rulesetator.jackpot + " рублей!");
                Console.WriteLine("Ввведите ваше имя, и мы запишем вас в текстовый файл рекордов!");
                string username = Console.ReadLine();
                string cookedstring = DateTime.Now.ToString("dd-MM-yyyy HH:mm") + " >> " + username + " >> ДЖЕКПОТ! 250 РУБЛЕЙ!" + Environment.NewLine;
                try
                {
                    File.AppendAllText("records.txt", cookedstring, Encoding.UTF8);
                    bankandtimer.Abort();
                    Program.Main(new string[] { "/noskip" });
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Возникла проблема при сохранении рекорда: " + ex.Message);
                    bankandtimer.Abort();
                    Program.Main(new string[] { "/noskip" });
                }
            }
            else {
                int localbank = secondTimer;
                Console.WriteLine("Поздравляем! Вы выиграли " + localbank + " рублей!");
                Console.WriteLine("Ввведите ваше имя, и мы запишем вас в текстовый файл рекордов!");
                string username = Console.ReadLine();
                string cookedstring = DateTime.Now.ToString("dd-MM-yyyy HH:mm") + " >> " + username + " >> " + localbank.ToString() + Sklon(localbank.ToString()) + Environment.NewLine;
                try
                {
                    File.AppendAllText("records.txt", cookedstring, Encoding.UTF8);
                    bankandtimer.Abort();
                    Program.Main(new string[] { "/noskip" });
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Возникла проблема при сохранении рекорда: " + ex.Message);
                    bankandtimer.Abort();
                    Program.Main(new string[] { "/noskip" });
                }
            }
        }

        /// <summary>
        /// Перемешивает ответы, чтобы не было так, что всегда неправильный - первый.
        /// </summary>
        /// <param name="IncorrectAns">Неправильный ответ</param>
        /// <param name="CorrectAns">Правильный ответ</param>
        /// <returns></returns>
        string ShuffleAnswers(string IncorrectAns, string CorrectAns) {
            int rs = random.Next(2);
            switch (rs)
            {
                case 0:
                    return IncorrectAns + " или " + CorrectAns;
                case 1:
                    return CorrectAns + " или " + IncorrectAns;
                default:
                    return IncorrectAns + " или " + CorrectAns;
            }
        }

        void TimerAndBank() {
            for (int firstTimer = Rulesetator.firstTimer; firstTimer != 0; firstTimer--) {
                Thread.Sleep(1000);
                Console.Title = "ОСТАВШЕЕСЯ ВРЕМЯ: " + firstTimer + Sklon(firstTimer);
            }
            JackpotFlag = false;
            for (secondTimer = Rulesetator.ostatok; secondTimer != -1; secondTimer -= Rulesetator.decrspeed)
            {
                Thread.Sleep(1000);
                Console.Title = "БАНК: " + secondTimer + Sklon(Convert.ToString(secondTimer));
            }
            GameOverFlag = true;
            Console.Title = "ВЫ ПРОИГРАЛИ!!!";
            return;
        }

        string Sklon(string money) {
            if (money.EndsWith("12") || money.EndsWith("13") || money.EndsWith("14"))
            {
                return " рублей!";
            }
            else if (money.EndsWith("1") && !money.EndsWith("11"))
            {
                return " рубль!";
            }
            else if (money.EndsWith("2") || money.EndsWith("3") || money.EndsWith("4")) {
                return " рубля!";
            }
            else {
                return " рублей!";
            }
        }

        string Sklon(int time) {
            string ttime = Convert.ToString(time);
            if (ttime.EndsWith("12") || ttime.EndsWith("13") || ttime.EndsWith("14"))
            {
                return " секунд!";
            }
            else if (ttime.EndsWith("1") && !ttime.EndsWith("11"))
            {
                return " секунда!";
            }
            else if (ttime.EndsWith("2") || ttime.EndsWith("3") || ttime.EndsWith("4"))
            {
                return " секунды!";
            }
            else
            {
                return " секунд!";
            }
        }

    }
}
