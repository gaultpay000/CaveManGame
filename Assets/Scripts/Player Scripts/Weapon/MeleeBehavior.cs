using UnityEngine;

public class MeleeBehavior : IWeaponBehavior
{
    public Club club;
    public void Fire(Transform firePoint)
    {
        if (club.isLaunchable)
        {
            club.Launch();
        }
            
    }
}
