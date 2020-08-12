using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Main class
/// Here we start calling a service to load tournaments.
/// </summary>
public class ApiWithUItest : MonoBehaviour
{
    /** This is only for debugging purposes. You could see information inside Inspector **/
    [SerializeField] private Tournaments tournaments;
    /* Service for PUBG communication */
    private PubgService pubgService;

    void Start()
    {
        pubgService = new PubgService();
        StartCoroutine(pubgService.GetTournaments(SaveTournaments));
    }

    /// <summary>
    /// Method to save tournaments.
    /// This could be a method that serializes info, but for now only save it in memory
    /// </summary>
    /// <param name="_tournaments"></param>
    private void SaveTournaments(Tournaments _tournaments)
    {
        tournaments = _tournaments;
        Debug.Log("Tournaments saved.");

        // After save tournaments, call UI to show them
        UIManager.instance.ShowTournaments(tournaments);
    }
}
