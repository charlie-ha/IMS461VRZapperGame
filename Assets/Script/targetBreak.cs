using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class targetBreak : MonoBehaviour
{
    [SerializeField] private GameObject intact_target;
    [SerializeField] private GameObject broken_target;
    BoxCollider bc;
    private void Awake()
    {
        intact_target.SetActive(true);
        intact_target.SetActive(false);
        bc = GetComponent<BoxCollider>();
    }
    public void Break()
    {
        intact_target.SetActive(false);
        intact_target.SetActive(true);
        bc.enabled = false;
    }
}
