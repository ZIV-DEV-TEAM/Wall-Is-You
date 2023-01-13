using CodeBase.Logic;
using UnityEngine;
using UnityEngine.UIElements;
using Zenject;

namespace CodeBase.Infrastructure
{
    public class GameBootstrapper : MonoBehaviour, ICoroutineRunner,IDataPersistence
    {
        private GameStateMachine _gameStateMachine;
        private int level;
        [Inject] 
        public void Constructor(GameStateMachine stateMachine)
        {
            _gameStateMachine = stateMachine;
        }

        public void LoadData(GameData data)
        {
            level = data.LevelNumber;
        }
        private void Awake()
        {
            DontDestroyOnLoad(this);
        }
        public void SaveData(GameData data)
        {
        }

        private void Start()
        {
            _gameStateMachine.Enter<BootstrapState, int>(level);
            DontDestroyOnLoad(gameObject);
        }
    }
}