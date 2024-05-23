using Mechanics.Controller;

namespace Mechanics.ProxySystem
{
    public class GameControllerProxyForMissions : Proxy<GameController>
    {
        public GameControllerProxyForMissions(GameController gameController) : base(gameController)
        {
        }

    }
}