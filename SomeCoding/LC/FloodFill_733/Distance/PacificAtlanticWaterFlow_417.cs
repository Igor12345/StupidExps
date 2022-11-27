namespace Distance;

public class PacificAtlanticWaterFlow_417
{
    private bool _canContinue;

    public IList<IList<int>> PacificAtlantic(int[][] heights)
    {
        IList<IList<int>> result = new List<IList<int>>();
        int[][] atlantic = new int[heights.Length][];
        int[][] pacific = new int[heights.Length][];
        for (int i = 0; i < heights.Length; i++)
        {
            atlantic[i] = Enumerable.Repeat(-1, heights[0].Length).ToArray();
            pacific[i] = Enumerable.Repeat(-1, heights[0].Length).ToArray();
        }
        
        for (int j = 0; j < heights[0].Length; j++)
        {
            pacific[0][j] = heights[0][j];
        }

        for (int i = 0; i < heights.Length; i++)
        {
            pacific[i][0] = heights[i][0];
        }
        
        for (int j = 0; j < heights[0].Length; j++)
        {
            atlantic[^1][j] = heights[^1][j];
        }

        for (int i = 0; i < heights.Length; i++)
        {
            atlantic[i][^1] = heights[i][^1];
        }
        do
        {
            _canContinue = false;
            for (int i = 0; i < heights.Length; i++)
            {
                for (int j = 0; j < heights[i].Length; j++)
                {
                    if (pacific[i][j] >= 0)
                    {
                        MarkNeighbours(heights, pacific, i, j);
                    }
                }
            }

        } while (_canContinue);
        
        do
        {
            _canContinue = false;
            for (int i = 0; i < heights.Length; i++)
            {
                for (int j = 0; j < heights[i].Length; j++)
                {
                    if (atlantic[i][j] >= 0)
                    {
                        MarkNeighbours(heights, atlantic, i, j);
                    }
                }
            }

        } while (_canContinue);
        
        for (int i = 0; i < heights.Length; i++)
        {
            for (int j = 0; j < heights[i].Length; j++)
            {
                if (atlantic[i][j] >= 0 && pacific[i][j]>=0)
                {
                    result.Add(new List<int>(){i,j});
                }
            }
        }

        return result;
    }

    private void MarkNeighbours(int[][] heights, int[][] available, int i, int j)
    {
        if (i > 0 && available[i - 1][j] == -1 && heights[i - 1][j] >= heights[i][j])
        {
            available[i - 1][j] = heights[i - 1][j];
            _canContinue = true;
        }

        if (i < heights.Length - 1 && available[i + 1][j] == -1 && heights[i + 1][j] >= heights[i][j])
        {
            available[i + 1][j] = heights[i + 1][j];
            _canContinue = true;
        }

        if (j > 0 && available[i][j - 1] == -1 && heights[i][j - 1] >= heights[i][j])
        {
            available[i][j - 1] = heights[i][j - 1];
            _canContinue = true;
        }

        if (j < heights[0].Length - 1 && available[i][j + 1] == -1 && heights[i][j + 1] >= heights[i][j])
        {
            available[i][j + 1] = heights[i][j + 1];
            _canContinue = true;
        }
    }
}