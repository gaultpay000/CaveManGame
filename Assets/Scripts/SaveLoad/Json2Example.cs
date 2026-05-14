using UnityEngine;
using UnityEngine.InputSystem;

public class Json2Example : MonoBehaviour
{
    [SerializeField] WeaponSwitching weaponSwitching;
    [SerializeField] LoadPlayer loadPlayer;

    Transform playerPos;
    private void Update()
    {
        //if (Input.GetKeyDown(KeyCode.S))
        if(Keyboard.current.yKey.wasPressedThisFrame)
        {
            playerPos = FindAnyObjectByType<PlayerMovement>().transform;
            GUIDRegistry.SetWeapons(weaponSwitching.WEAPON_INVENTORY.ToArray());
            GUIDRegistry.Register("spawnPos", playerPos);
            SaveLoadBase.Save("Example", new GameData2());
        }

        //if (Input.GetKeyDown(KeyCode.L))
        if (Keyboard.current.lKey.wasPressedThisFrame)
        {
            //GameData2 data = SaveLoadBase.Load("Example");
            //data?.LoadData();
            loadPlayer.InstantiatePlayer();
        }
    }
}

