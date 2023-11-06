// See https://aka.ms/new-console-template for more information

  
        Book book = new Book("C# Programming for Beginners");
        BookConsumer consumer = new BookConsumer();

        consumer.Subscribe(book);

        // Simulate book events
        book.Publish();
        book.Purchase();

        consumer.Unsubscribe(book);

        // No more event handling after unsubscribing
        book.Publish();
        book.Purchase();
    
