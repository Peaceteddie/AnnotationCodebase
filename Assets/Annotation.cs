using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Annotation : MonoBehaviour
{
    Camera Main;
    CanvasGroup Group;
    Transform Child;
    void Start()
    {
        Main = Camera.main;
        Child = transform.GetChild(0);
        Group = GetComponent<CanvasGroup>();
    }

    // Update is called once per frame
    void Update()
    {
        Child.LookAt(Main.transform);

        Group.alpha = Mathf.Clamp01(Vector3.Dot(transform.forward, Main.transform.forward) - .5f) * 2f;
    }
}
