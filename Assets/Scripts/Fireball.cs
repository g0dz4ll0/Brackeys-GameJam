using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{


    public GameObject fireballExplosion;

    public LayerMask WhatIsEnemy;

    public int ExplosionDmg;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }    

    private void Delay()
    {
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {

            Instantiate(fireballExplosion, transform.position, Quaternion.identity);

            collision.gameObject.GetComponent<Enemy>().TakeDamage(ExplosionDmg);

            Invoke("Delay", 0.05f);

        }
    }

}
