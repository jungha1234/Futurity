using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;

public class CommandGraphView : GraphView
{
    public CommandGraphView()
	{
		AddManipulators();

		AddGridBackground();

		//CreateNode();

		AddStyles();
	}

	private void AddManipulators()
	{
		// 줌인 줌아웃 기능
		SetupZoom(ContentZoomer.DefaultMinScale, ContentZoomer.DefaultMaxScale);

		// 버튼 추가 기능
		this.AddManipulator(CreateNodeContextualMenu("Add Node (Normal Attack)", CSCommandType.NormalAttack));
		this.AddManipulator(CreateNodeContextualMenu("Add Node (Charged Attack)", CSCommandType.ChargedAttack));
		this.AddManipulator(CreateNodeContextualMenu("Add Node (Dash)", CSCommandType.Dash));

		// 선택된 요소 드래그 이동
		// RectangleSelector보다 나중에 Add되면 정상 동작하지 않음
		this.AddManipulator(new SelectionDragger());

		// 그래프 요소 선택 기능
		this.AddManipulator(new RectangleSelector());

		// 드래그 기능
		this.AddManipulator(new ContentDragger());
	}

	private IManipulator CreateNodeContextualMenu(string actionTitle, CSCommandType commandType)
	{
		ContextualMenuManipulator contextualMenuManipulator = new ContextualMenuManipulator(
				menuEvent => 
					menuEvent.menu.AppendAction
						(
							actionTitle, 
							actionEvent => AddElement(CreateNode(commandType, actionEvent.eventInfo.localMousePosition))
						)
			);

		return contextualMenuManipulator;
	}

	private CSNode CreateNode(CSCommandType commandType, Vector2 position)
	{
		Type nodeType = Type.GetType($"CS{commandType}Node");

		CSNode node = (CSNode)Activator.CreateInstance(nodeType);

		node.Initialize(position);
		node.Draw();

		AddElement(node);

		return node;
	}

	private void AddGridBackground()
	{
		GridBackground gridBackground = new GridBackground();

		gridBackground.StretchToParentSize();

		Insert(0, gridBackground);
	}

	private void AddStyles()
	{
		StyleSheet graphStyleSheet = (StyleSheet)EditorGUIUtility.Load("CommandSystem/CommandGraphViewStyles.uss");
		StyleSheet nodeStyleSheet = (StyleSheet)EditorGUIUtility.Load("CommandSystem/CSNodeStyles.uss");

		styleSheets.Add(graphStyleSheet);
		styleSheets.Add(nodeStyleSheet);
	}
	
}
