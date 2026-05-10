using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

[Serializable]
public class ImagePrefabEntry
{
    public string imageName;
    public GameObject prefab;
}

public class ARImageTracker : MonoBehaviour
{
    [SerializeField] private ARTrackedImageManager imageManager;
    [SerializeField] private List<ImagePrefabEntry> imagePrefabs = new List<ImagePrefabEntry>();

    private Dictionary<string, GameObject> prefabLookup = new Dictionary<string, GameObject>();

    private void Awake()
    {
        if (imageManager == null)
        {
            imageManager = FindFirstObjectByType<ARTrackedImageManager>();
        }

        foreach (var entry in imagePrefabs)
        {
            if (entry != null && entry.prefab != null && !string.IsNullOrEmpty(entry.imageName))
            {
                if (!prefabLookup.ContainsKey(entry.imageName))
                {
                    prefabLookup.Add(entry.imageName, entry.prefab);
                }
            }
        }
    }

    private void OnEnable()
    {
        if (imageManager != null)
        {
            imageManager.trackablesChanged.AddListener(OnTrackedImagesChanged);
        }
    }

    private void OnDisable()
    {
        if (imageManager != null)
        {
            imageManager.trackablesChanged.RemoveListener(OnTrackedImagesChanged);
        }
    }

    private void OnTrackedImagesChanged(ARTrackablesChangedEventArgs<ARTrackedImage> eventArgs)
    {
        foreach (var trackedImage in eventArgs.added)
        {
            SpawnPrefab(trackedImage);
        }

        foreach (var trackedImage in eventArgs.updated)
        {
            bool isTracking = trackedImage.trackingState == TrackingState.Tracking;

            if (trackedImage.transform.childCount > 0)
            {
                GameObject content = trackedImage.transform.GetChild(0).gameObject;
                content.SetActive(isTracking);

                content.transform.position = trackedImage.transform.position;
                content.transform.rotation = trackedImage.transform.rotation;
            }
        }

        foreach (var pair in eventArgs.removed)
        {
            Debug.Log("Image removed: " + pair.Value.referenceImage.name);
        }
    }

    private void SpawnPrefab(ARTrackedImage trackedImage)
    {
        string imageName = trackedImage.referenceImage.name;

        if (prefabLookup.TryGetValue(imageName, out GameObject prefab))
        {
            GameObject spawnedContent = Instantiate(
                prefab,
                trackedImage.transform.position,
                trackedImage.transform.rotation
            );

            spawnedContent.transform.SetParent(trackedImage.transform);
        }
    }
}