namespace ZScripts
{
    public struct IntVector2
    {
        public static IntVector2 UNASSIGNET = new IntVector2(-1000, -1000);
        
        public int x;
        public int y;

        public IntVector2(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }
}