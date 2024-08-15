using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AlarmTrigger : MonoBehaviour
{
    [SerializeField] private Thief _thief;

    private AudioSource _audioSource;
    private float _volumeOfAlarm = 0;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.Play();
    }

    private void Update()
    {
        _audioSource.volume = _volumeOfAlarm;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Thief thief))
        {
            StopAllCoroutines();
        }

        StartCoroutine(LouderAlarm());
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Thief thief))
        {
            StopAllCoroutines();
        }

        StartCoroutine(QuiterAlarm());
    }

    private IEnumerator LouderAlarm()
    {
        float numberOfVoiceChange = 0.05f;
        float waitForSeconds = 0.5f;

        for (float i = _volumeOfAlarm; i < 1; i += numberOfVoiceChange)
        {
            _volumeOfAlarm = i;

            yield return new WaitForSeconds(waitForSeconds);
        }
    }

    private IEnumerator QuiterAlarm()
    {
        float numberOfVoiceChange = 0.05f;
        float waitForSeconds = 0.5f;

        for (float i = _volumeOfAlarm; i > 0; i -= numberOfVoiceChange)
        {
            _volumeOfAlarm = i;

            yield return new WaitForSeconds(waitForSeconds);
        }
    }
}
