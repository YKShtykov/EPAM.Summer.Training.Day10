using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FiboNumbersLogic;
using System.Collections.Generic;

namespace FiboNumbersTests
{
  /// <summary>
  /// Class for testing FiboNumbersLogic library
  /// </summary>
  [TestClass]
  public class FiboTests
  {
    /// <summary>
    /// input paramrter equals 1
    /// </summary>
    [TestMethod]
    public void FiboNumbers_Input1_Output1()
    {
      //Arrange 
      int[] expected = new int[]{ 1 };

      //Act
      int[] actual = FiboNumbers.GetFiboNumbers(1);

      //Assert
      CollectionAssert.AreEqual(expected, actual);
    }

    /// <summary>
    /// input paramrter equals 5
    /// </summary>
    [TestMethod]
    public void FiboNumbers_Input5_Output11235()
    {
      //Arrange 
      int[] expected = new int[] { 1,1,2,3,5 };

      //Act
      int[] actual = FiboNumbers.GetFiboNumbers(5);

      //Assert
      CollectionAssert.AreEqual(expected, actual);
    }

    /// <summary>
    /// input paramrter equals -1
    /// </summary>
    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void FiboNumbers_InputM1_OutputException()
    {
      //Act
      int[] actual = FiboNumbers.GetFiboNumbers(-1);
    }
  }
}
