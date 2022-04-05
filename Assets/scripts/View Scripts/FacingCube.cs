using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FacingCube : MonoBehaviour
{
    public float offset = 0.5f;

    private void Awake()
    {
        walkingController.OnFacingChange += RefreshFacing;
    }

    void RefreshFacing(FacingDirection fd)
    {
        switch (fd) {
            case FacingDirection.North:
                transform.localPosition = Vector3.forward * offset;
                break;
            case FacingDirection.East:
                transform.localPosition = Vector3.right * offset;
                break;
            case FacingDirection.West:
                transform.localPosition = Vector3.left * offset;
                break;
            default:
                transform.localPosition = Vector3.back * offset;
                break;
        }

    }
}
