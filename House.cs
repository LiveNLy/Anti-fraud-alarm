using UnityEngine;

public class House : MonoBehaviour
{
    [SerializeField] private AlarmTrigger _alarmTrigger;
    [SerializeField] private Alarm _alarm;

    private void OnEnable()
    {
        _alarmTrigger.ThiefDetected += _alarm.MakeSoundLouder;
    }

    private void OnDisable()
    {
        _alarmTrigger.ThiefDetected += _alarm.MakeSoundQuiter;
    }
}
