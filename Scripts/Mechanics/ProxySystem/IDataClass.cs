namespace Mechanics.ProxySystem
{
    public interface IDataClass<T> where T : IDataClass<T>
    {
        public abstract TProxyType GetProxyFor<TRequesterType, TProxyType>() where TProxyType : Proxy<T>;
    }
}