namespace Mechanics.Event
{
    public abstract class EventEmitter<T> where T : ActionEvent
    {
        protected void OnEmmit(T actionEvent)
        {
            EventDispatcher.Instance.Emit(actionEvent);
        }
    }
}