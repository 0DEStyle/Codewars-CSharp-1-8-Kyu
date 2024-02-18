/*Challenge link:https://www.codewars.com/kata/55c423ecf847fbcba100002b/train/csharp
Question:
Problem Description:

Oh no, Timmy's received some hate mail recently but he knows better. Help Timmy fix his regex filter so he can be awesome again!

Task:

You are given a string phrase containing some potentially offensive words such as "bad," "mean," "ugly," "horrible," and "hideous." Timmy wants to replace these words with the word "awesome" to make the message more positive. Your task is to implement a function, that replaces all occurrences of these offensive words with "awesome" in the input string phrase.

Input:

A string phrase containing words separated by spaces.
Output:

A string with the same words as phrase, but with any offensive words replaced by "awesome."
Example:

Input: "You're Bad! timmy!"
Output: "You're awesome! timmy!"
Input: "You're MEAN! timmy!"
Output: "You're awesome! timmy!"
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

//note the test case is wrong, add this to line 3: using System.Text.RegularExpressions;
//(?i) ignore case, compare pattern and replace with "awesome"
using System.Text.RegularExpressions;

public class Kata{
  public static string filterWords(string phrase) => Regex.Replace(phrase, @"(?i)bad|mean|ugly|horrible|hideous\b", "awesome");
}

//****************Sample Test*****************
using System;
using NUnit.Framework;
using System.Collections.Generic;
using System.Text.RegularExpressions;

[TestFixture]
public class Tests
{
  [Test]
  public static void FixedTest()
  {
    Assert.AreEqual("You're awesome! timmy!", Kata.filterWords("You're Bad! timmy!"));
    Assert.AreEqual("You're awesome! timmy!", Kata.filterWords("You're MEAN! timmy!"));
    Assert.AreEqual("You're awesome!! timmy!", Kata.filterWords("You're UGLY!! timmy!"));
    Assert.AreEqual("You're awesome! timmy!", Kata.filterWords("You're horrible! timmy!"));
    Assert.AreEqual("You're awesome!! timmy!", Kata.filterWords("You're HiDeOuS!! timmy!"));
    Assert.AreEqual("You're awesomeish!! timmy!", Kata.filterWords("You're Meanish!! timmy!"));
  }
  
  [Test]
  public static void RandomTests()
  {
    Random r = new Random();
    for(int i = 0; i < 100; i++)
    {
      int num = r.Next(4);
      Assert.AreEqual(genPhrase(num,true), Kata.filterWords(genPhrase(num,false)));
    }
  }
  
  private static string genPhrase(int n, bool a)
  {
    string[] mw = new string[] { "bad","mean","ugly","horrible","hideous","Bad","MEaN","UglY","HorrIbLe","HiDeOuS","BAD","MEAN","UGLY","HORRIBLE","HIDEOUS","baD","MeaN","UglY","HoRRiBlE","HideouS"};
    
    if(a)
      mw = new string[] {"awesome"};
    
    
    Random r = new Random();
    int w1 = r.Next(mw.Length);
    int w2 = r.Next(mw.Length);
    int w3 = r.Next(mw.Length);
    int w4 = r.Next(mw.Length);
  
    string[] phrases = new string[] {"Man timmy you really are {1}","You're Soo {1} and {3}!","You {1} and {2} and {3} and {4}!!","Go on timmy you {3} person!","Go on timmy you {3}ish person!"};
    return phrases[n].Replace("{1}",mw[w1]).Replace("{2}",mw[w2]).Replace("{3}",mw[w3]).Replace("{4}",mw[w4]);
  }
}
