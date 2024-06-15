using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorBtnRandom : MonoBehaviour
{
    private Dictionary<string, Color> colorMap = new Dictionary<string, Color>()
    {
        {"white", Color.white},
        {"black", Color.black},
        {"magenta", Color.magenta},
        {"green", Color.green},
        {"yellow", Color.yellow},
        {"cyan", Color.cyan},
    };

    public Button button;
    private float timer = 0f;
    public float changeInterval = 3f;

    // Start is called before the first frame update
    void Start()
    {
        if (button == null)
        {
            Debug.LogError("Button not assigned!");
            return;
        }
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= changeInterval)
        {
            List<string> keys = new List<string>(colorMap.Keys);
            string randomKey = keys[Random.Range(0, keys.Count)];
            Color randomColor = colorMap[randomKey];

            button.GetComponent<Image>().color = randomColor;

            timer = 0f;
        }
    }
}
