using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HomeworkQueriesLINQ
{
    abstract class ArtObject
    {
        public string Author { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
    }

    class Film : ArtObject
    {

        public int Length { get; set; }
        public IEnumerable<Actor> Actors { get; set; }
    }

    class Actor
    {
        public string Name { get; set; }
        public DateTime Birthdate { get; set; }
    }

    class Article : ArtObject
    {
        public int Pages { get; set; }
    }


    class ActorsQueriesLINQ
    {
        public void PrintAllNames(List<object> data)
        {
            data.OfType<Film>()
                .Select(x => x.Actors).SelectMany(x => x).ToList()
                .ForEach(x => { Console.WriteLine(x.Name); });
        }

        public void GetCountOfActors(List<object> data)
        {
            int count = data.OfType<Film>()
                .Select(x => x.Actors).SelectMany(x => x.Where(y => y.Birthdate.Month == 8)).ToList().Count();
            Console.WriteLine($"Actors burn in August: {count}");
        }

        public void PrintTwoOldestActors(List<object> data)
        {
            var actors = data.OfType<Film>()
                .Select(x => x.Actors).SelectMany(x => x).OrderByDescending(x => x.Birthdate).ToList();
            Console.WriteLine($"Two oldest actors is {actors[actors.Count - 1].Name} and {actors[actors.Count - 2].Name}");
        }

        public void PrintAuthorsActicles(List<object> data)
        {
            data.OfType<Article>()
                .Select(x => x.Author).Distinct().ToList()
                .ForEach(x => { Console.WriteLine($"{x} - {data.OfType<Article>().Count(y => y.Author == x)} articles"); });
        }

        public void PrintAuthorsOfArticlesAndFilms(List<object> data)
        {
            data.OfType<Article>()
                .Select(x => x.Author).Distinct().ToList()
                .ForEach(x => { Console.WriteLine($"{x} - {data.OfType<Article>().Count(y => y.Author == x)} articles"); });
            data.OfType<Film>()
                .Select(x => x.Author).Distinct().ToList()
                .ForEach(x => { Console.WriteLine($"{x} - {data.OfType<Film>().Count(y => y.Author == x)} films"); });
        }

        public void PrintDistinctCharsOfActorsNames(List<object> data)
        {
            var chars = data.OfType<Film>()
                .Select(x => x.Actors).SelectMany(x => x).Select(x => x.Name.ToLower()).Distinct()
                .SelectMany(x => x).Distinct().ToList().Count() - 1;

            Console.WriteLine($"{chars} different chars");
        }

        public void PrintArticleNames(List<object> data)
        {
            data.OfType<Article>().OrderBy(x => x.Author).ThenBy(x => x.Pages).ToList()
                .ForEach(x => { Console.WriteLine(x.Name); });
        }

        public void PrintActorAndHisFilms(List<object> data)
        {
            data.OfType<Film>()
                .Select(x => x.Actors).SelectMany(x => x).Select(x => x).Distinct().ToList()
                .ForEach(x => 
                {
                    Console.Write(x.Name + ": ");
                    data.OfType<Film>().Where(y => y.Actors.Contains(x)).Select(y => y.Name).ToList().ForEach(y =>
                    {
                        Console.Write(y + " ");
                    });
                    Console.WriteLine();
                });
        }

        public void GetSum(List<object> data)
        {
            Console.WriteLine($@"Article pages: {data.OfType<Article>().Sum(x => x.Pages)}
Sum of All: {data.OfType<Article>().Sum(x => x.Pages) + data.OfType<ArtObject>().Sum(x => x.Year) + data.OfType<Film>().Sum(x => x.Length)}");
        }

        public void GetDictionary(List<object> data)
        {
            var dictionary = data.OfType<Article>().Select(x => x.Author).Distinct()
                .ToDictionary(x => x, x => data.OfType<Article>().Where(y => y.Author == x).ToList());
        }
    }
}
