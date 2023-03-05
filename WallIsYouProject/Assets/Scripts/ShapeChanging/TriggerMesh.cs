using System;
using System.Collections;
using System.Collections.Generic;
using Player;
using UnityEngine;

public class TriggerMesh : MonoBehaviour
{
    [SerializeField] private Mesh mesh;
    [SerializeField] private int idPoint = -1;
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out IInteractable interactable))
        {
            interactable.SetMesh(mesh);
            if (idPoint!=-1)
            {
                interactable.SetPosition(idPoint);
            }
        }
    }
}
