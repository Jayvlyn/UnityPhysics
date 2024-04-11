using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] private GameObject explosionPrefab;

	private void OnTriggerEnter(Collider other)
	{
		Instantiate(explosionPrefab,transform.position, transform.rotation);
	}
}
