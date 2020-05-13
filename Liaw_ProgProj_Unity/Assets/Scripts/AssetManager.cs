/*Function of the AssetManager class:
 * Handles the assets of the player such as currency; gets and changes the currency and displays the current amount on screen at all times
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssetManager : MonoBehaviour
{
    //Declares the UI Text object to display the current currency amount on screen; declare the integer variable currency that will hold the amount of currency the player has
    public UnityEngine.UI.Text currentCurrency;
    int currency;

    /* FUNCTION: Start()
         * PARAMS: None
         * RETURNS: None
         * CLASS SCOPE EFFECTS: None
         * CALLED FUNCTIONS: None
         * 
         * DESCRIPTION: Initializes the player's currency to 10 at the start of the game
    */
    void Start()
    {
        currency = 10;
    }

    /* FUNCTION: Update()
         * PARAMS: None
         * RETURNS: None
         * CLASS SCOPE EFFECTS: None
         * CALLED FUNCTIONS: None
         * 
         * DESCRIPTION: Displays the player's current amount of currency on screen
    */
    void Update()
    {
        //changes currentCurrency to whatever value currency is at that frame
        currentCurrency.text = "Money: " + currency.ToString();
    }

    /* FUNCTION: GetCurrency()
         * PARAMS: None
         * RETURNS: integer
         * CLASS SCOPE EFFECTS: None
         * CALLED FUNCTIONS: None
         * 
         * DESCRIPTION: Returns the currency variable's amount when called
    */
    public int GetCurrency()
    {
        return currency;
    }

    /* FUNCTION: SetCurrency()
         * PARAMS: int money
         * RETURNS: none
         * CLASS SCOPE EFFECTS: None
         * CALLED FUNCTIONS: None
         * 
         * DESCRIPTION: Changes the player's current currency by adding the value passed to it.
    */
    public void SetCurrency(int money)
    {
        //add the passed money value to the currency variable
        currency = currency + money;
        
        //if the currency is already at 0 and must still be deducted, set the currency value to 0 (there will be no negative amount of currency)
        if (currency<0)
        {
            currency = 0;
        }
    }

    /* FUNCTION: ResetCurrency()
         * PARAMS: None
         * RETURNS: none
         * CLASS SCOPE EFFECTS: None
         * CALLED FUNCTIONS: None
         * 
         * DESCRIPTION: Resets the currency variable to 10
    */
    public void ResetCurrency()
    {
        currency = 10;
    }
}
