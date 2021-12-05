using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : MonoBehaviour
{

    public Cell[] cell;

    private bool isNextTurn = false; // Made it public for testing
    int lastEmptyCounter = 0;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void CheckWin(int player)
    {

        // Need to check if there are 3 of the same
        // Check horizontal rows
        if (GameManager.board[0] == player && GameManager.board[1] == player && GameManager.board[2] == player)
        {
            Debug.Log(string.Format("Player {0} has won!", player));
            GameManager.GameState = GameManager.GameStates.WIN;
        }

        if (GameManager.board[3] == player && GameManager.board[4] == player && GameManager.board[5] == player)
        {
            Debug.Log(string.Format("Player {0} has won!", player));
            GameManager.GameState = GameManager.GameStates.WIN;
        }

        if (GameManager.board[6] == player && GameManager.board[7] == player && GameManager.board[8] == player)
        {
            Debug.Log(string.Format("Player {0} has won!", player));
            GameManager.GameState = GameManager.GameStates.WIN;
        }

        // Check vertical columns
        for (int i = 0; i < 3; i++)
        {

            if (GameManager.board[i] == player && GameManager.board[i + 3] == player && GameManager.board[i + 6] == player)
            {
                Debug.Log(string.Format("Player {0} has won!", player));
                GameManager.GameState = GameManager.GameStates.WIN;
            }
        }

        // Check diagonal rows 2 possibilities
        if (GameManager.board[0] == player && GameManager.board[4] == player && GameManager.board[8] == player)
        {
            Debug.Log(string.Format("Player {0} has won!", player));
            GameManager.GameState = GameManager.GameStates.WIN;
        }

        if (GameManager.board[2] == player && GameManager.board[4] == player && GameManager.board[6] == player)
        {
            Debug.Log(string.Format("Player {0} has won!", player));
            GameManager.GameState = GameManager.GameStates.WIN;
        }
    }

    public void PlayerMove(int player)
    {
        if (player == 1 && isNextTurn)
        {
            GameManager.currentPlayer = 2;
            isNextTurn = false;
            GameManager.GameState = GameManager.GameStates.PLAYER2CHOICE;
        }

        if (player == 2 && isNextTurn)
        {
            GameManager.currentPlayer = 1;
            isNextTurn = false;
            GameManager.GameState = GameManager.GameStates.PLAYER1CHOICE;
        }
    }

    public void NextTurn()
    {
        int emptyCounter = 0;

        for (int i = 0; i < 9; i++)
        {

            if (GameManager.board[i] == 0)
            {
                emptyCounter++;
            }
        }

        // Start of game this will be true
        if (emptyCounter == 9)
        {
            Debug.Log("All cells are empty");
            isNextTurn = false;
            lastEmptyCounter = emptyCounter;
        }
        // If a tile has been clicked emptyCounter will be less than
        if (emptyCounter < lastEmptyCounter)
        {
            isNextTurn = true;
            lastEmptyCounter = emptyCounter;
            Debug.Log("Next turn status" + isNextTurn);
        }
        // If all tiles are clicked emptyCounter should be zero
        if (emptyCounter == 0)
        {
            Debug.Log("All cells are occupied");
            isNextTurn = false;
        }

    }


    public void StartGame()
    {
        // Initialize game
        // Initialize all array indices to 0
        for (int i = 0; i < 9; i++)
        {
            GameManager.board[i] = 0;
        }

        // Empty board visually
        for (int i = 0; i < 9; i++)
        {
            cell[i].EmptyBoard();

        }

        // Set initial player, and scores
        GameManager.GameState = GameManager.GameStates.PLAYER1CHOICE;

    }
}
