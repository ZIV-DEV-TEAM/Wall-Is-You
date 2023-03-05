
using UnityEngine;

namespace Player
{
    public interface IInteractable
    {
        public void Die();
        public void AddScore(int score);
        public void SetPosition(int key);
        public void SetMesh(Mesh newMesh);
        public void Clone(Mesh newMesh, int key);
    }
}