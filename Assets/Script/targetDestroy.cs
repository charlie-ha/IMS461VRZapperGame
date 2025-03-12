using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class targetDestroy : MonoBehaviour
{
    void Update()
    {
        Destroy(this.gameObject, 2);
    }
}
