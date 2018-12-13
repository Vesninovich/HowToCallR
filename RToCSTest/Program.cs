using System;

namespace RToCSTest
{
    class Program
    {
        private const string scriptPath = "Path\\\\To\\\\Script.R";

        static void Main(string[] args)
        {
            double x = 0;
            double y = 0;

            // Не доделано
            //RProcessCaller rProcessCaller
            //    = new RProcessCaller(scriptPath);

            // R.NET пока (12.12.18) не работает с R версии 3.5+
            // см. https://github.com/jmp75/rdotnet/issues/70
            RdotNetCaller rdotNetCaller
                = new RdotNetCaller(scriptPath);

            RHostClientCaller rHostClientCaller
                = new RHostClientCaller(scriptPath);

            GetUserInput(out x, out y);

            // Не доделано
            //Console.Write("Result from calling R process: ");
            //rProcessCaller.CallMyFunction(x, y);
            //rProcessCaller.WriteAllStdout();

            Console.Write("Result from R.NET: ");
            rdotNetCaller.CallMyFunction(x, y);

            Console.Write("Result from Microsoft.R.Host.Client: ");
            rHostClientCaller.CallMyFunction(x, y).Wait();
        }

        private static void GetUserInput(out double x, out double y)
        {
            string textX = "";
            string textY = "";

            while (!double.TryParse(textX, out x))
            {
                Console.Write("X = ");
                textX = Console.ReadLine();
            }

            while (!double.TryParse(textY, out y))
            {
                Console.Write("Y = ");
                textY = Console.ReadLine();
            }
        }
    }
}
