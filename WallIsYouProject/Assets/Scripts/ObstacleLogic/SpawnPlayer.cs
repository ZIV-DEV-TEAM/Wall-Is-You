using Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayer : MonoBehaviour
{
    [SerializeField] private Mesh meshClone;
    [SerializeField] private int idPoint;
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out IInteractable interactable))
        {
            gameObject.SetActive(false);
            interactable.Clone(meshClone, idPoint);
        }
    }
}
