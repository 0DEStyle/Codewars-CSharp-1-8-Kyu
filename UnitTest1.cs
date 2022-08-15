using NUnit.Framework;

namespace NUnitTest;
public class Tests
{
    
    [Test]
    public void Test1()
    {
        Assert.AreEqual(new string[] { "ab", "c_" }, TestLibrary.Class1.Solution2("abc"));
        Assert.AreEqual(new string[] { "ab", "cd", "ef" }, TestLibrary.Class1.Solution2("abcdef"));
    }
    


    /*
    [Test]
    public void Test2()
    {
        Assert.AreEqual(1, TestLibrary.Class1.test());
    }
    
*/

}
