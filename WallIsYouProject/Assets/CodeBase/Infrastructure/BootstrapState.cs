using Assets.CodeBase.Services.Input;
using System.Diagnostics;

namespace CodeBase.Infrastructure
{
    public class BootstrapState : IPayloadedState<int>
    {
        private const string Initial = "Initial";
        private readonly SceneLoader _sceneLoader;
        private GameStateMachine _stateMachine;
        private int _level; 
        public BootstrapState(GameStateMachine stateMachine, SceneLoader sceneLoader)
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
        }

        public void Enter(int level)
        {
            RegisterServices();
            EnterLoadLevel();
            _level = level;
            _level = level < 1 ? 1 : level;
        }

        public void Exit()
        {
        }

        public void LoadData(GameData data)
        {
        }

        public void SaveData(GameData data)
        {
        }

        private void EnterLoadLevel() =>
          _stateMachine.Enter<LoadLevelState, int>(_level);

        private void RegisterServices()
        {
        }
    }
}