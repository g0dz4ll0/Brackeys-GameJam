using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class Skills : MonoBehaviour
{

    [Header("Referencias de Skills")]

    public GameObject waterSkill;
    public VisualEffect LightningBolt;

    [Header("Referencias dos NPCs")]

    [SerializeField] public GameObject NPCFire;
    public GameObject NPCWater;
    public GameObject NPCShock;
    public GameObject NPCEarth;

    [Header("Propriedades das Skills")]

    List<bool> activatedSkills;
    List<float> skillsCooldowns;
    List<float> skillTimers;

    public int LightningSkillDamage;

    //Ordem nas listas: Fire, Water, Electric, Grass, Earth

    Transform enemyTarget;

    private void Awake()
    {
        
        skillsCooldowns = new List<float>();
        skillTimers = new List<float>();

        activatedSkills = new List<bool>();

        for (int i = 0; i < 5; i++)
        {

            skillsCooldowns.Add(5f);
            skillTimers.Add(0f);
            activatedSkills.Add(false);
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        enemyTarget = null;
    }

    // Update is called once per frame
    void Update()
    {
        
        for(int i = 0; i < activatedSkills.Count; i++)
        {

            if (activatedSkills[i])
            {

                if(skillTimers[i] > 0f) skillTimers[i] -= Time.deltaTime;

                if(skillTimers[i] < 0f) skillTimers[i] = 0f;

                
            }

        }

        ActivateSkills();

    }



    public void ActivatePet(string element)
    {

        switch (element)
        {

            case "FirePet":

                activatedSkills[0] = true;

                break;
            case "NPCWater":

                activatedSkills[1] = true;

                break;
            case "NPCShock":

                activatedSkills[2] = true;

                break;
            case "Grass":

                activatedSkills[3] = true;

                break;
            case "NPCRock":

                activatedSkills[4] = true;

                break;

        }

    }


    public void DeActivatePet(string element)
    {

        switch (element)
        {

            case "FirePet":

                activatedSkills[0] = false;

                break;
            case "NPCWater":

                activatedSkills[1] = false;

                break;
            case "NPCShock":

                activatedSkills[2] = false;

                break;
            case "Grass":

                activatedSkills[3] = false;

                break;
            case "NPCRock":

                activatedSkills[4] = false;

                break;

        }

    }



    public void ActivateSkills()
    {

        //Fire



        //Water

        if(activatedSkills[1] && skillTimers[1] <= 0f)
        {
            ActivateWater();
        }

        //Shock

        if (activatedSkills[2] && skillTimers[2] == 0f)
        {
            enemyTarget = NPCShock.GetComponent<NPCFollow>().Target;

            if (enemyTarget != null)
            {

                ActivateLightning();

            }

        }

        //Earth

    }


    public void ActivateFire()
    {



    }



    public void ActivateWater()
    {

        waterSkill.SetActive(true);

    }

    public void DeActivateWater()
    {

        waterSkill.SetActive(false);
        skillTimers[1] = skillsCooldowns[1];

    }



    public void ActivateLightning()
    {
        Debug.Log("Before : " + LightningBolt.GetAnimationCurve("LightningLenghtOverTimeCurve").keys[1].value);

        float Distance = Vector3.Distance(transform.position, enemyTarget.position) - 5f;


        AnimationCurve newCurve = new AnimationCurve();

        newCurve.AddKey(LightningBolt.GetAnimationCurve("LightningLenghtOverTimeCurve").keys[0]);
        newCurve.AddKey(LightningBolt.GetAnimationCurve("LightningLenghtOverTimeCurve").keys[1].time, Distance);

        LightningBolt.SetAnimationCurve("LightningLenghtOverTimeCurve", newCurve);

        Debug.Log("After : " + LightningBolt.GetAnimationCurve("LightningLenghtOverTimeCurve").keys[1].value);
        LightningBolt.Play();

        enemyTarget.GetComponent<Enemy>().TakeDamage(LightningSkillDamage);

        skillTimers[2] = skillsCooldowns[2];
    }



    public void ActivateEarth()
    {

    }



}
