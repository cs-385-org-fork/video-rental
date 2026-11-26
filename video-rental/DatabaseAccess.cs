using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Data.Sqlite;

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

 */

namespace video_rental {
    internal class DatabaseAccess {
        private const string ConnectionString = "Data Source=StoreDB.db";


        public DatabaseAccess() {
            InitializeDatabase();
        }
        public void InitializeDatabase() {
            try {
                using (var connection = new SqliteConnection(ConnectionString)) {
                    connection.Open();

                    var command = connection.CreateCommand();
                    command.CommandText = (" CREATE TABLE IF NOT EXISTS Inventory( ID INTEGER PRIMARY KEY AUTOINCREMENT, MediaType INTEGER NOT NULL, MediaID INTEGER NOT NULL, Title TEXT NOT NULL ); "); // MediaType: 0 = Movie, 1 = BoxSet, 2 = VideoGame. MediaID is the ID for the item in the Movies/BoxSets/VideoGames table
                    command.ExecuteNonQuery();

                    command.CommandText = (" CREATE TABLE IF NOT EXISTS Movies( ID INTEGER PRIMARY KEY AUTOINCREMENT, FOREIGN KEY (ItemID) REFERENCES Inventory(ID), Title TEXT NOT NULL, Length DOUBLE, Year INTEGER, MPARating CHAR, Format TEXT, AvailableCopies INTEGER NOT NULL, TotalCopies INTEGER NOT NULL ); ");
                    command.ExecuteNonQuery();

                    command.CommandText = (" CREATE TABLE IF NOT EXISTS BoxSets( ID INTEGER PRIMARY KEY AUTOINCREMENT, FOREIGN KEY (ItemID) REFERENCES Inventory(ID), Title TEXT NOT NULL, Seasons TEXT, Year INTEGER, MPARating CHAR, Format TEXT, DiscsIncluded INTEGER NOT NULL, AvailableCopies INTEGER NOT NULL, TotalCopies INTEGER NOT NULL ); ");
                    command.ExecuteNonQuery();

                    command.CommandText = (" CREATE TABLE IF NOT EXISTS VideoGames( ID INTEGER PRIMARY KEY AUTOINCREMENT, FOREIGN KEY (ItemID) REFERENCES Inventory(ID), Title TEXT NOT NULL, Year Integer, ESRBRating CHAR, Platform TEXT, MultiplayerInfo TEXT, AvailableCopies INTEGER NOT NULL, TotalCopies INTEGER NOT NULL ); ");
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex) {
                // THIS IS BAD, DO NOT DO THIS:
                MessageBox.Show("Error initializing database.\t" + ex.Message);
            }
        }


        public void AddMovie(Movie mov) {
            try {
                using (var connection = new SqliteConnection(ConnectionString)) {
                    connection.Open();

                    // create Inventory item
                    var command = connection.CreateCommand();
                    command.CommandText = @" INSERT INTO Inventory(MediaType, MediaID, Title) 
                                                                VALUES(@mediaType, @mediaID, @title); ";
                    command.Parameters.AddWithValue("@mediaType", 0); // 0 means Movie
                    command.Parameters.AddWithValue("@mediaID", -1); // temporary, will be updated once added to Movies table
                    command.Parameters.AddWithValue("@title", mov.Title);
                    command.ExecuteNonQuery();
                    
                    // get ID of Inventory item
                    int itemID = -1;
                    command = connection.CreateCommand();
                    command.CommandText = (" SELECT * FROM Inventory ORDER BY ID DESC LIMIT 1; "); // select the most recent entry
                    using (var reader = command.ExecuteReader()) {
                        while (reader.Read()) {
                            itemID = reader.GetInt32(0); /* ID */
                        }
                    }

                    // create Movies item
                    command.CommandText = @" INSERT INTO Movies(ItemID, Title, Length, Year, MPARating, Format, AvailableCopies, TotalCopies) 
                                                                VALUES(@itemID, @title, @length, @year, @rating, @format, @availCopies, @totalCopies); ";
                    command.Parameters.AddWithValue("@itemID", itemID);
                    command.Parameters.AddWithValue("@title", mov.Title);
                    command.Parameters.AddWithValue("@length", mov.Length);
                    command.Parameters.AddWithValue("@year", mov.ReleaseYear);
                    command.Parameters.AddWithValue("@rating", mov.Rating);
                    command.Parameters.AddWithValue("@format", mov.Format);
                    command.Parameters.AddWithValue("@availCopies", mov.AvailableCopies);
                    command.Parameters.AddWithValue("@totalCopies", mov.TotalCopies);
                    command.ExecuteNonQuery();

                    // get ID of Movies item and update in Inventory item
                    int movieID = -1;
                    command = connection.CreateCommand();
                    command.CommandText = (" SELECT * FROM Movies ORDER BY ID DESC LIMIT 1; "); // select the most recent entry
                    using (var reader = command.ExecuteReader()) {
                        while (reader.Read()) {
                            movieID = reader.GetInt32(0); /* ID */
                        }
                    }
                    command = connection.CreateCommand();
                    command.CommandText = (" UPDATE Inventory SET MediaID = " + movieID + "WHERE ID = " + itemID);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex) {
                // THIS IS BAD, DO NOT DO THIS:
                MessageBox.Show("Failed to add movie to database.\t" + ex.Message);
            }
        }
        public Movie GetMovie(int id) { // get movie from its ID on the Movies table
            Movie mov = new Movie();

            try {
                using (var connection = new SqliteConnection(ConnectionString)) {
                    connection.Open();
                    var command = connection.CreateCommand();
                    command.CommandText = (" SELECT * FROM Movies WHERE ID = " + id + "; ");
                    using (var reader = command.ExecuteReader()) {
                        while (reader.Read()) {
                            mov.ID = reader.GetInt32(0);
                            mov.Title = reader.GetString(1);
                            mov.Length = reader.GetDouble(2);
                            mov.ReleaseYear = reader.GetInt32(3);
                            mov.Rating = reader.GetChar(4);
                            mov.Format = reader.GetString(5);
                            mov.AvailableCopies = reader.GetInt32(6);
                            mov.TotalCopies = reader.GetInt32(7);
                        }
                    }
                }
            }
            catch (Exception ex) {
                MessageBox.Show("Failed to retrieve movie from database.\t" + ex.Message);
            }

            return mov;
        }
        public Movie GetMovieByItem(int itemID) { // get movie from its Inventory ID
            // get Movies ID from Inventory item
            int movieID = -1;
            try {
                using (var connection = new SqliteConnection(ConnectionString)) {
                    connection.Open();
                    var command = connection.CreateCommand();
                    command.CommandText = (" SELECT * FROM Inventory WHERE ID = " + itemID + "; ");
                    using (var reader = command.ExecuteReader()) {
                        while (reader.Read()) {
                            movieID = reader.GetInt32(2);
                        }
                    }
                }
            }
            catch (Exception ex) {
                MessageBox.Show("Failed to retrieve movie from database.\t" + ex.Message);
            }

            // call GetMovie using movieID
            return GetMovie(movieID);
        }

        public void AddBoxSet(BoxSet box) {
            try {
                using (var connection = new SqliteConnection(ConnectionString)) {
                    connection.Open();

                    // create Inventory item
                    var command = connection.CreateCommand();
                    command.CommandText = @" INSERT INTO Inventory(MediaType, MediaID, Title) 
                                                                VALUES(@mediaType, @mediaID, @title); ";
                    command.Parameters.AddWithValue("@mediaType", 1); // 0 means BoxSet
                    command.Parameters.AddWithValue("@mediaID", -1); // temporary, will be updated once added to BoxSets table
                    command.Parameters.AddWithValue("@title", box.Title);
                    command.ExecuteNonQuery();

                    // get ID of Inventory item
                    int itemID = -1;
                    command = connection.CreateCommand();
                    command.CommandText = (" SELECT * FROM Inventory ORDER BY ID DESC LIMIT 1; "); // select the most recent entry
                    using (var reader = command.ExecuteReader()) {
                        while (reader.Read()) {
                            itemID = reader.GetInt32(0); /* ID */
                        }
                    }

                    // create BoxSets item
                    command.CommandText = @" INSERT INTO BoxSets(ItemID, Title, Seasons, Year, MPARating, Format, DiscsIncluded, AvailableCopies, TotalCopies) 
                                                                VALUES(@itemID, @title, @seasons, @year, @rating, @format, @discs, @availCopies, @totalCopies); ";
                    command.Parameters.AddWithValue("@itemID", itemID);
                    command.Parameters.AddWithValue("@title", box.Title);
                    command.Parameters.AddWithValue("@seasons", box.Seasons);
                    command.Parameters.AddWithValue("@year", box.ReleaseYear);
                    command.Parameters.AddWithValue("@rating", box.Rating);
                    command.Parameters.AddWithValue("@format", box.Format);
                    command.Parameters.AddWithValue("@discs", box.DiscsIncluded);
                    command.Parameters.AddWithValue("@availCopies", box.AvailableCopies);
                    command.Parameters.AddWithValue("@totalCopies", box.TotalCopies);
                    command.ExecuteNonQuery();

                    // get ID of BoxSets item and update in Inventory item
                    int boxsetID = -1;
                    command = connection.CreateCommand();
                    command.CommandText = (" SELECT * FROM Movies ORDER BY ID DESC LIMIT 1; "); // select the most recent entry
                    using (var reader = command.ExecuteReader()) {
                        while (reader.Read()) {
                            boxsetID = reader.GetInt32(0); /* ID */
                        }
                    }
                    command = connection.CreateCommand();
                    command.CommandText = (" UPDATE Inventory SET MediaID = " + boxsetID + "WHERE ID = " + itemID);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex) {
                MessageBox.Show("Failed to add box set to database.\t" + ex.Message);
            }
        }
        public BoxSet GetBoxSet(int id) { // get box set from its ID on the BoxSets table
            BoxSet box = new BoxSet();

            try {
                using (var connection = new SqliteConnection(ConnectionString)) {
                    connection.Open();
                    var command = connection.CreateCommand();
                    command.CommandText = (" SELECT * FROM BoxSets WHERE ID = " + id + "; ");
                    using (var reader = command.ExecuteReader()) {
                        while (reader.Read()) {
                            box.ID = reader.GetInt32(0);
                            box.Title = reader.GetString(1);
                            box.Seasons = reader.GetString(2);
                            box.ReleaseYear = reader.GetInt32(3);
                            box.Rating = reader.GetChar(4);
                            box.Format = reader.GetString(5);
                            box.DiscsIncluded = reader.GetInt32(6);
                            box.AvailableCopies = reader.GetInt32(7);
                            box.TotalCopies = reader.GetInt32(8);
                        }
                    }
                }
            }
            catch (Exception ex) {
                MessageBox.Show("Failed to retrieve box set from database.\t" + ex.Message);
            }

            return box;
        }
        public BoxSet GetBoxSetByItem(int itemID) { // get box set from its Inventory ID
            // get BoxSets ID from Inventory item
            int boxsetID = -1;
            try {
                using (var connection = new SqliteConnection(ConnectionString)) {
                    connection.Open();
                    var command = connection.CreateCommand();
                    command.CommandText = (" SELECT * FROM Inventory WHERE ID = " + itemID + "; ");
                    using (var reader = command.ExecuteReader()) {
                        while (reader.Read()) {
                            boxsetID = reader.GetInt32(2);
                        }
                    }
                }
            }
            catch (Exception ex) {
                MessageBox.Show("Failed to retrieve box set from database.\t" + ex.Message);
            }

            // call GetBoxSet using boxsetID
            return GetBoxSet(boxsetID);
        }

        public void AddVideoGame(VideoGame game) {
            try {
                using (var connection = new SqliteConnection(ConnectionString)) {
                    connection.Open();

                    // create Inventory item
                    var command = connection.CreateCommand();
                    command.CommandText = @" INSERT INTO Inventory(MediaType, MediaID, Title) 
                                                                VALUES(@mediaType, @mediaID, @title); ";
                    command.Parameters.AddWithValue("@mediaType", 2); // 2 means VideoGame
                    command.Parameters.AddWithValue("@mediaID", -1); // temporary, will be updated once added to Movies table
                    command.Parameters.AddWithValue("@title", game.Title);
                    command.ExecuteNonQuery();

                    // get ID of Inventory item
                    int itemID = -1;
                    command = connection.CreateCommand();
                    command.CommandText = (" SELECT * FROM Inventory ORDER BY ID DESC LIMIT 1; "); // select the most recent entry
                    using (var reader = command.ExecuteReader()) {
                        while (reader.Read()) {
                            itemID = reader.GetInt32(0); /* ID */
                        }
                    }

                    // create Movies item
                    command.CommandText = @" INSERT INTO VideoGames(ItemID, Title, Year, ESRBRating, Platform, MultiplayerInfo, AvailableCopies, TotalCopies) 
                                                                VALUES(@itemID, @title, @year, @rating, @platform, @multiplayer, @availCopies, @totalCopies); ";
                    command.Parameters.AddWithValue("@itemID", itemID);
                    command.Parameters.AddWithValue("@title", game.Title);
                    command.Parameters.AddWithValue("@year", game.ReleaseYear);
                    command.Parameters.AddWithValue("@rating", game.Rating);
                    command.Parameters.AddWithValue("@platform", game.Platform);
                    command.Parameters.AddWithValue("@multiplater", game.MultiplayerInfo);
                    command.Parameters.AddWithValue("@availCopies", game.AvailableCopies);
                    command.Parameters.AddWithValue("@totalCopies", game.TotalCopies);
                    command.ExecuteNonQuery();

                    // get ID of VideoGame item and update in Inventory item
                    int videogameID = -1;
                    command = connection.CreateCommand();
                    command.CommandText = (" SELECT * FROM VideoGames ORDER BY ID DESC LIMIT 1; "); // select the most recent entry
                    using (var reader = command.ExecuteReader()) {
                        while (reader.Read()) {
                            videogameID = reader.GetInt32(0); /* ID */
                        }
                    }
                    command = connection.CreateCommand();
                    command.CommandText = (" UPDATE Inventory SET MediaID = " + videogameID + "WHERE ID = " + itemID);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex) {
                MessageBox.Show("Failed to add video game to database.\t" + ex.Message);
            }
        }
        public VideoGame GetVideoGame(int id) { // get video game from its ID on the VideoGames table
            VideoGame game = new VideoGame();

            try {
                using (var connection = new SqliteConnection(ConnectionString)) {
                    connection.Open();
                    var command = connection.CreateCommand();
                    command.CommandText = (" SELECT * FROM VideoGames WHERE ID = " + id + "; ");
                    using (var reader = command.ExecuteReader()) {
                        while (reader.Read()) {
                            game.ID = reader.GetInt32(0);
                            game.Title = reader.GetString(1);
                            game.ReleaseYear = reader.GetInt32(2);
                            game.Rating = reader.GetChar(3);
                            game.Platform = reader.GetString(4);
                            game.MultiplayerInfo = reader.GetString(5);
                            game.AvailableCopies = reader.GetInt32(6);
                            game.TotalCopies = reader.GetInt32(7);
                        }
                    }
                }
            }
            catch (Exception ex) {
                MessageBox.Show("Failed to retrieve video game from database.\t" + ex.Message);
            }

            return game;
        }
        public VideoGame GetVideoGameByItem(int itemID) { // get video game from its Inventory ID
            // get VideoGames ID from Inventory item
            int videogameID = -1;
            try {
                using (var connection = new SqliteConnection(ConnectionString)) {
                    connection.Open();
                    var command = connection.CreateCommand();
                    command.CommandText = (" SELECT * FROM Inventory WHERE ID = " + itemID + "; ");
                    using (var reader = command.ExecuteReader()) {
                        while (reader.Read()) {
                            videogameID = reader.GetInt32(2);
                        }
                    }
                }
            }
            catch (Exception ex) {
                MessageBox.Show("Failed to retrieve video game from database.\t" + ex.Message);
            }

            // call GetVideoGame using videogameID
            return GetVideoGame(videogameID);
        }

    }
}
