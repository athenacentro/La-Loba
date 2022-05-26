using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapSelection : MonoBehaviour
{
    [SerializeField] private GameObject mapPanel;
    //[SerializeField] private GameObject lockedPanel;
    //[SerializeField] private GameObject welcomePanel;
    //[SerializeField] private GameObject lockedEnemy;
    //[SerializeField] private GameObject herePanel;
    

    public void OnClickMap()
    {
        mapPanel.gameObject.SetActive(true);
    }

    public void OnClickHome()
    {
        //herePanel.gameObject.SetActive(true);
    }

    public void OnClickBackHome()
    {
        //herePanel.gameObject.SetActive(false);
    }

    public void OnClickBack()
    {
        mapPanel.gameObject.SetActive(false);
    }

    public void OnClick1stEnemy()
    {
        SceneManager.LoadScene("1stEnemy");
    }

    public void OnClickLockedLevels()
    {
        //lockedPanel.gameObject.SetActive(true);
    }

    public void OnClickLockedEnemy()
    {
        //lockedEnemy.gameObject.SetActive(true);
    }

    public void OnClickBackFromLockPanel()
    {
        //lockedPanel.gameObject.SetActive(false);
    }

    public void OnClickNext()
    {
        //welcomePanel.gameObject.SetActive(false);
    }
}
