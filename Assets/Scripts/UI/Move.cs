using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {

    [SerializeField]
    private float fromX=0;
    [SerializeField]
    private float toX=0;

    //滑动速度
    [SerializeField]
    private float slideSpeed = 1f;

    private RectTransform rectTransform;

    public void StartMove()
    {
        rectTransform = GetComponent<RectTransform>();

        StartCoroutine(move(fromX,toX));
    }
    public void EndMove()
    {
        StartCoroutine(move(fromX, toX));
        Invoke("DisablePanel", slideSpeed+0.1f);
    }

    private void DisablePanel()
    {
        transform.parent.parent.gameObject.SetActive(false);
    }

    IEnumerator move(float _fromX,float _toX)
    {
      //  rectTransform.anchoredPosition = new Vector2(fromX, rectTransform.anchoredPosition.y);
        float originalSpeed = slideSpeed;

        while (slideSpeed>0)
        {
            slideSpeed -= Time.deltaTime;

            rectTransform.anchoredPosition = Vector2.Lerp(new Vector2(_fromX, rectTransform.anchoredPosition.y), new Vector2(_toX, rectTransform.anchoredPosition.y), 1 - slideSpeed/ originalSpeed);
            yield return new WaitForEndOfFrame();
        }

        slideSpeed = originalSpeed;
    }

}
