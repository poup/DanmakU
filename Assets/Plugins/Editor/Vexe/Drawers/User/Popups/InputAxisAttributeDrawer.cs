﻿using Vexe.Editor.Helpers;
using Vexe.Runtime.Extensions;
using Vexe.Runtime.Types;

namespace Vexe.Editor.Drawers
{
	public class InputAxisAttributeDrawer : AttributeDrawer<string, InputAxisAttribute>
	{
		private string[] axes;
		private int current;

		protected override void OnSingleInitialization()
		{
			if (memberValue == null)
				memberValue = "";

			axes = EditorHelper.GetInputAxes().ToArray();
			current = axes.IndexOfZeroIfNotFound(memberValue);
		}

		public override void OnGUI()
		{
			var x = gui.Popup(niceName, current, axes);
			{
				var newValue = axes[x];
				if (current != x || memberValue != newValue)
				{
					memberValue = newValue;
					current = x;
				}
			}
		}
	}
}