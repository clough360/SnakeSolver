namespace SnakeSolver.Grid
{
    internal class SnakeMover
    {
        public static MoveResult Move(int gridWidth, int gridHeight, Snake snake, Cell direction, Cell Food)
        {
            var head = snake.Body[0];
            var newHead = AddMovement(head, direction);

            if (!IsCellInBounds(gridWidth, gridHeight, newHead))
            {
                return MoveResult.OutOfGrid;
            }
            snake.Body.Insert(0, newHead);
            if (IsHeadAtFood(snake, Food))
            {
                return MoveResult.AteFood;
            }

            TrimTail(snake);
            return MoveResult.Ok;
        }

        private static bool IsHeadAtFood(Snake snake, Cell Food)
        {
            return Food == snake.Head;
        }

        private static void TrimTail(Snake snake)
        {
            snake.Body.RemoveAt(snake.Body.Count - 1);
        }

        public static Cell AddMovement(Cell cell, Cell move)
        {
            return new Cell(cell.X + move.X, cell.Y + move.Y);
        }

        public static bool IsCellInBounds(int gridWidth, int gridHeight, Cell cell)
        {
            return cell.X >= 0
                && cell.Y >= 0
                && cell.X < gridWidth
                && cell.Y < gridHeight;
        }
        
        public static bool IsCellInSnakeBody(Cell cell, Snake snake)
        {
            if (snake == null)
            {
                return false;
            }
            return snake.Body.Any(bc => bc == cell);
        }

        public static int MakeLeftTurn(int snakeDirection)
        {
            var newDirection = snakeDirection - 1;
            if (newDirection < 0)
            {
                newDirection = 3;
            }
            return newDirection;
        }
        public static int MakeRightTurn(int snakeDirection)
        {
            var newDirection = snakeDirection + 1;
            if (newDirection > 3)
            {
                newDirection = 0;
            }
            return newDirection;
        }

        public static Cell DirectionToVector(int direction)
        {
            switch (direction)
            {
                case 0: return new Cell(0, -1);
                case 1: return new Cell(1, 0);
                case 2: return new Cell(0, 1);
                case 3: return new Cell(-1, 0);
            }
            throw new InvalidOperationException("Invalid direction");
        }

        public static int VectorToDirection(Cell movement)
        {
            if (movement.X == 0 && movement.Y > 0) return 0;
            if (movement.X > 0 && movement.Y == 0) return 1;
            if (movement.X == 0 && movement.Y < 1) return 2;
            if (movement.X < 0 && movement.Y == 0) return 3;
            throw new InvalidOperationException("Invalid direction");
        }
    }

    public enum MoveResult
    {
        Ok,
        AteFood,
        OutOfGrid,
        HitSnake,

    }
}
