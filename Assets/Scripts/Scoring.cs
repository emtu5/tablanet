using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;

public class Scoring
{
    // https://stackoverflow.com/a/3098381
    IEnumerable<IEnumerable<T>> CartesianProduct<T>(IEnumerable<IEnumerable<T>> sequences)
    {
        IEnumerable<IEnumerable<T>> emptyProduct = new[] { Enumerable.Empty<T>()};
        return sequences.Aggregate(
            emptyProduct,
            (accumulator, sequence) => 
                from accseq in accumulator 
                from item in sequence 
                select accseq.Concat(new[] {item})                          
            );
    }

    void GeneratePermutations<T>(T[] array, int size, List<T[]> result)
    {
        if (size == 1)
        {
            result.Add((T[])array.Clone());
            return;
        }

        for (int i = 0; i < size; i++)
        {
            GeneratePermutations(array, size - 1, result);

            if (size % 2 == 1)
            {
                Swap(ref array[0], ref array[size - 1]);
            }
            else
            {
                Swap(ref array[i], ref array[size - 1]);
            }
        }
    }

    void Swap<T>(ref T a, ref T b)
    {
        T temp = a;
        a = b;
        b = temp;
    }

    List<List<int>> DivideIntoSubsets(List<int> nums)
    {
        // get all permutations
        // for each permutation, check manually if it's subsets listed in order
        // if it is, it can divide, yay
        // otherwise, over
        return null;
    }

    static public bool CheckHand(IEnumerable<List<int>> cards, int mainCard)
    {
        // get cartesian product of all card values
        // for each product, divide into subsets
        // if it can divide, hand is valid, return valid set
        // otherwise, error
        return false;
    }
}
