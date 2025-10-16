using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    public AudioClip jumpSound;
    public AudioClip scoreSound;
    public AudioClip deathSound;
    public AudioClip runningSound;

    private AudioSource sfxSource;
    private AudioSource loopSource;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        sfxSource = gameObject.AddComponent<AudioSource>();
        loopSource = gameObject.AddComponent<AudioSource>();
        loopSource.loop = true;
    }

    public void PlayJump()
    {
        sfxSource.PlayOneShot(jumpSound);
    }

    public void PlayScore()
    {
        sfxSource.PlayOneShot(scoreSound);
    }

    public void PlayDeath()
    {
        sfxSource.PlayOneShot(deathSound);
    }

    public void StartRunning()
    {
        if (!loopSource.isPlaying)
        {
            loopSource.clip = runningSound;
            loopSource.Play();
        }
    }

    public void StopRunning()
    {
        if (loopSource.isPlaying)
        {
            loopSource.Stop();
        }
    }
}

