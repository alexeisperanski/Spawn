using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MoveTo : MonoBehaviour
{
    private void Start()
    {
        transform.DOMove(new Vector3(3,5,0), 3).SetDelay(2).SetLoops(-1, LoopType.Yoyo);
    }
}
