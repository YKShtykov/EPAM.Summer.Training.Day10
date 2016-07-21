using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SetLogic;

namespace SetLogicTests
{
  [TestClass]
  public class SetTests
  {
    [TestMethod]
    public void Union_12_23_Result123()
    {
      //Arrange
      Set<string> actual= new Set<string>(new string[]{ "one","two"});
      Set<string> expected = new Set<string>(new string[] { "one", "two", "three" });

      //Act
      actual.UnionWith(new string[] { "two", "three" });

      //Assert
      CollectionAssert.AreEqual(expected.ToList(), actual.ToList());
    }

    [TestMethod]
    public void SymmetryDifference_12_23_Result13()
    {
      //Arrange
      Set<string> actual = new Set<string>(new string[] { "one", "two" });
      Set<string> expected = new Set<string>(new string[] { "one", "three" });

      //Act
      actual.SymmetryDifference(new string[] { "two", "three" });

      //Assert
      CollectionAssert.AreEqual(expected.ToList(), actual.ToList());
    }

    [TestMethod]
    public void Except_12_23_Result1()
    {
      //Arrange
      Set<string> actual = new Set<string>(new string[] { "one", "two" });
      Set<string> expected = new Set<string>(new string[] { "one" });

      //Act
      actual.ExceptWith(new string[] { "two", "three" });

      //Assert
      CollectionAssert.AreEqual(expected.ToList(), actual.ToList());
    }

    [TestMethod]
    public void Intersect_12_23_Result1()
    {
      //Arrange
      Set<string> actual = new Set<string>(new string[] { "one", "two" });
      Set<string> expected = new Set<string>(new string[] { "two" });

      //Act
      actual.IntersectWith(new string[] { "two", "three" });

      //Assert
      CollectionAssert.AreEqual(expected.ToList(), actual.ToList());
    }
  }
}
