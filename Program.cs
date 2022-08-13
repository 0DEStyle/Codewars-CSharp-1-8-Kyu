using System;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
// See https://aka.ms/new-console-template for more information

long temp = 35231;
Console.WriteLine(TestLibrary.Class1.Digitize(548702838394));



//new stuff
//count the total
//count the error m-z
//return a string error/total

string test = "aaabbbbhaijjjm";
string test2 = "aaaaaaaaaaaaaaaabbbbbbbbbbbbbbbbbbmmmmmmmmmmmmmmmmmmmxyz";

string totalLength = test.Length.ToString();
string errorLength = Regex.Replace(test2, "[^n-z]", "").Length.ToString();


Console.WriteLine(errorLength);
Console.WriteLine(totalLength);
