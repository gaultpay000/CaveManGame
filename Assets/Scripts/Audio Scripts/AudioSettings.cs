using UnityEngine;
using UnityEngine.Audio;

public class AudioSettings : MonoBehaviour
{
  public static AudioSettings Instance;

  [SerializeField] private AudioMixer mixer;

  private void Awake()
  {
    if (Instance != null)
    {
      Destroy(gameObject);
      return;
    }

    Instance = this;
    DontDestroyOnLoad(gameObject);

    Load();
  }

  float ToDB(float v)
  {
    return Mathf.Log10(Mathf.Clamp(v, 0.0001f, 1f)) * 20;
  }

  public void Load()
  {
    SetMaster(PlayerPrefs.GetFloat("Master", 1f));
    SetMusic(PlayerPrefs.GetFloat("Music", 1f));
    SetSFX(PlayerPrefs.GetFloat("SFX", 1f));
  }

  public float GetMaster() => PlayerPrefs.GetFloat("Master", 1f);
  public float GetMusic() => PlayerPrefs.GetFloat("Music", 1f);
  public float GetSFX() => PlayerPrefs.GetFloat("SFX", 1f);

  public void SetMaster(float v)
  {
    mixer.SetFloat("MasterVolume", ToDB(v));
    PlayerPrefs.SetFloat("Master", v);
  }

  public void SetMusic(float v)
  {
    mixer.SetFloat("MusicVolume", ToDB(v));
    PlayerPrefs.SetFloat("Music", v);
  }

  public void SetSFX(float v)
  {
    mixer.SetFloat("SFXVolume", ToDB(v));
    PlayerPrefs.SetFloat("SFX", v);
  }
}