using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponRock : MonoBehaviour
{
    // Start is called before the first frame update
    public float targetX;
    public float targetY;
    public float targetZ;
    public float speed = 3;
    private Vector3 targetPosition;

    void Start()
    {
        targetPosition = new Vector3(targetX, targetY, targetZ);
    }

    // Update is called once per frame
    void Update()
    {
        var step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);
    }
}
