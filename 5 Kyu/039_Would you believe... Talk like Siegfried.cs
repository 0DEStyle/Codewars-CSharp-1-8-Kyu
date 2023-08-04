/*Challenge link:https://www.codewars.com/kata/57fd6c4fa5372ead1f0004aa/train/csharp
Question:
Do you ever wish you could talk like Siegfried of KAOS ?
YES, of course you do!
https://en.wikipedia.org/wiki/Get_Smart


Task
Write the function siegfried to replace the letters of a given sentence.

Apply the rules using the course notes below. Each week you will learn some more rules.

Und by ze fifz vek yu vil be speakink viz un aksent lik Siegfried viz no trubl at al!
Lessons
Week 1
ci -> si
ce -> se
c -> k (except ch leave alone)
Week 2
ph -> f
Week 3
remove trailing e (except for all 2 and 3 letter words)
replace double letters with single letters (e.g. tt -> t)
Week 4
th -> z
wr -> r
wh -> v
w -> v
Week 5
ou -> u
an -> un
ing -> ink (but only when ending words)
sm -> schm (but only when beginning words)
Notes
You must retain the case of the original sentence
Apply rules strictly in the order given above
Rules are cummulative. So for week 3 first apply week 1 rules, then week 2 rules, then week 3 rules
*/

//***************Solution********************
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

public class Dinglemouse{
  
  //Regex pattern
    private static Regex[] PATTERNS ={
        new Regex("(?i)ci|ce|c(?!h)",RegexOptions.Compiled),
        new Regex("(?i)ph",RegexOptions.Compiled),
        new Regex("(?i)(?<=[a-z]{3,})e\\b|([a-z])\\1",RegexOptions.Compiled),
        new Regex("(?i)th|w[rh]?",RegexOptions.Compiled),
        new Regex("(?i)ou|an|ing\\b|\\bsm",RegexOptions.Compiled)
    };

  //Dictionary for replacement
    private static Dictionary<string, string> CHANGES = new Dictionary<string, string>{
        ["ci"] = "si",
        ["ce"] = "se",
        ["c"] = "k",
        ["ph"] = "f",
        ["e"] = "",
        ["th"] = "z",
        ["wr"] = "r",
        ["wh"] = "v",
        ["w"] = "v",
        ["ou"] = "u",
        ["an"] = "un",
        ["ing"] = "ink",
        ["sm"] = "schm"
    };

    public static string Siegfried(int week, string str){
        var s = str;
      //looping for each week
        for (int n = 0; n < week; n++){
          //replace s with regex pattern
            s = PATTERNS[n].Replace(s, x =>{
                var tok = x.Groups[0].Value;
                var rep = new StringBuilder(CHANGES.GetValueOrDefault(tok.ToLower(), $"{tok[0]}"));
                if (char.IsUpper(tok[0]))
                    rep[0] = char.ToUpper(rep[0]);
                return rep.ToString();
            });
            Console.WriteLine($"Week {n + 1}: {s}");
        }
        return s;
    }
}

//****************Sample Test*****************
//the test case from java version
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
public class SolutionTests
{
    private static Regex[] PATTERNS =
    {
        new Regex("(?i)ci|ce|c(?!h)",RegexOptions.Compiled),
        new Regex("(?i)ph",RegexOptions.Compiled),
        new Regex("(?i)(?<=[a-z]{3,})e\\b|([a-z])\\1",RegexOptions.Compiled),
        new Regex("(?i)th|w[rh]?",RegexOptions.Compiled),
        new Regex("(?i)ou|an|ing\\b|\\bsm",RegexOptions.Compiled)
    };

    private static Dictionary<string, string> CHANGES = new Dictionary<string, string>
    {
        ["ci"] = "si",
        ["ce"] = "se",
        ["c"] = "k",
        ["ph"] = "f",
        ["e"] = "",
        ["th"] = "z",
        ["wr"] = "r",
        ["wh"] = "v",
        ["w"] = "v",
        ["ou"] = "u",
        ["an"] = "un",
        ["ing"] = "ink",
        ["sm"] = "schm"
    };

    public static string Siegfried(int week, string str)
    {
        var s = str;
        for (int n = 0; n < week; n++)
        {
            s = PATTERNS[n].Replace(s, x =>
            {
                var tok = x.Groups[0].Value;
                var rep = new StringBuilder(CHANGES.GetValueOrDefault(tok.ToLower(), $"{tok[0]}"));
                if (char.IsUpper(tok[0]))
                    rep[0] = char.ToUpper(rep[0]);
                return rep.ToString();
            });
            Console.WriteLine($"Week {n + 1}: {s}");
        }
        return s;
    }

    private static string english =
    "This is KAOS!! We don't play with Code-Wars here!! " +
    "So there will be trouble for you this time Mr Maxwell Smart! " +
    "We have received all the photographic evidence we need so choose carefully what you say next! " +
    "I hope you will co-operate with KAOS and do exactly what we want Mr Smart otherwise I won't be happy with you! " +
    "In fact, if you misbehave that would make me very unhappy indeed... " +
    "And you certainly would not want to make me unnecesarily cross would you Mr Maxwell Smart?";

    private static string afterWeek1 =
    "This is KAOS!! We don't play with Kode-Wars here!! " +
    "So there will be trouble for you this time Mr Maxwell Smart! " +
    "We have reseived all the photographik evidense we need so choose karefully what you say next! " +
    "I hope you will ko-operate with KAOS and do exaktly what we want Mr Smart otherwise I won't be happy with you! " +
    "In fakt, if you misbehave that would make me very unhappy indeed... " +
    "And you sertainly would not want to make me unnesesarily kross would you Mr Maxwell Smart?";

    private static string afterWeek2 =
    "This is KAOS!! We don't play with Kode-Wars here!! " +
    "So there will be trouble for you this time Mr Maxwell Smart! " +
    "We have reseived all the fotografik evidense we need so choose karefully what you say next! " +
    "I hope you will ko-operate with KAOS and do exaktly what we want Mr Smart otherwise I won't be happy with you! " +
    "In fakt, if you misbehave that would make me very unhappy indeed... " +
    "And you sertainly would not want to make me unnesesarily kross would you Mr Maxwell Smart?";

    private static string afterWeek3 =
    "This is KAOS!! We don't play with Kod-Wars her!! " +
    "So ther wil be troubl for you this tim Mr Maxwel Smart! " +
    "We hav reseived al the fotografik evidens we ned so chos karefuly what you say next! " +
    "I hop you wil ko-operat with KAOS and do exaktly what we want Mr Smart otherwis I won't be hapy with you! " +
    "In fakt, if you misbehav that would mak me very unhapy inded... " +
    "And you sertainly would not want to mak me unesesarily kros would you Mr Maxwel Smart?";

    private static string afterWeek4 =
    "Zis is KAOS!! Ve don't play viz Kod-Vars her!! " +
    "So zer vil be troubl for you zis tim Mr Maxvel Smart! " +
    "Ve hav reseived al ze fotografik evidens ve ned so chos karefuly vat you say next! " +
    "I hop you vil ko-operat viz KAOS and do exaktly vat ve vant Mr Smart ozervis I von't be hapy viz you! " +
    "In fakt, if you misbehav zat vould mak me very unhapy inded... " +
    "And you sertainly vould not vant to mak me unesesarily kros vould you Mr Maxvel Smart?";

    private static string afterWeek5 =
    "Zis is KAOS!! Ve don't play viz Kod-Vars her!! " +
    "So zer vil be trubl for yu zis tim Mr Maxvel Schmart! " +
    "Ve hav reseived al ze fotografik evidens ve ned so chos karefuly vat yu say next! " +
    "I hop yu vil ko-operat viz KAOS und do exaktly vat ve vunt Mr Schmart ozervis I von't be hapy viz yu! " +
    "In fakt, if yu misbehav zat vuld mak me very unhapy inded... " +
    "Und yu sertainly vuld not vunt to mak me unesesarily kros vuld yu Mr Maxvel Schmart?";

    [Test]
    public void Full5WeekCourse()
    {
        Assert.AreEqual(afterWeek1, Dinglemouse.Siegfried(1, english));
        Assert.AreEqual(afterWeek2, Dinglemouse.Siegfried(2, english));
        Assert.AreEqual(afterWeek3, Dinglemouse.Siegfried(3, english));
        Assert.AreEqual(afterWeek4, Dinglemouse.Siegfried(4, english));
        Assert.AreEqual(afterWeek5, Dinglemouse.Siegfried(5, english));
    }

    [Test]
    public void Week1Exercises()
    {
        Assert.AreEqual("Sity sivilians", Dinglemouse.Siegfried(1, "City civilians"));
        Assert.AreEqual("Sentre reseiver", Dinglemouse.Siegfried(1, "Centre receiver"));
        Assert.AreEqual("Chatanooga choo choo krashed", Dinglemouse.Siegfried(1, "Chatanooga choo choo crashed"));
        Assert.AreEqual("Kapital sity kats chew cheese", Dinglemouse.Siegfried(1, "Capital city cats chew cheese"));
    }

    [Test]
    public void Week2Exercises()
    {
        Assert.AreEqual("Foto of 5 feasants with grafs", Dinglemouse.Siegfried(2, "Photo of 5 pheasants with graphs"));
    }

    [Test]
    public void Week3Exercises()
    {
        Assert.AreEqual("Met me at the sam plas at non", Dinglemouse.Siegfried(3, "Meet me at the same place at noon"));
        Assert.AreEqual("The tim is now", Dinglemouse.Siegfried(3, "The time is now"));
        Assert.AreEqual("Be quit quiet", Dinglemouse.Siegfried(3, "Be quite quiet"));
        Assert.AreEqual("Ardvarks are nis most of the tim", Dinglemouse.Siegfried(3, "Aardvarks are nice most of the time"));
    }

    [Test]
    public void Week4Exercises()
    {
        Assert.AreEqual("Ze vitch zat rot zis vord vas ze vorst", Dinglemouse.Siegfried(4, "The witch that wrote this word was the worst"));
        Assert.AreEqual("Vich vitch is vich?", Dinglemouse.Siegfried(4, "Which witch is which?"));
        Assert.AreEqual("Riters zink zey ned anozer vek", Dinglemouse.Siegfried(4, "Writers think they need another week"));
        Assert.AreEqual("Vy vas zat vizard vaving ze ozer vand?", Dinglemouse.Siegfried(4, "Why was that wizard waving the other wand?"));
    }

    [Test]
    public void Week5Exercises()
    {
        Assert.AreEqual("Und unozer zink Mr Schmart, I vunt no mor trubl!", Dinglemouse.Siegfried(5, "And another thing Mr Smart, I want no more trouble!"));
        Assert.AreEqual("Yu ught to behav yurself Schmart!", Dinglemouse.Siegfried(5, "You ought to behave yourself Smart!"));
        Assert.AreEqual("Schmart und 99 ver husbund und vif", Dinglemouse.Siegfried(5, "Smart and 99 were husband and wife"));
    }

    [Test]
    public void BugFixes()
    {
        Assert.AreEqual(".. Mr Maxvel be Ze Schmart ..", Dinglemouse.Siegfried(5, ".. Mr Maxwell be The Smart .."));
        Assert.AreEqual(".. Mr Maxvel be Ve Schmart ..", Dinglemouse.Siegfried(5, ".. Mr Maxwell be We Smart .."));
        Assert.AreEqual("Be be Ze ze Ve ve Me me She she", Dinglemouse.Siegfried(5, "Be be The the We we Me me She she"));
        Assert.AreEqual("be Be ze Ze ve Ve me Me she She", Dinglemouse.Siegfried(5, "be Be the The we We me Me she She"));
        Assert.AreEqual("be ze ve me", Dinglemouse.Siegfried(5, "be the wee me"));
        Assert.AreEqual("be ve Maxvel be Ve be ve", Dinglemouse.Siegfried(5, "be we Maxwell be We bee wee"));
        Assert.AreEqual("Be lik Me", Dinglemouse.Siegfried(5, "Be like Me"));
        Assert.AreEqual("be ze sam", Dinglemouse.Siegfried(5, "be the same"));
        Assert.AreEqual("Ze sam be ve se", Dinglemouse.Siegfried(5, "The same bee we see"));
        Assert.AreEqual("It vas un inglorius endink", Dinglemouse.Siegfried(5, "It was an inglorious ending"));
    }

    [Test]
    public void Random()
    {
        var random = new Random();
        for (int r = 0; r < 10; r++)
        {
            var words = english.Split(' ');

            // Shuffle words or not?
            for (int w = 0; w < words.Length - 1; w++)
            {
                if (random.NextDouble() > 0.5)
                {
                    var tmp = words[w];
                    words[w] = words[w + 1];
                    words[w + 1] = tmp;
                }
            }
            var sentence = string.Join(" ", words);
            var expected = Siegfried(5, sentence);
            Assert.AreEqual(expected, Dinglemouse.Siegfried(5, sentence));
        }
    }
}
