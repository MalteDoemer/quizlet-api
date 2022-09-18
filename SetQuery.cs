

// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);

namespace SetQuery
{

    public class Models
    {
        public List<Set> set { get; set; }
    }

    public class Response
    {
        public Models models { get; set; }
    }

    public class Root
    {
        public List<Response> responses { get; set; }
    }

    public class Set
    {
        public int id { get; set; }
        public int timestamp { get; set; }
        public int lastModified { get; set; }
        public int publishedTimestamp { get; set; }
        public int creatorId { get; set; }
        public string wordLang { get; set; }
        public string defLang { get; set; }
        public string title { get; set; }
        public bool passwordUse { get; set; }
        public bool passwordEdit { get; set; }
        public int accessType { get; set; }
        public object accessCodePrefix { get; set; }
        public string description { get; set; }
        public int numTerms { get; set; }
        public bool hasImages { get; set; }
        public int parentId { get; set; }
        public int creationSource { get; set; }
        public int privacyLockStatus { get; set; }
        public bool hasDiagrams { get; set; }
        public string _webUrl { get; set; }
        public string _thumbnailUrl { get; set; }
        public object price { get; set; }
        public int mcqCount { get; set; }
        public int purchasableType { get; set; }
    }
}