namespace Distance;

public class TimeNeededToInformAllEmployees_1376
{
    private Dictionary<int, Branch> _departments = new();
    public int NumOfMinutes(int n, int headID, int[] manager, int[] informTime)
    {
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

            if (i != headID)
            {
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


        Branch header = _departments[headID];
        int wholeTime = header.RealTime();
        return wholeTime;
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

        public int RealTime()
        {
            int result = Time + (Employees.Any() ? Employees.Max(e => e.RealTime()) : 0);
            return result;
        }
    }
}