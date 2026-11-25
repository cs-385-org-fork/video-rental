using SQLitePCL;
using System;
using System.Collections.Generic;
using System.Text;

namespace video_rental
{
    internal class BoxSet : InventoryItem
    {
        public string title;
        public char rating;
        public int releaseYear;
        public string format;
        public string seasons; //String so you can input as 1, 1-4, 2-3, etc. No math is done with it anyways
        public int episodesCount;
        public int episodeLength;
        public int discsIncluded;
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
        public string Seasons
        {
            get { return seasons; }
            set { seasons = value; }
        }
        public int EpisodesCount
        {
            get { return episodesCount; }
            set { episodesCount = value; }
        }
        public int EpisodeLength
        {
            get { return episodeLength; }
            set { episodeLength = value; }
        }
        public int DiscsIncluded
        {
            get { return discsIncluded; }
            set { discsIncluded = value; }
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
            get { return MediaType.BoxSet; }
        }
    }
}
