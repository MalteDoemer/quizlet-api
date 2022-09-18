namespace StudiableItemQuery
{
    public class CardSide
    {
        public int sideId { get; set; }
        public string label { get; set; }
        public List<Medium> media { get; set; }
        public List<object> distractors { get; set; }
    }

    public class Medium
    {
        public int type { get; set; }
        public string plainText { get; set; }
        public string languageCode { get; set; }
        public string ttsUrl { get; set; }
        public string ttsSlowUrl { get; set; }
        public object richText { get; set; }
    }

    public class Models
    {
        public List<StudiableItem> studiableItem { get; set; }
    }

    public class Paging
    {
        public int total { get; set; }
        public int page { get; set; }
        public int perPage { get; set; }
        public string token { get; set; }
    }

    public class Response
    {
        public Models models { get; set; }
        public Paging paging { get; set; }
    }

    public class Root
    {
        public List<Response> responses { get; set; }
    }

    public class StudiableItem
    {
        public object id { get; set; }
        public int studiableContainerType { get; set; }
        public int studiableContainerId { get; set; }
        public int type { get; set; }
        public int rank { get; set; }
        public int creatorId { get; set; }
        public int timestamp { get; set; }
        public int lastModified { get; set; }
        public bool isDeleted { get; set; }
        public List<CardSide> cardSides { get; set; } // always a size of 2
    }

}