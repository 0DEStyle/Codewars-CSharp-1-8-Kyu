/*Challenge link:https://www.codewars.com/kata/57814d79a56c88e3e0000786/train/csharp
Question:
Implement a pseudo-encryption algorithm which given a string S and an integer N concatenates all the odd-indexed characters of S with all the even-indexed characters of S, this process should be repeated N times.

Examples:

encrypt("012345", 1)  =>  "135024"
encrypt("012345", 2)  =>  "135024"  ->  "304152"
encrypt("012345", 3)  =>  "135024"  ->  "304152"  ->  "012345"

encrypt("01234", 1)  =>  "13024"
encrypt("01234", 2)  =>  "13024"  ->  "32104"
encrypt("01234", 3)  =>  "13024"  ->  "32104"  ->  "20314"
Together with the encryption function, you should also implement a decryption function which reverses the process.

If the string S is an empty value or the integer N is not positive, return the first argument without changes.

This kata is part of the Simple Encryption Series:

Simple Encryption #1 - Alternating Split
Simple Encryption #2 - Index-Difference
Simple Encryption #3 - Turn The Bits Around
Simple Encryption #4 - Qwerty
Have fun coding it and please don't forget to vote and rank this kata! :-)



*/

//***************Solution********************
using System;

public class Kata
{
  public static string Encrypt(string text, int n){
    //check conditions before process
    if (string.IsNullOrEmpty(text) || n <= 0) { return text; }
    
    string encryptedText = "";
    
    for(int j = 0; j < n; j ++){
    encryptedText = ""; //Reset text at the start of each loop
    
    //shift the numbers in odd index, and concatenate into encryptedText
    for (int i = 0; i < text.Length; i++){
        if (i % 2 == 1)
            encryptedText += text[i];
    }
    //shift the numbers in even index, and concatenate into encryptedText
    for (int i = 0; i < text.Length; i++){
        if (i % 2 == 0)
            encryptedText += text[i];
    }
      
    //store the result in text, and repeat until n = 0
    text = encryptedText;
    }
    //return the result text
    return text;
  }
  
  
  public static string Decrypt(string encryptedText, int n){
    //check conditions before process
    if (string.IsNullOrEmpty(encryptedText) || n <= 0) { return encryptedText; }
    
    //make an array decryptedText with the identical length
    string[] decryptedText = new string[encryptedText.Length];
    int j = 0, k = 0;
    
    for(int l = 0; l < n; l ++){
      //Reset text at the start of each loop
      Array.Clear(decryptedText,0,decryptedText.Length); 
      j = 0;k = 0;
    
      //get the first half of the decryption
    for (int i = 0; i < encryptedText.Length - 1; i += 2){
        decryptedText[j + 1] += encryptedText[j];
        j++;
    }
      //get the second half of the decryption
    for (int i = 0; i < encryptedText.Length; i += 2){
        decryptedText[k] += encryptedText[j];
        k++;j++;
    }
      encryptedText = string.Join("",decryptedText);
    }
    //return the result
    return encryptedText;
  }
    
  
}

//****************Sample Test*****************
using NUnit.Framework;
using System;
//using System.Collections.Generic;
using System.Linq;

public class SolutionTest
{
  private Random rand = new Random(DateTime.Now.Second);
  
  [Test]
  public void EncryptExampleTests()
  {
    Assert.AreEqual("This is a test!", Kata.Encrypt("This is a test!", 0));
    Assert.AreEqual("hsi  etTi sats!", Kata.Encrypt("This is a test!", 1));
    Assert.AreEqual("s eT ashi tist!", Kata.Encrypt("This is a test!", 2));
    Assert.AreEqual(" Tah itse sits!", Kata.Encrypt("This is a test!", 3));
    Assert.AreEqual("This is a test!", Kata.Encrypt("This is a test!", 4));
    Assert.AreEqual("This is a test!", Kata.Encrypt("This is a test!", -1));
    Assert.AreEqual("hskt svr neetn!Ti aai eyitrsig", Kata.Encrypt("This kata is very interesting!", 1));
  }
  
  [Test]
  public void DecryptExampleTests()
  {
    Assert.AreEqual("This is a test!", Kata.Decrypt("This is a test!", 0));
    Assert.AreEqual("This is a test!", Kata.Decrypt("hsi  etTi sats!", 1));
    Assert.AreEqual("This is a test!", Kata.Decrypt("s eT ashi tist!", 2));
    Assert.AreEqual("This is a test!", Kata.Decrypt(" Tah itse sits!", 3));
    Assert.AreEqual("This is a test!", Kata.Decrypt("This is a test!", 4));
    Assert.AreEqual("This is a test!", Kata.Decrypt("This is a test!", -1));
    Assert.AreEqual("This kata is very interesting!", Kata.Decrypt("hskt svr neetn!Ti aai eyitrsig", 1));
  }
  
  [Test]
  public void EncryptDecryptTests()
  {
    Assert.AreEqual("Kobayashi-Maru-Test", Kata.Decrypt(Kata.Encrypt("Kobayashi-Maru-Test", 10), 10));
  }
  
  [Test]
  public void EmptyTests()
  {
    Assert.AreEqual("", Kata.Encrypt("", 0));
    Assert.AreEqual("", Kata.Decrypt("", 1));
  }
  
  [Test]
  public void NullTests()
  {
    Assert.AreEqual(null, Kata.Encrypt(null, 1));
    Assert.AreEqual(null, Kata.Decrypt(null, 0));
  }
  
  [Test]
  public void RandomTests()
  {
    for(int i = 0; i < 20; i++)
    {
      int n = rand.Next(0,10);
      int length = rand.Next(1,70);
      var text = string.Concat(Enumerable.Range(1, length).Select(c => (char)rand.Next(65,91)));
      Assert.AreEqual(myEncrypt(text, n), Kata.Encrypt(text, n));
      Assert.AreEqual(myDecrypt(text, n), Kata.Decrypt(text, n));
    }
  }
  
  private string myEncrypt(string text, int n)
  {
    if(string.IsNullOrEmpty(text) || (n <= 0))
    {
      return text;
    }
    
    string encryptedText = text;
    
    for(int x=0; x<n; x++)
    {
      encryptedText = string.Concat(encryptedText.Where((o, i) => i % 2 != 0).Concat(encryptedText.Where((o, i) => i % 2 == 0)));
    }
    
    return encryptedText;
  }
  
  public string myDecrypt(string encryptedText, int n)
  {
    if(string.IsNullOrEmpty(encryptedText) || (n <= 0))
    {
      return encryptedText;
    }
    
    string decryptedText = encryptedText;
    
    for(int x=0; x<n; x++)
    {
      decryptedText = string.Concat(Enumerable.Zip(decryptedText.Take(decryptedText.Length / 2), decryptedText.Skip(decryptedText.Length / 2), (a, b) => b + "" + a)) + (decryptedText.Length % 2 == 1  ? decryptedText.Substring(decryptedText.Length-1) : "");
    }
    
    return decryptedText;
  }
}
