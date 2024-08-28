using System;
using UnityEngine;

public class AlarmTrigger : MonoBehaviour
{
    [SerializeField] private Thief _thief;

    public event Action<float> ThiefDetected;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Thief thief))
            ThiefDetected?.Invoke(1);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Thief thief))
            ThiefDetected?.Invoke(0);
    }
}