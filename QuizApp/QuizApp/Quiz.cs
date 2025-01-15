using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp
{
    internal class Quiz
    {
        private Question[] _questions;
        private int _score;


        // Constructor
        public Quiz(Question[] questions)
        {
            _questions = questions;
            _score = 0; 
        }



        //Method to Start the Quiz using the other methods in this Class
        public void StartQuiz()
        {
            Console.WriteLine("Welcome to the Quiz!");
            int questionNumber = 1; //to display question numbers

            foreach (Question question in _questions)
            //Iterate in every the question from the array of questions passed to the constructor   
            {
                Console.WriteLine($"Question {questionNumber++}:");

                DispayQuestion(question);

                //Checking User Input using the bool method from the question Class
                int userChoice = GetUserChoice();
                if (question.IsCorrectAnswers(userChoice))
                {
                    Console.WriteLine("Correct!");
                    _score++;

                }else
                {                                                       //in the array of answers for this question,
                                                                        //i`m accessing the value of the correct one
                                                                        //in the right index
                    Console.WriteLine($"Wrong, The correct answer was: {question.Answers[question.CorrectAnswerIndex]}");
                }
            }
            //After Start the Quiz, Display the Question, Check the Answer and Give a score: 
            DisplayResults();
        }


        //Method to Display Questions
        private void DispayQuestion(Question question)
        {
            //Print the text
            //Some visual configs
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("╔═════════════════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║                                 Question                                ║");
            Console.WriteLine("╚═════════════════════════════════════════════════════════════════════════╝");
            Console.ResetColor();
            Console.WriteLine(question.QuestionText);  


            //Print all the answers one by one in the array
            //Some visual configs as well
            for(int i = 0; i < question.Answers.Length; i++)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("   ");
                Console.Write(i + 1); //Displaying Question stating at 1
                Console.ResetColor(); //Reset foreground Color

                Console.WriteLine($". {question.Answers[i]}");
            }
        }



        //Method to Deal with the user input
        private int GetUserChoice()
        {
            Console.Write("Your answer (number): ");
            string input = Console.ReadLine();
            int choice = 0;


            //Checking User choice

            //int.TryParse check if its a number
            //!intTryParse check if it is not a number
            //While it is not a number or the choice is less than 1 or greater the 4:
            while (!int.TryParse(input, out choice) || choice < 1 || choice > 4)
            {
                Console.WriteLine("Invalid choice. Please enter a number between 1 and 4:");
                input = Console.ReadLine();
            }

            //Valid choice:
            return choice -1; //ajust to 0 index array (User choice is 1-4, but the index is 0-3)

        }

        //Method for the results and score
        private void DisplayResults()
        {
            //Visual Configs
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("╔═════════════════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║                                 Results                                 ║");
            Console.WriteLine("╚═════════════════════════════════════════════════════════════════════════╝");
            Console.ResetColor();

            //Print How many questions the used guessed right out of the number of questions
            Console.WriteLine($"Quiz finished. Your score is: {_score} out of {_questions.Length}");

            //Print a color full message deppending on the percentage of right answers 
            double percentage = (double)_score / _questions.Length;
            if (percentage >= 0.8)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Excellent Work!");
            }
            else if (percentage >= 0.5)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Good effort!");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Keep practicing");
            }
            Console.ResetColor();
        }

    }   
}
