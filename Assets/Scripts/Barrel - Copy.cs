using System.Collections;
using UnityEngine;

public class Barrel : MonoBehaviour, IDamageable
{

    [SerializeField] private float _explodeRadius;


    [SerializeField] private bool _drawGizmos;
    [SerializeField] private Color _color = Color.red;

    [SerializeField] private bool _boomOnStart;
    [SerializeField] private bool _hasAlreadyBoomed;
    public void Start()
    {
        if (_boomOnStart)
        {
            TakeDamage();
        }
    }

    public void Boom()
    {
        if (_hasAlreadyBoomed)
        {
            return;
        }

       _hasAlreadyBoomed = true;

        Collider[] foundObjects = Physics.OverlapSphere(transform.position, _explodeRadius);

        for (int i = 0; i < foundObjects.Length; i++)
        {
            foundObjects[i].GetComponent<IDamageable>()?.TakeDamage();
        }

        Destroy(gameObject);
    }

    private void OnDrawGizmos()
    {
        if(_drawGizmos == false)
        {
            return;
        }

        Gizmos.color = _color;
        Gizmos.DrawWireSphere(transform.position, _explodeRadius);
    }

    public void TakeDamage()
    {
        StartCoroutine(DelayBoom());
    }
    IEnumerator DelayBoom()
    {
        gameObject.GetComponent<MeshRenderer>().material.color = new Color(1f, 0, 0);
        gameObject.transform.localScale += new Vector3(0.25f, 0, 0.25f);
        yield return new WaitForSeconds(1f);
        Boom();
    }
}



public interface IDamageable
{
    void TakeDamage();
}