using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextRandom : MonoBehaviour
{
    public Text colortxt;
    private float timer = 0f;
    public float changeInterval = 3f;

    private Dictionary<string, Color> colorMap = new Dictionary<string, Color>()
    {
        {"white", Color.white},
        {"black", Color.black},
        {"magenta", Color.magenta},
        {"green", Color.green},
        {"yellow", Color.yellow},
        {"cyan", Color.cyan},
    };

    void Update()
    {
        if (colortxt != null)
        {
            timer += Time.deltaTime;
            if (timer >= changeInterval)
            {
                List<string> keys = new List<string>(colorMap.Keys);
                string randomKey = keys[Random.Range(0, keys.Count)];
                colortxt.text = randomKey;
                colortxt.color = colorMap[randomKey];
                timer = 0f;
            }
        }
        else
        {
            Debug.LogError("colortxt is not assigned.");
        }
    }
}
