using System.Collections;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    private static MusicController instance;

    public AudioClip menuMusic;
    public AudioClip gameMusic;
    public AudioSource audioSource;

    private void Awake()
    {
        if (instance != null)
            Destroy(gameObject);
        else 
            instance = this;
    }

    private void OnValidate()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public static void SwitchToGame()
    {
        instance.StartCoroutine(instance.Transition(instance.gameMusic));
    }

    public static void SwitchToMenu()
    {
        instance.StartCoroutine(instance.Transition(instance.menuMusic));
    }

    private IEnumerator Transition(AudioClip clip)
    {
        var time = audioSource.time;

        time %= clip.length;

        audioSource.clip = clip;
        audioSource.Play();
        audioSource.time = time;
        yield break;
    }
}
