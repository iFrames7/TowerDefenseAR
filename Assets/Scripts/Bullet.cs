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
        if (collision.gameObject.GetComponent<EnemyTest>() != null)
        {
            Debug.Log($"Dealt {damage} points of damage via BULLET");
            Destroy(gameObject);
        }
    }

    IEnumerator DestroySequence()
    {
        yield return new WaitForSeconds(lifeTime);

        Destroy(gameObject);
    }
}
