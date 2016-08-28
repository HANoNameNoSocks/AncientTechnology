using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class ObjectTypesManager
{
  private static ObjectTypesManager instance = null;

  public static ObjectTypesManager Instance
  {
    get
    {
      if(instance == null)
      {
        instance = new ObjectTypesManager();
        instance.initDictionary ();
      }

      return instance;
    }
  }

  Dictionary <string, string> objectTypes = new Dictionary<string, string>();

  private void initDictionary()
  {
    objectTypes.Add("screw_A", "");
    objectTypes.Add("screw_B", "");
    objectTypes.Add("gear_A", "");
    objectTypes.Add("gear_B", "");
    objectTypes.Add("hammer_A", "");
    objectTypes.Add("hammer_B", "");
    objectTypes.Add("pipe_A", "");
    objectTypes.Add("pipe_B", "");
  }

  public string getImagePath(string itemId)
  {
    string res = "";
    res = objectTypes [itemId];
    return res;
  }

  public string getRandomItem()
  {
    string res = "";
    int cpt = 0;
    int itemNb = (int)Math.Floor(UnityEngine.Random.value * objectTypes.Count);

    foreach(KeyValuePair<string, string> type in objectTypes)
    {
      if (cpt == itemNb) {
        res = type.Key;
      } else 
      {
        cpt++;
      }
    }

    return res;
  }

}