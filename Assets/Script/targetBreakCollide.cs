using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class targetBreakCollide : MonoBehaviour
{   
    BoxCollider bc;
    public targetBreak targetBreak;
    void Start()
    {
        //targetSpawner = GameObject.Find("Spawner").GetComponent<TargetSpawner>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("blaster"))
        {
            targetBreak.Break();
        }
    }
    
}
