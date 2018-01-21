using UnityEngine;
using UnityEditor;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    public enum Direction { Left, Right, Up, Down, None }

    public static class DirectionMethods
    {
        public static Vector2 GetVector(this Direction direction)
        {
            switch (direction)
            {
                case Direction.Left:
                    return new Vector2(-1, 0);
                case Direction.Right:
                    return new Vector2(1, 0);
                case Direction.Up:
                    return new Vector2(0, 1);
                case Direction.Down:
                    return new Vector2(0, -1);
            }
            return new Vector2(0, 0);
        }

        public static bool IsOppisiteDirection(this Direction direction1, Direction direction2)
        {
            if (direction1 == Direction.Up && direction2 == Direction.Down)
            {
                return true;
            }

            if (direction1 == Direction.Down && direction2 == Direction.Up)
            {
                return true;
            }

            if (direction1 == Direction.Left && direction2 == Direction.Right)
            {
                return true;
            }

            if (direction1 == Direction.Right && direction2 == Direction.Left)
            {
                return true;
            }
            return false;
        }
    }
