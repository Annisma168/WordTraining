﻿using System.ComponentModel.DataAnnotations.Schema;

namespace WordTraining
{
    internal class Program
    {

        private static List<(string foreign, string native)> dictionary = new();
        static void Main(string[] args)
        {
            
            for (int i = 0; i >= 0; i++)
            {
                Console.WriteLine("What do you want to do? \nWrite \"1\" for creating a new pair of words. \nWrite \"2\" for playing the remember game.\nWrite \"3\" to exit.");
                string userInput = Console.ReadLine();
                if (userInput == "1")
                { 
                    NewPair();
                    for (int j = 0; j >= 0; j++)
                    {
                        Console.WriteLine("Do you want to add a new pair again? (y = yes / n = no)");
                        string newPair = Console.ReadLine();
                        if (newPair != null && newPair == "y")
                        {
                            NewPair();
                        }

                        else if (newPair != null && newPair == "n") break;

                        else Console.WriteLine("\nAnswer is not recognised. Try again.\n"); 
                    }
                
                }
                else if (userInput == "2")
                {
                    if (dictionary.Count == 0)
                    {
                        Console.WriteLine("\nThe dictionary is empty. Add some pairs first.\n");
                    }
                    else
                    {
                        RememberWords();
                        for (int j = 0; j >= 0; j++)
                        {
                            Console.WriteLine("Do you want to translate another word? (y = yes / n = no)");
                            string newGame = Console.ReadLine();
                            if (newGame != null && newGame == "y")
                            {
                                RememberWords();
                            }

                            else if (newGame != null && newGame == "n") break;

                            else Console.WriteLine("\nAnswer is not recognised. Try again.\n");
                        }
                    }
                }
                else if (userInput == "3")
                {
                   Exit();
                return;
                }
                else { Console.WriteLine("\nAnswer is not recognised. Try again.\n"); }
            }
            
        }
        static void NewPair()
        {
            //input of words
            int totalWords = 100;
            
            for (int i = 0; i < totalWords; i++)
            {
                
                for(int j = 0; j >= 0; j++) 
                {
                Console.WriteLine("\nWrite a new word in a foreign language:");
                string foreign = Console.ReadLine().Replace(" ", "");
                    if (string.IsNullOrEmpty(foreign))
                    {
                        Console.WriteLine("\nIt is empty. Try again\n");
                       
                    }
                    else
                    {
                        Console.WriteLine("Write a new word in your native language:");
                        string native = Console.ReadLine().Replace(" ", "");
                        if (string.IsNullOrEmpty(native))
                        {
                            Console.WriteLine("\nIt is empty. Try again\n");
                        }
                        else
                        {
                            dictionary.Add((foreign, native));
                            Console.WriteLine($"\nYour pair {foreign} = {native} is saved\n");
                            return;
                        }
                    }
                }
            
            }
        }
        static void RememberWords()
        {
            
          
            Random random = new Random();
            for (int i = 0; i < dictionary.Count; i++)
            {
                int randomIndex = random.Next(dictionary.Count);
                string randomForeign = dictionary[randomIndex].foreign;
                Console.WriteLine($"What is the translation of '{randomForeign}'?");
                string userTranslate = Console.ReadLine().Replace(" ", "");
                if (string.IsNullOrEmpty(userTranslate))
                {
                    Console.WriteLine("\nIt is empty. Try again\n");
                }
                else if (userTranslate.ToLower() == dictionary[randomIndex].native.ToLower())
                {
                    Console.WriteLine("\nCorrect!\n");
                    return;
                }
                else
                {
                    Console.WriteLine($"Wrong. The correct answer is: {dictionary[randomIndex].native}");
                    return;

                }
            }
            
        }
        static void Exit()
        {
            Console.WriteLine($"Thank you for playing! Press any button to exit...");
            Console.ReadKey();
        }
    }
}