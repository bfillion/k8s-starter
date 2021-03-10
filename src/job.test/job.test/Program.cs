using System;

namespace job.test
{
    class Program
    {
        static void Main(string[] args)
        {
            var err =
            Environment.GetEnvironmentVariable("ERR");

            string arg = "";

            if (args.Length > 0)
            {
                arg = args[0];
            }

            Console.WriteLine("Hello World!" + " Arg : " + arg);
        }
    }
}
