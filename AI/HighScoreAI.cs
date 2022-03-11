using System;
using TwoZeroFourEight.Models;
namespace TwoZeroFourEight.ViewModels
{
    class HighScoreAI
    {
        public static GameMoves GetNextMove(GameModel gameState, int depth = 1)
        {
            GameModel copyState;
            int topScore = 0;
            GameMoves bestMove = GameMoves.Any;
            // Up
            copyState = new GameModel(4, gameState.Score);
            copyState.GameBoard = gameState.DeepCopyBoard();
            copyState.MoveUp();
            if(copyState.Score != gameState.Score)
            {
                int tempScore = PredictNextMove(copyState, depth - 1);
                if( topScore < tempScore)
                {
                    topScore = tempScore;
                    bestMove = GameMoves.Up;
                }
            }
            // Down
            copyState = new GameModel(4, gameState.Score);
            copyState.GameBoard = gameState.DeepCopyBoard();
            copyState.MoveDown();
            if(copyState.Score != gameState.Score)
            {
                int tempScore = PredictNextMove(copyState, depth - 1);
                if( topScore < tempScore )
                {
                    topScore = tempScore;
                    bestMove = GameMoves.Down;
                }
            }
            // Left
            copyState = new GameModel(4, gameState.Score);
            copyState.GameBoard = gameState.DeepCopyBoard();
            copyState.MoveLeft();
            if(copyState.Score != gameState.Score)
            {
                int tempScore = PredictNextMove(copyState, depth - 1);
                if( topScore < tempScore )
                {
                    topScore = tempScore;
                    bestMove = GameMoves.Left;
                }
            }
            // Right
            copyState = new GameModel(4, gameState.Score);
            copyState.GameBoard = gameState.DeepCopyBoard();
            copyState.MoveRight();
            if(copyState.Score != gameState.Score)
            {
                int tempScore = PredictNextMove(copyState, depth - 1);
                if( topScore < tempScore )
                {
                    topScore = tempScore;
                    bestMove = GameMoves.Right;
                }
            }
            Console.WriteLine($"[DEBUG] Move:{bestMove};\tOG Score: {gameState.Score};\tNW Score: {topScore}");
            return bestMove;
        }

        private static int PredictNextMove(GameModel state, int depth)
        {
            if(depth <= 0)
                return state.Score;
            GameModel copyState;
            int topScore = 0;
            int score;
            // Up
            copyState = new GameModel(4, state.Score);
            copyState.GameBoard = state.DeepCopyBoard();
            copyState.MoveUp();
            score = PredictNextMove(copyState, depth - 1);
            if( topScore < score)
                topScore = score;
            // Down
            copyState = new GameModel(4, state.Score);
            copyState.GameBoard = state.DeepCopyBoard();
            copyState.MoveDown();
            score = PredictNextMove(copyState, depth - 1);
            if( topScore < score)
                topScore = score;
            // Left
            copyState = new GameModel(4, state.Score);
            copyState.GameBoard = state.DeepCopyBoard();
            copyState.MoveLeft();
            score = PredictNextMove(copyState, depth - 1);
            if( topScore < score)
                topScore = score;
            // Right
            copyState = new GameModel(4, state.Score);
            copyState.GameBoard = state.DeepCopyBoard();
            copyState.MoveRight();
            score = PredictNextMove(copyState, depth - 1);
            if( topScore < score)
                topScore = score;

            return topScore;
        }
    }
    
    public enum GameMoves
    {
        Up,
        Down,
        Left,
        Right,
        Any
    }
}
