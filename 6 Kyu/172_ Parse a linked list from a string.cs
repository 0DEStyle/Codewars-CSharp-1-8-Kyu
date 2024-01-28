/*Challenge link:https://www.codewars.com/kata/582c5382f000e535100001a7/train/csharp
Question:
Parse a linked list from a string
Related Kata
Although this Kata is not part of an official Series, you may want to complete this Kata before attempting this one as these two Kata are deeply related.

Preloaded
Preloaded for you is a class, struct or derived data type Node ( depending on the language ) used to construct linked lists in this Kata:

public class Node : Object
{
  public int Data;
  public Node Next;
  
  public Node(int data, Node next = null)
  {
    this.Data = data;
    this.Next = next;
  }
  
  public override bool Equals(Object obj)
  {
    // Check for null values and compare run-time types.
    if (obj == null || GetType() != obj.GetType()) { return false; }
  
    return this.ToString() == obj.ToString();
  }
  
  public override string ToString()
  {
    List<int> result = new List<int>();
    Node curr = this;
    
    while (curr != null)
    {
      result.Add(curr.Data);
      curr = curr.Next;
    }
    
    return String.Join(" -> ", result) + " -> null";
  }
}
Prerequisites
This Kata assumes that you are already familiar with the idea of a linked list. If you do not know what that is, you may want to read up on this article on Wikipedia. Specifically, the linked lists this Kata is referring to are singly linked lists, where the value of a specific node is stored in its data / $data/Data property, the reference to the next node is stored in its next / $next / Next property and the terminator for a list is null / NULL / nil / nullptr / null() / [].

Additionally, this Kata assumes that you have basic knowledge of Object-Oriented Programming ( or a similar concept ) in the programming language you are undertaking. If you have not come across Object-Oriented Programming in your selected language, you may want to try out an online course or read up on some code examples of OOP in your selected language up to ( but not necessarily including ) Classical Inheritance.

Specifically, if you are attempting this Kata in PHP and haven't come across OOP, you may want to try out the first 4 Kata in this Series.

Task
Create a function parse which accepts exactly one argument string / $string / s / strrep ( or similar, depending on the language ) which is a string representation of a linked list. Your function must return the corresponding linked list, constructed from instances of the Node class/struct/type. The string representation of a list has the following format: the value of the node, followed by a whitespace, an arrow and another whitespace (" -> "), followed by the rest of the linked list. Each string representation of a linked list will end in "null" / "NULL" / "nil" / "nullptr" / "null()" depending on the language you are undertaking this Kata in. For example, given the following string representation of a linked list:

... your function should return:

Note that due to the way the constructor for Node is defined, if a second argument is not provided, the next / $next / Next field is automatically set to null / NULL / nil / nullptr ( or equivalent in your language ). That means your function could also return the following ( if it helps you better visualise what is actually going on ):

Another example: given the following string input:

... your function should return:

If the input string is just "null" / "NULL" / "nil" / "nullptr" / "null()", return null / NULL / nil / nullptr / null() / [] ( or equivalent ).

For the simplicity of this Kata, the values of the nodes in the string representation will always ever be non-negative integers, so the following would not occur: "Hello World -> Goodbye World -> 123 -> null" / "Hello World -> Goodbye World -> 123 -> NULL" / "Hello World -> Goodbye World -> 123 -> nil" / "Hello World -> Goodbye World -> 123 -> nullptr" ( depending on the language ). This also means that the values of each Node must also be non-negative integers so keep that in mind when you are parsing the list from the string.

Enjoy, and don't forget to check out my other Kata Series :D
*/

//***************Solution********************
using System;
using System.Linq;


public static class Kata{
  public static Node Parse(string nodes){
    //Console.WriteLine("string: " + nodes);
    
    //check null
    if(nodes == "null") return null;
    //split by " -> " and store in array
    var nodesArr = nodes.Split(" -> ").ToArray();
    
    //set the first element in nodesArr as the head node
    //store the head in current node
    Node head = new Node(Convert.ToInt32(nodesArr[0]));
    Node currNode = head;
    
    //iterate throught each nodes, starting from 1
    //create new Node, store element i in nodesArr as next current node
    //then set next node as current node.
    for(int i  = 1; i < nodesArr.Length - 1; i++){
      currNode.Next = new Node(Convert.ToInt32(nodesArr[i]));
      currNode = currNode.Next;
      //Console.WriteLine("res: " + head);
    }
    return head;
  }
}

//solution 2
using System;
using System.Linq;
using System.Collections.Generic;

public static class Kata
{
  public static Node Parse(string nodes)
  {
    return 
      nodes
         .Split(new[] {" -> "}, StringSplitOptions.None)
         .Reverse()
         .Skip(1)
         .Select(x => int.Parse(x))
         .Aggregate((Node)null, (acc, e) => new Node(e, acc)) ;

  }
}

//solution 3
using System;

public static class Kata
{
    public static Node Parse(string nodes)
    {
        return NAdd(nodes.Split(" -> "));
    }
    public static Node NAdd(string[] arr)
    {
        if (arr[0] == "null")
            return null;
        return new Node(Convert.ToInt32(arr[0]), NAdd(arr[1..]));
    }
}

//solution 4
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Numerics;
using System.Text;

public static class Kata
{
  public static Node Parse(string nodes)
  {
    if (nodes == "null") return null;
    List<string> lstNodes = nodes.Split(" -> ").ToList();

    Node head = new Node(int.Parse(lstNodes[0]));
    Node nod=head;
    for (var i = 1; i < lstNodes.Count-1; i++)
    {
        nod.Next = new Node(int.Parse(lstNodes[i]));
        nod = nod.Next;
    }
    return head;
  }
}
//****************Sample Test*****************
namespace Solution 
{
  using NUnit.Framework;
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Text.RegularExpressions;

  public static class Solution
  {
    public static Node Parse(string nodes)
    {
      string[] datas = Regex.Split(nodes, @"\s->\s");
      Node result = null;
    
      foreach (int data in Enumerable.Reverse(datas.Take(datas.Length - 1).Select(Int32.Parse)))
      {
        result = new Node(data, result);
      }
      
      return result;
    }
  }

  [TestFixture]
  public class SolutionTest
  {
    [Test, Description("should pass the example tests provided in the Description")]
    public void SampleTest()
    {
      Assert.AreEqual(new Node(1, new Node(2, new Node(3))), Kata.Parse("1 -> 2 -> 3 -> null"));
      Assert.AreEqual(new Node(0, new Node(1, new Node(4, new Node(9, new Node(16))))), Kata.Parse("0 -> 1 -> 4 -> 9 -> 16 -> null"));
      Assert.AreEqual(null, Kata.Parse("null"));
    }
    [Test, Description("should pass all of the fixed tests provided")]
    public void FixedTest()
    {
      Assert.AreEqual(new Node(16), Kata.Parse("16 -> null"));
      Assert.AreEqual(new Node(125, new Node(64, new Node(27, new Node(8, new Node(1))))), Kata.Parse("125 -> 64 -> 27 -> 8 -> 1 -> null"));
      Assert.AreEqual(new Node(55, new Node(45, new Node(36, new Node(28, new Node(21, new Node(15, new Node(10, new Node(6, new Node(3, new Node(1, new Node(0))))))))))), Kata.Parse("55 -> 45 -> 36 -> 28 -> 21 -> 15 -> 10 -> 6 -> 3 -> 1 -> 0 -> null"));
      Assert.AreEqual(new Node(1, new Node(1, new Node(2, new Node(3, new Node(5, new Node(8, new Node(13))))))), Kata.Parse("1 -> 1 -> 2 -> 3 -> 5 -> 8 -> 13 -> null"));
      Assert.AreEqual(new Node(0, new Node(1, new Node(1, new Node(2, new Node(3, new Node(5, new Node(8, new Node(13, new Node(21, new Node(34, new Node(55, new Node(89, new Node(144, new Node(233, new Node(377, new Node(610, new Node(987, new Node(1597)))))))))))))))))), Kata.Parse("0 -> 1 -> 1 -> 2 -> 3 -> 5 -> 8 -> 13 -> 21 -> 34 -> 55 -> 89 -> 144 -> 233 -> 377 -> 610 -> 987 -> 1597 -> null"));
    }
    
    // Translators note: Next two tests not applicable to C#
    
    [Test, Description("should pass all 100 random tests provided")]
    public void RandomTest()
    {
      const int Tests = 100;
      Random rnd = new Random();
      
      for (int i = 0; i < 100; ++i)
      {
        Node node = Node.Build(new int[rnd.Next(0, 100)].Select(_ => rnd.Next()));
        String nodes = "";
        
        if (node == null)
        {
          nodes = "null";
        }
        else
        {
          nodes = node.ToString();
        }
        
        Node expected = Solution.Parse(nodes);
        Node actual = Kata.Parse(nodes);
        
        Assert.AreEqual(expected, actual);
      }
    }
  }
}
