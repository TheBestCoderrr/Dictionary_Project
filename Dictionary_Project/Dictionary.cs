using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Soap;
using BinaryFormatter;
using System.Xml.Serialization;
using System.Runtime.Serialization;

namespace Dictionary_Project
{
    internal class Dictionary
    {

        public Dictionary(Language language) {
            dictionary = new WordsList[language.CountLettersInAlphabet];
            for(int i = 0; i < language.CountLettersInAlphabet; i++)
            {
                dictionary[i] = new WordsList();
                dictionary[i].Key = language.Alphabet[i];
            }
        }
        [DataMember]
        public WordsList[] dictionary;
        public bool AddWord(Word word)
        {
            char letter = char.ToUpper(word.originalWord[0]);
            foreach(var list in dictionary)
            {
                if (letter == list.Key)
                {
                    try
                    {
                        list.FindWord(word.originalWord);
                    }
                    catch(Exception ex)
                    {
                        list.words.Add(word);
                        return true; 
                    }
                }
            }
            return false;
        }
        public bool RemoveWord(string word)
        {
            char letter = char.ToUpper(word[0]);
            foreach (var list in dictionary)
            {
                if (letter == list.Key)
                {
                    Word w = list.FindWord(word);
                    bool correct = list.words.Remove(w);
                    if (correct)
                        return true;
                }
            }
            return false;
        }
        public Word FindWord(string word)
        {
            char letter = char.ToUpper(word[0]);
            foreach (var list in dictionary)
            {
                if (letter == list.Key)
                {
                    return list.FindWord(word);                
                }
            }
            throw new Exception();
        }

        public void Save(string file)
        {
            using (Stream stream = File.Create(file))
            {
                new SoapFormatter().Serialize(stream, dictionary);
            }
        }
        public void Load(string file)
        {
            using (Stream stream = File.OpenRead(file))
            {
                dictionary = new SoapFormatter()?.Deserialize(stream) as WordsList[];
            }
        }

    }
}
