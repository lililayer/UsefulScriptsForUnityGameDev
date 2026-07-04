using UnityEngine;
using UnityEngine.Events;

public class WorldTrigger : MonoBehaviour
{
	public float distance;
	public TriggerType trigger_type;
	public UnityEvent trigger_event;
	public bool re_use;
	public bool locked = false;
	
	private GameManager gm;
	private bool used;
	
    void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        used = false;
    }

    void Update()
    {
    	if (used || locked) return;
    	
    	switch (trigger_type) {
    	
    		case TriggerType.InZone:
    		    	bool inZone = Vector3.Distance(gm.player.position, transform.position) < distance;
    			if (inZone) Active();
    			break;
		case TriggerType.InputToward:
			RaycastHit rhit;
			bool hit = false;
			if (Physics.Raycast(gm.cam.position, gm.cam.forward, out rhit, distance, gm.triggerable)) {
				if (rhit.transform == transform) {
					hit = true;
					gm.toogleTrigger.SetActive(true);
				}
			}
    			if (hit && Input.GetButtonDown("Use")) Active();
			break;
		default:
			break;
    	}
    }
    
    void Active() {
    	used = !re_use;
    	trigger_event.Invoke();
    }
}

public enum TriggerType {
	InZone,
	InputToward
}
