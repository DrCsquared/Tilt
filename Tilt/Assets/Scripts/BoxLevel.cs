using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxLevel : MonoBehaviour
{
    [SerializeField]
    private GameObject level;
    [SerializeField]
    private GameObject top;
    [SerializeField]
    private GameObject bottom;
    [SerializeField]
    private GameObject left;
    [SerializeField]
    private GameObject right;
    [SerializeField]
    private GameObject front;
    [SerializeField]
    private GameObject back;

    // Start is called before the first frame update
    void Start()
    {
        level.transform.SetParent(top.transform);
        top.GetComponent<LevelMovement>().enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag =="top")
        {
            level.transform.SetParent(null);
            level.transform.SetParent(top.transform);
        }
        if (other.tag == "bottom")
        {
            level.transform.SetParent(null);
            level.transform.SetParent(bottom.transform);
        }
        if (other.tag == "right")
        {
            level.transform.SetParent(null);
            level.transform.SetParent(right.transform); 
        }
        if (other.tag == "left")
        {
            level.transform.SetParent(null, true);
            level.transform.SetParent(left.transform);
        }
        if (other.tag == "front")
        {
            level.transform.SetParent(null, true);
            level.transform.SetParent(front.transform);
        }
        if (other.tag == "back")
        {
            level.transform.SetParent(null, true);
            level.transform.SetParent(back.transform);
        }
    }
}
