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

        float theta = Vector3.Dot(transform.forward, playerTransform.forward);

        Vector3 dirAngle = Vector3.Cross(transform.forward, playerTransform.forward);

        float angle = Mathf.Acos(theta) * Mathf.Rad2Deg;

        if (dirAngle.z < 0.0f)
            angle = 360 - angle;

        // Backward Open
        if (angle > 180f)
        {
            StartCoroutine(Tween.TweenTransform.LocalRotation(axis,
                                                              transform.localRotation.ChangeY(-maxAngle),
                                                              openTime));

        }

        // Forward Open
        else
        {
            StartCoroutine(Tween.TweenTransform.LocalRotation(axis,
                                                              transform.localRotation.ChangeY(maxAngle),
                                                              openTime));
        }

        Debug.Log(angle + " " + axis.rotation.eulerAngles);
    }

    public void Return()
    {
        StartCoroutine(Tween.TweenTransform.Rotation(axis,
                                                     transform.rotation.ChangeY(0),
                                                     openTime / 2));
    }
}
