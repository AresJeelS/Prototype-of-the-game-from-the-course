using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public enum RopeState
{
    Disabled,
    Fly,
    Active
}

public class RoapGun : MonoBehaviour
{
    public Hook Hook;
    public Transform Spawn;
    public Transform RopeStart;
    public SpringJoint SpringJoint;
    public RopeState CurrentRopeState;
    public RopeRenderer RopeRenderer;
    public PlayerMove PlayerMove;

    public float Speed;

    private float _lenght;
    void Update()
    {
        if (Input.GetMouseButtonDown(2))
        {
            Shot();
        }
        if (CurrentRopeState == RopeState.Fly)
        {
            float distance = Vector3.Distance(RopeStart.position, Hook.transform.position);
            if (distance > 20f)
            {
                Hook.gameObject.SetActive(false);
                CurrentRopeState = RopeState.Disabled;
                RopeRenderer.Hide();
            }
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            
            if (CurrentRopeState == RopeState.Active)
            {
                if (PlayerMove.Grounded == false)
                {
                    PlayerMove.Jump();
                }
            }
            DestroySpring();
        }
        if (CurrentRopeState == RopeState.Fly || CurrentRopeState == RopeState.Active)
        {
            RopeRenderer.Draw(RopeStart.position, Hook.transform.position, _lenght);
        }
    }
    public void Shot()
    {


        if (SpringJoint)
        {
            Destroy(SpringJoint);
        }

        Hook.gameObject.SetActive(true);

        Hook.StopFix();
        Hook.transform.position = Spawn.position;
        Hook.transform.rotation = Spawn.rotation;
        Hook.Rigidbody.velocity = Spawn.forward * Speed;

        CurrentRopeState = RopeState.Fly;
    }
    public void CreateSpring()
    {
        if (SpringJoint == null)
        {
            SpringJoint = gameObject.AddComponent<SpringJoint>();
            SpringJoint.connectedBody = Hook.Rigidbody;
            SpringJoint.anchor = RopeStart.localPosition;
            SpringJoint.autoConfigureConnectedAnchor = false;
            SpringJoint.connectedAnchor = Vector3.zero;
            SpringJoint.spring = 100f;
            SpringJoint.damper = 5f;

            _lenght = Vector3.Distance(RopeStart.position, Hook.transform.position);
            SpringJoint.maxDistance = _lenght;

            CurrentRopeState = RopeState.Active;
        }
    }
    public void DestroySpring()
    {
        if (SpringJoint)
        {
            Destroy(SpringJoint);
            CurrentRopeState = RopeState.Disabled;
            Hook.gameObject.SetActive(false);
            RopeRenderer.Hide();
        }
    }
}
