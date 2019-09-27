using System.Collections;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(SpheresCloudBuilder))]
public class BuildLights_GUI : Editor
{
    const float kIntensityMinLimit = 0.0f;
    const float kIntensityMaxLimit = 10.0f;

    const float kRangeMinLimit = 0.0f;
    const float kRangeMaxLimit = 10.0f;

    public override void OnInspectorGUI()
    {
        var myScript = (SpheresCloudBuilder)target;

        DrawDefaultInspector();

        EditorGUILayout.Space();

        EditorGUILayout.MinMaxSlider(ref myScript.lightMinIntensity, ref myScript.lightMaxIntensity, kIntensityMinLimit, kIntensityMaxLimit);
        EditorGUILayout.LabelField("Min Intensity:", myScript.lightMinIntensity.ToString());
        EditorGUILayout.LabelField("Max Intensity:", myScript.lightMaxIntensity.ToString());

        EditorGUILayout.Space();

        EditorGUILayout.MinMaxSlider(ref myScript.lightMinRange, ref myScript.lightMaxRange, kRangeMinLimit, kRangeMaxLimit);
        EditorGUILayout.LabelField("Min Range:", myScript.lightMinRange.ToString());
        EditorGUILayout.LabelField("Max Range:", myScript.lightMaxRange.ToString());

        EditorGUILayout.Space();

        if (GUILayout.Button("Build Object"))
        {
            myScript.BuildObject();
        }

        // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -

        myScript.lightMinIntensity = (float)System.Math.Round(myScript.lightMinIntensity, 1);
        myScript.lightMaxIntensity = (float)System.Math.Round(myScript.lightMaxIntensity, 1);

        myScript.lightMinRange = (float)System.Math.Round(myScript.lightMinRange, 1);
        myScript.lightMaxRange = (float)System.Math.Round(myScript.lightMaxRange, 1);
    }
}
