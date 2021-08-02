using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;


public class ButtonManager : MonoBehaviour
{
    private Button btn;
    [SerializeField] private RawImage buttonImage; //rawImage will use Sprite from items c#

    //public GameObject furniture;
    private int _itemId;

    private Sprite _buttonTexture;
    public Sprite ButtonTexture
    {
        set
        {
            _buttonTexture = value;
            buttonImage.texture = _buttonTexture.texture;
        }
    }

    //for encapsulation on itemid
    public int ItemId
    {
        set
        {
            _itemId = value;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        btn = GetComponent<Button>();
        btn.onClick.AddListener(SelectObject);
    }

    // Update is called once per frame
    void Update()
    {
        //the raw images are given animation ussing dotween

        if (UIManager.Instance.OnEntered(gameObject))
        {
            transform.DOScale(Vector3.one * 2, 0.2f);
            //transform.localScale = Vector3.one * 2;
        }
        else
        {
            transform.DOScale(Vector3.one , 0.2f);
           // transform.localScale = Vector3.one;
        }
    }
    void SelectObject()
    {
        DataHandler.Instance.SetFurniture(_itemId);
    }
}
