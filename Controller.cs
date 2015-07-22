using UnityEngine;
using System.Collections;

public class Controller : MonoBehaviour {
	public Camera camera;
	public Camera mapCam;
	public GameObject success;
	public GameObject fail;
	int force = 2000;
	public GameObject player;
	Vector3 direction;
	Vector3 cameraDir;
	// Use this for initialization
	void Start () {
		
	}
	
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButton(0))
		{
			RaycastHit hit;
			Ray ray = camera.ScreenPointToRay(Input.mousePosition);
			if (Physics.Raycast(ray, out hit)) 
			{
				if(hit.collider.gameObject.name == "PlayerBall")
				{
					cameraDir = new Vector3(camera.ScreenToWorldPoint(Input.mousePosition).x, camera.ScreenToWorldPoint(Input.mousePosition).y, -camera.ScreenToWorldPoint(Input.mousePosition).z);
					direction = new Vector3(transform.position.x, transform.position.y, +transform.position.z);
					//hit.rigidbody.AddForceAtPosition(Vector3.Normalize(camera.transform.forward-direction) * (force*Time.deltaTime), hit.point);
					//hit.rigidbody.AddForceAtPosition(Vector3.Normalize((cameraDir)-direction) * (force*Time.deltaTime), hit.point);
					hit.rigidbody.AddForceAtPosition(Vector3.Normalize(cameraDir-hit.rigidbody.position) * (force*Time.deltaTime), hit.point);
					
					//Applies force where clicked. Ball, however, goes in the same direction as the side clicked, rather than being repelled
					
					//hit.rigidbody.AddForce (Vector3.Normalize (camera.transform.position-direction) * (force*Time.deltaTime));

					
					//hit.rigidbody.AddRelativeForce (Vector3.Normalize (camera.transform.forward-direction)*(force*Time.deltaTime));
				}					
			}
		}

		camera.transform.position = new Vector3(transform.position.x, transform.position.y+2, transform.position.z-2);
		mapCam.transform.position = new Vector3(mapCam.transform.position.x, transform.position.y+5, transform.position.z);
	}
	
	void OnTriggerEnter(Collider collider)
	{
		if(collider.gameObject.name == "Goal")
		{
			success.gameObject.SetActive(true);
			mapCam.gameObject.SetActive(false);
			Destroy (this);
			//Victory
		}
		
		if(collider.gameObject.name== "DeathZone")
		{
			fail.gameObject.SetActive (true);
			mapCam.gameObject.SetActive (false);
			Destroy (this);
		}
		
	}
}
