using Mechanics.MissionSystem;

namespace Mechanics.Event
{
    public class MissionEvent : ActionEvent
    {
        public Mission Mission { get; private set; }
        
        public MissionEvent(Mission mission) : base(ActionEventType.MissionCompleted)
        {
            Mission = mission;
        }
    }
}