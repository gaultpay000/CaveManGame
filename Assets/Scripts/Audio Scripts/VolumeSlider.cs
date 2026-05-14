using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
  public enum Type { Master, Music, SFX }
  public Type volumeType;

  Slider slider;

  void Start()
  {
    slider = GetComponent<Slider>();

    slider.minValue = 0.0001f;
    slider.maxValue = 1f;

    slider.value = volumeType switch
    {
      Type.Master => AudioSettings.Instance.GetMaster(),
      Type.Music => AudioSettings.Instance.GetMusic(),
      Type.SFX => AudioSettings.Instance.GetSFX(),
      _ => 1f
    };

    slider.onValueChanged.AddListener(OnChange);
  }

  void OnChange(float value)
  {
    switch (volumeType)
    {
      case Type.Master:
        AudioSettings.Instance.SetMaster(value);
        break;

      case Type.Music:
        AudioSettings.Instance.SetMusic(value);
        break;

      case Type.SFX:
        AudioSettings.Instance.SetSFX(value);
        break;
    }
  }
}