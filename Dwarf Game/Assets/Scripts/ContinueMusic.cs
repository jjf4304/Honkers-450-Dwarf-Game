using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContinueMusic : MonoBehaviour
{
    public static ContinueMusic continueMusic;

    void Awake()
    {
        if (continueMusic == null)
        {
            DontDestroyOnLoad(gameObject);
            continueMusic = this;
        }
        else if (continueMusic != this)
        {
            Destroy(gameObject);
        }
    }
}
