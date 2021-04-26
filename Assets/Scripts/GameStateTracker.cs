using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Collectable
{
    public string name;
    public bool collected;
    public CollectableImage image;
    public Sprite sprite;
}

public class GameStateTracker : MonoBehaviour
{
    public GameObject collectableUIFrame;
    public GameObject collectableUIPrefab;
    public AudioSource collectAudioSource;
    public Collectable[] collectables;
    public GameObject flyer;


    private Dictionary<string, Collectable> collectableDict;
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);

        collectableDict = new Dictionary<string, Collectable>();
        foreach (Collectable c in collectables)
        {
            collectableDict.Add(c.name, c);
            GameObject g = Instantiate<GameObject>(collectableUIPrefab);
            g.transform.SetParent(collectableUIFrame.transform);
            c.image = g.GetComponent<CollectableImage>();
            c.image.SetSprite(c.sprite);
            c.image.SetColor(Color.black);
        }
    }

    public void CollectCollectable(string name)
    {
        Collectable c = collectableDict[name];
        c.collected = true;
        c.image.SetColor(Color.white);
        collectAudioSource.Play();

        if (AllCompleted())
        {
            flyer.SetActive(true);
        }
    }

    private bool AllCompleted()
    {
        int count = 0;
        foreach (Collectable c in collectables)
        {
            count += c.collected ? 1 : 0;
        }
        return count == collectables.Length;
    }
}
