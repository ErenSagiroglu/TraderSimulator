using UnityEngine;
using TMPro;

public class EconomyManager : MonoBehaviour
{
    public static EconomyManager Instance;

    public double currentMoney = 200.0;
    public TextMeshProUGUI moneyText;

    private void Awake()
    {
        if (Instance == null) Instance = this;
    }

    private void Start()
    {
        UpdateUI();
    }

    public void UpdateUI()
    {
        if (moneyText != null)
        {
            moneyText.text = $"${currentMoney}";
        }
    }
}