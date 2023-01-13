using CodeBase.Infrastructure;
using CodeBase.Logic;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class StateInstaller : MonoInstaller, ICoroutineRunner
{
    [SerializeField] private LoadingCurtain _curtain;
    [SerializeField] private GameObject _scorePrefab;
    private Game GameMain;
    public override void InstallBindings()
    {
        Instantiate(_scorePrefab);
        Container
            .Bind<Score>()
            .FromComponentInNewPrefab(_scorePrefab)
            .AsSingle();
        BindState();
    }

    private void BindState()
    {
        Instantiate(_curtain.gameObject);
        GameMain = new Game(this, _curtain);
        Container
            .Bind<GameStateMachine>()
            .FromInstance(GameMain.StateMachine)
            .AsSingle();
    }
}
