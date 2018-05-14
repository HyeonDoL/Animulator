using UnityEngine;

public class Debuger : MonoBehaviour
{
    [SerializeField]
    private ThunderBolt thunder;

    [SerializeField]
    private FlashBehaviour flashBehaviour;

    [SerializeField]
    private Light flashLight;

    [SerializeField]
    private GameObject directinalLight;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.C))
            thunder.Thunder();

        if (Input.GetKeyDown(KeyCode.V))
            flashBehaviour.Blink();

        if (Input.GetKeyDown(KeyCode.Alpha1))
            NormalMode();

        if (Input.GetKeyDown(KeyCode.Alpha2))
            ScaredMode();
    }

    public void NormalMode()
    {
        RenderSettings.ambientIntensity = 1f;

        RenderSettings.reflectionIntensity = 1f;

        flashLight.enabled = false;

        directinalLight.SetActive(true);
    }

    public void ScaredMode()
    {
        RenderSettings.ambientIntensity = 0f;

        RenderSettings.reflectionIntensity = 0.2f;

        //flashLight.enabled = true;

        directinalLight.SetActive(false);
    }
}
