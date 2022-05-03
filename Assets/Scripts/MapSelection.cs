using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapSelection : MonoBehaviour
{
    [SerializeField] private GameObject mapPanel;

    public void OnClickMap()
    {
        mapPanel.gameObject.SetActive(true);
    }

    public void OnClickBack()
    {
        mapPanel.gameObject.SetActive(false);
    }

    public void OnClick1stEnemy()
    {
        SceneManager.LoadScene("1stEnemy");
    }

}
