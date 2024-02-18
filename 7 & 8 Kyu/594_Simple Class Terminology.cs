/*Challenge link:https://www.codewars.com/kata/58cfe6c9f9dffe0f5100017f/train/csharp
Question:
In this Kata you will need to fill out the missing components of a class as described below. The behaviour of the various components is not being assessed, instead the validy of declaration (for example, are things private/public).

The class you are creating (DemoClass) needs:

A private int field, called _privateField.

A public string field, called PublicField, with a default value of "None".

An integer property (called LimitedProperty), that has a public get, and private set.

A constructor that take exactly 1 integer argument and uses it as the default value for _privateField.

Valid use of this class would be:

var instance = new DemoClass(4);
instance.PublicField = 15; //legal, because an int will cast to a string automatically
Console.WriteLine("Property + PublicField: " + (instance.LimitedProperty+instance.PublicField));
Property + PublicField: 015

(Notice there is no way to set LimitedProperty from outside the class)

Invalid use:

var instance = new DemoClass(4);
instance.LimitedProperty = 6; //setter is private
Console.WriteLine(instance._privateField);//everything about _privateField is private;
Compile time error

You don't need any extra methods or fields.

This example isn't highly functional, but it serves to test knowledge of Object Oriented terminology such as Field, Property, Constructor, and Argument.

Hint: there are at least 2 different ways to declare LimitedProperty - one is much easier than the other at just a single line of code.

An aside: the tests use reflection to ensure the final class is structured correctly, this is somewhat advanced C# code, so don't feel overwhelmed if you don't understand them.
*/

//***************Solution********************
/*
⬜⬜⬜⬜⬜⬜⬜⬛⬛⬛⬛⬛⬛⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜
⬜⬜⬜⬜⬜⬜⬛🟨🟨🟨🟨🟨🟨⬛⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜
⬜⬜⬜⬜⬜⬛🟨🟨🟨🟨🟨🟨🟨🟨⬛⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜
⬜⬜⬜⬜⬛🟨🟨🟨🟨⬛⬛⬜🟨🟨🟨⬛⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜
⬜⬜⬜⬜⬛🟨🟨🟨🟨⬛⬛⬛🟨🟨🟨⬛⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜
⬜⬜⬜⬜⬛⬛🟨🟨🟨⬛⬛⬛🟨🟨🟨⬛⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜
⬜⬜⬜⬛🟨🟨⬛🟨🟨🟨🟨🟨🟨🟨🟨⬛⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜
⬜⬛⬛🟨🟨🟨🟨⬛🟨🟨🟨🟨🟨🟨🟨⬛⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜
⬛🟨🟨🟨🟨🟧🟧⬛🟨🟨🟨🟨🟨🟨🟨⬛⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜
⬜⬛🟧🟧🟧🟧🟧⬛⬛🟨🟨🟨🟨🟨⬛⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬛
⬜⬜⬛⬛⬛⬛⬛🟨🟨🟨🟨🟨🟨🟨⬛⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬛⬛
⬜⬜⬜⬜⬜⬜⬛🟨🟨🟨🟨🟨🟨⬛🟨⬛⬛⬛⬛⬛⬜⬜⬜⬜⬜⬛🟨⬛
⬜⬜⬜⬜⬜⬜⬜⬛🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨⬛⬛⬛⬛⬛🟨🟨⬛
⬜⬜⬜⬜⬜⬜⬛🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨⬛
⬜⬜⬜⬜⬜⬛🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨⬛
⬜⬜⬜⬜⬛🟨🟨🟨🟨🟨🟨🟨🟨🟨⬛⬛⬛🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨⬛
⬜⬜⬜⬜⬛🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨⬛🟨🟨🟨🟨🟨🟨🟨🟨⬛⬜
⬜⬜⬜⬜⬛🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨⬛⬛🟨🟨🟨🟨🟨🟨⬛⬜
⬜⬜⬜⬜⬛🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨⬛🟨🟨🟨🟨🟨🟨⬛⬜
⬜⬜⬜⬜⬛🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨⬛🟨🟨🟨🟨🟨🟨🟨⬛⬜
⬜⬜⬜⬜⬛🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨⬛🟨🟨🟨🟨🟨🟨🟨🟨⬛⬜
⬜⬜⬜⬜⬛🟨🟨🟨🟨🟨🟨🟨🟨🟨⬛⬛⬛🟨🟨🟨🟨🟨🟨🟨🟨⬛⬜⬜
⬜⬜⬜⬜⬜⬛🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨⬛⬛⬜⬜⬜
⬜⬜⬜⬜⬜⬜⬛🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨⬛⬜⬜⬜⬜⬜
⬜⬜⬜⬜⬜⬜⬜⬛🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨⬛⬜⬜⬜⬜⬜⬜
⬜⬜⬜⬜⬜⬜⬜⬜⬛⬛⬛⬛⬛⬛⬛⬛⬛⬛⬛⬛⬛⬜⬜⬜⬜⬜⬜⬜
*/
namespace CustomAccessors {
  public class DemoClass{
    private int _privateField;
    public string PublicField = "None";
    public int LimitedProperty {get; private set;}
    public DemoClass(int privateField) => _privateField = privateField;
    }
}

//****************Sample Test*****************
namespace CustomAccessors {
  using NUnit.Framework;
  using System.Reflection;
  using System;
  
  [TestFixture]
  public class AllTests
  {
    [Test]
    public void CheckConstructorExists()
    {
      //sut --> subject under test
      var sut = new DemoClass(15);
      Assert.Pass("Single int argument constructor exists");
    }
    
    [Test]
    public void CheckConstructorAssignsToPrivateField()
    {
      for (int i = 0; i < 30; i+=5)
      {
          var sut = new DemoClass(i);
          FieldInfo fi = typeof(DemoClass).GetField("_privateField", BindingFlags.NonPublic | BindingFlags.Instance);
          
          Assert.NotNull(fi, "_privateField doesn't exist");
          Assert.AreEqual(i, fi.GetValue(sut));
      }      
    }
        
    [Test]
    public void CheckThatPublicFieldExists()
    {
      for (int i = 0; i < 30; i+=5)
      {
          var sut = new DemoClass(0);
          FieldInfo fi = typeof(DemoClass).GetField("PublicField", BindingFlags.Public | BindingFlags.Instance);
          
          Assert.NotNull(fi, "PublicField doesn't exist");
          Assert.AreEqual("None", fi.GetValue(sut));
          Assert.AreEqual("None", sut.PublicField);
          Assert.True(ReferenceEquals(fi.GetValue(sut), sut.PublicField));          
      }
    }
      
    [Test]
    public void CheckThatLimitedPropertyExists()
    {
        Type type = typeof(DemoClass);
        ConstructorInfo ci = type.GetConstructor(new []{typeof(int)});
        object classObject = ci.Invoke(new object[] { 24 });
        PropertyInfo pi = type.GetProperty("LimitedProperty", BindingFlags.Instance | BindingFlags.Public);
        
        Assert.NotNull(pi, "LimitedProperty doesn't exist");
        if(pi.GetGetMethod(nonPublic:false) == null)
           { Assert.Fail("Public getter not found"); }
        if (pi.GetSetMethod(nonPublic:true) == null)
           { Assert.Fail("Private setter not found"); }
           
        //now check that it is assignable
        MethodInfo mi = pi.GetSetMethod(true);
        for (int i = 0; i < 30; i+= 5)
        {
            mi.Invoke(classObject, new object[] { i });
            Assert.AreEqual(i, ((DemoClass)classObject).LimitedProperty, "Your LimitedProperty is either not setting or getting correctly");
        }
    }
  }
}
