using UnityEngine;
using CoffeyUtils;

public class SafeArea : MonoBehaviour
{
	[SerializeField] private RectTransform _safeAreaRect;
	[SerializeField] private Canvas _canvas;
	
	private Rect _lastSafeArea = Rect.zero;
	
	private void OnValidate()
	{
		if (_safeAreaRect == null) _safeAreaRect = GetComponent<RectTransform>();
		if (_canvas == null) _canvas = transform.parent != null ? transform.parent.GetComponent<Canvas>() : null;
	}
	
	private void Start()
	{
		UpdateSafeArea();
	}
	
	private void Update()
	{
		if (_lastSafeArea != Screen.safeArea)
		{
			UpdateSafeArea();
		}
	}
	
	[Button]
	private void UpdateSafeArea()
	{
		_lastSafeArea = Screen.safeArea;
		Rect safeArea = Screen.safeArea;
		
		Vector2 anchorMin = safeArea.position;
		Vector2 anchorMax = safeArea.position + safeArea.size;
		anchorMin.x /= _canvas.pixelRect.width;
		anchorMin.y /= _canvas.pixelRect.height;
		anchorMax.x /= _canvas.pixelRect.width;
		anchorMax.y /= _canvas.pixelRect.height;
		
		_safeAreaRect.anchorMin = anchorMin;
		_safeAreaRect.anchorMax = anchorMax;
	}
}
