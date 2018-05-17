using UnityEngine;
using System.Collections.Generic;
using System.Collections;
// FIXME : 급해서 생각없이 만듬

public class SetUpLight : InteractionObject
{
    [SerializeField]
    private float delay = 0.7f;

    [SerializeField]
    private List<LightObject> lights = new List<LightObject>();

    [System.Serializable]
    public struct LightObject
    {
        public Light[] lightArray;
    }

    private void Start()
    {
        for(int i = 0; i < lights.Count; ++i)
        {
            for (int j = 0; j < lights[i].lightArray.Length; ++j)
                lights[i].lightArray[j].enabled = false;
        }
    }

    public override void Interaction()
    {
        StartCoroutine(LightOn());
    }

    public IEnumerator LightOn()
    {
        for (int i = 0; i < lights.Count; ++i)
        {
            for (int j = 0; j < lights[i].lightArray.Length; ++j)
                lights[i].lightArray[j].enabled = true;

            yield return YieldInstructionCache.WaitForSeconds(delay);
        }
    }
}
