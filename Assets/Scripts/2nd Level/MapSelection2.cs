using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapSelection2 : MonoBehaviour
{
    [SerializeField] private GameObject mapPanel;
    [SerializeField] private GameObject lockedPanel;
    [SerializeField] private GameObject welcomePanel;
    //[SerializeField] private GameObject lockedEnemy;
    
    public void OnClickMap()
    {
        mapPanel.gameObject.SetActive(true);
    }

    public void OnClickHome()
    {
        SceneManager.LoadScene("1stLevel");
    }

    public void OnClickBack()
    {
        mapPanel.gameObject.SetActive(false);
    }

    public void OnClick1stEnemy()
    {
        SceneManager.LoadScene("1stEnemy");
    }

    public void OnClick2ndEnemy()
    {
        SceneManager.LoadScene("2ndEnemy");
    }

    public void OnClickLockedLevels()
    {
        lockedPanel.gameObject.SetActive(true);
    }

    public void OnClickLockedEnemy()
    {
        //lockedEnemy.gameObject.SetActive(true);
    }

    public void OnClickBackFromLockPanel()
    {
        lockedPanel.gameObject.SetActive(false);
    }

    public void OnClickNext()
    {
        welcomePanel.gameObject.SetActive(false);
    }
}
