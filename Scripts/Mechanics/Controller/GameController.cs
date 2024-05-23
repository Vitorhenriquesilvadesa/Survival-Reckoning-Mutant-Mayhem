using System;
using Mechanics.Controller;
using Mechanics.ProxySystem;
using UnityEngine;

public class GameController : MonoBehaviour, IDataClass<GameController>
{
    private static GameController Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<GameController>();
                if (_instance == null)
                {
                    GameObject obj = new GameObject("GameController");
                    _instance = obj.AddComponent<GameController>();
                }
            }

            return _instance;
        }
    }

    private static GameController _instance;

    private PlayerController _playerController;

    private GameController()
    {
        ProxyFactory.Instance.AddProxyConstraints(this);
        ProxyFactory.Instance.AddProxyConstraints(_playerController);
    }

    public TProxyType GetProxyFor<TRequesterType, TProxyType>() where TProxyType : Proxy<GameController>
    {
        switch (typeof(TRequesterType))
        {
            case { } t when t == typeof(MissionController):
            {
                return new GameControllerProxyForMissions(this) as TProxyType;
            }

            default:
            {
                throw new AccessViolationException("No GameController proxy available for " + typeof(TRequesterType));
            }
        }
    }
}