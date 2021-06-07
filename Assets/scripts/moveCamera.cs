using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveCamera : MonoBehaviour {

    public float moveSpeed = 3f;
    public float minPosition = -18f; // left border
    public float maxPosition = 18f; // right border

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //Moves Left and right along x Axis
        transform.Translate(Vector3.right * Time.deltaTime * Input.GetAxis("Horizontal") * moveSpeed);
        var clampedPos = transform.position;
        clampedPos.x = Mathf.Clamp(clampedPos.x, minPosition, maxPosition);
        transform.position = clampedPos;
    }
}