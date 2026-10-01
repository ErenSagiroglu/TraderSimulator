using System.Collections;
using UnityEngine;

public class CharacterLookController : MonoBehaviour
{
    [Header("Character GameObjects")]
    public GameObject characterNormal; // Character1 (Normal hali)
    public GameObject characterLooking; // Character2 (Bize bakan hali)

    [Header("Timing Settings")]
    public float lookInterval = 20f; // Kaç saniyede bir baksın (20s)
    public float lookDuration = 3f;  // Kaç saniye baksın (3s)

    void Start()
    {
        // Başlangıç durumunu garantiye alalım
        if (characterNormal != null) characterNormal.SetActive(true);
        if (characterLooking != null) characterLooking.SetActive(false);

        // Döngüyü başlat
        StartCoroutine(LookRoutine());
    }

    IEnumerator LookRoutine()
    {
        while (true)
        {
            // 20 saniye bekle
            yield return new WaitForSeconds(lookInterval);

            // Character1'i gizle, Character2'yi göster
            if (characterNormal != null) characterNormal.SetActive(false);
            if (characterLooking != null) characterLooking.SetActive(true);

            // 3 saniye ekrana baksın
            yield return new WaitForSeconds(lookDuration);

            // Character2'yi gizle, tekrar Character1'i göster
            if (characterLooking != null) characterLooking.SetActive(false);
            if (characterNormal != null) characterNormal.SetActive(true);
        }
    }
}