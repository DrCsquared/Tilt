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
    
    private GameObject current;

    // Start is called before the first frame update
    void Start()
    {
        top.transform.parent = null;
        level.transform.parent = top.transform;
        top.GetComponent<LevelMovement>().enabled = true;
        current = top;
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag =="top" && current != top)
        {
            level.transform.parent = null;
            current.transform.parent = level.transform;
            current.gameObject.GetComponent<LevelMovement>().enabled = false;
            top.transform.parent = null;
            level.transform.parent = top.transform;
            current = top;
            top.GetComponent<LevelMovement>().enabled = true;
        }
        if (other.tag == "bottom" && current != bottom)
        {
            level.transform.SetParent(null);
            level.transform.SetParent(bottom.transform);
        }
        if (other.tag == "right" && current != right)
        {
            Debug.Log(transform.parent);
            level.transform.parent = null;
            Debug.Log(transform.parent);
            current.transform.parent = level.transform;
            current.gameObject.GetComponent<LevelMovement>().enabled = false;
            right.transform.parent = null;
            level.transform.parent = right.transform;
            current = right;
            right.GetComponent<LevelMovement>().enabled = true;
        }
        if (other.tag == "left" && current != left)
        {
            level.transform.SetParent(null, true);
            level.transform.SetParent(left.transform);
        }
        if (other.tag == "front" && current != front)
        {
            level.transform.SetParent(null, true);
            level.transform.SetParent(front.transform);
        }
        if (other.tag == "back" && current != back)
        {
            level.transform.SetParent(null, true);
            level.transform.SetParent(back.transform);
        }
    }
}
