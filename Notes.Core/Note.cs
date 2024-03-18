namespace Notes.Core
{
    public class Note
    {
        public Note(int NoteId, int NoteChatId, string NoteText)
        {
            Id = NoteId;
            ChatId = NoteChatId;
            Text = NoteText;
            CreateDate = DateTime.Now;
        }

        private string _Text = "";

        public readonly int Id;

        public readonly int ChatId;
        public string Text { get { return _Text; } set { _Text = value; } }

        public readonly DateTime CreateDate;
        public override string ToString() => $"{Id.ToString()}\n{ChatId.ToString()}\n{Text}\n{CreateDate.ToString()}";
    }

}
