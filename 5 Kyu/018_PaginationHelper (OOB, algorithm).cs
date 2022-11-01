/*Challenge link:https://www.codewars.com/kata/515bb423de843ea99400000a/train/csharp
Question:
For this exercise you will be strengthening your page-fu mastery. You will complete the PaginationHelper class, which is a utility class helpful for querying paging information related to an array.

The class is designed to take in an array of values and an integer indicating how many items will be allowed per each page. The types of values contained within the collection/array are not relevant.

The following are some examples of how this class is used:

var helper = new PaginationHelper<char>(new List<char>{'a', 'b', 'c', 'd', 'e', 'f'}, 4);
helper.PageCount(); //should == 2
helper.ItemCount(); //should == 6
helper.PageItemCount(0); //should == 4
helper.PageItemCount(1); // last page - should == 2
helper.PageItemCount(2); // should == -1 since the page is invalid

// pageIndex takes an item index and returns the page that it belongs on
helper.PageIndex(5); //should == 1 (zero based index)
helper.PageIndex(2); //should == 0
helper.PageIndex(20); //should == -1
helper.PageIndex(-10); //should == -1
*/

//***************Solution********************

using System;
using System.Collections.Generic;

public class PagnationHelper<T>{
    public IList<T> Collection { get; set; }  // <param name="collection">A list of items
    public int ItemsPerPage { get; set; }     // The number of items that fit within a single page
    public int ItemCount => Collection.Count; // The number of items within the collection
    public int PageCount => Convert.ToInt32(Math.Ceiling((1.0 * ItemCount) / ItemsPerPage)); // The number of pages
    
    public PagnationHelper(IList<T> collection, int itemsPerPage){ 
        Collection = collection;
        ItemsPerPage = itemsPerPage;
    }
    // Returns the number of items in the page at the given page index 
    // The zero-based page index to get the number of items for
    // The number of items on the specified page or -1 for pageIndex values that are out of range
    public int PageItemCount(int pageIndex) =>
        pageIndex >= 0 && pageIndex < PageCount - 1 ? ItemsPerPage :
        pageIndex == PageCount - 1 ? ItemCount % ItemsPerPage :
        -1;
        
    // Returns the page index of the page containing the item at the given item index.
    // The zero-based index of the item to get the pageIndex for
    // The zero-based page index of the page containing the item at the given item index 
    // or -1 if the item index is out of range
    public int PageIndex(int itemIndex) =>
        itemIndex >= 0 && itemIndex < ItemCount ? itemIndex / ItemsPerPage : -1;
}

//****************Sample Test*****************
namespace Solution {
  using NUnit.Framework;
  using System;
  using System.Collections.Generic;
  [TestFixture]
  public class PagnationHelperTests
  {
    private readonly IList<int> collection = new List<int> {1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24};
    private PagnationHelper<int> helper;
    
    [SetUp]
    public void SetUp()
    {
      helper = new PagnationHelper<int>(collection, 10);
    }
    
    [Test]
    [TestCase(-1, ExpectedResult=-1)]
    [TestCase(0, ExpectedResult=10)]
    [TestCase(1, ExpectedResult=10)]
    [TestCase(2, ExpectedResult=4)]
    [TestCase(3, ExpectedResult=-1)]
    public int PageItemCountTest(int pageIndex)
    {
      return helper.PageItemCount(pageIndex);
    }
    
    [Test]
    [TestCase(-1, ExpectedResult=-1)]
    [TestCase(0, ExpectedResult=0)]
    [TestCase(1, ExpectedResult=0)]
    [TestCase(9, ExpectedResult=0)]
    [TestCase(10, ExpectedResult=1)]
    [TestCase(11, ExpectedResult=1)]
    [TestCase(19, ExpectedResult=1)]
    [TestCase(20, ExpectedResult=2)]
    [TestCase(21, ExpectedResult=2)]
    [TestCase(22, ExpectedResult=2)]
    [TestCase(23, ExpectedResult=2)]
    [TestCase(24, ExpectedResult=-1)]
    public int PageIndexTest(int itemIndex)
    {
      return helper.PageIndex(itemIndex);
    }
    
    [Test]
    public void ItemCountTest()
    {
      Assert.AreEqual(24, helper.ItemCount);
    }
    
    [Test]
    public void PageCountTest()
    {
      Assert.AreEqual(3, helper.PageCount);
    }
    
    [Test]
    public void EmptyCollectionPageIndexTest()
    {
      helper = new PagnationHelper<int>(new List<int>(), 10);
      Assert.AreEqual(-1, helper.PageIndex(0));
    } 
  }
}
