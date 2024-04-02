using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallTurret : Wall
{
    // 오버랩으로 체크하는데
    // Time.deltatime을 업데이트마다 쌓아서 발사 타이밍마다 오버랩을 체크하게 하고
    // 플레이어가 검출되면 플레이어를 타겟으로 잡고 bullet 발사
}
