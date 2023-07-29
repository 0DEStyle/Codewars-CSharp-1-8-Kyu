/*Challenge link:https://www.codewars.com/kata/534d2f5b5371ecf8d2000a08/train/csharp
Question:
Your task, is to create N×N multiplication table, of size provided in parameter.

For example, when given size is 3:

1 2 3
2 4 6
3 6 9
For the given example, the return value should be:

[[1,2,3],[2,4,6],[3,6,9]]
*/

//***************Solution********************

//create a 2d array
//set n to 1 upto size, convert to list to add items
//asign numbers into the cells using ForEach function from Linq
//return the result.
using System.Linq;

namespace Solution{
  class Solution{
    public static int[,] MultiplicationTable(int size){
      var table = new int[size, size];
      var n = Enumerable.Range(1, size).ToList();
      n.ForEach(i => n.ForEach(j => table[i - 1, j - 1] = i * j));
      return table;
    }
  }
}

//method 2
using System;

namespace Solution
{
  class Solution
  {
    public static int[,] MultiplicationTable(int size)
    {
      int[,] Mtable = new int[size, size];for (int i = 0; i < size; i++){for (int j = 0; j < size; j++){Mtable[i, j] = (i + 1) * (j + 1);}} return Mtable;
    }
  }
}
//****************Sample Test*****************
