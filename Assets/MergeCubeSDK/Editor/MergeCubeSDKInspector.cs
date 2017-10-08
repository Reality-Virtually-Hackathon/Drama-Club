using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(MergeCube.MergeCubeSDK))]
public class MergeCubeSDKInspector : Editor
{
	//asdasda 
	private static readonly string[] _dontIncludeMe = new string[]{ "m_Script" };

	SerializedProperty viewMode;
	SerializedProperty cubeConfiguration;
	SerializedProperty isUsingMergeReticle;
	void OnEnable()
	{
		//viewMode = serializedObject.FindProperty("viewMode");	
		isUsingMergeReticle = serializedObject.FindProperty("isUsingMergeReticle");
	}

	public override void OnInspectorGUI()
	{
		serializedObject.Update ();
		EditorGUILayout.Space();
//		EditorGUILayout.PropertyField(viewMode);
		EditorGUILayout.PropertyField(isUsingMergeReticle);
		EditorGUILayout.Space();

		serializedObject.ApplyModifiedProperties ();
	}
}
