using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{

    [SerializeField] Transform camerPosition;

    // Update is called once per frame
    void Update()
    {
        transform.position = camerPosition.position;
    }
}
