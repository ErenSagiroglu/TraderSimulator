using System.Collections;
using UnityEngine;

public class PanelAnimation : MonoBehaviour
{
    [Header("Animation Settings")]
    public float openDuration = 0.25f; // 0.25 - 0.3 saniye mobil hissi için en ideal hızlı süredir
    public Vector3 targetScale = Vector3.one; // Normal boyutu (1,1,1)

    private Coroutine currentCoroutine;

    private void OnEnable()
    {
        // Panel her SetActive(true) olduğunda ortadan büyüyerek açılır
        if (currentCoroutine != null) StopCoroutine(currentCoroutine);
        currentCoroutine = StartCoroutine(AnimateOpen());
    }

    private IEnumerator AnimateOpen()
    {
        // Başlangıçta ekranın ortasında küçücük (0,0,0) yapıyoruz
        transform.localScale = Vector3.zero;

        float elapsedTime = 0f;

        while (elapsedTime < openDuration)
        {
            elapsedTime += Time.deltaTime;
            float t = elapsedTime / openDuration;

            // EaseOutCubic formülü: Hızlı başlayıp tatlı bir şekilde durağanlaşır (Pop-up etkisi)
            t = 1f - Mathf.Pow(1f - t, 3);

            transform.localScale = Vector3.LerpUnclamped(Vector3.zero, targetScale, t);
            yield return null;
        }

        transform.localScale = targetScale;
    }
}