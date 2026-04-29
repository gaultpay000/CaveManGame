using UnityEngine;

public class Keypad : MonoBehaviour
{
  public string requiredKey; // "Red" or "Blue"
  public bool activated;

  public GameObject promptUI;

  private PlayerKeys player;

  private void OnTriggerEnter(Collider other)
  {
    player = other.GetComponent<PlayerKeys>();

    if (player != null && !activated)
      promptUI.SetActive(true);
  }

  private void OnTriggerExit(Collider other)
  {
    if (other.GetComponent<PlayerKeys>() != null)
    {
      promptUI.SetActive(false);
      player = null;
    }
  }

  private void Update()
  {
    if (player == null || activated) return;

    if (Input.GetKeyDown(KeyCode.E))
      TryUseKey();
  }

  void TryUseKey()
  {
    if (requiredKey == "Red" && player.hasRedKey)
    {
      player.RemoveKey("Red");
      Activate();
    }
    else if (requiredKey == "Blue" && player.hasBlueKey)
    {
      player.RemoveKey("Blue");
      Activate();
    }
  }

  void Activate()
  {
    activated = true;
    promptUI.SetActive(false);
  }
}