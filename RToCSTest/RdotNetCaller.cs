using System;
using RDotNet;

namespace RToCSTest
{
    // Пока (12.12.18) не работает с R версии 3.5+
    // см. https://github.com/jmp75/rdotnet/issues/70
    public class RdotNetCaller
    {
        private REngine engine;

        public RdotNetCaller(String scriptPath)
        {
            // Необязательно указывать, если в PATH нужная версия
            REngine.SetEnvironmentVariables(
                "D:\\Program Files\\R\\R-3.4.4\\bin\\i386",
                "D:\\Program Files\\R\\R-3.4.4"
            );
            engine = REngine.GetInstance();
            // Также можно считать просто из файла, как в RHostClientCaller
            engine.Evaluate($"source('{scriptPath}')");
        }

        public SymbolicExpression CallMyFunction(double x, double y)
        {
            return engine.Evaluate($"my.f({x}, {y})");
        }
    }
}