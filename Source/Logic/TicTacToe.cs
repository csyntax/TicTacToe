﻿namespace TicTacToe.Logic
{
    public class TicTacToe
    {
        public bool IsGameOver { get; private set; }

        public bool IsDraw { get; private set; }

        public Client PlayerOne { get; set; }

        public Client PlayerTwo { get; set; }

        private readonly int[] field = new int[9];

        private int movesLeft = 9;

        public TicTacToe()
        {
            for (int i = 0; i < field.Length; i++)
            {
                field[i] = -1;
            }
        }

        public bool Play(int player, int position)
        {
            if (this.IsGameOver)
            {
                return false;
            }                

            PlaceMarker(player, position);

            return CheckWinner();
        }


        private bool CheckWinner()
        {
            for (int i = 0; i < 3; i++)
            {
                if (
                    ((field[i * 3] != -1 && field[(i * 3)] == field[(i * 3) + 1] && field[(i * 3)] == field[(i * 3) + 2]) ||
                     (field[i] != -1 && field[i] == field[i + 3] && field[i] == field[i + 6]))
                )
                {
                    this.IsGameOver = true;

                    return true;
                }
            }

            if ((field[0] != -1 && field[0] == field[4] && field[0] == field[8]) || 
                (field[2] != -1 && field[2] == field[4] && field[2] == field[6]))
            {
                this.IsGameOver = true;

                return true;
            }

            return false;
        }

        private bool PlaceMarker(int player, int position)
        {
            movesLeft -= 1;

            if (movesLeft <= 0)
            {
                this.IsGameOver = true;
                this.IsDraw = true;

                return false;
            }

            if (position > field.Length)
            {
                return false;
            }
                
            if (field[position] != -1)
            {
                return false;
            }

            field[position] = player;

            return true;
        }
    }
}
