using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pointer : MonoBehaviour
{
    public Transform Aim;
    public Camera PlayerCamera;
    public Transform Body;

    private float _yEuler;
    private void LateUpdate()
    {
        // Луч
        Ray ray = PlayerCamera.ScreenPointToRay(Input.mousePosition);

        Debug.DrawRay(ray.origin, ray.direction * 50);

        // Плоскость
        Plane plane = new Plane(-Vector3.forward, Vector3.zero);

        // Повзоляет выстрелить в плоскость лучем
        float distance;
        plane.Raycast(ray, out distance);
        Vector3 point = ray.GetPoint(distance);

        Aim.position = point;

        // Пистолет следует за прицелом
        Vector3 toAim = Aim.position - transform.position;
        transform.rotation = Quaternion.LookRotation(toAim);

        if (toAim.x < 0)
        {
            _yEuler = Mathf.Lerp(_yEuler, 45f, Time.deltaTime * 8f);

        }
        else
        {
            _yEuler = Mathf.Lerp(_yEuler, -45f, Time.deltaTime * 8f);
        }
        Body.localEulerAngles = new Vector3(0, _yEuler, 0);
    }
}
