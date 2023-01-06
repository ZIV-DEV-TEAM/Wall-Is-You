using UnityEngine;

public class MoveObstacle : MonoBehaviour
{
    public static bool IsObstacleMove;
    [SerializeField] private GameObject _obstacle;
    [SerializeField] private float _speed;
    private Vector3 _startClickPosition;
    private Vector2 _lastClickPosition;
    private Vector3 _offset;
    private Camera _camera;
    private void Start()
    {
        if (!IsObstacleMove)
            return;
        _camera = Camera.main;
    }
    private void OnMouseDown()
    {
        if (!IsObstacleMove)
            return;

        Ray ray = _camera.ScreenPointToRay(Input.touches[0].position);

        RaycastHit hit;
        Touch touch = Input.GetTouch(0);
        if (Physics.Raycast(ray, out hit))
        {
            _startClickPosition = touch.position;
        }
    }
    private void OnMouseDrag()
    {
        if (!IsObstacleMove)
            return;
        Touch touch = Input.GetTouch(0);
        if (_lastClickPosition == touch.position|| !(TouchPhase.Moved == touch.phase))
        {
            return;
        }
        Debug.Log("move");
        _lastClickPosition = Input.touches[0].position;

        Ray ray = _camera.ScreenPointToRay(Input.touches[0].position);

        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            Vector3 clickPoint = touch.position;
            if (Vector3.Distance(clickPoint, _startClickPosition) > 0)
            {
                Vector3 offset = clickPoint - _startClickPosition;
                _obstacle.transform.Translate((new Vector3(offset.x, offset.y, 0)).normalized * Time.deltaTime * _speed, Space.World);
                _startClickPosition = clickPoint;
            }
        }

    }

    private void OnMouseUp()
    {
        if (!IsObstacleMove)
            return;
        Debug.Log("Up");
    }
}
