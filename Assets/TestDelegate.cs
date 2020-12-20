using System.Collections;
using System.Collections.Generic;
using UnityEngine;


        

public class TestDelegate : MonoBehaviour
{
    string a = "Hey";
    public delegate void TestD();

    public static event TestD someAction;


    // Start is called before the first frame update
    void Start()
    {
        SomeOther();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SomeOther()
    {
        someAction();
    }
}
