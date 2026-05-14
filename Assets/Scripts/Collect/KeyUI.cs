using UnityEngine;

public class KeyUI : MonoBehaviour
{
  public GameObject redIcon;
  public GameObject blueIcon;

  public void UpdateKeys(bool red, bool blue)
  {
    redIcon.SetActive(red);
    blueIcon.SetActive(blue);
  }
}