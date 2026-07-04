using UnityEngine;

public class CameraController : MonoBehaviour
{
	public float smoothTime;
	public Transform target;
	public Vector3 offset;
	
	private Vector3 vel = Vector3.zero;
	
    void LateUpdate()
    {
	Vector3 targetPos = target.position + offset;
	transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref vel, smoothTime);
	transform.LookAt(target.position);
    }
}
