using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class PlayerHitbox : MonoBehaviour
{
    // collider movement
    public float offset = 1f;
    BoxCollider col;

    //collider duration
    float duration;

    //secondary float value
    float secondary;

    private void Awake()
    {
        walkingController.OnFacingChange += RefreshFacing;
        walkingController.OnInteract += StartCollisionCheck;
        col = GetComponent<BoxCollider>();
        col.enabled = false;
    }

    private void Update()
    {
        if (col.enabled)
        {
            duration -= Time.deltaTime;
            if (duration <= 0)
            {
                col.enabled = false;
            }
        }
    }

    void StartCollisionCheck(float dur, float sec) {
        col.enabled = true;
        duration = dur;
        secondary = sec;
    }

    void RefreshFacing(FacingDirection fd)
    {
        switch (fd)
        {
            case FacingDirection.North:
                col.center = Vector3.forward * offset;
                break;
            case FacingDirection.East:
                col.center = Vector3.right * offset;
                break;
            case FacingDirection.West:
                col.center = Vector3.left * offset;
                break;
            default:
                col.center = Vector3.back * offset;
                break;
        }

    }
    void OnTriggerEnter(Collider col)
    {
        //col.GetComponent<InteractObject>().interact();
        col.GetComponent<AttackableObject>().TakeDamage(secondary);
    }


}
