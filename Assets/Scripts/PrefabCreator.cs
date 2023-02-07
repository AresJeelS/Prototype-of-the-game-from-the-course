using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabCreator : MonoBehaviour
{
    public GameObject prefab;
    public Transform spawn;
    public void Create()
    {
        Instantiate(prefab, spawn.position, spawn.rotation);
    }

}
