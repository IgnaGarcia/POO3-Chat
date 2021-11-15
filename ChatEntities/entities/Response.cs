namespace ChatEntities.entities
{
    [Serializable]
    public class Response
    {
        public int code;
        public string status;
        public User? user = null;
        public List<Chat>? chatList = null;
        public List<Message>? messageList = null;
        public Message? message = null;

        public Response(int code, string status)
        {
            this.code = code;
            this.status = status;
        }

        public Response(int code, string status, User? user) 
            : this(code, status)
        {
            this.user = user;
        }

        public Response(int code, string status, List<Chat>? chatList) 
            : this(code, status)
        {
            this.chatList = chatList;
        }
        public Response(int code, string status, List<Message>? messageList) 
            : this(code, status)
        {
            this.messageList = messageList;
        }
        public Response(int code, string status, Message? message) 
            : this(code, status)
        {
            this.message = message;
        }

        override public string ToString()
        {
            return "Response(" + code + "," + status + "," + user?.ToString() + "," + chatList?.ToString() + "," + messageList?.ToString() + "," + message?.ToString() + ")";
        }
    }
}
