using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text.Json;

class Program
{
    static async Task<double> FetchPriceGecko()
    {
        try
        {
            using HttpClient client = new HttpClient();
            string url = "https://api.coingecko.com/api/v3/simple/price?ids=bitcoin&vs_currencies=usd";
            var response = await client.GetStringAsync(url);
            var json = JsonDocument.Parse(response);
            return json.RootElement.GetProperty("bitcoin").GetProperty("usd").GetDouble();
        }
        catch
        {
            return -1;
        }
    }

    static double PredictRecursive(double value, double rate, int years)
    {
        if (years == 0) return value;
        return PredictRecursive(value * (1 + rate), rate, years - 1);
    }

    static double PredictMemo(double value, double rate, int years, Dictionary<int, double> memo)
    {
        if (years == 0) return value;
        if (memo.ContainsKey(years)) return memo[years];
        memo[years] = PredictMemo(value * (1 + rate), rate, years - 1, memo);
        return memo[years];
    }

    static async Task Main()
    {
        double currentValue = await FetchPriceGecko();
        double growthRate = 0.07;

        if (currentValue == -1)
        {
            Console.WriteLine("Failed to fetch current value.");
            return;
        }

        Console.Write("Enter number of years to forecast: ");
        if (!int.TryParse(Console.ReadLine(), out int years))
        {
            Console.WriteLine("Invalid input.");
            return;
        }

        double rec = PredictRecursive(currentValue, growthRate, years);
        double mem = PredictMemo(currentValue, growthRate, years, new Dictionary<int, double>());

        Console.WriteLine($"Bitcoin now: ${currentValue:F2}");
        Console.WriteLine($"Recursive Forecast: ${rec:F2}");
        Console.WriteLine($"Memoized Forecast: ${mem:F2}");
    }
}
