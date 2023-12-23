/*Challenge link:https://www.codewars.com/kata/562d8d4c434582007300004e/train/csharp
Question:
Many people choose to obfuscate their email address when displaying it on the Web. One common way of doing this is by substituting the @ and . characters for their literal equivalents in brackets.

Example 1:

user_name@example.com
=> user_name [at] example [dot] com
Example 2:

af5134@borchmore.edu
=> af5134 [at] borchmore [dot] edu
Example 3:

jim.kuback@ennerman-hatano.com
=> jim [dot] kuback [at] ennerman-hatano [dot] com
Using the examples above as a guide, write a function that takes an email address string and returns the obfuscated version as a string that replaces the characters @ and . with [at] and [dot], respectively.

Notes

Input (email) will always be a string object. Your function should return a string.
Change only the @ and . characters.
Email addresses may contain more than one . character.
Note the additional whitespace around the bracketed literals in the examples!
*/

//***************Solution********************

//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
//from the string email, replace @ to " [at] " and replace . to " [dot] ", then return the result.
public class EmailObfuscator {
    public static string Obfuscate(string email)  => email.Replace("@"," [at] ").Replace(".", " [dot] ");
}

//****************Sample Test*****************
using System;
using NUnit.Framework;

[TestFixture]
public class EmailObfuscatorTest {
	
	[Test]
	public void test1() {
		Assert.AreEqual("user_name [at] example [dot] com",
        EmailObfuscator.Obfuscate("user_name@example.com"));
	}
	[Test]
	public void test2() {
		Assert.AreEqual("af5134 [at] borchmore [dot] edu",
        EmailObfuscator.Obfuscate("af5134@borchmore.edu"));
	}
	[Test]
	public void test3() {
		Assert.AreEqual("jim [dot] kuback [at] ennerman-hatano [dot] com",
        EmailObfuscator.Obfuscate("jim.kuback@ennerman-hatano.com"));
	}
	[Test]
	public void test4() {
		Assert.AreEqual("sir_k3v1n_wulf [at] blingblong [dot] net",
        EmailObfuscator.Obfuscate("sir_k3v1n_wulf@blingblong.net"));
	}
	[Test]
	public void test5() {
		Assert.AreEqual("Hmm, this would be better with input validation [dot]  [dot]  [dot] !",
        EmailObfuscator.Obfuscate("Hmm, this would be better with input validation...!"));
	}
}
