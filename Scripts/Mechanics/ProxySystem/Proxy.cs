using Mechanics.Controller;

namespace Mechanics.ProxySystem
{
    public class Proxy<T> where T : IDataClass<T>
    {
        protected T DataClass;

        public Proxy(T dataClass)
        {
            DataClass = dataClass;
        }
    }
}