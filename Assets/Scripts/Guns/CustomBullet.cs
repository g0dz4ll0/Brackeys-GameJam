using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomBullet : MonoBehaviour
{
    //Referencias
    [Header("Referências")]
    public Rigidbody rb;
    public GameObject explosion;
    public LayerMask whatIsEnemies;

    //Estatísticas
    [Header("Estatísticas")]
    [Range(0f,1f)]
    public float bounciness;
    public bool useGravity;
    public bool isEnemyBullet;

    //Dano
    [Header("Dano")]
    public int explosionDamage;
    public float explosionRange;

    //Tempo de vida da bala
    [Header("Tempo De Vida Das Balas")]
    public int maxCollisions;
    public float maxLifeTime;
    public bool explodeOnTouch = true;

    int collisions;
    PhysicMaterial physics_mat;

    private void Start()
    {
        Setup();
    }

    private void Update()
    {
        //Quando explodir
        if (collisions > maxCollisions) Explode();

        //Contagem decrescente para o tempo de vida das balas
        maxLifeTime -= Time.deltaTime;
        if (maxLifeTime <= 0) Explode();
    }

    private void Explode()
    {
        //Instanciar a explosão
        if (explosion != null) Instantiate(explosion, transform.position, Quaternion.identity);

        
        //Verificar personagens e aplicar o dano
        Collider[] characters = Physics.OverlapSphere(transform.position, explosionRange, whatIsEnemies);
        for (int i = 0; i < characters.Length; i++)
        {
            if (characters[i].tag == "Enemy")
            {
                //Arranjar o componente do inimigo e chamar a função "TakeDamage"
                characters[i].GetComponent<Enemy>().TakeDamage(explosionDamage);
            }

            if (characters[i].tag == "Player")
            {
                //Arranjar o componente do jogador e chamar a função "TakeDamage"
                characters[i].GetComponent<Player>().TakeDamagePlayer(explosionDamage);
            }
            

        }

        Destroy(gameObject);
    }

    private void ExplodeOnShield(GameObject shield)
    {
        if (explosion != null) Instantiate(explosion, transform.position, Quaternion.identity);

        shield.GetComponent<ShieldDurability>().TakeDmg(explosionDamage);
        Destroy(gameObject);

    }

    private void OnCollisionEnter(Collision collision)
    {
        //Contar as colisões
        collisions++;

        //Explodir se as balas atingirem um inimigo/player diretamente ou a variável "explodeOnTouch" estiver verdadeira
        if (!isEnemyBullet)
            if (explodeOnTouch || collision.gameObject.tag == "Enemy") Explode();

        if(isEnemyBullet)
            if (explodeOnTouch || collision.gameObject.tag == "Player") Explode();        

    }

    private void OnTriggerEnter(Collider other)
    {
        if (isEnemyBullet)        
            if (explodeOnTouch || other.gameObject.tag == "WaterShield") ExplodeOnShield(other.gameObject);
        

        Debug.Log("Colidiu com o escudo!");
    }

    private void Setup()
    {
        //Criar um material de físicas novo
        physics_mat = new PhysicMaterial();
        physics_mat.bounciness = bounciness;
        physics_mat.frictionCombine = PhysicMaterialCombine.Minimum;
        physics_mat.bounceCombine = PhysicMaterialCombine.Maximum;
        //Atribuir o material ao collider
        GetComponent<SphereCollider>().material = physics_mat;

        //Definir a gravidade
        rb.useGravity = useGravity; 
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRange);
    }
}
