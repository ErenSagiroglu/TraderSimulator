using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [Header("UI Panels")]
    public GameObject newsPanel;
    public GameObject tradePanel;
    public GameObject shopPanel;

    // Haberler Panelini Aç
    public void OpenNews()
    {
        CloseAllPanels();
        if (newsPanel != null) newsPanel.SetActive(true);
    }

    // Borsa Panelini Aç
    public void OpenTrade()
    {
        CloseAllPanels();
        if (tradePanel != null) tradePanel.SetActive(true);
    }

    // Mağaza Panelini Aç
    public void OpenShop()
    {
        CloseAllPanels();
        if (shopPanel != null) shopPanel.SetActive(true);
    }

    // Tüm Panelleri Kapat (Odaya Dön)
    public void CloseAllPanels()
    {
        if (newsPanel != null) newsPanel.SetActive(false);
        if (tradePanel != null) tradePanel.SetActive(false);
        if (shopPanel != null) shopPanel.SetActive(false);
    }
}