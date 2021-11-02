namespace DSAlgorithms.Programs.Matrices
{
    public interface IMatrix
    {
        void Insert(int row, int col, int value);
        int Get(int row, int col);
        void Update(int row, int col, int value);
        void Display();
    }
}