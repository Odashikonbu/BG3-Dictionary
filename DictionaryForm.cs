namespace BG3_Dictionary
{
    using LiteDB;
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Data;
    using System.Drawing;
    using System.IO;
    using System.Linq;
    using System.Windows.Forms;
    using System.Xml.Linq;
    using static System.Windows.Forms.VisualStyles.VisualStyleElement;

    public struct TranslationData
    {
        public ObjectId ID { get; set; }
        public string UUID { get; set; }
        public string SourceLang { get; set; }
        public string TransLang { get; set; }
    }

    /// <summary>
    /// Defines the <see cref="Top" />
    /// </summary>
    public partial class Top : Form
    {
        private string DBPath = "translation.db";

        /// <summary>
        /// Initializes a new instance of the <see cref="Top"/> class.
        /// </summary>
        public Top()
        {
            InitializeComponent();

            //DataGridView幅設定
            SetupDataGridView();
        }
        private void SetupDataGridView()
        {
            SerchResult.AutoGenerateColumns = false;
            SerchResult.AllowUserToAddRows = false;
            SerchResult.Columns.Clear();

            // 行の高さ1.5倍に設定
            SerchResult.RowTemplate.Height = (int)(SerchResult.RowTemplate.Height * 1.5);
            SerchResult.RowHeadersWidth = 10;

            int hi = SerchResult.Height;
            int ch = SerchResult.ColumnHeadersHeight;
            int h = SerchResult.RowTemplate.Height;
            int n = (hi - ch) / h;
            hi = ch + h * n + 2;

            SerchResult.Height = hi;


            // UUID
            DataGridViewTextBoxColumn uuidColumn = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "UUID",
                HeaderText = "uuid",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                FillWeight = 10 // 比率 1
            };
            SerchResult.Columns.Add(uuidColumn);

            // 原文
            DataGridViewTextBoxColumn sourceLangColumn = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "SourceLang",
                HeaderText = "原文",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                FillWeight = 30 // 比率 2
            };
            SerchResult.Columns.Add(sourceLangColumn);

            // 訳文
            DataGridViewTextBoxColumn transLangColumn = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "TransLang",
                HeaderText = "訳文",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                FillWeight = 60 // 比率 2
            };
            SerchResult.Columns.Add(transLangColumn);

            // 自動的にカラム幅を調整するように設定
            SerchResult.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        }

        /// <summary>
        /// The Top_Load
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/></param>
        /// <param name="e">The e<see cref="EventArgs"/></param>
        private void Top_Load(object sender, EventArgs e)
        {

            using (var db = new LiteDatabase(DBPath))
            {
                var collection = db.GetCollection<TranslationData>("TranslationData");
                // インデックス付ける
                collection.EnsureIndex(x => x.ID);

                var data = collection.Find(Query.All(), limit: 20).ToList();

                if (data.Count > 0)
                {
                    SerchResult.DataSource = data;
                    SerchResult.Visible = data.Count >= 20;
                }
                else
                {
                    SerchResult.Visible = false;
                }
            }
        }

        /// <summary>
        /// The SearchBox_KeyPress
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/></param>
        /// <param name="e">The e<see cref="KeyPressEventArgs"/></param>
        private void SearchBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                SearchButton_Click(sender, e);
                e.Handled = true;
            }
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            string searchText = Search_Box.Text.Trim();
            if (!string.IsNullOrEmpty(searchText))
            {
                Search_Box.Enabled = false;
                SearchButton.Enabled = false;
                using (var db = new LiteDatabase(DBPath))
                {
                    var collection = db.GetCollection<TranslationData>("TranslationData");
                    var result = collection.Find(x => x.SourceLang.Contains(searchText)).Select(x => new TranslationData
                    {
                        UUID = x.UUID,
                        SourceLang = x.SourceLang,
                        TransLang = x.TransLang
                    }).ToList(); ;

                    if (result.Count > 0)
                    {
                        SetupDataGridView();
                        SerchResult.DataSource = result;
                        SerchResult.Visible = true;
                    }
                    else
                    {
                        SerchResult.Visible = false;
                    }

                }
                Search_Box.Enabled = true;
                SearchButton.Enabled = true;
            }
               
        }



        private void CreateDictionaryButton_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog
                {
                    Filter = "XML files (*.xml)|*.xml",
                    Title = "英語XMLファイルを選択してください"
                };

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string sourceXML = openFileDialog.FileName;

                    openFileDialog.Reset();
                    openFileDialog.Title = "日本語XMLファイルを選択してください";

                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        string transXML = openFileDialog.FileName;

                        // XML読み込み
                        XDocument sourceDoc = XDocument.Load(sourceXML);
                        XDocument translationDoc = XDocument.Load(transXML);

                        // XML辞書化
                        var sourceSentences = sourceDoc.Descendants("content")
                            .ToDictionary(x => (string)x.Attribute("contentuid"), x => (string)x);
                        var translationSentences = translationDoc.Descendants("content")
                            .ToDictionary(x => (string)x.Attribute("contentuid"), x => (string)x);

                        // 比較翻訳結果を格納
                        List<TranslationData> langDatasets = new List<TranslationData>();

                        int id = 1;
                        // uuidをキーに対訳
                        foreach (var uid in sourceSentences.Keys)
                        {
                            if (translationSentences.ContainsKey(uid))
                            {
                                string sourceWord = sourceSentences[uid];
                                string transWord = translationSentences[uid];

                                langDatasets.Add(new TranslationData
                                {
                                    UUID = uid,
                                    SourceLang = sourceWord,
                                    TransLang = transWord
                                });
                                id++;
                            }
                        }
                        InsertDB(DBPath, langDatasets);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"データのインポート中にエラーが発生しました。\n\n{ex.Message}", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InsertDB(string dbPath, List<TranslationData> list)
        {
            using (var db = new LiteDatabase(dbPath))
            {
                var collection = db.GetCollection<TranslationData>("TranslationData");
                collection.DeleteAll();

                // DB構築
                collection.InsertBulk(list);
                MessageBox.Show($"Creating Dictionary Complete", "Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
        
       
