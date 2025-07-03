using UnityEngine;

public class FireTurret : TurretClass
{
    [Header("Turret Properties")]
    public int cost;
    public float delayBetweenExplosions;
    public int explosionDamage;
    public float explosionLifeTime;
    public float explosionScaleFactor;

    [Space(5)]
    [Header("References")]
    public GameObject explosion;
    public Transform explosionPoint;

    private float counter;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        counter = (delayBetweenExplosions + explosionLifeTime) / 2;
        turretCost = cost;
        turretLevel = 1;
        turretType = TurretType.Fire;

        cost += turretCost;
    }

    // Update is called once per frame
    void Update()
    {
        counter += Time.deltaTime;

        if (counter > delayBetweenExplosions + explosionLifeTime)
        {
            SpawnExplosion();
        }
    }

    void SpawnExplosion()
    {
        Explosion spawnedExplosion = Instantiate(explosion, explosionPoint.position, Quaternion.identity).GetComponent<Explosion>();
        spawnedExplosion.damage = explosionDamage;
        spawnedExplosion.lifeTime = explosionLifeTime;
        spawnedExplosion.scaleFactor = explosionScaleFactor;

        counter = 0.0f;
    }

    public void LevelUp(int _supposedLevel)
    {
        int levelChangeChecker = (_supposedLevel <= 1) ? 0 : 1;

        cost += turretCost * levelChangeChecker;
        explosionDamage += (int)(explosionDamage / 2) * levelChangeChecker;
        delayBetweenExplosions *= 0.75f * levelChangeChecker;
        explosionScaleFactor += explosionScaleFactor * 0.5f * levelChangeChecker;

        turretLevel = _supposedLevel;
    }
}
