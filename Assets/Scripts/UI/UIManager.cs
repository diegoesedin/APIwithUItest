using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Singleton for UI management.
/// </summary>
public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    /** Prefab that will be showed for each tournament **/
    [SerializeField] private GameObject tournamentRowPrefab;
    /** Content where tournament's list will be showed **/
    [SerializeField] private GameObject content;

    /** Screen showed while tournaments are loading **/
    [SerializeField] private GameObject loadingScreen;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    void Start()
    {
        // Show loading screen at start
        loadingScreen.SetActive(true);
    }

    /// <summary>
    /// Method for rows instantiation 
    /// </summary>
    /// <param name="tournaments">Model with tournaments list inside .data</param>
    public void ShowTournaments(Tournaments tournaments)
    {
        StartCoroutine(LoadRows(tournaments));
    }

    private IEnumerator LoadRows(Tournaments tournaments)
    {
        foreach (Tournament tournament in tournaments.data)
        {
            // Create rows for each tournament
            GameObject row = Instantiate(tournamentRowPrefab, content.transform);
            row.gameObject.GetComponent<TournamentRow>().Initialize(tournament);
            yield return null;
        }

        //After all row creation, hide loading screen.
        loadingScreen.SetActive(false);
    }
}
