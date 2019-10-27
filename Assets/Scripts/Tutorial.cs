using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    private void Start()
    {
        Time.timeScale = 0;
    }
    
    public void TutorialScreen(GameObject scrceen)
    {
        Time.timeScale = 1;
        Destroy(scrceen);
    }
}
