using UnityEngine;

public class creditScript : MonoBehaviour
{
    private float scllowSpeed = 70f;
    private RectTransform rectTransform;
    
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    
    void Update()
    {
        rectTransform.anchoredPosition += new Vector2(0 ,scllowSpeed * Time.deltaTime);
    }
}
