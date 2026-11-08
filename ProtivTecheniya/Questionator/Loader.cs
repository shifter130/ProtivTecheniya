using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProtivTecheniya.Questionator;
using System.IO;
namespace ProtivTecheniya.Questionator
{
    public class Loader
    {
        public List<StructModel.Question> questions = new List<StructModel.Question>();

        public int LoadQuestions() {
            int totalquestions = 0;
            try
            {
                string[] unresolvedquestions = File.ReadAllLines("questions.txt");

                foreach (string resolvingquestion in unresolvedquestions)
                {
                    if (resolvingquestion == "")
                    {
                        continue;
                    }
                    string[] parts = resolvingquestion.Split(new string[] { "///" }, StringSplitOptions.None);
                    questions.Add(new StructModel.Question(parts[0], parts[1], parts[2]));
                    totalquestions++;
                }
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine("Файл с вопросами не найден. Проверьте установку!");
                Console.Write("Нажмите любую кнопку для продолжения...");
                Console.ReadKey();
                Environment.Exit(0);
            }
            catch (Exception ex) {
                Console.WriteLine("Необработанное исключение: " + ex.Message + ", трассировка стека: " + ex.StackTrace);
                Console.Write("Нажмите любую кнопку для продолжения...");
                Console.ReadKey();
                Environment.Exit(0);
            }
            return totalquestions;
        }
    }
}
