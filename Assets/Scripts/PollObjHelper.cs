using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PollObjHelper 
{
    
    List<GameObject> list = new List<GameObject>();
    Vector3 speed;
    
    public void Spawn(Vector3 position, GameObject go)
    {
        if (list.Exists(e => e.activeSelf == false))
        {
            var currentgo = list.Find(x => x.activeSelf == false);
            currentgo.transform.position = position;
            currentgo.SetActive(true);
        }
        else
        {
                var currentgo = MonoBehaviour.Instantiate<GameObject>(go);
                currentgo.transform.position = position;
                currentgo.SetActive(true);
                list.Add(currentgo);
        }
    }

    public void Spawn(Vector3 position, GameObject go, Vector3 speed)
    {
        if (list.Exists(e => e.activeSelf == false))
        {
            var currentgo = list.Find(x => x.activeSelf == false);
            currentgo.transform.position = position;
            if (currentgo.GetComponent<Rigidbody>() != null)
            {
                currentgo.GetComponent<Rigidbody>().velocity = speed;
                currentgo.GetComponent<Rigidbody>().angularVelocity = Random.insideUnitSphere;
                currentgo.GetComponent<Transform>().rotation = Random.rotation;
            }
            currentgo.SetActive(true);
        }
        else
        {
                var currentgo = MonoBehaviour.Instantiate<GameObject>(go);
                currentgo.transform.position = position;
                currentgo.SetActive(true);
                list.Add(currentgo);
        }
    }

    public void OnDamage(Transform currentOnDamage)
    {
        currentOnDamage.gameObject.SetActive(false);
    }
}
