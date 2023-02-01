using UnityEngine;
using Zenject;

namespace Assets.CodeBase.ObstacleLogic
{
    public class ObstscleCompleted : MonoBehaviour
    {
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private ObstacleService _obstacleService;
        public int PlayerShapeNumber;

        private Score _score;
        [Inject]
        public void Construct(Score score)
        {
            _score = score;
        }
        public void Complite()
        {
            _obstacleService.SwitchObstacleToNext();
            _score.Add(1);
            _audioSource.Play();
            Handheld.Vibrate();
        }
    }
}