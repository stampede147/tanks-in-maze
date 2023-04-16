using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime.Collections;
using UnityEditor;
using UnityEngine;

public class TankShooting : MonoBehaviour
{
    public Rigidbody bullet;                   
    public Transform startPoint;           
    public float minLaunchForce = 15f;        
    public float MaxLaunchForce = 30f;        
    public float maxChargeTime = 0.75f;       
    public int maxBullets = 5;

    private string fireButton;                
    private float launchForce;         
    private float chargeSpeed;                
    private bool isOnFire;                       
    private int currentBullets;
    private Rigidbody[] lastFiredBullets;

    private void OnEnable()
    {
        
        launchForce = minLaunchForce;
    }


    private void Start()
    {
        fireButton = "Fire";
        currentBullets = maxBullets;
        chargeSpeed = (MaxLaunchForce - minLaunchForce) / maxChargeTime;
        lastFiredBullets = new Rigidbody[maxBullets];
    }


    private void Update()
    {
        if (launchForce >= MaxLaunchForce && !isOnFire)
        {
            launchForce = MaxLaunchForce;
            Fire();
        }
        else if (Input.GetButtonDown(fireButton))
        {
            isOnFire = false;
            launchForce = minLaunchForce;

        }
        else if (Input.GetButton(fireButton) && !isOnFire)
        {
            launchForce += chargeSpeed * Time.deltaTime;

        }
        else if (Input.GetButtonUp(fireButton) && !isOnFire)
        {
            Fire();
        }
    }


    private void Fire()
    {

        DeleteDestroyedBullets();
        if (currentBullets > 0)
        {
            DoFire();
        }
    }

    private void DoFire()
    {
        isOnFire = true;

        lastFiredBullets[--currentBullets] =
            Instantiate(bullet, startPoint.position, startPoint.rotation) as Rigidbody;
        lastFiredBullets[currentBullets].velocity = 
            launchForce * startPoint.forward; ;

        launchForce = minLaunchForce;

    }
    private void DeleteDestroyedBullets()
    {
        for (int i = currentBullets; i < maxBullets; i++)
        {
            if (UnityObjectUtility.IsDestroyed(lastFiredBullets[i]))
            {
                lastFiredBullets[i] = null;
                currentBullets++;
            }

        }
    }
}