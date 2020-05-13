/*Function of the Board class:
 * Handle anything dealing with the board's objects
 * Assigns the objects on the board an identifying number and get the object's position in the game for the MovementManager class to access as necessary
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    //Declare game object board space and attach respective board space object to get the object's position in an array
    public GameObject[] boardSpace = new GameObject[10];

    //Declare public int variable to assign the board space object its respective number and variables to hold the object's x and z position in the game
    public int spaceNum;
    float spacePosX;
    float spacePosZ;

    /* FUNCTION: SetSpaceNumber()
         * PARAMS: int space
         * RETURNS: None
         * CLASS SCOPE EFFECTS: spaceNum
         * CALLED FUNCTIONS: None
         * 
         * DESCRIPTION: Changes the spaceNum value to the space value passed to the function
    */
    public void SetSpaceNumber(int space)
    {
        spaceNum = space;
    }

    /* FUNCTION: GetSpacePosX()
         * PARAMS: None
         * RETURNS: float
         * CLASS SCOPE EFFECTS: None
         * CALLED FUNCTIONS: None
         * 
         * DESCRIPTION: Returns the current set space's x position (using localPosition because the board pieces are children of an empty object)
    */
    public float GetSpacePosX()
    {
        //Gets the x position of the board space object from the boardSpace GameObject array
        spacePosX = boardSpace[spaceNum].transform.localPosition.x;
        return spacePosX;
    }

    /* FUNCTION: GetSpacePosZ()
         * PARAMS: None
         * RETURNS: float
         * CLASS SCOPE EFFECTS: None
         * CALLED FUNCTIONS: None
         * 
         * DESCRIPTION: Returns the current set space's z position (using localPosition because the board pieces are children of an empty object)
    */
    public float GetSpacePosZ()
    {
        //Gets the z position of the board space object from the boardSpace GameObject array
        spacePosZ = boardSpace[spaceNum].transform.localPosition.z;
        return spacePosZ;
    }
}
