/*Challenge link:https://www.codewars.com/kata/597770e98b4b340e5b000071/train/csharp
Question:
You have to extract a portion of the file name as follows:

Assume it will start with date represented as long number
Followed by an underscore
You'll have then a filename with an extension
it will always have an extra extension at the end
Inputs:
1231231223123131_FILE_NAME.EXTENSION.OTHEREXTENSION

1_This_is_an_otherExample.mpg.OTHEREXTENSIONadasdassdassds34

1231231223123131_myFile.tar.gz2
Outputs
FILE_NAME.EXTENSION

This_is_an_otherExample.mpg

myFile.tar
Acceptable characters for random tests:

abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ_-0123456789

The recommended way to solve it is using RegEx and specifically groups.
*/

//***************Solution********************
//pattern, (?<=exp) zero-width positive look behind to check if the expression is _
//. follow by
//(?=exp) zero-width positive look ahead to check if next expression is .
//collect the value and return the result as string.

//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
using System.Text.RegularExpressions;
namespace Solution
{
    class FileNameExtractor
    {
        public static string ExtractFileName(string s) =>  Regex.Match(s, @"(?<=_).+(?=\.)").Value;
    }
}

//****************Sample Test*****************
namespace Solution {
  using NUnit.Framework;
  using System;
  using System.Linq;
  
  [TestFixture]
  public class SolutionTest
  {
    [Test]
    public void BasicTests()
    {
      Assert.AreEqual("FILE_NAME.EXTENSION", FileNameExtractor.ExtractFileName("1231231223123131_FILE_NAME.EXTENSION.OTHEREXTENSION"));
      Assert.AreEqual("FILE_NAME.EXTENSION", FileNameExtractor.ExtractFileName("1_FILE_NAME.EXTENSION.OTHEREXTENSIONadasdassdassds34"));
      Assert.AreEqual("FILE_NAM-E.EXTENSION", FileNameExtractor.ExtractFileName("1_FILE_NAM-E.EXTENSION.OTHEREXTENSIONadasdassdassds34"), "please verify that you are handling well character - as part of the name");
    }
    
    private Random rand = new Random();
    
    [Test]
    public void RandomTests()
    {
      string extension, filename, firstPart, testfilename;
      string chars = "abcdefghijklmnopqrstuvwxyz123456789";

      for (int i = 0; i < 100; i++)
      {
          firstPart = rand.Next(1000, 1000000).ToString();
          filename = new string(Enumerable.Range(0, 20).Select(s => chars[rand.Next(chars.Length - 1)]).ToArray());
          extension = new string(Enumerable.Range(0, 20).Select(s => chars[rand.Next(chars.Length - 1)]).ToArray()).Substring(2, 3);
          testfilename = firstPart + "_" + filename + "." + extension + "." + firstPart + "a";
          
          Assert.AreEqual(filename + "." + extension, FileNameExtractor.ExtractFileName(testfilename));
      }
    }
  }
}
