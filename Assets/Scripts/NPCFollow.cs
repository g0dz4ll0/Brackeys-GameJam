using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCFollow : MonoBehaviour
{
    //Referências
    [Header("Referências")]
    public GameObject followerGameObject;
    public Transform npcFollow;
    public Player playerScript;

    //Variáveis para seguir
    [Header("Variáveis Para Seguir")]
    public NavMeshAgent agent;
    public Transform player;
    public bool isFollowing;
    private DialogueSystem dialogueSystem;

    //Variáveis de estatísticas de ataque
    [Header("Estatísticas De Ataque")]
    private bool alreadyAttacked;
    public GameObject projectile;
    public float timeBetweenAttacks;
    public float forwardForce = 32f;
    public float upwardForce = 8f;

    //Variáveis para os alvos e deteção de inimigos
    [Header("Alvos E Deteção")]
    public string enemyTag = "Enemy";
    private Transform target;
    private Enemy targetEnemy;
    public float range = 10f;

    public Transform Target
    {
        get { return target; }
    }

    private void Awake()
    {
        player = GameObject.Find("BaseWizard").transform;
        agent = GetComponent<NavMeshAgent>();
        dialogueSystem = FindObjectOfType<DialogueSystem>();
    }

    void Start()
    {
        InvokeRepeating ("UpdateTarget", 0f, 0.5f);
    }

    private void Update()
    {
        StartNPC();

        if(Vector3.Distance(playerScript.gameObject.transform.position, transform.position) > 20f)
        {
            transform.position = playerScript.gameObject.transform.position + new Vector3(3f, 0f, 3f);
            StartNPC();
        }
    }

    public void StartNPC()
    {
        if (dialogueSystem.dialogueEnded)
        {
            isFollowing = true;
            npcFollow.transform.parent = null;
            followerGameObject.SetActive(false);
        }

        if (isFollowing)
        {
            agent.SetDestination(player.position);
            this.gameObject.GetComponent<NPC>().enabled = false;
        }

            if (target != null)
                Attack();

    }

    private void Attack()
    {
        transform.LookAt(target);

        if (!alreadyAttacked)
        {
            //Código para atacar
            Rigidbody rb = Instantiate(projectile, transform.position, Quaternion.identity).GetComponent<Rigidbody>();

            rb.AddForce(transform.forward * forwardForce, ForceMode.Impulse);
            rb.AddForce(transform.up * upwardForce, ForceMode.Impulse);

            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }

    private void ResetAttack()
    {
        alreadyAttacked = false;
    }

    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;
        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
            targetEnemy = nearestEnemy.GetComponent<Enemy>();
        } else
        {
            target = null;
        }
    }
}
