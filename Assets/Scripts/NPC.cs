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

    //Tipos de pet
    [Header("Identificação Do Pet")]
    public bool isShock;
    public bool isWater; 
    public string Name;

    //Texto Para Diálogo
    [Header("Texto Para Diálogo")]
    [TextArea(5, 10)]
    public string[] sentences;

    void Start()
    {
        dialogueSystem = FindObjectOfType<DialogueSystem>();
    }

    void Update()
    {
        Vector3 Pos = UnityEngine.Camera.main.WorldToScreenPoint(NPCCharacter.position);
        Pos.y += 100;
        ChatBackGround.position = Pos;

        Vector3 distanceToPlayer = player.position - transform.position;
        if (distanceToPlayer.magnitude <= interactionRange)
        {
            this.gameObject.GetComponent<NPC>().enabled = true;
            FindObjectOfType<DialogueSystem>().EnterRangeOfNPC();
            if (Input.GetKeyDown(KeyCode.F))
            {
                this.gameObject.GetComponent<NPC>().enabled = true;
                dialogueSystem.Names = Name;
                dialogueSystem.dialogueLines = sentences;
                FindObjectOfType<DialogueSystem>().NPCName();
            }
        } 
    }

    public void OnTriggerExit()
    {
        FindObjectOfType<DialogueSystem>().OutOfRange();
        this.gameObject.GetComponent<NPC>().enabled = false;
    }
}
