using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileHandler : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject projectile;
  
    void Start()
    {
   
    }

    // Update is called once per frame
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("ProjectilePickup"))
        {
            other.gameObject.SetActive(false);
            SummonProjectile();
        }
    }

    void SummonProjectile()
    {
        GameObject p = Instantiate(projectile);
        p.transform.position = new Vector3(Random.Range(-2, 2), 2, 0);
    }
}
