using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace SetLogic
{
  /// <summary>
  /// Class-Collection for reference types, realises main operations for multiplicity
  /// </summary>
  /// <typeparam name="T"></typeparam>
  public class Set<T> : IEnumerable<KeyValuePair<int, T>>
                       where T : class
  {
    private Dictionary<int,T> collection;
    private Type setType;

    public Set()
    {
      collection = new Dictionary<int, T>();
      setType = typeof(T);
    }

    public Set(IEnumerable<T> otherCollection) : this()
    {
      foreach (var item in otherCollection)
      {
        collection.Add(item.GetHashCode(),item);
      }
    }

    /// <summary>
    /// Union of Set and Ienumerable type value
    /// </summary>
    /// <param name="otherCollection">IEnumerable<T> value</param>
    public void UnionWith(IEnumerable<T> otherCollection)
    {
      SetOperations(otherCollection, (other) => collection.Union(other));
    }

    /// <summary>
    /// Intersect of Set and Ienumerable type value
    /// </summary>
    /// <param name="otherCollection">IEnumerable<T> value</param>
    public void IntersectWith(IEnumerable<T> otherCollection)
    {
      SetOperations(otherCollection, (other) => collection.Intersect(other));
    }

    /// <summary>
    /// Except of Set and Ienumerable type value
    /// </summary>
    /// <param name="otherCollection">IEnumerable<T> value</param>
    public void ExceptWith(IEnumerable<T> otherCollection)
    {
      SetOperations(otherCollection, (other) => collection.Except(other));
    }

    /// <summary>
    /// Delete repeatet elements except one
    /// </summary>
    public void Distinct()
    {
      collection = collection.Distinct().ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
    }

    /// <summary>
    /// Delete repeatet elements of collections
    /// </summary>
    public void SymmetryDifference(IEnumerable<T> otherCollection)
    {
      if (ReferenceEquals(otherCollection, null)) return;
      var temp = ConvertToDictionary(otherCollection);
      var result = new Dictionary<int, T>();

      foreach (var item in collection)
      {
        if (!temp.ContainsKey(item.Key))
        {
          result.Add(item.Key, item.Value);
        }
      }
      foreach (var item in temp)
      {
        if (!collection.ContainsKey(item.Key))
        {
          result.Add(item.Key,item.Value);
        }
      }
      collection = result;
    }

    public IEnumerator<KeyValuePair<int, T>> GetEnumerator()
    {
      return collection.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
      return GetEnumerator();
    }

    /// <summary>
    /// Adde element in collection
    /// </summary>
    /// <param name="item"></param>
    public void Add(T item)
    {
      collection.Add(item.GetHashCode(),item);
    }

    /// <summary>
    /// Clear the collection
    /// </summary>
    /// <param name="item"></param>
    public void Clear()
    {
      collection = new Dictionary<int, T>();
    }

    /// <summary>
    /// Serch the element in collection
    /// </summary>
    /// <param name="item">element</param>
    public bool Contains(T item)
    {
      return collection.ContainsKey(item.GetHashCode());
    }

    /// <summary>
    /// Remove element from the set
    /// </summary>
    /// <param name="item"></param>
    /// <returns></returns>
    public void Remove(T item)
    {
      collection.Remove(item.GetHashCode());
    }

    /// <summary>
    /// Transform the set to List<T>
    /// </summary>
    /// <returns></returns>
    public List<T> ToList()
    {
      return new List<T>(collection.Values.ToList());
    }

    private Dictionary<int, T> ConvertToDictionary(IEnumerable<T> collection)
    {
      Dictionary<int, T> result = new Dictionary<int, T>();
      foreach (var item in collection)
      {
        result.Add(item.GetHashCode(), item);
      }
      return result;
    }

    private void SetOperations(IEnumerable<T> otherCollection, Func<Dictionary<int,T>, IEnumerable<KeyValuePair<int,T>>> func)
    {
      var temp = ConvertToDictionary(otherCollection);
      collection = (ReferenceEquals(otherCollection, null)) ? collection : func(temp).ToDictionary(kvp => kvp.Key, kvp => kvp.Value);

    }
  }
}
