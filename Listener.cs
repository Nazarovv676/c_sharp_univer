namespace Lab4Sharp { 
    class Listener { 
        private List<ListEntry> entries = new List<ListEntry>();

        public void SubscribeToAdded(EmployeeCollection collection) {
            collection.Added += ListenerFunc;
        }

        public void SubscribeToReplaced(EmployeeCollection collection) {
            collection.Replaced += ListenerFunc;
        }

        private void ListenerFunc(object sender, EmployeeCollectionHandlerEventArgs args) {
            entries.Add(new ListEntry(args.CollectionId, args.Msg, args.ElementIndex));
        }

        public override string ToString()
        {
            return String.Join("\n", entries.Select(entry => entry.ToString()).ToArray());
        }
    }
}