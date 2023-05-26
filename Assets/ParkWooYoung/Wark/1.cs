using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class Wark1 : MonoBehaviour
{
    // <Time.deltaTime>
    // 프레임 간 이동 사이의 시간 간격
    // 현재 fps의 상태를 알고 자동으로 시간간격을 계산해 줌으로써,
    // 컴퓨터마다 시간을 통일해 줄 수 있어,
    // fps가 다름으로 인해 발생할 수 있는 오류를 방지해 준다.
    // <Distance>
    // 거리를 구하는 함수
    // 

    // <타일맵 만들기>
    // 2D 패키지가 깔려있어야함
    // Hierarchy 우클릭 - 2D 오브젝트 - 타일맵 
    // Rectangular              : 바둑판방식의 격자무늬
    // Hexagonal - Point - Top  : 육각형 형태의 타일맵 (전략시뮬레이션 장르의 게임에 많이 쓰임)
    // Hexagonal - Flat - Top   :
    // Isometric                : 마름모형태의 타일맵 (2D게임이지만 3D게임처럼 착시효과를 일으키는데 사용할 수 있음)
    // Isometric Z as Y         :

    // 스프라이트시트를 타일맵으로 쓰기
    // 1. Window - 2D - Tile Palette
    // 2. Hirearchy 에서 타일맵을 선택시 신창에서 보라색 큐브모양이 생긴걸 눌러도 됨
    // Tile Palette - Create New Palette - 원하는 곳에서 폴더를 만듬 - 원하는 스프라이트 시트를 끈 뒤 원하느 폴더를 만듬

    // 타일 팔레트를 잘못만든 경우 타일 팔레트에 있는 Edit를 눌러서 수정할 수 있다. 

    // <Rule Tile>
    // x      : 이 방향에는 아무것도 없다.
    // 화살표  : 이 방향에는 있다.
    // 빈공간  : 상관없다.
    // 방향이 바뀐 타일을 쓰는것보단 같은 조건의 타일을 복사해서 반전해주는게 훨씬 쉽다.
    // 타일 가운데 버튼 적극 이용

    // <Random Tile>
    // +로 룰타일처럼 만든 뒤 OutPut에서 Random으로 바꾸고 Size에서 숫자를 입력하면 그 입력한 숫자만큼의 랜덤한 타일을 지정해줄 수 있다.
    // 한 룰타일 안에 여러가지의 랜덤타일을 만들 수 있다.
    // 타일맵에다 편의기능 넣는법
    // 이미지 중에 원하는 이미지를 타일맵에 넣을 수 있다
    // 1. 원하는 이미지를 프리팹화
    // 2. 타일 팔레트 아래에있는 브러쉬를 게임오브젝트 브러쉬를 선택한다
    // 3. GameObject Brush - Cells - Game Object에 원하는 프리팹을 넣어주면 타일맵처럼 사용 가능하다
    // 4. 타일맵에 있는게 아니기 때문에 타일맵의 하위자식으로 추가된다. 자식으로 추가되도 밖으로 빼낼 수 있음
    // 5. 조심할건 게임오브젝트 브러쉬라 타일맵과는 별개기 때문에 타일맵에 있는건 게임오브젝트 브러쉬로 사용이 안된다.

    // <Animated Tile>
    // 타일맵에 애니메이션을 넣을 수 있다.
    //


    // <20230524 상태패턴>

    /*private void Update()
    {
        // 점프를 하는 몬스터를 만들 때
        if (isPatrol) // 점프하고 맞지도 않고 플레이어를 안만났을 때 순찰
        {

        }
        else
        {

        }
        if (isJumping) // 점프중일 때
        {
            // <피격당함>
            // 점프 중 피격당했을때
            // 점프를 하지 않고 있는데 맞았을 때
            // 점프를 하는 중에 맞았을 떄
            // 맞지않고 점프를 했을때
            if (isHited)// 점프중인데 맞았을떄
            {
                // 점프 중인데 맞았으니 점프를 안하고 맞음
            }
            else
            {
                // 점프중인데 안맞았으니 그대로 점프 함
            }
        }
        else // 점프중이 아닐때
        {
            Move(); // 점프중이 아닐때만 움직일 수 있다.
            if (!IsGroundExist())
            {
                Turn();
            }
        }
    }
    // 순찰중인데 점프하고있고 맞는 중일땐?
    // 이렇게 많은 조건을 사람이 판단하고 만들기는 쉽지 않다.
    // 그래서 편하게 관리하기 위해 상태패턴이 있다
    // 몬스터를 만들기 위한 하나의 기능이다
    */

    //====================================
    //##        디자인 패턴 State        ##
    //====================================
    /*
     * 상태패턴 : 객체에게 한 번에 하나의 상태만을 가지게 하며 ex. 가만히 있는 상태, 점프하는 상태, 맞는 상태, 순찰중인 상태 등등
     * 객체는 현재 상태에 해당하는 행동만을 진행함
     * 구현 :
     * 1. 열거형 자료형으로 객체가 가질 수 있는 상태들을 정의 ex. 기본, 순찰, 점프, 맞음 등, 어디서부터 상태를 시착할지 처음상태를 지정해 줘야 함
     * 2. 현재 사채를 저장하는 변수에 초기 상태를 지정
     * 3. 객체는 행동에 있어서 현재 상태만의 행동을 진행
     * 4. 객체는 현재 상태의 행동을 진행 후 상태 변화에 대해 판단
     * 5. 상태 변화가 있어야 하는 경우 현재 상태를 대상 상태로 지정
     * 6. 상태가 변경된 다음 행동에 있어서 바뀐 상태만의 행동을 진행
     * 장점 :
     * 1. 객체가 진행할 행동을 복잡한 조건문을 상태로 처리가 가능하므로, 조건처리에 대한 부담이 적음
     * 2. 객체가 가지는 여러상태에 대한 연산없이 현재 상태만을 처리하므로, 연산속도가 뛰어남
     * 3. 객체와 관련된 모든 동작을 각각의 상태에 분산시키므로, 코드가 간결하고 가독성이 좋음
     * 단점 :
     * 1. 상태의 구분이 명확하지 않거나 갯수가 많은 경우, 상태 변경 코드가 복잡해질 수 있음
     * 2. 상태를 클래스로 캡슐화 시키지 않은 경우 상태간 간섭이 가능하므로, 개방폐쇄원칙이 준수되지 않음 !캡슐화 필수!
     * 3. 간단한 동작의 객체에 상태패턴을 적용하는 경우, 오히려 관리할 상태 코드량이 증가하게 됨, 너무 간단한선 상태패턴을 ㅗ쓰지말자
     */
    public class State
    {
        public class Mobile  // 핸드폰을 충전상태를 예로 듬
        {
            public enum State { Off, Normal, Charge, FullCharged } // 꺼짐, 동작중, 충전중, 완전충전

            private State state = State.Normal; // 처음 시작상태를 Normal로 함
            private bool charging = false;      // 처음 시작상태의 충전 여부 
            private float battery = 50.0f;      // 배터리 상태 50

            private void Update()
            {
                /*
                if (charging)
                {
                    if (battery == 100)
                    {
                        // 충전중일 떄 배터리가 100%라면 완전히 충전된 상태고 더이상 충전을 안함
                    }
                    else
                    {
                        // 충전중인데 배터리 상태가 100%가 아니면 충전을 진행한다.
                    }
                }
                else    // 충전중이 아닌 경우
                {
                    if (battery == 0)
                    {
                        // 배터리가 0%니 완전히 방전되서 동작이 안되고 충전을 기다린다.
                    }
                    else
                    {
                        // 배터리가 0%가 아니니 충전은 안하고 동작만 한다.
                    }
                }
                */

                switch (state)              // 현재상테에서 할 업데이트들만 진행
                {
                    case State.Off:         // 현재상태가 Off일 경우 OffUpdate에 대한 내용을 진행
                        OffUpdate();
                        break;
                    case State.Normal:      // 현재상태가 Norma일 경우 NormaUpdate에 대한 내용을 진행
                        NormalUpdate();
                        break;
                    case State.Charge:      // 현재상태가 Charge일 경우 ChargeUpdate에 대한 내용을 진행
                        ChargeUpdate();
                        break;
                    case State.FullCharged: // 현재상태가 FullCharge일 경우 FullChargeUpdate에 대한 내용을 진행
                        FullChargedUpdate();
                        break;
                }
            }
            private void OffUpdate()
            {
                // Off work     
                // Do nothing   
                // Off 상태일 때 할일을 정해줄 수 있다.

                if (charging) // 충전중일때
                {
                    state = State.Charge; // 현재상태를 충전상태로 전환한다
                }
            }
            private void NormalUpdate()
            {
                // Normal work
                // Normal 상태일 때 할일을 정해줄 수 있다.
                battery -= 1.5f * Time.deltaTime; // 배터리를 1.5씩 계속 소모해준다. 

                if (charging) // 충전중일때
                {
                    state = State.Charge; // 현재상태를 충전상태로 전환한다
                }
                else if (battery <= 0) // battery가 0보다 작거나 같을 때
                {
                    state = State.Off; // 현재상태를 Off상태로 전환한다
                }

            }
            private void ChargeUpdate()
            {
                // Charge work
                // Charge 상태일 때 할일을 정해준다.
                battery += 2.5f * Time.deltaTime; // 배터리소모를 안하고 2.5씩 충전해준다

                if (!charging) // 충전을 안할 때
                {
                    state = State.Normal; // 현재상태를 Normal상태로 전환한다
                }
                else if (battery >= 100) // battery가 100보다 크거나 같을 때
                {
                    state = State.FullCharged; // 현재상태를 FullCharged상태로 전환한다
                }
            }
            private void FullChargedUpdate()
            {
                // FullCharged
                // FullCharged 상태일 때 할일을 정해준다.
                if (!charging) // 충전을 하지 않는다
                {
                    state = State.Normal; // 현재상태를 Normal상태로 전환한다
                }
                // 배터리가 FullCharged상태니 else는 넣어주지 않아도 된다.
            }
            public void ConnectCharger()        // 충전기 연결
            {
                charging = true;                // 충전중
            }
            public void DisConnectCharger()     // 충전기 연결 안함
            {
                charging = false;               // 충전안함
            }
        }

        // <공중몬스터 구현>
        // 몬스터 상속하기
        //public class Monster : MonoBehaviour
        //{ }
        //public class Bee : Monster
        //{ } 
        // 상속받으면 컴포넌트 못쓰는게 아니라 Monster자체가 MonoBehaviour이기 때문에 MonoBehaviour가 쓰는 컴포넌트는 다 쓸 수 있음
        // 유니티창 : Bee한테 텍스트 준뒤 캔버스의 카메라는 월드스페이스주고 크기 조정 위치는 자신의 위치인 0, 0, 0 폰트사이즈 줄이기 내용은 Idle 이벤트카메라는 메인카메라주고 가운데정렬
        public class Bee : MonoBehaviour
        {
            // 1. 플레이어가 멀리 있을땐 가만히 있기
            // 2. 플레이어가 어느정도 가까워지면, 플레이어를 공격하도록 추적
            // 2-1. 추적 중에 너무 멀어지면 다시 제자리
            // 2-2. 추적중에 공격범위 안에 들어오면 공격함
            public enum State { Idle, Trace, Return, Attack}    // 가만히, 추적, 돌아오기, 공격
            [SerializeField] private TMP_Text text;             // 텍스트를 이용해 현재 무엇을 하고있나 표시함 switch와 연동
            [SerializeField] private float detectRange;         // 이 영역 안에 있으면 쫓아가게 하기 위해 썻음
            [SerializeField] private float attackRange;
            [SerializeField] private float moveSpeed;
            private State curState;                             // 지금상태를 보관하는 현재상태
            // private PlayerController player;                 // PlayerController스크립트가 달린 플레이어를 찾기위해 씀
            private Transform player;                           // Player의 Tag가 달린 플레이어의 현재위치를 찾기위해 사용
            private Vector3 returnPosition;                     // 돌아갈 위치(지금 있어야 할 위치) 현재위치가 아닌 돌아가야할 위치로 가야하기때문에 트랜스폼대신 백터를 씀
            private void Start()
            {
                curState = State.Idle;                          // 시작하자마자 상태
                player = GameObject.FindGameObjectWithTag("Player").transform; //Player의 Tag가 달린 플레이어의 현재위치를 탐색, 플레이어 자체를 따라다니는것보다 위치를 찾는게 중요함 몬스터는 시작하자마자 플레이어 게임오브젝트의 트랜스폼 컴포넌트를 갖게 됨
                returnPosition = transform.position;            // 시작하자마자 위치로 지정해야 있었던 위치로 지정되기때문에 추격에 실패하면 원래 있었어야할 위치로 인식해서 돌아감
            }
            private void Update()
            {
                switch (curState)                               // 각각의 상태에서 현재상태의 작업
                {
                    case State.Idle:
                        text.text = "Idle";
                        IdleUpdate();
                        break;
                    case State.Trace:
                        text.text = "Trace";
                        TraceUpdate();
                        break;
                    case State.Return:
                        text.text = "Return";
                        ReturnUpdate();
                        break;
                    case State.Attack:
                        text.text = "Attack";
                        AttackUpdate();
                        break;
                }
            }
            private void IdleUpdate()   // 평소상태
            {
                // 아무것도 안하기

                // 플레이어와 가까워졌을 때
                if (Vector2.Distance(player.position, transform.position) < detectRange ) // 플레이어의 포지션과 지금 나의 포지션이 detectRange보다 작으면 플레이어가 가까워졌다고 인식함
                {
                    curState = State.Trace; // 따라가는게 아닌 추적상태로 변환함
                }
            }
            private void TraceUpdate()  // 추격상태
            {
                // 플레이어 쫓아가기
                // normalized : 백터가 크든 작든 크기가 1인 백터로 만들어서 정규화시켜줌
                Vector2 dir = (player.position - transform.position).normalized;  // 플레이어의 포지션을 내 위치만큼 뺸위치만큼 가줌, 플레이어가 있는 방향으로 가는 방법은 도착지 - 출발지가 출발지로부터 그 도착지로 가기위한 방향성 백터임(백터연산을 알아야 잘이해가 됨)
                transform.Translate(dir * moveSpeed * Time.deltaTime); // 방향과 속도 시간을 가지고 곱해줌

                // 플레이어가 멀어졌을 때
                if (Vector2.Distance(player.position, transform.position) > detectRange) // 플레이어의 포지션과 지금 나의 포지션이 detectRange보다 작으면 플레이어가 커져서 벗어났기 때문에 범위안에 플레이어를 찾을수가 없음
                {
                    curState = State.Return; // 리턴상태로 전환
                }

                // 공격범위 안에 있을 때
                else if (Vector2.Distance(player.position, transform.position) < attackRange) // 플레이어의 포지션과 지금 나의 포지션이 attackRange보다 작으면 플레이어가 공격범위안에 들어왔다고 인식함
                {
                    curState = State.Attack; // 공격상태로 전환
                }
            }
            private void ReturnUpdate() // 돌아올떄
            {
                // 원래 자리로 돌아가기
                Vector2 dir = (returnPosition - transform.position).normalized;  
                transform.Translate(dir * moveSpeed * Time.deltaTime); 

                // 원래 자리로 도착했으면
                if (Vector2.Distance(transform.position, returnPosition) < 0.02f) // 돌아가고자하는 위치가 0.02보다 작으면 도착했다고 본다.
                    // if (transform.position == returnPosition) 돌아가고자 하는 위치가 정확하게 현재위치라면 맞지만 float는 대략적인 소수점을 표현하는 방식이다 보니 조금만 틀어져도 달랐다고 나오고 유니티는 프레임 기반으로 돌아가다 보니 도착위치가 한프레임의 속도와 딱 맞지 않는 위치에 있다면 역방으로 돌아왔다갔다 하다보니 계속 떨리기만 하고 반복하다보니 근접했다고 쓰는게 낫다
                {
                    curState = State.Idle; // 평소상태로 전환
                }
                else if (Vector2.Distance(player.position, transform.position) < detectRange) // 돌아가는 중에도 detectRange안에 있는게 확인이 됐을 때
                {
                    curState = State.Trace; // 추격상태로 전환
                }
            }
            float lastAttackTime = 0;
            private void AttackUpdate() //공격할때
            {
                // 공격하기
                if (lastAttackTime > 3) // lastAttackTime이 3보다 클때만 공격, 여기선 3초이상지나야 공격함
                {
                    Debug.Log("공격");
                    lastAttackTime = 0; // 3보다 커졌으니 다시 0으로 만듬
                }

                lastAttackTime += Time.deltaTime;  // lastAttackTime을 Time.deltaTime만큼 더해줌, 1초가 됐을때 1만큼 누적

                if (Vector2.Distance(player.position, transform.position) > attackRange) // 공격하다가 공격범위를 벗어나면, 추격상태로 바꾸기 위해 쓰려면 detectRange가 attackRange보다 커야함
                {
                    curState = State.Trace; // 추격상태로 전환
                }
            }
            private void OnDrawGizmos()
            {
                Gizmos.color = Color.yellow;                            // 노란색
                Gizmos.DrawWireSphere(transform.position, detectRange); // 내위치로부터 detectRange 만큼 동그랗게 그려줌 DrawWireSphere : 동그라미
                Gizmos.color = Color.red;                               // 빨간색
                Gizmos.DrawWireSphere(transform.position, attackRange); // 내위치로부터 attackRange 만큼 동그랗게 그려줌 DrawWireSphere : 동그라미
            }



        }























    }

