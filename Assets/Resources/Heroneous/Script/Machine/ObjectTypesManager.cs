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
  Dictionary <string, string> objectSchematics = new Dictionary<string, string>();

  private void initDictionary()
  {
    objectTypes.Add("screw_A", "Heroneous/Sprites/MachineElements/screw_a");
    objectTypes.Add("screw_B", "Heroneous/Sprites/MachineElements/screw_b");
    objectTypes.Add("gear_A", "Heroneous/Sprites/MachineElements/gear_a");
    objectTypes.Add("gear_B", "Heroneous/Sprites/MachineElements/gear_b");
    objectTypes.Add("hammer_A", "Heroneous/Sprites/MachineElements/hammer_a");
    objectTypes.Add("hammer_B", "Heroneous/Sprites/MachineElements/hammer_b");
    objectTypes.Add("pipe_A", "Heroneous/Sprites/MachineElements/pipe_a");
    objectTypes.Add("pipe_B", "Heroneous/Sprites/MachineElements/pipe_b");

    objectSchematics.Add("screw_A", "Heroneous/Sprites/MachineElements/CROQUIS_helice1");
    objectSchematics.Add("screw_B", "Heroneous/Sprites/MachineElements/CROQUIS_helice2");
    objectSchematics.Add("gear_A", "Heroneous/Sprites/MachineElements/CROQUIS_rouage1");
    objectSchematics.Add("gear_B", "Heroneous/Sprites/MachineElements/CROQUIS_rouage2");
    objectSchematics.Add("hammer_A", "Heroneous/Sprites/MachineElements/CROQUIS_marteau1");
    objectSchematics.Add("hammer_B", "Heroneous/Sprites/MachineElements/CROQUIS_marteau2");
    objectSchematics.Add("pipe_A", "Heroneous/Sprites/MachineElements/CROQUIS_tuyau1");
    objectSchematics.Add("pipe_B", "Heroneous/Sprites/MachineElements/CROQUIS_tuyau2");
  }

  public string getImagePath(string itemId)
  {
    string res = "";
    res = objectTypes [itemId];
    return res;
  }

  public string getSchematicsImagePath(string itemId)
  {
    string res = "";
    res = objectSchematics [itemId];
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
      }
      cpt++;
      
    }

    return res;
  }

  public string getRandomItemScematics()
  {
    string res = "";
    int cpt = 0;
    int itemNb = (int)Math.Floor(UnityEngine.Random.value * objectSchematics.Count);
    foreach(KeyValuePair<string, string> type in objectSchematics)
    {
      if (cpt == itemNb) {
        res = type.Key;
      }
      cpt++;

    }

    return res;
  }

}