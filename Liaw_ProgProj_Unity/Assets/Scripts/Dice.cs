/*Function of the Dice class:
 * handles anything dealing with the dice functionality such as setting the number of sides on the dice and reading the dice number rolled
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dice : MonoBehaviour
{
    //Declare variables to hold the number of sides the dice has and the number that gets rolled. 
    int diceSides;
    int rolledNumber;

    //Declares a UI text object to display the number rolled on the dice
    public UnityEngine.UI.Text rolledDice;

    /* FUNCTION: Start()
         * PARAMS: None
         * RETURNS: None
         * CLASS SCOPE EFFECTS: None
         * CALLED FUNCTIONS: None
         * 
         * DESCRIPTION: Initializes the number of sides on the dice
    */
    void Start()
    {
        //initialize diceSides to 3 as this game only requires a 3 sided dice
        diceSides = 3;
    }

    /* FUNCTION: Roll()
         * PARAMS: None
         * RETURNS: None
         * CLASS SCOPE EFFECTS: None
         * CALLED FUNCTIONS: None
         * 
         * DESCRIPTION: Uses the Random class to get a random number between 1 and the number of sides on the dice. Display on screen the number rolled
    */
    public void Roll()
    {
        //diceSides + 1 is used to make sure all sides of the dice are inclusive (max number is exclusive)
        //sets the value of rolledNumber
        rolledNumber = Random.Range(1, diceSides + 1);
        rolledDice.text = "Rolled a " + rolledNumber.ToString();
    }

    /* FUNCTION: GetMoneyLost()
         * PARAMS: None
         * RETURNS: integer
         * CLASS SCOPE EFFECTS: None
         * CALLED FUNCTIONS: None
         * 
         * DESCRIPTION: returns the value held in rolledNumber
    */
    public int GetMoneyLost()
    {
        //returns negative because the money will be only be deducted when the dice is rolled
        return (-1*rolledNumber);
    }

    /* FUNCTION: GetSpacesToJump()
         * PARAMS: None
         * RETURNS: integer
         * CLASS SCOPE EFFECTS: None
         * CALLED FUNCTIONS: None
         * 
         * DESCRIPTION: returns the value held in rolledNumber
    */
    public int GetSpacesToJump()
    {
        return rolledNumber;
    }

    
}
