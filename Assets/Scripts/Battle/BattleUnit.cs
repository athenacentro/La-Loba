using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class BattleUnit : MonoBehaviour
{
    [SerializeField] CharacterBase _cBase;
    [SerializeField] EnemyBase _eBase;

    [SerializeField] int level;
    [SerializeField] bool rightSide; //isPlayerUnit

    public Character Character { get; set; }
    public Enemy Enemy { get; set; }

    Image image;
    Vector3 originalPos;
    Animator _animator;

    private void Awake()
    {
        image = GetComponent<Image>();
        originalPos = image.transform.localPosition;
        _animator = GetComponent<Animator>();
    }

    public void SetupCharacter()
    {
        Character = new Character(_cBase, level);

        if (rightSide)
            image.sprite = Character.Base.LeftFacingSprite;
        else
            image.sprite = Character.Base.RightFacingSprite;

        PlayEnterAnimation();
    }

    public void SetupEnemy()
    {
        Enemy = new Enemy(_eBase, level);

        if (rightSide)
            image.sprite = Enemy.Base.LeftFacingSprite;
        else
            image.sprite = Enemy.Base.RightFacingSprite;

        PlayEnterAnimation();
    }

    public void PlayEnterAnimation()
    {
        if (rightSide)
            image.transform.localPosition = new Vector3(452f, originalPos.y);
        else
            image.transform.localPosition = new Vector3(-480f, originalPos.y);

        image.transform.DOLocalMoveX(originalPos.x, 2f);
    }

    public void PlayAttackAnimation()
    {
        var sequence = DOTween.Sequence();
        if (rightSide)
        {
            sequence.Append(image.transform.DOLocalMoveX(originalPos.x - 50f, 0.25f));
        }
        else
        {
            _animator.SetTrigger("attack");
        }

        sequence.Append(image.transform.DOLocalMoveX(originalPos.x, 0.25f));
        
    }


}
