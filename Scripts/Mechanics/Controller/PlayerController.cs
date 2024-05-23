using System;
using Mechanics.ProxySystem;

namespace Mechanics.Controller
{
    public class PlayerController : IDataClass<PlayerController>
    {
        public Player Player { get; private set; }
        
        

        public TProxyType GetProxyFor<TRequesterType, TProxyType>() where TProxyType : Proxy<PlayerController>
        {
            switch (typeof(TRequesterType))
            {
                case Type t when t == typeof(TRequesterType):
                {
                    return new PlayerControllerProxyForMissions(this) as TProxyType;
                }
                default:
                {
                    throw new AccessViolationException("No PlayerController proxy implemented for " + typeof(TRequesterType));
                }
            }
        }
    }
}