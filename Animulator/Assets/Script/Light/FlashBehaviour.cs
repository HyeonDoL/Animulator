using UnityEngine;
using System.Collections;

public class FlashBehaviour : MonoBehaviour
{
    [SerializeField]
    private Light flashLight;

    [Space(1.5f)]
    [Header("[ Intensity Configure ]")]

    [SerializeField]
    [Range(0.5f, 2.0f)]
    private float minIntensity;

    [SerializeField]
    [Range(0.5f, 2.0f)]
    private float maxIntensity;

    [SerializeField]
    private float changeTime;

    [Space(1.5f)]
    [Header("[ Blink Configure ]")]

    [SerializeField]
    [Range(1, 5)]
    private int minBlinkCount;

    [SerializeField]
    [Range(1, 5)]
    private int maxBlinkCount;

    [SerializeField]
    private float delayTime;

    private float nextIntensity;

    private float startIntensity;

    private float currentTime;

    private void Awake()
    {
        currentTime = 0f;

        nextIntensity = Random.Range(minIntensity, maxIntensity);

        startIntensity = flashLight.intensity;
    }

    private void Update()
    {
        currentTime += Time.deltaTime / changeTime;

        if(currentTime >= 1f)
        {
            nextIntensity = Random.Range(minIntensity, maxIntensity);

            startIntensity = flashLight.intensity;

            currentTime = 0f;

            return;
        }

        flashLight.intensity = Mathf.Lerp(startIntensity, nextIntensity, currentTime);
    }

    public void Blink()
    {
        StopAllCoroutines();

        StartCoroutine(DoBlink());
    }

    private IEnumerator DoBlink()
    {
        int blinkCount = Random.Range(minBlinkCount, maxBlinkCount + 1);

        for(int i = 0; i < blinkCount; ++i)
        {
            flashLight.enabled = false;

            yield return YieldInstructionCache.WaitForSeconds(delayTime);

            flashLight.enabled = true;

            yield return YieldInstructionCache.WaitForSeconds(delayTime);
        }
    }
}
