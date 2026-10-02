using System.Collections;
using UnityEngine;

public class SideMenuController : MonoBehaviour
{
    [Header("UI Elemanları")]
    [SerializeField] private RectTransform sideMenuPanel; // SideMenu paneli
    [SerializeField] private GameObject closeTouchArea;   // Sağdaki şeffaf tıklama alanı

    [Header("Animasyon Ayarları")]
    [SerializeField] private float closedX = -650f;
    [SerializeField] private float openX = -1f;
    [SerializeField] private float slideSpeed = 12f;

    private bool isOpen = false;
    private Coroutine currentSlideCoroutine;

    private void Start()
    {
        if (sideMenuPanel != null)
        {
            sideMenuPanel.anchoredPosition = new Vector2(closedX, sideMenuPanel.anchoredPosition.y);
        }

        // Başlangıçta şeffaf tıklama alanını kapat (ekrandaki butonlar rahat tıklansın)
        if (closeTouchArea != null)
        {
            closeTouchArea.SetActive(false);
        }
    }

    // Hamburger butonuna veya şeffaf alana tıklandığında çalışır
    public void ToggleMenu()
    {
        isOpen = !isOpen;

        // Menü açıkken şeffaf alanı aktif et, kapalıyken pasif yap
        if (closeTouchArea != null)
        {
            closeTouchArea.SetActive(isOpen);
        }

        float targetX = isOpen ? openX : closedX;

        if (currentSlideCoroutine != null)
            StopCoroutine(currentSlideCoroutine);

        currentSlideCoroutine = StartCoroutine(SlideMenu(targetX));
    }

    private IEnumerator SlideMenu(float targetX)
    {
        Vector2 currentPos = sideMenuPanel.anchoredPosition;

        while (Mathf.Abs(currentPos.x - targetX) > 0.1f)
        {
            currentPos.x = Mathf.Lerp(currentPos.x, targetX, Time.deltaTime * slideSpeed);
            sideMenuPanel.anchoredPosition = currentPos;
            yield return null;
        }

        sideMenuPanel.anchoredPosition = new Vector2(targetX, currentPos.y);
    }
}