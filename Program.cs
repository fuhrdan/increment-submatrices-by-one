//*****************************************************************************
//** 2536. Increment Submatrices by One                             leetcode **
//*****************************************************************************
//** A thousand tiny queries paint their marks across the grid,              **
//** Each rectangle a whisper of the work the solver did.                    **
//** But with a single sweep of sums, the chaos turns to grace               **
//** A quiet prefix chorus restores order to the place.                      **
//*****************************************************************************

/**
 * Return an array of arrays of size *returnSize.
 * The sizes of the arrays are returned as *returnColumnSizes array.
 * Note: Both returned array and *columnSizes array must be malloced, assume caller calls free().
 */
int** rangeAddQueries(int n, int** queries, int queriesSize, int* queriesColSize, int* returnSize, int** returnColumnSizes) {
    int i = 0;
    int j = 0;

    int** matrix = (int**)malloc(sizeof(int*) * n);
    for(i = 0; i < n; i++)
    {
        matrix[i] = (int*)calloc(n, sizeof(int));
    }

    for(i = 0; i < queriesSize; i++)
    {
        int row1 = queries[i][0];
        int col1 = queries[i][1];
        int row2 = queries[i][2];
        int col2 = queries[i][3];

        matrix[row1][col1]++;

        if(row2 + 1 < n)
        {
            matrix[row2 + 1][col1]--;
        }

        if(col2 + 1 < n)
        {
            matrix[row1][col2 + 1]--;
        }

        if(row2 + 1 < n && col2 + 1 < n)
        {
            matrix[row2 + 1][col2 + 1]++;
        }
    }

    for(i = 0; i < n; i++)
    {
        for(j = 0; j < n; j++)
        {
            if(i > 0)
            {
                matrix[i][j] += matrix[i - 1][j];
            }
            if(j > 0)
            {
                matrix[i][j] += matrix[i][j - 1];
            }
            if(i > 0 && j > 0)
            {
                matrix[i][j] -= matrix[i - 1][j - 1];
            }
        }
    }

    *returnSize = n;

    int* colSizes = (int*)malloc(sizeof(int) * n);
    for(i = 0; i < n; i++)
    {
        colSizes[i] = n;
    }
    *returnColumnSizes = colSizes;

    return matrix;
}