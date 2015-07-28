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
  }