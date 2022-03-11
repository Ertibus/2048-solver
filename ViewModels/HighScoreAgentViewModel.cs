using System;
using System.Threading;
using System.Collections.Generic;
using System.Text;
using ReactiveUI;

namespace TwoZeroFourEight.ViewModels
{
    class HighScoreAgentViewModel : ViewModelBase
    {
        private bool _enableWin;
        private GameBoardViewModel _game;
        private string _solveButtonText;
        private bool _isSolving;
        private double _moveDelay; private int _searchDepth;

        private Thread solverThread;
        private object _locker;

        public HighScoreAgentViewModel(GameBoardViewModel game)
        {
            _game = game;
            _enableWin = true;
            _solveButtonText = "Solve";
            _isSolving = false;
            _moveDelay = 0.1;
            _searchDepth = 1;
            _locker = new object();
        }

        public bool EnableWin
        {
            get => _enableWin;
            set {
                _enableWin = value;
                _game.EnableWinCondition(_enableWin);
            } 
        }

        public double MoveDelay
        {
            get => _moveDelay;
            set => _moveDelay = value;
        }

        public int SearchDepth 
        {
            get => _searchDepth;
            set => _searchDepth = value;
        }

        public string SolveButtonText 
        {
            get => _solveButtonText;
            set => this.RaiseAndSetIfChanged(ref _solveButtonText, value); 
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
        public void MoveAny()
        {
            _game.MoveAny();
        }

        public void SolveGame()
        {
            lock(_locker)
            {
                if(_isSolving)
                {
                    SolveButtonText = "Solve";
                } else {
                    SolveButtonText = "Stop";
                    solverThread = new Thread(Work);
                    solverThread.Start();
                }
            }
            _isSolving = !_isSolving;
        }

        private void Work()
        {
            while (_isSolving && _game.state != GameStateEnum.GameOver)
            {
                lock(_locker)
                {
                    switch(HighScoreAI.GetNextMove(_game.Game, _searchDepth))
                    {
                        case GameMoves.Up:
                            MoveUp();
                            break;
                        case GameMoves.Down:
                            MoveDown();
                            break;
                        case GameMoves.Left:
                            MoveLeft();
                            break;
                        case GameMoves.Right:
                            MoveRight();
                            break;
                        default:
                            MoveAny();
                            break;
                    }
                    Thread.Sleep((int)(_moveDelay * 1000));
                }
                if(_game.state == GameStateEnum.GameOver)
                {
                    _isSolving = false;
                    SolveButtonText = "Solve";
                }
            }
        }
    }
}
