using UnityEngine;

public interface IFloatingTextPosition {
	bool GetPosition(ref Vector2 position, GUIContent content, Vector2 size);
}
