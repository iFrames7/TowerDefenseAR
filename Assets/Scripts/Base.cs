using UnityEngine;

public class Base : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public void BaseDetected()
    {
        Renderer renderer = GetComponent<Renderer>();
        if (renderer != null)
        {   
            renderer.enabled = true;
            Debug.Log("Base detected");
        }
    }
    public void BaseLost()
    {
        Renderer renderer = GetComponent<Renderer>();
        if (renderer != null)
        {
            renderer.enabled = false;
            Debug.Log("Base lost");
        }
    }
}
