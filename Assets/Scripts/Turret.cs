using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    [Header("Turret Properties")]
    public int cost;
    public float delayBetweenShots;
    public float bulletForce;
    public int bulletDamage;
    public float bulletLifeTime;

    [Space(5)]
    [Header("Enemy Detection")]
    public float sphereCastRadius;

    [Space(5)]
    [Header("References")]
    public GameObject bullet;
    public Transform shootPoint;

    private bool shouldShoot = false;
    private float counter = 0.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Transform closestEnemy = GetClosestEnemy();

        transform.LookAt((closestEnemy != null) ? new Vector3(closestEnemy.position.x, transform.position.y, closestEnemy.position.z) : transform.forward);

        shouldShoot = (closestEnemy != null) ? true : false;

        counter += Time.deltaTime;

        if (shouldShoot)
        {
            ShootEnemy(closestEnemy);
        }
        else
        {
            counter = 0.0f;
        }
    }

    void ShootEnemy(Transform _enemyPosition)
    {
        if (counter > delayBetweenShots)
        {
            Vector3 directionToEnemy = _enemyPosition.position - shootPoint.position;

            Bullet currentBullet = Instantiate(bullet, shootPoint.position, Quaternion.identity).GetComponent<Bullet>();
            currentBullet.transform.forward = directionToEnemy.normalized;
            currentBullet.GetComponent<Rigidbody>().AddForce(directionToEnemy.normalized * bulletForce, ForceMode.Impulse);
            currentBullet.lifeTime = bulletLifeTime;
            currentBullet.damage = bulletDamage;

            counter = 0.0f;
        }
    }

    Transform GetClosestEnemy()
    {
        Transform bestTarget = null;
        float closestDistanceSqr = Mathf.Infinity;
        Vector3 currentPosition = transform.position;
        List<EnemyAI> tempEnemies = new();

        RaycastHit[] hits = Physics.SphereCastAll(currentPosition, sphereCastRadius, transform.forward, sphereCastRadius);

        foreach (RaycastHit hit in hits)
        {
            if (hit.transform.gameObject.GetComponent<EnemyAI>() != null)
            {
                tempEnemies.Add(hit.transform.gameObject.GetComponent<EnemyAI>());
            }
        }

        foreach (EnemyAI enemy in tempEnemies)
        {
            Vector3 directionToTarget = enemy.gameObject.transform.position - currentPosition;

            float dSqrToTarget = directionToTarget.sqrMagnitude;

            if (dSqrToTarget < closestDistanceSqr)
            {
                closestDistanceSqr = dSqrToTarget;
                bestTarget = enemy.gameObject.transform;
            }
        }

        return bestTarget;
    }
}