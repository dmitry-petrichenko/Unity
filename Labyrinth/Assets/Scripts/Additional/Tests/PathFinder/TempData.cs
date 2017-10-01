using System.Collections.Generic;
using Units.PathFinder;

namespace Labyrinth.Additional.Tests
{
    public class TempData
    {
        public TempData (){}
        
        public IntVector2 DestinationPoint { get; set; }
        public Vertex2D CurrentVertex { get; set; }
        public List<IntVector2> CloseList { get; set; }
        public List<Vertex2D> OpenList { get; set; }
    }
}