using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp
{
    internal class Question
    {

        public string QuestionText { get; set; }

        public string[] Answers { get; set; }

        public int CorrectAnswerIndex { get; set; }
        //for the correct Answer in Answers Array


        //Constructor

        //This constructor is colleting:
        //The Text for the question (string),
        //The answers for the questions (array),
        //The correct answers for it (the right index in the array of answers)
        public Question(string questionText, string[] answers, int correctAnswearIndex)
        {
            QuestionText = questionText;
            Answers = answers;
            CorrectAnswerIndex = correctAnswearIndex;
        }



        //Bool Method to check the correct Answear 
        public bool IsCorrectAnswers(int choice)
        {
            return CorrectAnswerIndex == choice;
        }


    }
}
