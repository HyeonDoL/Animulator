using UnityEngine;

public class Debuger : MonoBehaviour
{
    [SerializeField]
    private ThunderBolt thunder;

    [SerializeField]
    private FlashBehaviour flashBehaviour;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.C))
            thunder.Thunder();

        if (Input.GetKeyDown(KeyCode.V))
            flashBehaviour.Blink();
    }
}
