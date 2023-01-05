using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GOLconsole.Source
{
    public class Cell
    {
        public bool IsAlive { get; set; }
        public bool NextState { get; set; }

        public Cell(bool isAlive)
        {
            IsAlive = isAlive;
        }

        public void Update(int liveNeighbors)
        {
            if (IsAlive)
            {
                NextState = liveNeighbors == 2 || liveNeighbors == 3;
            }
            else
            {
                NextState = liveNeighbors == 3;
            }
        }
    }

}
