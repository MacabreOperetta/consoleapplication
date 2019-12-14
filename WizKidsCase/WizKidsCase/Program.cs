using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WizKidsCase
{
    class Program
    {
        static void Main(string[] args)
        {
            string answer;
            do
            {
                Console.WriteLine("Please select one of these functions");
                Console.WriteLine("1)Check the word is palindrome or not");
                Console.WriteLine("2)Foo Bar");
                Console.WriteLine("3)Valid Emails");
                Console.WriteLine("4)Word Generator");
                Console.WriteLine("5)Exit");
                Console.WriteLine("Please select your option");
                answer = Console.ReadLine();

                switch(Convert.ToInt32(answer))
                {
                    case 1:
                        Console.WriteLine("Please enter a word:");
                        string word = Console.ReadLine();
                        Console.WriteLine(isPalindrome(word));
                        Console.WriteLine("");
                        break;
                    case 2:
                        FooBarReturner();
                        Console.WriteLine("");
                        break;
                    case 3:
                        Console.WriteLine("Please enter pharagraph");
                        string pharagraph = Console.ReadLine();
                        EmailValidator(pharagraph);
                        break;
                    case 4:
                        Console.WriteLine("1)Alternavite words of test");
                        Console.WriteLine("2)Calculate word size");
                        Console.WriteLine("Please select a option:");
                        string option = Console.ReadLine();
                        if(Convert.ToInt32(option)==1)
                        {
                            Wordgenerator("test");
                            Console.WriteLine("");
                        }
                        if (Convert.ToInt32(option) == 2)
                        {
                            Console.WriteLine("Please enter word size");
                            string size = Console.ReadLine();
                            Console.WriteLine("Please enter alphabet lenght");
                            string alphabet = Console.ReadLine();
                            calculate(Convert.ToInt32(size), Convert.ToInt32(alphabet));
                            Console.WriteLine("");
                        }
                        break;
                    case 5:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid Input");
                        break;

                }
            } while (true);
        }
        public static bool isPalindrome(string myString)
        {
            myString = myString.ToLower();
            string first = myString.Substring(0, myString.Length / 2);
            char[] arr = myString.ToCharArray();

            Array.Reverse(arr);

            string temp = new string(arr);
            string second = temp.Substring(0, temp.Length / 2);

            return first.Equals(second);
        }
        public static void FooBarReturner()
        {
            string foo = "Foo";
            string bar = "Bar";
            for (int i= 0;i<100;i++)
            {
                if((i+1)%15==0)
                {
                    Console.WriteLine(foo + bar);
                }
                else if((i+1)%5==0)
                {
                    Console.WriteLine(bar);
                }
                else if((i + 1) % 3 == 0)
                {
                    Console.WriteLine(foo);
                }
                else
                {
                    Console.WriteLine(i + 1);
                }
            }
        }
        public static void EmailValidator(string paragraph)
        {
            string[] separators = new string[] { ",", "!", "\'", " ", "\'s" };
            Console.WriteLine("Valid Email List");
            foreach (string word in paragraph.Split(separators, StringSplitOptions.RemoveEmptyEntries))
                if(word.Contains("@"))
                {
                    var foo = new EmailAddressAttribute();
                    if(foo.IsValid(word))
                    {
                        Console.WriteLine(word);
                    }
                }
            Console.WriteLine();
        }
        public static void Wordgenerator(string word)
        {
            var wordlist = new List<string>();
            StringBuilder myStringBuilder = new StringBuilder(word);
            string alpha = "abcdefghijklmnopqrstuvwxyz";
            for (int i =0; i<word.Length;i++)
            {
                wordlist.Add(word.Remove(i, 1));
            }
            foreach (var c in alpha)
            {
                for (int i =0;i<=word.Length;i++)
                {
                    myStringBuilder.Insert(i, c);            
                    wordlist.Add(myStringBuilder.ToString());
                    myStringBuilder = new StringBuilder(word);
                }
            }
            for (int i = 0; i < word.Length; i++)
            {
                foreach(var c in alpha)
                {
                    wordlist.Add(word.Replace(word[i], c));
                }
            }
            for (int i = 0; i< word.Length-1;i++)
            {
                myStringBuilder[i] = word[i + 1];
                myStringBuilder[i + 1] = word[i];
                wordlist.Add(myStringBuilder.ToString());
                myStringBuilder = new StringBuilder(word);
            }
            for (int i = 0; i < wordlist.Count; i++)
            {
                Console.WriteLine(wordlist[i]);
            }
        }
        public static void calculate(int size,int alphabetsize)
        {
            int total = 0;
            total += size;
            total += (size + 1) * alphabetsize;
            total += size * alphabetsize;
            total += size - 1;
            Console.WriteLine(total);
        }
    }
}

