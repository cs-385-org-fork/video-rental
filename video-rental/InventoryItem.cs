using System;
using System.Collections.Generic;
using System.Text;

namespace video_rental {
    enum MediaType
    {
        Movie,
        BoxSet,
        VideoGame,
    }
    abstract class InventoryItem {
		/*
		 Options for movies, tv shows, and video games

		TV Series
			Season (int)
			Episodes (int)
			Episode Length (double)
			Year (int)
			MPA Rating (Char, E, T, M)
			Format (DVD, Blu-Ray) (String)
			Discs Included (Int)
			Available Copies (Int)
			Total Copies (int)

		Video Games
			ESRB Rating (Char, E, T, M)
			Year (Int)
			Platform (String)
			Multiplayer Information (String)
			Available Copies (Int)
			Total Copies (int)

		Movies
			Length (Double)
			Year (Int)
			MPA Rating (Char, E, T, M)
			Format (DVD, Blu-Ray) (String)
			Available Copies (Int)
			Total Copies (int)

		For database:
		Date checked out

		In common
			ID
			Title
			Year
			Rating?
			Format/Platform?
			AvailableCopies
			TotalCopies

		 */
        private int id = -1;
		private string title = "";
        
		public int ID { get; set; }
		public string Title { get; set; }
		public int Year { get; set; }
		public int AvailableCopies { get; set; }
		public int TotalCopies { get; set; }
		public MediaType Type { get; }


    }
}
