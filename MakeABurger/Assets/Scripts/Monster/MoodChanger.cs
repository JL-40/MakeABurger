using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

[RequireComponent(typeof(MonsterController))]
public class MoodChanger : MonoBehaviour
{
    [SerializeField] SpriteRenderer monsterImage;

    [SerializeField] Sprite normalSprite;
    [SerializeField] Sprite happySprite;
    [SerializeField] Sprite madSprite;

    [SerializeField] MonsterController monsterController;

    // Start is called before the first frame update
    void Start()
    {
        if (monsterImage == null)
        {
            monsterImage = GetComponent<SpriteRenderer>();
        }

        monsterImage.sprite = normalSprite;

        if (monsterController == null)
        {
            monsterController = GetComponent<MonsterController>();
        }
    }

    public void Satisfy(bool isHappy)
    {
        if (isHappy)
        {
            monsterImage.sprite = happySprite;
            PlayHappyMonsterSound();
        }
        else
        {
            monsterImage.sprite = madSprite;
            PlaySadMonsterSound();
        }
    }

    void PlayHappyMonsterSound()
    {
        EventReference monsterSound;

        switch (monsterController.MonsterType) 
        {
            case MONSTER_TYPE.LIZARD:
                {
                    monsterSound = FModEvents.Instance.lizardHappy;
                    break;
                }
            case MONSTER_TYPE.PINK_BLOB:
                {
                    monsterSound = FModEvents.Instance.pinkBlobHappy;
                    break;
                }
            case MONSTER_TYPE.PURPLE_BLOB:
                {
                    monsterSound = FModEvents.Instance.purpleBlobHappy;
                    break;
                }
            case MONSTER_TYPE.SQUID:
                {
                    monsterSound = FModEvents.Instance.squidHappy;
                    break;
                }
            default:
                {
                    monsterSound = new EventReference();
                    break;
                }
        }

        if (monsterSound.Equals(new EventReference()) == false)
        {
            AudioManager.Instance.PlayOneShot(monsterSound, gameObject.transform.position);
        }
    }

    void PlaySadMonsterSound()
    {
        EventReference monsterSound;

        switch (monsterController.MonsterType)
        {
            case MONSTER_TYPE.LIZARD:
                {
                    monsterSound = FModEvents.Instance.lizardSad;
                    break;
                }
            case MONSTER_TYPE.PINK_BLOB:
                {
                    monsterSound = FModEvents.Instance.pinkBlobSad;
                    break;
                }
            case MONSTER_TYPE.PURPLE_BLOB:
                {
                    monsterSound = FModEvents.Instance.purpleBlobSad;
                    break;
                }
            case MONSTER_TYPE.SQUID:
                {
                    monsterSound = FModEvents.Instance.squidSad;
                    break;
                }
            default:
                {
                    monsterSound = new EventReference();
                    break;
                }
        }

        if (monsterSound.Equals(new EventReference()) == false)
        {
            AudioManager.Instance.PlayOneShot(monsterSound, gameObject.transform.position);
        }
    }
}
