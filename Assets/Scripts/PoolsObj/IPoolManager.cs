using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPoolManager
{
    GameObject GetObjectFromPool(PoolType pt);
    void ReturnToPool(GameObject obj, PoolType pt);
}
