using UnityEngine;
using UnityEngine.UI;

public class LoadingScript : MonoBehaviour
{
    public Sprite[] frames;
    public float frameRate = 12f;

    private Image img;
    private int index;
    private float timer;

    void Start()
    {
        img = GetComponent<Image>();
    }

    void Update()
    {
        if (frames.Length == 0) return;

        timer += Time.deltaTime;

        if (timer >= 1f / frameRate)
        {
            timer = 0f;
            index = (index + 1) % frames.Length;
            img.sprite = frames[index];
        }
    }
}