using System.Runtime.CompilerServices;

namespace AdventOfCode2023;

public static class Extensions
{
    public static IEnumerable<IEnumerable<T>> GroupsWithSeparator<T>(this IEnumerable<T> source, Func<T, bool> separator)
    {
        var group = new List<T>();
        foreach(var item in source)
        {
            if (separator(item))
            {
                yield return group;
                group = new List<T>();
            }
            else
            {
                group.Add(item);
            }
        }
        yield return group;
    }

    public static IDictionary<TKey,TValue> ToDictionaryWithCombiner<TKey,TValue,TSource>(
        this IEnumerable<TSource> source, 
        Func<TSource, TKey> keySelector, 
        Func<TSource, TValue> valueSelector,
        Func<TValue, TValue, TValue> combiner) where TKey : notnull
    {
        var d = new Dictionary<TKey, TValue>();
        foreach(var elem in source)
        {
            var key = keySelector(elem);
            var value = valueSelector(elem); 
            if (d.ContainsKey(key))
            {
                d[key] = combiner(d[key], value);
            }
            else
            {
                d.Add(key, value);
            }
        }
        return d;
    }
}