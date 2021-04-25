using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectableImage : MonoBehaviour
{
    public Image image;

    public void SetSprite(Sprite s)
    {
        image.gameObject.name = s.name;
        image.sprite = s;
    }

    public void SetColor(Color c)
    {
        image.color = c;
    }
}
