using UnityEngine;
using Vuforia;

public class SpawnerActivator : MonoBehaviour
{
    public EnemySpawner spawner;

    void Start()
    {
        var observerHandler = GetComponent<DefaultObserverEventHandler>();
        if (observerHandler != null)
        {
            observerHandler.OnTargetFound.AddListener(OnTargetFound);
            observerHandler.OnTargetLost.AddListener(OnTargetLost);
        }
    }

    void OnTargetFound()
    {
        Debug.Log("Image Target Detectado");
        spawner.ActivateSpawner();
    }

    void OnTargetLost()
    {
        Debug.Log("Image Target Perdido");
        spawner.DeactivateSpawner();
    }
}