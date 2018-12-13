using System;
using System.Diagnostics;
using System.IO;

namespace RToCSTest
{
    // Общая идея, работоспособность не подтверждена
    public class RProcessCaller
    {
        private Process rProcess;
        private StreamWriter stdin;

        public RProcessCaller(string scriptPath)
        {
            rProcess = new Process();

            rProcess.StartInfo.FileName = "R.exe";
            rProcess.StartInfo.Arguments = "--vanilla";
            rProcess.StartInfo.UseShellExecute = false;
            rProcess.StartInfo.RedirectStandardInput = true;
            rProcess.StartInfo.RedirectStandardOutput = true;

            rProcess.Start();

            stdin = rProcess.StandardInput;

            stdin.WriteLine($"source('{scriptPath}')");
        }

        public void CallMyFunction(double x, double y)
        {
            stdin.WriteLine($"my.f({x}, {y})");
        }

        public void WriteAllStdout()
        {
            Console.WriteLine(rProcess.StandardOutput.ReadToEnd());
        }
    }
}