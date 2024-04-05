using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary_Project
{
    public class Language
    {
        public string? Type { get; set; }
        public int CountLettersInAlphabet { get; set; }
        public char[] Alphabet;
        public const int ENG = 26;
        public const int UKR = 33;
    }
}
