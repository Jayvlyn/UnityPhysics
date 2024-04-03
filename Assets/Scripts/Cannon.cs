using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    [SerializeField] private GameObject cannonBall;
    [SerializeField] private Transform firePoint;

	[SerializeField] int shots = 5;
	public TextMeshProUGUI shotsText;
	[SerializeField] GameObject endUI;

	private void Awake()
	{
		endUI.SetActive(false);
        UpdateShotsUI();
	}

	void Update()
    {
        if (Input.GetMouseButtonDown(0) && shots > 0)
        {
            shots--;
            UpdateShotsUI();
            GameObject ball = Instantiate(cannonBall, firePoint.position, Quaternion.identity);
            if(ball.TryGetComponent(out Rigidbody cannonRb))
            {
                cannonRb.AddForce(firePoint.transform.up * 50, ForceMode.Impulse);
            }
            if(shots <= 0) StartCoroutine(EndGame());
        }
    }

    private void UpdateShotsUI()
    {
		shotsText.text = "Shots Left: " + shots;
	}

    private IEnumerator EndGame()
    {
        yield return new WaitForSeconds(5);
        endUI.SetActive(true);
    }
}
