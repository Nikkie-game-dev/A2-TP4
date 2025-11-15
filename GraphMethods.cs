using System;
using System.Collections.Generic;

namespace a2tp4;

public class GraphMethods
{
    /// <summary>
    /// Determines whether all elements of a sequence satisfy a condition.
    /// f(n) = O(n) as worst case
    /// </summary>
    /// <typeparam name="TSource"></typeparam>
    /// <param name="source"></param>
    /// <param name="predicate"></param>
    /// <returns></returns>
    public static bool All<TSource>(IEnumerable<TSource> source, Func<TSource, bool> predicate)
    {
        foreach (var element in source)
        {
            if (!predicate(element))
            {
                return false;
            }
        }

        return true;
    }

    /// <summary>
    /// Determines whether any element of a sequence satisfies a condition.
    /// f(n) = O(n) as worst case
    /// </summary>
    /// <typeparam name="TSource"></typeparam>
    /// <param name="source"></param>
    /// <param name="predicate"></param>
    /// <returns></returns>
    public static bool Any<TSource>(IEnumerable<TSource> source, Func<TSource, bool> predicate)
    {
        foreach (var element in source)
        {
            if (predicate(element))
            {
                return true;
            }
        }

        return false;
    }

    /// <summary>
    /// Determines whether a sequence contains a specified element by using the default equality comparer.
    /// f(n) = O(n) as worst case
    /// </summary>
    /// <typeparam name="TSource"></typeparam>
    /// <param name="source"></param>
    /// <param name="item"></param>
    /// <returns></returns>
    public static bool Contains<TSource>(IEnumerable<TSource> source, TSource item)
    {
        foreach (var element in source)
        {
            if (element.Equals(item))
            {
                return true;
            }
        }

        return false;
    }

    /// <summary>
    /// Determines whether a sequence contains a specified element by using a specified IEqualityComparer<T>.
    /// f(n) = O(n) as worst case
    /// </summary>
    /// <typeparam name="TSource"></typeparam>
    /// <param name="source"></param>
    /// <param name="item"></param>
    /// <param name="comparer"></param>
    /// <returns></returns>
    public static bool Contains<TSource>(IEnumerable<TSource> source, TSource item, IEqualityComparer<TSource> comparer)
    {
        foreach (var element in source)
        {
            if (comparer.Equals(element, item))
            {
                return true;
            }
        }

        return false;
    }

    /// <summary>
    /// Returns distinct elements from a sequence by using the default equality comparer to compare values.
    /// f(n) = O(n^2) as worst case. A source said that this is O(n) but it clearly uses two nested loops, one
    /// with the add() and the foreach loop
    /// </summary>
    /// <typeparam name="TSource"></typeparam>
    /// <param name="source"></param>
    /// <returns></returns>
    public static IEnumerable<TSource> Distinct<TSource>(IEnumerable<TSource> source)
    {
        var distinctElements = new HashSet<TSource>();
        foreach (var element in source)
        {
            // Add() checks the hash codes of all elements inside, and if it is already inside it returns a false without
            // adding it 
            if (distinctElements.Add(element))
            {
                yield return element;
            }
        }
    }

    /// <summary>
    /// Returns distinct elements from a sequence by using a specified IEqualityComparer<T> to compare values.
    /// f(n) = O(n^2) as worst case
    /// </summary>
    /// <typeparam name="TSource"></typeparam>
    /// <param name="source"></param>
    /// <param name="comparer"></param>
    /// <returns></returns>
    public static IEnumerable<TSource> Distinct<TSource>(IEnumerable<TSource> source,
        IEqualityComparer<TSource> comparer)
    {
        var distinctElements = new HashSet<TSource>(comparer);
        foreach (var element in source)
        {
            if (distinctElements.Add(element))
            {
                yield return element;
            }
        }
    }

    /// <summary>
    /// Returns the element at a specified index in a sequence.
    /// f(n) = O(1) as worst case
    /// </summary>
    /// <typeparam name="TSource"></typeparam>
    /// <param name="source"></param>
    /// <param name="index"></param>
    /// <returns></returns>
    public static TSource ElementAt<TSource>(IEnumerable<TSource> source, int index)
    {
        var count = 0;
        foreach (var element in source)
        {
            if (count == index)
            {
                return element;
            }

            count++;
        }

        return default;
    }

    /// <summary>
    /// Produces the set difference of two sequences by using the default equality comparer to compare values.
    /// f(n) = O(n^2) as worst case
    /// </summary>
    /// <typeparam name="TSource"></typeparam>
    /// <param name="source1"></param>
    /// <param name="source2"></param>
    /// <returns></returns>
    public static IEnumerable<TSource> Except<TSource>(IEnumerable<TSource> source1, IEnumerable<TSource> source2)
    {
        var elements = new HashSet<TSource>(source1);

        foreach (var element in source2)
        {
            if (elements.Add(element))
            {
                yield return element;
            }
        }
    }

    /// <summary>
    /// Produces the set difference of two sequences by using the specified IEqualityComparer<T> to compare values.
    /// f(n) = O(n^2) as worst case
    /// </summary>
    /// <typeparam name="TSource"></typeparam>
    /// <param name="source1"></param>
    /// <param name="source2"></param>
    /// <param name="comparer"></param>
    /// <returns></returns>
    public static IEnumerable<TSource> Except<TSource>(IEnumerable<TSource> source1, IEnumerable<TSource> source2,
        IEqualityComparer<TSource> comparer)
    {
        var elements = new HashSet<TSource>(source1, comparer);

        foreach (var element in source2)
        {
            if (elements.Add(element))
            {
                yield return element;
            }
        }
    }

    /// <summary>
    /// Returns the first element in a sequence that satisfies a specified condition.
    /// f(n) = O(n) as worst case
    /// </summary>
    /// <typeparam name="TSource"></typeparam>
    /// <param name="source"></param>
    /// <param name="predicate"></param>
    /// <returns></returns>
    public static TSource First<TSource>(IEnumerable<TSource> source, Func<TSource, bool> predicate)
    {
        foreach (var element in source)
        {
            if (predicate(element))
            {
                return element;
            }
        }

        throw new Exception(); // if no element matches predicate
    }

    /// <summary>
    /// Returns the last element of a sequence that satisfies a specified condition.
    /// f(n) = O(n) as worst case
    /// </summary>
    /// <typeparam name="TSource"></typeparam>
    /// <param name="source"></param>
    /// <param name="predicate"></param>
    /// <returns></returns>
    public static TSource Last<TSource>(IEnumerable<TSource> source, Func<TSource, bool> predicate)
    {
        TSource lastElement = default;

        foreach (var element in source)
        {
            if (predicate(element))
            {
                lastElement = element;
            }
        }

        return lastElement;
    }

    /// <summary>
    /// Produces the set intersection of two sequences by using the default equality comparer to compare values.
    /// f(n) = O(n^2) as worst case
    /// </summary>
    /// <typeparam name="TSource"></typeparam>
    /// <param name="source1"></param>
    /// <param name="source2"></param>
    /// <returns></returns>
    public static IEnumerable<TSource> Intersect<TSource>(IEnumerable<TSource> source1, IEnumerable<TSource> source2)
    {
        var elements = new HashSet<TSource>(source1);

        foreach (var element in source2)
        {
            if (!elements.Add(element))
            {
                yield return element;
            }
        }
    }

    /// <summary>
    /// Produces the set intersection of two sequences by using the specified IEqualityComparer<T> to compare values.
    /// f(n) = O(n^2) as worst case
    /// </summary>
    /// <typeparam name="TSource"></typeparam>
    /// <param name="source1"></param>
    /// <param name="source2"></param>
    /// <param name="comparer"></param>
    /// <returns></returns>
    public static IEnumerable<TSource> Intersect<TSource>(IEnumerable<TSource> source1, IEnumerable<TSource> source2,
        IEqualityComparer<TSource> comparer)
    {
        var elements = new HashSet<TSource>(source1, comparer);

        foreach (var element in source2)
        {
            if (!elements.Add(element))
            {
                yield return element;
            }
        }
    }

    /// <summary>
    /// Returns a number that represents how many elements in the specified sequence satisfy a condition.
    /// f(n) = O(n^2) as worst case
    /// </summary>
    /// <typeparam name="TSource"></typeparam>
    /// <param name="source"></param>
    /// <param name="predicate"></param>
    /// <returns></returns>
    public static int Count<TSource>(IEnumerable<TSource> source, Func<TSource, bool> predicate)
    {
        var count = 0;

        foreach (var _ in source)
        {
            count++;
        }

        return count;
    }

    /// <summary>
    /// Determines whether two sequences are equal by comparing their elements by using a specified IEqualityComparer<T>.
    /// f(n) = O(n^2) as worst case
    /// </summary>
    /// <typeparam name="TSource"></typeparam>
    /// <param name="source1"></param>
    /// <param name="source2"></param>
    /// <param name="comparer"></param>
    /// <returns></returns>
    public static bool SequenceEqual<TSource>(IEnumerable<TSource> source1, IEnumerable<TSource> source2,
        IEqualityComparer<TSource> comparer)
    {
        var elements = new HashSet<TSource>(source1, comparer);

        foreach (var element in source2)
        {
            if (elements.Add(element))
            {
                return false;
            }
        }

        return true;
    }

    /// <summary>
    /// Returns the only element of a sequence that satisfies a specified condition, and throws an exception if more than one such element exists.
    /// f(n) = O(n^2) as worst case
    /// </summary>
    /// <typeparam name="TSource"></typeparam>
    /// <param name="source"></param>
    /// <param name="predicate"></param>
    /// <returns></returns>
    public static TSource Single<TSource>(IEnumerable<TSource> source, Func<TSource, bool> predicate)
    {
        var elements = new HashSet<TSource>();
        TSource result = default;
        var count = 0;

        foreach (var element in source)
        {
            if (!predicate(element) || elements.Add(element)) continue;
            
            if (count == 0)
            {
                ++count;
                result = element;
            }
            else
            {
                throw new Exception();
            }
        }

        return result;
    }

    /// <summary>
    /// Bypasses elements in a sequence as long as a specified condition is true and then returns the remaining elements.
    /// f(n) = O(n) as worst case
    /// </summary>
    /// <typeparam name="TSource"></typeparam>
    /// <param name="source"></param>
    /// <param name="predicate"></param>
    /// <returns></returns>
    public static IEnumerable<TSource> SkipWhile<TSource>(IEnumerable<TSource> source, Func<TSource, bool> predicate)
    {
        foreach (var element in source)
        {
            if (!predicate(element))
            {
                yield return element;
            }
        }
    }

    /// <summary>
    /// Produces the set union of two sequences by using the default equality comparer.
    /// f(n) = O(n^2) as worst case
    /// </summary>
    /// <typeparam name="TSource"></typeparam>
    /// <param name="source1"></param>
    /// <param name="source2"></param>
    /// <returns></returns>
    public static IEnumerable<TSource> Union<TSource>(IEnumerable<TSource> source1, IEnumerable<TSource> source2)
    {
        var elements = new HashSet<TSource>();

        foreach (var element in source1)
        {
            if (elements.Add(element))
            {
                yield return element;
            }
        }

        foreach (var element in source2)
        {
            if (elements.Add(element))
            {
                yield return element;
            }
        }
    }

    /// <summary>
    /// Produces the set union of two sequences by using a specified IEqualityComparer<T>.
    /// f(n) = O(n^2) as worst case
    /// </summary>
    /// <typeparam name="TSource"></typeparam>
    /// <param name="source1"></param>
    /// <param name="source2"></param>
    /// <param name="comparer"></param>
    /// <returns></returns>
    public static IEnumerable<TSource> Union<TSource>(IEnumerable<TSource> source1, IEnumerable<TSource> source2,
        IEqualityComparer<TSource> comparer)
    {

        var elements = new HashSet<TSource>(comparer);

        foreach (var element in source1)
        {
            if (elements.Add(element))
            {
                yield return element;
            }
        }

        foreach (var element in source2)
        {
            if (elements.Add(element))
            {
                yield return element;
            }
        }    }

    /// <summary>
    /// Filters a sequence of values based on a predicate. Each element's index is used in the logic of the predicate function.
    /// f(n) = O(n^2) as worst case
    /// </summary>
    /// <typeparam name="TSource"></typeparam>
    /// <param name="source"></param>
    /// <param name="predicate"></param>
    /// <returns></returns>
    public static IEnumerable<TSource> Where<TSource>(IEnumerable<TSource> source, Func<TSource, bool> predicate)
    {
        //var count = 0;
        foreach (var element in source)
        {
            if (predicate(element))
            {
                yield return element;
            }
        }
    }
}