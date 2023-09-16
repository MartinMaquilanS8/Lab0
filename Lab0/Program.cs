namespace Lab0
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int low;
            int high;

            Console.WriteLine("Enter a low number: ");
            low = int.Parse(Console.ReadLine());

            while (low < 0)
            {
                Console.WriteLine("Please enter a positive number.");

                Console.WriteLine("Enter a low number: ");
                low = int.Parse(Console.ReadLine());
            }

            Console.WriteLine("Enter a high number: ");
            high = int.Parse(Console.ReadLine());
            
            while (high < low)
            {
                Console.WriteLine("Please enter a number higher than the low number");

                Console.WriteLine("Enter a high number: ");
                high = int.Parse(Console.ReadLine());
            }

            int difference = high - low;
            Console.WriteLine($"The difference between the two numbers is {difference}");
            int[] numsArray = new int[difference];

            for (int n = low, i = 0; n <= high && i < difference; n++, i++)
            {
                numsArray[i] = n;
            }

            StreamWriter write = File.CreateText("data.txt");

            for (int i = numsArray.Length - 1; i >= 0; i--)
            {
                write.WriteLine(numsArray[i]);
            }

            write.Close();

            Console.WriteLine("Wrote to file");

        }
    }
}