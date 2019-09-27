using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpheresCloudBuilder : MonoBehaviour
{
    const int kRandBlockCapacity = 100;

    public GameObject spheresCloudHolder;
    public GameObject prefab;

    [Space]

    [Range(1,1000)]
    public int limit = 100;
    public int seed = 12345;

    [Space]
    [Header("Spread")]

    public Vector3 positionMin = new Vector3(-10f, -0.90f, -10f);
    public Vector3 positionMax = new Vector3(+10f, +2.35f, +10f);

    [Header("Light Settings")]

    public Color colorMin = Color.black;
    public Color colorMax = Color.white;

    public Vector3 lightMaxSpeed = new Vector3(90f, 90f, 90f);

    // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -

    [HideInInspector]
    public float lightMinIntensity = 0.1f;
    [HideInInspector]
    public float lightMaxIntensity = 3.0f;

    [HideInInspector]
    public float lightMinRange = 2.0f;
    [HideInInspector]
    public float lightMaxRange = 5.0f;

    public void BuildObject()
    {
        if (spheresCloudHolder == null || prefab == null)
            return;

        while (spheresCloudHolder.transform.childCount > 0)
        {
            DestroyImmediate(spheresCloudHolder.transform.GetChild(0).gameObject);
        }

        Random.InitState(seed);

        for ( int i=0; i< limit; i++ )
        {
            openRandBlock();

            // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -

            Vector3 pos = new Vector3(
                getRand(positionMin.x, positionMax.x),
                getRand(positionMin.y, positionMax.y),
                getRand(positionMin.z, positionMax.z));

            Vector3 rot = new Vector3(
                getRand(-180,180),
                getRand(-180, 180),
                getRand(-180, 180));

            var obj = Instantiate(prefab, pos, Quaternion.identity, spheresCloudHolder.transform);
            obj.transform.Rotate(rot);
            var scr = obj.GetComponentInChildren<SphereWithLight>();

            // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -

            float s = getRand(0.33f, 1.1f);

            scr.sphere.localScale = new Vector3(s, s, s);

            // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -

            scr.light.transform.localPosition = new Vector3(getRand(-0.5f, +0.5f), getRand(1.0f, +1.3f), getRand(-0.5f, +0.5f));

            scr.light.intensity = getRand(lightMinIntensity, lightMaxIntensity);

            scr.light.color = new Color(
                getRand(colorMin.r, colorMax.r),
                getRand(colorMin.g, colorMax.g),
                getRand(colorMin.b, colorMax.b)
            );

            scr.light.range = getRand(lightMinRange, lightMaxRange);

            scr.lightRotator.speed = new Vector3(
                getRand(-1, +1) * lightMaxSpeed.x,
                getRand(-1, +1) * lightMaxSpeed.y,
                getRand(-1, +1) * lightMaxSpeed.z
            );

            // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -

            closeRandBlock();
        }
    }

    //--------------------------------------------------------------------------

    float randCapacity;

    void openRandBlock()
    {
        randCapacity = kRandBlockCapacity;
    }

    void closeRandBlock()
    {
        while( randCapacity > 0)
        {
            getRand(0, 0);
        }
    }

    float getRand( float min, float max)
    {
        randCapacity--;
        return Random.Range(min, max);
    }
}
