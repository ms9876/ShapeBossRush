using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField]
    private List<AudioClip> _audioClip = new List<AudioClip>();
    private AudioSource _audio;
    private float _audioVolume;

    private void Awake()
    {
        _audio = GetComponent<AudioSource>();
        _audioVolume = _audio.volume;
    }
    private void Start()
    {
        StartCoroutine("SecondBossAudioChanging");
    }
    IEnumerator SecondBossAudioChanging()
    {
        AudioChange(0);
        yield return new WaitForSeconds(14f);
        WorldManager.instance.ChangeWorldState(WorldState.BigBullet);
        yield return new WaitForSeconds(1f);
        AudioChange(1);
        yield return new WaitForSeconds(19f);
        WorldManager.instance.ChangeWorldState(WorldState.Followbullet2);
        AudioChange(2);
        yield return new WaitForSeconds(50f);
        AudioChange(3);
    }
    private void AudioChange(int idx)
    {

        StartCoroutine(AudioVolumeSet(idx));
    }
    float audioSetTime = 1f;
    IEnumerator AudioVolumeSet(int idx)
    {
        float currentTime = 0;
        while (audioSetTime / 2 > currentTime)
        {
            yield return new WaitForEndOfFrame();
            _audio.volume = Mathf.Lerp(_audioVolume, 0, currentTime / audioSetTime);
            currentTime += Time.deltaTime;
        }
        _audio.volume = 0;
        _audio.clip = _audioClip[idx];
        _audio.Play();
        currentTime = 0;
        while (audioSetTime / 2 > currentTime)
        {
            yield return new WaitForEndOfFrame();
            _audio.volume = Mathf.Lerp(0, _audioVolume, currentTime / audioSetTime);
            currentTime += Time.deltaTime;
        }
        _audio.volume = _audioVolume;
    }
}
