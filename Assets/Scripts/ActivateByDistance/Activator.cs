using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activator : MonoBehaviour
{
    public List<ActivateByDistance> ObjectsToActivate = new List<ActivateByDistance>();
    public Transform PlayerTransform;
    // Этот скрипт нужен для активации другого скрипта, потому что после скрытия объекта он не может вызвать сам себя
    void Update()
    {
        for (int i = 0; i < ObjectsToActivate.Count; i++)
        {
            ObjectsToActivate[i].CheckDistance(PlayerTransform.position);
        }
    }
}
