using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class finish_sc : MonoBehaviour
{
    [SerializeField] private TMP_Text level;
    [SerializeField] private TMP_Text skor;
    public void level_al()
    {
        SceneManager.LoadScene("oyun");
        PlayerPrefs.SetInt("level", PlayerPrefs.GetInt("level")+1);
    }
    void Start()
    {
        level.text = "Level " + (PlayerPrefs.GetInt("level")+1).ToString() + " Successful";
        skor.text = PlayerPrefs.GetInt("skor").ToString() + " Score";
    }

    
}
