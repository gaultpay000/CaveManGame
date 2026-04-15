using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamagable
{
    [SerializeField]DefaultEnemyTemplate enemyTemplate;

    int health;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        health = enemyTemplate.enemyHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        StartCoroutine(FlashRed());
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
    IEnumerator FlashRed()
    {
        Renderer renderer = GetComponent<Renderer>();
        Color originalColor = renderer.material.color;
        renderer.material.color = Color.red;
        yield return new WaitForSeconds(0.7f);
        renderer.material.color = originalColor;
    }   
}
