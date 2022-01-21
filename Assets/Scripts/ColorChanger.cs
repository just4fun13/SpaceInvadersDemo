using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    [SerializeField] SpriteRenderer spr;

    private List<Color> colors;
    private Color myColor, nextColor;
    private float t = 0f;
    private void Start()
    {
        colors = new List<Color>();
        AddSomeColors();
        myColor = PickRandomColor();
        nextColor = PickRandomColor();
    }

    private void AddSomeColors()
    {
        colors.Add(Color.white);
        colors.Add(Color.green);
        colors.Add(Color.magenta);
        colors.Add(Color.red);
        colors.Add(Color.cyan);
        colors.Add(Color.blue);
        colors.Add(Color.yellow);
    }

    private Color PickRandomColor()
    {
        int randomIndex = Random.Range(0, colors.Count);
        return colors[randomIndex];
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        spr.color = Color.Lerp(myColor, nextColor, t);
        t += 0.001f;
        if (t >= 1f)
        {
            myColor = nextColor;
            nextColor = PickRandomColor();
            t = 0f;
        }
    }
}
