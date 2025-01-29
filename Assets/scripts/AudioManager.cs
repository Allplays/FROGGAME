using UnityEngine;

public class AudioManager : MonoBehaviour
{

    [Header("Audio Source")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource generalSfxSource;
    [SerializeField] AudioSource animeGirlSfxSource;
    [SerializeField] AudioSource lennonSfxSource;
    [SerializeField] AudioSource chimiSfxSource;
    [SerializeField] AudioSource enemySfxSource;

    [Header("Music")]
    public AudioClip mainTheme;

    [Header("Anime Girl Sfx")]
    public AudioClip stepsSfx;

    [Header("Chimi Sfx")]
    public AudioClip chimiIdleSfx;
    public AudioClip chimiCollectSfx;
    public AudioClip chimiPinchSfx;

    [Header("Lennon Sfx")]
    public AudioClip lennonIdleSfx;
    public AudioClip lennonMunchSfx; //Esta bug, habría que editar la pista de audio
    public AudioClip lennonPinchSfx;

    [Header("Enemy Sfx")]
    public AudioClip enemyIdleSfx;
    public AudioClip enemyDeathSfx;

    [Header("Poppy Sfx")]
    public AudioClip poppyIdleSfx;
    public AudioClip poppyWorktSfx;
    public AudioClip poppyPinchSfx;

    [Header("General SFX")]
    public AudioClip ipadMenuSfx;
    public AudioClip failSfx;
    public AudioClip InventorySfx;
    public AudioClip ItemDropSfx;
    public AudioClip ItemPickUpSfx;
    public AudioClip notificationSfx;
    public AudioClip SuccessSfx;
    public AudioClip textSfx;

    public float stepsSfxDuration;
    public float enemyIdleSfxDuration;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        musicSource.clip = mainTheme;
        musicSource.loop = true;
        musicSource.Play();

        animeGirlSfxSource.loop = true;

        stepsSfxDuration = stepsSfx.length;
        enemyIdleSfxDuration = enemyIdleSfx.length;
    }

    public void PlayGeneralSfx(AudioClip sfx)
    { generalSfxSource.PlayOneShot(sfx); }
    public void PlayAnimeGirlSfx(AudioClip sfx)
    { animeGirlSfxSource.PlayOneShot(sfx); }
    public void StopAnimeGirlSfx()
    { animeGirlSfxSource.Stop(); }
    public void PlayLennonSfx(AudioClip sfx)
    { lennonSfxSource.PlayOneShot(sfx); }

    public void PlayChimiSfx(AudioClip sfx)
    { chimiSfxSource.PlayOneShot(sfx); }

    public void PlayEnemySfx(AudioClip sfx)
    { enemySfxSource.PlayOneShot(sfx); }
}
