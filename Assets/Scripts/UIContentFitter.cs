using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIContentFitter : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        HorizontalLayoutGroup hg = GetComponent<HorizontalLayoutGroup>();
        int childCount = transform.childCount - 1; //space between 5 boxes is 4 boxes
        float childWidth = transform.GetChild(0).GetComponent<RectTransform>().rect.width;
        float width = hg.spacing * childCount + childCount * childWidth + hg.padding.left ;

        GetComponent<RectTransform>().sizeDelta = new Vector2(width, 400);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
