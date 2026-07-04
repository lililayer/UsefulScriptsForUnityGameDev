using UnityEngine;

public class GameManager : MonoBehaviour
{
	[Header("Player")]
	public Transform cam;
	public Transform player;
	[Header("Trigger events")]
	public LayerMask triggerable;
	public GameObject toogleTrigger;
	public QuestManager questManager;
	
	private float quartSecondTimer = 0f;
	
	public void Update() {
		quartSecondTimer += Time.deltaTime;
		if (quartSecondTimer > 0.25f) {
			quartSecondTimer = quartSecondTimer%0.25f;
			Apply4TimePerSeconds();
		}
	}
	
	void Apply4TimePerSeconds() {
		toogleTrigger.SetActive(false);
	}
}
