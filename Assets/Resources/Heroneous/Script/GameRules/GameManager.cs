using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class GameManager {

  private static GameManager instance = null;

  public static GameManager Instance{
    get{ 
      if (instance == null) {
        instance = new GameManager ();
        instance.init ();
      }
      return instance;
    }
  }

  private Dictionary<string, bool> players;
  private int winner;
  private string gameState;

  private void init(){
    winner = 0;
    players = new Dictionary<string, bool>();
    players.Add ("player_1", false);
    players.Add ("player_2", false);
    players.Add ("player_3", false);
    players.Add ("player_4", false);
  }

  public void addPlayer(int _padId)
  {
    string playerId = "player_" + _padId;
    players[playerId] = true;
  }

  public void removePlayer(int _padId)
  {
    string playerId = "player_" + _padId;
    if (players.ContainsKey (playerId)) {
      players[playerId] = false;
    }
  }

  public int getPlayerCount()
  {
    return players.Count;
  }

  public void setState(string _state)
  {
    gameState = _state;
  }

  public bool isPlayerIn(int _nb)
  {
    bool res = false;
    if(players.ContainsKey("player_" + _nb))
    {
      res = players["player_"+_nb];
    }
    return res;
  }

  public void setWinner(int _winner)
  {
    winner = _winner;
  }

  public int getWinner()
  {
    return winner;
  }

}
