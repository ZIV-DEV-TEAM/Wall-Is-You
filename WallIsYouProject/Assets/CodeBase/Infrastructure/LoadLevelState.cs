using CodeBase.CameraLogic;
using CodeBase.Logic;
using UnityEngine;

namespace CodeBase.Infrastructure
{
    public class LoadLevelState : IPayloadedState<int>
    {

        private readonly GameStateMachine _stateMachine;
        private readonly SceneLoader _sceneLoader;
        private readonly LoadingCurtain _loadingCurtain;

        public LoadLevelState(GameStateMachine gameStateMachine, SceneLoader sceneLoader, LoadingCurtain loadingCurtain)
        {
            _stateMachine = gameStateMachine;
            _sceneLoader = sceneLoader;
            _loadingCurtain = loadingCurtain;
        }

        public void Enter(int sceneName)
        {
            _loadingCurtain.Show();
            _sceneLoader.Load(sceneName, OnLoaded);
        }

        public void Exit() =>
          _loadingCurtain.Hide();

        private void OnLoaded()
        {
            _stateMachine.Enter<GameLoopState>();
        }

        private static GameObject Instantiate(string path)
        {
            var prefab = Resources.Load<GameObject>(path);
            return Object.Instantiate(prefab);
        }

        private static GameObject Instantiate(string path, Vector3 at)
        {
            var prefab = Resources.Load<GameObject>(path);
            return Object.Instantiate(prefab, at, Quaternion.identity);
        }
    }
}