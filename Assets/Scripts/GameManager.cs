using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // ***Singleton***
    // Static: means that there is only one of this variable throughout the entire game/application - globally accessible. This variable belongs to the class itself.
    public static GameManager instance; // this variable (named "instance") is of type GameManager 

    public int score;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IncrementScore()
    {
        score = score + 1;
    }
}
