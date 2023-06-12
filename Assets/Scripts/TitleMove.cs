using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TitleMove : MonoBehaviour
{
    [SerializeField] public float duration;
    [SerializeField] public float xmove;
    [SerializeField] public float ymove;
    // Start is called before the first frame update
    void Start()
    {
        transform.DOMove(new Vector3(transform.position.x+xmove,transform.position.y,transform.position.z),duration).SetEase(Ease.InOutSine).SetLoops(-1,LoopType.Yoyo);
        transform.DORotate(new Vector3(0,0,360),duration * 3,RotateMode.FastBeyond360).SetEase(Ease.InOutSine).SetLoops(-1,LoopType.Restart).SetEase(Ease.Linear);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
