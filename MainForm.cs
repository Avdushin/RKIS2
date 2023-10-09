using System;
using System.Windows.Forms;

public partial class MainForm : Form
{
    private Button buttonFindMax;
    private DataGridView dataGridView1;
    private Matrix matrix;

    public MainForm()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        this.buttonFindMax = new System.Windows.Forms.Button();
        this.dataGridView1 = new System.Windows.Forms.DataGridView();
        ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
        this.SuspendLayout();

        // buttonFindMax
        this.buttonFindMax.Location = new System.Drawing.Point(337, 381);
        this.buttonFindMax.Name = "buttonFindMax";
        this.buttonFindMax.Size = new System.Drawing.Size(231, 31);
        this.buttonFindMax.TabIndex = 0;
        this.buttonFindMax.Text = "Найти";
        this.buttonFindMax.UseVisualStyleBackColor = true;
        this.buttonFindMax.Click += new System.EventHandler(this.buttonFindMax_Click);

        // dataGridView1
        this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        this.dataGridView1.Location = new System.Drawing.Point(27, 26);
        this.dataGridView1.Name = "dataGridView1";
        this.dataGridView1.Size = new System.Drawing.Size(865, 339);
        this.dataGridView1.TabIndex = 1;

        // MainForm
        this.ClientSize = new System.Drawing.Size(917, 454);
        this.Controls.Add(this.dataGridView1);
        this.Controls.Add(this.buttonFindMax);
        this.Name = "MainForm";
        this.Load += new System.EventHandler(this.MainForm_Load);
        ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
        this.ResumeLayout(false);
    }

    private void buttonFindMax_Click(object sender, EventArgs e)
    {
        matrix = new Matrix(dataGridView1.Rows.Count, dataGridView1.Columns.Count);

        // Заполнение матрицы данными из DataGridView
        for (int i = 0; i < dataGridView1.Rows.Count; i++)
        {
            for (int j = 0; j < dataGridView1.Columns.Count; j++)
            {
                var cell = dataGridView1.Rows[i].Cells[j];
                if (cell.Value != null && int.TryParse(cell.Value.ToString(), out int cellValue))
                {
                    matrix[i, j] = cellValue;
                }
            }
        }

        // Поиск максимальных элементов в столбцах и вывод результатов
        for (int j = 0; j < matrix.Cols; j++)
        {
            int max = matrix.FindMaxInColumn(j);
            MessageBox.Show($"Максимальный элемент в столбце {j + 1}: {max}");
        }
    }

    private void MainForm_Load(object sender, EventArgs e)
    {
        // Количество строк и столбцов по-умолчанию
        int rowCount = 3; // 3 строки
        int colCount = 2; // 2 столбца

        // Очистка DataGridView перед добавлением столбцов и строк
        dataGridView1.Rows.Clear();
        dataGridView1.Columns.Clear();

        // Столбцы с указанием типа данных (Int)
        for (int i = 0; i < colCount; i++)
        {
            var column = new DataGridViewTextBoxColumn();
            column.Name = $"Столбец {i}";
            column.HeaderText = $"Столбец {i}";
            dataGridView1.Columns.Add(column);
        }

        // Добавляем строки в DataGridView
        for (int i = 0; i < rowCount; i++)
        {
            dataGridView1.Rows.Add();
        }
    }
}
