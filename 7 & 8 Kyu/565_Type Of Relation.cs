/*Challenge link:https://www.codewars.com/kata/64915dc9d40f96004319379a/train/csharp
Question:
Given two sets of integer numbers (domain and codomain), and a list of relationships (x, y) also integers, determine if they represent a function and its type:
1. Not a function: If there is at least one element in the domain set that is related to more than one element in the codomain set.
Example:
domain = {10, 20, 30, 40, 50}
codomain = {20, 30, 40, 50}
relations = {(10, 20),(10, 50),(20, 30),(30, 40),(40, 50),(50, 20)}
output = "It is not a function"
(this is because the element 10 in the domain is related to more than one element in the codomain,
therefore, it does not fulfill the uniqueness criterion).
2. Function: Each and every element in the domain set is related to an element in the codomain set. They are classified as:
A. Injective: Every element in the codomain set is related to at most one element in the domain set. In other words, there are no two distinct elements in the domain set that have the same image in the codomain set.
Example:

domain = {1, 2}
codomain = {20, 30, 40}
relations = {(1, 20),(2, 30)}
output = "Injective"
(because each element in the codomain is related to zero or at most one element in the domain).
B. Surjective: All elements in the codomain set are related to at least one element in the domain set. In other words, there are no elements in the codomain set that do not have a preimage in the domain set.
Example:

domain = {1, 2, 3, 4, 5}
codomain = {20, 30, 40, 50}
relations = {(1, 20),(2, 30),(3, 40),(4, 50),(5, 40)}
output = "Surjective"
(because all elements in the codomain are related to at least one element in the domain,
element 40 has more than one relation in the domain).
C. Bijective: Every element in the domain set is related to a unique element in the codomain set, and vice versa. Each element in the codomain set has a unique preimage in the domain set, and each element in the domain set has a unique image in the codomain set.
In other words, a function is bijective when it is injective and surjective at the same time.
Example:

domain = {2, 3, 4}
codomain = {2, 3, 4}
relations = {(3, 4),(2, 3),(4, 2)}
output = "Bijective" 
(because each element in the codomain is related to exactly one element in the domain).
D. General: There are elements in the domain set that are related to at least one element in the codomain set, but there may be elements in the codomain set that are not related to any element in the domain set.
Example:

domain = {1, 2, 3}
codomain = {2, 3, 4}
relations = {(1, 4),(2, 4),(3, 4)}
output = "General function"
(all elements in the domain are related to at least one element in the codomain,
although some elements in the codomain are not related to any element in the domain).
Note: All the first elements in the relations belong to the domain set, and all the second elements belong to the codomain set.
*/

//***************Solution********************
using System;
using System.Collections.Generic;
using System.Linq;

//domain
//codomain
//relation
//not a function, function, injective, surjective, bijective, general
namespace ClasificacionFunciones{
    public class Solution{
        public static string TypeOfFunction(HashSet<int> domain, HashSet<int> codomain, HashSet<Tuple<int, int>> relations){
          //select items from hashset and store in array
          var a = relations.Select(x => x.Item1).ToArray();
          var b = relations.Select(x => x.Item2).ToArray();
          
          //bool val
          var injective = b.Length == b.Distinct().Count();
          var surjective = b.Distinct().Count() == codomain.Count();
          
          //not a function
          if(a.Length != a.Distinct().Count())
            return "It is not a function";
          
          return injective && surjective ? 
            "Bijective" : injective ?
            "Injective" : surjective ?
            "Surjective" : "General function";
        }
    }
}


//****************Sample Test*****************
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using ClasificacionFunciones;

[TestFixture]
public class TestClasificacionFunciones
{
    #region Injective 
    [Test]
    public void TestInjective()
    {
        var dominio = new List<HashSet<int>>
        {
            new HashSet<int> { 1,2},
            new HashSet<int> { 10,20,30,40},
            new HashSet<int> { 2, 3 }
        };

        var codominio = new List<HashSet<int>>
        {
            new HashSet<int> { 20,30,40 },
            new HashSet<int> { 100,200,300,400,500},
            new HashSet<int> { 2, 3, 4 }
        };

        var relaciones = new List<HashSet<Tuple<int, int>>>
        {
            new HashSet<Tuple<int, int>>
            {
                new Tuple<int, int>(1,20),
                new Tuple<int, int>(2,30),
            },
            new HashSet<Tuple<int, int>>
            {
                new Tuple<int, int>(10,100),
                new Tuple<int, int>(20,200),
                new Tuple<int, int>(30,300),
                new Tuple<int, int> (40,400)
            },
            new HashSet<Tuple<int, int>>
            {
                new Tuple<int, int>(3,4),
                new Tuple<int, int>(2,3),
            }
        };

        int N = relaciones.Count;

        var actual = Enumerable.Range(0, N)
                    .Select(i => Solution.TypeOfFunction(dominio[i], codominio[i], relaciones[i]))
                    .ToList();

        var expected = Enumerable.Repeat("Injective", N).ToList();

        CollectionAssert.AreEqual(expected, actual);
    }
    #endregion

    #region Surjective
    [Test]
    public void TestSurjective()
    {
        var dominio = new List<HashSet<int>>
        {
            new HashSet<int> { 1,2,3,4,5},
            new HashSet<int> { 10,20,30,40},
            new HashSet<int> { 50,100,150,200,250,300},
            new HashSet<int> { 1, 2, 3, 4 }
        };

        var codominio = new List<HashSet<int>>
        {
            new HashSet<int> { 20,30,40,50},
            new HashSet<int> { 100,200,300},
            new HashSet<int> { 1000,2000,3000,4000,5000},
            new HashSet<int> { 2, 3, 4 }
        };

        var relaciones = new List<HashSet<Tuple<int, int>>>
        {
            new HashSet<Tuple<int, int>>
            {
                new Tuple<int, int> (1,20),
                new Tuple<int, int> (2,30),
                new Tuple<int, int> (3,40),
                new Tuple<int, int> (4,50),
                new Tuple<int, int> (5,40),
            },
            new HashSet<Tuple<int, int>>
            {
                new Tuple<int, int> (10,100),
                new Tuple<int, int> (20,200),
                new Tuple<int, int> (30,300),
                new Tuple<int, int> (40,300)
            },
            new HashSet<Tuple<int, int>>
            {
                new Tuple<int, int> (50,1000),
                new Tuple<int, int> (100,2000),
                new Tuple<int, int> (150,3000),
                new Tuple<int, int> (200,4000),
                new Tuple<int, int> (250,5000),
                new Tuple<int, int> (300,4000),
            },
            new HashSet<Tuple<int, int>>
            {
                new Tuple<int, int>(1,2),
                new Tuple<int, int>(2,4),
                new Tuple<int, int>(3,4),
                new Tuple<int, int>(4,3)
            }
        };

        int N = relaciones.Count;

        var actual = Enumerable.Range(0, N)
                    .Select(i => Solution.TypeOfFunction(dominio[i], codominio[i], relaciones[i]))
                    .ToList();

        var expected = Enumerable.Repeat("Surjective", N).ToList();

        CollectionAssert.AreEqual(expected, actual);
    }
    #endregion

    #region Bijective
    [Test]
    public void TestBijective()
    {
         var dominio = new List<HashSet<int>>
         {
             new HashSet<int> {10,11,12 },
             new HashSet<int> { 1, 2, 3},
             new HashSet<int> { 4, 5, 6},
             new HashSet<int> { 2, 3, 4 },
             new HashSet<int> { 1, 2, 3, 4 },
             new HashSet<int> { 70, 27, 11, 15, 51, 52, 55, 59, 63 }
         };

         var codominio = new List<HashSet<int>>
         {
             new HashSet<int> { 20,22,24 },
             new HashSet<int> { 2,4,6 },
             new HashSet<int> { 8,10,12 },
             new HashSet<int> { 2, 3, 4 },
             new HashSet<int> { 2, 3, 4, 5 },
             new HashSet<int> { 1, 72, 12, 81, 29, 20, 57, 28, 61 }
         };

         var relaciones = new List<HashSet<Tuple<int, int>>>
         {
             new HashSet<Tuple<int, int>>
             {
                 new Tuple<int, int>(10,20),
                 new Tuple<int, int>(11,22),
                 new Tuple<int, int>(12,24),
             },
             new HashSet<Tuple<int, int>>
             {
                 new Tuple<int, int>(1,2),
                 new Tuple<int, int>(2,4),
                 new Tuple<int, int>(3,6),
             },
             new HashSet<Tuple<int, int>>
             {
                 new Tuple<int, int>(4,8),
                 new Tuple<int, int>(5,10),
                 new Tuple<int, int>(6,12),
             },
             new HashSet<Tuple<int, int>>
             {
                 new Tuple<int, int>(3,4),
                 new Tuple<int, int>(2,3),
                 new Tuple<int, int>(4,2),
             },
             new HashSet<Tuple<int, int>>
             {
                 new Tuple<int, int>(1,4),
                 new Tuple<int, int>(2,3),
                 new Tuple<int, int>(4,2),
                 new Tuple<int, int>(3,5),
             },
             new HashSet<Tuple<int, int>>  
             {
                 new Tuple<int, int>(63, 81),
                 new Tuple<int, int>(27, 57),
                 new Tuple<int, int>(59, 12),
                 new Tuple<int, int>(70, 28),
                 new Tuple<int, int>(52, 1),
                 new Tuple<int, int>(15, 61),
                 new Tuple<int, int>(11, 20),
                 new Tuple<int, int>(63, 81),
                 new Tuple<int, int>(51, 29),
                 new Tuple<int, int>(55, 72)
             }
         };

         int N = relaciones.Count;

         var actual = Enumerable.Range(0, N)
                     .Select(i => Solution.TypeOfFunction(dominio[i], codominio[i], relaciones[i]))
                     .ToList();

         var expected = Enumerable.Repeat("Bijective", N).ToList();

         CollectionAssert.AreEqual(expected, actual);
    }
    #endregion

    #region General Function
    [Test]
    public void TestGeneralFunction()
    {
        var dominio = new List<HashSet<int>>
        {
            new HashSet<int> { 1, 2, 3 },
            new HashSet<int> { 1, 2, 3 }
        };

        var codominio = new List<HashSet<int>>
        {
            new HashSet<int> { 2, 3, 4 },
            new HashSet<int> { 2, 3, 4 }
        };

        var relaciones = new List<HashSet<Tuple<int, int>>>
        {
            new HashSet<Tuple<int, int>>
            {
                new Tuple<int, int>(1,4),
                new Tuple<int, int>(2,4),
                new Tuple<int, int>(3,4)
            },
            new HashSet<Tuple<int, int>>
            {
                new Tuple<int, int>(1,3), 
                new Tuple<int, int>(2,3),
                new Tuple<int, int>(3,2)
            }
        };

        int N = relaciones.Count;

        var actual = Enumerable.Range(0, N)
                    .Select(i => Solution.TypeOfFunction(dominio[i], codominio[i], relaciones[i]))
                    .ToList();

        var expected = Enumerable.Repeat("General function", N).ToList();

        CollectionAssert.AreEqual(expected, actual);
    }
    #endregion

    #region Not Function
    [Test]
    public void TestNotFunction()
    {
        var dominio = new List<HashSet<int>>
        {
            new HashSet<int> { 10,20,30,40,50},
            new HashSet<int> { 100,200,300,400,500},
            new HashSet<int> { 2, 3, 4 }
        };

        var codominio = new List<HashSet<int>>
        {
            new HashSet<int> { 20,30,40,50},
            new HashSet<int> { 22,33,44,55},
            new HashSet<int> { 2, 3, 4 }
        };

        var relaciones = new List<HashSet<Tuple<int, int>>>
        {
            new HashSet<Tuple<int, int>>
            {
                new Tuple<int, int> (10,20),
                new Tuple<int, int> (10,50),
                new Tuple<int, int> (20,30),
                new Tuple<int, int> (30,40),
                new Tuple<int, int> (40,50),
                new Tuple<int, int> (50,20),
            },
            new HashSet<Tuple<int, int>>
            {
                new Tuple<int, int> (100,22 ),
                new Tuple<int, int> (200,22 ),
                new Tuple<int, int> (200,33 ),
                new Tuple<int, int> (300,22 ),
                new Tuple<int, int> (400,55 ),
                new Tuple<int, int> (500,44 ),
                new Tuple<int, int> (500,33 ),
            },
            new HashSet<Tuple<int, int>>
            {
                new Tuple<int, int>(3,4),
                new Tuple<int, int>(2,3),
                new Tuple<int, int>(2,4),
                new Tuple<int, int>(4,4)
            }
        };

        int N = relaciones.Count;

        var actual = Enumerable.Range(0, N)
                    .Select(i => Solution.TypeOfFunction(dominio[i], codominio[i], relaciones[i]))
                    .ToList();

        var expected = Enumerable.Repeat("It is not a function", N).ToList();

        CollectionAssert.AreEqual(expected, actual);
    }
    #endregion


    /// <summary>
    /// Injective, bijective, surjective. It is not function. General function
    /// </summary>
    /// <param name="domain"></param>
    /// <param name="codomain"></param>
    /// <param name="relations"></param>
    /// <returns></returns>
    public static string TypeOfFunction(HashSet<int> domain,
                                              HashSet<int> codomain,
                                              HashSet<Tuple<int, int>> relations)
    {
        var dic = new Dictionary<int, int>();

        foreach (Tuple<int, int> r in relations)
        {
            if (dic.ContainsKey(r.Item1))
            {
                if (dic[r.Item1] != r.Item2)
                {
                    return "It is not a function";
                }
            }
            else { dic.Add(r.Item1, r.Item2); }
        }

        var hash_imagen = new HashSet<int>(relations.Select(r => r.Item2));
        bool es_sobreyectiva = hash_imagen.Count == codomain.Count;
        bool es_inyectiva = !relations.GroupBy(r => r.Item2).Any(g => g.Count() > 1);

        if (es_inyectiva && es_sobreyectiva && domain.Count == codomain.Count) return "Bijective";
        else if (es_inyectiva) return "Injective";
        else if (es_sobreyectiva) return "Surjective";
        return "General function";
    }

    public class Relacion
    {
        public HashSet<Tuple<int, int>> R;
        public HashSet<int> Domain;
        public HashSet<int> Codomain;
        static Random Random = new Random(DateTime.Now.Millisecond);

        public Relacion(int sizeSet)
        {
            R = new HashSet<Tuple<int, int>>();
            Domain= new HashSet<int>();
            Codomain = new HashSet<int>();
            CargarRelacion(sizeSet);
        }

        public void CargarRelacion(int setSize)
        {
            var listaX = new List<int>();
            for (int i = 0; i < setSize; i++) { listaX.Add(Random.Next(1, 100)); }

            var listaY = new List<int>();
            for (int i = 0; i < setSize; i++) { listaY.Add(Random.Next(1, 100)); }

            for (int i = 0; i < setSize; i++)
            {
                R.Add(new Tuple<int, int>(listaX[i], listaY[i]));
            }

            Domain = new HashSet<int>(listaX);
            Codomain = new HashSet<int>(listaY);
        }
    }

    [Test]
    public void TestSmallRandom()
    {
        var R = new List<Relacion>();
        int sizeSet = 50;

        int cantRelaciones = 10;
        for (int i = 0; i < cantRelaciones; i++)
        {
            R.Add(new Relacion(sizeSet));
        }

        int N = R.Count;

        var actual = Enumerable.Range(0, N)
                    .Select(i => Solution.TypeOfFunction(R[i].Domain, R[i].Codomain, R[i].R))
                    .ToList();

        var expected = Enumerable.Range(0, N)
                      .Select(i => TypeOfFunction(R[i].Domain, R[i].Codomain, R[i].R))
                      .ToList();

        CollectionAssert.AreEqual(expected, actual);
    }

    [Test]
    public void TestMediumRandom()
    {
        var R = new List<Relacion>();
        int sizeSet = 10;

        int cantRelaciones = 200;
        for (int i = 0; i < cantRelaciones; i++)
        {
            R.Add(new Relacion(sizeSet));
        }

        int N = R.Count;

        var actual = Enumerable.Range(0, N)
                    .Select(i => Solution.TypeOfFunction(R[i].Domain, R[i].Codomain, R[i].R))
                    .ToList();

        var expected = Enumerable.Range(0, N)
                      .Select(i => TypeOfFunction(R[i].Domain, R[i].Codomain, R[i].R))
                      .ToList();

        CollectionAssert.AreEqual(expected, actual);
    }

    [Test]
    public void TestBigRandom()
    {
        var R = new List<Relacion>();
        int sizeSet = 1000;

        int cantRelaciones = 200;
        for (int i = 0; i < cantRelaciones; i++)
        {
            R.Add(new Relacion(sizeSet));
        }

        int N = R.Count;

        var actual = Enumerable.Range(0, N)
                    .Select(i => Solution.TypeOfFunction(R[i].Domain, R[i].Codomain, R[i].R))
                    .ToList();

        var expected = Enumerable.Range(0, N)
                      .Select(i => TypeOfFunction(R[i].Domain, R[i].Codomain, R[i].R))
                      .ToList();

        CollectionAssert.AreEqual(expected, actual);
    }

}
