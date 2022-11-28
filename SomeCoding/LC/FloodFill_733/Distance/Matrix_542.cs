namespace Distance;

public class Matrix_542
{
    private bool _continue=true;
    public int[][] UpdateMatrix(int[][] mat) {

        for (int i = 0; i < mat.Length; i++)
        {
            for (int j = 0; j < mat[i].Length; j++)
            {
                if (mat[i][j] == 1)
                {
                    mat[i][j] = -1;
                }
            }
        }

        int step = 0;
        while (_continue)
        {
            _continue = false;
            for (int i = 0; i < mat.Length; i++)
            {
                for (int j = 0; j < mat[i].Length; j++)
                {
                    if (mat[i][j] == step)
                    {
                        ProcessAround(mat, i, j, step);
                    }
                }
            }

            step++;
        }

        return mat;
    }

    private void ProcessAround(int[][] mat, int i, int j, int step)
    {
        if (i > 0 && mat[i][j] == step && mat[i - 1][j] == -1)
        {
            mat[i - 1][j] = step + 1;
            _continue = true;
        }

        if (i < mat.Length - 1 && mat[i][j] == step && mat[i + 1][j] == -1)
        {
            mat[i + 1][j] = step + 1;
            _continue = true;
        }

        if (j > 0 && mat[i][j] == step && mat[i][j - 1] == -1)
        {
            mat[i][j - 1] = step + 1;
            _continue = true;
        }

        if (j < mat[i].Length - 1 && mat[i][j] == step && mat[i][j + 1] == -1)
        {
            mat[i][j + 1] = step + 1;
            _continue = true;
        }
    }
}