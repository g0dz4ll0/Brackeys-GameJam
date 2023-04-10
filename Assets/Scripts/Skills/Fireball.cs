using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{


    public GameObject fireballExplosion;

    public LayerMask WhatIsEnemy;

    public int ExplosionDmg;

    public float lifetime;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        lifetime -= Time.deltaTime;

        if (lifetime <= 0) Explode();
    }    

    private void Delay()
    {
        Destroy(gameObject);
    }

    public void Explode()
    {

        fireballExplosion.transform.localScale += Vector3.one * 2f;

        Instantiate(fireballExplosion, transform.position, Quaternion.identity);

        Invoke("Delay", 0.05f);

        fireballExplosion.transform.localScale -= Vector3.one * 2f;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            fireballExplosion.transform.localScale += Vector3.one * 2f;
            Instantiate(fireballExplosion, transform.position, Quaternion.identity);

            collision.gameObject.GetComponent<Enemy>().TakeDamage(ExplosionDmg);

            Invoke("Delay", 0.05f);

            fireballExplosion.transform.localScale -= Vector3.one * 2f;

        }
    }

}
