using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Values
{
    private static int score;

    public static int Score
    {
        get
        {
            return score;
        }
        set
        {
            score = value;
        }
    }
}
