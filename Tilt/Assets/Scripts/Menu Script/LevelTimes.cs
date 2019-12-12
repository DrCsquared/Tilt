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
    [SerializeField]
    private TextMeshPro level5;



    // Start is called before the first frame update
    void Start()
    {
        level1.text = string.Format("{0}:{1:00}.{2:000}", ((int)PlayerPrefs.GetFloat("Level 1", 3540) / 60), ((int)PlayerPrefs.GetFloat("Level 1", 3540) % 60), ((int)(PlayerPrefs.GetFloat("Level 1", 3540) * 1000) % 1000));
        level2.text = string.Format("{0}:{1:00}.{2:000}", ((int)PlayerPrefs.GetFloat("Level 2", 3540) / 60), ((int)PlayerPrefs.GetFloat("Level 2", 3540) % 60), ((int)(PlayerPrefs.GetFloat("Level 2", 3540) * 1000) % 1000));
        level3.text = string.Format("{0}:{1:00}.{2:000}", ((int)PlayerPrefs.GetFloat("Level 3", 3540) / 60), ((int)PlayerPrefs.GetFloat("Level 3", 3540) % 60), ((int)(PlayerPrefs.GetFloat("Level 3", 3540) * 1000) % 1000));
        level4.text = string.Format("{0}:{1:00}.{2:000}", ((int)PlayerPrefs.GetFloat("Level 4", 3540) / 60), ((int)PlayerPrefs.GetFloat("Level 4", 3540) % 60), ((int)(PlayerPrefs.GetFloat("Level 4", 3540) * 1000) % 1000));
        level5.text = string.Format("{0}:{1:00}.{2:000}", ((int)PlayerPrefs.GetFloat("Level 5", 3540) / 60), ((int)PlayerPrefs.GetFloat("Level 5", 3540) % 60), ((int)(PlayerPrefs.GetFloat("Level 5", 3540) * 1000) % 1000));
    }
}
