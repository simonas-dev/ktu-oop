namespace SpaceInvaders.Shared.Base.Factory
{
    public interface IFactory<out T, in TParam> 
        where T : class
    {
        T Create(TParam param, string name);
    }
}