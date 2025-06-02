using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AudioVideoShop.Services
{
    /// <summary>
    /// Помогает фильтровать строки в DataGridView
    /// </summary>
    public class SearchHelper
    {
        /// <summary>
        /// Применяет фильтр: ищет в выбранной колонке textLike
        /// Если ошибка Convert, сбрасывает фильтр и показывает MessageBox
        /// </summary>
        public void ApplySearchFilter(DataGridView dgv, string columnName, string searchText)
        {
            if (string.IsNullOrEmpty(columnName))
            {
                MessageBox.Show("Пожалуйста, выберите колонку для поиска.",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(searchText))
            {
                MessageBox.Show("Пожалуйста, введите текст для поиска.",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!(dgv.DataSource is DataTable dt))
                return;

            try
            {
                var sanitized = searchText.Trim().Replace("'", "''");
                string filter = $"Convert([{columnName}], 'System.String') LIKE '%{sanitized}%'";
                dt.DefaultView.RowFilter = filter;
            }
            catch (EvaluateException ex)
            {
                dt.DefaultView.RowFilter = string.Empty;
                MessageBox.Show($"Ошибка при фильтрации: {ex.Message}",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Сбрасывает фильтр (показывает все строки)
        /// </summary>
        public void ClearSearchFilter(DataGridView dgv)
        {
            if (dgv.DataSource is DataTable dt)
            {
                dt.DefaultView.RowFilter = string.Empty;
            }
        }
    }
}

