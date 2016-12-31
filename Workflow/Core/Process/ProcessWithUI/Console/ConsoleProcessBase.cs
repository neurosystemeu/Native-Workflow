using NeuroSystem.VirtualMachine.Core.Attributes;
using NeuroSystem.Workflow.UserData.UI.Consola;

namespace NeuroSystem.Workflow.Core.Process.ProcessWithUI.Console
{
    /// <summary>
    /// Proces obsługujący konsolę.
    /// Można wykonać w nim WriteLine i ReadLine, które wyśweitlają i pobierają dane z konsoli
    /// Host musi obsługiwać takie dane
    /// </summary>
    public class ConsoleProcessBase : ProcessBase
    {
        /// <summary>
        /// Odpowiedzialny za wyświetlenie tekstu na konsole,
        /// jeśli host obsługuję tryb konsoli
        /// </summary>
        /// <param name="text"></param>
        [Interpret]
        public void WriteLine(string text)
        {
            var consoleWrite = new ConsoleWrite() { Text = text, NewLine = true};
            UserDataOutput = consoleWrite;
            Status = EnumProcessStatus.WaitingForUserData;
            Hibernate();
        }

        [Interpret]
        public void Write(string text)
        {
            var consoleWrite = new ConsoleWrite() { Text = text, NewLine = false };
            UserDataOutput = consoleWrite;
            Status = EnumProcessStatus.WaitingForUserData;
            Hibernate();
        }


        /// <summary>
        /// Odpowiedzialny za pobranie danych jeśli host obsługuję tryb konsoli
        /// </summary>
        /// <returns>Dane wpisane przez użytkownika</returns>
        [Interpret]
        public string ReadLine()
        {
            var consoleRead = new ConsoleRead();
            UserDataOutput = consoleRead;
            Status = EnumProcessStatus.WaitingForUserData;
            Hibernate();

            return UserDataInput?.ToString();
        }
    }
}
