using System;
using Demo.App.Message;
using Grpc.Core;

namespace Demo.Server
{
    class Program
    {
        static void Main(string[] args)
        {
            var host = "127.0.0.1";
            var port = 9999;

            var serverInstance = new Grpc.Core.Server
            {
                Ports =
                {
                    new ServerPort(host, port, ServerCredentials.Insecure)
                }
            };

            Console.WriteLine($"Demo server listening on host:{host} and port:{port}");

            serverInstance.Services.Add(
                DemoService.BindService(
                    new DemoServiceImpl()));

            serverInstance.Start();
            
            Console.ReadKey();

            serverInstance.ShutdownAsync().Wait();
        }
    }
}