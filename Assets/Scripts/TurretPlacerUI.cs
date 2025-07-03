using System.Runtime.InteropServices.WindowsRuntime;
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

    }

    public void ActivateUI()
    {
        normalTurretButton.GetComponentInChildren<TextMeshProUGUI>().text = $"{turret.name} \nCost: {turret.cost}";
        fireTurretButton.GetComponentInChildren<TextMeshProUGUI>().text = $"{fireTurret.name} \nCost: {fireTurret.cost}";
        iceTurretButton.GetComponentInChildren<TextMeshProUGUI>().text = $"{iceTurret.name} \nCost: {iceTurret.cost}";

        if (spawner.spawnedTurret != null)
        {
            switch (spawner.spawnedTurret.turretType)
            {
                case TurretType.Normal:
                    normalTurretButton.GetComponentInChildren<TextMeshProUGUI>().text = $"Lvl {spawner.spawnedTurret.turretLevel + 1} {turret.name} \nCost: {spawner.spawnedTurret.turretCost}";
                    break;
                case TurretType.Fire:
                    fireTurretButton.GetComponentInChildren<TextMeshProUGUI>().text = $"Lvl {spawner.spawnedTurret.turretLevel + 1} {fireTurret.name} \nCost: {spawner.spawnedTurret.turretCost}";
                    break;
                case TurretType.Ice:
                    iceTurretButton.GetComponentInChildren<TextMeshProUGUI>().text = $"Lvl {spawner.spawnedTurret.turretLevel + 1} {iceTurret.name} \nCost: {spawner.spawnedTurret.turretCost}";
                    break;
            }
        }
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
            if (spawner.spawnedTurret.turretType == TurretType.Normal)
            {
                spawner.spawnedTurret.GetComponent<Turret>().LevelUp(spawner.spawnedTurret.turretLevel + 1);
            }
            else
            {
                Destroy(spawner.spawnedTurret.gameObject);
                spawner.spawnedTurret = null;

                spawner.spawnedTurret = Instantiate(turret, spawnPosition, Quaternion.identity).gameObject.GetComponent<TurretClass>();
            }
        }
        else
        {
            spawner.spawnedTurret = Instantiate(turret, spawnPosition, Quaternion.identity).gameObject.GetComponent<TurretClass>();
        }

        CancelOption();
    }

    public void SpawnFireTurret()
    {
        Vector3 spawnPosition = spawner.GetComponentInChildren<Transform>().position;

        if (spawner.spawnedTurret != null)
        {
            if (spawner.spawnedTurret.turretType == TurretType.Fire)
            {
                spawner.spawnedTurret.GetComponent<FireTurret>().LevelUp(spawner.spawnedTurret.turretLevel + 1);
            }
            else
            {
                Destroy(spawner.spawnedTurret.gameObject);
                spawner.spawnedTurret = null;

                spawner.spawnedTurret = Instantiate(fireTurret, spawnPosition, Quaternion.identity).gameObject.GetComponent<TurretClass>();
            }
        }
        else
        {
            spawner.spawnedTurret = Instantiate(fireTurret, spawnPosition, Quaternion.identity).gameObject.GetComponent<TurretClass>();
        }

        CancelOption();
    }

    public void SpawnIceTurret()
    {
        Vector3 spawnPosition = spawner.GetComponentInChildren<Transform>().position;

        if (spawner.spawnedTurret != null)
        {
            if (spawner.spawnedTurret.turretType == TurretType.Ice)
            {
                spawner.spawnedTurret.GetComponent<IceTurret>().LevelUp(spawner.spawnedTurret.turretLevel + 1);
            }
            else
            {
                Destroy(spawner.spawnedTurret.gameObject);
                spawner.spawnedTurret = null;

                spawner.spawnedTurret = Instantiate(iceTurret, spawnPosition, Quaternion.identity).gameObject.GetComponent<TurretClass>();
            }
        }
        else
        {
            spawner.spawnedTurret = Instantiate(iceTurret, spawnPosition, Quaternion.identity).gameObject.GetComponent<TurretClass>();
        }

        CancelOption();
    }
}
