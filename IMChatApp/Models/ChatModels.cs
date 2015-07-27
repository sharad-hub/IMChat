using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace IMChatApp.Models
{
  public enum Status
    {
        Online,
        Away,
        Bussy,
        Offline
    }
    public class Css
    {
        public string color { get; set; }
        public string underline { get; set; }
        public string fstyle { get; set; }
        public string italic { get; set; }
        public string bold { get; set; }
    }


    public class Room
    {
        public int id { get; set; }
        public string name { get; set; }
        public List<user> users { get; set; }
        public string type { get; set; }
        public string welcomeMessage { get; set; }
        //public string id { get; set; }
        //id, name, users, type, welcomeMessage
       // ChatAppEntities Db = new ChatAppEntities();
        public Room() {

            if (rooms.Count == 0)
            {
              //  List<RoomMaster> listroomMaster = Db.RoomMasters.ToList();
              //  rooms =Mappers.RoomMap(Db.RoomMasters.ToList());
            }
        }

        public static List<Room> rooms = new List<Room>();
        public static void InitializeRoom()
        {
            List<Room> rooms = new List<Room>();
            rooms.Add(new Room { id = 1, name = "India", welcomeMessage = "Welcome to India Room ", type = "Normal", users = null });
            rooms.Add(new Room { id = 2, name = "Canada", welcomeMessage = "Welcome to India Room ", type = "Normal", users = null });
            rooms.Add(new Room { id = 3, name = "Pakistan", welcomeMessage = "Welcome to Pakistan Room ", type = "Normal", users = null });
            rooms.Add(new Room { id = 4, name = "USA", welcomeMessage = "Welcome to USA Room ", type = "Normal", users = null });
            rooms.Add(new Room { id = 5, name = "UK", welcomeMessage = "Welcome to UK Room ", type = "Normal", users = null });
            rooms.Add(new Room { id = 6, name = "C sharp", welcomeMessage = "Welcome to C sharp Room ", type = "Normal", users = null });
            rooms.Add(new Room { id = 7, name = "PHP", welcomeMessage = "Welcome to PHP Room ", type = "Normal", users = null });
            rooms.Add(new Room { id = 8, name = "ASP", welcomeMessage = "Welcome to ASP Room ", type = "Normal", users = null });
            rooms.Add(new Room { id = 9, name = "MVC", welcomeMessage = "Welcome to MVC Room ", type = "Normal", users = null });

        }

        public void AddUserToList(string name, string room)
        {
            Room r = rooms.Where(x => x.name == "room").Single();
            // update from data base .
            r.users.Add(new user { name = name });
        }
    }
    public class user
    {
        //id, name, type, fontName, fontSize, fontColor, sex, age, friendsList, status, memberType

      public  string ConnectionId { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public List<user> friendsList { get; set; }
        public string fontName { get; set; }
        public string fontSize { get; set; }
        public string fontColor { get; set; }
        public string sex { get; set; }
        public int age { get; set; }
        public Status status { get; set; }
        public string memberType { get; set; }
        public string avator { get; set; }

        //public user Login(string UserName)
        //{ 


        //}

    }
    public class UsersRestricted
    {

        public int id { get; set; }
        public string name { get; set; }
        public string roomName { get; set; }
        public Restriction restriction { get; set; }

        public DateTime time { get; set; }

        public string restrictekBy { get; set; }
    }
 public  enum Restriction
    {
        BAN, MUTE, KICK
    }
    public class UsersInRoom
    {
    public int id { get; set; }
    public string RoomName { get; set; }
    public int usersCount { get; set; }
    }
}