using SnakeSolver.Grid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeSolver
{
    public class Snake
    {
        public Snake(Cell snakeStart)
        {
            Body.Add(snakeStart);
        }

        public List<Cell> Body { get; } = new ();
        public Cell Head => Body[0];

        public Cell Tail => Body[^1];

        internal Snake Copy()
        {
            throw new NotImplementedException();
        }
    }
}
