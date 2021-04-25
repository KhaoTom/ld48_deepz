using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class World1Controller : MonoBehaviour
{
    public void LoadSkyLevel()
    {
        SceneManager.LoadScene("World2");
    }
}
