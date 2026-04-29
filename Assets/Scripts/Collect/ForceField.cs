using UnityEngine;

public class ForceField : MonoBehaviour
{
  public Keypad redKeypad;
  public Keypad blueKeypad;

  private void Update()
  {
    if (redKeypad == null || blueKeypad == null) return;

    if (redKeypad.activated && blueKeypad.activated)
    {
      Destroy(gameObject);
    }
  }
}