using SnakeSolver.Game;
using SnakeSolver.Grid;

namespace SnakeSolver.Solvers
{
    internal interface ISolver
    {
        void Initialise(Game.Game game);
        int MakeMove();

        EventHandler<GameState>? GameFinished { get; set; }
        EventHandler? Moved { get; set; }
    }

    internal class SimpleSolver: ISolver
    {
        private Game.Game? game;

        public EventHandler<GameState>? GameFinished { get; set; }
        public EventHandler? Moved { get; set; }

        public void Initialise(Game.Game game)
        {
            this.game = game;
        }

        public int MakeMove()
        {
            var dx = game.Food.X - game.Snake.Head.X;
            var dy = game.Food.Y - game.Snake.Head.Y;

            var snakeDirection = SnakeMover.DirectionToVector(game.SnakeDirection);
            var xDirectionOk = (dx < 0 && snakeDirection.X < 0)
                || (dx > 0 && snakeDirection.X > 0)
                || (dx == 0 && snakeDirection.X == 0);
         
            var yDirectionOk = (dy < 0 && snakeDirection.Y < 0)
            || (dy > 0 && snakeDirection.Y > 0)
            || (dy == 0 && snakeDirection.Y == 0);

            if (xDirectionOk && yDirectionOk)
            {
                return game.SnakeDirection;
            }
            if (!xDirectionOk && yDirectionOk)
            {
                return SnakeMover.MakeLeftTurn(game.SnakeDirection);
            }
            return SnakeMover.MakeRightTurn(game.SnakeDirection);
        }
    }
}
