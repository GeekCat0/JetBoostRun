using UnityEngine;
using TMPro;
using Dan.Main;

namespace LeaderboardCreatorDemo
{ 
public class Board : MonoBehaviour
{
    [SerializeField] private TMP_Text[] _entryTextObjects;
    [SerializeField] private TMP_InputField Name;

    // Make changes to this section according to how you're storing the player's score:
    // ------------------------------------------------------------
    [SerializeField] private GameManager gameManager;

    private int Score => gameManager.highscore;

        // ------------------------------------------------------------

        private void Start()
    {
            LoadEntries();
            
    }

    private void LoadEntries()
    {
        // Q: How do I reference my own leaderboard?
        // A: Leaderboards.<NameOfTheLeaderboard>

        Leaderboards.JetBoostRunLeaderboard.GetEntries(entries =>
        {
            foreach (var t in _entryTextObjects)
                t.text = "";

            var length = Mathf.Min(_entryTextObjects.Length, entries.Length);
            for (int i = 0; i < length; i++)
                _entryTextObjects[i].text = $"{entries[i].Rank}. {entries[i].Username} - {entries[i].Score}";
        });
    }

    public void UploadEntry(string username)
    {
            Leaderboards.JetBoostRunLeaderboard.UploadNewEntry(username, Score, isSuccessful =>
        {
            if (isSuccessful) 
            LoadEntries();

        });
    }
}
}
