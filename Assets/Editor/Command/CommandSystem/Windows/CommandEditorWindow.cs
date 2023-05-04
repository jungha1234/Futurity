using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEditor.UIElements;
using System;

public class CommandEditorWindow : EditorWindow
{
    [MenuItem("Window/Player Command/Player Command Graph")]
    public static void ShowAttackGraph()
    {
        GetWindow<CommandEditorWindow>("Player Command Graph");
    }

	private void OnEnable()
	{
		AddGraphView();

		AddStyles();
	}

	private void AddGraphView()
	{
		CommandGraphView graphview = new CommandGraphView();
		graphview.StretchToParentSize();

		rootVisualElement.Add(graphview);
	}

	private void AddStyles()
	{
		StyleSheet styleSheet = (StyleSheet)EditorGUIUtility.Load("CommandSystem/CommandVariables.uss");

		rootVisualElement.styleSheets.Add(styleSheet);
	}
}