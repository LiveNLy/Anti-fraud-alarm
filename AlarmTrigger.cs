using System;
using UnityEngine;

public class AlarmTrigger : MonoBehaviour
{
    [SerializeField] private Thief _thief;

    private float maxTargetVolume = 1f;
    private float minTargetVolume = 0f;

    public event Action<float> ThiefDetected;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Thief thief))
            ThiefDetected?.Invoke(maxTargetVolume);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Thief thief))
            ThiefDetected?.Invoke(minTargetVolume);
    }
}