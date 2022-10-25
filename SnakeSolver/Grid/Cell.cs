using System.Diagnostics.CodeAnalysis;

namespace SnakeSolver.Grid
{
    public record Cell
    {
        public Cell()
        {
        }

        public Cell(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X { get; set; }
        public int Y { get; set; }
    }   
}
