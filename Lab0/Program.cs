namespace Lab0
{
    /// <summary>
    /// Basics of C# activity
    /// Author: Martin Maquilan (martin.maquilan@edu.sait.ca)
    /// Date: Sept 15, 2023
    /// </summary>
    internal class Program
    {
        static void Main(string[] args)
        {
            double low;
            double high;

            Console.WriteLine("Enter a low number: ");
            low = double.Parse(Console.ReadLine());

            while (low < 0)
            {
                Console.WriteLine("Please enter a positive number.");

                Console.WriteLine("Enter a low number: ");
                low = double.Parse(Console.ReadLine());
            }

            Console.WriteLine("Enter a high number: ");
            high = double.Parse(Console.ReadLine());
            
            while (high < low)
            {
                Console.WriteLine("Please enter a number higher than the low number");

                Console.WriteLine("Enter a high number: ");
                high = double.Parse(Console.ReadLine());
            }

            double difference = high - low;
            Console.WriteLine($"The difference between the two numbers is {difference}");
            double[] numsArray = new double[(int)Math.Ceiling(difference)];

            for (double n = low, i = 0; n <= high && i < difference; n++, i++)
            {
                numsArray[(int)i] = n;
            }

            StreamWriter write = File.CreateText("data.txt");

            for (int i = numsArray.Length - 1; i >= 0; i--)
            {
                write.WriteLine(numsArray[i]);
            }

            write.Close();

            Console.WriteLine("Wrote to file");

            double sum = 0;

            using (StreamReader reader = new StreamReader("data.txt"))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    double number;
                    if (double.TryParse(line, out number))
                    {
                        sum += number;
                    }
                }
            }

            double roundedSum = Math.Round(sum, 2);

            Console.WriteLine($"The sum of the numbers in the file is {roundedSum}");

            Console.WriteLine("The prime numbers between the low and high numbers are: ");
            for(double n = low; n <= high; n++)
            {
                if (IsPrime(n))
                {
                    Console.WriteLine(n);
                }
            }
        

        static bool IsPrime(double n)
            {
                for (double denominator = n - 1; denominator > 1; denominator--)
                {
                    double remainder = n % denominator;

                    if (remainder == 0)
                        return false;
                }

                return true;
            }
        }
    }
}