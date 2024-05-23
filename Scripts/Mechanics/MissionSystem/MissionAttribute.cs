namespace Mechanics.MissionSystem
{
    public class MissionAttribute<T>
    {
        public T Data { get; private set; }

        public MissionAttribute(T data)
        {
            Data = data;
        }
    }
}