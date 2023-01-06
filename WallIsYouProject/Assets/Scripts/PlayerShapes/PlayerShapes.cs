using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShapes : MonoBehaviour
{
    [SerializeField] private Shape[] _shapes;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private Shape _curentShape;
    public void SwitchShape(Shape shapeType)
    {
        StartCoroutine(Switch(shapeType));
    }
    IEnumerator Switch(Shape shapeType)
    {
        yield return new WaitForSeconds(1);
        foreach (Shape shape in _shapes)
        {
            if (shapeType == shape)
            {
                if (_curentShape == shape)
                {
                    break;
                }
                Handheld.Vibrate();
                _curentShape = shape;
                shape.gameObject.SetActive(true);
                _audioSource.Play();
            }
            else
            {
                shape.gameObject.SetActive(false);
            }
        }
    }
}
