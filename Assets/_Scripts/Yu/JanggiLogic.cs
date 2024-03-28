using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JanggiLogic : MonoBehaviour
{
    // ������� ���� 9, ���� 10 �� ũ��
    // ������� 2���� �迭�� ����ٸ� 9x10�� �迭�� �����ؾ���

    Spot[,] spots = new Spot[10, 9] 
    {
        { null, null, null, null, null, null, null, null, null},
        { null, null, null, null, null, null, null, null, null},
        { null, null, null, null, null, null, null, null, null},
        { null, null, null, null, null, null, null, null, null},
        { null, null, null, null, null, null, null, null, null},
        { null, null, null, null, null, null, null, null, null},
        { null, null, null, null, null, null, null, null, null},
        { null, null, null, null, null, null, null, null, null},
        { null, null, null, null, null, null, null, null, null},
        { null, null, null, null, null, null, null, null, null}
    };

    

    private void Start()
    {
        for (int z = 0; z < 10; z++)
        {
            for(int x = 0; x < 9; x++)
            {
                if (GetComponentInChildren<Spot>() == null)
                {
                    Debug.Log($"Null ({x}, {z})");
                    break;
                }

                spots[z, x] = GetComponentInChildren<Spot>();
            }
        }

        bool cheak = true;

        foreach (Spot spot in spots)
        {
            if (spot == null)
            {
                Debug.Log("null is exist");
                Debug.Log(spot.name);
                cheak = false;
                break;
            }
        }

        if (cheak)
        {
            Debug.Log("Ok");
        }
    }

    void MaLogic()
    {
        // �� ĭ�� �� �� �ִ��� Ȯ���Ѵ�
            // �� �� ���ٸ� �������� �Ѿ��
            // �� �� �ִٸ�
                // �밢���� Ȯ���Ѵ�
                    // �Ʊ� �⹰�̸� �������� �Ѿ��
                    // �� ĭ�̰ų� ��� �⹰�̸� �̵� ���� ǥ�ø� ���ش�


        // ������ ĭ�� �� �� �ִ��� Ȯ���Ѵ�
            // �� �� ���ٸ� �������� �Ѿ��
            // �� �� �ִٸ�
                // �밢���� Ȯ���Ѵ�
                    // �Ʊ� �⹰�̸� �������� �Ѿ��
                    // �� ĭ�̰ų� ��� �⹰�̸� �̵� ���� ǥ�ø� ���ش�

        // �� ĭ�� �� �� �ִ��� Ȯ���Ѵ�
            // �� �� ���ٸ� �������� �Ѿ��
            // �� �� �ִٸ�
                // �밢���� Ȯ���Ѵ�
                    // �Ʊ� �⹰�̸� �������� �Ѿ��
                    // �� ĭ�̰ų� ��� �⹰�̸� �̵� ���� ǥ�ø� ���ش�

        // ���� ĭ�� �� �� �ִ��� Ȯ���Ѵ�
            // �� �� ���ٸ� �������� �Ѿ��
            // �� �� �ִٸ�
                // �밢���� Ȯ���Ѵ�
                    // �Ʊ� �⹰�̸� �������� �Ѿ��
                    // �� ĭ�̰ų� ��� �⹰�̸� �̵� ���� ǥ�ø� ���ش�
    }
}