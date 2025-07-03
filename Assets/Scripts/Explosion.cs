using UnityEngine;

public class Explosion : MonoBehaviour
{
    [HideInInspector] public int damage;
    [HideInInspector] public float lifeTime;
    [HideInInspector] public float scaleFactor;

    private Vector3 startSize;
    private Vector3 endSize;
    private float counter = 0.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startSize = transform.localScale;
        endSize = startSize * scaleFactor;
    }

    // Update is called once per frame
    void Update()
    {
        float percentage = counter / lifeTime;

        transform.localScale = Vector3.Lerp(startSize, endSize, percentage);

        counter += Time.deltaTime;

        if (percentage >= 1)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        EnemyAI detectedEnemy = other.GetComponent<EnemyAI>();

        if (detectedEnemy != null)
        {
            Debug.Log($"Dealt {damage} points of damage via EXPLOSION");

            detectedEnemy.TakeDamage(damage);
        }
    }
}
