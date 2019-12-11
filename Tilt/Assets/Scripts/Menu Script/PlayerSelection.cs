using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerSelection : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> playersList;

    [SerializeField]
    private GameObject playerSpawnPoint;

    [SerializeField]
    private List<Material> playerMaterials;

    [SerializeField]
    private GameObject previewButton;

    private void Start()
    {
        PlayerPrefs.SetInt("BallMaterial", 0);
        previewButton.SetActive(false);
    }

    public void BlueisClicked()
    {
        if (playersList != null)
        {
            for (int i = 0; i < playersList.Count; i++)
            {
                if (i == 0)
                {
                    PlayerPrefs.SetInt("BallMaterial", i);
                    playersList[i].SetActive(true);
                }
                else
                    playersList[i].SetActive(false);
            }
        }
        previewButton.SetActive(true);
    }
    public void Brick3isClicked()
    {
        if (playersList != null)
        {
            for (int i = 0; i < playersList.Count; i++)
            {
                if (i == 1)
                {
                    PlayerPrefs.SetInt("BallMaterial", i);
                    playersList[i].SetActive(true);
                }
                else
                    playersList[i].SetActive(false);
            }
        }
        previewButton.SetActive(true);
    }
    public void GrassisClicked()
    {
        if (playersList != null)
        {
            for (int i = 0; i < playersList.Count; i++)
            {
                if (i == 2)
                {
                    PlayerPrefs.SetInt("BallMaterial", i);
                    playersList[i].SetActive(true);
                }
                else
                    playersList[i].SetActive(false);
            }
        }
        previewButton.SetActive(true);
    }
    public void MarbleWhiteisClicked()
    {
        if (playersList != null)
        {
            for (int i = 0; i < playersList.Count; i++)
            {
                if (i == 3)
                {
                    PlayerPrefs.SetInt("BallMaterial", i);
                    playersList[i].SetActive(true);
                }
                else
                    playersList[i].SetActive(false);
            }
        }
        previewButton.SetActive(true);
    }
    public void ConcreteisClicked()
    {
        if (playersList != null)
        {
            for (int i = 0; i < playersList.Count; i++)
            {
                if (i == 4
)
                {
                    PlayerPrefs.SetInt("BallMaterial", i);
                    playersList[i].SetActive(true);
                }
                else
                    playersList[i].SetActive(false);
            }
        }
        previewButton.SetActive(true);
    }
    public void MudisClicked()
    {
        if (playersList != null)
        {
            for (int i = 0; i < playersList.Count; i++)
            {
                if (i == 5)
                {
                    PlayerPrefs.SetInt("BallMaterial", i);
                    playersList[i].SetActive(true);
                }
                else
                    playersList[i].SetActive(false);
            }
        }
        previewButton.SetActive(true);
    }
    public void Brick2isClicked()
    {
        if (playersList != null)
        {
            for (int i = 0; i < playersList.Count; i++)
            {
                if (i == 6)
                {
                    PlayerPrefs.SetInt("BallMaterial", i);
                    playersList[i].SetActive(true);
                }
                else
                    playersList[i].SetActive(false);
            }
        }
        previewButton.SetActive(true);
    }
    public void WoodisClicked()
    {
        if (playersList != null)
        {
            for (int i = 0; i < playersList.Count; i++)
            {
                if (i == 7)
                {
                    PlayerPrefs.SetInt("BallMaterial", i);
                    playersList[i].SetActive(true);
                }
                else
                    playersList[i].SetActive(false);
            }
        }
        previewButton.SetActive(true);
    }
    public void Brick1isClicked()
    {
        if (playersList != null)
        {
            for (int i = 0; i < playersList.Count; i++)
            {
                if (i == 8)
                {
                    PlayerPrefs.SetInt("BallMaterial", i);
                    playersList[i].SetActive(true);
                }
                else
                    playersList[i].SetActive(false);
            }
        }
        previewButton.SetActive(true);
    }
    public void MarbleBlackisClicked()
    {
        if (playersList != null)
        {
            for (int i = 0; i < playersList.Count; i++)
            {
                if (i == 9)
                {
                    PlayerPrefs.SetInt("BallMaterial", i);
                    playersList[i].SetActive(true);

                }
                else
                    playersList[i].SetActive(false);
            }
        }
        previewButton.SetActive(true);
    }
    
}
