using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordRotate : MonoBehaviour {
    public float tumbleSpeed;
    Rigidbody rb;

	void Start () {
        rb= GetComponent<Rigidbody>();
        rb.angularVelocity = Random.insideUnitSphere * tumbleSpeed;
	}
}
