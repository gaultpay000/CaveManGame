using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class Save : MonoBehaviour
{
  [SerializeField] private TMP_Text interactPrompt;
  [SerializeField] private TMP_Text savedPrompt;

  private bool playerInRange;

  private WeaponSwitching currentWeaponSwitching;

  void Start()
  {
    interactPrompt.gameObject.SetActive(false);
    savedPrompt.gameObject.SetActive(false);
  }

  void Update()
  {
    if (playerInRange && Keyboard.current.yKey.wasPressedThisFrame)
    {
      Debug.Log("saved");

      SaveFile(currentWeaponSwitching);

      StartCoroutine(ShowSavedMessage());
    }
  }

  void OnTriggerEnter(Collider other)
  {
    if (other.GetComponent<PlayerMovement>() != null)
    {
      playerInRange = true;

      currentWeaponSwitching = other.GetComponent<WeaponSwitching>();

      interactPrompt.gameObject.SetActive(true);
    }
  }

  void OnTriggerExit(Collider other)
  {
    if (other.GetComponent<PlayerMovement>() != null)
    {
      playerInRange = false;

      interactPrompt.gameObject.SetActive(false);
    }
  }

  System.Collections.IEnumerator ShowSavedMessage()
  {
    savedPrompt.gameObject.SetActive(true);
    yield return new WaitForSeconds(2f);
    savedPrompt.gameObject.SetActive(false);
  }

  void SaveFile(WeaponSwitching weaponSwitching)
  {
    Transform playerPos = FindAnyObjectByType<PlayerMovement>().transform;

    GUIDRegistry.SetWeapons(weaponSwitching.WEAPON_INVENTORY.ToArray());
    GUIDRegistry.Register("spawnPos", playerPos);
    SaveLoadBase.Save("Example", new GameData2());
  }
}