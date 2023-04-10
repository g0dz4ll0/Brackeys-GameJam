using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileGun : MonoBehaviour
{
    //bala
    [Header("Balas")]
    public GameObject bullet;
    public CustomBullet bulletScript;

    //força da bala
    public float shootForce, upwardForce, defaultShootForce, defaultUpwardForce;

    //Estatísticas da arma
    [Header("Stats da arma")]
    public float timeBetweenShooting; 
    public float spreadAngle; 
    public float timeBetweenShots;
    public int bulletsPerTap;
    public int bulletsShot = 0;
    public bool allowButtonHold;

    //bools
    bool shooting, readyToShoot;

    //Referencias
    [Header("Referências")]
    public Camera cam;
    public Transform attackPoint;
    public Animator anim;

    //Gráficos
    [Header("Gráficos")]
    public GameObject muzzleFlash;

    [Header("Debugging")]
    public bool allowInvoke = true;

    //Áudio
    [Header("Áudio")]
    public AudioSource shoot;
    public AudioClip shootClip;

    private void Awake()
    {
        readyToShoot = true;
        defaultShootForce = shootForce;
        defaultUpwardForce = upwardForce;
    }

    private void Update()
    {
        MyInput();    
    }

    private void MyInput()
    {
        //Verificar se é permitido manter pressionado o butão e fazer o input correspondente
        if (allowButtonHold) shooting = Input.GetKey(KeyCode.Mouse0);
        else shooting = Input.GetKeyDown(KeyCode.Mouse0);

        //Disparar
        if (readyToShoot && shooting)
        {
            //Definir o número de balas disparadas para 0
            bulletsShot = 0;

            Shoot();
        }
    }

    private void Shoot()
    {
        readyToShoot = false;

        shoot.PlayOneShot(shootClip, 1F);

        if (anim != null)
            anim.SetTrigger("isReloading");

        //Instanciar a bala/projetil
        GameObject currentBullet = Instantiate(bullet, attackPoint.transform.position, Quaternion.identity); //guardar a bala/projetil instanciado

        //Calcular a separação da balas
        Vector3 dir = transform.forward + new Vector3 (Random.Range(-spreadAngle, spreadAngle), 
                                                      0, 
                                                      Random.Range(-spreadAngle, spreadAngle));

        //Adicionar forças às balas
        currentBullet.GetComponent<Rigidbody>().AddForce(attackPoint.transform.forward * shootForce, ForceMode.Impulse);
        currentBullet.GetComponent<Rigidbody>().AddForce(attackPoint.transform.up * upwardForce, ForceMode.Impulse);

        //Se houver separação de balas aplicar o respetivo ângulo
        if (spreadAngle != 0)
            currentBullet.GetComponent<Rigidbody>().AddForce(dir, ForceMode.Impulse);

        //Instanciar o "Muzzle Flash", se houver um
        if (muzzleFlash != null)
            Instantiate(muzzleFlash, attackPoint.position, Quaternion.identity);

        bulletsShot++;

        //Invocar a função "ResetShot" (se ainda não foi invocada)
        if (allowInvoke)
        {
            Invoke("ResetShot", timeBetweenShooting);
            allowInvoke = false;
        }

        //se houver mais que uma bala por clique certificar que repetimos a função de disparo
        if (bulletsShot < bulletsPerTap)
            Invoke("Shoot", timeBetweenShots);
    }

    private void ResetShot()
    {
        //Permitir disparar e invocar de novo
        readyToShoot = true;
        allowInvoke = true;
    }
}
