using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace ProtivTecheniya
{
    class Configurator
    {
        /// <summary>
        /// Получает значение по ключу из конфигурационного файла
        /// </summary>
        /// <param name="key">Ключ, значение которого нужно достать</param>
        /// <returns>Значение ключа</returns>
        public string Read(string key) 
        {
            if (!File.Exists("Config.txt")) 
            {
                File.Create("Config.txt");
            }
            string[] cfgLines = File.ReadAllLines("Config.txt", Encoding.UTF8);

            foreach (string line in cfgLines) 
            {
                if (line.StartsWith("//") || line == "")
                {
                    continue;
                }
                string[] parts = line.Split(new string[] { "=" }, StringSplitOptions.None);
                if (parts[0] == key)
                {
                    return parts[1];
                }
            }
            Console.WriteLine("Не найден ключ переданный в метод!");
            return "";
        }

        /// <summary>
        /// Записывает значение по ключу, если ключа не существует
        /// </summary>
        /// <param name="key">Ключ, значение которого нужно записать</param>
        /// <param name="value">Значение которое нужно записать</param>
        public void Write(string key, string value)
        {
            if (!File.Exists("Config.txt"))
            {
                File.Create("Config.txt");
            }
            string[] cfgLines = File.ReadAllLines("Config.txt", Encoding.UTF8);

            foreach (string line in cfgLines)
            {
                if (line.StartsWith("//") || line == "")
                {
                    continue;
                }
                string[] parts = line.Split(new string[] { "=" }, StringSplitOptions.None);
                if (parts[0] == key)
                {
#if DEBUG
                    Console.WriteLine("Ключ уже записан: используйте OverrideWrite для перезаписи!");
#endif
                    return;
                }
            }
            string cookedstring = key + "=" + value + Environment.NewLine;
            File.AppendAllText("Config.txt", cookedstring, Encoding.UTF8);
            return;
        }

        /// <summary>
        /// Записывает значение по ключу в любом случае, даже если ключ уже существует.
        /// </summary>
        /// <param name="key">Ключ, значение которого нужно записать</param>
        /// <param name="value">Значение которое нужно записать</param>
        public void OverrideWrite(string key, string value)
        {
            if (!File.Exists("Config.txt"))
            {
                File.Create("Config.txt");
            }
            string[] cfgLines = File.ReadAllLines("Config.txt", Encoding.UTF8);
            foreach (string line in cfgLines)
            {
                if (line.StartsWith("//") || line == "")
                {
                    continue;
                }
                string[] parts = line.Split(new string[] { "=" }, StringSplitOptions.None);
                if (parts[0] == key)
                {
                    string rval = Read(key);
                    string searchobject = key + "=" + rval;
                    int index = Array.IndexOf(cfgLines, searchobject);
                    var listwhatever = new List<string>(cfgLines);
                    listwhatever.RemoveAt(index);
                    listwhatever.Add(key + "=" + value);
                    cfgLines = listwhatever.ToArray();
                    File.Delete("Config.txt");
                    File.WriteAllLines("Config.txt", cfgLines, Encoding.UTF8);
                    return;
                }
            }
            string cookedstring = key + "=" + value;
            File.AppendAllText("Config.txt", cookedstring, Encoding.UTF8);
            return;
        }
    }
}
