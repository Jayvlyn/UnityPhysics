using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsCollider : MonoBehaviour
{
	string status = "";
	Vector3 contact;
	Vector3 normal;
	[SerializeField] private GameObject explosion;

	private void OnCollisionEnter(Collision collision)
	{
		status = "collision enter: " + collision.gameObject.name;

		contact = collision.GetContact(0).point;
		normal = collision.GetContact(0).normal;

		Instantiate(explosion, contact, Quaternion.LookRotation(normal));
	}

	private void OnCollisionStay(Collision collision)
	{
		status = "collision stay: " + collision.gameObject.name;
	}

	private void OnCollisionExit(Collision collision)
	{
		status = "collision exit: " + collision.gameObject.name;
	}

	private void OnTriggerEnter(Collider other)
	{
		status = "collision enter: " + other.gameObject.name;
	}

	private void OnTriggerStay(Collider other)
	{
		status = "collision stay: " + other.gameObject.name;
	}

	private void OnTriggerExit(Collider other)
	{
		status = "collision exit: " + other.gameObject.name;
	}

	private void OnGUI()
	{
		GUI.skin.label.fontSize = 24;
		Vector2 screen = Camera.main.WorldToScreenPoint(transform.position);
		GUI.Label(new Rect(screen.x, Screen.height - screen.y, 250, 70), status);
	}

	private void OnDrawGizmos()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawSphere(contact, 0.1f);
		Gizmos.DrawLine(contact, contact + normal);
	}
}
