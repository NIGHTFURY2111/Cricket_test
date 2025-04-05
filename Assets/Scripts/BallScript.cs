using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    [SerializeField] Vector3 LeftSideStartPosi;
    [SerializeField] Vector3 RightSideStartPosi;
    [SerializeField] public bool isLeftSide;

    private void Awake()
    {
        SwitchBowlingSide();
    }
    void SwitchBowlingSide()
    {
        transform.position = isLeftSide ? LeftSideStartPosi : RightSideStartPosi;
    }

}
