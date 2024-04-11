using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitScanAmmo : MonoBehaviour
{
	[SerializeField] private float distance = 10f;
	[SerializeField] GameObject hitPrefab;
	[SerializeField] private LayerMask layerMask = Physics.AllLayers;

	private void Start()
	{
		if (Physics.Raycast(transform.position, transform.forward, out RaycastHit raycastHit, distance, layerMask))
		{
			if (hitPrefab != null)
			{
				Instantiate(hitPrefab, raycastHit.point, Quaternion.LookRotation(raycastHit.normal));
			}
		}
		Color color = (raycastHit.collider != null) ? Color.red : Color.green;
		Debug.DrawRay(transform.position, transform.forward * distance, color, 1);


		Destroy(gameObject);
	}
}
