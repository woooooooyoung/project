using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class Wark1 : MonoBehaviour
{
    // <Time.deltaTime>
    // ������ �� �̵� ������ �ð� ����
    // ���� fps�� ���¸� �˰� �ڵ����� �ð������� ����� �����ν�,
    // ��ǻ�͸��� �ð��� ������ �� �� �־�,
    // fps�� �ٸ����� ���� �߻��� �� �ִ� ������ ������ �ش�.
    // <Distance>
    // �Ÿ��� ���ϴ� �Լ�
    // 

    // <Ÿ�ϸ� �����>
    // 2D ��Ű���� ����־����
    // Hierarchy ��Ŭ�� - 2D ������Ʈ - Ÿ�ϸ� 
    // Rectangular              : �ٵ��ǹ���� ���ڹ���
    // Hexagonal - Point - Top  : ������ ������ Ÿ�ϸ� (�����ùķ��̼� �帣�� ���ӿ� ���� ����)
    // Hexagonal - Flat - Top   :
    // Isometric                : ������������ Ÿ�ϸ� (2D���������� 3D����ó�� ����ȿ���� ����Ű�µ� ����� �� ����)
    // Isometric Z as Y         :

    // ��������Ʈ��Ʈ�� Ÿ�ϸ����� ����
    // 1. Window - 2D - Tile Palette
    // 2. Hirearchy ���� Ÿ�ϸ��� ���ý� ��â���� ����� ť������ ����� ������ ��
    // Tile Palette - Create New Palette - ���ϴ� ������ ������ ���� - ���ϴ� ��������Ʈ ��Ʈ�� �� �� ���ϴ� ������ ����

    // Ÿ�� �ȷ�Ʈ�� �߸����� ��� Ÿ�� �ȷ�Ʈ�� �ִ� Edit�� ������ ������ �� �ִ�. 

    // <Rule Tile>
    // x      : �� ���⿡�� �ƹ��͵� ����.
    // ȭ��ǥ  : �� ���⿡�� �ִ�.
    // �����  : �������.
    // ������ �ٲ� Ÿ���� ���°ͺ��� ���� ������ Ÿ���� �����ؼ� �������ִ°� �ξ� ����.
    // Ÿ�� ��� ��ư ���� �̿�

    // <Random Tile>
    // +�� ��Ÿ��ó�� ���� �� OutPut���� Random���� �ٲٰ� Size���� ���ڸ� �Է��ϸ� �� �Է��� ���ڸ�ŭ�� ������ Ÿ���� �������� �� �ִ�.
    // �� ��Ÿ�� �ȿ� ���������� ����Ÿ���� ���� �� �ִ�.
    // Ÿ�ϸʿ��� ���Ǳ�� �ִ¹�
    // �̹��� �߿� ���ϴ� �̹����� Ÿ�ϸʿ� ���� �� �ִ�
    // 1. ���ϴ� �̹����� ������ȭ
    // 2. Ÿ�� �ȷ�Ʈ �Ʒ����ִ� �귯���� ���ӿ�����Ʈ �귯���� �����Ѵ�
    // 3. GameObject Brush - Cells - Game Object�� ���ϴ� �������� �־��ָ� Ÿ�ϸ�ó�� ��� �����ϴ�
    // 4. Ÿ�ϸʿ� �ִ°� �ƴϱ� ������ Ÿ�ϸ��� �����ڽ����� �߰��ȴ�. �ڽ����� �߰��ǵ� ������ ���� �� ����
    // 5. �����Ұ� ���ӿ�����Ʈ �귯���� Ÿ�ϸʰ��� ������ ������ Ÿ�ϸʿ� �ִ°� ���ӿ�����Ʈ �귯���� ����� �ȵȴ�.

    // <Animated Tile>
    // Ÿ�ϸʿ� �ִϸ��̼��� ���� �� �ִ�.
    //


    // <20230524 ��������>

    /*private void Update()
    {
        // ������ �ϴ� ���͸� ���� ��
        if (isPatrol) // �����ϰ� ������ �ʰ� �÷��̾ �ȸ����� �� ����
        {

        }
        else
        {

        }
        if (isJumping) // �������� ��
        {
            // <�ǰݴ���>
            // ���� �� �ǰݴ�������
            // ������ ���� �ʰ� �ִµ� �¾��� ��
            // ������ �ϴ� �߿� �¾��� ��
            // �����ʰ� ������ ������
            if (isHited)// �������ε� �¾�����
            {
                // ���� ���ε� �¾����� ������ ���ϰ� ����
            }
            else
            {
                // �������ε� �ȸ¾����� �״�� ���� ��
            }
        }
        else // �������� �ƴҶ�
        {
            Move(); // �������� �ƴҶ��� ������ �� �ִ�.
            if (!IsGroundExist())
            {
                Turn();
            }
        }
    }
    // �������ε� �����ϰ��ְ� �´� ���϶�?
    // �̷��� ���� ������ ����� �Ǵ��ϰ� ������ ���� �ʴ�.
    // �׷��� ���ϰ� �����ϱ� ���� ���������� �ִ�
    // ���͸� ����� ���� �ϳ��� ����̴�
    */

    //====================================
    //##        ������ ���� State        ##
    //====================================
    /*
     * �������� : ��ü���� �� ���� �ϳ��� ���¸��� ������ �ϸ� ex. ������ �ִ� ����, �����ϴ� ����, �´� ����, �������� ���� ���
     * ��ü�� ���� ���¿� �ش��ϴ� �ൿ���� ������
     * ���� :
     * 1. ������ �ڷ������� ��ü�� ���� �� �ִ� ���µ��� ���� ex. �⺻, ����, ����, ���� ��, ��𼭺��� ���¸� �������� ó�����¸� ������ ��� ��
     * 2. ���� ��ä�� �����ϴ� ������ �ʱ� ���¸� ����
     * 3. ��ü�� �ൿ�� �־ ���� ���¸��� �ൿ�� ����
     * 4. ��ü�� ���� ������ �ൿ�� ���� �� ���� ��ȭ�� ���� �Ǵ�
     * 5. ���� ��ȭ�� �־�� �ϴ� ��� ���� ���¸� ��� ���·� ����
     * 6. ���°� ����� ���� �ൿ�� �־ �ٲ� ���¸��� �ൿ�� ����
     * ���� :
     * 1. ��ü�� ������ �ൿ�� ������ ���ǹ��� ���·� ó���� �����ϹǷ�, ����ó���� ���� �δ��� ����
     * 2. ��ü�� ������ �������¿� ���� ������� ���� ���¸��� ó���ϹǷ�, ����ӵ��� �پ
     * 3. ��ü�� ���õ� ��� ������ ������ ���¿� �л��Ű�Ƿ�, �ڵ尡 �����ϰ� �������� ����
     * ���� :
     * 1. ������ ������ ��Ȯ���� �ʰų� ������ ���� ���, ���� ���� �ڵ尡 �������� �� ����
     * 2. ���¸� Ŭ������ ĸ��ȭ ��Ű�� ���� ��� ���°� ������ �����ϹǷ�, ��������Ģ�� �ؼ����� ���� !ĸ��ȭ �ʼ�!
     * 3. ������ ������ ��ü�� ���������� �����ϴ� ���, ������ ������ ���� �ڵ差�� �����ϰ� ��, �ʹ� �����Ѽ� ���������� �Ǿ�������
     */
    public class State
    {
        public class Mobile  // �ڵ����� �������¸� ���� ��
        {
            public enum State { Off, Normal, Charge, FullCharged } // ����, ������, ������, ��������

            private State state = State.Normal; // ó�� ���ۻ��¸� Normal�� ��
            private bool charging = false;      // ó�� ���ۻ����� ���� ���� 
            private float battery = 50.0f;      // ���͸� ���� 50

            private void Update()
            {
                /*
                if (charging)
                {
                    if (battery == 100)
                    {
                        // �������� �� ���͸��� 100%��� ������ ������ ���°� ���̻� ������ ����
                    }
                    else
                    {
                        // �������ε� ���͸� ���°� 100%�� �ƴϸ� ������ �����Ѵ�.
                    }
                }
                else    // �������� �ƴ� ���
                {
                    if (battery == 0)
                    {
                        // ���͸��� 0%�� ������ �����Ǽ� ������ �ȵǰ� ������ ��ٸ���.
                    }
                    else
                    {
                        // ���͸��� 0%�� �ƴϴ� ������ ���ϰ� ���۸� �Ѵ�.
                    }
                }
                */

                switch (state)              // ������׿��� �� ������Ʈ�鸸 ����
                {
                    case State.Off:         // ������°� Off�� ��� OffUpdate�� ���� ������ ����
                        OffUpdate();
                        break;
                    case State.Normal:      // ������°� Norma�� ��� NormaUpdate�� ���� ������ ����
                        NormalUpdate();
                        break;
                    case State.Charge:      // ������°� Charge�� ��� ChargeUpdate�� ���� ������ ����
                        ChargeUpdate();
                        break;
                    case State.FullCharged: // ������°� FullCharge�� ��� FullChargeUpdate�� ���� ������ ����
                        FullChargedUpdate();
                        break;
                }
            }
            private void OffUpdate()
            {
                // Off work     
                // Do nothing   
                // Off ������ �� ������ ������ �� �ִ�.

                if (charging) // �������϶�
                {
                    state = State.Charge; // ������¸� �������·� ��ȯ�Ѵ�
                }
            }
            private void NormalUpdate()
            {
                // Normal work
                // Normal ������ �� ������ ������ �� �ִ�.
                battery -= 1.5f * Time.deltaTime; // ���͸��� 1.5�� ��� �Ҹ����ش�. 

                if (charging) // �������϶�
                {
                    state = State.Charge; // ������¸� �������·� ��ȯ�Ѵ�
                }
                else if (battery <= 0) // battery�� 0���� �۰ų� ���� ��
                {
                    state = State.Off; // ������¸� Off���·� ��ȯ�Ѵ�
                }

            }
            private void ChargeUpdate()
            {
                // Charge work
                // Charge ������ �� ������ �����ش�.
                battery += 2.5f * Time.deltaTime; // ���͸��Ҹ� ���ϰ� 2.5�� �������ش�

                if (!charging) // ������ ���� ��
                {
                    state = State.Normal; // ������¸� Normal���·� ��ȯ�Ѵ�
                }
                else if (battery >= 100) // battery�� 100���� ũ�ų� ���� ��
                {
                    state = State.FullCharged; // ������¸� FullCharged���·� ��ȯ�Ѵ�
                }
            }
            private void FullChargedUpdate()
            {
                // FullCharged
                // FullCharged ������ �� ������ �����ش�.
                if (!charging) // ������ ���� �ʴ´�
                {
                    state = State.Normal; // ������¸� Normal���·� ��ȯ�Ѵ�
                }
                // ���͸��� FullCharged���´� else�� �־����� �ʾƵ� �ȴ�.
            }
            public void ConnectCharger()        // ������ ����
            {
                charging = true;                // ������
            }
            public void DisConnectCharger()     // ������ ���� ����
            {
                charging = false;               // ��������
            }
        }

        // <���߸��� ����>
        // ���� ����ϱ�
        //public class Monster : MonoBehaviour
        //{ }
        //public class Bee : Monster
        //{ } 
        // ��ӹ����� ������Ʈ �����°� �ƴ϶� Monster��ü�� MonoBehaviour�̱� ������ MonoBehaviour�� ���� ������Ʈ�� �� �� �� ����
        // ����Ƽâ : Bee���� �ؽ�Ʈ �ص� ĵ������ ī�޶�� ���彺���̽��ְ� ũ�� ���� ��ġ�� �ڽ��� ��ġ�� 0, 0, 0 ��Ʈ������ ���̱� ������ Idle �̺�Ʈī�޶�� ����ī�޶��ְ� �������
        public class Bee : MonoBehaviour
        {
            // 1. �÷��̾ �ָ� ������ ������ �ֱ�
            // 2. �÷��̾ ������� ���������, �÷��̾ �����ϵ��� ����
            // 2-1. ���� �߿� �ʹ� �־����� �ٽ� ���ڸ�
            // 2-2. �����߿� ���ݹ��� �ȿ� ������ ������
            public enum State { Idle, Trace, Return, Attack}    // ������, ����, ���ƿ���, ����
            [SerializeField] private TMP_Text text;             // �ؽ�Ʈ�� �̿��� ���� ������ �ϰ��ֳ� ǥ���� switch�� ����
            [SerializeField] private float detectRange;         // �� ���� �ȿ� ������ �Ѿư��� �ϱ� ���� ����
            [SerializeField] private float attackRange;
            [SerializeField] private float moveSpeed;
            private State curState;                             // ���ݻ��¸� �����ϴ� �������
            // private PlayerController player;                 // PlayerController��ũ��Ʈ�� �޸� �÷��̾ ã������ ��
            private Transform player;                           // Player�� Tag�� �޸� �÷��̾��� ������ġ�� ã������ ���
            private Vector3 returnPosition;                     // ���ư� ��ġ(���� �־�� �� ��ġ) ������ġ�� �ƴ� ���ư����� ��ġ�� �����ϱ⶧���� Ʈ��������� ���͸� ��
            private void Start()
            {
                curState = State.Idle;                          // �������ڸ��� ����
                player = GameObject.FindGameObjectWithTag("Player").transform; //Player�� Tag�� �޸� �÷��̾��� ������ġ�� Ž��, �÷��̾� ��ü�� ����ٴϴ°ͺ��� ��ġ�� ã�°� �߿��� ���ʹ� �������ڸ��� �÷��̾� ���ӿ�����Ʈ�� Ʈ������ ������Ʈ�� ���� ��
                returnPosition = transform.position;            // �������ڸ��� ��ġ�� �����ؾ� �־��� ��ġ�� �����Ǳ⶧���� �߰ݿ� �����ϸ� ���� �־������ ��ġ�� �ν��ؼ� ���ư�
            }
            private void Update()
            {
                switch (curState)                               // ������ ���¿��� ��������� �۾�
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
            private void IdleUpdate()   // ��һ���
            {
                // �ƹ��͵� ���ϱ�

                // �÷��̾�� ��������� ��
                if (Vector2.Distance(player.position, transform.position) < detectRange ) // �÷��̾��� �����ǰ� ���� ���� �������� detectRange���� ������ �÷��̾ ��������ٰ� �ν���
                {
                    curState = State.Trace; // ���󰡴°� �ƴ� �������·� ��ȯ��
                }
            }
            private void TraceUpdate()  // �߰ݻ���
            {
                // �÷��̾� �Ѿư���
                // normalized : ���Ͱ� ũ�� �۵� ũ�Ⱑ 1�� ���ͷ� ���� ����ȭ������
                Vector2 dir = (player.position - transform.position).normalized;  // �÷��̾��� �������� �� ��ġ��ŭ �A��ġ��ŭ ����, �÷��̾ �ִ� �������� ���� ����� ������ - ������� ������κ��� �� �������� �������� ���⼺ ������(���Ϳ����� �˾ƾ� �����ذ� ��)
                transform.Translate(dir * moveSpeed * Time.deltaTime); // ����� �ӵ� �ð��� ������ ������

                // �÷��̾ �־����� ��
                if (Vector2.Distance(player.position, transform.position) > detectRange) // �÷��̾��� �����ǰ� ���� ���� �������� detectRange���� ������ �÷��̾ Ŀ���� ����� ������ �����ȿ� �÷��̾ ã������ ����
                {
                    curState = State.Return; // ���ϻ��·� ��ȯ
                }

                // ���ݹ��� �ȿ� ���� ��
                else if (Vector2.Distance(player.position, transform.position) < attackRange) // �÷��̾��� �����ǰ� ���� ���� �������� attackRange���� ������ �÷��̾ ���ݹ����ȿ� ���Դٰ� �ν���
                {
                    curState = State.Attack; // ���ݻ��·� ��ȯ
                }
            }
            private void ReturnUpdate() // ���ƿË�
            {
                // ���� �ڸ��� ���ư���
                Vector2 dir = (returnPosition - transform.position).normalized;  
                transform.Translate(dir * moveSpeed * Time.deltaTime); 

                // ���� �ڸ��� ����������
                if (Vector2.Distance(transform.position, returnPosition) < 0.02f) // ���ư������ϴ� ��ġ�� 0.02���� ������ �����ߴٰ� ����.
                    // if (transform.position == returnPosition) ���ư����� �ϴ� ��ġ�� ��Ȯ�ϰ� ������ġ��� ������ float�� �뷫���� �Ҽ����� ǥ���ϴ� ����̴� ���� ���ݸ� Ʋ������ �޶��ٰ� ������ ����Ƽ�� ������ ������� ���ư��� ���� ������ġ�� ���������� �ӵ��� �� ���� �ʴ� ��ġ�� �ִٸ� �������� ���ƿԴٰ��� �ϴٺ��� ��� �����⸸ �ϰ� �ݺ��ϴٺ��� �����ߴٰ� ���°� ����
                {
                    curState = State.Idle; // ��һ��·� ��ȯ
                }
                else if (Vector2.Distance(player.position, transform.position) < detectRange) // ���ư��� �߿��� detectRange�ȿ� �ִ°� Ȯ���� ���� ��
                {
                    curState = State.Trace; // �߰ݻ��·� ��ȯ
                }
            }
            float lastAttackTime = 0;
            private void AttackUpdate() //�����Ҷ�
            {
                // �����ϱ�
                if (lastAttackTime > 3) // lastAttackTime�� 3���� Ŭ���� ����, ���⼱ 3���̻������� ������
                {
                    Debug.Log("����");
                    lastAttackTime = 0; // 3���� Ŀ������ �ٽ� 0���� ����
                }

                lastAttackTime += Time.deltaTime;  // lastAttackTime�� Time.deltaTime��ŭ ������, 1�ʰ� ������ 1��ŭ ����

                if (Vector2.Distance(player.position, transform.position) > attackRange) // �����ϴٰ� ���ݹ����� �����, �߰ݻ��·� �ٲٱ� ���� ������ detectRange�� attackRange���� Ŀ����
                {
                    curState = State.Trace; // �߰ݻ��·� ��ȯ
                }
            }
            private void OnDrawGizmos()
            {
                Gizmos.color = Color.yellow;                            // �����
                Gizmos.DrawWireSphere(transform.position, detectRange); // ����ġ�κ��� detectRange ��ŭ ���׶��� �׷��� DrawWireSphere : ���׶��
                Gizmos.color = Color.red;                               // ������
                Gizmos.DrawWireSphere(transform.position, attackRange); // ����ġ�κ��� attackRange ��ŭ ���׶��� �׷��� DrawWireSphere : ���׶��
            }



        }























    }

