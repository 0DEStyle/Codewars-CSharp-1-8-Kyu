/*Challenge link:https://www.codewars.com/kata/577bd8d4ae2807c64b00045b/train/csharp
Question:
Create a function that returns the name of the winner in a fight between two fighters.

Each fighter takes turns attacking the other and whoever kills the other first is victorious. Death is defined as having health <= 0.

Each fighter will be a Fighter object/instance. See the Fighter class below in your chosen language.

Both health and damagePerAttack (damage_per_attack for python) will be integers larger than 0. You can mutate the Fighter objects.

Your function also receives a third argument, a string, with the name of the fighter that attacks first.

Example:
  declare_winner(Fighter("Lew", 10, 2), Fighter("Harry", 5, 4), "Lew") => "Lew"
  
  Lew attacks Harry; Harry now has 3 health.
  Harry attacks Lew; Lew now has 6 health.
  Lew attacks Harry; Harry now has 1 health.
  Harry attacks Lew; Lew now has 2 health.
  Lew attacks Harry: Harry now has -1 health and is dead. Lew wins.
public class Fighter {
  public string Name;
  public int Health, DamagePerAttack;
  public Fighter(string name, int health, int damagePerAttack) {
    this.Name = name;
    this.Health = health;
    this.DamagePerAttack = damagePerAttack;
  }
}
*/

//***************Solution********************
using System;

public class Kata {
  public static string declareWinner(Fighter fighter1, Fighter fighter2, string firstAttacker) {
    string winner = "";
    Console.WriteLine("firstAttacker " + firstAttacker);
   Console.WriteLine(fighter1.Name + " " + fighter1.Health  + " " + fighter1.DamagePerAttack );
  Console.WriteLine(fighter2.Name + " " + fighter2.Health + " " + fighter2.DamagePerAttack );
    
    while (!(fighter1.Health <= 0) && !(fighter2.Health <= 0)){
    if (firstAttacker == fighter1.Name)
    {
        fighter2.Health = epicBattleLog.PrintLog(firstAttacker, fighter2.Name, fighter2.Health, fighter1.DamagePerAttack);
        firstAttacker = fighter2.Name;
    }else
    {
        fighter1.Health = epicBattleLog.PrintLog(fighter2.Name, fighter1.Name, fighter1.Health, fighter2.DamagePerAttack);
        firstAttacker = fighter1.Name;
    }
      if(fighter1.Health <= 0)
        winner = fighter2.Name;
      else if(fighter2.Health <= 0)
        winner = fighter1.Name;
}  
    return winner;
}
}

//print stuff, return health left
public class epicBattleLog
{
    public string Name { get; set; }
    public static int PrintLog(string attacker , string defender , int defenderHealth, int attackerDamage)
    {
        int healthLeft = defenderHealth - attackerDamage;
        if(healthLeft > 0)
        {
            Console.WriteLine(attacker + " attacks " + defender + "; " + defender + " now has " + healthLeft + " health.");
        }
        else
        {
            Console.WriteLine(attacker + " attacks " + defender + "; " + defender + " now has " + healthLeft + " health and is dead. " + attacker + " wins.");
        }
        return healthLeft;
    }
}
//****************Sample Test*****************
namespace Solution {
  using NUnit.Framework;
  using System;

  [TestFixture]
  public class SolutionTest
  {
    [Test]
    public void BasicTests() {
      Assert.AreEqual("Lew", Kata.declareWinner(new Fighter("Lew", 10, 2),new Fighter("Harry", 5, 4), "Lew"));
      Assert.AreEqual("Harry", Kata.declareWinner(new Fighter("Lew", 10, 2),new Fighter("Harry", 5, 4), "Harry"));
      Assert.AreEqual("Harald", Kata.declareWinner(new Fighter("Harald", 20, 5), new Fighter("Harry", 5, 4), "Harry"));        
      Assert.AreEqual("Harald", Kata.declareWinner(new Fighter("Harald", 20, 5), new Fighter("Harry", 5, 4), "Harald"));        
      Assert.AreEqual("Harald", Kata.declareWinner(new Fighter("Jerry", 30, 3), new Fighter("Harald", 20, 5), "Jerry"));            
      Assert.AreEqual("Harald", Kata.declareWinner(new Fighter("Jerry", 30, 3), new Fighter("Harald", 20, 5), "Harald"));
        
    }
    
    
    [Test]
    public void RandomTests() {
      string[] names = {"Willy", "Johnny", "Max", "Lui", "Marco", "Bostin", "Loyd", "Mark", "Cuban", "Lew", "Rocky", "Mario", "David", "Patrick", "Michael"};
      Random r = new Random();
    
      for (int i = 0; i < 200; i++) {
        String[] name = {names[r.Next(names.Length)], names[r.Next(names.Length)]};
        while (name[0].Equals(name[1])) {
          name[1] = names[r.Next(names.Length)];
        }
        int[] health = {r.Next(999) + 1, r.Next(999) + 1}, damagePerAttack = {r.Next(99) + 1, r.Next(99) + 1};
        string first = name[r.Next(1)];
        Assert.AreEqual(Solution(new Fighter(name[0], health[0], damagePerAttack[0]), new Fighter(name[1], health[1], damagePerAttack[1]), first), Kata.declareWinner(new Fighter(name[0], health[0], damagePerAttack[0]), new Fighter(name[1], health[1], damagePerAttack[1]), first));
    }
  }
  
  private string Solution(Fighter fighter1, Fighter fighter2, String firstAttacker) {
    while (true) {
      if (fighter1.Name.Equals(firstAttacker)) {
        fighter2.Health -= fighter1.DamagePerAttack;
        if (fighter2.Health <= 0) return fighter1.Name;
        fighter1.Health -= fighter2.DamagePerAttack;
        if (fighter1.Health <= 0) return fighter2.Name;
      } else {
        fighter1.Health -= fighter2.DamagePerAttack;
        if (fighter1.Health <= 0) return fighter2.Name;
        fighter2.Health -= fighter1.DamagePerAttack;
        if (fighter2.Health <= 0) return fighter1.Name;
      }
    }
  }
    
    
  }
}
