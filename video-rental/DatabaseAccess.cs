using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Data.Sqlite;

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
                    command.CommandText = (" CREATE TABLE IF NOT EXISTS Movies( ID INTEGER PRIMARY KEY AUTOINCREMENT, Title TEXT NOT NULL, Year INTEGER NOT NULL, Rating TEXT NOT NULL, Studio TEXT, Genre TEXT ); ");
                    command.ExecuteNonQuery();
                    // table for TV Shows
                    // table for Video Games
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
