using Mechanics.Controller;

namespace Mechanics.ProxySystem
{
    public class Proxy<T> where T : IDataClass<T>
    {
        protected T DataClassInstance;

        public Proxy(T dataClassInstance)
        {
            DataClassInstance = dataClassInstance;
        }
    }
}