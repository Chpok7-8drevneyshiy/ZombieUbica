public class EnemyHP : HP
{
    private void Start()
    {
        currentHP = MaxHP;
    }
    public override void TakeDamage(float damage)
    {
        currentHP -= damage;
        
        if (currentHP <= 0 )
        {
            Die(true); return;
        }
        
    }
}
