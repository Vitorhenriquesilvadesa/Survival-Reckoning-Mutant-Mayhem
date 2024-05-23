using System;
using Mechanics.Event;

namespace Mechanics.MissionSystem
{
    public abstract class MissionObjective<T> : SingleEventTypeListener where T : ActionEvent
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        private readonly Func<bool> _isCompletedCallback;

        protected MissionObjective(Func<bool> isCompletedCallback, string name, string description,
            ActionEventType type) : base(type)
        {
            _isCompletedCallback = isCompletedCallback;
            Name = name;
            Description = description;
        }

        public bool IsCompleted => _isCompletedCallback.Invoke();
    }
}