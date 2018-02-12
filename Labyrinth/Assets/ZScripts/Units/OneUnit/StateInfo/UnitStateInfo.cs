namespace ZScripts.Units.StateInfo
{
    public class UnitStateInfo : IUnitStateInfo
    {
        public UnitStateInfo()
        {
            WaitPosition = IntVector2.UNASSIGNET;
        }
        
        public IntVector2 WaitPosition { get; set; }
    }
}