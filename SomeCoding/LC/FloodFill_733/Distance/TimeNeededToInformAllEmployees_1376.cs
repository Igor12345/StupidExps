using System.Collections;

namespace Distance;

public class TimeNeededToInformAllEmployees_1376
{
    private Dictionary<int, Branch> _departments = new();
    public int NumOfMinutes(int n, int headID, int[] manager, int[] informTime)
    {

        int ceo = -1;
        for (int i = 0; i < n; i++)
        {
            Branch employee;
            if (_departments.ContainsKey(i))
            {
                employee = _departments[i];
            }
            else
            {
                employee = new Branch(i, informTime[i]);
                _departments.Add(i, employee);
            }

            if (manager[i] == headID)
            {
                ceo = i;
            }
            else{
                if (!_departments.ContainsKey(manager[i]))
                {
                    _departments.Add(manager[i], new Branch(manager[i], informTime[manager[i]], employee));
                }
                else
                {
                    _departments[manager[i]].Employees.Add(employee);
                }
            }
        }

        int wholeTime = 0;

        Branch header = _departments[ceo];
        int time = header.RealTime();

        TreeWalker walker = new TreeWalker(header);

        IVisitor visitor = new TimeCalculator();
        foreach (Branch branch in walker)
        {
            visitor.Visit(branch);
            // Console.WriteLine($"Result of walking branch: {branch.Header}");
        }
        
        Queue<int> queue = new();
        queue.Enqueue(ceo);
        while (queue.Any())
        {
            var departmentId = queue.Dequeue();
            var department = _departments[departmentId];
            // int time = department.Employees.m
        }

        return 1;
    }

    class TreeWalker : IEnumerable<Branch>
    {
        private readonly Branch _branch;

        public TreeWalker(Branch branch)
        {
            // Console.WriteLine($"ctor walker {branch.Header} [{branch.Employees.Count}]");
            _branch = branch;
        }

        public IEnumerator<Branch> GetEnumerator()
        {
            // Console.WriteLine($"Enter GetEnumerator of {_branch.Header}");
            foreach (Branch employee in _branch.Employees)
            {
                // Console.WriteLine($"Enter loop from {_branch.Header} - employee: {employee.Header}");
                foreach (Branch sub in new TreeWalker(employee))
                {
                    // Console.WriteLine($"Return {sub.Header}; from {_branch.Header} - employee: {employee.Header}");
                    yield return sub;
                }

                // Console.WriteLine($"Return employee himself {employee.Header} from {_branch.Header}");
                // yield return employee;
            }

            yield return _branch;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    struct Branch
    {
        public int Time;

        public int Header;

        public List<Branch> Employees = new ();

        public Branch(int header, int time)
        {
            Time = time;
            Header = header;
        }
        public Branch(int header, int time, Branch employee)
        {
            Time = time;
            Header = header;
            Employees.Add(employee);
        }

        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }

        public int RealTime()
        {
            int result = Time + (Employees.Any() ? Employees.Max(e => e.RealTime()) : 0);
            return result;
        }
    }

    interface IVisitor
    {
        void Visit(Branch branch);
    }

    class PrintVisitor : IVisitor
    {
        public void Visit(Branch branch)
        {
            Console.WriteLine($"!! Processing {branch.Header} [{branch.Employees.Count}]");
        }
    }

    class TimeCalculator : IVisitor
    {
        public void Visit(Branch branch)
        {
            Console.WriteLine($"!! Processing {branch.Header} [{branch.Employees.Count}], time: {branch.RealTime()}");

        }
    }
}