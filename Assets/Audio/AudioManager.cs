using System.Collections;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }

    [Header("--------- Audio Sources ---------")]
    public AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    [Header("--------- Audio Clip ------------")]
    public AudioClip background;
    public AudioClip tension;

    public float fadeDuration = 3f;

    private Coroutine fadeCoroutine;
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    private void Start()
    {
        musicSource.clip = background;
        musicSource.volume = 1f;
        musicSource.loop = true;
        musicSource.Play();

        SFXSource.clip = tension;
        SFXSource.volume = 0f;
        SFXSource.loop = true;
        SFXSource.Play();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("TouchPlayer");
            FadeToTension();
            //musicSource.Pause();
            //SFXSource.clip = tension;
            //SFXSource.loop = true;
            //SFXSource.Play();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            FadeToBackground();
            //SFXSource.Stop();
            //musicSource.UnPause();
        }
    }
    private void FadeToTension()
    {
        if (fadeCoroutine != null) StopCoroutine(fadeCoroutine);
        fadeCoroutine = StartCoroutine(FadeAudio(musicSource, SFXSource));
    }
    public void FadeToTensionClip(AudioClip clip)
    {
        SFXSource.clip = clip;
        SFXSource.Play();

        if (fadeCoroutine != null) StopCoroutine(fadeCoroutine);
        fadeCoroutine = StartCoroutine(FadeAudio(musicSource, SFXSource));
    }
    public void FadeToBackground()
    {
        if (fadeCoroutine != null) StopCoroutine(fadeCoroutine);
        fadeCoroutine = StartCoroutine(FadeAudio(SFXSource, musicSource));
    }
    IEnumerator FadeAudio(AudioSource from, AudioSource to)
    {
        float time = 0f;
        float startVol_From = from.volume;
        float startVol_To = to.volume;

        while (time < fadeDuration)
        {
            float t = time / fadeDuration;

            from.volume = Mathf.Lerp(startVol_From, 0f, t);
            to.volume = Mathf.Lerp(startVol_To, 1f, t);

            time += Time.deltaTime;
            yield return null;
        }

        from.volume = 0f;
        to.volume = 1f;
    }
}
