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
  public class Set<T> : IEnumerable<T>
                       where T : class
  {
    private List<T> collection;
    public Set()
    {
      collection = new List<T>();
    }
    public Set(IEnumerable<T> otherCollection) : this()
    {
      foreach (var item in otherCollection)
      {
        collection.Add(item);
      }
    }

    /// <summary>
    /// Union of Set and Ienumerable type value
    /// </summary>
    /// <param name="otherCollection">IEnumerable<T> value</param>
    public void Union(IEnumerable<T> otherCollection)
    {
      collection = (ReferenceEquals(otherCollection, null)) ? collection : new List<T>(collection.Union(otherCollection));
    }

    /// <summary>
    /// Intersect of Set and Ienumerable type value
    /// </summary>
    /// <param name="otherCollection">IEnumerable<T> value</param>
    public void Intersect(IEnumerable<T> otherCollection)
    {
      collection = (ReferenceEquals(otherCollection, null)) ? collection : new List<T>(collection.Intersect(otherCollection));
    }

    /// <summary>
    /// Except of Set and Ienumerable type value
    /// </summary>
    /// <param name="otherCollection">IEnumerable<T> value</param>
    public void Except(IEnumerable<T> otherCollection)
    {
      collection = (ReferenceEquals(otherCollection, null)) ? collection : new List<T>(collection.Except(otherCollection));
    }

    /// <summary>
    /// Delete repeatet elements except one
    /// </summary>
    public void Distinct()
    {
      collection = new List<T>(collection.Distinct());
    }

    /// <summary>
    /// Delete repeatet elements of collections
    /// </summary>
    public void SymmetryDifference(IEnumerable<T> otherCollection)
    {
      if (ReferenceEquals(otherCollection, null)) return;
      List<T> temp = otherCollection.ToList();
       
      foreach (var item in otherCollection)
      {
        if (collection.Contains(item))
        {
          collection.Remove(item);
          temp.Remove(item);
        }
      }
      collection.AddRange(temp);
    }

    public IEnumerator<T> GetEnumerator()
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
      collection.Add(item);
    }

    /// <summary>
    /// Clear the collection
    /// </summary>
    /// <param name="item"></param>
    public void Clear()
    {
      collection = new List<T>();
    }

    /// <summary>
    /// Serch the element in collection
    /// </summary>
    /// <param name="item">element</param>
    public bool Contains(T item)
    {
      return collection.Contains(item);
    }

    /// <summary>
    /// Copy the set into array elements of T ype
    /// </summary>
    /// <param name="array"></param>
    /// <param name="arrayIndex"></param>
    public void CopyTo(T[] array, int arrayIndex)
    {
      Array.Copy(collection.ToArray<T>(), 0, array, arrayIndex, collection.ToArray<T>().Length);
    }

    /// <summary>
    /// Remove element from the set
    /// </summary>
    /// <param name="item"></param>
    /// <returns></returns>
    public bool Remove(T item)
    {
      if(!collection.Contains(item)) return false;
      collection.Remove(item);
      if (!collection.Contains(item)) return true;
      return false;
    }

    /// <summary>
    /// Transform the set to List<T>
    /// </summary>
    /// <returns></returns>
    public List<T> ToList()
    {
      return new List<T>(collection);
    }
  }
}
