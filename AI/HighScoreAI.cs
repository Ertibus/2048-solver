using TwoZeroFourEight.Models;
namespace TwoZeroFourEight.ViewModels
{
    class HighScoreAI
    {
        public static GameMoves GetNextMove(GameModel gameState, int depth = 1)
        {
            GameModel copyState = new GameModel();
            int topScore = 0;
            GameMoves bestMove = GameMoves.Any;
            // Up
            copyState.GameBoard = gameState.DeepCopyBoard();
            copyState.MoveUp();
            if( topScore < copyState.Score )
            {
                topScore = copyState.Score;
                bestMove = GameMoves.Up;
            }
            // Down
            copyState.GameBoard = gameState.DeepCopyBoard();
            copyState.MoveDown();
            if( topScore < copyState.Score )
            {
                topScore = copyState.Score;
                bestMove = GameMoves.Down;
            }
            // Left
            copyState.GameBoard = gameState.DeepCopyBoard();
            copyState.MoveLeft();
            if( topScore < copyState.Score )
            {
                topScore = copyState.Score;
                bestMove = GameMoves.Left;
            }
            // Right
            copyState.GameBoard = gameState.DeepCopyBoard();
            copyState.MoveRight();
            if( topScore < copyState.Score )
            {
                topScore = copyState.Score;
                bestMove = GameMoves.Right;
            }
            return bestMove;
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
