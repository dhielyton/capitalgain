using CapitalGain.Application.Service;
using System;
using System.Collections.Generic;

namespace CapitalGain.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            OperationService operationService = new OperationService(new Domain.Operations.OperationService());
            List<string> lines = new List<string>();
            string line = string.Empty;
            do
            {
                line = Console.ReadLine();
                if(!string.IsNullOrWhiteSpace(line))
                    lines.Add(line);

            } while (!string.IsNullOrWhiteSpace(line));

            foreach (var item in lines)
            {
                operationService.Process(item);
            }
        }
    }
}
