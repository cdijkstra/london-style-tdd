# Bowling-outside-in-kata
This repo is meant for the bowling kata using a london-tdd-approach

## The Kata
At Fresh-Bowl, we organize a weekly bowling game. After each game, we receive a file from the bowling system and manually calculate the total scores. As you can imagine, this process is time-consuming and prone to errors. Therefore, we want to automate this process. Specifically, we aim to have a system where we can upload a game file, process it to determine the game's winner, and store individual player statistics for long-term tracking.


**Goals of the new System**
1. **Input Processing:** Accept the game file and extract player information.
2. **Score Calculation:** Calculate each player’s total score according to bowling rules.
3. **Winner Determination:** Identify the winner of the game based on scores.
4. **Data Storage:** Store each player’s game details, including the game date, score, and finishing position. If a player’s record already exists, append the new data to their file.
5. **Statistics:** WProvide end-of-year reports for players, including their average score and the number of games won.


**Game Processing Steps**

1. Extract each player's name and roll data from the input file.
2. Compute scores for each player following bowling rules.
3. Determine the winner based on the highest score.
4. Save game information for each player (e.g., game date, score, position) in their respective files.
5. Return the name of the winner. Or Draw: player1, player2

## Input File:
**FileName**:  Game_2_2024_11_15
(format:Game_x_YYYY_MM_DD)

```
Sjaak, 1,4,4,5,6,4,5,5,10,0,1,7,3,6,4,10,2,8,6
Piet,  10,1,3,8,2,10,0,0,8,0,7,2,8,1,10,10,10,6
```
Each Line starts with the players name, continuing with the pins rolled for each throw.

## Bowling Scoring Rules
1. A game consists of 10 frames, with each frame allowing a maximum of two rolls to knock down 10 pins.
2. Spare: If all 10 pins are knocked down in two rolls, the frame's score includes the 10 pins plus a bonus equal to the number of pins knocked down on the next roll.
    Example: Rolls 4,6,4 → Frame score = 10 (spare) + 4 (bonus) = 14.

3. Strike: If all 10 pins are knocked down in the first roll of a frame, the frame's score includes the 10 pins plus a bonus equal to the total of the next two rolls.
4. 10th Frame Special Rule:
    If a player scores a spare in the 10th frame, they get 1 extra roll for the bonus.
    If a player scores a strike in the 10th frame, they get 2 extra rolls for the bonus.
