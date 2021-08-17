using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControls : MonoBehaviour
{
    int index;

    [SerializeField] float Speed;
    [SerializeField] float Distance;

    [SerializeField] Transform Target;
    [SerializeField] Transform[] Hotspots;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
            index = index < Hotspots.Length - 1 ? ++index : 0;

        else if (Input.GetKeyDown(KeyCode.LeftArrow))
            index = index > 0 ? --index : Hotspots.Length - 1;

        UpdateTransform();
    }

    void UpdateTransform()
    {
        var adjustedPosition = new Vector3(Target.position.x, Hotspots[index].position.y, Target.position.z);

        var direction = Hotspots[index].position - adjustedPosition;

        var newPosition = adjustedPosition + direction.normalized * Distance;

        transform.position = Vector3.MoveTowards(transform.position, newPosition, Speed * Time.deltaTime);

        transform.LookAt(Hotspots[index].position);
    }
}
