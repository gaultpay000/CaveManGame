using UnityEngine;

public class UIAudioPlayer : MonoBehaviour
{
  public static UIAudioPlayer Instance;

  [SerializeField] private AudioSource uiSource;

  private void Awake()
  {
    Instance = this;
  }

  public void PlayClick()
  {
    uiSource.Play();
  }
}