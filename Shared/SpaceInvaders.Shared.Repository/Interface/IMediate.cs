namespace SpaceInvaders.Shared.Repository.Interface
{
    public interface IMediate
    {
        TResponse Request<TResponse>(IQuery<TResponse> query);
    }
}