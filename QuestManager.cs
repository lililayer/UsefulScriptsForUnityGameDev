using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class QuestManager : MonoBehaviour
{
    public Quest quest;
    public Text questName, partDesc;
    private WorldTrigger targetedTrigger;
    private Vector3 targetPosition;
    
    public void InitializeQuest() {
    	quest.partID = 0;
    	UpdatePart(quest.parts[quest.partID]);
    }
    
    public void NextPart() {
    	quest.partID++;
    	if (quest.partID >= quest.parts.Length) {
	    	partDesc.text  = "DONE";
	    	
    		return;
    	}
    	UpdatePart(quest.parts[quest.partID]);
    }
    
    private void UpdatePart(QuestPart part) {
    	questName.text = quest._name;
    	partDesc.text  = part._description;
    	targetedTrigger = GameObject.Find(part.worldTrigger).AddComponent<WorldTrigger>();
    	if (targetedTrigger == null) {Debug.LogWarning(part.worldTrigger + " not found !");return;}
    	targetedTrigger.distance = part.t_data.distance;
    	targetedTrigger.trigger_type = part.t_data.trigger_type;
    	targetedTrigger.trigger_event = part.t_data.trigger_event;
    	targetPosition = targetedTrigger.transform.position;
    }
}

[System.Serializable]
public class Quest {
	public string _name;
	public int partID = 0;
	public QuestPart[] parts;
}

[System.Serializable]
public class QuestPart {
	public string _description, worldTrigger;
	public WorldTriggerData t_data;
}

[System.Serializable]
public class WorldTriggerData {
	public float distance;
	public TriggerType trigger_type;
	public UnityEvent trigger_event;
}
