using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : MonoBehaviour
{
    [SerializeField] private Texture2D cursorTexture;

    [SerializeField] private float cursorWidth;
    [SerializeField] private float cursorHeight;

    private Vector2 cursorHotspot;
    
    void Start()
    {
        cursorHotspot = new Vector2(cursorTexture.width/ cursorWidth, cursorTexture.height/ cursorHeight);
        Cursor.SetCursor(cursorTexture, cursorHotspot, CursorMode.Auto);
        
    }

    
    
}
