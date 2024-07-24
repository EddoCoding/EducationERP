using Raketa.Commands;

namespace EducationERP.Modules.Components.Notification.VM
{
    public class NoteViewModel
    {
        public string TextNote { get; set; } = string.Empty;

        public RaketaCommand ExitCommand { get; }

        public NoteViewModel(string textNote, Action exitWindow)
        {
            TextNote = textNote;
            ExitCommand = RaketaCommand.Launch(exitWindow);
        }
    }
}