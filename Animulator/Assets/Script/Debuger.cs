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
    private GameObject[] offObj;

    [SerializeField]
    private PlayerBehaviour playerBehaviour;

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;        
    }

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

        if(Input.GetKeyDown(KeyCode.Tab))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

        if (Input.GetKeyUp(KeyCode.Tab))
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    public void NormalMode()
    {
        RenderSettings.ambientIntensity = 1f;

        RenderSettings.reflectionIntensity = 1f;

        flashLight.enabled = false;

        for(int i = 0; i < offObj.Length; ++i)
            offObj[i].SetActive(true);

        playerBehaviour.MoveSpeed = 2.5f;
    }

    public void ScaredMode()
    {
        RenderSettings.ambientIntensity = 0f;

        RenderSettings.reflectionIntensity = 0.2f;

        //flashLight.enabled = true;

        for (int i = 0; i < offObj.Length; ++i)
            offObj[i].SetActive(false);

        playerBehaviour.MoveSpeed = 2.0f;
    }
}
