using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotController : MonoBehaviour
{
    private void OnEnable()
    {
        StartCoroutine("Ilifetime");
    }
    private IEnumerator Ilifetime()
    {
        yield return new WaitForSeconds(4);
        gameObject.SetActive(false);
    }
}
