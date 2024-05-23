namespace Mechanics.Event
{
    public abstract class SingleEventTypeListener
    {
        private ActionEventType _eventType;

        protected SingleEventTypeListener(ActionEventType eventType)
        {
            _eventType = eventType;
        }

        public abstract void OnNotify(ActionEvent actionEvent);
        
        public void OnReceive(ActionEvent actionEvent)
        {
            if (actionEvent.Type == _eventType)
            {
                OnNotify(actionEvent);
            }
        }
    }
}