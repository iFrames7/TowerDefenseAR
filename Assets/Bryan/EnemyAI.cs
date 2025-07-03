using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public Transform targetBase;
    public float speed = 3.0f;
    public float health = 100.0f;

    [HideInInspector] public float currentSpeed;

    private void Start()
    {
        currentSpeed = speed;
    }

    void Update()
    {
        if (targetBase == null)
            return;

        Vector3 direction = (targetBase.position - transform.position).normalized;
        transform.position += direction * currentSpeed * Time.deltaTime;
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0f)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
