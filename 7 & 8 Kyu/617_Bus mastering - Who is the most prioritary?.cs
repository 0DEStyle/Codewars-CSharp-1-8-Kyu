/*Challenge link:https://www.codewars.com/kata/5a0366f12b651dbfa300000c/train/csharp
Question:
When multiple master devices are connected to a single bus (https://en.wikipedia.org/wiki/System_bus), there needs to be an arbitration in order to choose which of them can have access to the bus (and 'talk' with a slave).

We implement here a very simple model of bus mastering. Given n, a number representing the number of masters connected to the bus, and a fixed priority order (the first master has more access priority than the second and so on...), the task is to choose the selected master. In practice, you are given a string inp of length n representing the n masters' requests to get access to the bus, and you should return a string representing the masters, showing which (only one) of them was granted access:

The string 1101 means that master 0, master 1 and master 3 have requested
access to the bus. 
Knowing that master 0 has the greatest priority, the output of the function should be: 1000
Examples
* arbitrate("001000101", 9) -> "001000000"

* arbitrate("000000101", 9) -> "000000100"
Notes
The resulting string (char* ) should be allocated in the arbitrate function, and will be free'ed in the tests.

n is always greater or equal to 1.
*/

//***************Solution********************
/*
🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨
🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨
🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨
🟨⬛⬜🟨🟨🟨🟨🟨⬛⬜🟨
🟨⬛⬛🟨🟨🟨🟨🟨⬛⬛🟨
🟨⬛⬛🟨🟨⬛🟨🟨⬛⬛🟨
🟥🟨🟨🟨🟨🟨🟨🟨🟨🟨🟥
🟥🟥🟨🟨🟨⬛🟨🟨🟨🟥🟥
🟥🟥🟨🟨⬛🟨⬛🟨🟨🟥🟥
🟥🟨🟨🟨🟨🟨🟨🟨🟨🟨🟥
🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨
*/
//return the highest bit on the left, set all the right to 0

using System;

public class Bus{
	public static string arbitrate(string input, int length){
		//get index of first 1
    var i = input.IndexOf('1') + 1;
    
    //up to first 1, + the rest of the 0s
    return input.Substring(0, i) + 
           new string('0', input.Length - i);
	}
}

//solution 2
public class Bus
{
  public static string arbitrate(string input, int length)
  {
    return input[..(input.IndexOf('1') + 1)].PadRight(length, '0');
  }
}
//****************Sample Test*****************
namespace Solution {
  using NUnit.Framework;
  using System;
  using System.Text.RegularExpressions;

  // TODO: Replace examples and use TDD development by writing your own tests

  [TestFixture]
  public class SolutionTests
  {    
    private string _arbitrate(string input, int length)
    {
        var match = Regex.Match(input, "1");
        string str = input.Substring(0, match.Index + 1);
        return str + new Regex("1").Replace(input.Substring(str.Length), "0");
    }
  
    public static string random_sequence(int len){
        string result = "";
        Random rand = new Random();
        for (int i = 0; i < len; i++){
            result += rand.Next(0, 2);
        }
        return result;
    }
    
    [Test]
    public void RandomTests()
    {
        for(int i = 1; i <= 100; i++){
            string input = random_sequence(i);
            Assert.AreEqual(this._arbitrate(input, i), Bus.arbitrate(input, i));
        }
    }
  }
}
