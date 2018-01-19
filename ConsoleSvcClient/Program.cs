using System;
using ConsoleSvcClient.CalculatorService;


namespace ConsoleSvcClient
{
   class Program
    {
        static void Main(string[] args)
        {
            var calc = new CalculatorServiceClient();
            var result = calc.GetResult(Operation.Add, new object[] { 2, 3 });
            if (string.IsNullOrEmpty(result.Error))
                Console.WriteLine(result.Result);
            else
                Console.WriteLine(result.Error);

            result = calc.GetResult(Operation.Print, new object[] { "result", result.Result });
            if (string.IsNullOrEmpty(result.Error))
                Console.WriteLine(result.Result);
            else
                Console.WriteLine(result.Error);

            result = calc.GetResult(Operation.Add, new object[] { 2, "c3" });
            if (string.IsNullOrEmpty(result.Error))
                Console.WriteLine(result.Result);
            else
                Console.WriteLine(result.Error);

            result = calc.GetResult(Operation.AddPair, new object[] { new Pair { V1 = 3, V2 = 4 } });
            if (string.IsNullOrEmpty(result.Error))
                Console.WriteLine(result.Result);
            else
                Console.WriteLine(result.Error);

            Console.ReadKey();
        }
    }
}
