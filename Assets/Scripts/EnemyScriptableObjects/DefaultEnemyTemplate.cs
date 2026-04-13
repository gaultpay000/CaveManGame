using UnityEngine;
using XNode;

[CreateAssetMenu(fileName = "DefaultEnemyTemplate", menuName = "Scriptable Objects/DefaultEnemyTemplate")]
public class DefaultEnemyTemplate : ScriptableObject
{
    public int enemyHealth;
    public int enemyMaxHealth;

    public enum EnemyType
    {
        Melee,
        Ranged,
        Boss
    }
    public EnemyType enemyType;

    public NodeGraph behaviorTree = null;

    
}
