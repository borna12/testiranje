using UnityEngine;

public class FloatingText1 : MonoBehaviour {
	private static readonly GUISkin Skin = Resources.Load<GUISkin>("GameSkin");
	
	public static FloatingText1 Show(string text, string style, IFloatingTextPosition positioner)
	{
		var go = new GameObject("Floating Text");
		var floatingText = go.AddComponent<FloatingText1>();
	    floatingText.Style = Skin.GetStyle(style);
        floatingText._positioner = positioner;
        floatingText._content = new GUIContent(text);
        return floatingText;
	}
	
	private GUIContent _content;
	private IFloatingTextPosition _positioner;
	
	public string Text {get{return _content.text;} set{_content.text=value;}}
	public GUIStyle Style { get; set;}
	
	public void OnGui()
	{
		var position = new Vector2 ();
		var contentSize = Style.CalcSize (_content);
		if (!_positioner.GetPosition (ref position, _content,contentSize)) {
			Destroy(gameObject);
			return;
		}
		
		GUI.Label (new Rect(position.x,position.y,contentSize.x,contentSize.y), _content, Style);
	}
}