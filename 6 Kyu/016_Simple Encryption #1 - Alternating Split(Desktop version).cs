using System;

int n = 2;// n is the number of time to repeat
string text = "012345", encryptedText = "", decryptedText = "";
//012345 This is a test!

//select all odd concatenate to even
while (n != 0)
{
    encryptedText = ""; //Reset text after repetition
    for (int i = 0; i < text.Length; i++)
    {
        if (i % 2 == 1)
            encryptedText += text[i];
    }
    for (int i = 0; i < text.Length; i++)
    {
        if (i % 2 == 0)
            encryptedText += text[i];
    }
    text = encryptedText;
    n--;
}
Console.WriteLine("Text: "+ text + "\nText length: " + text.Length + "\nEncrypted text: " + encryptedText);


//string newtext = "135024"; // temp > 012345
string newtext = " Tah itse sits!"; // temp > This is a test!
string[] temp = new string[newtext.Length];

Console.WriteLine("newtext: " + newtext + "\nnewtext length:" + newtext.Length);

n = 3;
Console.WriteLine("Encrypted Text: " + newtext);
while (n != 0)
{

    Array.Clear(temp,0,temp.Length); //empty the array
    int j = 0;
    Console.WriteLine("Decrypting String...");
    for (int i = 0; i < newtext.Length - 1; i += 2)
    {
        // start with odd number, shift first odd number back by one and so on into empty array
        temp[j + 1] += newtext[j];
        j++;
        Console.WriteLine("Index: " + j +" -> " + string.Join("", temp));
    }
    Console.WriteLine("First half of decryption: " + string.Join("", temp) + "\n");

    // now add even number.
    int k = 0;
    for (int i = 0; i < newtext.Length; i += 2)
    {
        temp[k] += newtext[j];
        k++;
        j++;
        Console.WriteLine("Index: " + j + " -> " + string.Join("", temp));
    }
    Console.WriteLine("Second half of decryption: " + string.Join("", temp) + "\n");
    newtext = string.Join("",temp);
    Console.WriteLine("new text is " + newtext);
    n--;
    Console.WriteLine("Repetition time left: " + n);
}
Console.WriteLine("Decrypted text: " + string.Join("", temp));
