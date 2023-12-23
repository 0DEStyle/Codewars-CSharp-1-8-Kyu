/*Challenge link:https://www.codewars.com/kata/545cff101288c1d2da0006fb/train/csharp
Question:
A category page displays a set number of products per page, with pagination at the bottom allowing the user to move from page to page.

Given that you know the page you are on, how many products are in the category in total, and how many products are on any given page, how would you output a simple string showing which products you are viewing..

Examples
In a category of 30 products with 10 products per page, on page 1 you would see

'Showing 1 to 10 of 30 Products.'

In a category of 26 products with 10 products per page, on page 3 you would see

'Showing 21 to 26 of 26 Products.'

In a category of 8 products with 10 products per page, on page 1 you would see

'Showing 1 to 8 of 8 Products.'
*/

//***************Solution********************

//Then simiplfied into one line by using an Lambda expression with Enumerable methods.

/*
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢠⣤⣴⣶⣿⣾⣿⣷⣶⣶⣴⣦⣤⣀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⢀⣴⣶⣿⣿⣿⣿⣞⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣦⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⣰⣿⣿⣿⣿⣿⣿⣾⠿⠛⠉⠛⠛⡻⠿⢿⡿⡿⡿⠿⣿⡆⠀⠀⢰⣶⣶⣄⣠⣿⣛⡇
⠀⠀⠀⠀⠀⠀⢀⣿⣿⣿⣿⣿⣿⣿⠇⠀⠀⠀⠀⠠⢠⠛⣧⢸⢣⡄⠀⠘⢿⡇⠀⠀⠙⢿⣿⣟⣛⣿⡏
⠀⠀⠀⠀⠀⠀⣺⣿⣿⣿⣿⣿⣿⡿⣯⡂⠀⠀⠀⠀⢶⢭⣓⡿⣷⠾⡤⢠⠀⢻⠀⠀⠀⠈⢿⣿⡿⠋⠀
⠀⠀⠀⠀⠀⠀⣿⣿⣿⣿⣿⣿⣟⠛⠈⠀⠀⢀⣴⣷⣿⣶⣧⣿⣷⢂⢯⡗⡔⠜⡇⠀⠀⠀⠈⠋⠀⠀⠀
⠀⠀⠀⠀⠀⠀⣿⣿⣿⣿⣿⣿⠁⠀⠀⠀⠴⣛⣯⣿⣿⣿⣿⣿⣿⣿⡿⣷⣧⣄⣃⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⢀⡿⠋⠛⢻⣿⠇⠀⠀⠀⠀⡹⣿⣿⣿⠿⠿⣿⣿⡏⠉⠇⣿⠿⠿⢿⣷⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⢸⣐⣥⣴⢸⣧⣃⠀⠀⠀⠀⠄⠈⠝⣿⣶⣶⣿⡟⠁⠀⢳⢽⣤⣶⣦⠌⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⡸⣿⠇⡀⢀⣿⣿⡆⠀⠀⠀⠀⣀⣸⣷⣿⣿⣿⣆⣀⠀⠀⣇⢿⣆⢇⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠘⠛⠑⠆⢸⣿⣿⣿⣶⣦⣥⣿⠟⢝⣯⣿⣿⣿⣄⣬⡍⡀⡼⢳⡛⠊⡆⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠈⡞⠰⣿⣿⣵⣿⣿⣿⣿⣿⣰⣿⣿⣿⢿⣿⣿⣿⣿⣯⣏⣿⡿⣠⠁⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⢀⢯⡇⢸⣟⡿⣾⣾⣿⣿⣿⣿⣿⣿⣿⣿⣻⣐⠉⠻⠿⠯⠙⣿⢧⡃⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠘⠛⠀⢸⣿⣽⣿⣻⣿⣿⣿⣿⣿⣿⣿⣿⣏⣿⣲⣶⡤⠄⢠⣶⣟⠃⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⢠⠞⢿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡟⣶⣿⡇⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⡏⣿⣌⠙⢻⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣾⣿⡏⡄⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⢀⣼⠂⠻⣿⡧⣙⢪⠙⢿⣿⣿⣿⣿⡿⣿⣿⣿⣿⣿⣿⣿⣿⢖⡅⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⢀⣼⣧⣿⡆⣀⠑⢿⣬⡓⡆⠈⠻⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡿⢂⠃⠀⠀⠀⠀⠀⠀⠀⠀⠀
⣀⢀⠠⢐⢿⠿⠡⢯⣛⣾⣷⣈⠙⢗⡆⡆⠀⡉⣿⣿⣿⣿⣿⣿⣿⣿⣿⠛⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
*/
//cursed oneline with string interpolation and tenary lol
public class Kata{
  public static string PaginationText(int pageNumber, int pageSize, int totalProducts) =>
    $"Showing {(pageNumber < 2 ? pageNumber : (pageNumber - 1) * pageSize + 1)} to {(totalProducts < pageSize ? totalProducts : pageSize * pageNumber < totalProducts ? pageSize * pageNumber  : totalProducts)} of {totalProducts} Products.";
}

//solution 2
public class Kata {
  public static string PaginationText(int p, int w, int t)
    => $"Showing {w * (p - 1) + 1} to {System.Math.Min(w * p, t)} of {t} Products.";
}
//****************Sample Test*****************
using System;
using NUnit.Framework;

[TestFixture]
public class Tests
{
  [Test]
  [TestCase(1,10,30,ExpectedResult="Showing 1 to 10 of 30 Products.")]
  [TestCase(3,10,26,ExpectedResult="Showing 21 to 26 of 26 Products.")]
  [TestCase(1,10,8,ExpectedResult="Showing 1 to 8 of 8 Products.")]
  [TestCase(2,30,350,ExpectedResult="Showing 31 to 60 of 350 Products.")]
  [TestCase(1,23,30,ExpectedResult="Showing 1 to 23 of 30 Products.")]
  [TestCase(2,23,30,ExpectedResult="Showing 24 to 30 of 30 Products.")]
  [TestCase(43,15,3456,ExpectedResult="Showing 631 to 645 of 3456 Products.")]
  public static string FixedTest(int pageNumber, int pageSize, int totalProducts)
  {
    return Kata.PaginationText(pageNumber, pageSize, totalProducts);
  }
}
