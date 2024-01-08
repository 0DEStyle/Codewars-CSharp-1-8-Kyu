/*Challenge link:https://www.codewars.com/kata/62d34faad32b8c002a17d6d9/train/csharp
Question:
In a computer operating system that uses paging for virtual memory management, page replacement algorithms decide which memory pages to page out when a page of memory needs to be allocated. Page replacement happens when a requested page is not in memory (page fault) and a free page cannot be used to satisfy the allocation, either because there are none, or because the number of free pages is lower than some threshold.

The FIFO page replacement algorithm
The first-in, first-out (FIFO) page replacement algorithm is a low-overhead algorithm that requires little bookkeeping on the part of the operating system. The idea is obvious from the name: the operating system keeps track of all the pages in memory in a queue, with the most recent arrival at the back, and the oldest arrival in front. When a page needs to be replaced, the oldest page is selected. Note that a page already in the queue is not pushed at the end of the queue if it is referenced again.

Your task is to implement this algorithm. The function will take two parameters as input: the number of maximum pages that can be kept in memory at the same time n and a reference list containing numbers. Every number represents a page request for a specific page (you can see this number as the unique ID of a page). The expected output is the status of the memory after the application of the algorithm. Note that when a page is inserted in the memory, it stays at the same position until it is removed from the memory by a page fault.

Example:
Given:

N = 3,
REFERENCE LIST = [1, 2, 3, 4, 2, 5],
  * 1 is read, page fault --> memory = [1];
  * 2 is read, page fault --> memory = [1, 2];
  * 3 is read, page fault --> memory = [1, 2, 3];
  * 4 is read, page fault --> memory = [4, 2, 3];
  * 2 is read, already in memory, nothing happens;
  * 5 is read, page fault --> memory = [4, 5, 3].
So, at the end we have the list [4, 5, 3], which is what you have to return. If not all the slots in the memory get occupied after applying the algorithm, fill the remaining slots (at the end of the list) with -1 to represent emptiness (note that the IDs will always be >= 1).
*/

//***************Solution********************
/*
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣀⠔⠊⠉⠉⠑⠢⡀⠀⠀⣀⣀⣀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣴⠒⠉⢀⣠⣤⣈⠁⠀⠀⢘⣦⣼⡿⣿⣞⡇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⡿⣷⡄⣿⢯⣈⣹⡆⠄⠐⣇⢈⡴⠛⠛⠉⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢠⣿⡿⣃⠸⣿⣯⣿⠽⠀⠀⠈⠋⢳⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢠⣿⠀⠀⠀⡙⣦⠀⠀⠀⠀⠀⠀⠀⠘⡄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠸⢿⡓⠿⠟⠛⠉⢳⡀⠀⠀⠀⠀⠀⠀⠙⣄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⡆⣄⣀⣀⣀⣀⣀⠁⠀⠀⠀⠀⠀⠀⠀⠘⣆⣀⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⢀⡀⠀⠀⠀⠀⠀⣷⡿⠛⠉⠉⠉⠀⠀⠀⠀⢀⡆⠐⠀⠀⠀⢹⣿⣹⡷⢤⣀⣀⣤⣀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⣠⡾⠋⠈⠉⠁⠈⠉⠉⠙⡷⢄⣀⠦⠴⠊⠀⠒⣨⠍⠂⠀⠀⠀⠀⠀⣿⣿⣿⣠⣿⡿⠛⠉⠉⠓⠢⢤⣀⡤⠤⠄⠀⠀⠀⣀⣀⣤⣀⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⢀⣴⣊⣍⠁⣿⠀⠀⠀⠀⠀⠀⠀⠀⢰⣷⣤⠤⠤⣄⣀⣾⡝⠁⠀⠀⠀⠀⠀⠀⢰⣿⣿⣿⣿⡿⠃⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢠⣿⠿⠿⠷⠄⢀⣀⣀⠀⠀⠀⠀⠀⠀
⢯⣠⣾⢟⡴⠻⣶⣤⣤⡤⢤⣴⣤⣀⣼⣿⣿⣿⠛⠉⠉⠉⠀⠀⠀⠀⠀⠀⠀⣠⣾⣿⣿⣿⡟⠁⠀⢠⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣿⡏⠀⠀⠀⠀⠀⠀⠐⣺⢽⣽⣦⣀⠀
⠀⠠⣥⣯⠏⠉⠀⠀⠀⠀⠀⠀⠀⠀⣿⣿⣿⡇⠀⠀⠀⠀⠀⠀⠀⠀⢀⣴⣿⣿⣿⣿⣿⡟⠁⠀⠀⠀⢧⡀⠀⢀⣀⢢⡀⠀⠀⠀⠀⠀⣿⡗⡄⠀⠀⠀⢀⣄⡀⠈⠙⣎⠻⣮⡷
⠀⠀⠈⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢿⣿⣿⣧⠀⠀⠀⠀⠀⢀⣠⣾⣿⣿⣿⣿⣿⣿⣿⠁⠂⠀⠀⢲⣿⠟⠛⠋⠉⠙⠛⠓⠛⠒⠤⣤⣽⣷⣄⠀⠀⣾⠛⠛⠻⣷⣄⠼⣆⠱⣼
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸⣿⣿⣿⣿⡓⠒⣶⣶⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣆⣀⣵⣶⣾⣿⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⠉⠈⢦⠀⠘⣆⠀⠀⠈⠿⢭⡿⣤⡾
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣿⣿⣿⣿⣿⠶⠾⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⢆⢄⣼⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠙⣿⠿⠿⢹⡆⠀⠻⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡿⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⠉⠁⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⡇⠀⠀⠈⠁⠀⠀⠈⠉⠉⠉⠛⠛⠛⠛⠉⠉⠉⠉⠁⠀⠘⡇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣷⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣾⡏⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣠⣾⣿⡇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠸⣄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣠⣾⡿⠏⠀⡇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⠢⣄⡀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣠⣴⣾⣿⡿⠋⠀⡠⠀⡇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢻⣿⣷⣶⣶⣶⣶⣷⣶⣾⣿⡿⠿⠛⠁⢀⡴⠊⠁⠀⡇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸⡇⠙⢿⡋⠉⠉⠉⠉⠁⠀⠀⠀⠴⠚⠁⠀⠀⠀⢀⡇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸⡁⠀⠀⠈⠀⠈⠉⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⡾⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⠻⣦⡄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣠⣴⠟⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠙⢿⣦⣤⣤⣠⣤⣤⣤⣤⣤⣶⣶⣿⡟⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣿⣿⣿⣿⣿⣿⢹⣟⠋⠉⣿⣿⣿⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢹⣿⢿⣿⣿⣿⢸⣿⣧⢠⣿⣿⣿⡇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠘⣿⣠⣿⣿⣟⢸⣿⣿⡏⣿⣿⣿⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢻⣿⣿⣿⡿⠀⣿⡃⠃⣸⣿⠇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣿⣿⣿⣿⡇⠀⣿⣧⢸⣿⣿⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣾⣿⣿⣿⣿⡿⠘⣿⣿⣿⣿⡟⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢠⣿⣿⣿⣿⠟⠋⠀⣰⣿⣿⣿⣿⡇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠘⠿⠿⠟⠃⠀⢀⣼⣿⣿⣿⣿⣿⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸⣿⣿⣿⣿⠿⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
*/
using System.Linq;
using System.Collections.Generic;

public class PageReplacementAlgorithms{
    public static List<int> Fifo(int n, List<int> referenceList, int pos = 0){
      //replacement for number, repeat -1 n times and store as list.
      var stack = Enumerable.Repeat(-1, n).ToList();
      
      //if stack doesn't contains the item from referenceList, replace stack index([pos++ %n]) by item.
      //pos increase by 1 each iteration, mod n, the maximum pages that can be kept in memory
      foreach(int item in referenceList.Where(item => !stack.Contains(item)))
        stack[pos++ % n] = item;
      
        return stack;
    }
}

//solution 2
using System.Collections.Generic;

public class PageReplacementAlgorithms
{
    public static List<int> Fifo(int n, List<int> referenceList)
    {
      List<int> result = new List<int>();
      
      for(int i = 0; i < n; i++)
      {
        result.Add(-1);
      }

      int counter = 0;

      foreach(int i in referenceList)
      {
        if(!result.Exists(e => e == i))
        {
          result[counter % n] = i;
          counter++;
        }
      }
      
      return result;
    }
}
//****************Sample Test*****************
namespace Tests
{
    using System.Collections.Generic;
    using System.Linq;
    using NUnit.Framework;
    using System;
  
    [TestFixture, Description("Fixed Tests")]
    public class FixedTests
    {
        [Test]
        public void Tests()
        {
            List<List<int>> referenceLists = new List<List<int>>(new List<int>[]{
                new List<int>(new int[]{1, 2, 3, 4, 2, 5}),
                new List<int>(new int[]{}),
                new List<int>(new int[]{1, 2, 3, 3, 4, 5, 1}),
                new List<int>(new int[]{1, 1, 1, 2, 2, 3}),
                new List<int>(new int[]{5, 4, 3, 3, 4, 10}),
                new List<int>(new int[]{1, 1, 1, 1, 1, 1, 1, 1}),
                new List<int>(new int[]{10, 9, 8, 7, 7, 8, 7, 6, 5, 4, 3, 4, 3, 4, 5, 6, 5})
            });
          
            List<List<int>> results = new List<List<int>>(new List<int>[]{
                new List<int>(new int[]{4, 5, 3}),
                new List<int>(new int[]{-1, -1, -1, -1, -1}),
                new List<int>(new int[]{5, 1, 3, 4}),
                new List<int>(new int[]{1, 2, 3, -1}),
                new List<int>(new int[]{10}),
                new List<int>(new int[]{1, -1, -1}),
                new List<int>(new int[]{5, 4, 3, 7, 6})
            });
          
            int[] ns = new int[]{3, 5, 4, 4, 1, 3, 5};

            for (int i = 0; i < referenceLists.Count; i++)
            {
                string referenceListString = string.Join(", ", referenceLists[i]);
                string expectedString = string.Join(", ", results[i]);
              
                List<int> actual = PageReplacementAlgorithms.Fifo(ns[i], new List<int>(referenceLists[i]));
                string actualString = string.Join(", ", actual);  
              
                if (results[i].SequenceEqual(actual))
                  Assert.Pass();
                else
                  Assert.Fail($"N = {ns[i]}, REFERENCE LIST = [{referenceListString}]: [{actualString}] should equal [{expectedString}]");
            }
        }
    }
  
    [TestFixture, Description("Random Tests")]
    public class RandomTests
    {
        private static List<int> ReferenceSolution(int n, List<int> referenceList)
        {
            List<int> result = Enumerable.Repeat(-1, n).ToList();
            HashSet<int> referenceSet = new HashSet<int>();
            int pointer = 0;

            foreach (int reference in referenceList)
            {
                if (referenceSet.Add(reference))
                {
                    referenceSet.Remove(result[pointer]);
                    result[pointer] = reference;
                    pointer = (pointer + 1) % n;
                }
            }

            return result;
        }
      
        [Test]
        public void Tests()
        {
            Random generator = new();
          
            for (int _ = 0; _ < 100; _++)
            {
                List<int> referenceList = new List<int>();
              
                int n = generator.Next(2, 51);
                
                for (int __ = 0; __ < n; __++)
                  referenceList.Add(generator.Next(1, 26));
                
                string referenceListString = string.Join(", ", referenceList);
                List<int> expected = ReferenceSolution(n, referenceList);
                
                List<int> actual = PageReplacementAlgorithms.Fifo(n, new List<int>(referenceList));
                string actualString = string.Join(", ", actual);  
              
                string expectedString = string.Join(", ", expected);
                
                if (expected.SequenceEqual(actual))
                  Assert.Pass();
                else
                  Assert.Fail($"N = {n}, REFERENCE LIST = [{referenceListString}]: [{actualString}] should equal [{expectedString}]");
            }
        }
    }
}
