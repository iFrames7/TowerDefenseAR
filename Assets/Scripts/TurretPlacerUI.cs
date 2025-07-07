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
    public GameObject notEnoughCoins;
    
    private TurretSpawner spawner;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    public void ActivateUI()
    {
        notEnoughCoins.SetActive(false);

        normalTurretButton.GetComponentInChildren<TextMeshProUGUI>().text = $"{turret.name} \nCost: {turret.cost}";
        fireTurretButton.GetComponentInChildren<TextMeshProUGUI>().text = $"{fireTurret.name} \nCost: {fireTurret.cost}";
        iceTurretButton.GetComponentInChildren<TextMeshProUGUI>().text = $"{iceTurret.name} \nCost: {iceTurret.cost}";

        if (spawner.spawnedTurret != null)
        {
            switch (spawner.spawnedTurret.turretType)
            {
                case TurretType.Normal:
                    normalTurretButton.GetComponentInChildren<TextMeshProUGUI>().text = $"Lvl {spawner.spawnedTurret.turretLevel + 1} {turret.name} \nCost: {spawner.spawnedTurret.GetComponent<Turret>().cost}";
                    break;
                case TurretType.Fire:
                    fireTurretButton.GetComponentInChildren<TextMeshProUGUI>().text = $"Lvl {spawner.spawnedTurret.turretLevel + 1} {fireTurret.name} \nCost: {spawner.spawnedTurret.GetComponent<FireTurret>().cost}";
                    break;
                case TurretType.Ice:
                    iceTurretButton.GetComponentInChildren<TextMeshProUGUI>().text = $"Lvl {spawner.spawnedTurret.turretLevel + 1} {iceTurret.name} \nCost: {spawner.spawnedTurret.GetComponent<IceTurret>().cost}";
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
                if (!GameManager.Instance.CobroMejoras(spawner.spawnedTurret.GetComponent<Turret>().cost))
                {
                    notEnoughCoins.SetActive(true);
                    return;
                }

                spawner.spawnedTurret.GetComponent<Turret>().LevelUp(spawner.spawnedTurret.turretLevel + 1);
            }
            else
            {
                if (!GameManager.Instance.CobroMejoras(turret.cost))
                {
                    notEnoughCoins.SetActive(true);
                    return;
                }

                Destroy(spawner.spawnedTurret.gameObject);
                spawner.spawnedTurret = null;

                spawner.spawnedTurret = Instantiate(turret, spawnPosition, Quaternion.identity).gameObject.GetComponent<TurretClass>();
            }
        }
        else
        {
            if (!GameManager.Instance.CobroMejoras(turret.cost))
            {
                notEnoughCoins.SetActive(true);
                return;
            }

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
                if (!GameManager.Instance.CobroMejoras(spawner.spawnedTurret.GetComponent<FireTurret>().cost))
                {
                    notEnoughCoins.SetActive(true);
                    return;
                }

                spawner.spawnedTurret.GetComponent<FireTurret>().LevelUp(spawner.spawnedTurret.turretLevel + 1);
            }
            else
            {
                if (!GameManager.Instance.CobroMejoras(fireTurret.cost))
                {
                    notEnoughCoins.SetActive(true);
                    return;
                }

                Destroy(spawner.spawnedTurret.gameObject);
                spawner.spawnedTurret = null;

                spawner.spawnedTurret = Instantiate(fireTurret, spawnPosition, Quaternion.identity).gameObject.GetComponent<TurretClass>();
            }
        }
        else
        {
            if (!GameManager.Instance.CobroMejoras(fireTurret.cost))
            {
                notEnoughCoins.SetActive(true);
                return;
            }

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
                if (!GameManager.Instance.CobroMejoras(spawner.spawnedTurret.GetComponent<IceTurret>().cost))
                {
                    notEnoughCoins.SetActive(true);
                    return;
                }

                spawner.spawnedTurret.GetComponent<IceTurret>().LevelUp(spawner.spawnedTurret.turretLevel + 1);
            }
            else
            {
                if (!GameManager.Instance.CobroMejoras(iceTurret.cost))
                {
                    notEnoughCoins.SetActive(true);
                    return;
                }

                Destroy(spawner.spawnedTurret.gameObject);
                spawner.spawnedTurret = null;

                spawner.spawnedTurret = Instantiate(iceTurret, spawnPosition, Quaternion.identity).gameObject.GetComponent<TurretClass>();
            }
        }
        else
        {
            if (!GameManager.Instance.CobroMejoras(iceTurret.cost))
            {
                notEnoughCoins.SetActive(true);
                return;
            }

            spawner.spawnedTurret = Instantiate(iceTurret, spawnPosition, Quaternion.identity).gameObject.GetComponent<TurretClass>();
        }

        CancelOption();
    }
}
