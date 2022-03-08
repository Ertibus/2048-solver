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

        private GameModel _game;
        private ObservableCollection<GameTileModel> _currentItems;

        public GameBoardViewModel()
        {
            _game = new GameModel(4);
            _game.NewGame();
            GameTileModel[,] gameBoard = _game.GameBoard;
            List<GameTileModel> items = new List<GameTileModel>();
            Width = 400;
            Height = 400;
            for(int i = 0; i < 4; i++)
                for(int j = 0; j < 4; j++)
                    items.Add(gameBoard[i, j]);

            this._currentItems = new ObservableCollection<GameTileModel>(items);
        }

        public ObservableCollection<GameTileModel> Items {
            get => _currentItems;
            set => this.RaiseAndSetIfChanged(ref _currentItems, value); 
        }
        public int Width{ get; set; }
        public int Height{ get; set; }

        public void NewBoard(int size = 4)
        {
            _game.NewGame();
        }

        public void MoveUp()
        {
            _game.MoveUp();
            RedrawGame();
        }
        public void MoveDown()
        {
            _game.MoveDown();
            RedrawGame();
        }
        public void MoveLeft()
        {
            _game.MoveLeft();
            RedrawGame();
        }
        public void MoveRight()
        {
            _game.MoveRight();
            RedrawGame();
        }

        private void RedrawGame()
        {
            GameTileModel[,] gameBoard = _game.GameBoard;
            List<GameTileModel> items = new List<GameTileModel>();
            for(int i = 0; i < Width / 100; i++)
                for(int j = 0; j < Height / 100; j++)
                    items.Add(gameBoard[i, j]);

            Items = new ObservableCollection<GameTileModel>(items);
        }
    }
}
