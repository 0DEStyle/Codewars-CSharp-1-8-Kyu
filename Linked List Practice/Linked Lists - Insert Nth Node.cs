/*Challenge link:https://www.codewars.com/kata/55cacc3039607536c6000081/train/csharp
Question:
Linked Lists - Insert Nth

Implement an InsertNth() function (insert_nth() in PHP) which can insert a new node at any index within a list.

InsertNth() is a more general version of the Push() function that we implemented in the first kata listed below. Given a list, an index 'n' in the range 0..length, and a data element, add a new node to the list so that it has the given index. InsertNth() should return the head of the list.

Node.InsertNth(1 -> 2 -> 3 -> null, 0, 7)  => 7 -> 1 -> 2 -> 3 -> null
Node.InsertNth(1 -> 2 -> 3 -> null, 1, 7)  => 1 -> 7 -> 2 -> 3 -> null
Node.InsertNth(1 -> 2 -> 3 -> null, 3, 7)  => 1 -> 2 -> 3 -> 7 -> null
Node.InsertNth(1 -> 2 -> 3 -> null, -2, 7) // throws new ArgumentException
You must throw/raise an exception (ArgumentOutOfRangeException in C#, InvalidArgumentException in PHP) if the index is too large.

The push() and buildOneTwoThree() (build_one_two_three() in PHP) functions do not need to be redefined. The Node class is also preloaded for you in PHP.
*/

//***************Solution********************
using System;

public partial class Node{
  public int Data;
  public Node Next;
  
  public Node(int data, Node next = null){
    Data = data;
    Next = next;
  }
  
  public static Node InsertNth(Node head, int index, int data){
    if (index < 0 || (index > 0 && head == null))
      throw new ArgumentOutOfRangeException();
    
    if (index == 0)
      return new Node(data,head);
    else{
      head.Next =  InsertNth(head.Next, index - 1, data);
      return head;
    }
  }
}



//****************Sample Test*****************
namespace Solution 
{
  using NUnit.Framework;
  using System;

  [TestFixture]
  public class SolutionTest
  {
    [Test, Description("should be able to handle an empty list.")]
    public void EmptyTest()
    {
      Assert.AreEqual(12, Node.InsertNth(null, 0, 12).Data, "should be able to insert a node on an empty/null list.");
      Assert.AreEqual(null, Node.InsertNth(null, 0, 12).Next, "value at index 1 should be null.");
    }
    
    [Test, Description("should be able to insert a new node at the head of a list.")]
    public void TestIndex0()
    {
      Assert.AreEqual(23, Node.InsertNth(Node.BuildOneTwoThree(), 0, 23).Data, "should be able to insert new node at head of list.");
      Assert.AreEqual(1, Node.InsertNth(Node.BuildOneTwoThree(), 0, 23).Next.Data, "value for node at index 1 should be 1.");
      Assert.AreEqual(2, Node.InsertNth(Node.BuildOneTwoThree(), 0, 23).Next.Next.Data, "value for node at index 2 should be 2.");
      Assert.AreEqual(3, Node.InsertNth(Node.BuildOneTwoThree(), 0, 23).Next.Next.Next.Data, "value for node at index 3 should be 3.");
      Assert.AreEqual(null, Node.InsertNth(Node.BuildOneTwoThree(), 0, 23).Next.Next.Next.Next, "value at index 4 should be null.");
    }
    
    [Test, Description("should be able to insert a new node at index 1 of a list.")]
    public void TestIndex1()
    {
      Assert.AreEqual(1, Node.InsertNth(Node.BuildOneTwoThree(), 1, 23).Data, "value for node at index 0 should remain unchanged.");
      Assert.AreEqual(23, Node.InsertNth(Node.BuildOneTwoThree(), 1, 23).Next.Data, "value for node at index 1 should be 23.");
      Assert.AreEqual(2, Node.InsertNth(Node.BuildOneTwoThree(), 1, 23).Next.Next.Data, "value for node at index 2 should be 2.");
      Assert.AreEqual(3, Node.InsertNth(Node.BuildOneTwoThree(), 1, 23).Next.Next.Next.Data, "value for node at index 3 should be 3.");
      Assert.AreEqual(null, Node.InsertNth(Node.BuildOneTwoThree(), 1, 23).Next.Next.Next.Next, "value at index 4 should be null.");
    }
    
    [Test, Description("should be able to insert a new node at index 2 of a list.")]
    public void TestIndex2()
    {
      Assert.AreEqual(1, Node.InsertNth(Node.BuildOneTwoThree(), 2, 23).Data, "value for node at index 0 should remain unchanged.");
      Assert.AreEqual(2, Node.InsertNth(Node.BuildOneTwoThree(), 2, 23).Next.Data, "value for node at index 1 should remain unchanged.");
      Assert.AreEqual(23, Node.InsertNth(Node.BuildOneTwoThree(), 2, 23).Next.Next.Data, "value for node at index 2 should be 23.");
      Assert.AreEqual(3, Node.InsertNth(Node.BuildOneTwoThree(), 2, 23).Next.Next.Next.Data, "value for node at index 3 should be 3.");
      Assert.AreEqual(null, Node.InsertNth(Node.BuildOneTwoThree(), 2, 23).Next.Next.Next.Next, "value at index 4 should be null.");
    }
    
    [Test, Description("should be able to insert a new node at the tail of a list.")]
    public void TestIndex3()
    {
      Assert.AreEqual(1, Node.InsertNth(Node.BuildOneTwoThree(), 3, 23).Data, "head should remain unchanged after inserting new node at tail");
      Assert.AreEqual(2, Node.InsertNth(Node.BuildOneTwoThree(), 3, 23).Next.Data, "value at index 1 should remain unchanged after inserting new node at tail");
      Assert.AreEqual(3, Node.InsertNth(Node.BuildOneTwoThree(), 3, 23).Next.Next.Data, "value at index 2 should remain unchanged after inserting new node at tail");
      Assert.AreEqual(23, Node.InsertNth(Node.BuildOneTwoThree(), 3, 23).Next.Next.Next.Data, "value for node at index 3 should be 23.");
      Assert.AreEqual(null, Node.InsertNth(Node.BuildOneTwoThree(), 3, 23).Next.Next.Next.Next, "value at index 4 should be null.");
    }
    
    [Test, Description("should throw ArgumentOutOfRangeException if index is out of range")]
    public void ExceptionTest()
    {
      Assert.Throws<ArgumentOutOfRangeException>(() => Node.InsertNth(Node.BuildOneTwoThree(), 4, 23), "Invalid index value should throw ArugmentException");
      Assert.Throws<ArgumentOutOfRangeException>(() => Node.InsertNth(Node.BuildOneTwoThree(), -4, 23), "Invalid index value should throw ArugmentException");
    }
  }
}
