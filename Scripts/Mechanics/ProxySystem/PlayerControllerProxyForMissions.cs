using Mechanics.Controller;

namespace Mechanics.ProxySystem
{
    public class PlayerControllerProxyForMissions : Proxy<PlayerController>
    {
        public PlayerControllerProxyForMissions(PlayerController dataClassInstance) : base(dataClassInstance)
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