﻿namespace Notes
{
	using System;
	using System.Collections;
	using System.Collections.Generic;
	using UnityEditor;
	using UnityEngine;

	[Serializable]
	public class Tag
	{
		#region Fields
		[SerializeField]
		private string name = null;
		[SerializeField]
		private bool isEnabled = true;
		[SerializeField]
		private Color color = Color.white;

		private static GUIStyle style = null;
		[SerializeField]
		private GUILayoutOption width = null;
		#endregion

		#region Properties
		public string Name
		{ get { return name; } }

		public bool IsEnabled
		{ get { return isEnabled; } }

		private static GUIStyle Style
		{
			get
			{
				style = style ?? new GUIStyle(EditorStyles.helpBox);
				return style;
			}
		}

		private GUILayoutOption Width
		{
			get
			{
				width = width ?? GUILayout.Width(Style.CalcSize(new GUIContent(name)).x + 1f);
				return width;
			}
		}
		#endregion

		#region Constructors
		public Tag(string name)
		{
			this.name = name;
		}
		#endregion

		#region Methods
		public void Draw()
		{
			using(new GUIColorScope(color))
			{
				GUILayout.Label(name, Style, Width);
			}
		}

		public void DrawSettings(TagList tagList)
		{
			DrawNameField(tagList);
			DrawColorField(tagList);
		}

		private void DrawNameField(TagList tagList)
		{
			string newName = GUILayout.TextField(name, GUILayout.Width(100f));
			if(newName != name)
			{
				Undo.RegisterCompleteObjectUndo(tagList, "Changed Tag Name");
				name = newName;
				EditorUtility.SetDirty(tagList);
			}
		}

		private void DrawColorField(TagList tagList)
		{
			Color newColor = EditorGUILayout.ColorField(color);
			if(newColor != color)
			{
				Undo.RegisterCompleteObjectUndo(tagList, "Changed Tag Color");
				color = newColor;
				EditorUtility.SetDirty(tagList);
			}
		}

		public void Toggle()
		{
			isEnabled = !isEnabled;
		}
		#endregion
	}
}