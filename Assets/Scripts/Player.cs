using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //Variáveis
    //Referências
    [Header("Referências")]
    public GameObject camera;
    public GameObject playerObj;
    public Rigidbody rb;

    //Movimento
    [Header("Movimento")]
    public float movementSpeed;
    public float jumpForce;
    public float dashForce;
    public float dashCooldown;

    //Estatísticas
    [Header("Estatísticas Gerais")]
    public float playerHealth;

    //Verificadores
    [Header("Verificadores")]
    public bool isGrounded;
    public bool hasDashed;

    private Vector3 movement;

    //Métodos
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Floor")
            isGrounded = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Floor")
            isGrounded = false;
    }

    void Update()
    {
        //Jogador a olhar para o cursor
        PlayerLook();

        //Movimento do jogador
        PlayerMovement();
    }

    private void PlayerLook()
    {
        Plane playerPlane = new Plane(Vector3.up, playerObj.transform.position);
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        float hitDist = 0.0f;

        if(playerPlane.Raycast(ray, out hitDist))
        {
            Vector3 targetPoint = ray.GetPoint(hitDist);
            Quaternion targetRotation = Quaternion.LookRotation(targetPoint - playerObj.transform.position);
            targetRotation.x = 0;
            targetRotation.z = 0;
            playerObj.transform.rotation = Quaternion.Slerp(playerObj.transform.rotation, targetRotation, 7f * Time.deltaTime);
        }
    }

    private void PlayerMovement()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.z = Input.GetAxisRaw("Vertical");

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
            rb.AddForce(playerObj.transform.up * jumpForce, ForceMode.Impulse);

        if (Input.GetKeyDown(KeyCode.LeftShift) && !hasDashed)
        {
            hasDashed = true;
            rb.AddForce(movement * dashForce, ForceMode.Impulse);
            Invoke("ResetDash", dashCooldown);
        }

        rb.MovePosition(rb.position + movement * movementSpeed * Time.deltaTime);
    }

    public void TakeDamagePlayer(int damage)
    {
        playerHealth -= damage;

        if (playerHealth <= 0) Invoke(nameof(Die), .5f);
    }

    private void ResetDash()
    {
        hasDashed = false;
    }

    private void Die()
    {
        Debug.Log("Morreste!");
    }
}
