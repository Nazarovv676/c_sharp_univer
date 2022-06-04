namespace Lab4Sharp { 
    class EmployeeCollectionHandlerEventArgs {
        public EmployeeCollectionHandlerEventArgs(string CollectionId,
                                                  string Msg,
                                                  int ElementIndex) {
            this.CollectionId = CollectionId;
            this.Msg = Msg;
            this.ElementIndex = ElementIndex;
        }

        public readonly string CollectionId;

        public readonly string Msg;

        public readonly int ElementIndex;

        public override string ToString()
        {
            return $"EmployeeListHandlerEventArgs(CollectionId: {CollectionId}, Msg: {Msg}, ElementIndex: {ElementIndex})";
        }
    }

    delegate void EmployeeListHandler (object source, EmployeeCollectionHandlerEventArgs args);

    class EmployeeCollection 
    {
        private List<Employee> employees = new List<Employee>();

        public EmployeeCollection(string id) {
            Id = id;
        }

        public string Id 
        {
            get; set;
        }

        public event EventHandler<EmployeeCollectionHandlerEventArgs> Added;
        public event EventHandler<EmployeeCollectionHandlerEventArgs> Replaced;

        private void OnAdded()
        {
            Added(this, new EmployeeCollectionHandlerEventArgs(Id,
                "Element added",
                employees.Count - 1));
        }

        private void OnReplaced(int index)
        {
            Replaced(this, new EmployeeCollectionHandlerEventArgs(Id,
                "Element replaced",
                index));
        }

        public void Add(Employee Employee)
        {
            employees.Add(Employee);
            OnAdded();
        }

        public void Replace(int index, Employee employee)
        {
            employees[index] = employee;
            OnReplaced(index);
        }


        public Employee this[int index]
        {
            get => employees[index];
            set => Replace(index, value);
        }

        public void AddRange(params Employee[] employees)
        {
            foreach(Employee employee in employees) {
                Add(employee);
            }
        }

        public void AddDefaults() 
        {
            Add(new Employee());
            Add(new Employee(new Person("Jony", "Depp", new DateTime(1978, 1, 12)),
                "Actor",
                TimeWork.FullTime,
                1999));
        }
    } 
}