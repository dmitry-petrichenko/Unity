using System.Net.NetworkInformation;

namespace ZScripts
{
    public struct IntVector2
    {
        public static IntVector2 UNASSIGNET = new IntVector2(-1000, -1000);

        public static bool AreEqual(IntVector2 one, IntVector2 two)
        {
            if (one.x == two.x &&
                one.y == two.y)
            {
                return true;
            }

            return false;
        }
        
        public int x;
        public int y;

        public IntVector2(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        
        
    }
}