using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary_Project
{
    [Serializable]
    internal class WordsList
    {
        public WordsList() { words = new List<Word>(); }
        public char Key { get; set; }
        public List<Word> words;
        public Word FindWord(string word)
        {
            foreach(var w in words)
            {
                if (w.originalWord == word)
                    return w;
            }
            throw new Exception("Word not found");
        }
    }
}
