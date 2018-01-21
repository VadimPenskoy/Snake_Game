using UnityEngine;
using UnityEditor;

public class Score
{
    int score = 0;
    public int getScore() { return score; }
    public int addPoint() { return score++; }
    public void ResetScore() { score = 0; }
   
}