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
        private const string ConnectionString = "Data Source=StoreCatalog.db";


        public DatabaseAccess() {
            InitializeDatabase();
        }
        public void InitializeDatabase() {
            try {
                using (var connection = new SqliteConnection(ConnectionString)) {
                    connection.Open();

                    var command = connection.CreateCommand();
                    command.CommandText = (" CREATE TABLE IF NOT EXISTS Movies( ID INTEGER PRIMARY KEY AUTOINCREMENT, Title TEXT NOT NULL, Length DOUBLE, Year INTEGER, MPARating CHAR, Format TEXT, AvailableCopies INTEGER NOT NULL, TotalCopies INTEGER NOT NULL ); ");
                    command.ExecuteNonQuery();

                    command.CommandText = (" CREATE TABLE IF NOT EXISTS BoxSets( ID INTEGER PRIMARY KEY AUTOINCREMENT, Title TEXT NOT NULL, Seasons TEXT, Year INTEGER, MPARating CHAR, Format TEXT, DiscsIncluded INTEGER NOT NULL, AvailableCopies INTEGER NOT NULL, TotalCopies INTEGER NOT NULL ); ");
                    command.ExecuteNonQuery();

                    command.CommandText = (" CREATE TABLE IF NOT EXISTS VideoGames( ID INTEGER PRIMARY KEY AUTOINCREMENT, Title TEXT NOT NULL, Year Integer, ESRBRating CHAR, Platform TEXT, MultiplayerInfo TEXT, AvailableCopies INTEGER NOT NULL, TotalCopies INTEGER NOT NULL ); ");
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex) {
                // THIS IS BAD, DO NOT DO THIS:
                MessageBox.Show("Error initializing database.\t" + ex.Message);
            }
        }


        public void AddBook(string title, string author, int year) {
            try {
                using (var connection = new SqliteConnection(ConnectionString)) {
                    connection.Open();

                    var command = connection.CreateCommand();

                    command.CommandText = @" INSERT INTO Books(Title, Author, YearPublished) 
                                                                VALUES(@title, @author, @year); ";
                    command.Parameters.AddWithValue("@title", title);
                    command.Parameters.AddWithValue("@author", author);
                    command.Parameters.AddWithValue("@year", year);

                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex) {
                // THIS IS BAD, DO NOT DO THIS:
                MessageBox.Show("Failed to add book.\t" + ex.Message);
            }
        }

    }
}
