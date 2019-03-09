using System;
using UnityEngine;
[AttributeUsage(AttributeTargets.Field)]
public class MinMaxSliderIntAttribute : PropertyAttribute
{
	public int Min, Max;
	public MinMaxSliderIntAttribute(int min, int max)
	{
		Min = min;
		Max = max;
	}
}
