using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
	public Vector2 screenDimensions = new Vector2(960, 540);
	public float force, speed;
	[HideInInspector]public Vector2 inputs;
	[HideInInspector]public Vector2 velocity;
	private Rigidbody rb;

	void Start() {velocity = Vector2.zero; rb = GetComponent<Rigidbody>();}
    // Update is called once per frame
    void FixedUpdate()
    {
        inputs = Mouse.current.position.ReadValue();
        inputs /= screenDimensions;
        inputs -= Vector2.one * 0.5f;
        inputs *= 4f * force;
        inputs = Vector2.right * Mathf.Clamp(inputs.x, -1f, 1f) + Vector2.up * Mathf.Clamp(inputs.y, -1f, 1f);
        rb.AddForce(Time.fixedDeltaTime * (Vector3)inputs * speed);
        
        velocity = rb.linearVelocity;
    }
}
