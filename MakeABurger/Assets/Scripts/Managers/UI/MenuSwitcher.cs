using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSwitcher : MonoBehaviour
{
    public static MenuSwitcher Instance;

    private void Awake()
    {
        #region SINGLETON
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }

        Instance = this;
        #endregion
    }

    public void SwitchMenu(GameObject nextMenu, GameObject currentMenu)
    {
        if (currentMenu.activeSelf == true)
        {
            nextMenu.SetActive(true);

            currentMenu.SetActive(false);
        }
    }
}
