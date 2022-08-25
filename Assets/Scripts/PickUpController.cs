using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpController : MonoBehaviour
{
    [Header("Referências")]
    public ProjectileGun gunScript;
    public Rigidbody rb;
    public BoxCollider coll;
    public Transform player, gunContainer;
    public WaveSpawner waveSpawner;
    public AudioSource pickUp;

    [Header("Forças e Alcances")]
    public float pickUpRange;
    public float dropForwardForce, dropUpwardForce;

    [Header("Verificadores")]
    public bool equipped;
    public static bool slotFull;

    private void Start()
    {
        //Setup
        if (!equipped)
        {
            gunScript.enabled = false;
            rb.isKinematic = false;
            coll.isTrigger = false;
        }
        if (equipped)
        {
            gunScript.enabled = true;
            rb.isKinematic = true;
            coll.isTrigger = true;
            slotFull = true;
        }
    }

    private void Update()
    {
        //Verificar se o jogador está dentro do alcance e pressionou a tecla "E"
        Vector3 distanceToPlayer = player.position - transform.position;
        if (!equipped && distanceToPlayer.magnitude <= pickUpRange && Input.GetKeyDown(KeyCode.E) && !slotFull)
        {
            PickUp();
            waveSpawner.enabled = true;
        }

        //Atirar a arma se estiver equipada e o botão "Q" for pressionado
        if (equipped && Input.GetKeyDown(KeyCode.Q)) Drop(); 
    }

    private void PickUp()
    {
        equipped = true;
        slotFull = true;

        pickUp.Play();

        //Tornar a arma um child do GunContainer e movê-la para a sua posição default
        transform.SetParent(gunContainer);
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.Euler(Vector3.zero);
        transform.localScale = Vector3.one;

        //Tornar o Rigidbody para kinematic e o BoxCollider para um trigger
        rb.isKinematic = true;
        coll.isTrigger = true;

        //Ativar o script
        gunScript.enabled = true;
    }

    private void Drop()
    {
        equipped = false;
        slotFull = false;

        //Retirar o parent da arma
        transform.SetParent(null);

        //Tornar o Rigidbody para não kinematic e o BoxCollider para normal
        rb.isKinematic = false;
        coll.isTrigger = false;

        //A arma fica com o momentum do jogador
        rb.velocity = player.GetComponent<Rigidbody>().velocity;

        //Adicionar forças
        rb.AddForce(gunContainer.forward * dropForwardForce, ForceMode.Impulse);
        rb.AddForce(gunContainer.up * dropUpwardForce, ForceMode.Impulse);
        //Adicionar uma rotação aleatória
        float random = Random.Range(-1f, 1f);
        rb.AddTorque(new Vector3(random, random, random) * 10);

        //desativar o script
        gunScript.enabled = false; 
    }
}
