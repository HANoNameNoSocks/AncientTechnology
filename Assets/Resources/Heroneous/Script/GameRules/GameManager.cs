using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class GameManager {

  private GameManager instance;

  public GameManager Instance{
    get{ 
      if (Instance == null) {
        instance = new GameManager ();
      }
      return instance;
    }
  }

  private Dictionary<string, bool> players;
  private string gameState;

  private void init(){
    gameState = "mainMenu";
    players.Add ("player_1", false);
    players.Add ("player_2", false);
    players.Add ("player_3", false);
    players.Add ("player_4", false);
  }

  private void addPlayer(int _padId)
  {
    string playerId = "player_" + _padId;
    players[playerId] = true;
  }

  private void removePlayer(int _padId)
  {
    string playerId = "player_" + _padId;
    players[playerId] = false;
  }

  public int getPlayerCount()
  {
    return players.Count;
  }

  public string getState()
  {
    return gameState;
  }

  public void setState(string _state)
  {
    gameState = _state;
  }

}
