using SnakeSolver.Grid;

namespace SnakeSolver.Game
{
    public class Game
    {
        private GameState gameState;
        private Cell? lastMove;
        private Random random;
        public Snake Snake { get; private set; }
        public int SnakeDirection { get; private set; }
        public int GridWidth { get; }
        public int GridHeight { get; }

        public int Moves { get; private set; }
        public int Score => Snake.Body.Count;

        public Cell Food { get; private set; }
        public GameState GameState
        {
            get
            {
                return gameState;
            }
            internal set
            {
                gameState = value;
                GameStateChanged?.Invoke(this, value);
            }
        }
        public EventHandler<GameState>? GameStateChanged;

        public Game(int gridWith, int gridHeight, int? randomSeed = null)
        {
            GridWidth = gridWith;
            GridHeight = gridHeight;

            if (randomSeed != null)
            {
                random = new Random(randomSeed.Value);
            }
            else
            {
                random = new Random();
            }
            GameState = GameState.Alive;
            Snake = new Snake(RandomCellNotInSnake());
            SnakeDirection = RandomValidSnakeDirection();
            Food = RandomCellNotInSnake();
            Moves = 0;
        }

        private int RandomValidSnakeDirection()
        {
            return random.Next(3);
        }

        private Cell RandomCellNotInSnake()
        {
            var newX = random.Next(GridWidth);
            var newY = random.Next(GridHeight);
            var cell = new Cell(newX, newY);
            while (SnakeMover.IsCellInSnakeBody(cell, Snake))
            {
                newX = random.Next(GridWidth);
                newY = random.Next(GridHeight);
                cell = new Cell(newX, newY);
            }
            return cell;
        }

        public void Move()
        {
            Move(lastMove);
        }

        public void Move(int direction)
        {
            Move(SnakeMover.DirectionToVector(direction));
        }

        public void Move(Cell movement)
        {
            if (GameState != GameState.Alive)
            {
                return;
            }
            lastMove = movement;
            SnakeDirection = SnakeMover.VectorToDirection(movement);
            var moveResult = SnakeMover.Move(GridWidth, GridHeight, Snake, movement, Food);
            switch (moveResult)
            {
                case MoveResult.OutOfGrid:
                case MoveResult.HitSnake:
                    GameState = GameState.Dead;
                    return;
                case MoveResult.AteFood when (!IsGameFinished()):
                    Moves += 1;
                    Food = RandomCellNotInSnake();
                    return;
                case MoveResult.AteFood:
                    Moves += 1;
                    return;
                case MoveResult.Ok when (IsGameWon()):
                    Moves += 1;
                    GameState = GameState.Won;
                    return;
                case MoveResult.Ok:
                    Moves += 1;
                    return;
            }
        }

        private bool IsGameWon()
        {
            return Snake.Body.Count == GridWidth * GridHeight;
        }


        public bool IsGameFinished()
        {
            return GameState != GameState.Alive || IsGameWon();
        }
    }
}
