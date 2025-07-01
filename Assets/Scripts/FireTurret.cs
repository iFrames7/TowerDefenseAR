using UnityEngine;

public class FireTurret : MonoBehaviour
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
}
