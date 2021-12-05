using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //Static instance of GameManager which allows it to be accessed by any other script.
    public static GameManager instance = null;

    //Store a reference to our BoardManager which will start the game.
    private BoardManager boardScript;

    public static int currentPlayer;
    public static int[] board = new int[9];

    public enum GameStates
    {
        START,
        PLAYER1CHOICE,
        PLAYER2CHOICE,
        GAMEOVER,
        WIN,
        DRAW
    }

    private static GameStates gameState;

    public static GameStates GameState
    {
        get
        {
            return gameState;
        }

        set
        {
            gameState = value;
        }
    }

    //Awake is always called before any Start functions
    void Awake()
    {
        //Check if instance already exists
        if (instance == null)
        {
            //if not, set instance to this
            instance = this;

        }

        //If instance already exists and it's not this:
        else if (instance != this)
        {
            //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
            Destroy(gameObject);
        }

        //Sets this to not be destroyed when reloading scene
        DontDestroyOnLoad(gameObject);

        //Get a component reference to the attached BoardManager script
        boardScript = GetComponent<BoardManager>();

        //Call the InitGame function to initialize the first level 
        InitGame();
    }

    //Initializes the game
    public void InitGame()
    {
        GameState = GameStates.START;
    }

    //Update is called every frame.
    void Update()
    {
        UpdateStates();
    }

    void UpdateStates()
    {
        switch (gameState){
            case GameStates.START:
                Debug.Log("Start the game");
                boardScript.StartGame();
                break;
            case GameStates.PLAYER1CHOICE:
                Debug.Log("Player 1 choice");
                currentPlayer = 1;
                boardScript.PlayerMove(1);
                boardScript.CheckWin(1);
                boardScript.NextTurn();
                break;
            case GameStates.PLAYER2CHOICE:
                Debug.Log("Player 2 choice");
                currentPlayer = 2;
                boardScript.PlayerMove(2);
                boardScript.CheckWin(2);
                boardScript.NextTurn();
                break;
            case GameStates.WIN:
                //Debug.Log("Win");
                break;
            case GameStates.DRAW:
                //Debug.Log("Draw");
                break;
            case GameStates.GAMEOVER:
                //Debug.Log("Gameover");
                break;
        }
    }

}
