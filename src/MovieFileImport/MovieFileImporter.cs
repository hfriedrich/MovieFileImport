using System.Collections.Generic;
using MovieImportService;
using Newtonsoft.Json;
using System.IO;
using Microsoft.Framework.ConfigurationModel;

namespace MovieFileImport
{
    public class MovieFileImporter : IMovieImporter
    {
        public IEnumerable<Movie> ImportMovies()
        {
            var pathToFileWithMovies = ReadPathToFileWithMoviesFromConfig();
            string movieFile = File.ReadAllText(pathToFileWithMovies);
            return JsonConvert.DeserializeObject<List<Movie>>(movieFile);
        }

        private static string ReadPathToFileWithMoviesFromConfig()
        {
            var configuration = new Configuration();
            configuration.AddJsonFile("config.json");
            return configuration.Get("Data:FileWithMovies:Path");
        }
    }
}
