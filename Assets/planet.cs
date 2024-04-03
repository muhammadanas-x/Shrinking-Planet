using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class planet : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        transform.localScale = transform.localScale - new Vector3(0.001f, 0.001f, 0.001f);
        Debug.Log(transform.localScale);
    }
}
