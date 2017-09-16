using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class UIScreenFade : MonoBehaviour {


    private IEnumerator YScreenFadeIn()
    {
        float alpha = 0;
        Color color = GetComponent<Image> ().color;
        GetComponent<Image> ().color = new Color (color.r, color.g, color.b, alpha);
        yield return new WaitForEndOfFrame();
        while (alpha < 1) {
            alpha += Time.deltaTime * 2;
            GetComponent<Image> ().color = new Color (color.r, color.g, color.b, alpha);
            yield return null;
        }
    }

    private IEnumerator YScreenFadeOut()
    {
        float alpha = 1;
        Color color = GetComponent<Image> ().color;
        GetComponent<Image> ().color = new Color (color.r, color.g, color.b, alpha);
        while (alpha > 0) {
            alpha -= Time.deltaTime * 2;
            GetComponent<Image> ().color = new Color (color.r, color.g, color.b, alpha);
            yield return null;
        }
        gameObject.SetActive (false);
    }

    public void CallScreenFadeIn()
    {
        gameObject.SetActive (true);
        StartCoroutine (YScreenFadeIn ());
    }

    public void CallScreenFadeOut()
    {
        gameObject.SetActive (true);
        StartCoroutine (YScreenFadeOut ());
    }

}
