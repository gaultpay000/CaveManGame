using UnityEngine;

public class Projectile : MonoBehaviour
{
    Rigidbody rb;
    SphereCollider col;
    void Start()
    {
        col = GetComponent<SphereCollider>();
        rb = GetComponent<Rigidbody>();
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Enemy>() != null)
        {
            collision.gameObject.GetComponent<Enemy>().BeenShot();
        }
        rb.linearVelocity = Vector3.zero;
        rb.isKinematic = true;
        col.isTrigger = true;


    }
}
