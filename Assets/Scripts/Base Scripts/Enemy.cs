using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamagable
{
    [SerializeField] private DefaultEnemyTemplate enemyTemplate;

    private int health;
    private Renderer enemyRenderer;

    void Start()
    {
        health = enemyTemplate.enemyHealth;

        enemyRenderer = GetComponentInChildren<Renderer>();

        if (enemyRenderer == null)
        {
            Debug.LogWarning("Dont Crash Plz.");
        }
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
        if (enemyRenderer == null)
            yield break;

        Color originalColor = enemyRenderer.material.color;

        enemyRenderer.material.color = Color.red;

        yield return new WaitForSeconds(0.7f);

        enemyRenderer.material.color = originalColor;
    }
}