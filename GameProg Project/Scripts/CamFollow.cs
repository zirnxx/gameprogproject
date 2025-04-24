using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float followSpeed;

    private void FixedUpdate(){
        Vector3 targetposition = target.TransformPoint(new Vector3(0, 0, -10));
        transform.position = Vector3.Lerp(transform.position, targetposition, followSpeed);
    }
}
