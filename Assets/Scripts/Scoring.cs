using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;

public class Scoring
{
    // https://stackoverflow.com/a/3098381
    static IEnumerable<IEnumerable<T>> CartesianProduct<T>(IEnumerable<IEnumerable<T>> sequences)
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

    // https://stackoverflow.com/a/10630026
    static IEnumerable<IEnumerable<T>> GetPermutations<T>(IEnumerable<T> list, int length)
    {
        if (length == 1) return list.Select(t => new T[] { t });

        return GetPermutations(list, length - 1)
            .SelectMany(t => list.Where(e => !t.Contains(e)),
                (t1, t2) => t1.Concat(new T[] { t2 }));
    }

    static List<int> DivideIntoSubsets(List<int> nums, int total)
    {
        // current code is abysmally unoptimized, but I don't care right now
        // get all permutations
        // foreach (int elem in nums) {
        //     Debug.Log(elem);
        // }
        Debug.LogFormat("length: {0}", nums.Count);
        var allPerms = GetPermutations(nums, nums.Count);
        foreach (var perm in allPerms) {
            // for each permutation, check manually if it's subsets listed in order
            int currentTotal = 0;
            foreach(int elem in perm) {
                currentTotal += elem;
                if (currentTotal == total) {
                    currentTotal = 0;
                }
                else if (currentTotal > total) {
                    break;
                }
            }
            if (currentTotal == 0) {
                foreach (int elem in perm) {
                    Debug.Log(elem);
                }
                return perm.ToList();
            }
        }
        
        
        // if it is, it can divide, yay
        // otherwise, over
        Debug.Log("guh");
        return null;
    }

    static public IEnumerable<int> CheckHand(IEnumerable<List<int>> cards, int mainCard)
    {
        // get cartesian product of all card values
        var allPossibleInitialValues = CartesianProduct(cards);
        Debug.Log(allPossibleInitialValues);
        foreach (var product in allPossibleInitialValues) {

            // for each product, divide into subsets
            // if it can divide, hand is valid, return valid set
            // otherwise, error
            var result = DivideIntoSubsets(product.ToList(), mainCard);
            if (result != null) {
                return product;
            }
        }
        Debug.Log("guh2");
        return null;
    }
}
