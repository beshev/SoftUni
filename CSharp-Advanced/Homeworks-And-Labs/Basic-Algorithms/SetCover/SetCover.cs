using System;
using System.Collections.Generic;
using System.Linq;

public class SetCover
{
    public static void Main(string[] args)
    {
        int[] universe = new[] { 1, 2, 3, 4, 5 };
        int[][] sets = new[]
        {
                new[] { 1, 2, 3, 4, 5 },
                new[] { 2, 3, 4, 5 },
                new[] { 5 },
                new[] {3 },
               // new[] { 11, 20, 30, 40 },
               // new[] { 3, 7, 40 }
            };

        List<int[]> selectedSets = ChooseSets(sets.ToList(), universe.ToList());
        Console.WriteLine($"Sets to take ({selectedSets.Count}):");

        foreach (int[] set in selectedSets)
        {
            Console.WriteLine($"{{ {string.Join(", ", set)} }}");
        }
    }

    public static List<int[]> ChooseSets(IList<int[]> sets, IList<int> universe)
    {
        // TODO: Implement the method
        var sellectedSet = new List<int[]>();
        while (universe.Count > 0)
        {
            var currentSet = sets.OrderByDescending(s => s.Count(universe.Contains)).First();
            sellectedSet.Add(currentSet);
            sets.Remove(currentSet);
            RemoveAll(currentSet, universe);
        }
        return sellectedSet;

    }

    private static void RemoveAll(int[] currentSet, IList<int> universe)
    {

        for (int i = 0; i < currentSet.Length; i++)
        {
            universe.Remove(currentSet[i]);
        }
    }
}
