using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class Sounds : MonoBehaviour
{
    public AudioClip[] sounds;

    private AudioSource audioSrc;

    void Start()
    {
        // Проверяем наличие AudioSource и добавляем, если его нет
        audioSrc = GetComponent<AudioSource>();
        if (audioSrc == null)
        {
            audioSrc = gameObject.AddComponent<AudioSource>();
        }
    }

    public void PlaySound(AudioClip clip, float volume = 1f, bool destroyed = false, float p1 = 1f, float p2 = 1f)
    {
        audioSrc.pitch = Random.Range(p1, p2);
        audioSrc.PlayOneShot(clip, volume);
    }
}
