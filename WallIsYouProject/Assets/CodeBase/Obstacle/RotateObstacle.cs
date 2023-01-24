using UnityEngine;

public class RotateObstacle : MonoBehaviour
{
    public static bool IsObstacleRotate;
    [SerializeField] private GameObject _obstacle;
    [SerializeField] private float _speed;
    private Camera _camera;
    private Vector3 _startClickPosition;
    private bool isRotating;
    private void Start()
    {
        if (!IsObstacleRotate)
            return;
        _camera = Camera.main;
    }

    private void OnMouseDown()
    {
        if (!IsObstacleRotate)
            return;

        Ray ray = _camera.ScreenPointToRay(Input.touches[0].position);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            _startClickPosition = hit.point;
            isRotating = true;
        }
    }
    private void Update()
    {
        if (!IsObstacleRotate)
            return;
        if (isRotating)
        {

        Ray ray = _camera.ScreenPointToRay(Input.touches[0].position);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                Vector3 clickPoint = hit.point;
                Vector3 offset = clickPoint - _startClickPosition;
                if (Mathf.Abs(offset.x) > Mathf.Abs(offset.y))
                {
                    if (_startClickPosition.y > _obstacle.transform.position.y)
                    {
                        _obstacle.transform.Rotate(0f, 0, -offset.x * _speed);
                    }
                    else
                    {
                        _obstacle.transform.Rotate(0f, 0, offset.x * _speed);
                    }
                }
                else
                {
                    if (_startClickPosition.x > _obstacle.transform.position.x)
                    {
                        _obstacle.transform.Rotate(0f, 0, offset.y * _speed);
                    }
                    else
                    {
                        _obstacle.transform.Rotate(0f, 0, -offset.y * _speed);
                    }
                }
                _startClickPosition = clickPoint;
                Debug.Log(offset);
            }
        }

    }
    private void OnMouseUp()
    {
        if (!IsObstacleRotate)
            return;
        isRotating = false;
    }
}
