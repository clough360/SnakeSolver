using SnakeSolver.Game;
using SnakeSolver.Grid;
using SnakeSolver.Solvers;

namespace SnakeSolver
{
    public partial class SnakeForm : Form
    {
        private GridRenderer renderer;

        private Game.Game game;
        private ISolver currentSolver;

        public SnakeForm()
        {
            InitializeComponent();

            var gridWidth = 10;
            var gridHeight = 10;
            var image = new Bitmap(1000, 1000);
            GridContainer.Image = image;
            this.renderer = new GridRenderer(GridContainer, gridWidth, gridHeight);

            game = new Game.Game(gridWidth, gridHeight);
            RedrawGame(renderer, true);
        }

        private void GridContainer_Resize(object sender, EventArgs e)
        {
            renderer.Draw(game, true);
        }

        private void RestartButton_Click(object sender, EventArgs e)
        {
            game = new Game.Game(10, 10);
            RedrawGame(renderer, true);
        }

        private void UpButton_Click(object sender, EventArgs e)
        {
            game.Move(new Cell(0, -1));
            RedrawGame(renderer);
        }

        private void DownButton_Click(object sender, EventArgs e)
        {
            game.Move(new Cell(0, 1));
            RedrawGame(renderer);
        }

        private void LeftButton_Click(object sender, EventArgs e)
        {
            game.Move(new Cell(-1, 0));
            RedrawGame(renderer);
        }

        private void RightButton_Click(object sender, EventArgs e)
        {
            game.Move(new Cell(1, 0));
            RedrawGame(renderer);
        }
        private void RedrawGame(GridRenderer renderer, bool redrawGrid = false)
        {
            renderer.Draw(game, redrawGrid);
            UpdateStats();
        }

        private void UpdateStats()
        {
            ScoreLabel.Text = $"Score: {game.Score}";
            MovesLabel.Text = $"Moves: {game.Moves}";
        }

        private void RunSimpleSolverButton_Click(object sender, EventArgs e)
        {
            RunSolver(new SimpleSolver());
        }

        private void RunSolver(SimpleSolver solver)
        {
            if (currentSolver != null)
            {
                currentSolver.Moved -= HandleSolverMoved;
                currentSolver.GameFinished -= HandleSolverGameFinished;
            }

            game = new Game.Game(10, 10);
            solver.Initialise(game);
            currentSolver = solver;
            solver.Moved += HandleSolverMoved;
            solver.GameFinished += HandleSolverGameFinished;

            var thread = new Thread(new ThreadStart(SolverLoop));
            thread.Start();
        }

        private void SolverLoop()
        {
            Invoke(RedrawGame, renderer, true);

            while (!game.IsGameFinished())
            {
                var move = currentSolver.MakeMove();

                game.Move(move);
                Thread.Sleep(1000);
                Invoke(RedrawGame, renderer, false);
            }
        }

        private void HandleSolverGameFinished(object? sender, GameState e)
        {
            throw new NotImplementedException();
        }

        private void HandleSolverMoved(object? sender, EventArgs e)
        {
            RedrawGame(renderer);
        }
    }
}
