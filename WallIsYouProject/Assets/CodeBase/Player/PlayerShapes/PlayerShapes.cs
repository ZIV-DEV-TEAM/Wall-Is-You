using System;
using System.Collections;
using UnityEngine;

public class PlayerShapes : MonoBehaviour
{
    [SerializeField] private float _delayToSwapShape;
    [SerializeField] private Shape[] _shapes;
    [SerializeField] private GameObject[] _hints;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private Shape _curentShape;
    public void SwitchShape(int shapeType)
    {
        StartCoroutine(Switch(shapeType));
    }
    IEnumerator Switch(int shapeType)
    {
        Shape shape = _shapes[shapeType];
        yield return new WaitForSeconds(_delayToSwapShape);
        if (_curentShape == shape)
        {
            yield break;
        }
        Vibrate.TriggerVibrate();
        _curentShape.gameObject.SetActive(false);
        foreach (GameObject item in _hints)
        {
            item.SetActive(false);
        }
        _curentShape = shape;
        _hints[shapeType].SetActive(true);
        shape.gameObject.SetActive(true);
        _audioSource.Play();
    }
}
