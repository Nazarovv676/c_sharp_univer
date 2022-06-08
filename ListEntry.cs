namespace Lab4Sharp { 
    class ListEntry { 
        public ListEntry(string name, string message, int index) {
            CollectionName = name;
            Message = message;
            Index = index;
        }
        
        public string CollectionName {
            get; set;
        }

        public string Message {
            get; set;
        }

        public int Index {
            get; set;
        }

        public override string ToString()
        {
            return string.Format($"Name: {CollectionName}, Message: {Message}, Index: {Index}");
        }
    }
}