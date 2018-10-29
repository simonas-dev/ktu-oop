using System;

namespace SpaceInvaders.Shared.Repository.Interface
{
    public interface IHandleQueries<in TQuery, out TResponse>
        where TQuery : IQuery<TResponse>
    {
        TResponse Handle(TQuery query);

        bool CanHandle(Type commandType);
    }
}