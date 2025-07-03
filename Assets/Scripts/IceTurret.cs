using UnityEngine;

public class IceTurret : MonoBehaviour
{
    [Header("Turret Properties")]
    public int cost;
    public float detectionRange;
    public float speedModifierDenominator;

    [Space(5)]
    [Header("References")]
    public Transform detectionSphereCastPoint;

    private SphereCollider sphereCollider;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sphereCollider = GetComponent<SphereCollider>();

        sphereCollider.radius = detectionRange;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        EnemyAI detectedEnemy = other.GetComponent<EnemyAI>();

        if (detectedEnemy != null)
        {
            detectedEnemy.currentSpeed = detectedEnemy.speed / speedModifierDenominator;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        EnemyAI detectedEnemy = other.GetComponent<EnemyAI>();

        if (detectedEnemy != null)
        {
            detectedEnemy.currentSpeed = detectedEnemy.speed;
        }
    }
}
