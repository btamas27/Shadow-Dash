using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(SongDataCollector))]
public class SongDataCollectorEditor : Editor
{

    GUIStyle mainStyle;
    GUIStyle subStyle;

    public override void OnInspectorGUI()
    {
        mainStyle = new GUIStyle();
        mainStyle.fontSize = 16;
        mainStyle.fontStyle = FontStyle.Bold;
        mainStyle.normal.textColor = new Color(76.0f / 255, 128.0f / 255, 124.0f / 255);
        mainStyle.alignment = TextAnchor.MiddleCenter;

        subStyle = new GUIStyle();
        subStyle.fontSize = 14;
        subStyle.fontStyle = FontStyle.Bold;
        subStyle.normal.textColor = Color.white;
        subStyle.alignment = TextAnchor.MiddleLeft;

        SongDataCollector collector = target as SongDataCollector;

        EditorGUILayout.LabelField("Song data collector", mainStyle);
        GUILayout.Space(20);

        EditorGUILayout.BeginVertical();
        {
            EditorGUILayout.LabelField("Data", subStyle);
            GUILayout.Space(15);
            foreach (SongData data in collector.songDatas)
            {
                EditorGUILayout.BeginVertical();
                {
                    DataLabel("Pitch", data.pitch);
                    DataLabel("DB", data.db);
                    DataLabel("Time", data.time);
                }
                EditorGUILayout.EndVertical();
                GUILayout.Space(5);
            }
        }
        EditorGUILayout.EndVertical();
    }

    public void DataLabel(string title, float value)
    {
        EditorGUILayout.BeginHorizontal();
        {
            EditorGUILayout.LabelField(title);
            EditorGUILayout.LabelField(value.ToString());
        }
        EditorGUILayout.EndHorizontal();
    }
}
