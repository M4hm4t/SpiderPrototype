using PathCreation.Examples;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    Rigidbody rb;
    public GameObject rope;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float xMove = Input.GetAxisRaw("Horizontal"); 
        float zMove = Input.GetAxisRaw("Vertical"); 
        rb.velocity = new Vector3(xMove, rb.velocity.y, zMove) * speed; 

    }
	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.name == "TriggerA")
		{
			rope.GetComponent<PathFollower>().enabled = true;
			//isSwinging = true;
			//swingArea.transform.rotation = Quaternion.Euler(new Vector3(0, transform.eulerAngles.y + 90, 0));
			//swingArea.SetActive(true);
			//lineRenderer.enabled = true;
		}
		if (other.gameObject.name == "TriggerB")
		{
			rope.GetComponent<PathFollower>().enabled = false;
			//isSwinging = true;
			//swingArea.transform.rotation = Quaternion.Euler(new Vector3(0, transform.eulerAngles.y + 90, 0));
			//swingArea.SetActive(true);
			//lineRenderer.enabled = true;
		}
		
	}
}
