using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KinematicController : MonoBehaviour
{
    [SerializeField] private float speed = 1;

    void Update()
    {
        Vector3 direction = Vector3.zero;

        direction.x = Input.GetAxisRaw("Horizontal");
        direction.z = Input.GetAxisRaw("Vertical");

        Vector3.ClampMagnitude(direction, 1);

        transform.position += direction * speed * Time.deltaTime;
    }
}
