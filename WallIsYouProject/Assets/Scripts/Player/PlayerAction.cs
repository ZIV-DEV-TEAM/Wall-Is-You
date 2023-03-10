using Bank;
using DG.Tweening;
using OnlineLeaderboards;
using UI;
using UnityEngine;

namespace Player
{
    public class PlayerAction : MonoBehaviour, IInteractable, IInit<Die>
    {
        [SerializeField] private Rigidbody rigidbody;
        [SerializeField] private float speed = 5f;
        [SerializeField] private Score score;
        [SerializeField] private Death deathBank;
        [SerializeField] private MeshFilter meshFilter;
        [SerializeField] private MeshCollider meshCollider;

        private PositionController _positionController;

        public bool _isPaused;
        private bool _isDead;
        private float _currentSpeed;
        private ChangeMesh _changeMesh;
        private event Die _die;
        private Reborn _reborn;

        private PauseDelegate _pauseDelegate;
        private Vector3 _direction;

        public Reborn RebornDelegate => _reborn;
        public PauseDelegate PauseDelegate => _pauseDelegate;
        public Score Score => score;
        public Death DeathBank => deathBank;

        public void Construct(PositionController positionController, bool isPaused, bool isDead, ChangeMesh changeMesh,
            Die die, Reborn reborn, PauseDelegate pauseDelegate, Vector3 direction)
        {
            _positionController = positionController;
            _isPaused = isPaused;
            _isDead = isDead;
            _changeMesh = changeMesh;
            _die = die;
            _reborn = reborn;
            _pauseDelegate = pauseDelegate;
            _direction = direction;
        }

        void Awake()
        {
            _changeMesh = new ChangeMesh(meshCollider, meshFilter);
            _direction = Vector3.forward;
            _pauseDelegate = Pause;
            _reborn = Reborn;
        }

        void FixedUpdate()
        {
            if (_isDead || _isPaused) _currentSpeed = 0;
            else _currentSpeed = speed;
            rigidbody.velocity = _direction * _currentSpeed;
        }

        public void AddScore(int value = 1)
        {
            score.Add(value);
        }

        public void Die()
        {
            _isDead = true;
            deathBank.Add(1);
            _die?.Invoke();
        }

        private void Pause()
        {
            _isPaused = !_isPaused;
        }

        private void Reborn()
        {
            _isDead = false;
            transform.DOMoveZ(transform.position.z - 15, 0.5f);
        }

        public void Initialize(Die @delegate)
        {
            _die += @delegate;
        }

        public void SetPositionController(PositionController positionControl)
        {
            _positionController = positionControl;
        }

        public void SetPosition(int key)
        {
            var position = _positionController.GetPosition(key).transform.position;
            transform.DOMoveX(position.x, 0.5f);
            transform.DOMoveY(position.y, 0.5f);
        }


        public void SetMesh(Mesh newMesh)
        {
            _changeMesh.SetMesh(newMesh);
        }

        public void Clone(Mesh newMesh, int key)
        {
            var clone = Instantiate(this);
            clone.Construct(_positionController, _isPaused, _isDead, _changeMesh, _die, _reborn, _pauseDelegate,
                _direction);
            clone.SetPosition(key);
            clone.SetMesh(newMesh);
        }
    }

    public delegate void Reborn();

    public delegate void Die();
}