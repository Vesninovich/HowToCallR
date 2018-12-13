using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.R.Host.Client;

namespace RToCSTest
{
    public class RHostClientCaller
    {
        private IRHostSession session;
        private Task task;

        private string scriptPath;

        private bool scriptExecuted = false;

        public RHostClientCaller(string scriptPath)
        {
            this.scriptPath = scriptPath;
            session = RHostSession.Create("Test");
            task = session.StartHostAsync(new RHostSessionCallback());
        }

        public async Task CallMyFunction(double x, double y)
        {
            await task;
            if (!scriptExecuted)
            {
                await session.ExecuteAsync(File.ReadAllText(scriptPath));
                // Можно попробовать так
                //await session.ExecuteAsync("source('full\\path\\to\\Script.R')");
                scriptExecuted = true;
            }

            var res = await session.ExecuteAndOutputAsync($"my.f({x}, {y})");
            Console.WriteLine(res.Output);
        }
    }
}
