using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menu_olay_sc : MonoBehaviour
{
    public void play_but()
    {
        SceneManager.LoadScene("oyun");
    }
}
