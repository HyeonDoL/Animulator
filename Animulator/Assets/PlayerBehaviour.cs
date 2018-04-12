using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour {

    private Transform _transform;
    private Rigidbody _rigidbody;

    private Vector3 _lookPoint;

	// Use this for initialization
	void Start () {
        _transform = GetComponent<Transform>();
        _rigidbody = GetComponent<Rigidbody>();

        _lookPoint = Vector3.back;
	}
	
	// Update is called once per frame
	void Update () {
        _rigidbody.velocity = _transform.localRotation * new Vector3(Input.GetAxis("Horizontal") * 4f, _rigidbody.velocity.y, Input.GetAxis("Vertical") * 4f);
        _lookPoint = Vector3.Lerp(_lookPoint, _rigidbody.velocity, Time.deltaTime * 5f);
        _transform.LookAt(_transform.position + _lookPoint);
	}
}
