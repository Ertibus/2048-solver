using System;
using System.Collections.Generic;

namespace _2048_solver.Models
{
    class GameModel
    {
        private readonly Random _random = new Random();
        private GameTileModel[,] _gameBoard;
        public GameTileModel[,] GameBoard
        {
            get => _gameBoard;
            private set { _gameBoard = value; }
        }

        public GameModel()
        {
            _gameBoard = new GameTileModel[4, 4];
        }

        private void SpawnNewRandomTile()
        {
            List<(int, int)> candidates = new List<(int, int)>();
            for(int i = 0; i < 4; i++)
                for(int j = 0; j < 4; j++)
                    if(_gameBoard[i, j].Number == 0)
                        candidates.Add((i, j));
            if(candidates.Count == 0)
                return;
            int chosen = _random.Next(candidates.Count);
            (int x, int y) = candidates[chosen];
            _gameBoard[x, y].Number = 2;
        }

        public void NewGame()
        {
            _gameBoard = new GameTileModel[4, 4];
            SpawnNewRandomTile();
            SpawnNewRandomTile();
        }

        private bool HasLegalMove()
        {
            for(int i = 0; i < 4; i++)
                for(int j = 0; j < 4; j++)
                    if((_gameBoard[i, j].Number == 0)
                            || ((i != 3) && (_gameBoard[i, j].Number == _gameBoard[i + 1, j].Number))
                            || ((j != 3) && (_gameBoard[i, j].Number == _gameBoard[i, j + 1].Number)))
                        return true;
            return false;
        }

        public void MoveUp()
        {
            for(int i = 1; i < 4; i++)
                for(int j = 0; j < 4; j++)
                    Move(i, j, -1, 0);
        }

        public void MoveDown()
        {
            for(int i = 2; i >= 0; i--)
                for(int j = 0; j < 4; j++)
                    Move(i, j, 1, 0);
        }

        public void MoveLeft()
        {
            for(int i = 0; i < 4; i++)
                for(int j = 1; j < 4; j++)
                    Move(i, j, 0, -1);
        }

        public void MoveRight()
        {
            for(int i = 0; i < 4; i++)
                for(int j = 2; j >= 0; j--)
                    Move(i, j, 0, 1);
        }

        private void Move(int row, int col, int rowDir, int colDir)
        {
            int nextRow = row + rowDir;
            int nextCol = col + colDir;
            if(_gameBoard[nextRow, nextCol].Number == 0)
            {
                _gameBoard[nextRow, nextCol] = _gameBoard[row, col];
                _gameBoard[nextRow, nextCol].Clear();
                Move(nextRow, nextCol, rowDir, colDir);
            }
            else if(_gameBoard[nextRow, nextCol].Number == _gameBoard[row, col].Number && !_gameBoard[nextRow, nextCol].HasChanged)
            {
                _gameBoard[nextRow, nextCol].DoubleIt();
                _gameBoard[row, col].Clear();
            }
        }
    }
}
