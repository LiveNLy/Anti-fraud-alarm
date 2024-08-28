using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class Alarm : MonoBehaviour
{
    private AudioSource _audioSource;
    private Coroutine _checkAudioSourse;
    private float _numberOfVoiceChange = 0.1f;
    private float _targetVolume;

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

    public void MakeSoundQuiter(float number)
    {
        StopCoroutine(_checkAudioSourse);
        _checkAudioSourse = StartCoroutine(StartAudioSourse(number));
    }

    private IEnumerator StartAudioSourse(float number)
    {
        _targetVolume = number;

        if (_audioSource.volume == 0)
        {
            _audioSource.Play();
        }

        while (_audioSource.volume != _targetVolume)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, _targetVolume, _numberOfVoiceChange);

            yield return new WaitForSeconds(0.5f);
        }

        if (_audioSource.volume == 0)
        {
            _audioSource.Stop();
        }
    }
}