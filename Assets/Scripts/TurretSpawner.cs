using UnityEngine;

public class TurretSpawner : MonoBehaviour
{
    public TurretPlacerUI turretPlacerUI;
    public LayerMask targetLayer;
    public TurretClass spawnedTurret;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //turretPlacerUI = FindAnyObjectByType<TurretPlacerUI>(FindObjectsInactive.Include);
    }
    public void TurretDetected()
    {
        foreach (Renderer renderer in GetComponentsInChildren<Renderer>())
        { 
            if (renderer != null)
            { 
                renderer.enabled = true;
                Debug.Log("Turret detected");
            }
        }
    }
    public void TurretLost()
    {
        foreach (Renderer renderer in GetComponentsInChildren<Renderer>())
        { 
            if (renderer != null)
            { 
                renderer.enabled = false;
                Debug.Log("Turret lost");
            }
        }
    }
    
    
    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                Ray ray = Camera.main.ScreenPointToRay(touch.position);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit, Mathf.Infinity, targetLayer))
                {
                    TurretSpawner tempSpawner = hit.collider.gameObject.GetComponent<TurretSpawner>();

                    if (tempSpawner != null)
                    {
                        Debug.Log("Hit a Spawner");

                        if (turretPlacerUI.gameObject.activeSelf == true)
                        {
                            turretPlacerUI.gameObject.SetActive(false);
                        }

                        turretPlacerUI.gameObject.SetActive(true);
                        turretPlacerUI.ObtainTurretReference(tempSpawner);
                    }
                }
            }
        }
    }
}
