using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepMuover : MonoBehaviour
{
    


    void Update()
    {
        gameObject.transform.Rotate(Vector3.up * 10 * Time.deltaTime);
    }
}
