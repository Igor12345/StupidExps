namespace Directions;

public class KeysAndRooms_841
{
    private HashSet<int> _visited = new();
    private HashSet<int> _keys = new();
    public bool CanVisitAllRooms(IList<IList<int>> rooms) {
        foreach (int key in rooms[0])
        {
            _keys.Add(key);
        }
        _visited.Add(0);

        while (_keys.Any() && _visited.Count < rooms.Count)
        {
            int next = _keys.First();
            _keys.Remove(next);
            if (!_visited.Contains(next))
            {
                _visited.Add(next);
            }

            foreach (int key in rooms[next])
            {
                if (!_keys.Contains(key) && !_visited.Contains(key))
                    _keys.Add(key);
            }
        }

        return _visited.Count == rooms.Count;
    }
}