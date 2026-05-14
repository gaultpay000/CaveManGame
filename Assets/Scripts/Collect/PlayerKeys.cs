using UnityEngine;
using System;

public class PlayerKeys : MonoBehaviour
{
  public bool hasRedKey;
  public bool hasBlueKey;

  public KeyUI ui;

  public Action onKeysChanged;

  private void OnTriggerEnter(Collider other)
  {
    KeyPickup key = other.GetComponentInParent<KeyPickup>();
    if (key == null) return;

    switch (key.keyType)
    {
      case KeyPickup.KeyType.Red:
        hasRedKey = true;
        break;

      case KeyPickup.KeyType.Blue:
        hasBlueKey = true;
        break;
    }

    if (ui != null)
      ui.UpdateKeys(hasRedKey, hasBlueKey);

    onKeysChanged?.Invoke();

    Destroy(key.gameObject);
  }

  public void RemoveKey(string type)
  {
    if (type == "Red") hasRedKey = false;
    if (type == "Blue") hasBlueKey = false;

    if (ui != null)
      ui.UpdateKeys(hasRedKey, hasBlueKey);

    onKeysChanged?.Invoke();
  }
}