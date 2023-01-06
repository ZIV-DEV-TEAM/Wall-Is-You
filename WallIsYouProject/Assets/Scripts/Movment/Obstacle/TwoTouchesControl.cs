using UnityEngine;

public class TwoTouchesControl : MonoBehaviour
{
    [SerializeField] private GameObject _obstacle;
    [SerializeField] private float _speedRotate;
    [SerializeField] private float _speedMove;
    private Vector2 _startMovePosition;
    private Vector2 _startRotatePosition1;
    private Vector2 _startRotatePosition2;
    private void Update()
    {
        if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    _startMovePosition = touch.position;
                    break;

                case TouchPhase.Moved:
                    Vector2 direction = touch.position - _startMovePosition;
                    _obstacle.transform.Translate(direction * Time.deltaTime * _speedMove, Space.World);
                    _startMovePosition = touch.position;
                    break;
            }
        }
        if (Input.touchCount == 2)
        {
            Touch touch1 = Input.GetTouch(0);
            Touch touch2 = Input.GetTouch(1);
            switch (touch1.phase)
            {
                case TouchPhase.Began:
                    if (touch2.phase == TouchPhase.Began)
                    {
                        _startRotatePosition1 = touch1.position;
                        _startRotatePosition2 = touch2.position;
                    }
                    break;

                case TouchPhase.Moved:
                    if (touch2.phase == TouchPhase.Moved)
                    {
                        if (touch1.position.x> _startRotatePosition1.x&& touch2.position.x > _startRotatePosition2.x)
                        {
                            _obstacle.transform.Rotate(Vector3.forward * _speedRotate);
                        }
                        else if(touch1.position.x < _startRotatePosition1.x && touch2.position.x < _startRotatePosition2.x) {
                            _obstacle.transform.Rotate(-Vector3.forward * _speedRotate);
                        }
                        _startRotatePosition1 = touch1.position;
                        _startRotatePosition2 = touch2.position;
                    }
                    break;
            }
        }
    }
}
