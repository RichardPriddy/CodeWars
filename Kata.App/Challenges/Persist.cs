namespace CodeWars.App.Challenges
{
using System;
using System.Collections.Generic;
using System.Linq;

public class Persist
{
    private static int[] deconstruct(long num)
    {
        List<int> listOfInts = new List<int>();
        while (num > 0)
        {
            listOfInts.Add((int)(num % 10));
            num = num / 10;
        }
        listOfInts.Reverse();
        return listOfInts.ToArray();
    }


    public static int Persistence(long n)
    {
        var nums = deconstruct(n);
        var tracker = 0;
        int count = 0;
        while(nums.Length > 1)
        {
            tracker = nums.Aggregate(1, (acc, x) => acc * x);
            nums = deconstruct(tracker);
            count = count + 1 ;
        }

        return count;
    }
}
}
