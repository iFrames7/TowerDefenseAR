using UnityEngine;

public class TurretSpawner : MonoBehaviour
{
    public TurretPlacerUI turretPlacerUI;
    public LayerMask targetLayer;
    public GameObject spawnedTurret;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //turretPlacerUI = FindAnyObjectByType<TurretPlacerUI>(FindObjectsInactive.Include);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePosition = Input.mousePosition;

            Ray ray = Camera.main.ScreenPointToRay(mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, targetLayer))
            {
                TurretSpawner tempSpawner = hit.collider.gameObject.GetComponent<TurretSpawner>();

                if (tempSpawner != null)
                {
                    Debug.Log("Hit a Spawner");

                    turretPlacerUI.gameObject.SetActive(true);
                    turretPlacerUI.ObtainTurretReference(tempSpawner);
                }
            }
        }
    }
}
