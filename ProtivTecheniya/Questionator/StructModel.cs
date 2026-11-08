using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProtivTecheniya.Questionator
{
    public class StructModel
    {
        public struct Question
        {
            public string question;
            public string incorrect;
            public string correct;

            public Question(string q, string i, string c)
            {
                question = q;
                incorrect = i;
                correct = c;
            }
        }
    }
}
