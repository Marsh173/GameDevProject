using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip defaultAmbience;

    private AudioSource grass_Ambience, house_Ambience;
    private bool isPlayingGrass;

    public static AudioManager instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    private void Start()
    {
        grass_Ambience = gameObject.AddComponent<AudioSource>();
        house_Ambience = gameObject.AddComponent<AudioSource>();


        isPlayingGrass = true;

        SwapTrack(defaultAmbience);
    }

    public void SwapTrack(AudioClip newClip)
    {
        StopAllCoroutines();

        StartCoroutine(FadeTrack(newClip));

        isPlayingGrass = !isPlayingGrass;
    }

    public void ReturntoDefault()
    {
        SwapTrack(defaultAmbience);
    }

    private IEnumerator FadeTrack(AudioClip newClip)
    {
        float timeToFade = 1.25f;
        float timeElapsed = 0;

        if (isPlayingGrass)
        {
            house_Ambience.clip = newClip;
            house_Ambience.Play();
            while(timeElapsed < timeToFade)
            {
                house_Ambience.volume = Mathf.Lerp(0, 1, timeElapsed / timeToFade);
                grass_Ambience.volume = Mathf.Lerp(1, 0, timeElapsed / timeToFade);
                timeElapsed += Time.deltaTime;
                yield return null;
            }

            grass_Ambience.Stop();
        }
        else
        {
            grass_Ambience.clip = newClip;
            grass_Ambience.Play();

            while (timeElapsed < timeToFade)
            {
                grass_Ambience.volume = Mathf.Lerp(0, 1, timeElapsed / timeToFade);
                house_Ambience.volume = Mathf.Lerp(1, 0, timeElapsed / timeToFade);
                timeElapsed += Time.deltaTime;
                yield return null;
            }
            house_Ambience.Stop();
        }
    }
}
