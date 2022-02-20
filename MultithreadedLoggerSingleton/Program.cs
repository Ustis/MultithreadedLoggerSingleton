using System;
using System.Threading;

namespace MultithreadedLoggerSingleton
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            for (int i = 0; i < 100; ++i)
            {
                Thread process = new Thread(() =>
                {
                    Logger.log(new Message(MessageType.Info, "source" + i.ToString(), DateTime.Now,
                        "contnet" + i.ToString()));
                });
                process.Start();
                process.Join();
            }
        }
    }
}