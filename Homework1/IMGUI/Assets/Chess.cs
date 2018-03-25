using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chess : MonoBehaviour
{

    public bool IsPlayer1 = true;//Judge which player is the next
    public int[,] ChessBoard = new int[3, 3];//Note the state of the chessboard
    public bool InGame = false;//Judge if is in game
    public int Winner = 0;//0->in game

    void Start()
    {
        Reset();
    }

    void OnGUI()
    {
        //Reset Button
        if (GUI.Button(new Rect(600, 500, 80, 30), "Reset")) Reset();

        //State of the Label
        if (!InGame)
        {
            if (Winner == 0) GUI.Label(new Rect(350, 100, 220, 50), "Click Reset to play!");
            else if (Winner == 1) GUI.Label(new Rect(350, 100, 220, 50), "Player1 won!");
            else GUI.Label(new Rect(350, 100, 220, 50), "Player2 won!");
        }
        else GUI.Label(new Rect(350, 100, 220, 50), "Is playing!");

        //Change the note to chess
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                if (ChessBoard[i, j] == 1) GUI.Button(new Rect(240 + i * 100, 200 + j * 100, 80, 80), "1");
                else if (ChessBoard[i, j] == 2) GUI.Button(new Rect(240 + i * 100, 200 + j * 100, 80, 80), "2");

                if (GUI.Button(new Rect(240 + i * 100, 200 + j * 100, 80, 80), ""))
                {
                    if (InGame)
                    {
                        if (IsPlayer1)
                        {
                            ChessBoard[i, j] = 1;
                            IsPlayer1 = false;
                        }
                        else
                        {
                            ChessBoard[i, j] = 2;
                            IsPlayer1 = true;
                        }
                    }
                    Check();
                }
            }
        }
    }

    void Reset()
    {
        //Reset the player flag and the chessboard
        IsPlayer1 = true;
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                ChessBoard[i, j] = 0;
            }
        }
        InGame = true;
        Winner = 0;
    }

    void Check()
    {
        InGame = false;
        if (ChessBoard[0, 0] == ChessBoard[1, 1] && ChessBoard[2, 2] == ChessBoard[1, 1] && ChessBoard[1, 1] != 0)
        {
            Winner = ChessBoard[1, 1];
            return;
        }
        if (ChessBoard[2, 0] == ChessBoard[1, 1] && ChessBoard[0, 2] == ChessBoard[1, 1] && ChessBoard[1, 1] != 0)
        {
            Winner = ChessBoard[1, 1];
            return;
        }
        for (int i = 0; i < 3; i++)
        {
            if (ChessBoard[i, 0] == ChessBoard[i, 1] && ChessBoard[i, 2] == ChessBoard[i, 1] && ChessBoard[i, 1] != 0)
            {
                Winner = ChessBoard[i, 1];
                return;
            }
            if (ChessBoard[0, i] == ChessBoard[1, i] && ChessBoard[2, i] == ChessBoard[1, i] && ChessBoard[1, i] != 0)
            {
                Winner = ChessBoard[1, i];
                return;
            }   
        }
        if (Winner == 0) InGame = true;
    }

}
