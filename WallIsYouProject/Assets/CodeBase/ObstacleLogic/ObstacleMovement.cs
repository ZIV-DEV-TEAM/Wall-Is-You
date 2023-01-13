using Assets.CodeBase.Services.Input;
using UnityEngine;
using Zenject;

public class ObstacleMovement : Obstacle
{
    public bool IsActive;
    [SerializeField] private float _moveSpeed = 1;
    [SerializeField] private float _rotateSpeed = 0.3f;
    [SerializeField] private GameObject[] _clons;

    private IInputService _mobileInputService;
    [Inject]
    public void Construct(IInputService inputService)
    {
        _mobileInputService = inputService;
    }

    private void Update()
    {
        if (!IsActive)
            return;
        if (_mobileInputService.Direction != Vector3.zero)
        {
            transform.Translate(_mobileInputService.Direction * _moveSpeed * Time.deltaTime, Space.World);
            foreach (GameObject item in _clons)
            {
                item.transform.Translate(_mobileInputService.Direction * _moveSpeed * Time.deltaTime, Space.World);
            }
        }
        if (_mobileInputService.RotateDirection != Vector3.zero)
        {
            transform.Rotate(_mobileInputService.RotateDirection * _rotateSpeed);
            foreach (GameObject item in _clons)
            {
                item.transform.Rotate(_mobileInputService.RotateDirection * _rotateSpeed);
            }
        }
    }
    private void OnDestroy()
    {
        foreach (GameObject item in _clons)
        {
            Destroy(item);
        }
    }
}
