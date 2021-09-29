using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

/**
 * Name : Hamza Eliraqy
 * Lab1
 * Student number : 40976448
 */
namespace Lab1CH
{
    class Program
    {
        static IList<string> words = new List<string>();
        static void Main(string[] args)
        {
            int numChoice;
            char charChoice;
            Program p = new Program();
            
            do
            {
                numChoice = 0;
                charChoice = 'a';

                Console.WriteLine("     ");
                Console.WriteLine("Hello World!! My First C# App");
                Console.WriteLine("Options");
                Console.WriteLine("---------");
                Console.WriteLine("1 - Import Words From File");
                Console.WriteLine("2 - Bubble Srot Words");
                Console.WriteLine("3 - LINQ/Lambda Sort Words");
                Console.WriteLine("4 - Count The Distinct Words");
                Console.WriteLine("5 - Take The First 10 Words");
                Console.WriteLine("6 - Get The Number Of Words That Start With 'j' And Display The Count");
                Console.WriteLine("7 - Get And Display The number Of Words That End With 'd' And Display The Count");
                Console.WriteLine("8 - Get And Display Of Words That Are Greater Than 4 Characters Long, And Display The Count");
                Console.WriteLine("9 - Get And Display Of Words That Are Less Than 3 Characters Long And Start With The Letter 'a', And Display The Count");
                Console.WriteLine("x - Exit");
                Console.WriteLine("    ");
                Console.WriteLine("Make a Selection : ");

               var choice = Console.ReadLine();

                bool parseSuccess = int.TryParse(choice, out numChoice);
                bool parseSuccers2 = char.TryParse(choice, out charChoice);
               

                switch (numChoice)
                {
                    case 1: //import words from file
                       
                        p.readFromFile();
                       
                        break;

                    case 2: //bubble sort
                       
                        Console.WriteLine("Bubble Sort");
                        var watch = new System.Diagnostics.Stopwatch();
                        watch.Start();
                        p.BubbleSort(words);
                        watch.Stop();
                        Console.WriteLine($"Time Elapsed : {watch.ElapsedMilliseconds}ms");
                        
                        break;

                    case 3:     //LINQ 

                        Console.WriteLine(" ");
                        var watchQ = new System.Diagnostics.Stopwatch();
                        watchQ.Start();
                        IEnumerable<string> query = from word in words
                                                    orderby word.Length
                                                    select word;
                        foreach (string str in query);
                        watchQ.Stop();
                        Console.WriteLine($"Time Elapsed : {watchQ.ElapsedMilliseconds}ms");
                            
                        break;

                    case 4:  //Count distinct words

                        int res = (from x in words select x).Distinct().Count();
                        Console.WriteLine("  ");
                        Console.WriteLine("Number of distinct words is : " + res);
                        break;

                    case 5:     //Get first 10 words

                        Console.WriteLine(" ");
                        Console.WriteLine("The first 10 words are : ");
                        var watchA = new System.Diagnostics.Stopwatch();
                        watchA.Start();
                        IEnumerable<string> query10 = from word in words
                                                      select word;
                        int h = 0;
                        foreach (string str in query10)
                        {
                            h++;
                            Console.WriteLine(str);
                            if(h == 10)
                            {
                                break;
                            }
                        }
                        /*for(int i = 0; i < 10; i++)   //Regular method
                        {
                            Console.WriteLine(words[i]);
                        }*/
                        watchA.Stop();
                        Console.WriteLine($"Time Elapsed : {watchA.ElapsedMilliseconds}ms");
                        break;

                    case 6:     //Get number of words that start with 'j'

                        Console.WriteLine(" ");
                        int countJ = 0;
                        char j = 'j';
                        for(int i = 0; i < words.Count(); i++)
                        {
                            string word;
                            word = words[i];
                            if (word[0].CompareTo(j) == 0)
                            {
                                Console.WriteLine(word);
                                countJ++;
                            }
                        }
                        Console.WriteLine(countJ);
                        break;

                    case 7:     //Get number of words that end with 'd'

                        Console.WriteLine("  ");
                        int countD = 0;
                        char d = 'd';
                        int z;
                        for(int i = 0; i < words.Count(); i++)
                        {
                            string word;
                            word = words[i];
                            for(z = 0; z < word.Count(); z++)
                            {

                            }
                            if(word[z-1].CompareTo(d) == 0)
                            {
                                Console.WriteLine(word);
                                countD++;
                            }
                        }
                        Console.WriteLine("Number of words that end with d : " + countD);
                       
                        break;

                    case 8:     //Get words that are longer than 4 chars
                        
                        Console.WriteLine("   ");
                        int countL = 0;
                        for(int i = 0; i < words.Count(); i++)
                        {
                            string word;
                            word = words[i];
                            if(word.Count() > 4)
                            {
                                countL++;
                                Console.WriteLine(word);
                            }
                        }
                        Console.WriteLine("Number of words longer than 4 characters is : " + countL);
                       
                        break;

                    case 9:     //Get words less than 3 chars and start with 'a'

                        Console.WriteLine(" ");
                        int countC = 0;
                        char a = 'a';
                        for(int i = 0; i < words.Count(); i++)
                        {
                            string word;
                            word = words[i];
                            if(word.Count() < 3 && word[0].CompareTo(a) == 0)
                            {
                                countC++;
                                Console.WriteLine(word);
                            }
                        }
                        Console.WriteLine("Number of words less than 4 characters and start with 'a' is : " + countC);
                     
                        break;

                    default:
                        Console.WriteLine("Invalid Input");
                        break;
                }
                 

            } while (charChoice != 'x');
        }
        /**
         * Read from file line by line and adds it to list 
         */
        void readFromFile()
        {
            try
            {
                words.Clear();
                string word;
                //IList<string> aWords = new List<string>();
                StreamReader fileRead = new StreamReader("Words.txt");
                while ((word = fileRead.ReadLine()) != null)
                {
                    words.Add(word);
                }
                Console.WriteLine("Number of words : " + words.Count());
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine("FILE NOT FOUND!");
            }
        }
        /**
         * Sort arrayList using bubble sort 
         */
        IList<string> BubbleSort(IList<string> words)
        {
            try
            {
                int length = words.Count();
                string word;
                //Console.WriteLine("in bb");
                for (int i = 0; i < length; i++)
                {
                    for (int j = 0; j < length - 1; j++)
                    {
                        if (words[j].CompareTo(words[j + 1]) > 0)
                        {
                            word = words[j];
                            words[j] = words[j + 1];
                            words[j + 1] = word;

                        }

                    }
                }
            }
            catch(IndexOutOfRangeException i)
            {
                Console.WriteLine("Index out of range");
            }
            return words;
        }
    }
}
