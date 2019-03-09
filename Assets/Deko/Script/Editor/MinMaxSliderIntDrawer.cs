using UnityEngine;
using UnityEditor;
[CustomPropertyDrawer(typeof(MinMaxSliderIntAttribute))]
class MinMaxSliderIntDrawer : PropertyDrawer
{
	private float _height = EditorGUIUtility.singleLineHeight;
	public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
	{
		return base.GetPropertyHeight(property, label) + _height;
	}
	public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
	{
		if (property.propertyType == SerializedPropertyType.Vector2Int)
		{
			label = EditorGUI.BeginProperty(position, label, property);
			position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);
			var range = property.vector2IntValue;
			float min = range.x;
			float max = range.y;
			var a = attribute as MinMaxSliderIntAttribute;
			var left = new Rect(position.x, position.y, position.width / 2f - 11f, _height);
			var right = new Rect(position.x + position.width - left.width, position.y, left.width, _height);
			var mid = new Rect(left.xMax, position.y, 22f, _height);
			min = Mathf.Clamp(EditorGUI.IntField(left, (int)min), a.Min, max);
			EditorGUI.LabelField(mid, " to ");
			max = Mathf.Clamp(EditorGUI.IntField(right, (int)max), min, a.Max);
			position.y += _height;
			EditorGUI.BeginChangeCheck();
			EditorGUI.MinMaxSlider(position, GUIContent.none, ref min, ref max, a.Min, a.Max);
			if (EditorGUI.EndChangeCheck())
			{
				range.x = (int)min;
				range.y = (int)max;
				property.vector2IntValue = range;
			}
			EditorGUI.EndProperty();
		}
		else
			EditorGUI.HelpBox(position, "Use with Vector2Int.", MessageType.Warning);
	}
}
