using UnityEngine;

[RequireComponent(typeof(WorldTrigger))]
public class Note : MonoBehaviour
{
	private GameManager gm;
	private Vector3 startPos, startRotation;
	private Transform defParent;
	private bool opened;
	
	public float camDistance;
	
    void Start()
    {
    	opened = false;
    	startPos = transform.position;
    	startRotation = transform.eulerAngles;
    	defParent = transform.parent;
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    public void Read() {
    	transform.position = gm.cam.position + gm.cam.forward * camDistance;
    	transform.LookAt(gm.cam);
    	transform.SetParent(gm.cam);
	opened = true;
    }
    
    void Close() {
    	opened = false;
    	transform.position = startPos;
    	transform.eulerAngles = startRotation;
    	transform.SetParent(defParent);
    }
    
    void Update() {
    	if (opened) {
    		if (Input.GetButtonDown("Cancel")) {
    			Close();
    		}
    	}
    }
}
