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
    Color originalColor;

    private void Awake()
    {
        image = GetComponent<Image>();
        originalPos = image.transform.localPosition;
        _animator = GetComponent<Animator>();
        originalColor = image.color;
    }

    public void SetupCharacter()
    {
        Character = new Character(_cBase, level);

        if (rightSide)
        {
            _animator.SetTrigger("walkleft");
            image.sprite = Character.Base.LeftFacingSprite;
        }
        else
        {
            _animator.SetTrigger("walkright");
            image.sprite = Character.Base.RightFacingSprite;
        }

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
        {
            _animator.SetTrigger("walkleft");
            image.transform.localPosition = new Vector3(452f, originalPos.y);
        }
        else
        {
            _animator.SetTrigger("faceright");
            image.transform.localPosition = new Vector3(-480f, originalPos.y);
        }
            
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
            sequence.Append(image.transform.DOLocalMoveX(originalPos.x + 50f, 0.5f));
        }

        sequence.Append(image.transform.DOLocalMoveX(originalPos.x, 0.25f));
        
    }

    public void PlayHitAnimation()
    {
        var sequence = DOTween.Sequence();
        sequence.Append(image.DOColor(Color.gray, 0.2f));
        sequence.Append(image.DOColor(originalColor, 0.2f));
    }

    public void PlayFaintAnimation()
    {
        var sequence = DOTween.Sequence();
        sequence.Append(image.transform.DOLocalMoveY(originalPos.y - 150f, 0.5f));
        sequence.Join(image.DOFade(0f, 0.5f));
    }
}
