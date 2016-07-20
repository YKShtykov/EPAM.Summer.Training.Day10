using System;
using System.Collections;
using System.Collections.Generic;

namespace QueueLogic
{
  /// <summary>
  /// Queue class
  /// </summary>
  /// <typeparam name="T"></typeparam>
  public class Queue<T>: IEnumerable <T>
  {
    private T[] queue;
    private int tail;
    private int head;
    /// <summary>
    /// Maximum count of values in queue
    /// </summary>
    public int Capacity { get; private set; }

    public Queue(int capacity = 10)
    {
      queue = new T[capacity];
      Capacity = capacity;
    }

    /// <summary>
    /// Adding element in queue
    /// </summary>
    /// <param name="element"></param>
    public void Enqueue(T element)
    {
      if (head == Capacity)
      {
        if (tail == 0)
        {
          IncreaseQueue();
        }
        if (tail > 0)
        {
          Move();
        }
      }
      queue[head++] = element;
    }

    /// <summary>
    /// Deleting element from queue
    /// </summary>
    /// <returns></returns>
    public T Dequeue()
    {
      if (tail == head) throw new Exception("Queue is empty");

      return queue[tail++];
    }

    
    /// <summary>
    /// Queue iterator
    /// </summary>
    private struct QueueItherator : IEnumerator<T>
    {
      private readonly T[] collection;
      private int current;
      private int head;

      public QueueItherator(Queue<T> collection)
      {
        this.collection = collection.queue;
        head = collection.head;
        current = collection.tail - 1;
      }

      public T Current
      {
        get
        {
          if(current == -1 || current>= head)
          {
           throw new InvalidOperationException();
          }
          return collection[current];
        }
      }

      object IEnumerator.Current
      {
        get 
        {
          return Current;
        }
      }

      public void Dispose()
      {
      }

      public bool MoveNext()
      {
        return ++current < head;
      }

      public void Reset()
      {
        current = -1;
      }
    }

    private void Move()
    {
      for (int i = tail; i < head; i++)
      {
        queue[i - tail] = queue[i];
      }
      head -= tail;
      tail = 0;
    }

    private void IncreaseQueue()
    {
      Array.Resize<T>(ref queue, 2 * Capacity);
      Capacity *= 2;
    }

    /// <summary>
    /// Implemetnation of IEnumerable<> interface
    /// </summary>
    /// <returns></returns>
    public IEnumerator<T> GetEnumerator()
    {
      return new QueueItherator(this);
    }

    /// <summary>
    /// Explicit implemetnation of IEnumerable<> interface
    /// </summary>
    /// <returns></returns>
    IEnumerator IEnumerable.GetEnumerator()
    {
      return GetEnumerator();
    }
  }
}
