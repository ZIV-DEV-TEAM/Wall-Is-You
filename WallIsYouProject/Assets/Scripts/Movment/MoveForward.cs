using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Rigidbody _playerRigidbody;
    private void FixedUpdate()
    {
        _playerRigidbody.velocity = _speed* Vector3.forward;
    }
}
