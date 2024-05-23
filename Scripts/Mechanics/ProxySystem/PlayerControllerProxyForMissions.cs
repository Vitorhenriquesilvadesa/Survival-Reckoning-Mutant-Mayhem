using Mechanics.Controller;

namespace Mechanics.ProxySystem
{
    public class PlayerControllerProxyForMissions : Proxy<PlayerController>
    {
        public PlayerControllerProxyForMissions(PlayerController dataClass) : base(dataClass)
        {
        }
        
        
        public void GetPlayerInventory()
        {
            
        }

        public void GetPlayerProperties()
        {
            
        }
    }
}