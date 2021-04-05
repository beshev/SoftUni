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
        var sortedCoins = coins.OrderByDescending(c => c).ToList();
        var result = new Dictionary<int, int>();
        int index = 0;
        var currentSum = 0;
        while (currentSum != targetSum && index < sortedCoins.Count)
        {
            var currentCoinValue = sortedCoins[index];
            var remainingSum = targetSum - currentSum;
            var numberOfCoinsToTake = remainingSum / currentCoinValue;
            if (numberOfCoinsToTake > 0)
            {
                result.Add(sortedCoins[index], numberOfCoinsToTake);
                currentSum += sortedCoins[index] * numberOfCoinsToTake;
            }
            index++;
        }
        if (currentSum == targetSum)
        {
            return result;
        }
        else
        {
            throw new InvalidOperationException();
        }
    }
}