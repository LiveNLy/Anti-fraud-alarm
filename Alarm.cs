using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class Alarm : MonoBehaviour
{
    private AudioSource _audioSource;
    private Coroutine _checkAudioSourse;
    private float _soundChanger;
    private float numberOfVoiceChange = 0.5f;
    private float targetVolume = 1;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _checkAudioSourse = StartCoroutine(CheckAudioSourse());
    }

    private void Update()
    {
        _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, targetVolume, (numberOfVoiceChange * _soundChanger) * Time.deltaTime);
    }

    public void ChangeSound(float changer)
    {
        if (_audioSource.volume == 0)
            _audioSource.Play();

        _soundChanger = changer;
    }

    private IEnumerator CheckAudioSourse()
    {
        int secondsToCheck = 3;

        while (true)
        {
            if (_audioSource.volume == 0)
                _audioSource.Stop();

            yield return new WaitForSeconds(secondsToCheck);
        }
    }
}