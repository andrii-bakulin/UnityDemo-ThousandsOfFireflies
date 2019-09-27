using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereWithLight : MonoBehaviour
{
    enum State
    {
        TurnOn,
        Idle,
        TurnOff,
    }

    public Transform sphere;
    public Light light;
    public UtilRotator lightRotator;


    State state;
    Color lightColor;

    float phase;
    float duration;

    public void Start()
    {
        lightColor = light.color;

        phase = Random.Range(-7.0f, 0.0f);
        duration = Random.Range(0.5f, 5.0f);

        state = State.TurnOn;
    }

    public void Update()
    {
        phase += Time.deltaTime;

        if (state == State.TurnOn)
        {
            float t = Mathf.Clamp01(phase / duration);

            if (t >= 1.0f)
                state = State.Idle;

            light.color = Color.Lerp(Color.black, lightColor, t);
        }
        else if(state == State.Idle)
        {
            if (Time.fixedTime >= 15.0f)
            {
                state = State.TurnOff;

                phase = 0.0f;
                duration = Random.Range(2.0f, 5.0f);

                if (duration < 3.0f && Random.Range(0.0f,1.0f) > 0.33f)
                {
                    duration *= Random.Range(0.5f, 0.8f);
                }
            }
        }
        else if(state == State.TurnOff)
        {
            float t = Mathf.Clamp01(phase / duration);

            light.color = Color.Lerp(lightColor, Color.black, t);
        }
    }
}
