using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Save : MonoBehaviour
{
    [SerializeField]GameObject uiElement;
    void OnTriggerStay(Collider other)
    {
        if(other.GetComponent<PlayerMovement>() != null)
        {
            // add UI element to show the ability to save here
            //GetComponent<UISaveIcon>().Savable();
            if (Keyboard.current.yKey.wasPressedThisFrame)
            {
                Debug.Log("saved");    
                SaveFile(other.GetComponent<WeaponSwitching>());
            }
        }
    }
    void OnTriggerExit(Collider other)
    {
        //GetComponent<UISaveIcon>().Unsavable();
        uiElement.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        uiElement.SetActive(true);
    }

    void SaveFile(WeaponSwitching weaponSwitching)
    {
        Transform playerPos = FindAnyObjectByType<PlayerMovement>().transform;
        GUIDRegistry.SetWeapons(weaponSwitching.WEAPON_INVENTORY.ToArray());
        GUIDRegistry.Register("spawnPos", playerPos);
        SaveLoadBase.Save("Example", new GameData2());
    }
}
