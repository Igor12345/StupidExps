namespace FloodFill_733;

public class Solution
{
    private readonly Queue<(int, int)> _queue = new Queue<(int, int)>();
    private int _startColor;
    private int _color;

    public int[][] FloodFill(int[][] image, int sr, int sc, int color)
    {
        _startColor = image[sr][sc];
        _color = color;

        _queue.Enqueue((sr, sc));
        image[sr][sc] = color;
        while (_queue.Count > 0)
        {
            var point = _queue.Dequeue();
            StepUp(image, point);
            StepDown(image, point);
            StepRight(image, point);
            StepLeft(image, point);
        }

        for (int i = 0; i < image.Length; i++)
        {
            for (int j = 0; j < image[i].Length; j++)
            {
                if (image[i][j] == -1)
                    image[i][j] = color;
            }
        }

        return image;
    }

    private void StepRight(int[][] image, (int, int) point)
    {
        if (point.Item2 < image[point.Item1].Length && image[point.Item1][point.Item2 + 1] == _startColor)
        {
            _queue.Enqueue((point.Item1, point.Item2 + 1));
            image[point.Item1][point.Item2 + 1] = _color;
        }
    }

    private void StepLeft(int[][] image, (int, int) point)
    {
        if (point.Item2 > 0 && image[point.Item1][point.Item2 - 1] == _startColor)
        {
            _queue.Enqueue((point.Item1, point.Item2 - 1));
            image[point.Item1][point.Item2 - 1] = _color;
        }
    }

    private void StepDown(int[][] image, (int, int) point)
    {
        if (point.Item1 < image.Length && image[point.Item1 + 1][point.Item2] == _startColor)
        {
            _queue.Enqueue((point.Item1 + 1, point.Item2));
            image[point.Item1 + 1][point.Item2] = _color;
        }
    }

    private void StepUp(int[][] image, (int, int) point)
    {
        if (point.Item1 > 0 && image[point.Item1 - 1][point.Item2] == _startColor)
        {
            _queue.Enqueue((point.Item1 - 1, point.Item2));
            image[point.Item1 - 1][point.Item2] = _color;
        }
    }
}