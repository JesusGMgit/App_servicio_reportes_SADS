using System;
using System.Windows.Forms;
using System.Drawing;

namespace app_servicio_SADS2
{
    class inputboxvb
    {
        public static string InputBox(string title, string promptText, ref string value)
        {
            Form form = new Form();
            Label label = new Label();
            TextBox textBox = new TextBox();
            Button buttonOk = new Button();
            Button buttonCancel = new Button();
            int numero_int;

            bool es_o_no_numerico;
            form.Text = title;
            label.Text = promptText;
            textBox.Text = value;

            if (title=="CONTRASEÑA")
            {
                textBox.PasswordChar = '+';
            }                    

            buttonOk.Text = "OK";
            buttonCancel.Text = "Cancel";
            buttonOk.DialogResult = DialogResult.OK;
            buttonCancel.DialogResult = DialogResult.Cancel;

            label.SetBounds(9, 20, 372, 13);
            textBox.SetBounds(12, 36, 372, 20);
            buttonOk.SetBounds(228, 72, 75, 23);
            buttonCancel.SetBounds(309, 72, 75, 23);

            label.AutoSize = true;
            textBox.Anchor = textBox.Anchor | AnchorStyles.Right;
            buttonOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

            form.ClientSize = new Size(396, 107);
            form.Controls.AddRange(new Control[] { label, textBox, buttonOk, buttonCancel });
            form.ClientSize = new Size(Math.Max(300, label.Right + 10), form.ClientSize.Height);
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.MinimizeBox = false;
            form.MaximizeBox = false;
            form.AcceptButton = buttonOk;
            form.CancelButton = buttonCancel;

            DialogResult dialogResult = form.ShowDialog();
            
            if(title=="Tiempo de poleo")
            {
                es_o_no_numerico = int.TryParse(textBox.Text, out numero_int);
                if (!es_o_no_numerico)
                {
                    textBox.Text="";
                }
            }
                
            
            return value = textBox.Text;
            //return dialogResult;
        }
    }
}
