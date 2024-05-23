namespace Mechanics.Event
{
    public abstract class ActionEvent
    {
        public ActionEventType Type { get; }

        protected ActionEvent(ActionEventType actionEventType)
        {
            Type = actionEventType;
        }
    }
}