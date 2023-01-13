using System.Collections;
using UnityEngine;

public class PlayerShapes : MonoBehaviour
{
    [SerializeField] private float _delayToSwapShape;
    [SerializeField] private Shape[] _shapes;
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
        Handheld.Vibrate();
        _curentShape.gameObject.SetActive(false);
        _curentShape = shape;
        shape.gameObject.SetActive(true);
        _audioSource.Play();
    }
}
