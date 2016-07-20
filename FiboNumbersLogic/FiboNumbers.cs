using System;
using System.Collections.Generic;
using System.Linq;

namespace FiboNumbersLogic
{
  /// <summary>
  /// Class for getting Fibonachi numbers
  /// </summary>
  public static class FiboNumbers
  {
    /// <summary>
    /// Method returns array of Fibonachi numbers
    /// </summary>
    /// <param name="numbersCount"> count of numbers that you need</param>
    /// <returns>array of Fibonachi numbers</returns>
    public static int[] GetFiboNumbers(int numbersCount)
    {
      if (numbersCount < 1) throw new ArgumentException("number must be greather than 0");

      List<int> result = new List<int>();

      foreach (var item in GetNumbers(numbersCount))
      {
        result.Add(item);
      }

      return result.ToArray<int>();
    }

    private static IEnumerable<int> GetNumbers(int numbersCount)
    {
      int prevValue = 0;
      int curValue = 1;

      yield return curValue;

      for (int i = 0; i < numbersCount-1; i++)
      {
        int temp = prevValue;
        prevValue = curValue;

        yield return curValue += temp;
      }
    }
  }
}
