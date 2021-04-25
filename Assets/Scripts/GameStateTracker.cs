using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Collectable
{
    public string name;
    public bool collected;
    public Image image;
    public Sprite sprite;
}

public class GameStateTracker : MonoBehaviour
{
    public GameObject collectableUIFrame;
    public GameObject collectableUIPrefab;
    public Collectable[] collectables;


    private Dictionary<string, Collectable> collectableDict;
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);

        collectableDict = new Dictionary<string, Collectable>();
        foreach (Collectable c in collectables)
        {
            collectableDict.Add(c.name, c);
            GameObject g = Instantiate<GameObject>(collectableUIFrame);
            g.transform.parent = collectableUIFrame.transform;
            c.image = g.GetComponent<Image>();
            c.image.sprite = c.sprite;
            c.image.color = Color.black;
        }
    }

    public void CollectCollectable(string name)
    {
        Collectable c = collectableDict[name];
        c.collected = true;
        c.image.color = Color.white;
    }
}
