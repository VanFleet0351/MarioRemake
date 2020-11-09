namespace SprintZero.Interfaces
{
    public interface IBlock: IGameObject
    {
        IBlockState State {get; set;}
        bool WasHit { get; set; }
        void BeHit();
        void BeBumped();
    }
}
