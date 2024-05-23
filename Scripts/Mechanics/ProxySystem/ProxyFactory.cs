using System;
using System.Collections.Generic;

namespace Mechanics.ProxySystem
{
    public class ProxyFactory
    {
        private static ProxyFactory _instance;
        
        public static ProxyFactory Instance => _instance ??= new ProxyFactory();

        private List<object> _dataClasses;
        
        private ProxyFactory(){}

        public void AddProxyConstraints<T>(T dataClass)
            where T : IDataClass<T>
        {
            _dataClasses.Add(dataClass);
        }

        public TProxyType GetProxyFor<TRequesterType, TProxyType, TDataClass>()
            where TProxyType : Proxy<TDataClass>
            where TDataClass : IDataClass<TDataClass>
        {
            foreach (object dataClass in _dataClasses)
            {
                if (dataClass.GetType() == typeof(TProxyType))
                {
                    return ((TDataClass)dataClass).GetProxyFor<TRequesterType, TProxyType>();
                }
            }

            throw new AccessViolationException(
                $"No proxy implemented for {typeof(TDataClass)} to {typeof(TRequesterType)}");
        }
    }
}