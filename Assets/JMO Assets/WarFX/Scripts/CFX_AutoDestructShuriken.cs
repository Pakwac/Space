using UnityEngine;
using System.Collections;
using Zenject;

[RequireComponent(typeof(ParticleSystem))]
public class CFX_AutoDestructShuriken : MonoBehaviour
{
    [Inject]
    PoolManager poolManager;

    public bool OnlyDeactivate;

    void OnEnable()
    {
        StartCoroutine("CheckIfAlive");
    }

    IEnumerator CheckIfAlive()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.5f);
            if (!GetComponent<ParticleSystem>().IsAlive(true))
            {

                //GetComponentInParent<Explosion>().gameObject.SetActive(false);
                break;
            }
        }
    }
}
