using UnityEngine;

public class FirstPersonCamera : MonoBehaviour
{
    [SerializeField] private float sensitivity = 5.0f;
    [SerializeField] private float smoothing = 2.0f;
    [SerializeField] private float yRotationLimit = 89.0f;
    
    private Vector2 mouseLook;
    private Vector2 smoothV;
    private Vector2 smoothDeltaV;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        Vector2 mouseDelta = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
        mouseDelta = Vector2.Scale(mouseDelta, new Vector2(sensitivity * smoothing, sensitivity * smoothing));
        smoothDeltaV = Vector2.Lerp(smoothDeltaV, mouseDelta, 1f / smoothing);
        smoothV = Vector2.Lerp(smoothV, mouseDelta, 1f / smoothing);

        mouseLook += smoothDeltaV;
        mouseLook.y = Mathf.Clamp(mouseLook.y, -yRotationLimit, yRotationLimit);

        transform.localRotation = Quaternion.AngleAxis(-mouseLook.y, Vector3.right);
        
        if (transform.parent != null)
        {
            transform.parent.localRotation = Quaternion.AngleAxis(mouseLook.x, transform.parent.up);
        }
        
        if (Input.GetKey(KeyCode.Escape)) {
		Cursor.lockState = CursorLockMode.None;
		Cursor.visible = true;
        }
    }
}
