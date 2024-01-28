
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class PlayersSO : ScriptableObject
{
    [SerializeField]
    List<string> players = new List<string>();

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
        nextPlayer = players[Random.Range(0, players.Count - 1)];
        if(lastPlayer == nextPlayer)
        {
            nextPlayer = GetNextPlayer();
        }
        return nextPlayer;
    }

    public void Limpiar()
    {
        players.Clear();
    }
}
