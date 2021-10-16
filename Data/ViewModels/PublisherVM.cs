﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace my_book.Data.ViewModels
{
    public class PublisherVM
    {
        public string Name { get; set; }

    }

    public class PublisherWithBooksAndAuthorsVM
    {
        public string Name { get; set; }
        public List<PublisherBookAuthorVM> BookAuthors { get; set; }
    }

    public class PublisherBookAuthorVM
    {
        public string BookName { get; set; }

        public List<string> BookAuthors { get; set; }

    }
}
