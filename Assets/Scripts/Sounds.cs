using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sounds : MonoBehaviour
{
    public AudioClip[] sounds; // Массив звуков
    public SoundArrays[] randSound; // Массив звуков для случайного выбора

    private AudioSource audioSrc;

    private void Awake()
    {
        // Инициализируем AudioSource, если он не был добавлен
        audioSrc = GetComponent<AudioSource>();
        if (audioSrc == null)
        {
            audioSrc = gameObject.AddComponent<AudioSource>();
        }
    }

    public void PlaySound(int i, float volume = 1f, bool random = false, bool destroyed = false, float p1 = 0.85f, float p2 = 1.2f)
    {
        // Проверка на выход индекса за пределы массива
        if (i < 0 || i >= (random ? randSound.Length : sounds.Length))
        {
            Debug.LogError("Sound index out of range: " + i);
            return;
        }

        AudioClip clip;
        if (random)
        {
            // Случайный выбор из массива звуков
            clip = randSound[i].soundArray[Random.Range(0, randSound[i].soundArray.Length)];
        }
        else
        {
            clip = sounds[i];
        }

        // Установка случайного тона
        audioSrc.pitch = Random.Range(p1, p2);
        Debug.Log("Playing sound: " + clip.name);

        if (destroyed)
        {
            AudioSource.PlayClipAtPoint(clip, transform.position, volume);
        }
        else
        {
            audioSrc.PlayOneShot(clip, volume);
        }
    }

    [System.Serializable]
    public class SoundArrays
    {
        public AudioClip[] soundArray; // Массив аудиоклипов для случайного выбора
    }
}