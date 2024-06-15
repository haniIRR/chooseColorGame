using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Button upBtn;
    public Button downBtn;
    public Button leftBtn;
    public Button rightBtn;

    public Text colortxt;
    public Text scoretxt;

    public int score = 0;

    private Dictionary<string, Color> colorMap = new Dictionary<string, Color>()
    {
        {"white", Color.white},
        {"black", Color.black},
        {"magenta", Color.magenta},
        {"green", Color.green},
        {"yellow", Color.yellow},
        {"cyan", Color.cyan},
    };

    // Start is called before the first frame update
    void Start()
    {
        scoretxt.text = "0";
        if (string.IsNullOrEmpty(colortxt.text))
        {
            colortxt.text = "white";
            Debug.LogError("colortxt is empty or null");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            HandleButtonPress(upBtn);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            HandleButtonPress(downBtn);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            HandleButtonPress(leftBtn);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            HandleButtonPress(rightBtn);
        }

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                Vector2 touchPos = touch.position;
                if (RectTransformUtility.RectangleContainsScreenPoint(upBtn.GetComponent<RectTransform>(), touchPos))
                {
                    HandleButtonPress(upBtn);
                }
                else if (RectTransformUtility.RectangleContainsScreenPoint(downBtn.GetComponent<RectTransform>(), touchPos))
                {
                    HandleButtonPress(downBtn);
                }
                else if (RectTransformUtility.RectangleContainsScreenPoint(leftBtn.GetComponent<RectTransform>(), touchPos))
                {
                    HandleButtonPress(leftBtn);
                }
                else if (RectTransformUtility.RectangleContainsScreenPoint(rightBtn.GetComponent<RectTransform>(), touchPos))
                {
                    HandleButtonPress(rightBtn);
                }
            }
        }
    }

    bool CheckColor(Button button, Text colorText)
    {
        Color buttonColor = button.GetComponent<Image>().color;
        if (colorMap.TryGetValue(colorText.text.ToLower(), out Color targetColor))
        {
            return buttonColor == targetColor;
        }
        else
        {
            Debug.LogError("Color not found in colorMap: " + colorText.text);
            return false;
        }
    }

    void HandleButtonPress(Button button)
    {
        if (CheckColor(button, colortxt))
        {
            score += 3;
            scoretxt.text = score.ToString();
            Debug.Log(button.name + " button color matches!");
        }
        else
        {
            score -=1;
            scoretxt.text = score.ToString();
            Debug.Log(button.name + " button color does not match.");
        }
    }
}