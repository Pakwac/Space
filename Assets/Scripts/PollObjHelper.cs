using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PollObjHelper 
{
    GameObject currentgo;
    List<GameObject> list = new List<GameObject>();

    public GameObject Spawn(Vector3 position, List<GameObject> go)
    {
        if (list.Exists(e => e.activeSelf == false))
        {
            currentgo = list.Find(x => x.activeSelf == false);
            currentgo.transform.position = position;
            currentgo.SetActive(true);
        }
        else
        {
            currentgo = MonoBehaviour.Instantiate<GameObject>(go[Random.Range(0, go.Count)]);
            currentgo.transform.position = position;
            currentgo.SetActive(true);
            list.Add(currentgo);
        }
        return currentgo;
    }

    public GameObject Spawn(Vector3 position, List<GameObject> go, Vector3 speed)
    {
        if (list.Exists(e => e.activeSelf == false))
        {
            currentgo = list.Find(x => x.activeSelf == false);
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
                currentgo = MonoBehaviour.Instantiate<GameObject>(go[Random.Range(0, go.Count)]);
                currentgo.transform.position = position;
                currentgo.SetActive(true);
            if (currentgo.GetComponent<Rigidbody>() != null)
            {
                currentgo.GetComponent<Rigidbody>().velocity = speed;
                currentgo.GetComponent<Rigidbody>().angularVelocity = Random.insideUnitSphere;
                currentgo.GetComponent<Transform>().rotation = Random.rotation;
            }
                list.Add(currentgo);
        }
        return currentgo;
    }

    public GameObject Spawn(Vector3 position, List<GameObject> go, Vector3 speed, Quaternion rotation)
    {
        if (list.Exists(e => e.activeSelf == false))
        {
            currentgo = list.Find(x => x.activeSelf == false);
            currentgo.transform.position = position;
            if (currentgo.GetComponent<Rigidbody>() != null)
            {
                currentgo.GetComponent<Rigidbody>().velocity = speed;
                currentgo.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
                currentgo.GetComponent<Transform>().rotation = Quaternion.identity;
            }
            currentgo.SetActive(true);
        }
        else
        {
            currentgo = MonoBehaviour.Instantiate<GameObject>(go[Random.Range(0, go.Count)]);
            currentgo.transform.position = position;
            currentgo.SetActive(true);
            if (currentgo.GetComponent<Rigidbody>() != null)
            {
                currentgo.GetComponent<Rigidbody>().velocity = speed;
                currentgo.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
                currentgo.GetComponent<Transform>().rotation = Quaternion.identity;
            }
            list.Add(currentgo);
        }
        return currentgo;
    }

    public void OnDamage(Transform currentOnDamage)
    {
        currentOnDamage.gameObject.SetActive(false);
    }
}
