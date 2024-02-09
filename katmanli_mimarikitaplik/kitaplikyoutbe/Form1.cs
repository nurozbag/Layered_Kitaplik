using kitaplikyoutbe.DAL;
using kitaplikyoutbe.Entities;

namespace kitaplikyoutbe
{
    public partial class Form1 : Form
    {
        AppDbContext _context = new AppDbContext();
        int BookdelId = 0;
        public Form1()
        {
            InitializeComponent();
            dataGridView1.DataSource = _context.Categories.ToList();
            dataGridView2.DataSource = _context.Authors.ToList();
            dataGridView3.DataSource = _context.Publishers.ToList();
            dataGridView4.DataSource = _context.Books.ToList();
            comboBox1.DataSource = _context.Categories.ToList();
            comboBox1.DisplayMember = "Name";
            comboBox1.ValueMember = "Id";
            comboBox2.DataSource = _context.Authors.ToList();
            comboBox2.DisplayMember = "Name";
            comboBox2.ValueMember = "Id";
            comboBox3.DataSource = _context.Publishers.ToList();
            comboBox3.DisplayMember = "Name";
            comboBox3.ValueMember = "Id";
            button5.Enabled = false;



        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                category category = new category();
                category.Name = textBox1.Text;
                _context.Categories.Add(category);
                _context.SaveChanges();

                dataGridView1.DataSource = _context.Categories.ToList();
                textBox1.Text = "";
                comboBox1.DataSource = _context.Categories.ToList();
                comboBox1.DisplayMember = "Name";
                comboBox1.ValueMember = "Id";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "")
            {
                Author author=new Author();
                author.Name = textBox2.Text;
                _context.Authors.Add(author);
                _context.SaveChanges();

                dataGridView2.DataSource=_context.Authors.ToList();
                textBox2.Text = "";
                comboBox2.DataSource = _context.Authors.ToList();
                comboBox2.DisplayMember = "Name";
                comboBox2.ValueMember = "Id";
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox3.Text != "")
            {
                Publisher publisher = new Publisher();
                publisher.Name = textBox3.Text;
                _context.Publishers.Add(publisher);
                _context.SaveChanges();

                dataGridView3.DataSource = _context.Publishers.ToList();
                textBox3.Text = "";
                comboBox3.DataSource = _context.Publishers.ToList();
                comboBox3.DisplayMember = "Name";
                comboBox3.ValueMember = "Id";
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if(textBox4.Text != "" && textBox5.Text!= "")
            {
                Book book = new Book();
                book.Name=textBox4.Text;
                book.ISBN = textBox5.Text;
                book.categoryId=Int32.Parse(comboBox1.SelectedValue.ToString());
                book.AuthorId = Int32.Parse(comboBox2.SelectedValue.ToString());
                book.PublisherId = Int32.Parse(comboBox3.SelectedValue.ToString());

                _context.Books.Add(book);
                _context.SaveChanges();
                dataGridView4.DataSource=_context.Books.ToList();
                textBox4.Text = "";
                textBox5.Text = "";

            }
        }

        private void dataGridView4_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex == 0)
            {
                DataGridViewRow row = dataGridView4.Rows[e.RowIndex];
                BookdelId = Int32.Parse(row.Cells[0].Value.ToString());
                button5.Enabled = true;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Book deleteBook = _context.Books.Find(BookdelId);
            if(deleteBook != null)
            {
                _context.Books.Remove(deleteBook);
                _context.SaveChanges();
                dataGridView4.DataSource=_context.Books.ToList();
            }
        }
    }
}