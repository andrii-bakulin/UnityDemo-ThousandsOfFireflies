using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UtilRotator : MonoBehaviour
{
    public bool animate = true;
    public float phase;
    public Vector3 speed;

    private Vector3 startRotation;

    // Start is called before the first frame update
    void Start()
    {
        startRotation = transform.localEulerAngles;
    }

    // Update is called once per frame
    void Update()
    {
        if (!animate)
            return;

        phase += Time.deltaTime;

        transform.localRotation = Quaternion.Euler(startRotation + speed * phase);
    }
}
