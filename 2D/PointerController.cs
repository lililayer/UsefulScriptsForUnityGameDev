using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PointerController : MonoBehaviour
{
	public Transform cam;
	public float velocityRayDist;
	private LineRenderer lr;
	public PlayerController pc;
	private Vector3[] positions;
	private Vector2 inputs;
	private Vector3 center;
	
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        lr = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        inputs = pc.inputs;
        
	center = cam.position - Vector3.forward * cam.position.z;
        positions = new Vector3[3] {
        	center + (Vector3)inputs,
        	center,
        	center + (Vector3)pc.velocity * velocityRayDist
        };
        lr.SetPositions(positions);
    }
}
