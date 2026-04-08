using UnityEngine;

public class RaycastBehavior : IWeaponBehavior
{
    public int range;
    public void Fire(Transform firePoint)
    {
        RaycastHit hit;
        if (Physics.Raycast(firePoint.position, firePoint.forward, out hit, range))
        {
            Debug.Log($"something was hit: {hit.transform.name}");
        }
    }
}
