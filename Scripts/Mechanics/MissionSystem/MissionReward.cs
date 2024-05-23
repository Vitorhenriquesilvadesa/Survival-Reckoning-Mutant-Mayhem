using System;
using Mechanics.Controller;
using Mechanics.ProxySystem;

namespace Mechanics.MissionSystem
{
    public class MissionReward
    {
        private readonly Action<PlayerControllerProxyForMissions> _rewardCallback;
        private bool _isGiven;

        public void GiveFor(PlayerControllerProxyForMissions player)
        {
            if (!_isGiven)
            {
                _isGiven = true;
                _rewardCallback.Invoke(player);
                return;
            }

            throw new Exception("Cannot give the same reward one more time.");
        }
        
        public MissionReward(Action<PlayerControllerProxyForMissions> rewardCallback)
        {
            _rewardCallback = rewardCallback;
        }
    }
}