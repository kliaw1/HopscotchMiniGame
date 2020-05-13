/*Function of the player class:
 * Handles anything dealing with the player object
 * Handles getting and changing the player's position on the board
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //Declare a GameObject object called player; this will have the player object attached to it
    public GameObject player;

    /* FUNCTION: SetPosition()
       * PARAMS: float newXPosition, float newZPosition
       * RETURNS: None
       * CLASS SCOPE EFFECTS: None
       * CALLED FUNCTIONS: MoveTo()
       * 
       * DESCRIPTION: Takes the x and z positions passed and changes the player's position on the board with the MoveTo coroutine
    */
    public void SetPosition(float newXPosition, float newZPosition)
    {
        //Create a Vector3 object with the new x and z position, keeping the current y position the same
        Vector3 newPosition = new Vector3(newXPosition, player.transform.localPosition.y, newZPosition);
        //Start the Coroutine to animate the player moving across the board
        StartCoroutine(MoveTo(newPosition));
    }

    /* FUNCTION: MoveTo()
       * PARAMS: Vector3 newPosition
       * RETURNS: None
       * CLASS SCOPE EFFECTS: None
       * CALLED FUNCTIONS: Vector3 class MoveTowards() 
       * 
       * DESCRIPTION: Takes the x and z positions passed and moves the GameObject to the specified position on the board
    */
    //Credit: Referenced the coroutine concept to animate the movement of the player piece from https://answers.unity.com/questions/1612420/move-object-along-path-points-after-mouse-click-wi.html
    public IEnumerator MoveTo(Vector3 newPosition)
    {
        //While the player object's current position does not yet equal the new position, move the object towards the newPosition coordinates
        while (player.transform.localPosition != newPosition)
        {
            //takes the current player's position and moves it towards the new desired position at the specified speed
            player.transform.localPosition = Vector3.MoveTowards(player.transform.localPosition, newPosition, 6f * Time.deltaTime);
            yield return null;
        }
    }

    /* FUNCTION: ResetPosition()
      * PARAMS: float newXPosition, float newZPosition
      * RETURNS: None
      * CLASS SCOPE EFFECTS: None
      * CALLED FUNCTIONS: None
      * 
      * DESCRIPTION: Takes the x and z positions passed and resets the GameObject's position to first space on the board
   */
    public void ResetPosition(float newXPosition, float newZPosition)
    {
        player.transform.localPosition = new Vector3(newXPosition, player.transform.localPosition.y, newZPosition);
    }
}
