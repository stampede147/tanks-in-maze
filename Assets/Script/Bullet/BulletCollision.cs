using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollision : MonoBehaviour
{

    public GameObject relOwner;

    public int maxReflections = 5;

    private int currentRelfections;

    // Start is called before the first frame update
    void Start()
    {
        currentRelfections = 0;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        destroyIfNeeded();
    }

    private void destroyIfNeeded()
    {
        if (++currentRelfections > maxReflections) {
            Destroy(gameObject);
        }
    }

}
