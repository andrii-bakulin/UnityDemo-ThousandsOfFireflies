using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UtilMover : MonoBehaviour
{
    public bool animate = true;
    public float phase;
    public Vector3 speed;

    private Vector3 startPosition;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if (!animate)
            return;

        phase += Time.deltaTime;

        transform.localPosition = startPosition + speed * phase;
    }
}
