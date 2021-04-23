# ThirtyOne
---
It is an interesting game, and it is similar to Yahtzee, but it is more entertaining than Yahtzee. <br/><br/>

## Description
The game is played with six dices and it consists of ten rounds where each round consists
of three rolls. Thus, the player will be rolling the dices thirty times in total during one
game. In the first roll, the player throws all the dices. Afterward, the player can choose
which dice to roll and which dice to keep. After each round, the result will be calculated.
The total score is the total number of points that are gained in all ten rounds. As for
the rounds’ calculation, there are ten choices; 12, 11, 10, 9, 8, 7, 6, 5, 4, and Low. The
player can use an option only once during the game. The calculation for the first nine
options is based on the number of combinations corresponding to the option multiplied
by the option’s value. Low is a special option where it is calculated by adding up the dices
of less than four. <br/><br/>
Demonstration for the calculation, after one round, if the player gets the following
combination: 5, 1, 6, 2, 3, and 4, then one possibility is to choose option 6, and that will
give 18 points because the combination of the dices can form three sixes: ({ 5, 1 }, {6},
{ 2, 4 }). Another option is 8, which would give 16 points because the combination can
form two eights ({ 5, 3 }, { 6, 2 }). In terms of the Low option, the combination will give
only 6 points: (1, 2, 3). Thus, one combination can give different results. In the proposed
solution, the application will automatically choose for the player the best option available
that will give the maximum points. Thus, the player will not have to do any calculations
to choose the best option; rather, the application will carry out this task.
The application will save the scores of the players and display them when the user
starts the game. 
