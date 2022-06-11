using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwingArea : MonoBehaviour
{
	[SerializeField]
	Transform player;
	public Transform hangPoint;

	[Range(5, 30)]
	public int radius;

	[Range(10, 180)]
	public float angle;

	[SerializeField]
	float maxSpeed;
	float hangPointSpeed;
	float moveAngle;
	float arcLength;
	float speedDirection;

	Vector3 right_arcPoint;
	Vector3 left_arcPoint;

	private void OnDrawGizmos()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawSphere(transform.position, 0.2f);
	}

	private void OnEnable()
	{
		StartCoroutine(SwingBob());
	}

	IEnumerator SwingBob()
	{
		makeSwingCalculations();

		while (true)
		{
			hangPointSpeed = Mathf.Lerp(hangPointSpeed, speedDirection * maxSpeed, Time.deltaTime);
			moveAngle += hangPointSpeed * Time.deltaTime;

			hangPoint.position = transform.position + Quaternion.AngleAxis(moveAngle, transform.forward) * Vector3.down * radius;

			compareArcLength();

			yield return new WaitForEndOfFrame();
		}
	}

	private void makeSwingCalculations()
	{
		//transform.position = new Vector3(player.position.x, player.position.y + radius, player.position.z);

		right_arcPoint = transform.position + Quaternion.AngleAxis(angle, transform.forward) * Vector3.down * radius;
		left_arcPoint = transform.position + Quaternion.AngleAxis(-angle, transform.forward) * Vector3.down * radius;

		hangPoint.position = new Vector3(transform.position.x, transform.position.y - radius, transform.position.z);

		arcLength = (2 * Mathf.PI * radius * angle) / 360;

		moveAngle = 0;
		hangPointSpeed = 0;
		speedDirection = -1;
	}

	private void compareArcLength()
	{
		float bobAngle = 180 - Vector3.Angle(transform.up, hangPoint.position - transform.position);

		float bobArcLength = (2 * Mathf.PI * radius * bobAngle) / 360;

		if (bobArcLength > arcLength)
		{
			if (Vector3.Distance(hangPoint.position, right_arcPoint) < Vector3.Distance(hangPoint.position, left_arcPoint)) speedDirection = -1;
			else speedDirection = 1;
		}
	}

	private void OnDisable()
	{
		StopCoroutine(SwingBob());
	}
}
