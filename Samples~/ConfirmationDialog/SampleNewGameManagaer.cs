using KSIShareable.UI.Dialog;
using UnityEngine;

namespace KSIShareable.Samples
{
    internal class SampleNewGameManagaer : MonoBehaviour
    {
        [SerializeField] BasicConfirmationDialog dialogPrefab;

        public void CreateDialog() {
            string questionText = "Starting a new game will delete your previous data.\n\nAre you sure you want to start a new game?";
            string yesBtnText = "New Game";
            string noBtnText = "Cancel";

            var dialog = Instantiate(dialogPrefab);
            dialog.Init(questionText, yesBtnText, noBtnText, AgreeNewGame, null);
            dialog.SetWidth(700f);
            dialog.SetSortOder(10);

            //Another Style:
            //var dialog = Instantiate(dialogPrefab)
            //    .Init(questionText, yesBtnText, noBtnText, AgreeNewGame, null)
            //    .SetWidth(700f)
            //    .SetSortOder(10);

        }

        public void AgreeNewGame() {
            Debug.Log("Deleted previous data. Create a new game.");
        }
    }
}