using UnityEngine;

public class billboard : MonoBehaviour
{
	public bool yAxisOnly;
	private Transform player;
	private Vector3 defaultAngles;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.Find("GameManager").GetComponent<GameManager>().player;
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(player.position);
        if (yAxisOnly)
        	transform.eulerAngles = new Vector3(defaultAngles.x, transform.eulerAngles.y, defaultAngles.z);
    }
}
