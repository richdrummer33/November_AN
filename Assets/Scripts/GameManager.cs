using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // ***Singleton***
    // Static: means that there is only one of this variable throughout the entire game/application - globally accessible. This variable belongs to the class itself.
    public static GameManager instance; // this variable (named "instance") is of type GameManager 

    public Text scoreText; // Num cubes destroyed
    public Text timeRemaining; // Num cubes destroyed
    public Text cubesRemaining;

    public int cubesDestroyed; // Keeping track of num cubes destroyed
    public int numCubesToDestroy = 21; // To win the game, need destroy this many
    int numCubesRemaining;

    public float gameTimer = 10f; // If reaches 0, then gameover (countdown timer)

    public BasicButtonController resetButton; 

    // Start is called before the first frame update
    void Start()
    {
        instance = this;

        numCubesRemaining = numCubesToDestroy;

        resetButton.OnButtonPushed += ResetGame; // Subsrcibe the ResetGame method to the OnButtonPushed delegate
    }

    // Update is called once per frame
    void Update()
    {
        // If the number of cubes destroyed is not yet the amount required to win
        if (gameTimer > 0) // Still playing
        {
            if (cubesDestroyed < numCubesToDestroy)
            {
                scoreText.text = "Cubes Destroyed (score): " + cubesDestroyed;

                numCubesRemaining = numCubesToDestroy - cubesDestroyed;

                cubesRemaining.text = "Cubes Remaining: " + numCubesRemaining;

                gameTimer -= Time.deltaTime;
            }
            else // We win
            {
                scoreText.text = "YOU WIN!!!";
            }
        }
        else
        {
            scoreText.text = "Game Over. Score: " + cubesDestroyed;
        }

        timeRemaining.text = "Time Remaining: " + System.Math.Round(gameTimer, 1);
    }

    public void IncrementScore()
    {
        cubesDestroyed = cubesDestroyed + 1;
    }

    void ResetGame()
    {
        gameTimer = 10f;

        cubesDestroyed = 0;
    }
}
