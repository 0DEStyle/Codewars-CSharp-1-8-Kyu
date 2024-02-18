/*Challenge link:https://www.codewars.com/kata/514a677421607afc99000002/train/csharp
Question:
The following code is not giving the expected results. Can you debug what the issue is?

The following is an example of data that would be passed in to the function.

public class Person
{
  public int Age;
  public string Name;

  public Person(string name = "John", int age = 21)
  {
    Age = age;
    Name = name;
  }
}

Person[] data = new Person[]
{
  new Person("Joe", 20),
  new Person("Bill", 30),
  new Person("Kate", 23)
};

Kata.GetNames(data) => new string[] {"Joe", "Bill", "Kate"};
*/

//***************Solution********************

//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
/*
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣀⣤⣤⣶⡾⠿⠿⠛⠛⠛⠛⠛⠛⠛⠛⠋⠉⠉⠛⠛⠛⠛⠛⠛⠛⠛⠛⠻⠿⢿⣶⣤⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⣠⣶⡿⠛⠋⠉⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀ ⠈⠛⠿⣷⣦⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⢀⣼⡿⠃⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀   ⠻⣿⣆⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⢀⣿⠟⠀⠀⠀⢠⣤⣤⠀⣀⡀⢀⣤⣤⠀⣀⣤⣤⣄⠀⠀⣀⣤⡄⠀⢠⡄⠀⠀⣴⡄⣀⣤⣤⡄⠀⠀⠀⠀⠀⠈⢿⣷⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⣼⡟⠀⠀⠀⢠⣿⠿⣿⠀⣿⣿⣼⣿⣿⢀⣿⠏⠙⣿⡆⢰⡿⠋⠁⠀⢸⣧⠀⠀⣿⡇⣿⣿⣭⡀⠀⠀⠀⠀⠀⠀⠀⣿⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⣿⡇⠀⠀⠀⣿⣿⣶⣿⡄⣿⡿⠿⢹⣿⢸⣿⣀⣀⣿⠃⢸⣧⢘⣿⡇⠘⣿⣄⣠⣿⠁⢠⣬⣽⣿⠀⠀⠀⠀⠀⠀⢰⣿⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⢿⣇⠀⠀⠀⠿⠀⠀⠿⠇⠿⠇⠀⠈⠛⠀⠙⠛⠛⠛⠀⠈⠻⠿⠛⠀⠀⠈⠛⠛⠋⠀⠀⠉⠉⠁⠀⠀⠀⠀⠀⢀⣾⡟⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠈⢿⣧⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣠⣾⡟⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠙⠿⣷⣄⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣠⣤⣾⠿⠋⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⠻⠿⣶⣦⣤⣤⣀⣀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣤⡄⢀⣀⣀⣤⣤⣴⡾⠿⠛⠉⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⠉⠙⠛⠛⠛⠛⠛⠛⠛⠛⠿⣷⡆⠀⠀⠀⢀⣾⠟⠛⠛⠛⠛⠋⠉⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣿⡇⠀⠀⣰⣿⠏⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣿⡇⢀⣾⡿⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣿⣷⣿⠋⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣿⡿⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣀⣀⣤⣤⣤⣤⣤⣀⣀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⢀⣠⡾⠟⠋⠁⠀⠀⠀⠀⠀⠉⠙⠻⢷⣤⣀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⢠⣾⠋⠀⠀⠀⢀⣀⣀⣀⠀⠀⠀⠀⠀⠀⠉⠻⢷⣄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⣰⡟⠁⠀⠀⠀⠐⠟⠋⠉⠙⠃⠀⠀⠀⠀⠀⠀⠀⠈⢻⣇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⣿⠀⠀⠀⠀⠀⢀⣠⣄⣀⣀⣀⣀⣀⠀⠀⠀⠀⠀⠀⠀⣿⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⣿⠀⠀⠀⠀⠀⣿⣉⠉⠉⢹⣿⣿⣿⠇⣾⠛⠷⢶⣶⣶⣿⡆⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠻⣧⡀⠀⠀⠀⠈⠙⠛⠷⠿⠛⠋⠁⢀⣻⢶⣤⣼⣿⣿⡿⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠙⢷⣦⡀⠀⠀⣿⡛⠛⠻⢶⣦⣤⣼⠿⠀⠀⠀⣰⡿⠃⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠙⠻⢶⣦⡙⠛⠛⠛⠛⢋⣩⡶⢀⣠⣶⡾⠋⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣀⣀⣀⣀⣀⣀⣀⡀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣰⡟⠀⠀⠛⢻⡿⠿⠿⠟⠛⠉⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢠⣴⣴⡟⠉⠀⠈⠉⠉⠉⠛⠻⢷⣤⣄⠀⠀
⠀⠀⠀⠀⠀⢀⣠⣴⠶⠶⠿⠁⠀⠀⠀⢸⣇⣀⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣿⣿⡏⢀⣤⣤⣤⣤⣤⣤⣤⣀⢨⠿⣿⡀⠀
⠀⠀⠀⠀⣠⡿⠋⠀⠀⠀⠀⠀⠀⠀⠀⠈⠉⠙⠛⢷⡄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢻⡟⠀⣾⡋⢤⣠⣀⣀⣀⢈⣿⡌⠀⢹⣧⠀      I've become so numb
⠀⠀⠀⢸⡟⠀⠀⢀⣤⡶⣦⣄⡀⠀⠀⠀⠀⣤⠀⠈⢿⡄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣾⠃⠀⠈⠻⣿⣷⣶⣿⡿⠟⠉⠀⠀⠀⢻⡆  /      I can't feel you there
⠀⠀⠀⣾⠃⠀⢠⡿⠋⠀⠀⠙⢷⣦⣴⡶⣶⡿⠀⠀⢸⡇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣸⠏⠀⠀⠀⠀⠘⠛⠛⠛⠁⠀⠀⠀⠀⠀⠸⣧ /     Become so tired
⠀⠀⢰⡟⠀⠀⢸⣷⡟⣶⢀⣴⡾⠋⠁⠀⣿⠁⠀⠀⣸⡇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢠⡟⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣿           So much more aware
⠀⠀⣾⠃⠀⣤⣈⠙⣷⣿⣾⠋⠀⠀⢀⣠⡟⠀⠀⢠⡿⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣸⡇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣿        I'm becoming this
⠀⠀⣿⠀⠀⠈⠻⣷⣄⡀⠀⢀⣠⣴⣟⠋⠁⠀⢠⣿⠃⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣿⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣿            All I want to do
⠀⢸⡟⠀⠀⠀⠀⠀⠙⠛⠛⠛⠋⠉⠙⠿⣶⣾⠟⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸⡇⠀⠀⠀⠀⣀⣤⣤⣤⣤⣤⡀⠀⠀⠀⠀⠀⣿          Is be more like me
⠀⣿⠃⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣿⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣾⠁⠀⠀⠀⢸⡏⠀⠀⠀⠀⠙⣿⠀⠀⠀⠀⠀⢸⡏              And be less like you
⢀⣿⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣿⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣠⡶⠶⠒⠺⠿⠀⠀⠀⠀⢸⡇⠀⠀⠀⠀⠀⣿⠀⠀⠀⠀⠀⢸⡇
⢸⡏⠀⠀⠀⠀⠀⠀⣴⡟⠛⢿⡄⠀⠀⠀⣸⡏⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢻⣇⠀⠀⠀⠀⠀⠀⠀⣀⣼⠇⠀⠀⣀⣀⣠⣿⠀⠀⠀⠀⠀⢸⠇
⢸⡇⠀⠀⠀⠀⠀⣼⡟⠀⠀⢸⡇⠀⠀⠀⣿⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⠛⠻⠶⠦⠶⠴⠶⠞⠛⠁⠀⢠⡿⠋⠉⠉⠁⠀⠀⠀⠀⢀⣼⠀
⢸⡇⠀⠀⢀⣀⣀⣿⡀⠀⠀⢸⡇⠀⠀⠀⠿⠛⠛⠲⢶⣦⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⠻⢶⣤⣤⣤⣤⣴⠾⠟⠛⠋⠀
⢸⣧⠀⠀⠈⠉⠉⠉⠛⢷⡄⢸⣇⠀⠀⠀⠀⠀⠀⠀⣠⣿⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⢿⣦⣀⠀⠀⠀⠀⠀⣸⠃⠈⠛⠛⠓⠶⠶⠶⠞⠛⠋⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⣤⣠⡈⠙⠛⠛⠶⠶⠟⠛⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
*/
//added System.Linq;
//added x => x and ToArray()
using System.Linq;

public class Kata{
  public static string[] GetNames(Person[] data) => data.Select(x => x.Name).ToArray();
}

//****************Sample Test*****************
namespace Solution 
{
  using NUnit.Framework;
  using System;
  using System.Linq;

  [TestFixture]
  public class Fixed_Tests
  {
    private static object[] testCases = new object[]
    {
      new object[]
      {
        new Person[]
        {
          new Person("Joe", 20),
          new Person("Bill", 30),
          new Person("Kate", 23)
        },
        new string[] {"Joe", "Bill", "Kate"}
      },
      new object[]
      {
        new Person[]
        {
          new Person("Jane", 20),
          new Person("Sam", 30)
        },
        new string[] {"Jane", "Sam"}
      },
      new object[]
      {
        new Person[]
        {
          new Person("Alexander", 27),
          new Person("Catherine", 42)
        },
        new string[] {"Alexander", "Catherine"}
      }
    };
  
    [Test, TestCaseSource("testCases")]
    public void FixedTest(Person[] testCase, string[] expected)
    {
      Assert.AreEqual(expected, Kata.GetNames(testCase));
    }
  }
  
  [TestFixture]
  public class Random_Tests
  {
    private static Random rnd = new Random();
    
    private static string[] solution(Person[] data) =>
      data.Select(p => p.Name)
          .ToArray();
          
    private static string generateName() =>
      String.Concat(new char[rnd.Next(3, 20)].Select(_ => (char)rnd.Next(97, 123)));
    
    [Test]
    public void RandomTest()
    {
      const int Tests = 100;
      
      for (int i = 0; i < Tests; ++i)
      {
        Person[] test = new Person[rnd.Next(3, 20)].Select(_ => new Person(generateName(), rnd.Next(2, 101))).ToArray();
        string[] actual = Kata.GetNames(test);
        string[] expected = solution(test);
        
        Assert.AreEqual(expected, actual);
      }
    }
  }
}
