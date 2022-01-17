namespace AsyncDemo
{
    public class Program
    {
        public static void Main()
        {
            long sum = 0;

            Task.Run(() =>
            {
                for (long i = 0; i < 1000000000; i++)
                {
                    sum += i;
                    Thread.Sleep(1000);
                }
            });

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "show")
                {
                    Console.WriteLine(sum);
                }
                else if (command == "exit")
                {
                    return;
                }
            }
        }
    }
}