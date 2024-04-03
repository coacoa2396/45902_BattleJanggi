using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallAccelerate : Wall
{
    // 진입시 플레이어에게 가속'버프'를 주는 형식으로 구현

    // TriggerEnter로 버프체크하고

    // 진입시에는 버프의 지속시간을 어마어마하게 크게 준 다음에

    // TriggerExit으로 버프의 시간을 지속시간 만큼으로 줄여준다    
}
