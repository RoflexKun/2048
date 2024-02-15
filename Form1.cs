namespace Atestat
{
    public partial class Form1 : Form
    {
        public int[,] map = new int[4, 4];
        public Label[,] puteri = new Label[4, 4];
        public PictureBox[,] pics = new PictureBox[4, 4];
        private int scor = 0;
        public Form1()
        {
            MessageBox.Show("Cum se joacă:" +'\n' + '\n' + "Folosește săgețile de pe tastatură pentru a uni pătrațele cu același număr. Continuă până ajungi la 2048." + '\n' + '\n' + "Butoane pentru a te mișca:" + '\n' + '\n' + "←: săgeată stânga" + '\n' + "→: săgeată dreapta" + '\n' + "↑: săgeată sus" + '\n' + "↓: săgeată jos", "Instrucțiuni");
            InitializeComponent();
            this.KeyDown += new KeyEventHandler(_keyboardEvent);
            lbl_value.Text = Properties.Settings.Default.h_score;
            /// Pentru a reseta scorul maxim: decomenteaza urmatoarele 3 linii de cod
            ///lbl_value.Text = "0";
            ///Properties.Settings.Default.h_score = lbl_value.Text;
            ///Properties.Settings.Default.Save();
            map[0, 0] = 1;
            map[1, 0] = 1;
            map[0, 1] = 1;
            createMap();
            createPics();
            genPics();
        }

        private void createMap()
        {
            for(int i= 0; i < 4; i++)
            {
                for(int j=0;j < 4; j++)
                {
                    PictureBox pic = new PictureBox();
                    pic.Location = new Point(23 + 76*j, 126 + 76*i);
                    pic.Size = new Size(70, 70);
                    pic.BackColor = Color.Gray;
                    this.Controls.Add(pic);
                }
            }
           
        }
        private void genPics()
        {
            Random rnd = new Random();
            int a = rnd.Next(0, 4);
            int b = rnd.Next(0, 4);
            while (pics[a, b]!= null)
            {
                a = rnd.Next(0, 4);
                b = rnd.Next(0, 4); 
            }
            map[a, b] = 1;
            pics[a, b] = new PictureBox();
            puteri[a, b] = new Label();
            puteri[a, b].Text = "2";
            puteri[a, b].TextAlign = ContentAlignment.MiddleCenter;
            puteri[a, b].Size = new Size(76, 76);
            puteri[a, b].Font = new Font(new FontFamily("Cooper Black"), 16);
            pics[a, b].Controls.Add(puteri[a, b]);
            pics[a, b].Location = new Point(23+b*76, 126 + a*76);
            pics[a, b].Size = new Size(70, 70);
            pics[a, b].BackColor = Color.MintCream;
            this.Controls.Add(pics[a, b]);
            pics[a, b].BringToFront();

        }
        private void createPics()
        {
            pics[0, 0] = new PictureBox();
            puteri[0,0] = new Label();
            puteri[0, 0].Text = "2";
            puteri[0, 0].TextAlign = ContentAlignment.MiddleCenter;
            puteri[0, 0].Size = new Size(76, 76);
            puteri[0, 0].Font = new Font(new FontFamily("Cooper Black"), 16);
            pics[0, 0].Controls.Add(puteri[0, 0]);
            pics[0, 0].Location = new Point(23, 126);
            pics[0, 0].Size = new Size(70, 70);
            pics[0, 0].BackColor = Color.MintCream;
            this.Controls.Add(pics[0, 0]);
            pics[0, 0].BringToFront();

           
            pics[0, 1] = new PictureBox();
            puteri[0, 1] = new Label();
            puteri[0, 1].Text = "2";
            puteri[0, 1].TextAlign = ContentAlignment.MiddleCenter;
            puteri[0, 1].Size = new Size(76, 76);
            puteri[0, 1].Font = new Font(new FontFamily("Cooper Black"), 16);
            pics[0, 1].Controls.Add(puteri[0, 1]);
            pics[0, 1].Location = new Point(99, 126);
            pics[0, 1].Size = new Size(70, 70);
            pics[0, 1].BackColor = Color.MintCream;
            this.Controls.Add(pics[0, 1]);
            pics[0, 1].BringToFront();

            
            pics[1, 0] = new PictureBox();
            puteri[1, 0] = new Label();
            puteri[1, 0].Text = "4";
            puteri[1, 0].TextAlign = ContentAlignment.MiddleCenter;
            puteri[1, 0].Size = new Size(76, 76);
            puteri[1, 0].Font = new Font(new FontFamily("Cooper Black"), 16);
            pics[1, 0].Controls.Add(puteri[1, 0]);
            pics[1, 0].Location = new Point(23, 202);
            pics[1, 0].Size = new Size(70, 70);
            pics[1, 0].BackColor = Color.Wheat;
            this.Controls.Add(pics[1, 0]);
            pics[1, 0].BringToFront();
        }

        private void changeColor(int sum, int i, int j)
        {
            if (sum % 2048 == 0)
                pics[i, j].BackColor = Color.DarkOrange;
            else if (sum % 1024 == 0)
                pics[i, j].BackColor = Color.OrangeRed;
            else if (sum % 512 == 0)
                pics[i, j].BackColor = Color.Coral;
            else if (sum % 256 == 0)
                pics[i, j].BackColor = Color.Magenta;
            else if (sum % 128 == 0)
                pics[i, j].BackColor = Color.MediumPurple;
            else if (sum % 64 == 0)
                pics[i, j].BackColor = Color.Crimson;
            else if (sum % 32 == 0)
                pics[i, j].BackColor = Color.PaleVioletRed;
            else if (sum % 16 == 0)
                pics[i, j].BackColor = Color.LightPink;
            else if (sum % 8 == 0)
                pics[i, j].BackColor = Color.Beige;
            else if (sum % 4 == 0)
                pics[i, j].BackColor = Color.Wheat;
        }
        private void _keyboardEvent(object? sender, KeyEventArgs e)
        {
            bool ok = false;
            switch (e.KeyCode.ToString()) 
            {
                case "Right":
                    for(int k=0; k <= 3; k ++ )
                    {
                        for(int l = 2; l >= 0; l--)
                        {
                            if (map[k, l] == 1)
                            {
                                for(int j = l+1; j <= 3; j++)
                                    {
                                        if (map[k, j] == 0)
                                        {
                                            ok = true;
                                            map[k, j - 1] = 0;
                                            map[k, j] = 1;   
                                            pics[k, j] = pics[k, j - 1];
                                            pics[k, j - 1] = null;
                                            puteri[k, j] = puteri[k, j - 1];
                                            puteri[k, j - 1] = null;
                                            pics[k, j].Location = new Point(pics[k, j].Location.X + 76, pics[k, j].Location.Y);
                                        }
                                        else
                                    {
                                        int a = int.Parse(puteri[k, j].Text);
                                        int b = int.Parse(puteri[k, j - 1].Text);
                                        if(a == b)
                                        {
                                            ok = true;
                                            puteri[k, j].Text = (a+b).ToString();
                                            scor += (a + b);
                                            int x = int.Parse(lbl_value.Text);
                                            if (x <= scor)
                                            {
                                                lbl_value.Text = scor.ToString();
                                                Properties.Settings.Default.h_score = lbl_value.Text;
                                                Properties.Settings.Default.Save();
                                            }
                                            changeColor(a + b, k, j);
                                            scor_curent.Text = "Scor Curent: " + scor;
                                            map[k, j - 1] = 0;
                                            this.Controls.Remove(pics[k, j - 1]);
                                            this.Controls.Remove(puteri[k, j - 1]);
                                            pics[k, j - 1] = null;
                                            puteri[k, j - 1] = null;
                                        }
                                    }
                                    }
                            }
                        }
                    }
                    
                    break;

                case "Left":
                    for (int k = 0; k <= 3; k++)
                    {
                        for (int l = 0; l <= 3 ; l++)
                        {
                            if (map[k, l] == 1)
                            {
                                for (int j = l-1; j >= 0; j--)
                                {
                                    if (map[k, j] == 0)
                                    {
                                        ok = true;
                                        map[k, j + 1] = 0;
                                        map[k, j] = 1;
                                        pics[k, j] = pics[k, j + 1];
                                        pics[k, j + 1] = null;
                                        puteri[k, j] = puteri[k, j + 1];
                                        puteri[k, j + 1] = null;
                                        pics[k, j].Location = new Point(pics[k, j].Location.X - 76, pics[k, j].Location.Y);
                                    }
                                    else
                                    {
                                        int a = int.Parse(puteri[k, j].Text);
                                        int b = int.Parse(puteri[k, j + 1].Text);
                                        if (a == b)
                                        {
                                            ok = true;
                                            puteri[k, j].Text = (a + b).ToString();
                                            scor += (a + b);
                                            int x = int.Parse(lbl_value.Text);
                                            if (x <= scor)
                                            {
                                                lbl_value.Text = scor.ToString();
                                                Properties.Settings.Default.h_score = lbl_value.Text;
                                                Properties.Settings.Default.Save();
                                            }
                                            changeColor(a + b, k, j);
                                            scor_curent.Text = "Scor Curent: " + scor;
                                            map[k, j + 1] = 0;
                                            this.Controls.Remove(pics[k, j + 1]);
                                            this.Controls.Remove(puteri[k, j + 1]);
                                            pics[k, j + 1] = null;
                                            puteri[k, j + 1] = null;
                                        }
                                    }

                                }
                            }
                        }
                    }
                    
                    break;

                case "Down":
                    for (int k = 2; k >= 0 ; k--)
                    {
                        for (int l = 0; l <= 3; l++)
                        {
                            if (map[k, l] == 1)
                            {
                                for (int j =k + 1; j <= 3; j++)
                                {
                                    if (map[j, l] == 0)
                                    {
                                        ok = true;
                                        map[j - 1, l] = 0;
                                        map[j, l] = 1;
                                        pics[j, l] = pics[j - 1, l];
                                        pics[j - 1, l] = null;
                                        puteri[j, l] = puteri[j - 1, l];
                                        puteri[j - 1, l] = null;
                                        pics[j, l].Location = new Point(pics[j, l].Location.X , pics[j, l].Location.Y + 76);
                                    }
                                    else
                                    {
                                        int a = int.Parse(puteri[j, l].Text);
                                        int b = int.Parse(puteri[j-1, l].Text);
                                        if (a == b)
                                        {
                                            ok = true;
                                            puteri[j, l].Text = (a + b).ToString();
                                            scor += (a + b);
                                            int x = int.Parse(lbl_value.Text);
                                            if (x <= scor)
                                            {
                                                lbl_value.Text = scor.ToString();
                                                Properties.Settings.Default.h_score = lbl_value.Text;
                                                Properties.Settings.Default.Save();
                                            }
                                            changeColor(a + b, j, l);
                                            scor_curent.Text = "Scor Curent: " + scor;
                                            map[j - 1, l] = 0;
                                            this.Controls.Remove(pics[j - 1, l]);
                                            this.Controls.Remove(puteri[j - 1, l]);
                                            pics[j - 1, l] = null;
                                            puteri[j - 1, l] = null;
                                        }
                                    }

                                }
                            }
                        }
                    }
                   
                    break;

                case "Up":
                    for (int k = 0; k <= 3; k++)
                    {
                        for (int l = 0; l <= 3; l++)
                        {
                            if (map[k, l] == 1)
                            {
                                for (int j = k - 1; j >= 0; j--)
                                {
                                    if (map[j, l] == 0)
                                    {
                                        ok = true;
                                        map[j + 1, l] = 0;
                                        map[j, l] = 1;
                                        pics[j, l] = pics[j + 1, l];
                                        pics[j + 1, l] = null;
                                        puteri[j, l] = puteri[j + 1, l];
                                        puteri[j + 1, l] = null;
                                        pics[j, l].Location = new Point(pics[j, l].Location.X, pics[j, l].Location.Y - 76);
                                    }
                                    else
                                    {
                                        int a = int.Parse(puteri[j, l].Text);
                                        int b = int.Parse(puteri[j + 1, l].Text);
                                        if (a == b)
                                        {
                                            ok = true;
                                            puteri[j, l].Text = (a + b).ToString();
                                            scor += (a + b);
                                            int x = int.Parse(lbl_value.Text);
                                            if (x <= scor)
                                            {
                                                lbl_value.Text = scor.ToString();
                                                Properties.Settings.Default.h_score = lbl_value.Text;
                                                Properties.Settings.Default.Save();
                                            }
                                                
                                            changeColor(a + b, j, l);
                                            scor_curent.Text = "Scor Curent: " + scor;
                                            map[j + 1, l] = 0;
                                            this.Controls.Remove(pics[j + 1, l]);
                                            this.Controls.Remove(puteri[j + 1, l]);
                                            pics[j + 1, l] = null;
                                            puteri[j + 1, l] = null;
                                        }
                                    }

                                }
                            }
                        }
                    }
                    
                    break;
            }
            if (ok)
                genPics();
        }
        
        private void scor_curent_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}