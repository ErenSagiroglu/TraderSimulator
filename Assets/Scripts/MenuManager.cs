using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [Header("UI Panels")]
    public GameObject newsPanel;
    public GameObject tradePanel;
    public GameObject shopPanel;

    [Header("Audio Settings")]
    public AudioSource audioSource;
    public AudioClip newsOpenSound;
    public AudioClip tradeOpenSound;
    public AudioClip shopOpenSound;
    public AudioClip homeButtonSound;

    // Haberler Panelini Aç
    public void OpenNews()
    {
        CloseAllPanels();
        if (newsPanel != null) newsPanel.SetActive(true);
        PlaySound(newsOpenSound);
    }

    // Borsa Panelini Aç
    public void OpenTrade()
    {
        CloseAllPanels();
        if (tradePanel != null) tradePanel.SetActive(true);
        PlaySound(tradeOpenSound);
    }

    // Mağaza Panelini Aç
    public void OpenShop()
    {
        CloseAllPanels();
        if (shopPanel != null) shopPanel.SetActive(true);
        PlaySound(shopOpenSound);
    }

    // Tüm Panelleri Kapat (Odaya Dön)
    public void CloseAllPanels()
    {
        // Panel kapatma butonuna basınca ev sesini çal
        PlaySound(homeButtonSound);

        if (newsPanel != null) newsPanel.SetActive(false);
        if (tradePanel != null) tradePanel.SetActive(false);
        if (shopPanel != null) shopPanel.SetActive(false);
    }

    private void PlaySound(AudioClip clip)
    {
        if (audioSource != null && clip != null)
        {
            audioSource.PlayOneShot(clip);
        }
    }
}