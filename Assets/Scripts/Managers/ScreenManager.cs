using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenManager : MonoBehaviour
{

    public UIScreen.Type defaultScreen;
    public UIScreenFade screenFade;

    private void Start()
    {
        ChangeScreen(defaultScreen);
        EventManager.Instance.OnChangeScreen += HandleChangeScreen;
        screenFade.CallScreenFadeOut();
    }

    private void OnDestroy()
    {
        EventManager.Instance.OnChangeScreen -= HandleChangeScreen;
    }

    private IEnumerator YDelay(UIScreen.Type type)
    {
        screenFade.CallScreenFadeIn();
        yield return new WaitForSeconds(0.4f);
        ChangeScreen(type);
        screenFade.CallScreenFadeOut();
    }

    private void HandleChangeScreen(UIScreen.Type type)
    {
        StopCoroutine("YDelay");
        StartCoroutine(YDelay(type));
    }

    private void ChangeScreen(UIScreen.Type type)
    {
        foreach (UIScreen screen in GetComponentsInChildren<UIScreen>(true))
        {
            if (screen.type == type)
            {
                screen.Show();
            }
            else
            {
                screen.Hide();
            }
        }
    }
}
