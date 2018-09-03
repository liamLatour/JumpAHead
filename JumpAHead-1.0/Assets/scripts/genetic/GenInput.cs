using UnityEngine;
using System.Collections.Generic;

public class GenInput : MonoBehaviour
{
    private GeneticAlgorithm<float> ga;
    private System.Random random;
    public int populationSize = 2;

    public Transform player;

    public GameObject ennemy;
    private GameObject[] ennemies;
    private Player[] players;

    private void Start()
    {
        ennemies = new GameObject[populationSize];
        players = new Player[populationSize];

        for (int i = 0; i < populationSize; i++)
        {
            ennemies[i] = (GameObject)Instantiate(ennemy, new Vector3(7, -4, 0), Quaternion.identity, this.transform);
            ennemies[i].name = i.ToString();
            players[i] = ennemies[i].GetComponent<Player>();
        }

        random = new System.Random();
        ga = new GeneticAlgorithm<float>(populationSize, 32, random, GetRandomWeight, FitnessFunction);

        //ga.NewGeneration();
    }

    private float GetRandomWeight()
    {
        return Random.Range(-1.0f, 1.0f);
    }

    private float FitnessFunction(int index)
    {
        return ennemies[index].GetComponentInChildren<WINNING>().score;
    }

    private void Update()
    {
        //ga.NewGeneration();

        //Create new generation if the current best Ennemy died

        for (int i = 0; i < populationSize; i++)
        {
            float Xleft = ennemies[i].transform.position.x - player.position.x;
            float Xright = 0;

            if (Xleft < 0)
            {
                Xright = -Xleft;
                Xleft = 0;
            }

            float Ytop = ennemies[i].transform.position.y - player.position.y;
            float Ybottom = 0;

            if (Ytop < 0)
            {
                Ybottom = -Ytop;
                Ytop = 0;
            }

            float[] weights = ga.Population[i].Genes;

            float[] move = Proccess(weights, new float[] { Xright, Xleft, Ytop, Ybottom });

            Vector2 directionalInput = new Vector2(move[0], move[1]);
            players[i].SetDirectionalInput(directionalInput);

            if (move[2] > 0.5f)
            {
                players[i].OnJumpInputDown();
            }

            if (move[3] > 0.5f)
            {
                players[i].OnJumpInputUp();
            }
        }
    }

    private float[] Proccess(float[] weights, float[] inputs)
    {
        float IXleft = 1 / inputs[0];
        float IXright = 1 / inputs[1];
        float IYtop = 1 / inputs[2];
        float IYbottom = 1 / inputs[3];

        float Xleft = inputs[0] / 16.3f;
        float Xright = inputs[1] / 16.3f;
        float Ytop = inputs[2] / 8.3f;
        float Ybottom = inputs[3] / 8.3f;

        float X = IXleft * weights[0] + IXright * weights[1] + IYtop * weights[2] + IYbottom * weights[3] + Xleft * weights[4] + Xright * weights[5] + Ytop * weights[6] + Ybottom * weights[7];
        float Through = IXleft * weights[8] + IXright * weights[9] + IYtop * weights[10] + IYbottom * weights[11] + Xleft * weights[12] + Xright * weights[13] + Ytop * weights[14] + Ybottom * weights[15];
        float Jump = IXleft * weights[16] + IXright * weights[17] + IYtop * weights[18] + IYbottom * weights[19] + Xleft * weights[20] + Xright * weights[21] + Ytop * weights[22] + Ybottom * weights[23];
        float ExitJump = IXleft * weights[24] + IXright * weights[25] + IYtop * weights[26] + IYbottom * weights[27] + Xleft * weights[28] + Xright * weights[29] + Ytop * weights[30] + Ybottom * weights[31];

        float[] output = { X, Through, Jump, ExitJump };
        return output;
    }
}