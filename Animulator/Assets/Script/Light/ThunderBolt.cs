using UnityEngine;
using System.Collections;

using HD;

public class ThunderBolt : MonoBehaviour
{
    [SerializeField]
    private float delayTime;

    [SerializeField]
    private Light thunderLight;

    private Transform playerTrans;

    private void Awake()
    {
        thunderLight.enabled = false;
    }

    private void Start()
    {
        playerTrans = InGameManager.Instance.PlayerDataContainer.Transform;
    }

    public void Thunder()
    {
        float yAxis = Quaternion.LookRotation(playerTrans.position - this.transform.position).eulerAngles.y;

        transform.rotation =  transform.rotation.ChangeY(yAxis);

        StartCoroutine(DoThunder());
    }

    private IEnumerator DoThunder()
    {
        thunderLight.enabled = true;

        yield return YieldInstructionCache.WaitForSeconds(delayTime);

        thunderLight.enabled = false;

        yield return YieldInstructionCache.WaitForSeconds(delayTime);

        thunderLight.enabled = true;

        yield return YieldInstructionCache.WaitForSeconds(delayTime);

        thunderLight.enabled = false;
    }
}