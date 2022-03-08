using System;
using System.Collections.Generic;

namespace TwoZeroFourEight.Models
{
    class GameModel
    {
        private readonly Random _random = new Random();
        private GameTileModel[,] _gameBoard;
        private int gameBoardSize = 4;
        public GameTileModel[,] GameBoard
        {
            get => _gameBoard;
            private set { _gameBoard = value; }
        }

        public GameModel(int size = 4)
        {
            _gameBoard = new GameTileModel[size, size];
            gameBoardSize = size;
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
            for(int i = 0; i < 4; i++)
                for(int j = 0; j < 4; j++)
                    _gameBoard[i, j] = new GameTileModel(j, i, 0);
            gameBoardSize = 4;
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
            for(int i = 0; i < 4; i++)
                for(int j = 0; j < 4; j++)
                    Move(i, j, -1, 0);
            ClearChanged();
            SpawnNewRandomTile();
        }

        public void MoveDown()
        {
            for(int i = 4; i >= 0; i--)
                for(int j = 0; j < 4; j++)
                    Move(i, j, 1, 0);
            ClearChanged();
            SpawnNewRandomTile();
        }

        public void MoveLeft()
        {
            for(int i = 0; i < 4; i++)
                for(int j = 0; j < 4; j++)
                    Move(i, j, 0, -1);
            ClearChanged();
            SpawnNewRandomTile();
        }

        public void MoveRight()
        {
            for(int i = 0; i < 4; i++)
                for(int j = 3; j >= 0; j--)
                    Move(i, j, 0, 1);
            ClearChanged();
        }

        private void Move(int row, int col, int rowDir, int colDir)
        {
            int nextRow = row + rowDir;
            int nextCol = col + colDir;
            if(nextRow >= gameBoardSize || nextCol >= gameBoardSize || nextRow < 0 || nextCol < 0 || _gameBoard[row, col].Number == 0) 
                return;
            if(_gameBoard[nextRow, nextCol].Number == 0)
            {
                _gameBoard[nextRow, nextCol].Number = _gameBoard[row, col].Number;
                _gameBoard[row, col].Clear();
                Move(nextRow, nextCol, rowDir, colDir);
            }
            else if(_gameBoard[nextRow, nextCol].Number == _gameBoard[row, col].Number && !_gameBoard[nextRow, nextCol].HasChanged)
            {
                _gameBoard[nextRow, nextCol].DoubleIt();
                _gameBoard[row, col].Clear();
            }
        }

        private void ClearChanged()
        {
            for(int i = 0; i < gameBoardSize; i++)
                for(int j = 0; j < gameBoardSize; j++)
                    _gameBoard[i, j].HasChanged = false;
        }
    }
}
