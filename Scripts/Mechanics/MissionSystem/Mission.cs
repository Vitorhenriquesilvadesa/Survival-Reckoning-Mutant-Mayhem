using System.Collections.Generic;
using Mechanics.Controller;
using Mechanics.Event;
using Mechanics.ProxySystem;

namespace Mechanics.MissionSystem
{
    public class Mission : MultipleEventTypeListener
    {
        public MissionTitle Title { get; private set; }
        public MissionDescription Description { get; private set; }
        public List<MissionAttribute<object>> Attributes { get; private set; }
        public List<MissionObjective<ActionEvent>> Objectives { get; private set; }
        public MissionReward Reward { get; private set; }

        public Mission(MissionTitle title, MissionDescription description, List<MissionAttribute<object>> attributes,
            List<MissionObjective<ActionEvent>> objectives, MissionReward reward, params ActionEventType[] types) : base(types)
        {
            Title = title;
            Description = description;
            Attributes = attributes;
            Objectives = objectives;
            Reward = reward;
        }

        public void AddObjective(MissionObjective<ActionEvent> objective)
        {
            Objectives.Add(objective);
        }

        public bool VerifyCompleted()
        {
            foreach (MissionObjective<ActionEvent> missionObjective in Objectives)
            {
                if (!missionObjective.IsCompleted)
                {
                    return false;
                }
            }

            return true;
        }

        public void GiveReward(PlayerControllerProxyForMissions player)
        {
            if (VerifyCompleted())
            {
                Reward.GiveFor(player);
            }
        }

        protected override void OnNotify(ActionEvent actionEvent)
        {
            foreach (MissionObjective<ActionEvent> missionObjective in Objectives)
            {
                missionObjective.OnNotify(actionEvent);
            }
        }
    }
}