using Mechanics.Controller;

namespace Mechanics.ProxySystem
{
    public class PlayerControllerProxyForMissions : Proxy<PlayerController>
    {
        public PlayerControllerProxyForMissions(PlayerController dataClassInstance) : base(dataClassInstance)
        {
        }
        
        // Metodos do PlayerController a serem expostos ao mission controller.
        public void GetPlayerInventory()
        {
            
        }

        public void GetPlayerProperties()
        {
            
        }
    }
}