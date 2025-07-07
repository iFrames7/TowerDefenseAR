using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int coins = 0;
    public TMP_Text coinText;
    
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void AddCoins(int amount)
    {
        coins += amount;
        UpdateUI();
    }

    public bool CobroMejoras(int _costo)
    {
        if (coins >= _costo)
        {
            coins -= _costo;
            UpdateUI(); 
            return true;
        }
        else
        {
            return false;
        }
    }

    void UpdateUI()
    {
        if (coinText != null)
            coinText.text = "Monedas: " + coins;
        
    }
}
