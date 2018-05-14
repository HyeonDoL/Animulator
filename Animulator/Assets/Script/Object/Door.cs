using UnityEngine;

using HD;

public class Door : InteractionObject
{
    [SerializeField]
    private Transform axis;

    [SerializeField]
    private float openTime = 1.5f;

    [SerializeField]
    private float maxAngle = 60f;

    private Transform playerTransform;

    private float startAngle;

    private void Start()
    {
        playerTransform = InGameManager.Instance.PlayerDataContainer.Transform;
    }

    protected override void OnTriggerExit(Collider other)
    {
        base.OnTriggerExit(other);

        Return();
    }

    public override void Interaction()
    {
        StopAllCoroutines();

        float direction = Vector3.Dot(transform.forward, playerTransform.forward);

        //// Forward Open
        //if(direction > 0f)
        //{
        //    StartCoroutine(Tween.TweenTransform.Rotation(axis,
        //                                                 transform.rotation.ChangeY(maxAngle),
        //                                                 openTime));
        //}

        //// Backward Open
        //else
        //{
        //    StartCoroutine(Tween.TweenTransform.Rotation(axis,
        //                                                 transform.rotation.ChangeY(-maxAngle),
        //                                                 openTime));
        //}

        Debug.Log(direction);
   }

    public void Return()
    {
        StartCoroutine(Tween.TweenTransform.Rotation(axis,
                                                     transform.rotation.ChangeY(0),
                                                     openTime / 2));
    }
}
