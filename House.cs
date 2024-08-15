using UnityEngine;

public class House : MonoBehaviour
{
    [SerializeField] private AlarmTrigger _alarmTrigger;
    [SerializeField] private Alarm _alarm;

    private void OnEnable()
    {
        _alarmTrigger.thiefDiscovered += _alarm.ChangeSound;
    }
}
