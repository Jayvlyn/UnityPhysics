using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BlockbusterPoints : MonoBehaviour
{
	public int points = 0;
	public TextMeshProUGUI pointsText;
	private bool countPoints = false;

	private void Start()
	{
		StartCoroutine(CountPoints());
	}

	private void OnCollisionEnter(Collision collision)
	{
        if (countPoints)
        {
			if (!collision.gameObject.tag.Equals("CannonBall"))
			{
				points += 1000;
				pointsText.text = "Score: " + points;
			}
        }
	}

	private IEnumerator CountPoints()
	{
		yield return new WaitForSeconds(1);
		countPoints = true;
	}
}
