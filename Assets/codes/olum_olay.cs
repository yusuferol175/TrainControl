using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class olum_olay : MonoBehaviour
{
    [SerializeField] private TMP_Text level;
    [SerializeField] private TMP_Text skor;
    public void try_again()
    {
        SceneManager.LoadScene("oyun");
        
    }
    void Start()
    {
        level.text = "Level " + (PlayerPrefs.GetInt("level") + 1).ToString() + " Failed";
        skor.text = PlayerPrefs.GetInt("skor").ToString() + " Score";
    }
}
