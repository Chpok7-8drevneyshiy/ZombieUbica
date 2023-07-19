using UnityEngine;
public abstract class HP : MonoBehaviour
{
    public float MaxHP;
    [SerializeField] protected float currentHP;
    public abstract void TakeDamage(float damage);

    protected void Die(bool isDead)
    {
        if (isDead) 
        { 
            Destroy(gameObject); 
        }
    }
}
