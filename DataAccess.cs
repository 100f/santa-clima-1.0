using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SantaClima
{
    public class DataAccess
    {
        private string connString = "mongodb+srv://dbVitor:teste123@estacao-g8blf.gcp.mongodb.net/test?retryWrites=true&w=majority";
        private IMongoDatabase database;
        public DataAccess(string _database)
        {
            try
            {
                var client = new MongoClient(connString); 
                database = client.GetDatabase(_database);
            }
            catch(Exception ex)
            {
                MessageBox.Show($"Erro: {ex.Message}");
            }
        }
        public async void insertRegister<T>(string _collection, T _document)
        {
            var collection = database.GetCollection<T>(_collection);
            await collection.InsertOneAsync(_document);
        }
        public List<T> getRegistersByDate<T>(string _collection, DateTime _minDate, ulong pageNumber = 1, byte pointsPerPage = 20)
        {
            var collection = database.GetCollection<T>(_collection);
            var dateRangeFilter = Builders<T>.Filter.Lte("createdAt", DateTime.Now) & Builders<T>.Filter.Gte("createdAt", _minDate);
            var sortDefinition = Builders<T>.Sort.Ascending("createdAt");
            return collection.Find(dateRangeFilter).Skip(pointsPerPage * ((int)pageNumber - 1)).Limit(pointsPerPage).Sort(sortDefinition).ToList();
        }
        public ulong getPageCount<T>(string _collection, byte _documentsPerPage = 20)
        {
            var collection = database.GetCollection<T>(_collection);
            var matchesAllFilter = Builders<T>.Filter.Empty;
            var numberOfDocuments = collection.CountDocumentsAsync(matchesAllFilter).Result;

            return numberOfDocuments > 0 ? (ulong)Math.Ceiling((double)numberOfDocuments / _documentsPerPage) : 1;
        }
        public double getPeakValueByDateRange<T>(DateTime _minDate, DateTime _maxDate, string _collection, string _weatherParameter)
        {
            var collection = database.GetCollection<T>(_collection);
            var dateRangeFilter = Builders<T>.Filter.Lte("createdAt", _maxDate) & Builders<T>.Filter.Gte("createdAt", _minDate);
            var sortDefinition = Builders<T>.Sort.Descending(_weatherParameter);
            var registerRetrieved = collection.Find(dateRangeFilter).Sort(sortDefinition).FirstOrDefault();
            return registerRetrieved != null ? (double)registerRetrieved.GetType().GetProperty(_weatherParameter).GetValue(registerRetrieved, null) : 0;
        }
    }
}