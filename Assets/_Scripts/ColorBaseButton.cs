using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]

public class ColorBaseButton : MonoBehaviour {

    public Color color;
    public Player myPlayer;
    
    [Header("References")]
    public Image uiImage;

    void Start() {
        uiImage.color = color;
        //GetComponent<Button>().onClick.AddListener(OnClick);
    }
    void OnValidate() {
        uiImage = GetComponent<Image>();
    }
    public void OnClick() {
        myPlayer.ChangeColor(color);
    }
  
}
