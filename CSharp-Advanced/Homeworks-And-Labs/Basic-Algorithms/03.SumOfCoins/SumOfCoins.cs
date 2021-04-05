using System;
using System.Collections.Generic;
using System.Linq;

public class SumOfCoins
{
    public static void Main(string[] args)
    {
        var availableCoins = new[] { 1, 2, 5, 10, 20, 50 };
        var targetSum = 923;

        var selectedCoins = ChooseCoins(availableCoins, targetSum);

        Console.WriteLine($"Number of coins to take: {selectedCoins.Values.Sum()}");
        foreach (var selectedCoin in selectedCoins)
        {
            Console.WriteLine($"{selectedCoin.Value} coin(s) with value {selectedCoin.Key}");
        }
    }

    public static Dictionary<int, int> ChooseCoins(IList<int> coins, int targetSum)
    {
        // TODO: Implement the method
        int sum = 0;
        Dictionary<int, int> result = new Dictionary<int, int>();
        for (int i = 0; i < coins.Count; i++)
        {
            while (coins[coins.Count - 1 - i] + sum <= targetSum)
            {
                sum += coins[coins.Count - 1 - i];
                if (result.ContainsKey(coins[coins.Count - 1- i]) == false)
                {
                    result.Add(coins[coins.Count - 1 - i], 0);
                }
                result[coins[coins.Count - 1 - i]]++;
            }
        }
        return result;
    }
}