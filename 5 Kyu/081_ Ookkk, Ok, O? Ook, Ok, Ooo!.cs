/*Challenge link:https://www.codewars.com/kata/55035eb47451fb61c0000288/train/csharp
Question:
We've got a message from the Librarian. As usual there're many o and k in it and, as all codewarriors don't know "Ook" language we need that you translate this message.

tip : it seems traditional "Hello World!" would look like : Ok, Ook, Ooo?  Okk, Ook, Ok?  Okk, Okk, Oo?  Okk, Okk, Oo?  Okk, Okkkk?  Ok, Ooooo?  Ok, Ok, Okkk?  Okk, Okkkk?  Okkk, Ook, O?  Okk, Okk, Oo?  Okk, Ook, Oo?  Ook, Ooook!

Your task is to implement a function okkOokOo(okkOookk), that would take the okkOookk message as input and return a decoded human-readable string.

eg:

Kata.OkkOokOo("Ok, Ook, Ooo!"); // -> "H"
Kata.OkkOokOo("Ok, Ook, Ooo?  Okk, Ook, Ok?  Okk, Okk, Oo?  Okk, Okk, Oo?  Okk, Okkkk!"); // -> "Hello"
Kata.OkkOokOo("Ok, Ok, Okkk?  Okk, Okkkk?  Okkk, Ook, O?  Okk, Okk, Oo?  Okk, Ook, Oo?  Ook, Ooook!"); // -> "World!"
*/

//***************Solution********************

//OKKKKKKKK!?
//replace string with pattern @"[\s!,]" to nothing
//convert to lowercase, replace "o" with "0" and "k" with "1"
//split sentence by "?", then convert sentence to int and use it to convert to ascii.
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.

using System;
using System.Linq;
using System.Text.RegularExpressions;

public class Kata {
    public static string OkkOokOo(string okkOookk) =>
      string.Concat(Regex.Replace(okkOookk, @"[\s!,]", "")
            .ToLower().Replace("o", "0").Replace("k", "1")
            .Split('?').Select(x => (char)Convert.ToInt32(x, 2)));
}


//funny code
using OkOkOokkOkkkkOokOkkkOokkOkkkOkOoOkkOokOkOkkOkkOk = System;
using OkOkOokkOkkkkOokOkkkOokkOkkkOkOoOkkOokOkOkkOkkOkOokOkkkOokOoookOokkkkOokOkkkOkOoOkkOokOk = System.Byte;
using OkOkOokkOkkkkOokOkkkOokkOkkkOkOoOkkOokOkOkkOkkOkOokOkkkOokOkOokkOkkkOkOoOkkkOokOokkOkOokOkkOkkkOokkOokkk = System.String;
using OkOkOokkOkkkkOokOkkkOokkOkkkOkOoOkkOokOkOkkOkkOkOokOkkkOokOkOkOoOkkOokOkOkkkkOooOkkkOkOoOokOkkkOokOkOokkOkkkOkOoOkkkOokOokkOkOokOkkOkkkOokkOokkkOkOoookOokkkOkOkOkkOkOokOkkOkkOoOkkOokOoOkkOokOkOkkkOokO = System.Text.StringBuilder;
using OkOkOokkOkkkkOokOkkkOokkOkkkOkOoOkkOokOkOkkOkkOkOokOkkkOokOokOokOkkOkkkOokkkOkOoOokkOokkOokkOokO = System.Int32;
using OkOkOokkOkkkkOokOkkkOokkOkkkOkOoOkkOokOkOkkOkkOkOokOkkkOokOoookkOkkOkOooOkkOoookOkkkOokO = System.Char;
using OkOkOokkOkkkkOokOkkkOokkOkkkOkOoOkkOokOkOkkOkkOkOokOkkkOokOkOkOoOkkOokOkOkkkkOooOkkkOkOoOokOkkkOokOookOkOkkOkkkOokkOookkOkkOkkkkOkkOokOoOkkOkOokOkkOkkkOokkOokkk = System.Text.Encoding;
using OkOkOokkOkkkkOokOkkkOokkOkkkOkOoOkkOokOkOkkOkkOkOokOkkkOokOoookkOkkOkkkkOkkOkkOoOkkOkkOoOkkOokOkOkkOookkOkkkOkOoOkkOkOokOkkOkkkkOkkOkkkOokkkOokkOokOkkkOokOookkkOkkOokOkOkkOkkkOokkOokOkOkkkOokOokkOkOokOkkOookkOokOkkkOokOookOoOkkOkOokOkkOookkOkkkOkOoOkkOkOokOkkOkkkkOkkOkkkOokkOoookOkkkOokOokkkkOokOokkkkOoOkkkOokkOkkkOkOoOkkkOokOokkOkOokOkkOkkkOokkOokkkOokOkkOoOkkkOokkOkkkOkOoOkkkOokOokkOkOokOkkOkkkOokkOokkkOokkkkkO = System.Collections.Generic.Dictionary<string,string>;
using OkOkOokkOkkkkOokOkkkOokkOkkkOkOoOkkOokOkOkkOkkOkOokOkkkOokOoookOokkOkkkkOkkOkkkkOkkOkkOoOkkOokOkOkkOoookOkkOkkkO = System.Boolean;

public static class Kata
{
    public static OkOkOokkOkkkkOokOkkkOokkOkkkOkOoOkkOokOkOkkOkkOkOokOkkkOokOkOokkOkkkOkOoOkkkOokOokkOkOokOkkOkkkOokkOokkk OkkOokOo(OkOkOokkOkkkkOokOkkkOokkOkkkOkOoOkkOokOkOkkOkkOkOokOkkkOokOkOokkOkkkOkOoOkkkOokOokkOkOokOkkOkkkOokkOokkk okkOookk)
    {
        OkOkOokkOkkkkOokOkkkOokkOkkkOkOoOkkOokOkOkkOkkOkOokOkkkOokOkOkOoOkkOokOkOkkkkOooOkkkOkOoOokOkkkOokOkOokkOkkkOkOoOkkkOokOokkOkOokOkkOkkkOokkOokkkOkOoookOokkkOkOkOkkOkOokOkkOkkOoOkkOokOoOkkOokOkOkkkOokO OkkkOokkOkkOookO = new OkOkOokkOkkkkOokOkkkOokkOkkkOkOoOkkOokOkOkkOkkOkOokOkkkOokOkOkOoOkkOokOkOkkkkOooOkkkOkOoOokOkkkOokOkOokkOkkkOkOoOkkkOokOokkOkOokOkkOkkkOokkOokkkOkOoookOokkkOkOkOkkOkOokOkkOkkOoOkkOokOoOkkOokOkOkkkOokO();
        OkOkOokkOkkkkOokOkkkOokkOkkkOkOoOkkOokOkOkkOkkOkOokOkkkOokOoookkOkkOkkkkOkkOkkOoOkkOkkOoOkkOokOkOkkOookkOkkkOkOoOkkOkOokOkkOkkkkOkkOkkkOokkkOokkOokOkkkOokOookkkOkkOokOkOkkOkkkOokkOokOkOkkkOokOokkOkOokOkkOookkOokOkkkOokOookOoOkkOkOokOkkOookkOkkkOkOoOkkOkOokOkkOkkkkOkkOkkkOokkOoookOkkkOokOokkkkOokOokkkkOoOkkkOokkOkkkOkOoOkkkOokOokkOkOokOkkOkkkOokkOokkkOokOkkOoOkkkOokkOkkkOkOoOkkkOokOokkOkOokOkkOkkkOokkOokkkOokkkkkO();
        okkOookk = okkOookk.OkOkOkOoOkkOkkkkOkOokkOoOkkOkkkkOkkkOkkkOkkOokOkOkkkOokO();
        okkOookk = okkOookk.OkOkOokOokkOokOkOkkkOoooOkkOkkOoOkkOoookOkkOookkOkkOokOk("Okk, Ok, Okk!", "Ookk, Oook!");
        okkOookk = okkOookk.OkOkOokOokkOokOkOkkkOoooOkkOkkOoOkkOoookOkkOookkOkkOokOk("Okk, Okkkk!", "Ookk, Oooo!");
        okkOookk = okkOookk.OkOkOokOokkOokOkOkkkOoooOkkOkkOoOkkOoookOkkOookkOkkOokOk("Ook, Okk, Oo!", "");
        okkOookk = okkOookk.OkOkOokOokkOokOkOkkkOoooOkkOkkOoOkkOoookOkkOookkOkkOokOk("Ook, Ooooo!", "");
        okkOookk = okkOookk.OkOkOokOokkOokOkOkkkOoooOkkOkkOoOkkOoookOkkOookkOkkOokOk("Ook, Ooook!", "");

        OkOkOokkOkkkkOokOkkkOokkOkkkOkOoOkkOokOkOkkOkkOkOokOkkkOokOkOokkOkkkOkOoOkkkOokOokkOkOokOkkOkkkOokkOokkk[] OkkOookOokOooook
          = okkOookk.OkOkOokkOkkkOoooOkkOkkOoOkkOkOokOkkkOkOo(OkkOokOoOkkOkOokOkkOookkOkkkOkOo["Ookkkkkk!"][0]);
          
        foreach (OkOkOokkOkkkkOokOkkkOokkOkkkOkOoOkkOokOkOkkOkkOkOokOkkkOokOkOokkOkkkOkOoOkkkOokOokkOkOokOkkOkkkOokkOokkk OkkOookO
            in OkkOookOokOooook)
        {
            OkkkOokkOkkOookO.OkOkOokkOkkkOoooOkkOkkOoOkkOkOokOkkkOkOo(
                OkOookOkOkkOkkkOokkOookkOkkOkkkkOkkOokOoOkkOkOokOkkOkkkOokkOokkkOokOkkkOokOooookOkOkOokkOkOoookkOkOokOokOkOokOokOokOkkkOokOookkkOkkOokOkOkkkOkOoOkOkOokkOkkkOkOoOkkkOokOokkOkOokOkkOkkkOokkOokkk(
                    new OkOkOokkOkkkkOokOkkkOokkOkkkOkOoOkkOokOkOkkOkkOkOokOkkkOokOoookOokkkkOokOkkkOkOoOkkOokOk[] {
                            OkOkOokkOkkkkOokOkkkOokkOkkkOkOoOkkOokOkOkkOkkOkOokOkkkOokOoookkOkkOkkkkOkkOkkkOokkkOkkOokkOokOkOkkkOokOokkkOkOoOokOkkkOokOkOkOoOkkOkkkkOkOoookOokkkkOokOkkkOkOoOkkOokOk(OkkOookO, 2)
                    }
                ));
        }

        return OkkkOokkOkkOookO.OkOkOkOoOkkOkkkkOkOkOokkOkkkOkOoOkkkOokOokkOkOokOkkOkkkOokkOokkk();
    }

    static OkOkOokkOkkkkOokOkkkOokkOkkkOkOoOkkOokOkOkkOkkOkOokOkkkOokOoookkOkkOkkkkOkkOkkOoOkkOkkOoOkkOokOkOkkOookkOkkkOkOoOkkOkOokOkkOkkkkOkkOkkkOokkkOokkOokOkkkOokOookkkOkkOokOkOkkOkkkOokkOokOkOkkkOokOokkOkOokOkkOookkOokOkkkOokOookOoOkkOkOokOkkOookkOkkkOkOoOkkOkOokOkkOkkkkOkkOkkkOokkOoookOkkkOokOokkkkOokOokkkkOoOkkkOokkOkkkOkOoOkkkOokOokkOkOokOkkOkkkOokkOokkkOokOkkOoOkkkOokkOkkkOkOoOkkkOokOokkOkOokOkkOkkkOokkOokkkOokkkkkO
  OkkOokOoOkkOkOokOkkOookkOkkkOkOo = new OkOkOokkOkkkkOokOkkkOokkOkkkOkOoOkkOokOkOkkOkkOkOokOkkkOokOoookkOkkOkkkkOkkOkkOoOkkOkkOoOkkOokOkOkkOookkOkkkOkOoOkkOkOokOkkOkkkkOkkOkkkOokkkOokkOokOkkkOokOookkkOkkOokOkOkkOkkkOokkOokOkOkkkOokOokkOkOokOkkOookkOokOkkkOokOookOoOkkOkOokOkkOookkOkkkOkOoOkkOkOokOkkOkkkkOkkOkkkOokkOoookOkkkOokOokkkkOokOokkkkOoOkkkOokkOkkkOkOoOkkkOokOokkOkOokOkkOkkkOokkOokkkOokOkkOoOkkkOokkOkkkOkOoOkkkOokOokkOkOokOkkOkkkOokkOokkkOokkkkkO();

    static OkOkOokkOkkkkOokOkkkOokkOkkkOkOoOkkOokOkOkkOkkOkOokOkkkOokOkOokkOkkkOkOoOkkkOokOokkOkOokOkkOkkkOokkOokkk OkOkOkOoOkkOkkkkOkOokkOoOkkOkkkkOkkkOkkkOkkOokOkOkkkOokO(this OkOkOokkOkkkkOokOkkkOokkOkkkOkOoOkkOokOkOkkOkkOkOokOkkkOokOkOokkOkkkOkOoOkkkOokOokkOkOokOkkOkkkOokkOokkk OkkkOokk) { return OkkkOokk.ToLower(); }
    static OkOkOokkOkkkkOokOkkkOokkOkkkOkOoOkkOokOkOkkOkkOkOokOkkkOokOkOokkOkkkOkOoOkkkOokOokkOkOokOkkOkkkOokkOokkk OkOkOokOokkOokOkOkkkOoooOkkOkkOoOkkOoookOkkOookkOkkOokOk(this OkOkOokkOkkkkOokOkkkOokkOkkkOkOoOkkOokOkOkkOkkOkOokOkkkOokOkOokkOkkkOkOoOkkkOokOokkOkOokOkkOkkkOokkOokkk OkkkOokk, OkOkOokkOkkkkOokOkkkOokkOkkkOkOoOkkOokOkOkkOkkOkOokOkkkOokOkOokkOkkkOkOoOkkkOokOokkOkOokOkkOkkkOokkOokkk OkkOoook, OkOkOokkOkkkkOokOkkkOokkOkkkOkOoOkkOokOkOkkOkkOkOokOkkkOokOkOokkOkkkOkOoOkkkOokOokkOkOokOkkOkkkOokkOokkk OkkOookO) { return OkkkOokk.Replace(OkkOokOoOkkOkOokOkkOookkOkkkOkOo[OkkOoook], OkkOokOoOkkOkOokOkkOookkOkkkOkOo[OkkOookO]); }
    static OkOkOokkOkkkkOokOkkkOokkOkkkOkOoOkkOokOkOkkOkkOkOokOkkkOokOkOokkOkkkOkOoOkkkOokOokkOkOokOkkOkkkOokkOokkk[] OkOkOokkOkkkOoooOkkOkkOoOkkOkOokOkkkOkOo(this OkOkOokkOkkkkOokOkkkOokkOkkkOkOoOkkOokOkOkkOkkOkOokOkkkOokOkOokkOkkkOkOoOkkkOokOokkOkOokOkkOkkkOokkOokkk OkkkOokk, OkOkOokkOkkkkOokOkkkOokkOkkkOkOoOkkOokOkOkkOkkOkOokOkkkOokOoookkOkkOkOooOkkOoookOkkkOokO OkkOookk) { return OkkkOokk.Split(OkkOookk); }
    static void OkOkOokkOkkkOoooOkkOkkOoOkkOkOokOkkkOkOo(this OkOkOokkOkkkkOokOkkkOokkOkkkOkOoOkkOokOkOkkOkkOkOokOkkkOokOkOkOoOkkOokOkOkkkkOooOkkkOkOoOokOkkkOokOkOokkOkkkOkOoOkkkOokOokkOkOokOkkOkkkOokkOokkkOkOoookOokkkOkOkOkkOkOokOkkOkkOoOkkOokOoOkkOokOkOkkkOokO OkkkOokkOkkOookO, OkOkOokkOkkkkOokOkkkOokkOkkkOkOoOkkOokOkOkkOkkOkOokOkkkOokOkOokkOkkkOkOoOkkkOokOokkOkOokOkkOkkkOokkOokkk OkkkOokk) { OkkkOokkOkkOookO.Append(OkkkOokk); }
    static OkOkOokkOkkkkOokOkkkOokkOkkkOkOoOkkOokOkOkkOkkOkOokOkkkOokOkOokkOkkkOkOoOkkkOokOokkOkOokOkkOkkkOokkOokkk OkOkOkOoOkkOkkkkOkOkOokkOkkkOkOoOkkkOokOokkOkOokOkkOkkkOokkOokkk(this OkOkOokkOkkkkOokOkkkOokkOkkkOkOoOkkOokOkOkkOkkOkOokOkkkOokOkOkOoOkkOokOkOkkkkOooOkkkOkOoOokOkkkOokOkOokkOkkkOkOoOkkkOokOokkOkOokOkkOkkkOokkOokkkOkOoookOokkkOkOkOkkOkOokOkkOkkOoOkkOokOoOkkOokOkOkkkOokO OkkkOokkOkkOookO) { return OkkkOokkOkkOookO.ToString(); }
    static OkOkOokkOkkkkOokOkkkOokkOkkkOkOoOkkOokOkOkkOkkOkOokOkkkOokOkOokkOkkkOkOoOkkkOokOokkOkOokOkkOkkkOokkOokkk OkOookOkOkkOkkkOokkOookkOkkOkkkkOkkOokOoOkkOkOokOkkOkkkOokkOokkkOokOkkkOokOooookOkOkOokkOkOoookkOkOokOokOkOokOokOokOkkkOokOookkkOkkOokOkOkkkOkOoOkOkOokkOkkkOkOoOkkkOokOokkOkOokOkkOkkkOokkOokkk(OkOkOokkOkkkkOokOkkkOokkOkkkOkOoOkkOokOkOkkOkkOkOokOkkkOokOoookOokkkkOokOkkkOkOoOkkOokOk[] OkkOookO) { return OkOkOokkOkkkkOokOkkkOokkOkkkOkOoOkkOokOkOkkOkkOkOokOkkkOokOkOkOoOkkOokOkOkkkkOooOkkkOkOoOokOkkkOokOookOkOkkOkkkOokkOookkOkkOkkkkOkkOokOoOkkOkOokOkkOkkkOokkOokkk.ASCII.OkOookkkOkkOokOkOkkkOkOoOkOkOokkOkkkOkOoOkkkOokOokkOkOokOkkOkkkOokkOokkk(OkkOookO); }
    static OkOkOokkOkkkkOokOkkkOokkOkkkOkOoOkkOokOkOkkOkkOkOokOkkkOokOkOokkOkkkOkOoOkkkOokOokkOkOokOkkOkkkOokkOokkk OkOookkkOkkOokOkOkkkOkOoOkOkOokkOkkkOkOoOkkkOokOokkOkOokOkkOkkkOokkOokkk(this OkOkOokkOkkkkOokOkkkOokkOkkkOkOoOkkOokOkOkkOkkOkOokOkkkOokOkOkOoOkkOokOkOkkkkOooOkkkOkOoOokOkkkOokOookOkOkkOkkkOokkOookkOkkOkkkkOkkOokOoOkkOkOokOkkOkkkOokkOokkk OkkOokOkOkkOkkkOokkOookkOkkOkkkkOkkOokOoOkkOkOokOkkOkkkOokkOokkk, OkOkOokkOkkkkOokOkkkOokkOkkkOkOoOkkOokOkOkkOkkOkOokOkkkOokOoookOokkkkOokOkkkOkOoOkkOokOk[] OkkOookO) { return OkkOokOkOkkOkkkOokkOookkOkkOkkkkOkkOokOoOkkOkOokOkkOkkkOokkOokkk.GetString(OkkOookO); }
    static OkOkOokkOkkkkOokOkkkOokkOkkkOkOoOkkOokOkOkkOkkOkOokOkkkOokOoookOokkkkOokOkkkOkOoOkkOokOk OkOkOokkOkkkkOokOkkkOokkOkkkOkOoOkkOokOkOkkOkkOkOokOkkkOokOoookkOkkOkkkkOkkOkkkOokkkOkkOokkOokOkOkkkOokOokkkOkOoOokOkkkOokOkOkOoOkkOkkkkOkOoookOokkkkOokOkkkOkOoOkkOokOk(OkOkOokkOkkkkOokOkkkOokkOkkkOkOoOkkOokOkOkkOkkOkOokOkkkOokOkOokkOkkkOkOoOkkkOokOokkOkOokOkkOkkkOokkOokkk OkkkOokk, OkOkOokkOkkkkOokOkkkOokkOkkkOkOoOkkOokOkOkkOkkOkOokOkkkOokOokOokOkkOkkkOokkkOkOoOokkOokkOokkOokO OkkOkOok) { return OkOkOokkOkkkkOokOkkkOokkOkkkOkOoOkkOokOkOkkOkkOk.Convert.ToByte(OkkkOokk, OkkOkOok); }
    static OkOkOokkOkkkkOokOkkkOokkOkkkOkOoOkkOokOkOkkOkkOkOokOkkkOokOoookOokkOkkkkOkkOkkkkOkkOkkOoOkkOokOkOkkOoookOkkOkkkO OkkOokOoOkkOkOokOkkOookkOkkkOkOoOkOookOkOkkOkkOkOkkkOoooOkkkOkOoOkkkkOok() { return OkkOokOoOkkOkOokOkkOookkOkkkOkOo.Count == 0; }
    static void OkkOokOoOkkOkOokOkkOookkOkkkOkOoOkOooookOkkOokOoOkkOokOo(OkOkOokkOkkkkOokOkkkOokkOkkkOkOoOkkOokOkOkkOkkOkOokOkkkOokOkOokkOkkkOkOoOkkkOokOokkOkOokOkkOkkkOokkOokkk OkkOkOkk, OkOkOokkOkkkkOokOkkkOokkOkkkOkOoOkkOokOkOkkOkkOkOokOkkkOokOkOokkOkkkOkOoOkkkOokOokkOkOokOkkOkkkOokkOokkk OkkkOkkO) { OkkOokOoOkkOkOokOkkOookkOkkkOkOo.Add(OkkOkOkk, OkkkOkkO); }

    static void OkOkOokkOkkkkOokOkkkOokkOkkkOkOoOkkOokOkOkkOkkOkOokOkkkOokOoookkOkkOkkkkOkkOkkOoOkkOkkOoOkkOokOkOkkOookkOkkkOkOoOkkOkOokOkkOkkkkOkkOkkkOokkkOokkOokOkkkOokOookkkOkkOokOkOkkOkkkOokkOokOkOkkkOokOokkOkOokOkkOookkOokOkkkOokOookOoOkkOkOokOkkOookkOkkkOkOoOkkOkOokOkkOkkkkOkkOkkkOokkOoookOkkkOokOokkkkOokOokkkkOoOkkkOokkOkkkOkOoOkkkOokOokkOkOokOkkOkkkOokkOokkkOokOkkOoOkkkOokkOkkkOkOoOkkkOokOokkOkOokOkkOkkkOokkOokkkOokkkkkO()
    {
        if (OkkOokOoOkkOkOokOkkOookkOkkkOkOoOkOookOkOkkOkkOkOkkkOoooOkkkOkOoOkkkkOok())
        {
            OkkOokOoOkkOkOokOkkOookkOkkkOkOoOkOooookOkkOokOoOkkOokOo("Okk, Ok, Okk!", "k");
            OkkOokOoOkkOkOokOkkOookkOkkkOkOoOkOooookOkkOokOoOkkOokOo("Okk, Okkkk!", "o");
            OkkOokOoOkkOkOokOkkOookkOkkkOkOoOkOooookOkkOokOoOkkOokOo("Ook, Okk, Oo!", ",");
            OkkOokOoOkkOkOokOkkOookkOkkkOkOoOkOooookOkkOokOoOkkOokOo("Ook, Ooooo!", " ");
            OkkOokOoOkkOkOokOkkOookkOkkkOkOoOkOooookOkkOokOoOkkOokOo("Ook, Ooook!", "!");
            OkkOokOoOkkOkOokOkkOookkOkkkOkOoOkOooookOkkOokOoOkkOokOo("Ookk, Oook!", "1");
            OkkOokOoOkkOkOokOkkOookkOkkkOkOoOkOooookOkkOokOoOkkOokOo("Ookk, Oooo!", "0");
            OkkOokOoOkkOkOokOkkOookkOkkkOkOoOkOooookOkkOokOoOkkOokOo("Ookkkkkk!", "?");
            OkkOokOoOkkOkOokOkkOookkOkkkOkOoOkOooookOkkOokOoOkkOokOo("", "");
        }
    }
}

    /*
        Okk, Ok, Okk?  Okk, Ok, Ook?  Okk, Okk, Oo?  Okk, Okk, Oo?  Ook, Ooooo?  Okk, Okk, Ok?  Okk, Ook, Ok!

        Ok, Ook, Ook?  Ook, Ooooo?  Okkk, Okkk?  Okk, Ok, Ook?  Okkk, Ookk?  Okk, Ok, Ooo?  Ook, Ooooo?  Ok, Ooookk?  Ook, Oookk?  Ook, Ooooo?  Okkk, Okkk?  Okk, Okkkk?
        Okkk, Ok, Ok?  Okk, Okk, Oo?  Okk, Ook, Oo?  Ook, Ooooo?  Okk, Okk, Oo?  Okk, Ook, Ok?  Okkk, Ok, Oo?  Ook, Ooooo?  Okk, Okk, Ok?  Okk, Ook, Ok?  Ook, Ooooo?
        Okkk, Oooo?  Okk, Okk, Oo?  Okk, Ooook?  Okk, Oookk?  Okk, Ook, Ok?  Ook, Ooooo?  Okkk, Ok, Ok?  Okkk, Ookk?  Okk, Ok, Ook?  Okk, Okkk, O?  Okk, Ookkk?  Okkk,
        Ookk?  Ook, Ooooo?  Okk, Ooook?  Okkk, Ok, Oo?  Ook, Ooooo?  Okkk, Ok, Oo?  Okk, Ok, Ooo?  Okk, Ook, Ok?  Ook, Ooooo?  Okk, Oook, O?  Okk, Okkkk?  Okkk, Ok, Oo?
        Okkk, Ok, Oo?  Okk, Okkkk?  Okk, Okk, Ok?  Ook, Ooooo?  Okk, Ok, Ook?  Okk, Okkk, O?  Okkk, Ookk?  Okkk, Ok, Oo?  Okk, Ook, Ok?  Okk, Ooook?  Okk, Ook, Oo?  Ook, 
        Ooooo?  Okk, Okkkk?  Okk, Ookk, O?  Ook, Ooooo?  Okkk, Ok, Oo?  Okk, Ok, Ooo?  Okk, Ook, Ok?  Ook, Ooooo?  Okkk, Ok, Oo?  Okk, Okkkk?  Okkk, Oooo!

        Ok, Ook, Ook?  Okkk, Ok, Oo?  Ook, Ooooo?  Okk, Ok, Okk?  Okk, Ok, Ook?  Okk, Okk, Oo?  Okk, Okk, Oo?  Okkk, Ookk?  Ook, Ooooo?  Okk, Ok, Ooo?  Okk, Ooook?  Okk,
        Okk, Oo?  Okk, Ookk, O?  Ook, Ooooo?  Okkk, Ok, Oo?  Okk, Ok, Ooo?  Okk, Ook, Ok?  Ook, Ooooo?  Okk, Okk, Ok?  Okkkk, Ook?  Okkk, Ookk?  Okkk, Ok, Oo?  Okk, Ook, 
        Ok?  Okkk, Ook, O?  Okkkk, Ook?  Ook, Ooooo?  Okk, Okkkk?  Okkk, Ok, Oo?  Okk, Ok, Ooo?  Okk, Ook, Ok?  Okkk, Ook, O?  Okkk, Okkk?  Okk, Ok, Ook?  Okkk, Ookk?  
        Okk, Ook, Ok?  Ook, Ooooo?  Ookkk, Ok, O?  Ook, Okkkk!
    */

//****************Sample Test*****************
namespace Solution
{
    using NUnit.Framework;
    
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    
    [TestFixture]
    public class Tests
    {
        [Test]
        public void ExampleTests()
        {
            Assert.AreEqual("H", Kata.OkkOokOo("Ok, Ook, Ooo!"));
            Assert.AreEqual("e", Kata.OkkOokOo("Okk, Ook, Ok!"));
            Assert.AreEqual("l", Kata.OkkOokOo("Okk, Okk, Oo!"));
            Assert.AreEqual("o", Kata.OkkOokOo("Okk, Okkkk!"));
            Assert.AreEqual("W", Kata.OkkOokOo("Ok, Ok, Okkk!"));
            Assert.AreEqual("r", Kata.OkkOokOo("Okkk, Ook, O!"));
            Assert.AreEqual("d", Kata.OkkOokOo("Okk, Ook, Oo!"));
            Assert.AreEqual("!", Kata.OkkOokOo("Ok, Ooook!"));
        }
        
        [Test]
        public void ExtendedTest()
        {
            Assert.AreEqual("AT LAST, SIR TERRY, WE MUST WALK TOGETHER", Kata.OkkOokOo("Ok, Oooook?  Ok, Ok, Ok, Oo?  Ok, Ooooo?  Ok, Ookk, Oo?  Ok, Oooook?  Ok, Ok, Ookk?  Ok, Ok, Ok, Oo?  Ook, Okk, Oo?  Ok, Ooooo?  Ok, Ok, Ookk?  Ok, Ook, Ook?  Ok, Ok, Ook, O?  Ok, Ooooo?  Ok, Ok, Ok, Oo?  Ok, Oook, Ok?  Ok, Ok, Ook, O?  Ok, Ok, Ook, O?  Ok, Okk, Ook?  Ook, Okk, Oo?  Ok, Ooooo?  Ok, Ok, Okkk?  Ok, Oook, Ok?  Ok, Ooooo?  Ok, Ookk, Ok?  Ok, Ok, Ok, Ok?  Ok, Ok, Ookk?  Ok, Ok, Ok, Oo?  Ok, Ooooo?  Ok, Ok, Okkk?  Ok, Oooook?  Ok, Ookk, Oo?  Ok, Ook, Okk?  Ok, Ooooo?  Ok, Ok, Ok, Oo?  Ok, Ookkkk?  Ok, Oookkk?  Ok, Oook, Ok?  Ok, Ok, Ok, Oo?  Ok, Ook, Ooo?  Ok, Oook, Ok?  Ok, Ok, Ook, O!"));
        }
        
        [Test]
        public void RandomTests()
        {
            Random rand = new Random();
            
            Func<string, string> Solution = (string okkOookk) =>
            {
                var tokens = okkOookk.Split(new[] { "  " }, StringSplitOptions.None).Select(e => Regex.Replace(e, "[,?! ]", ""));

                StringBuilder result = new StringBuilder();
                foreach(var token in tokens)
                {
                    string binaryASCIICode = Regex.Replace(Regex.Replace(token, "(?i)o", "0"), "(?i)k", "1");
                    int decimalASCIICode = Convert.ToInt32(binaryASCIICode, 2);
        
                    result.Append((char)decimalASCIICode);
                }
        
                return result.ToString();
            };
            
            Func<string, string> Encode = (string text) =>
            {
                List<string> codes = new List<string>();
    
                foreach(var c in text)
                {
                    string ook = Convert.ToString(c, 2).PadLeft(8, '0').Replace('0', 'o').Replace('1', 'k');
    
                    string ookCode = string.Join(", ", Regex.Split(ook, "(o+k+|o{2,}k|ok{2,}|ok)")
                                                        .Where(e => e != string.Empty)
                                                        .Select(e => char.ToUpper(e[0]) + e.Substring(1)));
    
                    codes.Add(ookCode);
                }
    
                return string.Join("?  ", codes) + "!";
            };
            
            for(int i = 0; i < 100; i++)
            {
                int length = rand.Next(1, 21);
            
                string text = string.Concat(Enumerable.Range(0, length).Select(e => (char)rand.Next(32, 124)));
                
                string encodedText = Encode(text);
                
                string actual = Kata.OkkOokOo(encodedText);
                
                Assert.AreEqual(text, actual);
            }
        }
    }
}
