using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AudioVideoShop.Services
{
    /// <summary>
    /// Статический класс-утилита, который отвечает за:
    /// - авто-размер и выравнивание колонок в DataGridView,
    /// - изменение фона ячейки при правке.
    /// </summary>
    public static class DataGridViewStyler
    {
        /// <summary>
        /// Настраивает переданный DataGridView:
        /// - растягивает колонки на всю ширину
        /// - выравнивает первую колонку по правому краю, остальные — по левому
        /// </summary>
        public static void AdjustColumns(DataGridView dgv)
        {
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            foreach (DataGridViewColumn column in dgv.Columns)
            {
                column.DefaultCellStyle.Alignment =
                    column.Index == 0
                        ? DataGridViewContentAlignment.MiddleRight
                        : DataGridViewContentAlignment.MiddleLeft;
            }
        }

        /// <summary>
        /// Меняет фон ячейки при изменении значения
        /// </summary>
        public static void HighlightModifiedCell(DataGridViewCell cell)
        {
            if (cell != null)
                cell.Style.BackColor = System.Drawing.Color.LightBlue;
        }

        /// <summary>
        /// Сбрасывает фон всех ячеек в DataGridView к белому
        /// Вызывать после сохранения изменений в БД
        /// </summary>
        public static void ResetAllCellsBackground(DataGridView dgv)
        {
            foreach (DataGridViewRow row in dgv.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    cell.Style.BackColor = System.Drawing.Color.White;
                }
            }
        }
    }
}
