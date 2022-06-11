using PathCreation.Examples;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    Rigidbody rb;
    public GameObject rope;
    LineRenderer lineRenderer;
    [SerializeField]
    GameObject swingArea;
    [SerializeField]
    Transform bob, webPoint;

    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        
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
            InvokeRepeating("SetLine", 3, 300);
            swingArea.SetActive(true);
            lineRenderer.SetPosition(0, webPoint.position);
            lineRenderer.SetPosition(1, swingArea.transform.position);
            rope.GetComponent<PathFollower>().enabled = true;

        }
        if (other.gameObject.name == "TriggerB")
        {
            lineRenderer.enabled = false;
            rope.GetComponent<PathFollower>().enabled = false;
        }
    }

    void SetLine()
    {
        lineRenderer.enabled = true;
        swingArea.transform.rotation = Quaternion.Euler(new Vector3(0, transform.eulerAngles.y + 90, 0));
    }
}
