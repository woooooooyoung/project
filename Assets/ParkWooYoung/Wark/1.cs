using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wark1 : MonoBehaviour
{
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























}

