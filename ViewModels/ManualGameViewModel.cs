using System;
using System.Collections.Generic;
using System.Text;

namespace TwoZeroFourEight.ViewModels
{
    class ManualGameViewModel : ViewModelBase
    {
        private bool _enableWin;
        private GameBoardViewModel _game;

        public ManualGameViewModel(GameBoardViewModel game)
        {
            _game = game;
            _enableWin = true;
        }

        public bool EnableWin
        {
            get => _enableWin;
            set {
                _enableWin = value;
                _game.EnableWinCondition(_enableWin);
            } 
        }

        public void MoveUp()
        {
            _game.MoveUp();
        }
        public void MoveDown()
        {
            _game.MoveDown();
        }
        public void MoveLeft()
        {
            _game.MoveLeft();
        }
        public void MoveRight()
        {
            _game.MoveRight();
        }
    }
}
