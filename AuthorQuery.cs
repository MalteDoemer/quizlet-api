namespace AuthorQuery
{
    public class Models
    {
        public List<User> user { get; set; }
    }

    public class Response
    {
        public Models models { get; set; }
    }

    public class Root
    {
        public List<Response> responses { get; set; }
    }

    public class User
    {
        public int id { get; set; }
        public string username { get; set; }
        public int timestamp { get; set; }
        public int lastModified { get; set; }
        public int type { get; set; }
        public bool isLocked { get; set; }
        public string _imageUrl { get; set; }
        public string timeZone { get; set; }
        public int _numClassMemberships { get; set; }
    }
}