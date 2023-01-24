using CodeBase.Infrastructure;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ObstacleInstaller : MonoInstaller
{
    [SerializeField] private ObstacleService _obstacleService;
    public override void InstallBindings()
    {
        Container
            .Bind<ObstacleService>()
            .FromInstance(_obstacleService)
            .AsSingle();
    }
}
