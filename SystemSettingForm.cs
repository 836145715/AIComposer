using AIComposer.AISupport;
using AntdUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace AIComposer
{
    public partial class SystemSettingForm : AntdUI.Window
    {

        public SystemSettingForm()
        {
            InitializeComponent();
            CenterToScreen();
        }

        private void SystemSettingForm_Load(object sender, EventArgs e)
        {
            LoadSetting();
            InitAiSelect();
            InitTable();
        }

        private void LoadSetting()
        {
            var setting = Program.Setting;
            if (setting.ShowHotkey != null)
            {
                buttonShowHotKey.Text = "显示窗口热键：" + setting.ShowHotkey.ToString();
            }
            else
            {
                buttonShowHotKey.Text = "显示窗口热键：未注册";
            }
            if (setting.AskHotkey != null)
            {
                buttonAskHotKey.Text = "发起提问热键：" + setting.AskHotkey.ToString();
            }
            else
            {
                buttonAskHotKey.Text = "发起提问热键：未注册";
            }
        }


        private void InitAiSelect()
        {
            selectAi.Items.Clear();
            foreach (var ai in Program.AIList)
            {
                selectAi.Items.Add(ai.Description);
            }
        }


        private List<AntdUI.AntItem[]> _aiList = new List<AntItem[]>();

        private void InitTable()
        {
            tableAI.Columns = new ColumnCollection() {
                new ColumnCheck("Selected","启用"){Fixed = true},
                new Column("Name", "名称",ColumnAlign.Center),
                new Column("Url", "地址"),
                new Column("Description", "介绍",ColumnAlign.Left){Width = "200" },
                new Column("Proxy","代理"),
                new Column("Operator","操作"),
            };

            var setting = Program.Setting;
            foreach (var aiSetting in setting.AISettings)
            {
                var ai = Program.AIList.FirstOrDefault(x => x.Key == aiSetting.Key);
                if (ai == null)
                {
                    continue;
                }
                AddAiToTable(ai.Name, ai.Description, ai.Url, ai.Key, aiSetting.Enabled);
            }

            tableAI.DataSource = _aiList;

            tableAI.CellButtonClick += (sender, args) =>
            {
                if (args.ColumnIndex == 2)
                {
                    //打开指定网址
                    System.Diagnostics.Process.Start(args.Btn.Id);
                }

                if (args.ColumnIndex == 5)
                {
                    var index = args.RowIndex - 1;
                    if (args.Btn.Id == "Delete")
                    {
                        _aiList.RemoveAt(index);
                    }

                    if (args.Btn.Id == "Up")
                    {
                        if (index <= 0)
                        {
                            return;
                        }

                        (_aiList[index], _aiList[index - 1]) = (_aiList[index - 1], _aiList[index]);
                    }

                    if (args.Btn.Id == "Down")
                    {
                        if (index >= _aiList.Count - 1)
                        {
                            return;
                        }
                        (_aiList[index], _aiList[index + 1]) = (_aiList[index + 1], _aiList[index]);
                    }

                    tableAI.DataSource = _aiList;
                }

                Console.WriteLine(args);
            };


        }

        private void AddAiToTable(string name, string desc, string url, string key, bool sel = false)
        {
            _aiList.Add(new AntItem[]
            {
                new AntItem("Selected",sel),
                new AntItem("Name",name),
                new AntItem("Description",desc),
                new AntItem("Url",new CellLink(url,"官网地址")),
                new AntItem("Proxy",inputProxy.Text),
                new AntItem("Operator",new CellButton[]
                {
                    new CellButton("Up","向上",TTypeMini.Primary),
                    new CellButton("Down","向下",TTypeMini.Primary),
                    new CellButton("Delete","删除",TTypeMini.Error)
                }),
                new AntItem("Key",key),
            });
            tableAI.DataSource = _aiList;
        }


        private void buttonShowHotKey_Click(object sender, EventArgs e)
        {
            using (var dialog = new HotkeyInputForm())
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    Program.Setting.ShowHotkey = dialog.Hotkey;
                }
            }
            LoadSetting();
        }

        private void buttonAskHotKey_Click(object sender, EventArgs e)
        {
            using (var dialog = new HotkeyInputForm())
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    Program.Setting.AskHotkey = dialog.Hotkey;
                }
            }
            LoadSetting();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            SaveAiSetting();
            DialogResult = DialogResult.OK;
        }

        protected override bool ProcessCmdKey(ref System.Windows.Forms.Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.S))
            {
                buttonOk_Click(null, null);
                return true;
            }
            if (keyData == (Keys.Escape))
            {
                buttonCancel_Click(null, null);
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void buttonAddAi_Click(object sender, EventArgs e)
        {
            if (selectAi.SelectedIndex < 0)
            {
                AntdUI.Message.error(this, "请选择一个AI");
                return;
            }
            var ai = Program.AIList[selectAi.SelectedIndex];
            AddAiToTable(ai.Name, ai.Description, ai.Url, ai.Key, false);
        }

        private void SaveAiSetting()
        {
            Program.Setting.AISettings.Clear();
            foreach (var item in _aiList)
            {
                var aiSetting = new AISetting()
                {
                    Key = item[6].value.ToString(),
                    Enabled = item[0].value.ToString() == "True",
                    Proxy = item[4].value?.ToString()
                };
                Program.Setting.AISettings.Add(aiSetting);
            }
        }

    }
}
