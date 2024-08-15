using System;
using UnityEngine;

public class AlarmTrigger : MonoBehaviour
{
    [SerializeField] private Thief _thief;

    public event Action<float> thiefDiscovered;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Thief thief))
            thiefDiscovered?.Invoke(1);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Thief thief))
            thiefDiscovered?.Invoke(-1);
    }
}