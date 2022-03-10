using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using TwoZeroFourEight.Models;
using ReactiveUI;

namespace TwoZeroFourEight.ViewModels
{
    class GameBoardViewModel : ViewModelBase
    {

        private int _selectedMode;
        private GameModel _game;
        private int _width;
        private int _height;
        private ObservableCollection<GameTileModel> _currentItems;
        private int _score;
        private ViewModelBase _gameControls;
        private List<ViewModelBase> _availableControls;
        private string _gameState;
        private GameStateEnum _state;
        

        public GameBoardViewModel()
        {
            _selectedMode = 0;
            _game = new GameModel(4);
            _game.NewGame();
            GameTileModel[,] gameBoard = _game.GameBoard;
            List<GameTileModel> items = new List<GameTileModel>();
            _width = _height = _game.gameBoardSize;

            _availableControls = new List<ViewModelBase>();
            _availableControls.Add(new ManualGameViewModel(this));

            _gameControls = _availableControls[0];

            _gameState = " ";
            _state = GameStateEnum.Playing;

            for(int i = 0; i < 4; i++)
                for(int j = 0; j < 4; j++)
                    items.Add(gameBoard[i, j]);

            this._currentItems = new ObservableCollection<GameTileModel>(items);
        }

        public ObservableCollection<GameTileModel> Items {
            get => _currentItems;
            set => this.RaiseAndSetIfChanged(ref _currentItems, value); 
        }
        public int Width{ get => _width * (GameTileModel.TILE_SIZE + GameTileModel.PADDING) ; set => _width = value; }
        public int Height{ get => _height * (GameTileModel.TILE_SIZE + GameTileModel.PADDING) ; set => _width = value; }
        public int GameScore {
            get => _score;
            set => this.RaiseAndSetIfChanged(ref _score, value);
        }
        public ViewModelBase GameControls {
            get => _gameControls;
            set => this.RaiseAndSetIfChanged(ref _gameControls, value);
        }
        public int SelectedMode {
            get => _selectedMode;
            set {
            _selectedMode = value;
            NewBoard();
            }
        }

        public string GameState 
        {
            get => _gameState;
            set => this.RaiseAndSetIfChanged(ref _gameState, value);
        }

        public void NewBoard()
        {
            GameControls = _availableControls[_selectedMode];
            _game.NewGame();
            GameState = " ";
            _state = GameStateEnum.Playing;
            RedrawGame();
        }

        public void MoveUp()
        {
            if(!(_state == GameStateEnum.Playing))
                return;
            _game.MoveUp();
            RedrawGame();
        }
        public void MoveDown()
        {
            if(!(_state == GameStateEnum.Playing))
                return;
            _game.MoveDown();
            RedrawGame();
        }
        public void MoveLeft()
        {
            if(!(_state == GameStateEnum.Playing))
                return;
            _game.MoveLeft();
            RedrawGame();
        }
        public void MoveRight()
        {
            if(!(_state == GameStateEnum.Playing))
                return;
            _game.MoveRight();
            RedrawGame();
        }

        private void RedrawGame()
        {
            GameTileModel[,] gameBoard = _game.GameBoard;
            List<GameTileModel> items = new List<GameTileModel>();
            for(int i = 0; i < _width; i++)
                for(int j = 0; j < _height; j++)
                    items.Add(gameBoard[i, j]);

            Items = new ObservableCollection<GameTileModel>(items);
            GameScore = _game.Score;
            // Won?
            if(_game.HasWon())
            {
                GameState = "Victory!";
                _state = GameStateEnum.GameOver;
            }
            if(!_game.HasLegalMove())
            {
                GameState = "You Lost:\nYou Have no more moves.";
                _state = GameStateEnum.GameOver;
            }
        }

        public void EnableWinCondition(bool enable)
        {
            _game.CanWin = enable;
        }
    }
    enum GameStateEnum
    {
        Playing,
        GameOver,
    }
}
