using UnityEngine;

public class RaycastBehavior : IWeaponBehavior
{
    public int range;

    GameObject hitGameObject;
    public void Fire(Transform firePoint)
    {
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, range))
        {
            hitGameObject = hit.collider.gameObject;
            Debug.Log($"something was hit: {hit.transform.name}");
            if (hitGameObject.GetComponent<Enemy>() != null)
            {
                hitGameObject.GetComponent<Enemy>().BeenShot();
            }
        }
    }
}
