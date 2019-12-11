using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class LevelTimes : MonoBehaviour
{
    [SerializeField]
    private TextMeshPro level1;
    [SerializeField]
    private TextMeshPro level2;
    [SerializeField]
    private TextMeshPro level3;
    [SerializeField]
    private TextMeshPro level4;

   

    // Start is called before the first frame update
    void Start()
    {
        level1.text = string.Format("{0}:{1:00}.{2:000}", ((int)PlayerPrefs.GetFloat("Level 1", 0) / 60), ((int)PlayerPrefs.GetFloat("Level 1", 0) % 60), ((int)PlayerPrefs.GetFloat("Level 1", 0) % 1000));
        level2.text = string.Format("{0}:{1:00}.{2:000}", ((int)PlayerPrefs.GetFloat("Level 2", 0) / 60), ((int)PlayerPrefs.GetFloat("Level 2", 0) % 60), ((int)PlayerPrefs.GetFloat("Level 2", 0) % 1000));
        level3.text = string.Format("{0}:{1:00}.{2:000}", ((int)PlayerPrefs.GetFloat("Level 3", 0) / 60), ((int)PlayerPrefs.GetFloat("Level 3", 0) % 60), ((int)PlayerPrefs.GetFloat("Level 3", 0) % 1000));
        level4.text = string.Format("{0}:{1:00}.{2:000}", ((int)PlayerPrefs.GetFloat("Level 4", 0) / 60), ((int)PlayerPrefs.GetFloat("Level 4", 0) % 60), ((int)PlayerPrefs.GetFloat("Level 4", 0) % 1000));
    }
}
