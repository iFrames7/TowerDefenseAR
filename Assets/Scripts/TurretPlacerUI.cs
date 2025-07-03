using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TurretPlacerUI : MonoBehaviour
{
    [Header("Turret references")]
    public Turret turret;
    public FireTurret fireTurret;
    public IceTurret iceTurret;

    [Space(5)]
    [Header("UI references")]
    public Button normalTurretButton;
    public Button fireTurretButton;
    public Button iceTurretButton;
    
    private TurretSpawner spawner;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameObject.SetActive(false);
    }

    public void ActivateUI()
    {
        normalTurretButton.GetComponentInChildren<TextMeshProUGUI>().text = $"{turret.name} \nCost: {turret.cost}";
        fireTurretButton.GetComponentInChildren<TextMeshProUGUI>().text = $"{fireTurret.name} \nCost: {fireTurret.cost}";
        iceTurretButton.GetComponentInChildren<TextMeshProUGUI>().text = $"{iceTurret.name} \nCost: {iceTurret.cost}";
    }

    public void ObtainTurretReference(TurretSpawner _turret)
    {
        spawner = _turret;
        ActivateUI();
    }

    public void CancelOption()
    {
        gameObject.SetActive(false);
    }

    public void SpawnNormalTurret()
    {
        Vector3 spawnPosition = spawner.GetComponentInChildren<Transform>().position;

        if (spawner.spawnedTurret != null)
        {
            Destroy(spawner.spawnedTurret);
            spawner.spawnedTurret = null;
        }

        spawner.spawnedTurret = Instantiate(turret, spawnPosition, Quaternion.identity).gameObject;

        CancelOption();
    }

    public void SpawnFireTurret()
    {
        Vector3 spawnPosition = spawner.GetComponentInChildren<Transform>().position;

        if (spawner.spawnedTurret != null)
        {
            Destroy(spawner.spawnedTurret);
            spawner.spawnedTurret = null;
        }

        spawner.spawnedTurret = Instantiate(fireTurret, spawnPosition, Quaternion.identity).gameObject;

        CancelOption();
    }

    public void SpawnIceTurret()
    {
        Vector3 spawnPosition = spawner.GetComponentInChildren<Transform>().position;

        if (spawner.spawnedTurret != null)
        {
            Destroy(spawner.spawnedTurret);
            spawner.spawnedTurret = null;
        }

        spawner.spawnedTurret = Instantiate(iceTurret, spawnPosition, Quaternion.identity).gameObject;

        CancelOption();
    }
}
