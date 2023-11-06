using System;

class Book
{
    public event EventHandler<string> BookPublished;
    public event EventHandler<string> BookPurchased;

    private string? title;

    public Book(string? title)
    {
        this.title = title;
    }

    public void Publish()
    {
        Console.WriteLine($"The book '{title}' has been published.");
        OnBookPublished($"The book '{title}' has been published.");
    }

    public void Purchase()
    {
        Console.WriteLine($"Someone purchased the book '{title}'.");
        OnBookPurchased($"Someone purchased the book '{title}'.");
    }

    protected virtual void OnBookPublished(string message)
    {
        BookPublished?.Invoke(this, message);
    }

    protected virtual void OnBookPurchased(string message)
    {
        BookPurchased?.Invoke(this, message);
    }
}

class BookConsumer
{
    public void Subscribe(Book book)
    {
        book.BookPublished += HandleBookPublishedEvent;
        book.BookPurchased += HandleBookPurchasedEvent;
    }

    public void Unsubscribe(Book book)
    {
        book.BookPublished -= HandleBookPublishedEvent;
        book.BookPurchased -= HandleBookPurchasedEvent;
    }

    private void HandleBookPublishedEvent(object sender, string message)
    {
        Console.WriteLine($"Consumer received the following event: {message}");
    }

    private void HandleBookPurchasedEvent(object sender, string message)
    {
        Console.WriteLine($"Consumer received the following event: {message}");
    }
}

