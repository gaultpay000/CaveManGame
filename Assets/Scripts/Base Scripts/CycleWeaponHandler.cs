using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class CycleWeaponHandler : MonoBehaviour
{
    public UnityEvent CycleWeapon;
    public UnityEvent EquipClub;
    public UnityEvent EquipBow;
    public UnityEvent EquipSpear;

    public InputActionReference cycleWeaponAction;

    private void OnEnable()
    {
        //Debug.Log("switching weapon");
        cycleWeaponAction.action.Enable();
        //cycleWeaponAction.action.performed += OnCycleWeapon;
    }

    private void OnDisable()
    {
        //cycleWeaponAction.action.performed -= OnCycleWeapon;
        cycleWeaponAction.action.Disable();
    }

    //private void OnCycleWeapon(InputAction.CallbackContext context)
    //{
    //    CycleWeapon.Invoke();
    //}
}
