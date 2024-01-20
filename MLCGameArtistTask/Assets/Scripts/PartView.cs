using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PartView : MonoBehaviour
{
    [SerializeField]
    public Image Image;

    public void SetSprite(Sprite sprite)
    {
        Image.sprite = sprite;
    }

    public void SetColor(Color color)
    {
        Image.color = color;
    }
}
