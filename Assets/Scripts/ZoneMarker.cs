using NUnit.Framework;
using UnityEditor;
using UnityEngine;
using System.Collections.Generic;

public class ZoneMarker : MonoBehaviour
{
    public PopulationPool pool;
    //public int spawnPointMax;
    public Transform[] spawnPoints;
    [UnityEngine.Range(0.8f, 1f)] public float camouflageTightness;
    public StoryFragment fragment;

    [HideInInspector] public List<GameObject> spawnedInstances = new();
    //[HideInInspector] 
    public bool resolved;

    public void OnTargetFound()
    {
        if (resolved) return;
        resolved = true;
        FragmentManager.Instance.Unlock(fragment);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
}

[CustomEditor(typeof(ZoneMarker))]
public class ZoneMarkerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        
        ZoneMarker zone = (ZoneMarker)target;
        if (GUILayout.Button("Populate"))
        {
            SpawnObjects(zone);
        }
        if (GUILayout.Button("Clear"))
        {
            ClearObjects(zone);
        }
    }
    private void SpawnObjects(ZoneMarker zone)
    {
        ClearObjects(zone);
        int targetIndex = Random.Range(0, zone.spawnPoints.Length);
        
        for (int i = 0; i < zone.spawnPoints.Length; i++)
        {
            GameObject prefab = (i == targetIndex) 
                ? zone.pool.targetPrefab : GetWeightedDecoy(zone.pool);
            GameObject instance = (GameObject)PrefabUtility.InstantiatePrefab(prefab, zone.transform);
            TargetTell tell = instance.GetComponent<TargetTell>();
            tell?.ApplyTightness(zone.camouflageTightness);
            instance.transform.position = zone.spawnPoints[i].position;
            instance.transform.rotation = zone.spawnPoints[i].rotation;


            Interactable interactable = instance.GetComponent<Interactable>();
            if (interactable != null)
            {
                interactable.isTarget = (i == targetIndex);
                interactable.ownerZone = zone;
            }

            zone.spawnedInstances.Add(instance);
        }
    }
    private void ClearObjects(ZoneMarker zone)
    {
        foreach (var instance in zone.spawnedInstances)
            if (instance != null) DestroyImmediate(instance);
        zone.spawnedInstances.Clear();
    }

    GameObject GetWeightedDecoy(PopulationPool pool) {
        float totalWeight = 0f;
        foreach (var decoy in pool.decoyPrefabs)
            totalWeight += decoy.weight;
        float randomValue = Random.Range(0f, totalWeight);
        float cumulativeWeight = 0f;
        foreach (var decoy in pool.decoyPrefabs)
        {
            cumulativeWeight += decoy.weight;
            if (randomValue <= cumulativeWeight)
                return decoy.prefab;
        }
        return null; // Fallback in case of rounding errors
    }

}
