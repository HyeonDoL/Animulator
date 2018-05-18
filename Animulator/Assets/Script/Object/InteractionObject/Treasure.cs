using UnityEngine;

public class Treasure : InteractionObject
{
    private Transform _transform;
    private Vector3 _position;

    private void Awake()
    {
        _transform = GetComponent<Transform>();
    }

    private void Start()
    {
        _position = _transform.localPosition;
    }

    private void Update()
    {
        _transform.localPosition = _position + Vector3.up * (Mathf.Sin(Time.time * 4f) + 1f) * 0.1f;
        _transform.localRotation = Quaternion.AngleAxis(Time.time * 360f, Vector3.up);
    }

    public override void Interaction()
    {
        InGameManager.Instance.TreasureFind();

        Destroy(this.gameObject);
    }
}
