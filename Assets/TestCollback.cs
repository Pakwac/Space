using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCollback : MonoBehaviour
{
    string a = null;
    // Start is called before the first frame update
    void Start()
    {
        TestDelegate.someAction += TestMethod;
    }

    // Update is called once per frame
    void Update()
    {
        //TestMethod(a);
    }
    public void TestMethod()
    {
        Debug.Log("Получилось");
    }
}
