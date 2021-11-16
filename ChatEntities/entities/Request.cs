namespace ChatEntities.entities
{
    [Serializable]
    public class Request
    {
        public int code;
        public string username = "";
        public int chatId = 0;
        public string chatname = "";
        public int userId = 0;
        public string message = "";

        public Request(int code)
        {
            this.code = code;
        }

        public Request(int code, string username)
        {
            this.code = code;
            this.username = username;
        }

        public Request(int code,int chatId, string chatname)
        {
            this.code = code;
            this.chatId = chatId;
            this.chatname = chatname;
        }
        public Request(int code, int chatId)
        {
            this.code = code;
            this.chatId = chatId;
        }

        public Request(int code, int chatId, int userId)
        {
            this.code = code;
            this.chatId = chatId;
            this.userId = userId;
        }

        public Request(int code, int userId, int chatId, string username, string message)
        {
            this.code = code;
            this.userId = userId;
            this.chatId = chatId;
            this.username = username;
            this.message = message;
        }

        override public string ToString()
        {
            return "Request(" + code + "," + userId + "," + username + "," + chatId + "," + chatname + "," + message + ")";
        }
    }
}
