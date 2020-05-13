/*Function of the ScoreManager class:
 * Handle anything dealing with getting the current 'score' of the player. For this game, score just represents space number that the player is on. 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    //Declares currentScore integer to hold the current space the player is on
    int currentScore;

    /* FUNCTION: Start()
         * PARAMS: None
         * RETURNS: integer
         * CLASS SCOPE EFFECTS: None
         * CALLED FUNCTIONS: None
         * 
         * DESCRIPTION: Initializes the currentScore variable to 1 (to indicate the player is on the first space
    */
    void Start()
    {
        currentScore = 1;
    }

    /* FUNCTION: SetScore()
         * PARAMS: int spacesToMove
         * RETURNS: None
         * CLASS SCOPE EFFECTS: None
         * CALLED FUNCTIONS: currentScore
         * 
         * DESCRIPTION: changes and sets the currentScore variable by adding the value of spacesToMove and sets the bounds of maximum and minimum space number that the player can be on
    */
    public void SetScore(int spacesToMove)
    {
        currentScore = currentScore + spacesToMove;

        //if the currentScore value after adjusting is less than one, set the value of current score to 1 (This is because there is no spaces before 1)
        if(currentScore < 1)
        {
            currentScore = 1;
        }
        
        //if the currentScore value after adjusting is greater than 10, set the value of currentScore to 10 (because this is the last space that the player can move to)
        if (currentScore > 10)
        {
            currentScore = 10;
        }
    }

    /* FUNCTION: GetScore()
         * PARAMS: None
         * RETURNS: integer
         * CLASS SCOPE EFFECTS: None
         * CALLED FUNCTIONS: None
         * 
         * DESCRIPTION: Returns the currentScore value when called
    */
    public int GetScore()
    {
        return currentScore;
    }

    /* FUNCTION: ReetScore()
         * PARAMS: None
         * RETURNS: None
         * CLASS SCOPE EFFECTS: None
         * CALLED FUNCTIONS: None
         * 
         * DESCRIPTION: Resets the player's currency to 1
    */
    public void ResetScore()
    {
        currentScore = 1;
    }
}
