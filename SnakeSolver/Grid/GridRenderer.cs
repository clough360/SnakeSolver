using SnakeSolver.Game;

namespace SnakeSolver.Grid
{
    internal class GridRenderer
    {
        private readonly PictureBox container;
        private Cell lastSnakeTail;
        private Brush BlankCellBrush => Brushes.LightGray;
        private Brush FoodCellBrush => Brushes.Red;
        private Brush SnakeCellBrush => Brushes.Green;
        private Brush SnakeHeadBrush => Brushes.DarkGreen;
        private Brush SnakeDeadHeadBrush => Brushes.Black;

        private int CellContentsPadding => 3;
        public GridRenderer(PictureBox container, int width, int height)
        {
            this.container = container;
            CellsX = width;
            CellsY = height;
        }

        public int CellsX { get; }
        public int CellsY { get; }

        public void Draw(Game.Game game, bool redrawGrid = false)
        {
            Graphics g = Graphics.FromImage(container.Image);
            if (redrawGrid)
            {
                DrawGrid(g);
                DrawBlankCells(g);
            }
            DrawSnake(g, game.GameState, game.Snake, lastSnakeTail);
            DrawDirection(g, game.Snake, game.SnakeDirection);
            DrawFood(g, game.Food);
            g.Dispose();

            lastSnakeTail = game.Snake.Tail;

            container.Invalidate();
        }

        private void DrawDirection(Graphics g, Snake snake, int snakeDirection)
        {
            var cellBounds = GetCellBounds(snake.Head.X, snake.Head.Y, CellContentsPadding);
            var middleX = cellBounds.Left + cellBounds.Width / 2;
            var middleY = cellBounds.Top + cellBounds.Height / 2;

            Point lineEnd;
            switch (snakeDirection)
            {
                case 0: lineEnd = new Point(middleX, cellBounds.Y); break;
                case 1: lineEnd = new Point(cellBounds.X + cellBounds.Width, middleY); break;
                case 2: lineEnd = new Point(middleX, cellBounds.Y + cellBounds.Height); break;
                case 3: lineEnd = new Point(cellBounds.X, middleY); break;
                default: throw new NotImplementedException("Invalid Direction");
            }
            g.DrawLine(Pens.White, new Point(middleX, middleY), lineEnd);
            //DrawCell(g, cellBounds, FoodCellBrush);
        }

        private void DrawFood(Graphics g, Cell food)
        {
            if (food == new Cell())
            {
                return;
            }
            var cellBounds = GetCellBounds(food.X, food.Y, CellContentsPadding);
            DrawCell(g, cellBounds, FoodCellBrush);
        }

        private void DrawSnake(Graphics g, GameState gameState, Snake snake, Cell lastSnakeTail)
        {
            if (snake?.Body == null)
            {
                return;
            }
            var isHead = true;
            foreach (var cell in snake.Body)
            {
                var cellBounds = GetCellBounds(cell.X, cell.Y, CellContentsPadding);
                if (isHead)
                {
                    if (gameState == GameState.Alive)
                    {
                        DrawCell(g, cellBounds, SnakeHeadBrush);
                    }
                    else
                    {
                        DrawCell(g, cellBounds, SnakeDeadHeadBrush);
                    }
                    isHead = false;
                }
                else
                {
                    DrawCell(g, cellBounds, SnakeCellBrush);
                }
            }
            if (lastSnakeTail != null && snake.Tail != lastSnakeTail)
            {
                DrawCell(g, GetCellBounds(lastSnakeTail.X, lastSnakeTail.Y, CellContentsPadding), BlankCellBrush);
            }
        }

        private void DrawCell(Graphics g, Rectangle cellBounds, Brush brush)
        {
            g.FillRectangle(brush, cellBounds);
        }

        private void DrawGrid(Graphics g)
        {
            for (var yIdx = 0; yIdx < CellsY; yIdx++)
            {
                for (var xIdx = 0; xIdx < CellsX; xIdx++)
                {
                    var bounds = GetCellBounds(xIdx, yIdx, CellContentsPadding);
                    g.DrawRectangle(Pens.LightGray, bounds);
                }
            }
        }

        public void DrawBlankCells(Graphics g)
        {
            for (var yIdx = 0; yIdx < CellsY; yIdx++)
            {
                for (var xIdx = 0; xIdx < CellsX; xIdx++)
                {
                    DrawCell(g, GetCellBounds(xIdx, yIdx, 1), BlankCellBrush);
                }
            }
        }

        private Rectangle GetCellBounds(int xIdx, int yIdx, int padding)
        {
            var cellWidthX = container.Image.Width / CellsX;
            var cellWidthY = container.Image.Height / CellsY;

            var cellWidth = Math.Min(cellWidthY, cellWidthX);

            var minX = xIdx * cellWidth + padding;
            var minY = yIdx * cellWidth + padding;

            return new Rectangle(minX, minY, cellWidth - padding * 2, cellWidth - padding * 2);
        }
    }
}
