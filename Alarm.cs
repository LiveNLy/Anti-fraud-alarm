using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class Alarm : MonoBehaviour
{
    private AudioSource _audioSource;
    private Coroutine _checkAudioSourse;
    private float _numberOfVoiceChange = 0.1f;
    private float _waitingTimeOfCoroutine = 0.5f;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void MakeSoundLouder(float number)
    {
        if (_checkAudioSourse != null)
        {
            StopCoroutine(_checkAudioSourse);
        }

        _checkAudioSourse = StartCoroutine(StartAudioSourse(number));
    }

    public void MakeSoundQuiter(float targetVolume)
    {
        StopCoroutine(_checkAudioSourse);
        _checkAudioSourse = StartCoroutine(StartAudioSourse(targetVolume));
    }

    private IEnumerator StartAudioSourse(float targetVolume)
    {
        var waitingTime = new WaitForSeconds(_waitingTimeOfCoroutine);

        if (_audioSource.volume == 0)
        {
            _audioSource.Play();
        }

        while (_audioSource.volume != targetVolume)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, targetVolume, _numberOfVoiceChange);

            yield return waitingTime;
        }

        if (_audioSource.volume == 0)
        {
            _audioSource.Stop();
        }
    }
}