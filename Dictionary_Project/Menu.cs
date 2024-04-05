using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary_Project
{
    internal class Menu
    {
        static string ToUpperFirstLetter(string word)
        {
            char[] wordChars = word.ToCharArray();
            wordChars[0] = char.ToUpper(wordChars[0]);
            string modifiedWord = new string(wordChars);
            return modifiedWord;
        }
        public void SecondMenu(Language language)
        {
            Dictionary dictionary = new Dictionary(language);
            dictionary.Load($"Dictionary({language.Type}).txt");
            int user_choice = -1;
            while (user_choice != 0)
            {
                Thread.Sleep(3000);
                Console.WriteLine("0 - Back\n1 - Translate word\n2 - Add word\n3 - Add translate\n4 - remove word\n" +
                    "5 - remove translate\n6 - change word\n7 - change translate\n8 - save\n9 - load\n10 - export");
                Thread.Sleep(2000);
                Console.WriteLine("Enter variant: ");
                user_choice = int.Parse(Console.ReadLine());
                switch (user_choice)
                {
                    case 0:
                        dictionary.Save($"Dictionary({language.Type}).txt");
                        break;
                    case 1:
                        Console.WriteLine("Enter word: ");
                        string word = Console.ReadLine();
                        word = ToUpperFirstLetter(word);
                        try
                        {
                            Console.WriteLine(dictionary.FindWord(word).ToString());
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;
                    case 2:
                        Console.WriteLine("Enter original word: ");
                        word = Console.ReadLine();
                        word = ToUpperFirstLetter(word);
                        Console.WriteLine("Enter translate words: ");
                        string[] arr = Console.ReadLine().Split(" ");
                        List<string> words = new List<string>();
                        for (int i = 0; i < arr.Length; i++)
                        {
                            arr[i] = ToUpperFirstLetter(arr[i]);
                            words.Add(arr[i]);
                        }
                        bool IfAdd = dictionary.AddWord(new Word(word, words));
                        if(IfAdd == false) Console.WriteLine("Error. Add Similar word");
                        break;
                    case 3:
                        Console.WriteLine("Enter original word: ");
                        word = Console.ReadLine();
                        word = ToUpperFirstLetter(word);
                        Console.WriteLine("Enter translate word: ");
                        string tr_word = Console.ReadLine();
                        try
                        {
                            dictionary.FindWord(word).AddTranslateWord(tr_word);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;
                    case 4:
                        Console.WriteLine("Enter word: ");
                        word = Console.ReadLine();
                        word = ToUpperFirstLetter(word);
                        try
                        {
                            dictionary.RemoveWord(word);
                        }
                        catch (Exception ex) { Console.WriteLine(ex.Message); }
                        break;
                    case 5:
                        Console.WriteLine("Enter original word: ");
                        word = Console.ReadLine();
                        word = ToUpperFirstLetter(word);
                        Console.WriteLine("Enter translate word: ");
                        tr_word = Console.ReadLine();
                        tr_word = ToUpperFirstLetter(tr_word);
                        dictionary.FindWord(word).RemoveTranslateWord(tr_word);
                        break;
                    case 6:
                        Console.WriteLine("Enter word(find): ");
                        word = Console.ReadLine();
                        word = ToUpperFirstLetter(word);
                        Console.WriteLine("Enter word(change): ");
                        tr_word = Console.ReadLine();
                        tr_word = ToUpperFirstLetter(tr_word);
                        dictionary.FindWord(word).SetOriginalWord(tr_word);
                        break;
                    case 7:
                        Console.WriteLine("Enter word(find): ");
                        word = Console.ReadLine();
                        word = ToUpperFirstLetter(word);
                        Console.WriteLine("Enter translate word(find): ");
                        tr_word = Console.ReadLine();
                        tr_word = ToUpperFirstLetter(tr_word);
                        Console.WriteLine("Enter translate word(change): ");
                        string temp = Console.ReadLine();
                        temp = ToUpperFirstLetter(temp);
                        try
                        {
                            dictionary.FindWord(word).SetTranslateWord(tr_word, temp);
                        }
                        catch (Exception ex){ Console.WriteLine(ex.Message); }
                        break;
                    case 8:
                        dictionary.Save($"Dictionary({language.Type}).txt");
                        break;
                    case 9:
                        dictionary.Load($"Dictionary({language.Type}).txt");
                        break;
                    case 10:
                        temp = Console.ReadLine();
                        dictionary.Save($"{temp}");
                        break;
                    default:
                        Console.WriteLine("Invalid variant.");
                        break;
                }
            }
        }
        public void menu()
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            Console.InputEncoding = System.Text.Encoding.Unicode;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();

            int user_choice = -1;
            while(user_choice != 0)
            {
                Console.WriteLine("MENU:\n0 - End\n1 - ENG-UKR\n2 - UKR-ENG");
                Console.WriteLine("Enter variant: ");
                user_choice = int.Parse(Console.ReadLine());
                switch (user_choice)
                {
                    case 0:
                        break;
                    case 1:
                        Language English = new Language { Type = "ENG-UKR", Alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray(), CountLettersInAlphabet = 26 };
                        SecondMenu(English);
                        user_choice = -1;
                        break;
                    case 2:
                        Language Ukrainian = new Language { Type = "UKR-ENG", Alphabet = "АБВГҐДЕЄЖЗИІЇЙКЛМНОПРСТУФХЦЧШЩЬЮЯ".ToCharArray(), CountLettersInAlphabet = 33 };
                        SecondMenu(Ukrainian);
                        user_choice = -1;
                        break;
                    default: 
                        Console.WriteLine("Invalid variant.");
                        break;
                }
            }
        }
    }
}
