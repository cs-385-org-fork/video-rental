using System;
using System.Collections.Generic;
using System.Text;

namespace video_rental {
    internal class Movie : InventoryItem
    {
        public string title;
        public char rating;
        public int releaseYear;
        public string format;
        public int availableCopies;
        public int totalCopies;

        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        public char Rating
        {
            get { return rating; }
            set { rating = value; }
        }

        public int ReleaseYear
        {
            get { return releaseYear; }
            set { releaseYear = value; }
        }

        public string Format
        {
            get { return format; }
            set { format = value; }
        }

        public int AvailableCopies
        {
            get { return availableCopies; }
            set { availableCopies = value; }
        }

        public int TotalCopies
        {
            get { return totalCopies; }
            set { totalCopies = value; }
        }

        public MediaType Type
        {
            get { return MediaType.Movie; }
        }

    }
}
