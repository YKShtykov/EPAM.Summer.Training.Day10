using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QueueLogic;

namespace QueueTests
{
  /// <summary>
  /// Class for testing queue logic
  /// </summary>
  [TestClass]
  public class QueueTest
  {
    /// <summary>
    /// Dequeue from empty queue
    /// </summary>
    [TestMethod]
    [ExpectedException(typeof(Exception))]
    public void DequeueEmptyQueue_Exception()
    {
      Queue<int> queue = new Queue<int>();
      int var = queue.Dequeue();
    }

    /// <summary>
    /// Normal work test
    /// </summary>
    [TestMethod]
    public void QueueEnqueueDequeue_EnqueueValue()
    {
      //Arrange
      Queue<int> queue = new Queue<int>();
      queue.Enqueue(5);

      //Act
      int actual = queue.Dequeue();

      //Assert
      Assert.AreEqual(5, actual);
    }

    /// <summary>
    /// Increasing of capacity test
    /// </summary>
    [TestMethod]
    public void QueueEnqueue15Values_Capacity20()
    {
      //Arrange
      Queue<int> queue = new Queue<int>();
      for (int i = 0; i < 15; i++)
      {
        queue.Enqueue(5);
      }
      

      //Act
      int actual = queue.Capacity;

      //Assert
      Assert.AreEqual(20, actual);
    }

    /// <summary>
    /// Itherator test
    /// </summary>
    [TestMethod]
    public void QueueItherator()
    {
      //Arrange
      Queue<int> queue = new Queue<int>();
      for (int i = 0; i < 5; i++)
      {
        queue.Enqueue(5);
      }


      //Assert
      foreach (var item in queue)
      {
        Assert.AreEqual(5, item);
      }
    }
  }
}
