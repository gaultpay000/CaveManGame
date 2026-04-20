using UnityEngine;

public class Projectile : MonoBehaviour
{
    Rigidbody rb;
    SphereCollider col;
    public bool collectable = false;
    void Start()
    {
        col = GetComponent<SphereCollider>();
        rb = GetComponent<Rigidbody>();
    }
    void OnCollisionEnter(Collision collision)
    {
        // if (collision.gameObject.GetComponent<Enemy>() != null)
        // {
        //     collision.gameObject.GetComponent<Enemy>().BeenShot();
        // }
        collectable = true;
        rb.linearVelocity = Vector3.zero;
        rb.isKinematic = true;
        col.isTrigger = true;
    }
}