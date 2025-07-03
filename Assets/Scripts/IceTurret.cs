using UnityEngine;

public class IceTurret : TurretClass
{
    [Header("Turret Properties")]
    public int cost;
    public float detectionRange;
    public float speedModifierDenominator;

    [Space(5)]
    [Header("References")]
    public Transform detectionSphereCastPoint;

    [HideInInspector] public TurretClass turretClass;

    private SphereCollider sphereCollider;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sphereCollider = GetComponent<SphereCollider>();

        sphereCollider.radius = detectionRange;

        turretCost = cost;
        turretLevel = 1;
        turretType = TurretType.Ice;

        cost += turretCost;
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

    public void LevelUp(int _supposedLevel)
    {
        int levelChangeChecker = (_supposedLevel <= 1) ? 0 : 1;

        cost += turretCost * levelChangeChecker;
        detectionRange += (detectionRange / 2) * levelChangeChecker;
        speedModifierDenominator += (speedModifierDenominator / 2) * levelChangeChecker;

        sphereCollider.radius = detectionRange;

        turretLevel = _supposedLevel;
    }
}
