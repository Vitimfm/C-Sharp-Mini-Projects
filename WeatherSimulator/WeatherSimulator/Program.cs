using System.Runtime.CompilerServices;

namespace WeatherSimulator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter with a number of days to simulate: ");
            int days = int.Parse(Console.ReadLine());

            int[] temperature = new int[days]; 
            //list of temperatures with <days> lenght

            string[] conditions = { "Sunny", "Cloudy", "Rainy", "Snowy"};
            string[] weatherConditions = new string[days];

            Random random = new Random();


            for (int i = 0; i < days; i++)
            {
                temperature[i] = random.Next(-10, 40);
                if (temperature[i] >= 20)
                {
                    conditions = new string[] { "Sunny", "Cloudy", "Rainy"};
                }
                weatherConditions[i] = conditions[random.Next(conditions.Length)];
            }

            Console.WriteLine($"Average Temperature: {AverageTemperature(temperature)}");
            Console.WriteLine($"Minimal Temperature: {MinTemperature(temperature)}");
            Console.WriteLine($"Most Commom Condition: {MostCommonCondition(conditions)}");
            Console.ReadKey();

        }

        static double AverageTemperature(int[] temperature)
        {
            double sum = 0;
            for (int i = 0; i < temperature.Length; i++)
            {
                sum += temperature[i];
            }
            return sum / temperature.Length;
        }

        static int MinTemperature(int[] temperature)
        {
            int min = 0;

            foreach (int i in temperature)
            {
                if (i < min)
                {
                    min = i;
                }
            }
            return min;
        }

        static string MostCommonCondition(string[] conditions)
        {
            int count = 0;
            string mostCommon = conditions[0];
            //assuming the first one is the most common

            for (int i = 0; i < conditions.Length; i++)
            // interate all conditions 
            {
                int tempCount = 0;
                for (int j = 0; j < conditions.Length; j++)
                {
                    //Comparer the condition[i] index with all the other conditions in the array
                    //if repeats, increments the temporary counter 
                    if (conditions[j] == conditions[i])
      

                    {
                        tempCount++;
                    }
                }
                if (tempCount > count)
                //If repeats more, more the counter increases so that will be the most common
                {
                    count = tempCount;
                    mostCommon = conditions[i];

                }
            }

            return mostCommon;
        }
    }
}
