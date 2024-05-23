using System.Linq;

namespace Mechanics.Event
{
    public abstract class MultipleEventTypeListener
    {
        private readonly ActionEventType[] _types;

        protected MultipleEventTypeListener(params ActionEventType[] types)
        {
            _types = types;
        }

        public void OnReceive(ActionEvent actionEvent)
        {
            if (_types.Any(actionEventType => actionEvent.Type == actionEventType))
            {
                OnNotify(actionEvent);
            }
        }

        protected abstract void OnNotify(ActionEvent actionEvent);
    }
}