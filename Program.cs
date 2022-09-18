using System.Text.Json;

class FlashCard
{
    public FlashCard(string term, string definition)
    {
        Term = term;
        Definition = definition;
    }

    public string Term { get; set; }
    public string Definition { get; set; }
}

class LearnsetMetadata
{
    public LearnsetMetadata(string title, string author, int cardCount)
    {
        Title = title;
        Author = author;
        this.cardCount = cardCount;
    }

    public string Title { get; set; }
    public string Author { get; set; }
    public int cardCount { get; set; }
}

class Learnset
{
    public Learnset(LearnsetMetadata metadata, List<FlashCard> cards)
    {
        this.metadata = metadata;
        this.cards = cards;
    }

    public LearnsetMetadata metadata { get; set; }
    public List<FlashCard> cards { get; set; }
}


class Program
{

    private static async Task<Learnset> FetchLearnset(string id)
    {
        var client = new HttpClient();

        client.DefaultRequestHeaders.UserAgent.Clear();
        client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0");


        var setResponse = client.GetStreamAsync($"https://quizlet.com/webapi/3.9/sets/{id}");
        var setRoot = await JsonSerializer.DeserializeAsync<SetQuery.Root>(await setResponse);

        var cardCount = setRoot.responses[0].models.set[0].numTerms;
        var title = setRoot.responses[0].models.set[0].title;
        var authorId = setRoot.responses[0].models.set[0].creatorId;

        var authorResponse = client.GetStreamAsync($"https://quizlet.com/webapi/3.9/users/{authorId}");
        var studiableItemResponse = client.GetStreamAsync($"https://quizlet.com/webapi/3.4/studiable-item-documents?filters%5BstudiableContainerId%5D={id}&filters%5BstudiableContainerType%5D=1&perPage={cardCount}&page=1");

        var authorRoot = await JsonSerializer.DeserializeAsync<AuthorQuery.Root>(await authorResponse);

        var authroName = authorRoot.responses[0].models.user[0].username;
        var metadata = new LearnsetMetadata(title, authroName, cardCount);

        var studiableItemRoot = await JsonSerializer.DeserializeAsync<StudiableItemQuery.Root>(await studiableItemResponse);

        var cards = new List<FlashCard>(cardCount);
        foreach (var item in studiableItemRoot.responses[0].models.studiableItem)
        {
            var front = item.cardSides[0];
            var back = item.cardSides[1];

            var term = front.media[0].plainText;
            var expr = back.media[0].plainText;

            cards.Add(new FlashCard(term, expr));
        }

        return new Learnset(metadata, cards);
    }

    public static async Task Main()
    {
        var id = "717194124";

        var learnset = await FetchLearnset(id);

        System.Console.WriteLine($"{learnset.metadata.Title} by {learnset.metadata.Author}");

        foreach (var card in learnset.cards) {
            System.Console.WriteLine($"{card.Term} ---- {card.Definition}");
        }
    }

}