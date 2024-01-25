/*Challenge link:https://www.codewars.com/kata/582c297e56373f0426000098/train/csharp
Question:
Convert a linked list to a string
Related Kata
Although this Kata is not part of an official Series, you may also want to try out Parse a linked list from a string if you enjoyed this Kata.

Preloaded
Preloaded for you is a class, struct or derived data type Node ( depending on the language ) used to construct linked lists in this Kata:

public class Node {
  public int Data { get; private set; }
  public Node Next { get; private set; }

  public Node(int data, Node next = null) {
    Data = data;
    Next = next;
  }
}
Prerequisites
This Kata assumes that you are already familiar with the idea of a linked list. If you do not know what that is, you may want to read this article on Wikipedia. Specifically, the linked lists this Kata is referring to are singly linked lists, where the value of a specific node is stored in its data / $data / Data property, the reference to the next node is stored in its next / $next / Next / next_node property and the terminator for a list is null / NULL / None / nil / nullptr / null().

Task
Create a function stringify which accepts an argument list / $list and returns a string representation of the list. The string representation of the list starts with the value of the current Node, specified by its data / $data / Data property, followed by a whitespace character, an arrow and another whitespace character (" -> "), followed by the rest of the list. The end of the string representation of a list must always end with null / NULL / None / nil / nullptr / null() ( all caps or all lowercase depending on the language you are undertaking this Kata in ). For example, given the following list:

new Node(1, new Node(2, new Node(3)))
... its string representation would be:

And given the following linked list:

... its string representation would be:

Note that null / NULL / None / nil / nullptr / null() itself is also considered a valid linked list. In that case, its string representation would simply be "null" / "NULL" / "None" / "nil" / "nullptr" / @"NULL" / "null()" ( again, depending on the language ).

For the simplicity of this Kata, you may assume that any Node in this Kata may only contain non-negative integer values. For example, you will not encounter a Node whose data / $data / Data property is "Hello World".

Enjoy, and don't forget to check out my other Kata Series :D
*/

//***************Solution********************
/*
⠀⠀⠀⠀⠀⠀⠀⠙⣿⣷⣄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⢺⣿⣿⡆⠀⠀⠀⠀⠀⠀⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⢸⣿⣿⡇⠀⠀⠀⠀⠀⠀⣾⢡⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢢⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠈⣿⣿⣷⡦⠀⠀⠀⠀⢰⣿⣿⣷⠀⠀⠀⠀⠀⠀⠀⠀⠃⣠⣾⡇⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⢻⣿⣿⣿⣆⠀⠀⠀⣾⣿⣿⣿⣷⠄⠀⠰⠤⣀⠀⠀⣴⣿⣿⡇⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠃⢺⣿⣿⣿⣿⡄⠀⠀⣿⣿⢿⣿⣿⣦⣦⣦⣶⣼⣭⣼⣿⣿⣿⠇⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⢿⣿⣿⣿⣷⡆⠂⣿⣿⣞⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡄⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⢙⣿⣿⣿⣿⣷⠸⣿⣿⣿⣿⣿⣿⠟⠻⣿⣿⣿⣿⡿⣿⣿⣷⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠄⢿⣿⣿⣿⣿⡄⣿⣿⣿⣿⣿⣿⡀⢀⣿⣿⣿⣿⠀⢸⣿⣿⠅⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠸⣿⣿⣿⣿⣇⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⠁⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠠⢐⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡿⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⣀⣤⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⠟⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⢀⣴⣾⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⡀⣠⣾⣾⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡔⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⢁⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣄⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠠⢸⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣄⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⣀⣶⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡄⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⣻⣿⣿⣿⣿⣿⡟⠋⠙⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡿⠙⢿⣿⣿⣿⣿⣿⣿⣄⠀⠀⠀⠀⠀⠀
⠀⠀⠀⣿⣿⣿⣿⣿⡿⠋⠀⠀⠀⢿⣿⣿⣿⣿⣿⣿⠿⢿⡿⠛⠋⠁⠀⠀⠈⠻⣿⣿⣿⣿⣿⣿⣅⠀⠀⠀⠀⠀
⠀⠀⠀⣿⣿⣿⣿⡟⠃⠀⠀⠀⠀⢸⣿⣿⣿⣿⣿⣿⡄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠙⢻⣿⣿⣿⣿⣿⣤⡀⠀⠀⠀
⠀⠜⢠⣿⣿⣿⣿⠀⠀⠀⠀⠀⠀⠀⢿⣿⣿⣿⣿⣿⣗⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢻⣿⣿⣿⣿⣿⣦⠄⣠⠀
⠠⢸⣿⣿⣿⣿⣿⠀⠀⠀⠀⠀⠀⠀⢸⣿⣿⣿⣿⣿⣿⢀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠘⣿⣿⣿⣿⣿⣿⣿⣿
⠀⠛⣿⣿⣿⡿⠏⠀⠀⠀⠀⠀⠀⢳⣾⣿⣿⣿⣿⣿⣿⡶⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣿⣿⣿⣿⣿⣿⣿
⠀⢨⠀⠉⠉⠀⠀⠀⠀⠀⠀⠀⠀⠙⣿⣿⡿⡿⠿⠛⠙⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠹⠏⠉⠻⠿⠟⠁
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
*/
//if list is null, return "null"
//else format list.Data with " -> ", then with recursively pass list.Next node into Stringify;
public class Kata{
  public static string Stringify(Node list){ 
    if(list == null) return "null";
    return list.Data + " -> " + Stringify(list.Next);
  }
}

//****************Sample Test*****************
namespace Solution {
  using NUnit.Framework;
  using System;

  [TestFixture]
  public class SolutionTest
  {
    [Test]
    public void SampleTest()
    {
      Assert.AreEqual("1 -> 2 -> 3 -> null", Kata.Stringify(new Node(1, new Node(2, new Node(3)))));
      Assert.AreEqual("0 -> 1 -> 4 -> 9 -> 16 -> null", Kata.Stringify(new Node(0, new Node(1, new Node(4, new Node(9, new Node(16)))))));
      Assert.AreEqual("null", Kata.Stringify(null));
    }
    
    [Test]
    public void FixedTest()
    {
      Assert.AreEqual("23 -> null", Kata.Stringify(new Node(23)));
      Assert.AreEqual("4 -> 25 -> null", Kata.Stringify(new Node(4, new Node(25))));
      Assert.AreEqual("1 -> 3 -> 6 -> 10 -> 15 -> 21 -> 28 -> 36 -> 45 -> 55 -> null", Kata.Stringify(new Node(1, new Node(3, new Node(6, new Node(10, new Node(15, new Node(21, new Node(28, new Node(36, new Node(45, new Node(55))))))))))));
      Assert.AreEqual("1 -> 1 -> 2 -> 3 -> 5 -> 8 -> 13 -> null", Kata.Stringify(new Node(1, new Node(1, new Node(2, new Node(3, new Node(5, new Node(8, new Node(13)))))))));
      Assert.AreEqual("0 -> 1 -> 1 -> 2 -> 3 -> 5 -> 8 -> 13 -> 21 -> 34 -> 55 -> 89 -> 144 -> 233 -> 377 -> 610 -> 987 -> 1597 -> null", Kata.Stringify(new Node(0, new Node(1, new Node(1, new Node(2, new Node(3, new Node(5, new Node(8, new Node(13, new Node(21, new Node(34, new Node(55, new Node(89, new Node(144, new Node(233, new Node(377, new Node(610, new Node(987, new Node(1597))))))))))))))))))));
    }
    
    private static Random rnd = new Random();
    
    private static string Solution(Node list) => (list == null) ? "null" : $"{list.Data} -> " + Solution(list.Next);
    
    private static Node RandomLinkedList()
    {
      Node list = null;
      int loops = rnd.Next(0, 26);
      for (int i = 0; i < loops; ++i)
      {
        list = new Node(rnd.Next(0, 101), list);
      }
      return list;
    }
    
    [Test]
    public void RandomTest()
    {
      for (int i = 0; i < 100; ++i)
      {
        Node list = RandomLinkedList();
        string expected = Solution(list);
        string actual = Kata.Stringify(list);
        Console.WriteLine("Expected: \"{0}\"\nActual:   \"{1}\"\n", expected, actual);
        Assert.AreEqual(expected, actual);
      }
    }
  }
}
