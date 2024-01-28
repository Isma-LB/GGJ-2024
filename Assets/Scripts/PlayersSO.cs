
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class PlayersSO : ScriptableObject
{
    [SerializeField]
    public List<string> players = new List<string>();

    string lastPlayer;

    public bool InsertarElemento(string newPlayer)
    {
        bool correcto = false;
        if (!players.Contains(newPlayer))
        {
            players.Add(newPlayer);
            correcto = true;
        }
        return correcto;
    }

    public string GetNextPlayer()
    {
        string nextPlayer;
        int num = Random.Range(0, players.Count);
        nextPlayer = players[num];
        if(lastPlayer == nextPlayer)
        {
            num++;
            num = num%players.Count;
            nextPlayer = players[num];
        }
        return nextPlayer;
    }

    public void Limpiar()
    {
        players.Clear();
    }
}
