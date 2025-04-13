using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class targetBreak : MonoBehaviour
{
    [SerializeField] private GameObject intact_target;
    [SerializeField] private GameObject broken_target;
    BoxCollider bc;
    private TargetSpawner targetSpawner;
    private void Awake()
    {
        targetSpawner = GameObject.Find("Spawner").GetComponent<TargetSpawner>();
        intact_target.SetActive(true);
        broken_target.SetActive(false);
        bc = GetComponent<BoxCollider>();
        //Debug.Log("awake");
    }
    public void Break()
    {
        intact_target.SetActive(false);
        broken_target.SetActive(true);
        targetSpawner.targetsInGameAmount--;
        if(bc != null)
        {
            bc.enabled = false;
        }
        
        //Debug.Log("broken");
    }
}
