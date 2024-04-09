using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Timeline.Actions;
using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// 개발자: Yerin
/// 
/// 장기말의 기능 구현
/// </summary>
public class Piece : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] LayerMask playerCheck;

    protected Spot[,] JanggiSituation;    // 현재 장기판 위 말의 상황을 받아 올 배열

    Material pieceMaterial; // 해당 장기말의 Material을 받을 변수
    Spot underSpot;

    protected string pieceName; // 장기말의 종류
    bool isClicked;  // 해당 말이 클릭됐는지 아닌지 판단하는 변수

    [SerializeField] string whosPiece;

    public Material PieceMaterial { get { return pieceMaterial; } }
    public string PieceName { get { return pieceName; } }
    public string WhosPiece { get { return whosPiece; } }
    public bool IsClicked { set { isClicked = value; } }


    List<Spot> CanGoSpots = new List<Spot>();

    protected virtual void Start()
    {
        pieceMaterial = gameObject.GetComponent<Renderer>().material;
    }

    /// <summary>
    /// 해당 장기말 선택 시 장기판의 전체적인 상황 받아옴
    /// 플레이어가 장기말을 선택 시 해당 오브젝트의 색을 빨간색으로 변경
    /// </summary>
    /// <param name="eventData"></param>
    public void OnPointerClick(PointerEventData eventData)
    {
        if (!Manager.JanggiTurn.CheckWhosTurn(WhosPiece))
        {
            if (!underSpot.InList)
                return;

            // 여기서 FPS씬으로 이동
            TransFPS(underSpot.ListPiece, this);
            //underSpot.ClickMove();    // 움직이는건 승리를 했을 경우에 실행
        }
        else
        {
            if (!CheckMyTurn())
            {
                return;
            }

            if (isClicked)
            {
                JanggiLogic.Instance.ClickedPieceExist = false;


                pieceMaterial.color = Color.white;
                isClicked = false;

                DeleteList();
                Manager.JanggiCamera.CameraMoveLow();
                return;
            }

            JanggiSituation = Manager.JanggiLogic.JanggiLogicSituation;

            if (JanggiSituation == null)
            {
                Debug.Log("Get JanggiLogic Fail");
            }

            if (JanggiLogic.Instance.ClickedPieceExist)  // 장기판에 다른 말이 이미 선택되어 있을 경우
            {
                JanggiLogic.Instance.ClickedPiece.pieceMaterial.color = Color.white;
                JanggiLogic.Instance.ClickedPiece.IsClicked = false;

                JanggiLogic.Instance.ClickedPiece.DeleteList();
            }

            JanggiLogic.Instance.ClickedPieceExist = true;
            JanggiLogic.Instance.ClickedPiece = this;

            pieceMaterial.color = Color.red;
            isClicked = true;

            Manager.JanggiCamera.CameraMoveHigh();
            FindCanGo();
        }
    }
        /// <summary>
        /// 플레이어가 해당 장기말 위에 마우스를 올릴 시 오브젝트의 색을 노란색으로 변경
        /// 선택할 수 있음을 알려주기 위해
        /// </summary>
        /// <param name="eventData"></param>

        public void OnPointerEnter(PointerEventData eventData)
        {
            if (!CheckMyTurn())
            {
                return;
            }

            if (isClicked)
            {
                return;
            }

            pieceMaterial.color = Color.yellow;
        }

        /// <summary>
        /// 플레이어가 해당 장기말을 선택하지 않고 나왔을 시 오브젝트의 색을 원래대로 변경
        /// </summary>
        /// <param name="eventData"></param>
        public void OnPointerExit(PointerEventData eventData)
        {
            if (isClicked)
            {
                return;
            }

            pieceMaterial.color = Color.white;
        }

        /// <summary>
        /// 기물을 해당 spot의 위치로 옮기는 함수
        /// </summary>
        /// <param name="selectSpot"></param>
        public void MovePiece(Spot selectSpot)
        {
            underSpot.CheckCanGo = false;
            transform.position = new Vector3(selectSpot.transform.position.x, transform.position.y, selectSpot.transform.position.z);

            JanggiLogic.Instance.ClickedPieceExist = false;

            pieceMaterial.color = Color.white;
            isClicked = false;

            DeleteList();
            Manager.JanggiTurn.OnTurn();
            Manager.JanggiCamera.CameraMoveLow();
        }

        /// <summary>
        /// 갈 수있는 spot을 리스트에 넣고 빨간색으로 표시해준다
        /// </summary>
        /// <param name="destSpot"></param>
        public void AddList(Spot destSpot)
        {
            destSpot.GetComponent<Renderer>().material.color = Color.red;
            destSpot.CheckCanGo = true;
            destSpot.InList = true;
            destSpot.SetList(this);
            CanGoSpots.Add(destSpot);
        }

        /// <summary>
        /// 갈 수 있는 Spot을 저장한 리스트 전체 삭제
        /// </summary>
        public void DeleteList()
        {
            foreach (Spot spot in CanGoSpots)
            {
                Color color = new Color(0, 0, 0, 0);

                spot.gameObject.GetComponent<Renderer>().material.color = color;
            }

            CanGoSpots.Clear();
        }

    public virtual void FindCanGo()
    {

    }

    private bool CheckMyTurn()
    {
        if (!Manager.JanggiTurn.CheckWhosTurn(whosPiece))
        {
            return false;
        }

        return true;
    }
    /// <summary>
    /// 제작 : 찬규
    /// FPS씬으로 이동하게 하는 함수
    /// </summary>
    /// <param name="player1"></param>
    /// <param name="player2"></param>
    public void TransFPS(Piece player1, Piece player2)
    {
        // 씬 매니저를 사용하여 로드
        // FPS씬에 Player1은 gameObject의 FPSPrefab
        // Player2는 collision.gameObject의 FPSPrefab으로 설정한다
    }
    /// <summary>
    /// 제작 : 찬규
    /// 발 밑의 spot을 받아옴
    /// 상대방의 이동 때 사용
    /// </summary>
    /// <param name="spot"></param>
    public void SetUnderSpot(Spot spot)
    {
        underSpot = spot;
    }
}
