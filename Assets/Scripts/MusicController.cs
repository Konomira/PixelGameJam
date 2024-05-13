using System.Collections;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    private static MusicController instance;

    public AudioSource menuMusic;
    public AudioSource gameMusic;
    public AudioSource creditsMusic;

    public float defaultVolume = 1.0f;
    private AudioSource oldSource;
    private void Awake()
    {
        if (instance != null)
            Destroy(gameObject);
        else
        {
            instance = this;
            oldSource = menuMusic;
        }
    }

    public static void SwitchToGame()
    {
        instance.StartCoroutine(instance.Transition(instance.gameMusic));
    }

    public static void SwitchToMenu()
    {
        instance.StartCoroutine(instance.Transition(instance.menuMusic));
    }

    public static void SwitchToCredits()
    {
        instance.StartCoroutine(instance.Transition( instance.creditsMusic));
    }

    private IEnumerator Transition(AudioSource newSource)
    {
        newSource.volume = 0f;

        var time = oldSource.time;

        time %= newSource.clip.length;
        newSource.time = time;
        float percentage = 0f;

        while (oldSource.volume > 0 && oldSource != newSource)
        {
            oldSource.volume = Mathf.Lerp(defaultVolume, 0, percentage);
            newSource.volume = Mathf.Lerp(0, defaultVolume, percentage);
            percentage += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        newSource.volume = defaultVolume;
        oldSource = newSource;
        yield break;
    }
}
