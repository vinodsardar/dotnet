using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;

namespace CheckMongoDB
{
    class Program
    {
        static void Main(string[] args)
        {

            const string connectionString = "mongodb://localhost";

            //Create the client for Mongo DB
            MongoClient mongoClient = new MongoClient(connectionString);


            //Get Database (if not present then MongoDB will create the Database)
            var database = mongoClient.GetDatabase("BlogPost");
           
            //Get the Collection .......... See strongly typed collection using <Post>
            var collection = database.GetCollection<Post>("post");
            

            List<string> _lstComments = new List<string>();
            _lstComments.Add("Thanks");
            Random r = new Random();            
            Post p1 = new Post(r.Next(), "Vinod Sardar","Sample Content",_lstComments);

            //Insert the data into Mongo DB
            collection.InsertOne(p1);
             

            //Iterate the Data from MongoDB collection
            foreach (Post item in collection.AsQueryable<Post>())
            {
                Console.WriteLine("id : {0} , Author : {1}",item.Id,item.Author);

            }

            Console.ReadLine();




        }
    }

    public class Post
    {
        public int Id { get; set; }
        public string Author { get; set; }
        public string Content { get; set; }
        public List<string> Comments { get; set; }

        public Post(int id,string author,string content,List<string> commentList)
        {
            this.Id = id;
            this.Author = author;
            this.Content = content;
            this.Comments = commentList;
        }
    }
}
