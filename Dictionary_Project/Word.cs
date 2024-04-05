using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Dictionary_Project
{
    [Serializable]
    internal class Word
    {
        public Word(string originalWord, List<string> translation) {
            this.originalWord = originalWord;
            this.translation = translation;
        }
        public string? originalWord { get; set; }
        public List<string>? translation { get; set; }
        public void AddTranslateWord(string word)
        {
            if (translation.IndexOf(word) != -1) throw new Exception("Error. Similar word");
            translation.Add(word);
        }
        public bool RemoveTranslateWord(string word)
        {
            if (translation.Count <= 1) return false;
            bool correct = translation.Remove(word);
            return correct? true:false;
        }
        public void SetOriginalWord(string new_Word)
        {
            originalWord = new_Word;
        }
        public bool SetTranslateWord(string word, string new_Word) {
            int index = translation.IndexOf(word);
            if (index == -1) return false;
            translation[translation.IndexOf(word)] = new_Word;
            return true;
        }
        public override string ToString() => $"|{originalWord}| - {string.Join(" | ", translation)}";
    }
}
