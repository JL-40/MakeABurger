using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoodChanger : MonoBehaviour
{
    [SerializeField] SpriteRenderer monsterImage;

    [SerializeField] Sprite normalSprite;
    [SerializeField] Sprite happySprite;
    [SerializeField] Sprite madSprite;

    // Start is called before the first frame update
    void Start()
    {
        if (monsterImage == null)
        {
            monsterImage = GetComponent<SpriteRenderer>();
        }

        monsterImage.sprite = normalSprite;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Satisfy(bool isHappy)
    {
        if (isHappy)
        {
            monsterImage.sprite = happySprite;
        }
        else
        {
            monsterImage.sprite = madSprite;
        }
    }
}
