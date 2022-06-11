using PathCreation.Examples;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    Rigidbody rb;
    public GameObject hangPoint;
    public LineRenderer line;
    public Transform pos1;
    public Transform pos2;
    //[SerializeField]
    //GameObject swingArea;
    //[SerializeField]
    //Transform bob, webPoint;

    //private void Awake()
    //{
    //    lineRenderer = GetComponent<LineRenderer>();
    //}
    void Start()
    {
        line.positionCount = 2;
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        line.SetPosition(0,pos1.position);
        line.SetPosition(1,pos2.position);

        
        if (Input.GetKey(KeyCode.UpArrow))
        {
            rb.velocity = transform.forward * speed;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            rb.velocity = -transform.forward * speed;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.velocity = transform.right * speed;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.velocity = -transform.right * speed;
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "TriggerA")
        {
            line.enabled = true;
            //  InvokeRepeating("SetLine", 3, 300);
            // swingArea.SetActive(true);
            //lineRenderer.SetPosition(0, webPoint.position);
            //lineRenderer.SetPosition(1, swingArea.transform.position);
            hangPoint.GetComponent<PathFollower>().enabled = true;

        }
        if (other.gameObject.name == "TriggerB")
        {
            line.enabled = false;
            hangPoint.GetComponent<PathFollower>().enabled = false;
        }
    }

    //void SetLine()
    //{
    //    lineRenderer.enabled = true;
    //    swingArea.transform.rotation = Quaternion.Euler(new Vector3(0, transform.eulerAngles.y + 90, 0));
    //}
}
