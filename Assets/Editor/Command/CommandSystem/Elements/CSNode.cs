using System;
using UnityEditor.Experimental.GraphView;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

public class CSNode : Node
{
	public string CommandName { get; set; }
	public CSCommandType CommandType { get; set; }

	public virtual void Initialize(Vector2 position)
	{
		CommandName = "CommandName";
		CommandType = CSCommandType.NormalAttack;

		SetPosition(new Rect(position, Vector2.zero));
	}

	public virtual void Draw()
	{
		// Title Container
		TextField commandName = new TextField()
		{
			value = CommandName
		};

		titleContainer.Add(commandName);

		// Input Container
		Port inputPort = InstantiatePort(Orientation.Horizontal, Direction.Input, Port.Capacity.Single, typeof(bool));
		inputPort.portName = "이전 커맨드";

		inputContainer.Add(inputPort);

		// Extensions Container
		VisualElement customDataContainer = new VisualElement();

		EnumField enumField = new EnumField(CommandType);

		customDataContainer.Add(enumField);

		extensionContainer.Add(customDataContainer);

		// Output Container
		Port nextCommands = InstantiatePort(Orientation.Horizontal, Direction.Output, Port.Capacity.Multi, typeof(bool));
		nextCommands.portName = "다음 커맨드";
		outputContainer.Add(nextCommands);
	}
}
