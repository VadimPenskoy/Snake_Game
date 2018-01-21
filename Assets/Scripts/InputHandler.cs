using UnityEngine;
using UnityEditor;

public class InputHandler
{
    public Direction HandleArrows(Direction direction)
    {
        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            direction = Direction.Up;
        }
        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            direction = Direction.Down;
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            direction = Direction.Left;
        }
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            direction = Direction.Right;
        }
        return direction;
    }

   

}
