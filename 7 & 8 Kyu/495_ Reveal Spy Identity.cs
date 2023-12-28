/*Challenge link:https://www.codewars.com/kata/563a362e21001b1d16000049/train/csharp
Question:
You have to detect if the person is a Police or a Spy :D There is an abstract class named "Human" with just one property which is "Name". "Name" is an string. There are two other classes named "Police" and "Spy" that inherit from Human class.

Complete the FindHisIdentity method, so it returns a string that tell the identity of the person: the output string should be like this: "'Name of the person' is a 'real identity of the person'"


*/

//***************Solution********************

//Then simiplfied into one line by using an Lambda expression with Enumerable methods.

//get the Type class of current instance using Person Name
//using string interpolation to format string.
namespace Identity{  
  public class Kata{
        public static string FindHisIdentity(Human person) => $"{person.Name} is a {person.GetType().Name}";
    }
}

//solution 2
namespace Identity {
  using System;
  
  public class Kata
    {
        public static string FindHisIdentity(Human person)
        {
            if (person is Police)
              return $"{person.Name} is a Police";
          
            return $"{person.Name} is a Spy";          
        }
    }
}
//****************Sample Test*****************
namespace Identity {
  using NUnit.Framework;
  using System;
  
  [TestFixture]
    public class TestClass
    {
        [Test]
        public void test1()
        {
            Human person = new Police();
            person.Name = "John";
            Assert.AreEqual("John is a Police",Kata.FindHisIdentity(person));
        }
        
        [Test]
        public void test2()
        {
            Human person = new Spy();
            person.Name = "Sara";
            Assert.AreEqual("Sara is a Spy",Kata.FindHisIdentity(person));
        }
        
        [Test]
        public void test3()
        {
            Human person = new Spy();
            person.Name = "Nadia";
            Assert.AreEqual("Nadia is a Spy",Kata.FindHisIdentity(person));
        }
        
        [Test]
        public void test4()
        {
            Human person = new Police();
            person.Name = "Varon";
            Assert.AreEqual("Varon is a Police",Kata.FindHisIdentity(person));
        }
        
        [Test]
          public static void RandomTest([Random(0,1,100)]int x)
          {
            Human h;
            if(x == 0)
              h = new Spy();
            else
              h = new Police();
            h.Name = "suspicious person";
            Assert.AreEqual(Solution(h), Kata.FindHisIdentity(h));
          }
          
          private static string Solution(Human person)
          {
            return  person.Name + " is a " + person.GetType().Name;
          }
    }
}
