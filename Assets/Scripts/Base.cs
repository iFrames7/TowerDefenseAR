using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Base : MonoBehaviour
{
    public static Base Instance{get; private set;}
    public EnemySpawner enemySpawner1;
    public EnemySpawner enemySpawner2;
    public EnemySpawner enemySpawner3;
    public EnemySpawner enemySpawner4;
    public int baseMaxHealth;
    private int baseCurrentHealth;
    public Slider healthBar;
    public TextMeshProUGUI gameOverText;
    
    
    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }
    void Start()
    {
        baseCurrentHealth = baseMaxHealth;
        healthBar.maxValue = baseMaxHealth;
        UpdateHealthBar();

    }

    private void OnTriggerEnter(Collider other)
    {
        EnemyAI enemyScript = other.gameObject.GetComponent<EnemyAI>();
        if (enemyScript != null)
        {
            DealDamage(10);
            Destroy(other.gameObject);
        }
    }

    public void DealDamage(int damageAmount)
    {
        baseCurrentHealth -= damageAmount;
        baseCurrentHealth = Mathf.Max(baseCurrentHealth, 0);
        UpdateHealthBar();
        if (baseCurrentHealth <= 0)
        {
            gameOverText.gameObject.SetActive(true);
            gameOverText.text = "Game Over";
            BaseLost();
            Destroy(this.gameObject);
        }
    }
    
    void UpdateHealthBar()
    {
        healthBar.value = baseCurrentHealth;
    }
    public void BaseDetected()
    {
        Renderer renderer = GetComponent<Renderer>();
        if (renderer != null)
        {   
            renderer.enabled = true;
            Debug.Log("Base detected");
        }

        enemySpawner1.ActivateSpawner();
        enemySpawner2.ActivateSpawner();
        enemySpawner3.ActivateSpawner();
        enemySpawner4.ActivateSpawner();
    }
    public void BaseLost()
    {
        Renderer renderer = GetComponent<Renderer>();
        if (renderer != null)
        {
            renderer.enabled = false;
            Debug.Log("Base lost");
        }
        enemySpawner1.DeactivateSpawner();
        enemySpawner2.DeactivateSpawner();
        enemySpawner3.DeactivateSpawner();
        enemySpawner4.DeactivateSpawner();
    }
}
