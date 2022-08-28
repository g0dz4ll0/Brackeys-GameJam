using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

[System.Serializable]
public class NPC : MonoBehaviour
{
    //Referências
    [Header("Referências")]
    public Transform ChatBackGround;
    public Transform NPCCharacter;
    public Transform player;
    private DialogueSystem dialogueSystem;
    public float interactionRange;
    private ProjectileGun equippedGun;
    public GameObject gunContainer;
    public GameObject nextWaveSpawner;
    private NPCFollow npcFollow;

    //Tipos de pet
    [Header("Identificação Do Pet")]
    public bool isShock;
    public bool isWater;
    public bool isRock;
    public bool isFire; 
    public string Name;

    //Texto Para Diálogo
    [Header("Texto Para Diálogo")]
    [TextArea(5, 10)]
    public string[] sentences;

    void Awake()
    {
        dialogueSystem = FindObjectOfType<DialogueSystem>();
        npcFollow = GetComponent<NPCFollow>();
    }

    void Update()
    {
        DialogueSetup();
        StartDialogue();
        EndDialogue();
    }

    public void DialogueSetup()
    {
        Vector3 Pos = Camera.main.WorldToScreenPoint(NPCCharacter.position);
        Pos.y += 100;
        ChatBackGround.position = Pos;
    }

    public void StartDialogue()
    {
        Vector3 distanceToPlayer = player.position - transform.position;
        if (distanceToPlayer.magnitude <= interactionRange)
        {
            FindObjectOfType<DialogueSystem>().EnterRangeOfNPC();
            if (Input.GetKeyDown(KeyCode.F))
            {
                dialogueSystem.Names = Name;
                dialogueSystem.dialogueLines = sentences;
                FindObjectOfType<DialogueSystem>().NPCName();
            }
        }
    }

    public void EndDialogue()
    {
        if (dialogueSystem.dialogueEnded)
        {
            equippedGun = gunContainer.GetComponentInChildren<ProjectileGun>();

            nextWaveSpawner.SetActive(true);

            //if (equippedGun == null)
            //{
            //    Debug.Log("Nenhuma arma equipada!");
            //}
            //else
            //{
            //    if (isShock)
            //    {
            //        if (equippedGun.timeBetweenShooting > 0)
            //            equippedGun.timeBetweenShooting -= 1.5f;

            //        equippedGun.bulletScript.useGravity = true;
            //        equippedGun.bulletScript.explodeOnTouch = false;

            //        if (equippedGun.shootForce - 75f > 0)
            //            equippedGun.shootForce -= 75f;

            //        equippedGun.bulletScript.maxCollisions += 3;

            //        if (equippedGun.bulletScript.bounciness < 1f)
            //            equippedGun.bulletScript.bounciness = 0.8f;

            //        if (equippedGun.timeBetweenShooting + 0.8f <= 0)
            //        {
            //            equippedGun.timeBetweenShooting = 0.05f;
            //        }
            //    }

            //    if (isWater)
            //    {
            //        equippedGun.spreadAngle += 10;
            //    }

            //    if (isRock)
            //    {
            //        equippedGun.bullet.transform.localScale *= 2f;
            //        equippedGun.timeBetweenShooting += 1f;
            //        equippedGun.bulletScript.useGravity = true;
            //        equippedGun.bulletScript.explodeOnTouch = false;

            //        if (equippedGun.shootForce - 75f > 0)
            //            equippedGun.shootForce -= 75f;

            //        equippedGun.bulletScript.maxCollisions += 3;

            //        if (equippedGun.bulletScript.bounciness + 0.8f < 1f)
            //            equippedGun.bulletScript.bounciness = 0.8f;
            //    }

            //    if (isFire)
            //    {
            //        equippedGun.bullet.transform.localScale *= 2f;
            //        equippedGun.timeBetweenShooting += 1f;
            //        equippedGun.bulletScript.useGravity = true;
            //        equippedGun.bulletScript.explodeOnTouch = false;

            //        if (equippedGun.shootForce - 75f > 0)
            //            equippedGun.shootForce -= 75f;

            //        equippedGun.bulletScript.maxCollisions += 3;

            //        if (equippedGun.bulletScript.bounciness + 0.8f < 1f)
            //            equippedGun.bulletScript.bounciness = 0.8f;

            //        equippedGun.bulletScript.explosionDamage += 50;
            //        equippedGun.bulletScript.explosionRange += 5f;
            //    }
            //}
        } 
    }

    public void OnTriggerExit()
    {
        if (!npcFollow.isFollowing)
        {
            FindObjectOfType<DialogueSystem>().OutOfRange();
            this.gameObject.GetComponent<NPC>().enabled = false;
            this.gameObject.GetComponent<NPCFollow>().enabled = false;
        }
    }
}
