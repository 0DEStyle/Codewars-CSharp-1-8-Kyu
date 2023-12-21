/*Challenge link:https://www.codewars.com/kata/5388f0e00b24c5635e000fc6/train/csharp
Question:
I would like to be able to pass an array with two elements to my swapValues function to swap the values. However it appears that the values aren't changing.

Can you figure out what's wrong here?
*/

//***************Solution********************//change args to Arguments
public class Swapper{
    public object[] Arguments { get; private set; }
    
    public Swapper(object[] args) => Arguments = args;
    
    
    public void SwapValues(){
        object[] args = new[] { Arguments[0], Arguments[1] };
        
        object temp = Arguments[0];
        Arguments[0] = Arguments[1];
        Arguments[1] = temp;
    }
}

//****************Sample Test*****************
namespace Solution
{
    using NUnit.Framework;
    
    using System;
    using System.Linq;
    
    [TestFixture]
    public class Tests
    {
        [Test]
        public void ExampleTest()
        {
            int[] args = new[] { 1, 2 };
            
            Swapper swapper = new Swapper(args.Cast<object>().ToArray());
            swapper.SwapValues();
            
            Assert.AreEqual(2, swapper.Arguments[0], "Failed swapping numbers");
            Assert.AreEqual(1, swapper.Arguments[1], "Failed swapping numbers");
        }
        
        [Test]
        public void StringTest()
        {
            string[] args = new[] { "1", "2" };
            
            Swapper swapper = new Swapper(args.Cast<object>().ToArray());
            swapper.SwapValues();
            
            Assert.AreEqual("2", swapper.Arguments[0], "Failed swapping numbers");
            Assert.AreEqual("1", swapper.Arguments[1], "Failed swapping numbers");
        }
        
        [Test]
        public void DifferentSubtypesTest()
        {
            object[] args = new object[] { "1", 2 };
            
            Swapper swapper = new Swapper(args);
            swapper.SwapValues();
            
            Assert.AreEqual(2, swapper.Arguments[0], "Failed swapping numbers");
            Assert.AreEqual("1", swapper.Arguments[1], "Failed swapping numbers");
        }
        
        [Test]
        public void ArraysTest()
        {
            object[] args = new object[] { new[] { "1" }, new[] { 2 } };
            
            Swapper swapper = new Swapper(args);
            swapper.SwapValues();
            
            Assert.AreEqual(2, (swapper.Arguments[0] as int[])[0], "Failed swapping numbers");
            Assert.AreEqual("1", (swapper.Arguments[1] as string[])[0], "Failed swapping numbers");
        }
    }
}
