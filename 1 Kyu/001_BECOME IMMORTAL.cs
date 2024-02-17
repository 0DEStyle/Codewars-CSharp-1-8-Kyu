/*Challenge link:https://www.codewars.com/kata/59568be9cc15b57637000054/train/csharp
Question:
In the nation of CodeWars, there lives an Elder who has lived for a long time. Some people call him the Grandpatriarch, but most people just refer to him as the Elder.

There is a secret to his longetivity: he has a lot of young worshippers, who regularly perform a ritual to ensure that the Elder stays immortal:

The worshippers line up in a magic rectangle, of dimensions m and n.
They channel their will to wish for the Elder. In this magic rectangle, any worshipper can donate time equal to the xor of the column and the row (zero-indexed) he's on, in seconds, to the Elder.
However, not every ritual goes perfectly. The donation of time from the worshippers to the Elder will experience a transmission loss l (in seconds). Also, if a specific worshipper cannot channel more than l seconds, the Elder will not be able to receive this worshipper's donation.
The estimated age of the Elder is so old it's probably bigger than the total number of atoms in the universe. However, the lazy programmers (who made a big news by inventing the Y2K bug and other related things) apparently didn't think thoroughly enough about this, and so their simple date-time system can only record time from 0 to t-1 seconds. If the elder received the total amount of time (in seconds) more than the system can store, it will be wrapped around so that the time would be between the range 0 to t-1.

Given m, n, l and t, please find the number of seconds the Elder has received, represented in the poor programmer's date-time system.

(Note: t will never be bigger than 2^32 - 1, and in JS, 2^26 - 1.)

Example:

m=8, n=5, l=1, t=100

Let's draw out the whole magic rectangle:
0 1 2 3 4 5 6 7
1 0 3 2 5 4 7 6
2 3 0 1 6 7 4 5
3 2 1 0 7 6 5 4
4 5 6 7 0 1 2 3

Applying a transmission loss of 1:
0 0 1 2 3 4 5 6
0 0 2 1 4 3 6 5
1 2 0 0 5 6 3 4
2 1 0 0 6 5 4 3
3 4 5 6 0 0 1 2

Adding up all the time gives 105 seconds.

Because the system can only store time between 0 to 99 seconds, the first 100 seconds of time will be lost, giving the answer of 5.
This is no ordinary magic (the Elder's life is at stake), so you need to care about performance. All test cases (900 tests) can be passed within 1 second, but naive solutions will time out easily. Good luck, and do not displease the Elder.
*/

//***************Solution********************
/*

⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣠⡤⠶⠖⠛⠋⠉⠉⠉⠙⠓⠶⢦⣀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣀⡴⠞⠋⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠉⠳⣄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣤⠞⠋⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠐⡄⠈⢷⡀⠀⢀⡤⠖⠦⣄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣤⠟⡟⠀⠀⠀⠀⠀⠀⢠⠖⠛⠒⠲⢤⣄⠀⠀⠀⠀⢀⣤⠼⠦⢤⡟⠙⠋⠀⠀⠀⢸⡆⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⣠⠖⣺⠃⡼⠀⠒⣛⣉⣁⡀⠀⠈⠉⠉⠉⠛⠛⠛⠛⠀⠀⢀⡟⠀⠀⠀⠈⠀⠀⠀⢠⡴⠞⠛⣙⠳⣆⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⣸⢡⠞⠁⠠⠗⠋⠉⠁⠀⠀⠀⣀⣀⣤⣤⡤⠶⣶⣲⠿⠿⢷⡼⠧⢤⠤⠶⠒⠒⣶⡾⠋⠀⠀⠀⠈⢣⢸⡆⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⣹⠏⣀⡀⠰⠀⠀⠀⣴⠶⠚⢯⣍⣛⣋⡤⠭⠷⠖⡒⣦⠀⠈⣇⣁⣀⣀⡤⠤⠤⡾⠁⣠⠖⠋⠻⡆⠘⢸⡇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⢀⣀⣠⠤⢶⣶⣖⠒⠋⢭⠍⠙⡷⡾⠭⠽⠇⠀⢸⠉⠉⠁⢀⣤⠖⠐⡤⢈⠸⡄⠀⣿⠩⣇⣀⠁⠀⣼⠃⢰⡿⢶⡄⡰⠃⢀⡾⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⡞⠉⢀⡭⠷⠖⠒⠋⠉⠉⠙⣆⠀⠀⢀⣀⠀⠀⠸⡇⠀⠀⣿⣿⣄⣠⣿⠀⠀⡇⠀⣿⠀⣽⠋⠀⠊⡼⠀⠘⠁⢠⡏⠁⢠⡾⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀<----  me after solving this problem
⢧⠀⢸⡀⠀⠀⢀⣴⡎⠀⣇⢹⣤⠾⠋⠉⠻⣶⣄⢻⡄⠀⠹⢿⣿⠿⠟⠀⠀⡇⠀⣿⠀⠘⠶⠶⠞⠁⠀⠀⠈⢉⣠⡾⠋⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀   Elder literally took time off my life lol.
⠸⣶⡌⣇⠀⠀⠸⣿⣿⣾⣿⠟⠁⠀⠀⠀⠀⠈⢻⣷⡙⢦⣀⣉⣀⣠⣤⠤⠞⠁⣠⡏⠀⠀⠀⠀⠀⡄⠀⠀⠀⣸⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⢹⣷⡈⢧⡀⠀⠿⢻⡿⠁⠀⠀⠀⠀⠀⠀⠀⠀⠙⢿⣷⣶⣴⣶⣶⣾⠿⠗⠛⠋⠀⠀⠀⠀⠀⠀⠙⢦⣠⣴⠏⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠹⣷⣄⣓⣒⣲⡟⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⠤⣀⡀⢀⣀⣀⠀⣄⡀⠀⠀⠀⠀⠀⠀⠀⢻⡄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠈⠛⠛⠛⣿⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣀⠤⠊⣱⠞⠙⠋⠉⠁⠉⠙⢻⡉⠀⠀⠀⠀⢀⠀⠀⠘⣧⠀⠀⠀⠀⠀⠀⢀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⢿⡧⡀⠀⠀⠀⠀⠀⣀⠠⠔⠊⣁⣤⠶⠃⠀⠀⠀⠀⣀⣀⣤⠞⠁⠀⠀⣠⣴⡏⠀⠀⠀⢹⠙⢶⡶⠶⠖⠛⠉⠙⠳⢦⣀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠈⢷⣌⡁⠀⠀⠀⢉⣀⣠⠴⠞⠋⠀⡆⢀⡀⢘⠘⢻⡝⠋⠀⠀⣀⣴⣾⠟⠁⢇⣀⠀⣰⠏⠀⠈⢧⠀⠀⠀⠀⠀⠀⠀⠉⠛⠶⣤⣀⡀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⠉⠛⠛⠛⠉⠙⠧⠴⣄⣀⣠⣉⣰⡶⠶⡶⠾⠃⣀⢴⣮⠷⠋⣽⠓⠶⣤⡴⠞⠁⠀⠀⠀⠸⡇⠀⣀⡀⠀⠀⠀⠀⠀⠀⠀⠉⠙⠳⠶⢦⣄⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⠉⠁⠹⣏⠀⠀⢁⣀⣽⠾⠋⠁⢀⣴⠏⣀⡴⠊⢉⣉⣉⠙⠿⣲⢦⣷⠀⠈⠙⢶⣦⣤⣀⡀⠀⠀⠀⠀⠀⠀⠀⢹⡇⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⠛⠛⠋⠁⠀⠀⠀⠀⣾⣾⡾⢋⠀⡄⢯⡀⣸⠇⠀⠈⠓⠝⠀⠀⠀⠀⠻⣄⠉⠉⠛⠛⡖⠒⠂⠀⠀⠀⡇⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⡿⠉⠀⠀⣆⢹⠀⠉⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠘⣷⠀⠀⠀⡿⠀⠀⠀⠀⠀⡇⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸⢃⢀⠀⠀⢸⡀⡇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⢷⡀⢀⡇⠀⠀⠀⠀⢸⡇⠀⠀⠀
⠀⠀⠀⠀⠀⠀⢀⣠⣄⣀⣀⣀⣀⣀⣀⣀⣀⣀⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⡿⠇⠀⠀⠀⣸⣧⠸⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⢷⣸⠃⠀⠀⠀⠀⣼⠁⠀⠀⠀
⠀⠀⠀⠀⠀⣠⡞⠙⠤⣤⣯⡴⢛⣉⡭⠽⠉⠉⠉⠛⠳⠶⣦⣤⣤⣀⣀⣀⣀⣾⢁⠀⠀⠀⠀⡿⣿⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⣿⠀⠀⠀⠀⢰⡇⠀⠀⠀⠀
⠀⠀⠀⠀⠀⢿⡀⠀⢸⢹⡏⢰⡏⣁⣀⡀⠀⠀⣤⣀⣀⡀⠈⠹⣆⠀⠈⠉⠉⠛⠒⠀⠀⠀⣼⠃⢸⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠘⣯⠉⡟⠲⣟⡀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠘⣇⣀⣼⡄⣿⢸⡇⠀⠀⠀⢀⡞⠁⢠⠊⠙⣷⡄⡽⠀⠀⠀⠀⠀⠀⠀⠰⣠⠏⠀⢸⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢹⠀⠸⠀⠈⢳⣤⣦⡀⠀
⠀⠀⠀⠀⠀⠀⢉⡟⠘⢧⣿⡀⡇⠀⠀⠀⢸⡇⣦⢸⠠⠇⠈⣷⣧⣤⣤⣤⣄⣀⣀⣀⣠⠟⠀⠀⣾⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣼⡄⠀⢧⠀⠘⡇⠘⢧⡀
⠀⠀⠀⠀⠀⠀⡾⢣⠀⠀⣩⠟⣧⣀⠀⠀⣸⣿⢻⡈⢇⠀⢠⢻⡇⠀⠀⠀⠀⠈⠉⠉⠁⠀⠀⠀⡿⠀⠰⣄⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⡤⠀⢀⣼⠋⠙⣦⡈⢆⢸⣧⣀⢈⣿
⠀⠀⠀⠀⠀⢸⠃⠀⠓⢰⠏⠀⢸⠉⠉⠉⢹⡿⡌⢇⠀⠉⠁⢸⠇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣧⠀⢠⡀⠀⠉⠉⠉⠉⠉⣁⡤⠤⠒⠉⣀⡴⠟⠁⠀⢀⡘⣷⠈⢯⣀⣴⠋⠁
⠀⠀⠀⠀⠀⣿⠀⡔⠳⡿⠀⠀⠘⠧⠴⠖⠚⢧⡑⢬⣑⣶⣷⠏⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠙⠳⣦⣌⣀⠀⠀⠀⠀⠀⣀⣀⣤⣴⡿⠋⠀⠀⠀⠀⠀⠃⢹⣦⣀⡾⠁⠀⠀
⠀⠀⠀⠀⠀⡟⠀⠃⢰⠇⠀⠀⠀⠀⠀⠀⠀⠀⠙⠓⠚⠋⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢠⡇⠀⠉⠉⠛⠛⠛⠉⠉⠕⠋⠁⠀⠀⠀⠀⠀⠀⠀⠀⢸⠃⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⣇⠀⠀⢸⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣴⠟⠀⡠⠂⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠆⣿⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⣿⡀⠀⢸⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣰⠟⠁⢠⠞⠀⠀⢸⠲⠤⠀⠀⠠⢶⢺⠁⠀⠀⠀⠀⠀⠀⠜⣰⠇⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⣿⡇⡆⢸⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⡾⠃⠀⣴⣁⣀⡀⠤⠈⡟⠶⣄⣀⣠⡏⡌⠀⠀⠀⠀⠀⠀⠀⢀⡟⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⢻⣷⡇⢸⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣴⠏⠀⠀⡴⠃⠀⠀⠀⠤⠚⢹⣤⠞⠁⣹⠃⡇⠀⠀⠀⠀⠀⠀⠀⡾⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⢸⣼⢳⢸⡄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣼⠋⠀⢀⠞⠀⠀⠀⠀⠀⢀⡴⠋⠁⠀⢀⡟⠀⡇⠀⠀⠀⠀⠀⠀⣼⠁⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠈⣿⡾⡈⡇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣸⠃⠀⠀⡏⠀⠀⠀⠀⢀⡴⠋⠀⠀⠀⠀⢸⡇⠀⢱⠀⠀⠀⠀⠀⠀⡏⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⣿⢷⠀⣷⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠙⢦⡄⠀⠳⠀⠀⠀⠀⢺⡅⠀⠀⠀⠀⠀⠈⢷⣄⣨⣆⠀⠀⠀⠀⡀⣿⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⢸⡼⡀⢻⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠻⣆⠀⢳⠀⠀⡀⠈⢷⡀⠀⠀⠀⠀⠀⠀⠘⣧⠘⡄⠀⠀⠀⠱⢿⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⣷⢧⠸⡆⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⢷⡀⠳⡀⠱⡀⠘⣧⠀⠀⠀⠀⠀⠀⠀⠘⢧⠹⡀⠀⠀⠀⠸⣇⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⢹⡘⡀⣷⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠻⣆⠱⡄⠱⠀⠸⣇⠀⠀⠀⠀⠀⠀⠀⠈⢷⠱⡀⢠⠀⠀⢿⡀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⣧⢳⠸⡄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣼⢓⠼⠦⠀⠀⢹⡆⠀⠀⠀⠀⠀⠀⠀⠈⢷⠱⡀⠳⠀⠈⣧⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠹⣜⡄⢷⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣀⣠⣤⣤⡤⠤⠶⠖⠚⠛⠛⢳⣄⣀⣀⣠⣿⠀⠀⠀⠀⠀⠀⠀⢠⠞⣴⢧⡤⠄⠀⠘⣆⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⢿⣿⠘⣆⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣼⠋⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸⡇⠀⠀⠀⠀⣀⣤⡼⡛⠉⠉⠻⣦⡤⠖⠻⣦⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠘⣿⣿⢿⡄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢻⣖⢤⣀⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣀⡤⢔⣫⡿⣡⣤⠴⠚⠛⠉⠀⠋⠀⠐⠀⠀⠀⠀⠀⠀⣹⡆⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠹⣄⣀⡷⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠙⠳⢦⣍⣙⡛⠒⠒⠒⠒⢚⣋⣭⡴⠞⠛⠁⣼⠋⠀⢀⠄⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⡤⣮⡟⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⠉⠉⠉⠛⠛⠉⠉⠉⠀⠀⠀⠀⠀⢻⡝⠦⣄⣑⡀⠀⠀⠀⢀⣀⣠⣴⣞⣩⣾⣋⣀⣀⣀⣀⣀⣀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠙⠷⣦⣌⣉⣉⣉⣉⣉⣥⢾⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿
*/

/* Jank notes

ref: https://blog.valerauko.net/2018/02/11/munching-the-squares-of-immortality/
XOR magic square is in "Munching Squares" pattern: https://mathworld.wolfram.com/MunchingSquares.html

Pattern visualisation
n:31, m:31, l:1, t:100
row0:  0  1  2  3  4  5  6  7  8  9  10 11 12 13 14 15 16 17 18 19 20 21 22 23 24 25 26 27 28 29 30 
row1:  1  0  3  2  5  4  7  6  9  8  11 10 13 12 15 14 17 16 19 18 21 20 23 22 25 24 27 26 29 28 31 
row2:  2  3  0  1  6  7  4  5  10 11 8  9  14 15 12 13 18 19 16 17 22 23 20 21 26 27 24 25 30 31 28 
row3:  3  2  1  0  7  6  5  4  11 10 9  8  15 14 13 12 19 18 17 16 23 22 21 20 27 26 25 24 31 30 29 
row4:  4  5  6  7  0  1  2  3  12 13 14 15 8  9  10 11 20 21 22 23 16 17 18 19 28 29 30 31 24 25 26 
row5:  5  4  7  6  1  0  3  2  13 12 15 14 9  8  11 10 21 20 23 22 17 16 19 18 29 28 31 30 25 24 27 
row6:  6  7  4  5  2  3  0  1  14 15 12 13 10 11 8  9  22 23 20 21 18 19 16 17 30 31 28 29 26 27 24 
row7:  7  6  5  4  3  2  1  0  15 14 13 12 11 10 9  8  23 22 21 20 19 18 17 16 31 30 29 28 27 26 25 
row8:  8  9  10 11 12 13 14 15 0  1  2  3  4  5  6  7  24 25 26 27 28 29 30 31 16 17 18 19 20 21 22 
row9:  9  8  11 10 13 12 15 14 1  0  3  2  5  4  7  6  25 24 27 26 29 28 31 30 17 16 19 18 21 20 23 
row10: 10 11 8  9  14 15 12 13 2  3  0  1  6  7  4  5  26 27 24 25 30 31 28 29 18 19 16 17 22 23 20 
row11: 11 10 9  8  15 14 13 12 3  2  1  0  7  6  5  4  27 26 25 24 31 30 29 28 19 18 17 16 23 22 21 
row12: 12 13 14 15 8  9  10 11 4  5  6  7  0  1  2  3  28 29 30 31 24 25 26 27 20 21 22 23 16 17 18 
row13: 13 12 15 14 9  8  11 10 5  4  7  6  1  0  3  2  29 28 31 30 25 24 27 26 21 20 23 22 17 16 19 
row14: 14 15 12 13 10 11 8  9  6  7  4  5  2  3  0  1  30 31 28 29 26 27 24 25 22 23 20 21 18 19 16 
row15: 15 14 13 12 11 10 9  8  7  6  5  4  3  2  1  0  31 30 29 28 27 26 25 24 23 22 21 20 19 18 17 
row16: 16 17 18 19 20 21 22 23 24 25 26 27 28 29 30 31 0  1  2  3  4  5  6  7  8  9  10 11 12 13 14 
row17: 17 16 19 18 21 20 23 22 25 24 27 26 29 28 31 30 1  0  3  2  5  4  7  6  9  8  11 10 13 12 15 
row18: 18 19 16 17 22 23 20 21 26 27 24 25 30 31 28 29 2  3  0  1  6  7  4  5  10 11 8  9  14 15 12 
row19: 19 18 17 16 23 22 21 20 27 26 25 24 31 30 29 28 3  2  1  0  7  6  5  4  11 10 9  8  15 14 13 
row20: 20 21 22 23 16 17 18 19 28 29 30 31 24 25 26 27 4  5  6  7  0  1  2  3  12 13 14 15 8  9  10 
row21: 21 20 23 22 17 16 19 18 29 28 31 30 25 24 27 26 5  4  7  6  1  0  3  2  13 12 15 14 9  8  11 
row22: 22 23 20 21 18 19 16 17 30 31 28 29 26 27 24 25 6  7  4  5  2  3  0  1  14 15 12 13 10 11 8  
row23: 23 22 21 20 19 18 17 16 31 30 29 28 27 26 25 24 7  6  5  4  3  2  1  0  15 14 13 12 11 10 9  
row24: 24 25 26 27 28 29 30 31 16 17 18 19 20 21 22 23 8  9  10 11 12 13 14 15 0  1  2  3  4  5  6  
row25: 25 24 27 26 29 28 31 30 17 16 19 18 21 20 23 22 9  8  11 10 13 12 15 14 1  0  3  2  5  4  7  
row26: 26 27 24 25 30 31 28 29 18 19 16 17 22 23 20 21 10 11 8  9  14 15 12 13 2  3  0  1  6  7  4  
row27: 27 26 25 24 31 30 29 28 19 18 17 16 23 22 21 20 11 10 9  8  15 14 13 12 3  2  1  0  7  6  5  
row28: 28 29 30 31 24 25 26 27 20 21 22 23 16 17 18 19 12 13 14 15 8  9  10 11 4  5  6  7  0  1  2  
row29: 29 28 31 30 25 24 27 26 21 20 23 22 17 16 19 18 13 12 15 14 9  8  11 10 5  4  7  6  1  0  3  
row30: 30 31 28 29 26 27 24 25 22 23 20 21 18 19 16 17 14 15 12 13 10 11 8  9  6  7  4  5  2  3  0  

tansmmission loss can't get lower than 0

Because the system can only store time between 0 to 99 seconds, the first 100 seconds of time will be lost, giving the answer of 5.
if result > 99 ? 105 - 100 = 5 or result % 100

*/
using System;
using System.Numerics;
  
public static class Immortal{
	//set true to enable debug
	public static bool Debug = false;
  
  
  //for printing out info, disable in main if not needed
  public static void infoPrint(long n, long m, long l, long t){
    Console.WriteLine($"n:{n}, m:{m}, l:{l}, t:{t}");
    
    //to create magic rectangle, xor row and column, format only works for 2 digits
    for(long i = 0; i < n; i++){
      Console.WriteLine();
      if(i < 10) Console.Write($"row{i}:  ");
      else Console.Write($"row{i}: ");
      
      for(long j = 0; j < m; j++){
        long xorVal = i^j;
        
        if(xorVal < 10) Console.Write(xorVal +"  ");
        else Console.Write(xorVal +" ");
      }
    }
  }
  
  
  //helper function with BigInteger
  public static BigInteger findRangeSum(long n1, long n2) => ((BigInteger)(n1 + n2)) * (n2 - n1 + 1) / 2;
  //find reminder for sum by moding time t 
  public static long findRem(BigInteger sum, long t) => (long)(sum % t);
  
  
	public static long ElderAge(long n, long m, long l, long t){
    //info printer: number can get big, so disable by comment out this part!
    //infoPrint(n,m,l,t); 
    
    //check empty, also to stop recursion
    if(n < 1 || m < 1) return 0;
    
    //make rectangle horizontal, because rectangle is not necessarily a square
    //if m is greater than n, swap no jutsu, 
    //now m will always greater than n, which makes it easier to perform condition
    if (m > n) (n, m) = (m, n);
    
    //https://learn.microsoft.com/en-us/dotnet/api/system.numerics.bitoperations.rounduptopowerof2?view=net-6.0
    //round up to closest power of 2
    var nPowerOf2 = (long)BitOperations.RoundUpToPowerOf2((ulong)n);
    var mPowerOf2 = (long)BitOperations.RoundUpToPowerOf2((ulong)m);
    //Console.WriteLine($"{nPowerOf2},{mPowerOf2}");
    if(nPowerOf2 <= l) return 0;
    
    //if both n and m power of 2 are equal
    //accumulate sum recursively
    if(nPowerOf2 == mPowerOf2){
      var ans1 = findRem(  findRangeSum(1, nPowerOf2 - l - 1)   *   (n + m - nPowerOf2), t);
      var ans2 = ElderAge(nPowerOf2 - n, mPowerOf2 - m, l, t);
      return (ans1 + ans2) % t;
    }
    
    //if not n or m power of 2 are not equal
    //accumulate sum recursively
    mPowerOf2 = nPowerOf2 / 2;
    var res1 = findRem(findRangeSum(1, nPowerOf2 - l - 1) * m - (nPowerOf2 - n)    *   findRangeSum(Math.Max(0, mPowerOf2 - l), nPowerOf2 - l - 1), t);
    var res2 = l;
    
    if(res1 < 0) res1 += t;
    if(res2 <= mPowerOf2)
      res2 = findRem((BigInteger)(mPowerOf2 - l) * (mPowerOf2 - m) * (nPowerOf2 - n), t)    +    ElderAge(mPowerOf2 - m, nPowerOf2 - n, 0, t);
    else
      res2 = ElderAge(mPowerOf2 - m, nPowerOf2 - n, l - mPowerOf2, t);
    return (res1 + res2) % t; 
      
	}
}


//Shorter solution
using System;
using System.Numerics;

public static class Immortal
{
	/// set true to enable debug
	public static bool Debug = false;

	public static long ElderAge(BigInteger m, BigInteger y, BigInteger l, BigInteger t)
  {
      BigInteger T = 0;

      while (y > 0)
      {
          var Y = y;
          var x = m;
          y &= y - 1;
          while (x > 0)
          {
              var X = x;
              x &= x - 1;
              var S = BigInteger.Max(X - x, Y - y);
              var s = BigInteger.Min(X - x, Y - y);
              var h = BigInteger.Max((x ^ y | S - 1) + 1 - l, 0);
              var w = BigInteger.Min(h, S);
              T += s * w * (h + h - w - 1) / 2;
          }
      }

      return (long)(T % t);
  }
}

//no BigInteger solution
using System;

public static class Immortal
{
	/// set true to enable debug
	public const bool Debug = true;

	public static long ElderAge(long m, long n, long l, long t)
	{
		long small = Math.Min(m, n);
	  long big = Math.Max(m, n);
	  long power = (long) Math.Pow(2, Math.Floor(Math.Log(big, 2)));
	  long rows = Math.Min(power, small);
	  long first = Math.Max(0, -l);
	  long terms = Math.Max(0, power - l - 1);
		long x = (terms - first + 1);
		long y = first + terms;

		if (x % 2 > 0) y = (long) Math.Floor((double) (y / 2));
		else if (y % 2 > 0) x = (long) Math.Floor((double) (x / 2));

		long series = y <= 0 ? 0 : ((y % t) * (x % t)) % t;

		long sum = (((series % t) * (rows % t)) % t)
	    + (big > power ? ElderAge(big - power, rows, l - power, t) : 0)
	    + (small > rows ? ElderAge(power, small - rows, l - rows, t) : 0)
	    + (small > rows && big > power ? ElderAge(big - power, small - rows, l, t) : 0);
      
	  return sum % t;
	}
}
//****************Sample Test*****************
using System;
using NUnit.Framework;

[TestFixture]
public class ImmortalTest
{
	private static long _date = DateTime.Now.Millisecond;
	private static long _passed;
	private static bool _good = true;
	private readonly Random _random = new Random(DateTime.Now.Millisecond);
  
  private static long _p = (int) 1e9;

	private static int Log2(long x)
	{
		var ans = 0;
		while ((x >>= 1) != 0) ans++;
		return ans;
	}

	private static long Mul(long x, long y, long z)
	{
		if (z != 2) return x % _p * (y % _p) % _p;
		if ((x & 1) != 0) y >>= 1;
		else if ((y & 1) != 0) x >>= 1;
		else throw new Exception("shit");
		return x % _p * (y % _p) % _p;
	}

	private static long SumTimes(long first, long n, long k, long t)
	{
		first -= k;
		if (first >= 1) return n <= 0 ? 0 : Mul(Mul(first + first + n - 1, n, 2L), t, 1);
		n -= 1 - first;
		first = 1;
		return n <= 0 ? 0 : Mul(Mul(first + first + n - 1, n, 2L), t, 1);
	}

	private static long SolElderAge(long n, long m, long k, long newp)
	{
		if (n == 0 || m == 0) return 0;
		if (k < 0) k = 0;
		if (n < m)
		{
			var tmp = n;
			n = m;
			m = tmp;
		}
		_p = newp;
		if (n == m && (n & -n) == n) return SumTimes(1, n - 1, k, m);
		int nn = Log2(n), mm = Log2(m);
		long centerWidth = 1L << nn, centerHeight = 1L << mm;
		if (nn == mm)
		{
			long rightWidth = n - centerWidth, bottomHeight = m - centerHeight;
			var bottomSum = SumTimes(centerHeight, centerWidth, k, bottomHeight);
			return ((SumTimes(centerWidth, centerHeight, k, rightWidth) + bottomSum) % _p +
			        (SolElderAge(rightWidth, bottomHeight, k, _p) + SolElderAge(centerWidth, centerHeight, k, _p)) % _p) % _p;
		}
		var leftWidth = 1L << nn;
		var leftSum = SumTimes(0, leftWidth, k, m);
		var rightSum = SolElderAge(n - leftWidth, m, k - leftWidth, _p);
		if (leftWidth <= k) return (leftSum + rightSum) % _p;
		rightSum += Mul(Mul(leftWidth - k, m, 1), n - leftWidth, 1);
		rightSum %= _p;
		return (leftSum + rightSum) % _p;
	}
  
  
	[Test]
	public void A_Example()
	{
		Assert.AreEqual((long) 5, Immortal.ElderAge(8, 5, 1, 100));
		Assert.AreEqual((long) 224, Immortal.ElderAge(8, 8, 0, 100007));
		Assert.AreEqual((long) 11925, Immortal.ElderAge(25, 31, 0, 100007));
		Assert.AreEqual((long) 4323, Immortal.ElderAge(5, 45, 3, 1000007));
		Assert.AreEqual((long) 1586, Immortal.ElderAge(31, 39, 7, 2345));
		Assert.AreEqual((long) 808451, Immortal.ElderAge(545, 435, 342, 1000007));
		// You need to run this test very quickly before attempting the actual tests :)
		Assert.AreEqual((long) 5456283, Immortal.ElderAge(28827050410L, 35165045587L, 7109602, 13719506));
	}

	[Test]
	public void B_TheElderIsInterested()
	{
		Console.WriteLine(
			"<p><font color=\"green\">100 test cases\\nm,n: 2^5 - 2^10\\nl: 0 - 19\\nt: 2^5 - 2^15</font></p>");
		Console.WriteLine("Young man, you should learn a thing or two...");
		for (var i = 0; i < 100; i++)
		{
		if(!_good) return;
			long m = (long) Math.Floor(Math.Pow(2, _random.NextDouble() * 5 + 5)),
				n = (long) Math.Floor(Math.Pow(2, _random.NextDouble() * 5 + 5)),
				l = (long) (_random.NextDouble() * 20),
				t = (long) Math.Floor(Math.Pow(2, _random.NextDouble() * 10 + 5));
			long expected = SolElderAge(m, n, l, t), actual = Immortal.ElderAge(m, n, l, t);
			if (expected != actual)
			{
				_good = false;
        #pragma warning disable 0162
				if (Immortal.Debug)
					Console.WriteLine("The Elder says: \\n<p><font color=\"yellow\">m=" + m + ", n=" + n + ", l=" + l + ", t=" + t +
					                  "</font></p>");
        #pragma warning restore 0162
			}
			else _passed++;
			Assert.AreEqual(expected, actual);
		}
	}

	[Test]
	public void C_TheElderIsExcited()
	{
		if(!_good) return;
		Console.WriteLine(
			"<p><font color=\"yellow\">300 test cases\\nm,n: 2^8 - 2^20\\nl: 0 - 9999\\nt: 2^10 - 2^20</font></p>");
		Console.WriteLine("You're too young and too simple!");
		for (int i = 0; i < 300; i++)
		{
			long m = (long) Math.Floor(Math.Pow(2, _random.NextDouble() * 12 + 8)),
				n = (long) Math.Floor(Math.Pow(2, _random.NextDouble() * 12 + 8)),
				l = (long) (_random.NextDouble() * 10000),
				t = (long) Math.Floor(Math.Pow(2, _random.NextDouble() * 10 + 10));
			long expected = SolElderAge(m, n, l, t), actual = Immortal.ElderAge(m, n, l, t);
			if (expected != actual)
			{
				_good = false;
        #pragma warning disable 0162
				if (Immortal.Debug)
					Console.WriteLine("The Elder says: \\n<p><font color=\"yellow\">m=" + m + ", n=" + n + ", l=" + l + ", t=" + t +
					                  "</font></p>");
        #pragma warning restore 0162
			}
			else _passed++;
			Assert.AreEqual(expected, actual);
		}
	}

	[Test]
	public void D_TheElderIsAngry()
	{
		if(!_good) return;
    Console.WriteLine(
			"<p><font color=\"red\">500 test cases\\nm,n: 2^32 - 2^48\\nl: 0 - 9999999\\nt: 2^16 - 2^26</font></p>");
		Console.WriteLine("And sometimes naive!");
		for (int i = 0; i < 500; i++)
		{
			long m = (long) Math.Floor(Math.Pow(2, _random.NextDouble() * 16 + 32)),
				n = (long) Math.Floor(Math.Pow(2, _random.NextDouble() * 16 + 32)),
				l = (long) (_random.NextDouble() * 1e7),
				t = (long) Math.Floor(Math.Pow(2, _random.NextDouble() * 10 + 16));
			long expected = SolElderAge(m, n, l, t), actual = Immortal.ElderAge(m, n, l, t);
			if (expected != actual)
			{
				_good = false;
        #pragma warning disable 0162
				if (Immortal.Debug)
					Console.WriteLine("The Elder says: \\n<p><font color=\"yellow\">m=" + m + ", n=" + n + ", l=" + l + ", t=" + t +
					                  "</font></p>");
        #pragma warning restore 0162
			}
			else _passed++;
			Assert.AreEqual(expected, actual);
		}
	}

	[OneTimeTearDown]
	public static void End()
	{
		long end = DateTime.Now.Millisecond;
		var timeDiff = (_date - end) / 1000;
		if (_passed >= 900)
		{
			Console.WriteLine("You spent.. " + timeDiff + "ms");
			Console.WriteLine(timeDiff <= 1
				? "You finished all the tests within 1 second. The Elder is very happy! +1s"
				: "The Elder is pleased!");
		}
		else
		{
			Console.WriteLine("The Elder is displeased!");
			Assert.Fail();
		}
	}
}
