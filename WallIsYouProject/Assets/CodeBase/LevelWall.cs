using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class LevelWall : MonoBehaviour
{
    private UIMenu _UIMenu;

    [Inject]
    public void Construct(UIMenu UIMenu)
    {
        _UIMenu = UIMenu;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Obstacle>(out Obstacle obstacle))
        {
            _UIMenu.ActiveMenuLose();
        }
    }
}
