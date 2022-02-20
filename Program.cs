using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectQ1

{
    class Program
    {   
        static int  GetInputFormUser(string discripation)
        {
            bool flag = true;
            string numString = "";
            while (flag)
            {
                Console.WriteLine($"\n{discripation}");
                 numString = Console.ReadLine();

                if (IsNumber(numString))
                    flag = false;
                else 
                    ERR();
            }
              
            return Convert.ToInt32(numString);
        }
        static bool IsNumber(string numString)
        {
            int numericValue = 0;
            bool isNumber = int.TryParse(numString, out numericValue);

            return isNumber;
        }
        static void ERR()
        {
            Console.WriteLine("Wrong input Please try again!\n");
        }
        static void Print(string text)
        {
            Console.WriteLine($"\n{text}");
        }
        static string DisplaGameTitleAndgetName()
        {
            Console.WriteLine("\n\t\t\t\t----------------------------------\n\t\t\t\t|  Welcome to the guessing game  |");
            Console.WriteLine("\t\t\t\t----------------------------------\n\t\t\t\t\n\n");
            Console.Write("Please enter your 'Name' : ");
            string userName = Console.ReadLine();
            return userName;
        }
        static void DisplaGameDescription(string userName)
        {
            Console.WriteLine($"\nWelcome {userName} in this game we will generate a random number between 50 and 75 and\n" +
                $"You have to guess it right,\nYou have only 5 attempts to guess the number, This game is divided" +
                $" into 3 levels:\n\nDifficulties :\n" +
                $"------------------------------------------------------------\n" +
                $"level 1 (Easy) the generated number will be from 50-55\n\n" +
                $"Points:\n" +
                $"if you guessed it from the 1st time you will earn 10 points,\n" +
                $"2nd time you will earn 7 points,\n" +
                $"3rd time you will earn 5 points,\n" +
                $"4th time you will earn 2 points,\n" +
                $"5th time you will earn 1 point.\n" +
                $"------------------------------------------------------------\n" +
                $"level 2 (Medium) the generated number will be from 50-60\n\n" +
                $"Points:\n" +
                $"1st time you will earn 20 points,\n" +
                $"2nd time you will earn 14 points,\n" +
                $"3rd time you will earn 10 points,\n" +
                $"4th time you will earn 4 points,\n" +
                $"5th time you will earn 2 point.\n" +
                $"------------------------------------------------------------\n" +
                $"level 3 (Hard) the generated number will be from 50-75\n\n" +
                $"Points:\n" +
                $"1st time you will earn 40 points,\n" +
                $"2nd time you will earn 28 points,\n" +
                $"3rd time you will earn 20 points,\n" +
                $"4th time you will earn 8 points,\n" +
                $"5th time you will earn 4 point.\n" +
                $"------------------------------------------------------------\n\n");
        }
        static int GenerateRandomNumber(int x, int y)
        {
            Random obj = new Random();

            return obj.Next(x, y);
        }
        static int AddToScore(int numberAttempts, int countStage)
        {
            int res = 0;
            switch (numberAttempts)
            {
                case 1: res = (countStage == 1)? 10 :(countStage == 2)? 20 : 40; break;
                case 2: res = (countStage == 1)? 7 : (countStage == 2) ?14 : 28; break;
                case 3: res = (countStage == 1)? 5 : (countStage == 2) ?10 : 20; break;
                case 4: res = (countStage == 1)? 2 : (countStage == 2) ?4 : 8; break;
                default: res = (countStage == 1)? 1 :(countStage == 2)? 2 : 4; break;
            }
            return res;
        }
        static string Rank(int numberAttempts)
        {
            string rank = "";
            switch (numberAttempts)
            {
                case 1:rank = "1st";break;
                case 2: rank = "2nd"; break;
                case 3: rank = "3rd"; break;
                case 4: rank = "4th"; break;
                default: rank = "5th"; break;
            }
            return rank;
        }

        static void Main(string[] args)
        {
            string userName = DisplaGameTitleAndgetName();
            DisplaGameDescription(userName);

            int numberToStartGa = GetInputFormUser("| If you are ready Enter (1) to start, In any given time Enter (0) to Exit. |");

            int randomNumber = GenerateRandomNumber(50,55);

            int guessedNumber, countAttempts = 0, score = 0, countStage = 1;


            
            if (numberToStartGa == 1)
            {
                guessedNumber =GetInputFormUser($"(Level: {countStage}) We generated number between {((countStage == 1) ? "(50 & 55)" : (countStage == 2) ? "(50 & 60)" : "(50 & 75)")} " +
                    $"Please Enter your guess OR Enter (0) to Exit :");
                while ( guessedNumber != 0)
                {
                    countAttempts++;
                    if(guessedNumber == randomNumber)
                    {
                        score += AddToScore(countAttempts ,countStage);
                       
                        if (countStage == 3)
                        {
                            Print($"'Congratulations', you won the game and finished all the levels (^_^)\n" +
                                $" you finshed level 3 in the '{Rank(countAttempts)}' attempts \n"+
                                $" you earn '{AddToScore(countAttempts,countStage)}' points .");
                            break;
                        }
                        
                       
                        numberToStartGa = GetInputFormUser($"'Congratulations', you won in the '{Rank(countAttempts)}' attempts\n" +
                                          $" you earn '{AddToScore(countAttempts,countStage)}' points and passed Level '{countStage}'\n" +
                                           $" Enter(1) to move to the next Level, and(0) to Exit.");
                        if (numberToStartGa == 1)
                        {
                            countStage++;
                            countAttempts = 0;
                            if(countStage == 2)
                            randomNumber = GenerateRandomNumber(50, 60);
                            else
                            randomNumber = GenerateRandomNumber(50, 75);

                        }
                        else
                        {
                           break;
                        }                        

                    }
                    else
                    {
                        Print($"Wrong guess.. you have {5 - countAttempts} Attempt left : ");
                    }

                    if(countAttempts == 5 && randomNumber != guessedNumber)
                    { 
                        numberToStartGa = GetInputFormUser($"Game Over the number is '{randomNumber}' Enter(1) to start again, and(0) to Exit");
                        if (numberToStartGa == 1)
                        {
                            countAttempts = 0;
                            switch (countStage)
                            {
                                case 1: randomNumber = GenerateRandomNumber(50, 55);break;
                                case 2: randomNumber = GenerateRandomNumber(50, 60); break;
                                case 3: randomNumber = GenerateRandomNumber(50, 75); break;

                            }
                        }
                        else
                        {
                            break;
                        }
                    }

                    if (numberToStartGa != 0 && countAttempts != 5 && guessedNumber != 0)
                        guessedNumber = GetInputFormUser($"(Level: {countStage}) We generated number between {((countStage == 1) ? "(50 & 55)" : (countStage == 2) ? "(50 & 60)" : "(50 & 75)")} " +
                         $"Please Enter your guess OR Enter (0) to Exit :");

                }

            }
            

            Print($"Name : {userName}\nScore : {score}\nLevel : {countStage}");
        }
    }
}
