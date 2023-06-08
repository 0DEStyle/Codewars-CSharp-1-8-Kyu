/*Challenge link:https://www.codewars.com/kata/55befc42bfe4d13ab1000007/train/csharp
Question:
Linked Lists - Get Nth
Implement a GetNth() function that takes a linked list and an integer index and returns the node stored at the Nth index position. GetNth() uses the C numbering convention that the first node is index 0, the second is index 1, ... and so on.

So for the list 42 -> 13 -> 666, GetNth(1) should return Node(13);

Node.GetNth(1 -> 2 -> 3 -> null, 0).Data == 1
Node.GetNth(1 -> 2 -> 3 -> null, 1).Data == 2
The index should be in the range [0..length-1]. If it is not, or if the list is empty, GetNth() should throw/raise an exception (ArgumentException in C#, InvalidArgumentException in PHP, Exception in Java).
*/

//***************Solution********************

using System;

public partial class Node{
  public int Data;
  public Node Next;
  
  public Node(int data){
    Data = data;
    Next = null;
  }
  
  public static Node GetNth(Node node, int index) =>
    node == null ? throw new ArgumentException() : index == 0 ? node : GetNth(node.Next, index - 1);
}


//****************Sample Test*****************
namespace Solution 
{
  using NUnit.Framework;
  using System;

  [TestFixture]
  public class SolutionTest
  {
    [Test, Description("tests for getting the Nth node in a linked list.")]
    public void Test()
    {
      Node list = Node.BuildOneTwoThree();
      
      Assert.AreEqual(1, Node.GetNth(list, 0).Data, "First node should be located at index 0.");
      Assert.AreEqual(2, Node.GetNth(list, 1).Data, "Second node should be located at index 1.");
      Assert.AreEqual(3, Node.GetNth(list, 2).Data, "Third node should be located at index 2.");
      Assert.Throws<ArgumentException>(() => Node.GetNth(list, 3), "Invalid index value should throw an exception.");
      Assert.Throws<ArgumentException>(() => Node.GetNth(list, -3), "Invalid index value should throw an exception.");
      Assert.Throws<ArgumentException>(() => Node.GetNth(list, 100), "Invalid index value should throw an exception.");
      Assert.Throws<ArgumentException>(() => Node.GetNth(null, 0), "Null linked list should throw an exception.");
    }
  }
}
