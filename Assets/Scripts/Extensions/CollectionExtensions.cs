using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Extensions
{
    public static class CollectionExtensions
    {
        public static T PickRandomElement<T>(this IReadOnlyList<T> collection)
        {
            var index = Random.Range(0, collection.Count);
            return collection[index];
        }
        
        public static T PickRandomElement<T>(this ISet<T> collection)
        {
            var index = Random.Range(0, collection.Count);
            return collection.ElementAt(index);
        }
    }
}