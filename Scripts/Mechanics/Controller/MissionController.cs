using System.Collections.Generic;
using Mechanics.Event;
using Mechanics.MissionSystem;
using Mechanics.ProxySystem;
using UnityEngine;

namespace Mechanics.Controller
{
    public class MissionController : EventEmitter<MissionEvent>
    {
        private readonly List<Mission> _missions = new();
        private readonly GameControllerProxyForMissions _gameControllerProxy;
        private readonly PlayerControllerProxyForMissions _playerControllerProxy;

        public MissionController()
        {
            _gameControllerProxy = ProxyFactory.Instance
                .GetProxyFor<MissionController, GameControllerProxyForMissions, GameController>();
            _playerControllerProxy = ProxyFactory.Instance
                .GetProxyFor<MissionController, PlayerControllerProxyForMissions, PlayerController>();
        }

        public void AddMission(Mission mission)
        {
            _missions.Add(mission);
        }

        public void CheckMissions()
        {
            foreach (var mission in _missions)
            {
                if (mission.VerifyCompleted())
                {
                    mission.GiveReward(_playerControllerProxy);
                    OnEmmit(new MissionCompletedEvent(mission));
                }
            }
        }
    }
}