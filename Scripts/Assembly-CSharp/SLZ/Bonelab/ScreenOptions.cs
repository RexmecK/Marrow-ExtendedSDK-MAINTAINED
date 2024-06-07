using System.Collections.Generic;
using UnityEngine;

namespace SLZ.Bonelab
{
	public class ScreenOptions : MonoBehaviour
	{
		protected delegate void CallbackBool(bool isClicked);

		protected delegate void CallbackFloat(float amount);

		protected enum GUIType
		{
			BUTTON = 0,
			LINE = 1,
			LABEL = 2,
			BOX = 3,
			SLIDER = 4
		}

		protected struct GUIItem
		{
			public GUIType type;

			public string label;

			public float value;

			public float start;

			public float stop;

			public CallbackBool callbackBool;

			public CallbackFloat callbackFloat;

			public GUIItem(GUIType t, float v, float st, float sp, CallbackFloat c = null)
			{
				this.callbackBool = null;
				this.callbackFloat = null;
				this.type = GUIType.BOX;
				this.label = "null";
				this.value = 0f;
				this.start = 0f;
				this.stop = 0f;
			}

			public GUIItem(GUIType t, string l, float v, float st, float sp, CallbackFloat c = null)
			{
				this.callbackBool = null;
				this.callbackFloat = null;
				this.type = GUIType.BOX;
				this.label = "null";
				this.value = 0f;
				this.start = 0f;
				this.stop = 0f;
			}

			public GUIItem(GUIType t, string l)
			{
				this.callbackBool = null;
				this.callbackFloat = null;
				this.type = GUIType.BOX;
				this.label = "null";
				this.value = 0f;
				this.start = 0f;
				this.stop = 0f;
			}

			public GUIItem(GUIType t, string l, CallbackBool c = null)
			{
				this.callbackBool = null;
				this.callbackFloat = null;
				this.type = GUIType.BOX;
				this.label = "null";
				this.value = 0f;
				this.start = 0f;
				this.stop = 0f;
			}

			public GUIItem(GUIType t, string l, CallbackFloat c = null)
			{
				this.callbackBool = null;
				this.callbackFloat = null;
				this.type = GUIType.BOX;
				this.label = "null";
				this.value = 0f;
				this.start = 0f;
				this.stop = 0f;
			}
		}

		private float guiMargin;

		private float guiButtonWidth;

		private float guiButtonHeight;

		private float guiLabelHeight;

		private float guiLabelSmallHeight;

		private float guiSliderHeight;

		private float guiInputWidth;

		private float startY;

		private float startX;

		private Texture2D lineTexture;

		private List<GUIItem> guiItems;

		private void SetupTexture()
		{
		}

		protected void StartGUI()
		{
		}

		protected void EndGUI()
		{
		}

		protected void GUIButton(string label, CallbackBool callback)
		{
		}

		protected void GUIButton(string label)
		{
		}

		protected void GUILine()
		{
		}

		protected void GUILabel(string label)
		{
		}

		protected void GUISlider(float value, float start, float stop, CallbackFloat callback)
		{
		}

		protected void GUISlider(string label, float value, float start, float stop, CallbackFloat callback)
		{
		}
	}
}
