/*Function of the Deck class:
 * Handles any functionality dealing with the deck such as creating the deck of cards, shuffling the cards, drawing a card, and reading the card's actions
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Deck : MonoBehaviour
{
    //Function of the Card class: Create instances of each card that can be drawn from the 'deck'
    public class Card
    {
        //declare message variable that will hold the message to be displayed on screen,
        //actionCost that will have the value to move the player with, 
        //currency cost will hold the value to be added/taken from the player's currency
        public string message;
        public int actionCost;
        public int currencyCost;

        //declare and initialize the drawn variable value to false
        public bool drawn = false;

        //Constructor for the card class that takes a string and two integers to assign to each individual card created
        public Card(string cardMessage, int action, int currency)
        {
            message = cardMessage;
            actionCost = action;
            currencyCost = currency;
        }
    }

    //declare the two arrays of the Card class; playingCards will be the master deck of the cards in order and shuffleCards will handle the cards post shuffling
    static Card[] playingCards = new Card[10];
    static Card[] shuffledCards = new Card[10];

    //Declare drawnMoneyCost and drawnActionCost to hold the values of the money to be added/deducted and the number of spaces to move the player by
    static int drawnMoneyCost;
    static int drawnActionCost;

    //declare a variable cardsDrawn and initalize to 0; this will handle tracking the index of the shuffled card array through the game
    static int cardsDrawn = 0;

    //Declare the UnityEngine.UI.Text called cardAction that will have the corresponding text object attached to it to display card messages on screen for the player
    public UnityEngine.UI.Text cardAction;

    /* FUNCTION: Start()
        * PARAMS: None
        * RETURNS: None
        * CLASS SCOPE EFFECTS: playingCards array
        * CALLED FUNCTIONS: None
        * 
        * DESCRIPTION: initializes the playingCards master deck with 10 Card objects
    */
    void Start()
    {
        //creating 10 card objects and adding them to the master deck array 'playingCards'
        playingCards[0] = new Card("Move back 1, money +2 ", -1, 2);
        playingCards[1] = new Card("Move back 1, money +1 ", -1, 1);
        playingCards[2] = new Card("Move back 2, money +3 ", -2, 3);
        playingCards[3] = new Card("Move forward 2, money -3", 2, -3);
        playingCards[4] = new Card("Move forward 1, money -2 ", 1, -2);
        playingCards[5] = new Card("Move forward 1, money -1", 1, -1);
        playingCards[6] = new Card("Move back 2, money -1", -2, -1);
        playingCards[7] = new Card("Move back 1, money -2 ", -2, -1);
        playingCards[8] = new Card("Move up 1, money +2", 1, 2);
        playingCards[9] = new Card("Move up 2, money +1", 2, 1);

    }

    /* FUNCTION: Draw()
        * PARAMS: None
        * RETURNS: None
        * CLASS SCOPE EFFECTS: None
        * CALLED FUNCTIONS: Shuffle()
        * 
        * DESCRIPTION: First shuffles the master deck playingCards array as needed. 
        * Then, when the function is called, take the first available card (determined by the cardsDrawn variable) and record the money and action costs listed on the card drawn
    */
    public void Draw()
    {
        //First shuffle the playingCards array if the cardsDrawn variable is 0
        if (cardsDrawn == 0)
        {
            Shuffle();
        }

        //Draw the 'first' card on the top of the deck (based on the cardsDrawn variable), starting from the top of the card and get the money and action of the card and set accordingly
        drawnMoneyCost = shuffledCards[cardsDrawn].currencyCost;
        drawnActionCost = shuffledCards[cardsDrawn].actionCost;

        //display the card's message of money and action costs
        cardAction.text = shuffledCards[cardsDrawn].message;

        //increment cardsDrawn to move down the array and draw the next card the next time Draw() is called
        cardsDrawn++;

        //check if cardsDrawn has reached the 'bottom' of the deck/has drawn the last element in the shuffledCards array and reset back to 0 so the deck can be shuffled again
        if(cardsDrawn == 10)
        {
            cardsDrawn = 0;
        }
    }

    /* FUNCTION: Shuffle()
        * PARAMS: None
        * RETURNS: None
        * CLASS SCOPE EFFECTS: shuffledCards array
        * CALLED FUNCTIONS: None
        * 
        * DESCRIPTION: Use the Random class to randomly pick from the playingCards array and copy to the shuffledCards array to get a random order of Cards
    */
    public void Shuffle()
    {
        //iterate through a loop 10 times to go through each space available in the shuffledCards array
        for(int i = 0; i<10; i++)
        {
            //get a random number between 0 and 9 (10 is exclusive)
            int holdRandom = Random.Range(0,10);

            //If the Card object's drawn value is false, then the card can be copied into the array
            if(playingCards[holdRandom].drawn == false)
            {
                shuffledCards[i] = playingCards[holdRandom]; //copy the Card object to the shuffledCards array
                playingCards[holdRandom].drawn = true; //set the playingCard's drawn value to true to indicate its been placed into the deck
            }
            //if the Card's drawn value is true, this means the card has already been drawn and copied to the shuffledCards array, so a different card must be chosen
            else
            {
                i--; //decrement the i value so that it does not move to the next index for the shuffledCards array
            }
        }

        //Reset the Cards' drawn variable to false; this is in anticipation of the next time the cards must be shuffled
        for (int i = 0; i < 10; i++)
        {
            playingCards[i].drawn = false;
            shuffledCards[i].drawn = false;
        }
    }

    /* FUNCTION: ReadMoneyCost()
       * PARAMS: None
       * RETURNS: integer
       * CLASS SCOPE EFFECTS: None
       * CALLED FUNCTIONS: None
       * 
       * DESCRIPTION: returns the drawnMoneyCost value when called
    */
    public int ReadMoneyCost()
    {
        return drawnMoneyCost;
    }
    /* FUNCTION: ReadMoneyCost()
       * PARAMS: None
       * RETURNS: integer
       * CLASS SCOPE EFFECTS: None
       * CALLED FUNCTIONS: None
       * 
       * DESCRIPTION: returns the drawnActionCost value when called
    */
    public int ReadActionCost()
    {
        return drawnActionCost;
    }
}

