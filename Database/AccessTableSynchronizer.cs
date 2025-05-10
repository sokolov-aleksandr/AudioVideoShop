using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;

namespace AudioVideoShop
{
    public class AccessTableSynchronizer : AccessDataSource
    {
        public string tableName;
        private DataTable dataTable;
        private OleDbDataAdapter adapter;
        private OleDbCommandBuilder commandBuilder;

        public AccessTableSynchronizer(string tableName)
        {
            this.tableName = tableName;
            dataTable = new DataTable();
            adapter = new OleDbDataAdapter($"SELECT * FROM {tableName}", connection);
            commandBuilder = new OleDbCommandBuilder(adapter);
        }

        // Загружает данные из Access в DataGridView
        public void LoadToGrid(DataGridView grid)
        {
            dataTable.Clear();
            adapter.Fill(dataTable);
            grid.DataSource = dataTable;
        }

        // Сохраняет изменения из DataGridView в базу Access
        public void SaveChanges()
        {
            adapter.Update(dataTable);
        }

        // Принудительно обновить таблицу (полностью перезагрузить)
        public void RefreshGrid(DataGridView grid, string tableName)
        {
            dataTable = new DataTable();
            adapter = new OleDbDataAdapter($"SELECT * FROM {tableName}", connection);
            commandBuilder = new OleDbCommandBuilder(adapter);

            LoadToGrid(grid); // Просто пересоздаём привязку заново
        }

        public void AddRow(params object[] values)
        {
            if (values.Length != dataTable.Columns.Count)
                throw new ArgumentException("Количество значений не соответствует количеству столбцов");

            var row = dataTable.NewRow();
            row.ItemArray = values;
            dataTable.Rows.Add(row);
        }

        public void DeleteRow(int rowIndex)
        {
            if (rowIndex < 0 || rowIndex >= dataTable.Rows.Count)
                throw new IndexOutOfRangeException("Индекс строки вне допустимого диапазона");

            dataTable.Rows[rowIndex].Delete();
        }

        

    }
}
