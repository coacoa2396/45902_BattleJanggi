using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "FPSPieceData", menuName = "Data/FPS")]
public class FPSPieceData : ScriptableObject
{
    [SerializeField] int hp;
    public int HP { get { return hp; }}

    [SerializeField] float speed;
    public float Speed { get { return speed; }}

    [SerializeField] GameObject piecePrefab;
    public GameObject PiecePrefab { get {  return piecePrefab; }}


}
