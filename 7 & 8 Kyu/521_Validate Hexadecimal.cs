/*Challenge link:https://www.codewars.com/kata/55a5a70c81e8541d990000bd/train/csharp
Question:
Create a function to validate if a string is a valid hexadecimal.

Two patterns is valid

6 chars (ff00ff)
3 chars (f0f).

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
⠀⠀⠀⠀⣠⡿⠋⠀⠀⠀⠀⠀⠀⠀⠀⠈⠉⠙⠛⢷⡄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢻⡟⠀⣾⡋⢤⣠⣀⣀⣀⢈⣿⡌⠀⢹⣧⠀
⠀⠀⠀⢸⡟⠀⠀⢀⣤⡶⣦⣄⡀⠀⠀⠀⠀⣤⠀⠈⢿⡄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣾⠃⠀⠈⠻⣿⣷⣶⣿⡿⠟⠉⠀⠀⠀⢻⡆
⠀⠀⠀⣾⠃⠀⢠⡿⠋⠀⠀⠙⢷⣦⣴⡶⣶⡿⠀⠀⢸⡇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣸⠏⠀⠀⠀⠀⠘⠛⠛⠛⠁⠀⠀⠀⠀⠀⠸⣧
⠀⠀⢰⡟⠀⠀⢸⣷⡟⣶⢀⣴⡾⠋⠁⠀⣿⠁⠀⠀⣸⡇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢠⡟⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣿
⠀⠀⣾⠃⠀⣤⣈⠙⣷⣿⣾⠋⠀⠀⢀⣠⡟⠀⠀⢠⡿⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣸⡇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣿
⠀⠀⣿⠀⠀⠈⠻⣷⣄⡀⠀⢀⣠⣴⣟⠋⠁⠀⢠⣿⠃⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣿⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣿
⠀⢸⡟⠀⠀⠀⠀⠀⠙⠛⠛⠛⠋⠉⠙⠿⣶⣾⠟⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸⡇⠀⠀⠀⠀⣀⣤⣤⣤⣤⣤⡀⠀⠀⠀⠀⠀⣿
⠀⣿⠃⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣿⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣾⠁⠀⠀⠀⢸⡏⠀⠀⠀⠀⠙⣿⠀⠀⠀⠀⠀⢸⡏
⢀⣿⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣿⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣠⡶⠶⠒⠺⠿⠀⠀⠀⠀⢸⡇⠀⠀⠀⠀⠀⣿⠀⠀⠀⠀⠀⢸⡇
⢸⡏⠀⠀⠀⠀⠀⠀⣴⡟⠛⢿⡄⠀⠀⠀⣸⡏⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢻⣇⠀⠀⠀⠀⠀⠀⠀⣀⣼⠇⠀⠀⣀⣀⣠⣿⠀⠀⠀⠀⠀⢸⠇
⢸⡇⠀⠀⠀⠀⠀⣼⡟⠀⠀⢸⡇⠀⠀⠀⣿⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⠛⠻⠶⠦⠶⠴⠶⠞⠛⠁⠀⢠⡿⠋⠉⠉⠁⠀⠀⠀⠀⢀⣼⠀
⢸⡇⠀⠀⢀⣀⣀⣿⡀⠀⠀⢸⡇⠀⠀⠀⠿⠛⠛⠲⢶⣦⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⠻⢶⣤⣤⣤⣤⣴⠾⠟⠛⠋⠀
⢸⣧⠀⠀⠈⠉⠉⠉⠛⢷⡄⢸⣇⠀⠀⠀⠀⠀⠀⠀⣠⣿⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⢿⣦⣀⠀⠀⠀⠀⠀⣸⠃⠈⠛⠛⠓⠶⠶⠶⠞⠛⠋⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⣤⣠⡈⠙⠛⠛⠶⠶⠟⠛⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
*/
//capture group A-F a-f 0-9, match quantifier 3 times, then match quantifier between 1 or 2 times
//^ $ start and end of string
using System.Text.RegularExpressions;

public class Kata{
    public bool IsHex(string hex) => Regex.IsMatch(hex , "^([A-Fa-f0-9]{3}){1,2}$");
}

//solution 2
using System.Text.RegularExpressions;

public class Kata
{
  public bool IsHex(string hex)
  {
    return Regex.IsMatch(hex, @"^(?i)([a-f\d]{3}){1,2}$");
  }
}

//****************Sample Test*****************
using NUnit.Framework;
using System;
using System.Text.RegularExpressions;

[TestFixture]
public class KataTest
{
    private Random random = new Random();

    public class Solution
    {
        public bool IsHex(string hex)
        {
            return Regex.IsMatch(hex, @"^([a-fA-F0-9]{3}){1,2}$");
        }
    }

    [Test]
    public void _0_BasicTests()
    {
        var kata = new Kata();

        Assert.AreEqual(true, kata.IsHex("ff00ff"));
        Assert.AreEqual(true, kata.IsHex("f0f"));

        Assert.AreEqual(false, kata.IsHex("ffg"));
    }

    [Test]
    public void _1_MoreTests()
    {
        var kata = new Kata();

        Assert.AreEqual(true, kata.IsHex("ff00ff"));
        Assert.AreEqual(true, kata.IsHex("f0f"));

        Assert.AreEqual(true, kata.IsHex("ff0000"));
        Assert.AreEqual(true, kata.IsHex("ff0"));
        Assert.AreEqual(true, kata.IsHex("Ff00Fb"));
        Assert.AreEqual(true, kata.IsHex("b0F"));
        Assert.AreEqual(false, kata.IsHex("b0Ff"));
        Assert.AreEqual(false, kata.IsHex("b0g"));
        Assert.AreEqual(false, kata.IsHex("ff0gf0"));
        Assert.AreEqual(false, kata.IsHex("#ff0gf0"));
        Assert.AreEqual(false, kata.IsHex("0xff0gf0"));
    }

    private string GetHex() => random.Next(0, 256).ToString("X").PadLeft(2, '0');

    [Test]
    public void _2_RandomTests()
    {
        var kata = new Kata();
        var solution = new Solution();

        for (int i = 0; i < 50; i++)
        {
            string hex = $"{GetHex()}{GetHex()}{GetHex()}";

            if (random.NextDouble() <= 0.5)
                hex = hex.Replace(hex[2], (char)random.Next(105, 123));

            if (random.NextDouble() <= 0.1)
                hex = hex.Substring(random.Next(0, 3), random.Next(2, 3));

            Assert.AreEqual(solution.IsHex(hex), kata.IsHex(hex));
        }
    }
}
