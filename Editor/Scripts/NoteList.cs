﻿namespace Todo
{
	using System;
	using System.Collections;
	using System.Collections.Generic;
	using System.Linq;
	using UnityEngine;

	[CreateAssetMenu(menuName = "TODO Manager/NoteList")]
	[Serializable]
	public class NoteList : ScriptableObject
	{
		#region Fields
		public List<Note> Notes = new List<Note>();
		[SerializeField]
		public List<string> tags = new List<string> { "TODO", "BUG" };
		#endregion

		#region Properties
		public List<string> Tags
		{ get { return tags; } }
		#endregion

		#region Constructors

		#endregion

		#region Methods
		public int GetCountByTag(int tagIndex)
		{
			return tagIndex == -1 ? Notes.Count : Notes.Count(entry => entry.Tag == Tags[tagIndex]);
		}

		public Note GetEntryAt(int index)
		{
			return Notes[index];
		}

		public void AddTag(string tag)
		{
			if(Tags.Contains(tag) || string.IsNullOrEmpty(tag))
			{
				return;
			}
			Tags.Add(tag);
		}

		public void RemoveTag(int index)
		{
			if(Tags.Count >= (index + 1))
			{
				Tags.RemoveAt(index);
			}
		}
		#endregion
	}
}