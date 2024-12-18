using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundFXManager : MonoBehaviour
{
    public static SoundFXManager instace;

    [SerializeField] private AudioSource SoundFXObject;

    private void Awake()
    {
        if(instace == null)
            instace = this;
    }

    public void PlaySoundFXclip(AudioClip audioClip, Transform spawnTransform, float volume)
    {
        AudioSource audioSource = Instantiate(SoundFXObject, spawnTransform.position, Quaternion.identity);

        audioSource.clip = audioClip;

        audioSource.volume = volume;

        audioSource.Play();

        float clipLength = audioSource.clip.length;
        Debug.Log(clipLength);

        Destroy(audioSource.gameObject, clipLength);
    }


}
