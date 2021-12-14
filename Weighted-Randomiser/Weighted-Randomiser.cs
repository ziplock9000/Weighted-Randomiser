//
// Code originally from Philipp @ https://gamedev.stackexchange.com/questions/162976/how-do-i-create-a-weighted-collection-and-then-pick-a-random-element-from-it
//
using System;
using System.Collections.Generic;

internal class WeightedRandomiser<T>
{

    private struct Entry
    {
        public double accumulatedWeight;
        public T item;
    }

    private readonly List<Entry> entries = new List<Entry>();
    private double accumulatedWeight;
    private readonly Random rand = new Random();

    public void AddEntry(T item, double weight)
    {
        accumulatedWeight += weight;
        entries.Add(new Entry { item = item, accumulatedWeight = accumulatedWeight });
    }

    public T GetRandom()
    {
        double r = rand.NextDouble() * accumulatedWeight;

        //DO NOT Use the linq version, it's half the speed and uses more memory
        //foreach (Entry entry in entries.Where(entry => entry.accumulatedWeight >= r))
        //{
        //    return entry.item;
        //}

        //TODO: Having to loop through each item until one is found at a certain threshold before exiting seems to be inefficient. Why can't we just index directly to a value?
        //Apparently not, every example on the internet uses this loop.
        foreach (Entry entry in entries)
        {
            if (entry.accumulatedWeight >= r)
            {
                return entry.item;
            }
        }
        return default(T);
    }
}
