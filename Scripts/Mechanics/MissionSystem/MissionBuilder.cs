using System.Collections.Generic;
using Mechanics.Event;

namespace Mechanics.MissionSystem
{
    public class MissionBuilder
    {
        private string _title;
        private string _description;
        private ActionEventType[] _types;
        private List<MissionAttribute<object>> _attributes = new();
        private List<MissionObjective<ActionEvent>> _objectives = new();
        private MissionReward _reward;

        public MissionBuilder WithTitle(string title)
        {
            _title = title;
            return this;
        }

        public MissionBuilder WithDescription(string description)
        {
            _description = description;
            return this;
        }

        public MissionBuilder WithAttributes(params MissionAttribute<object>[] attributes)
        {
            _attributes = new List<MissionAttribute<object>>(attributes);
            return this;
        }

        public MissionBuilder WithObjectives(params MissionObjective<ActionEvent>[] objectives)
        {
            _objectives = new List<MissionObjective<ActionEvent>>(objectives);
            return this;
        }

        public MissionBuilder WithReward(MissionReward reward)
        {
            _reward = reward;
            return this;
        }

        public MissionBuilder ListeningEventTypes(params ActionEventType[] types)
        {
            _types = types;
            return this;
        }

        public MissionSystem.Mission Build()
        {
            return new MissionSystem.Mission(new MissionTitle(_title), new MissionDescription(_description), _attributes,
                _objectives, _reward, _types);
        }
    }
}