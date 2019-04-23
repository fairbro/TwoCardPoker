
using Common.Interfaces;
using System.Collections.Generic;

namespace UserInterface
{
    public interface IUI
    {
        void ShowIntro();

        void ShowMessage(string message);

        ushort GetNumericInput(string message, ushort min, ushort max);

        void ShowRoundResults(IEnumerable<IPlayerRoundResult> roundResults, int roundNumber);
        void ShowFinalResults(IEnumerable<IPlayerFinalScore> playerResults);
    }
}
