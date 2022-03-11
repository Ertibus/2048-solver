using System;
using System.Collections.Generic;

namespace TwoZeroFourEight.Models
{
    class GameModel
    {
        public int gameBoardSize;
        private readonly Random _random = new Random();
        private GameTileModel[,] _gameBoard;
        private bool hasChanged;
        private int _score;
        private bool _canWin;

        public GameModel(int size = 4, int score = 0)
        {
            _gameBoard = new GameTileModel[size, size];
            gameBoardSize = size;
            hasChanged = false;
            _score = score;
        }

        public GameTileModel[,] GameBoard
        {
            get => _gameBoard;
            set { _gameBoard = value; }
        }

        public int Score
        {
            get => _score;
        }

        public bool CanWin
        {
            get => _canWin;
            set => _canWin = value;
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
            _score = 0;
            hasChanged = false;
            SpawnNewRandomTile();
            SpawnNewRandomTile();
        }

        public bool HasLegalMove()
        {
            for(int i = 0; i < 4; i++)
                for(int j = 0; j < 4; j++)
                    if((_gameBoard[i, j].Number == 0)
                            || ((i != 3) && (_gameBoard[i, j].Number == _gameBoard[i + 1, j].Number))
                            || ((j != 3) && (_gameBoard[i, j].Number == _gameBoard[i, j + 1].Number)))
                        return true;
            return false;
        }

        public bool MoveUp()
        {
            for(int i = 0; i < 4; i++)
                for(int j = 0; j < 4; j++)
                    Move(i, j, -1, 0);
            ClearChanged();
            if(hasChanged)
            {
                SpawnNewRandomTile();
                hasChanged = false;
                return true;
            } else {
                return false;
            }
        }

        public bool MoveDown()
        {
            for(int i = 4; i >= 0; i--)
                for(int j = 0; j < 4; j++)
                    Move(i, j, 1, 0);
            ClearChanged();
            if(hasChanged)
            {
                SpawnNewRandomTile();
                hasChanged = false;
                return true;
            } else {
                return false;
            }
        }

        public bool MoveLeft()
        {
            for(int i = 0; i < 4; i++)
                for(int j = 0; j < 4; j++)
                    Move(i, j, 0, -1);
            ClearChanged();
            if(hasChanged)
            {
                SpawnNewRandomTile();
                hasChanged = false;
                return true;
            } else {
                return false;
            }
        }

        public bool MoveRight()
        {
            for(int i = 0; i < 4; i++)
                for(int j = 3; j >= 0; j--)
                    Move(i, j, 0, 1);
            ClearChanged();
            if(hasChanged)
            {
                SpawnNewRandomTile();
                hasChanged = false;
                return true;
            } else {
                return false;
            }
        }

        public void MoveAny()
        {
            switch (_random.Next(4))
            {
                case 0:
                    if(!MoveUp())
                        MoveAny();
                    return;
                case 1:
                    if(!MoveDown())
                        MoveAny();
                    return;
                case 2:
                    if(!MoveLeft())
                        MoveAny();
                    return;
                case 3:
                    if(!MoveRight())
                        MoveAny();
                    return;
            }

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
                hasChanged = true;
                Move(nextRow, nextCol, rowDir, colDir);
            }
            else if(_gameBoard[nextRow, nextCol].Number == _gameBoard[row, col].Number && !_gameBoard[nextRow, nextCol].HasChanged)
            {
                _gameBoard[nextRow, nextCol].DoubleIt();
                _score += _gameBoard[nextRow, nextCol].Number;
                _gameBoard[row, col].Clear();
                hasChanged = true;
            }
        }

        private bool HasChanged()
        {
            for(int i = 0; i < gameBoardSize; i++)
                for(int j = 0; j < gameBoardSize; j++)
                    if (_gameBoard[i, j].HasChanged)
                        return true;
            return false;
        }

        private void ClearChanged()
        {
            for(int i = 0; i < gameBoardSize; i++)
                for(int j = 0; j < gameBoardSize; j++)
                    _gameBoard[i, j].HasChanged = false;
        }
        
        public bool HasWon()
        {
            for(int i = 0; i < gameBoardSize; i++)
                for(int j = 0; j < gameBoardSize; j++)
                    if(_gameBoard[i, j].Number >= 2048)
                        return _canWin;
            return false;
        }

        public GameTileModel[,] DeepCopyBoard()
        {
            var gameBoard = new GameTileModel[4, 4];
            for(int i = 0; i < 4; i++)
                for(int j = 0; j < 4; j++)
                    gameBoard[i, j] = new GameTileModel(j, i, _gameBoard[i, j].Number);
            return gameBoard;
        }
    }
}
