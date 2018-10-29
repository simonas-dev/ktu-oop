namespace SpaceInvaders.Domain.Models.States
{
    public interface IGamesState
    {
        void DoAction(Game games);
    }
}