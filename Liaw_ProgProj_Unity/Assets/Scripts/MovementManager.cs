/*Function of the MovementManager:
 * Handles anything dealing with making a move on the board. Handles any button input the player makes to make a choice in the game.
 * Takes values from and changes values in Deck, Player, Dice, AssetManager, ScoreManager, and BoardManager classes
 * Handles restarting and concluding the game as necessary
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovementManager : MonoBehaviour
{
    //Declaring the class scripts that will need to be called in the MovementManager
    Deck handleDeck;
    Player handlePlayer;
    Dice handleDice;
    AssetManager handleAssets;
    ScoreManager handleScore;
    Board handleBoard;

    //Declaring Button objects that the player will click on during gameplay
    public Button diceButton;
    public Button oneStepButton;
    public Button drawCardButton;
    public Button restarter;

    //boolean variable to check when the player has made a move, and two integer variables to hold the money and number of spaces to change the current values by
    bool moved;
    int moneyToChange;
    int spaceToChange;

    //Declaring a UI text object that will display the action that the player just took to the player on screen
    public UnityEngine.UI.Text actionText;
    public UnityEngine.UI.Text endGameText;
    /* FUNCTION: Start()
         * PARAMS: None
         * RETURNS: None
         * CLASS SCOPE EFFECTS: None
         * CALLED FUNCTIONS: RestartGame(), ThrowDice(), TakeAStep(), DrawCard()
         * 
         * DESCRIPTION: Initializes the script object variables to handle and call the functions of their respective scripts,
         * Initializes the button objects and call for the onClick listener to call their respective functions
         * Initalizes the moved variable to false (indicating that the player has yet to make a move)
    */
    void Start()
    {
        handleDeck = GetComponent<Deck>();
        handlePlayer = GetComponent<Player>();
        handleDice = GetComponent<Dice>();
        handleAssets = GetComponent<AssetManager>();
        handleScore = GetComponent<ScoreManager>();
        handleBoard = GetComponent<Board>();

        Button clickDice = diceButton.GetComponent<Button>();
        Button clickStep = oneStepButton.GetComponent<Button>();
        Button clickCard = drawCardButton.GetComponent<Button>();
        Button clickRestart = restarter.GetComponent<Button>();

        clickRestart.onClick.AddListener(RestartGame);
        clickDice.onClick.AddListener(ThrowDice);
        clickStep.onClick.AddListener(TakeAStep);
        clickCard.onClick.AddListener(DrawCard);

        //initialized to false in order to ensure the player cannot draw a card before taking a step or rolling the dice
        moved = false;
    }
    /* FUNCTION: TakeAStep()
         * PARAMS: None
         * RETURNS: None
         * CLASS SCOPE EFFECTS: moved, actionText
         * CALLED FUNCTIONS: ImplementAction()
         * 
         * DESCRIPTION: moves the player one space and deducts one currency unit from the player's current funds; set the actionText to display that the player has moved one step forward
    */
    public void TakeAStep()
    {
        if(moved == false)
        {
            actionText.text = "Moving one space!";
            ImplementAction(1, -1);

            moved = true; //set moved to true to indicate the player has taken their move action already and must draw a card (they cannot choose to take another step or roll a dice otherwise)
        }
    }

    /* FUNCTION: ThrowDice()
         * PARAMS: None
         * RETURNS: None
         * CLASS SCOPE EFFECTS: moved, moneyToChange, spaceToChange
         * CALLED FUNCTIONS:ImplementAction(), Dice class's Roll()
         * 
         * DESCRIPTION: Calls the Dice class's Roll function to roll a dice and get a random number between 1 and 3, and then deduct that much money and move that many spaces
         * Change the actionText to indicate that the player is rolling the dice
    */
    public void ThrowDice()
    {
        if (moved == false)
        {
            actionText.text = "Rolling the dice!!";

            //Roll the dice and get a random number between 1 and 3
            handleDice.Roll();

            //Get the dice value rolled to deduct money/move spaces and assign them to moneyToChange and spaceToChange
            moneyToChange = handleDice.GetMoneyLost();
            spaceToChange = handleDice.GetSpacesToJump();

            ImplementAction(spaceToChange, moneyToChange);

            moved = true;
        }
    }

    /* FUNCTION: DrawCard()
         * PARAMS: None
         * RETURNS: None
         * CLASS SCOPE EFFECTS: moved, moneyToChange, spaceToChange
         * CALLED FUNCTIONS:ImplementAction(), Draw class's Draw()
         * 
         * DESCRIPTION: Calls the Deck class's Draw function to draw a card from a shuffled deck, and then deduct that much money and move that many spaces according to the card's message
         * Change the actionText to display that the player is drawing a card
         * Setting the moved value to false to indicate that the player has drawn a card and can now move by rolling a dice or moving a space.
    */
    public void DrawCard()
    {
        if (moved == true)
        {
            //Changing the displayed text
            actionText.text = "Drawing a card!!";

            //calling the Deck class's Draw function
            handleDeck.Draw();

            //Setting moneyToChange and spaceToChange according to the card's message
            moneyToChange = handleDeck.ReadMoneyCost();
            spaceToChange = handleDeck.ReadActionCost();

            ImplementAction(spaceToChange, moneyToChange);

            moved = false;
        }
    }

    /* FUNCTION: ImplementAction()
        * PARAMS: spaceToChange, moneyToChange
        * RETURNS: None
        * CLASS SCOPE EFFECTS: None
        * CALLED FUNCTIONS: ScoreManager class's SetScore() and GetScore(), AssetManager class's SetCurrency() and GetCurrency(), Board class's SetSpaceNumber(), Player class's SetPosition(), EndGame() 
        * 
        * DESCRIPTION: Passes the values to be changed to their respective classes; gets the desired board location and passes it to the Player class
        * Passes the money and space to change to the AssetManager and ScoreManager respectively
        * Checks to see if the space moved to is the 10th space on the board; if so, end the game
   */
    public void ImplementAction(int spaceToChange, int moneyToChange)
    {
        //Adjust the player's current space count with ScoreManager script, then get the new current score 
        handleScore.SetScore(spaceToChange);
        int currentScore = handleScore.GetScore();
        
        //Adjust the player's current money amount with the AssetManager script, then get the new current amount of money
        handleAssets.SetCurrency(moneyToChange);
        
        //find the desired board's space position, Pass the new space to the Board class and get the desired space's x and z position
        handleBoard.SetSpaceNumber(currentScore-1);
        float newPosX = handleBoard.GetSpacePosX();
        float newPosZ = handleBoard.GetSpacePosZ();

        //Pass to the player class the board space location
        handlePlayer.SetPosition(newPosX, newPosZ);

        //check if the player has reached the final space on the board; if true, call the EndGame function
        if (currentScore == 10)
        {
            moved = false;
            EndGame();
        }

    }

    /* FUNCTION: RestartGame()
        * PARAMS: None
        * RETURNS: None
        * CLASS SCOPE EFFECTS: moved
        * CALLED FUNCTIONS: ScoreManager class's ResetScore, AssetManager class's ResetCurrency(), Board class's SetSpaceNumber(), Player class's ResetPosition()
        * 
        * DESCRIPTION: If the player chooses to restart the game, call the respective functions to reset the values: reset the score to 1, reset the currency back to 10, and place the player back on space 1
   */
    public void RestartGame()
    {
        //set moved to false
        moved = false;

        //Reset the values: Currency is set back to 10, score of the space is reset back to 1, and the first space's location is sent to the Player class to move the player back to square 1
        handleAssets.ResetCurrency();
        handleScore.ResetScore();
        handleBoard.SetSpaceNumber((handleScore.GetScore()) - 1);
        float newPosX = handleBoard.GetSpacePosX();
        float newPosZ = handleBoard.GetSpacePosZ();
        handlePlayer.ResetPosition(newPosX, newPosZ);
        
    }

    /* FUNCTION: EndGame()
        * PARAMS: None
        * RETURNS: None
        * CLASS SCOPE EFFECTS: moved
        * CALLED FUNCTIONS: actionText, Asset class's GetCurrency()
        * 
        * DESCRIPTION: If the player made it to the last space, deduct one more unit of currency as required; if the player has enough money to deduct, they win.
        * if the player has no money left to deduct, they lose.
   */
    public void EndGame()
    {
        //Get the player's current amount of currency        
        int currentMoney = handleAssets.GetCurrency();
        
        //if the player's currency is greater than 0, deduct one unit of currency and indicate the player has won
        if(currentMoney > 0)
        {
            handleAssets.SetCurrency(-1);
            endGameText.text = "Congrats! You WIN!!";
        }
        //if the player's money is 0, indicate they lose
        else if(currentMoney == 0)
        {
            endGameText.text = "Sorry! You lose!";
        }

    }
}
