using System;
using System.Collections.Generic;
using System.Linq;

namespace HomeworkQueriesLINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            //First Part

            var queries = new QuiriesWithDigitsAndStrings();

            //queries.PrintDigits();

            //queries.PrintDigitsDivisibleBy3();

            //queries.PrintWord();

            //queries.PrintAllStringsWithA("aaa;abb;ccc;dap");

            //queries.PrintAllStringsAndCountOfA("aaa;abb;ccc;dap");

            //queries.IsWordExist("aaa;abb;ccc;dap", "abb");

            //queries.PrintLongestString("aaa; xabbx; abb; ccc; dap");

            //queries.PrintAverageLenghtOfString("aaa; xabbx; abb; ccc; dap");

            //queries.PrintShortestStringReverse("aaa; xabbx; abb; ccc; dap; zh");

            //queries.PrintStringsStartsAEndsB("baaa; aabb; aaa; aabbx; abb; ccc; dap; zh");

            //queries.PrintLastInSequence("baaa; aabb; aaa; aabbx; abb; ccc; dap; zh; asdbb; vasdasdbb; bbbbbbb");

            /////
            ///

            //Second Part

            List<object> data = new List<object> {
                "Hello",
                new Article { Author = "Hilgendorf", Name = "Punitive law and criminal law doctrine.", Pages = 44 },
                new List<int> {45, 9, 8, 3},
                new string[] {"Hello inside array"},
                new Film { Author = "Martin Scorsese", Name= "The Departed", Actors = new List<Actor>() {
                    new Actor { Name = "Jack Nickolson", Birthdate = new DateTime(1937, 4, 22)},
                    new Actor { Name = "Leonardo DiCaprio", Birthdate = new DateTime(1974, 11, 11)},
                    new Actor { Name = "Matt Damon", Birthdate = new DateTime(1970, 8, 10)}
                }},
                new Film { Author = "Gus Van Sant", Name = "Good Will Hunting", Actors = new List<Actor>() {
                    new Actor { Name = "Matt Damon", Birthdate = new DateTime(1970, 8, 10)},
                    new Actor { Name = "Robin Williams", Birthdate = new DateTime(1951, 8, 11)},
                }},
                new Article { Author = "Basov", Name="Classification and content of restrictive administrative measures applied in the case of emergency", Pages = 35},
                new Article { Author = "Basov", Name="Classification and content of restrictive administrative measures applied in the case of emergency 2", Pages = 35},
                "Leonardo DiCaprio"
            };

            var actorQueries = new ActorsQueriesLINQ();

            actorQueries.PrintAllNames(data);

            actorQueries.GetCountOfActors(data);

            actorQueries.PrintTwoOldestActors(data);

            //actorQueries.PrintAuthorsActicles(data);

            actorQueries.PrintAuthorsOfArticlesAndFilms(data);

            actorQueries.PrintDistinctCharsOfActorsNames(data);

            actorQueries.PrintArticleNames(data);

            actorQueries.PrintActorAndHisFilms(data);

            actorQueries.GetSum(data);

            actorQueries.GetDictionary(data);
        }
    }
}
