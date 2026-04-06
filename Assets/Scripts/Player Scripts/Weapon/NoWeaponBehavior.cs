using UnityEngine;

public class NoWeaponBehavior : IWeaponBehavior
{
    public void Fire(Transform firePoint)
    {
        firePoint = firePoint;
        Debug.Log("theres no weapon to use");
    }
}
