using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [HideInInspector] public float lifeTime;
    [HideInInspector] public int damage;

    void Start()
    {
        StartCoroutine(DestroySequence());
    }

    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        EnemyAI detectedEnemy = collision.gameObject.GetComponent<EnemyAI>();

        if (detectedEnemy != null)
        {
            Debug.Log($"Dealt {damage} points of damage via BULLET");

            detectedEnemy.TakeDamage(damage);

            Destroy(gameObject);
        }
    }

    IEnumerator DestroySequence()
    {
        yield return new WaitForSeconds(lifeTime);

        Destroy(gameObject);
    }
}
