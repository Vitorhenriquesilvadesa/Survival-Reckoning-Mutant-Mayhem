using Mechanics.MissionSystem;

namespace Mechanics.Event
{
    public class MissionCompletedEvent : MissionEvent
    {
        public MissionCompletedEvent(Mission mission) : base(mission)
        {
        }
    }
}