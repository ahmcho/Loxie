using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using System.IO;
using System.Threading;

namespace Loxie
{
    public partial class Main : Form
    {
        bool listShow1 = false;
        bool listShow2 = false;
        string keyword1 = ":";
        string keyword2 = "@";
        string path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\config.loxie";
        int count = 0;
        //=======================================================UserInterface=======================================//
        public Main()
        {
            if (!File.Exists(path))
            {
                TextWriter tw = new StreamWriter(path);
                tw.WriteLine("[Application]");
                tw.WriteLine("FirstStart = true");
                tw.Close();
                Thread t = new Thread(new ThreadStart(SplashScreen));
                t.Start();
                Thread.Sleep(3000);
                this.StartPosition = FormStartPosition.CenterScreen;
                InitializeComponent();
                t.Abort();
            }
            else if (File.Exists(path))
            {
                TextWriter tw1 = new StreamWriter(path);
                tw1.WriteLine("[Run]");
                tw1.WriteLine("ApplicationRunTime={0}", DateTime.Now);
                tw1.Close();
                InitializeComponent();
            }
        }
        public void formload()
        {
            Application.Run(new Main());
        }
        public void SplashScreen()
        {
            Application.Run(new Splash());
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            htmlTemplate();
            this.browserWindow.Navigate("about:blank");
            HtmlDocument doc = this.browserWindow.Document;
            doc.Write(string.Empty);
            this.browserWindow.DocumentText = textArea.Text;
        }
        private void textArea_TextChanged(object sender, EventArgs e)
        {
            browserWindow.DocumentText = textArea.Text;
        }
        private void htmlTemplate()
        {
            TandB.ColumnCount = 2;
            TandB.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            TandB.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TandB.Location = new Point(12, 110);
            if (this.Controls.OfType<TableLayoutPanel>().FirstOrDefault(y => y.Name == "tableMenu") != null)
            {
                this.Controls.OfType<TableLayoutPanel>().FirstOrDefault(y => y.Name == "tableMenu").Dispose();
            }
            for (int i = this.Controls.Count - 1; i >= 0; i--)
            {
                Button control = this.Controls[i] as Button;
                //ListBox control1 = this.Controls[i] as ListBox;

                if (control == null)// && control1 == null)
                    continue;
                control.Visible = false;
                control.Dispose();
                //control1.Dispose();
            }
            textArea.Clear();
            textArea.AppendText("<html>  \n");
            textArea.AppendText("<head> \r \n");
            textArea.AppendText("<title>A website</title> \n");
            textArea.AppendText("<meta http-equiv=\"Content - Type\" content=\"text / html; charset = utf - 8\"> \n");
            textArea.AppendText("\n");
            textArea.AppendText("</head> \n");
            textArea.AppendText("<body> \n");
            textArea.AppendText("<header>\n</header>\n");
            textArea.AppendText("\n");
            textArea.AppendText("<p>Hello,world!</p>\n");
            textArea.AppendText("<footer> \n");
            textArea.AppendText("Copyright &copy yourName \n");
            textArea.AppendText("</footer> \n");
            textArea.AppendText("</body> \n");
            textArea.AppendText("</html> \n");
            //
            // button
            // 
            Button btn = new Button();
            btn.Anchor = System.Windows.Forms.AnchorStyles.Left;
            btn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            btn.Font = new System.Drawing.Font("Palatino Linotype", 8.25F);
            btn.Location = new System.Drawing.Point(697, 35);
            btn.Name = "btn";
            btn.Size = new System.Drawing.Size(64, 31);
            btn.Text = "button";
            btn.Click += new System.EventHandler(this.btn_Click);
            // 
            // div
            // 
            Button divBtn = new Button();
            divBtn.Anchor = System.Windows.Forms.AnchorStyles.Left;
            divBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            divBtn.Font = new System.Drawing.Font("Palatino Linotype", 8.25F);
            divBtn.Location = new System.Drawing.Point(635, 35);
            divBtn.Name = "divBtn";
            divBtn.Size = new System.Drawing.Size(59, 31);
            divBtn.Text = "<div>";
            divBtn.Click += new System.EventHandler(this.divBtn_Click);
            // 
            // link
            // 
            Button linkBtn = new Button();
            linkBtn.Anchor = System.Windows.Forms.AnchorStyles.Left;
            linkBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            linkBtn.Font = new System.Drawing.Font("Palatino Linotype", 8.25F);
            linkBtn.Location = new System.Drawing.Point(577, 35);
            linkBtn.Name = "linkBtn";
            linkBtn.Size = new System.Drawing.Size(55, 31);
            linkBtn.Text = "link";
            linkBtn.Click += new System.EventHandler(this.linkBtn_Click);
            // 
            // youtube
            // 
            Button youtube = new Button();
            youtube.Anchor = System.Windows.Forms.AnchorStyles.Left;
            youtube.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            youtube.Font = new System.Drawing.Font("Palatino Linotype", 8.25F);
            youtube.Location = new System.Drawing.Point(505, 35);
            youtube.Name = "youtube";
            youtube.Size = new System.Drawing.Size(69, 31);
            youtube.Text = "youtube";
            youtube.Click += new System.EventHandler(this.youtube_Click);
            // 
            // audio
            // 
            Button audioBtn = new Button();
            audioBtn.Anchor = System.Windows.Forms.AnchorStyles.Left;
            audioBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            audioBtn.Font = new System.Drawing.Font("Palatino Linotype", 8.25F);
            audioBtn.Location = new System.Drawing.Point(446, 35);
            audioBtn.Name = "audioBtn";
            audioBtn.Size = new System.Drawing.Size(56, 31);
            audioBtn.Text = "audio";
            audioBtn.UseVisualStyleBackColor = true;
            audioBtn.Click += new System.EventHandler(this.audioBtn_Click);
            // 
            // quote
            // 
            Button sitatBtn = new Button();
            sitatBtn.Anchor = System.Windows.Forms.AnchorStyles.Left;
            sitatBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            sitatBtn.Font = new System.Drawing.Font("Palatino Linotype", 8.25F);
            sitatBtn.Location = new System.Drawing.Point(381, 35);
            sitatBtn.Name = "sitatBtn";
            sitatBtn.Size = new System.Drawing.Size(62, 31);
            sitatBtn.Text = "quote";
            sitatBtn.Click += new System.EventHandler(this.sitatBtn_Click);
            // 
            // abbr
            // 
            Button abbreviature = new Button();
            abbreviature.Anchor = System.Windows.Forms.AnchorStyles.Left;
            abbreviature.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            abbreviature.Font = new System.Drawing.Font("Palatino Linotype", 8.25F);
            abbreviature.Location = new System.Drawing.Point(309, 35);
            abbreviature.Name = "abbreviature";
            abbreviature.Size = new System.Drawing.Size(69, 31);
            abbreviature.Text = "abbr";
            abbreviature.Click += new System.EventHandler(this.abbreviature_Click);
            // 
            // image
            // 
            Button imgBtn = new Button();
            imgBtn.Anchor = System.Windows.Forms.AnchorStyles.Left;
            imgBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            imgBtn.Font = new System.Drawing.Font("Palatino Linotype", 8.25F);
            imgBtn.Location = new System.Drawing.Point(247, 35);
            imgBtn.Name = "imgBtn";
            imgBtn.Size = new System.Drawing.Size(59, 31);
            imgBtn.Text = "image";
            imgBtn.UseVisualStyleBackColor = true;
            imgBtn.Click += new System.EventHandler(this.imgBtn_Click);
            // 
            // comment
            // 
            Button commentBtn = new Button();
            commentBtn.Anchor = System.Windows.Forms.AnchorStyles.Left;
            commentBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            commentBtn.Font = new System.Drawing.Font("Palatino Linotype", 8.25F);
            commentBtn.Location = new System.Drawing.Point(193, 35);
            commentBtn.Name = "commentBtn";
            commentBtn.Size = new System.Drawing.Size(51, 31);
            commentBtn.Text = "<! ->";
            commentBtn.Click += new System.EventHandler(this.commentBtn_Click);
            // 
            // video
            // 
            Button video = new Button();
            video.Anchor = System.Windows.Forms.AnchorStyles.Left;
            video.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            video.Font = new System.Drawing.Font("Palatino Linotype", 8.25F);
            video.Location = new System.Drawing.Point(124, 35);
            video.Name = "video";
            video.Size = new System.Drawing.Size(66, 31);
            video.Text = "video";
            video.UseVisualStyleBackColor = true;
            video.Click += new System.EventHandler(this.video_Click);
            // 
            // code
            //
            Button scriptBtn = new Button();
            scriptBtn.Anchor = System.Windows.Forms.AnchorStyles.Left;
            scriptBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            scriptBtn.Font = new System.Drawing.Font("Palatino Linotype", 8.25F);
            scriptBtn.Location = new System.Drawing.Point(61, 35);
            scriptBtn.Name = "scriptBtn";
            scriptBtn.Size = new System.Drawing.Size(60, 31);
            scriptBtn.Text = "code";
            scriptBtn.Click += new System.EventHandler(this.scriptBtn_Click);
            // 
            // text
            // 
            Button textAreaBtn = new Button();
            textAreaBtn.Anchor = System.Windows.Forms.AnchorStyles.Left;
            textAreaBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            textAreaBtn.Font = new System.Drawing.Font("Palatino Linotype", 8.25F);
            textAreaBtn.Location = new System.Drawing.Point(0, 35);
            textAreaBtn.Name = "textAreaBtn";
            textAreaBtn.Size = new System.Drawing.Size(58, 31);
            textAreaBtn.Text = "text";
            textAreaBtn.UseVisualStyleBackColor = true;
            textAreaBtn.Click += new System.EventHandler(this.textAreaBtn_Click);
            // 
            // button14
            // 
            Button tdBtn = new Button();
            tdBtn.Anchor = System.Windows.Forms.AnchorStyles.Left;
            tdBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            tdBtn.Font = new System.Drawing.Font("Palatino Linotype", 8.25F);
            tdBtn.Location = new System.Drawing.Point(155, 35);
            tdBtn.Name = "tdBtn";
            tdBtn.Size = new System.Drawing.Size(61, 31);
            tdBtn.Text = "<td>";
            tdBtn.UseVisualStyleBackColor = true;
            tdBtn.Click += new System.EventHandler(this.tdBtn_Click);
            // 
            // button13
            // 
            Button trBtn = new Button();
            trBtn.Anchor = System.Windows.Forms.AnchorStyles.Left;
            trBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            trBtn.Font = new System.Drawing.Font("Palatino Linotype", 8.25F);
            trBtn.Location = new System.Drawing.Point(91, 35);
            trBtn.Name = "trBtn";
            trBtn.Size = new System.Drawing.Size(61, 31);
            trBtn.Text = "<tr>";
            trBtn.UseVisualStyleBackColor = true;
            trBtn.Click += new System.EventHandler(this.trBtn_Click);
            // 
            // button12
            // 
            Button tableButton = new Button();
            tableButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
            tableButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            tableButton.Font = new System.Drawing.Font("Palatino Linotype", 8.25F);
            tableButton.Location = new System.Drawing.Point(0, 35);
            tableButton.Name = "tableButton";
            tableButton.Size = new System.Drawing.Size(88, 31);
            tableButton.Text = "<table>";
            tableButton.UseVisualStyleBackColor = true;
            tableButton.Click += new System.EventHandler(this.tableButton_Click);
            // 
            // button27
            // 
            Button baseButton = new Button();
            baseButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
            baseButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            baseButton.Font = new System.Drawing.Font("Palatino Linotype", 8.25F);
            baseButton.Location = new System.Drawing.Point(0, 35);
            baseButton.Name = "baseButton";
            baseButton.Size = new System.Drawing.Size(51, 31);
            baseButton.TabIndex = 0;
            baseButton.Text = "base";
            baseButton.UseVisualStyleBackColor = true;
            baseButton.Click += new System.EventHandler(this.baseButton_Click);
            // 
            // button28
            // 
            Button markButton = new Button();
            markButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
            markButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            markButton.Font = new System.Drawing.Font("Palatino Linotype", 8.25F);
            markButton.Location = new System.Drawing.Point(54, 35);
            markButton.Name = "markButton";
            markButton.Size = new System.Drawing.Size(59, 31);
            markButton.Text = "mark";
            markButton.UseVisualStyleBackColor = true;
            markButton.Click += new System.EventHandler(this.markButton_Click);
            // 
            // button29
            // 
            Button menuButton = new Button();
            menuButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
            menuButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            menuButton.Font = new System.Drawing.Font("Palatino Linotype", 8.25F);
            menuButton.Location = new System.Drawing.Point(116, 35);
            menuButton.Name = "menuButton";
            menuButton.Size = new System.Drawing.Size(59, 31);
            menuButton.Text = "menu";
            menuButton.UseVisualStyleBackColor = true;
            menuButton.Click += new System.EventHandler(this.menuButton_Click);
            // 
            // button30
            // 
            Button formBtn = new Button();
            formBtn.Anchor = System.Windows.Forms.AnchorStyles.Left;
            formBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            formBtn.Font = new System.Drawing.Font("Palatino Linotype", 8.25F);
            formBtn.Location = new System.Drawing.Point(178, 35);
            formBtn.Name = "formBtn";
            formBtn.Size = new System.Drawing.Size(56, 31);
            formBtn.Text = "form";
            formBtn.UseVisualStyleBackColor = true;
            formBtn.Click += new System.EventHandler(this.formBtn_Click);
            // 
            // button31
            // 
            Button hiddenText = new Button();
            hiddenText.Anchor = System.Windows.Forms.AnchorStyles.Left;
            hiddenText.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            hiddenText.Font = new System.Drawing.Font("Palatino Linotype", 8.25F);
            hiddenText.Location = new System.Drawing.Point(237, 35);
            hiddenText.Name = "hiddenText";
            hiddenText.Size = new System.Drawing.Size(55, 31);
            hiddenText.Text = "hide";
            hiddenText.UseVisualStyleBackColor = true;
            hiddenText.Click += new System.EventHandler(this.hiddenText_Click);
            // 
            // button32
            // 
            Button article = new Button();
            article.Anchor = System.Windows.Forms.AnchorStyles.Left;
            article.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            article.Font = new System.Drawing.Font("Palatino Linotype", 8.25F);
            article.Location = new System.Drawing.Point(295, 35);
            article.Name = "article";
            article.Size = new System.Drawing.Size(61, 31);
            article.Text = "article";
            article.UseVisualStyleBackColor = true;
            article.Click += new System.EventHandler(this.article_Click);
            // 
            // button33
            // 
            Button inputBtn = new Button();
            inputBtn.Anchor = System.Windows.Forms.AnchorStyles.Left;
            inputBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            inputBtn.Font = new System.Drawing.Font("Palatino Linotype", 8.25F);
            inputBtn.Location = new System.Drawing.Point(359, 35);
            inputBtn.Name = "inputBtn";
            inputBtn.Size = new System.Drawing.Size(58, 31);
            inputBtn.Text = "input";
            inputBtn.Click += new System.EventHandler(this.inputBtn_Click);
            // 
            // button34
            //
            Button outputBtn = new Button();
            outputBtn.Anchor = System.Windows.Forms.AnchorStyles.Left;
            outputBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            outputBtn.Font = new System.Drawing.Font("Palatino Linotype", 8.25F);
            outputBtn.Location = new System.Drawing.Point(422, 35);
            outputBtn.Name = "outputBtn";
            outputBtn.Size = new System.Drawing.Size(60, 31);
            outputBtn.TabIndex = 7;
            outputBtn.Text = "output";
            outputBtn.UseVisualStyleBackColor = true;
            outputBtn.Click += new System.EventHandler(this.outputBtn_Click);
            // 
            // button35
            // 
            Button sectionBtn = new Button();
            sectionBtn.Anchor = System.Windows.Forms.AnchorStyles.Left;
            sectionBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            sectionBtn.Font = new System.Drawing.Font("Palatino Linotype", 8.25F);
            sectionBtn.Location = new System.Drawing.Point(485, 35);
            sectionBtn.Name = "sectionBtn";
            sectionBtn.Size = new System.Drawing.Size(64, 31);
            sectionBtn.Text = "section";
            sectionBtn.Click += new System.EventHandler(this.sectionBtn_Click);
            // 
            // button36
            // 
            Button asideBtn = new Button();
            asideBtn.Anchor = System.Windows.Forms.AnchorStyles.Left;
            asideBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            asideBtn.Font = new System.Drawing.Font("Palatino Linotype", 8.25F);
            asideBtn.Location = new System.Drawing.Point(552, 35);
            asideBtn.Name = "asideBtn";
            asideBtn.Size = new System.Drawing.Size(65, 30);
            asideBtn.Text = "aside";
            asideBtn.Click += new System.EventHandler(this.asideBtn_Click);
            // 
            // button37
            // 
            Button datalistBtn = new Button();
            datalistBtn.Anchor = System.Windows.Forms.AnchorStyles.Left;
            datalistBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            datalistBtn.Font = new System.Drawing.Font("Palatino Linotype", 8.25F);
            datalistBtn.Location = new System.Drawing.Point(620, 35);
            datalistBtn.Name = "datalistBtn";
            datalistBtn.Size = new System.Drawing.Size(109, 30);
            datalistBtn.Text = "datalist";
            datalistBtn.Click += new System.EventHandler(this.datalistBtn_Click);
            // 
            // button38
            // 
            Button fieldsetBtn = new Button();
            fieldsetBtn.Anchor = System.Windows.Forms.AnchorStyles.Left;
            fieldsetBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            fieldsetBtn.Location = new System.Drawing.Point(0, 35);
            fieldsetBtn.Name = "fieldsetBtn";
            fieldsetBtn.Size = new System.Drawing.Size(69, 31);
            fieldsetBtn.Text = "fieldset";
            fieldsetBtn.Click += new System.EventHandler(this.fieldsetBtn_Click);
            // 
            // button39
            //
            Button navBtn = new Button();
            navBtn.Anchor = System.Windows.Forms.AnchorStyles.Left;
            navBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            navBtn.Location = new System.Drawing.Point(72, 35);
            navBtn.Name = "navBtn";
            navBtn.Size = new System.Drawing.Size(86, 31);
            navBtn.Text = "navigation";
            navBtn.Click += new System.EventHandler(this.navBtn_Click);
            // 
            // button56
            // 
            Button meterBtn = new Button();
            meterBtn.Anchor = System.Windows.Forms.AnchorStyles.Left;
            meterBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            meterBtn.Location = new System.Drawing.Point(764, 35);
            meterBtn.Name = "meterBtn";
            meterBtn.Size = new System.Drawing.Size(75, 31);
            meterBtn.Text = "meter";
            meterBtn.Click += new EventHandler(this.meterBtn_Click);
            // 
            // button55
            //
            Button timeBtn = new Button();
            timeBtn.Anchor = System.Windows.Forms.AnchorStyles.Left;
            timeBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            timeBtn.Location = new System.Drawing.Point(677, 35);
            timeBtn.Name = "timeBtn";
            timeBtn.Size = new System.Drawing.Size(84, 31);
            timeBtn.Text = "time";
            timeBtn.Click += new System.EventHandler(this.timeBtn_Click);
            // 
            // button54
            // 
            Button selectBtn = new Button();
            selectBtn.Anchor = System.Windows.Forms.AnchorStyles.Left;
            selectBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            selectBtn.Location = new System.Drawing.Point(298, 35);
            selectBtn.Name = "selectBtn";
            selectBtn.Size = new System.Drawing.Size(66, 31);
            selectBtn.Text = "select";
            selectBtn.Click += new System.EventHandler(this.selectBtn_Click);
            // 
            // button53
            // 
            Button dialogBtn = new Button();
            dialogBtn.Anchor = System.Windows.Forms.AnchorStyles.Left;
            dialogBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            dialogBtn.Location = new System.Drawing.Point(590, 35);
            dialogBtn.Name = "dialogBtn";
            dialogBtn.Size = new System.Drawing.Size(84, 31);
            dialogBtn.Text = "dialog";
            dialogBtn.Click += new System.EventHandler(this.dialogBtn_Click);
            // 
            // button52
            // 
            Button figureBtn = new Button();
            figureBtn.Anchor = System.Windows.Forms.AnchorStyles.Left;
            figureBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            figureBtn.Location = new System.Drawing.Point(503, 35);
            figureBtn.Name = "figureBtn";
            figureBtn.Size = new System.Drawing.Size(84, 31);
            figureBtn.Text = "figure";
            figureBtn.Click += new System.EventHandler(this.figureBtn_Click);
            // 
            // button51
            // 
            Button progressBtn = new Button();
            progressBtn.Anchor = System.Windows.Forms.AnchorStyles.Left;
            progressBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            progressBtn.Location = new System.Drawing.Point(425, 35);
            progressBtn.Name = "progressBtn";
            progressBtn.Size = new System.Drawing.Size(75, 31);
            progressBtn.Text = "progress";
            progressBtn.Click += new System.EventHandler(this.progressBtn_Click);
            // 
            // button42
            //
            Button metaBtn = new Button();
            metaBtn.Anchor = System.Windows.Forms.AnchorStyles.Left;
            metaBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            metaBtn.Location = new System.Drawing.Point(230, 35);
            metaBtn.Name = "metaBtn";
            metaBtn.Size = new System.Drawing.Size(65, 31);
            metaBtn.Text = "meta";
            metaBtn.Click += new System.EventHandler(this.metaBtn_Click);
            // 
            // button41
            //
            Button iframeBtn = new Button();
            iframeBtn.Anchor = System.Windows.Forms.AnchorStyles.Left;
            iframeBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            iframeBtn.Location = new System.Drawing.Point(367, 35);
            iframeBtn.Name = "iframeBtn";
            iframeBtn.Size = new System.Drawing.Size(55, 31);
            iframeBtn.Text = "iframe";
            iframeBtn.Click += new System.EventHandler(this.iframeBtn_Click);
            // 
            // button40
            //
            Button labelBtn = new Button();
            labelBtn.Anchor = System.Windows.Forms.AnchorStyles.Left;
            labelBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            labelBtn.Location = new System.Drawing.Point(161, 35);
            labelBtn.Name = "labelBtn";
            labelBtn.Size = new System.Drawing.Size(66, 31);
            labelBtn.Text = "label";
            labelBtn.Click += new System.EventHandler(this.labelBtn_Click);
            // 
            // button50
            // 
            Button h6 = new Button();
            h6.Anchor = System.Windows.Forms.AnchorStyles.Left;
            h6.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            h6.Location = new System.Drawing.Point(295, 35);
            h6.Name = "h6";
            h6.Size = new System.Drawing.Size(57, 31);
            h6.Text = "<h6>";
            h6.Click += new EventHandler(this.h6_Click);
            // 
            // button49
            //
            Button h5 = new Button();
            h5.Anchor = System.Windows.Forms.AnchorStyles.Left;
            h5.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            h5.Location = new System.Drawing.Point(236, 35);
            h5.Name = "h5";
            h5.Size = new System.Drawing.Size(56, 31);
            h5.Text = "<h5>";
            h5.Click += new EventHandler(this.h5_Click);
            // 
            // button48
            //
            Button h4 = new Button();
            h4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            h4.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            h4.Location = new System.Drawing.Point(177, 35);
            h4.Name = "h4";
            h4.Size = new System.Drawing.Size(56, 31);
            h4.Text = "<h4>";
            h4.Click += new EventHandler(this.h4_Click);
            // 
            // button47
            //
            Button h2 = new Button();
            h2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            h2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            h2.Location = new System.Drawing.Point(59, 35);
            h2.Name = "h2";
            h2.Size = new System.Drawing.Size(56, 31);
            h2.Text = "<h2>";
            h2.Click += new EventHandler(this.h2_Click);
            // 
            // button46
            //
            Button h3 = new Button();
            h3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            h3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            h3.Location = new System.Drawing.Point(118, 35);
            h3.Name = "h3";
            h3.Size = new System.Drawing.Size(56, 31);
            h3.Text = "<h3>";
            h3.Click += new EventHandler(this.h3_Click);
            // 
            // button45
            // 
            Button h1 = new Button();
            h1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            h1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            h1.Location = new System.Drawing.Point(1, 35);
            h1.Name = "h1";
            h1.Size = new System.Drawing.Size(56, 31);
            h1.TabIndex = 1;
            h1.Text = "<h1>";
            h1.Click += new EventHandler(this.h1_Click);
            // 
            // button44
            // 
            Button ul = new Button();
            ul.Anchor = System.Windows.Forms.AnchorStyles.Left;
            ul.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            ul.Location = new System.Drawing.Point(666, 35);
            ul.MaximumSize = new System.Drawing.Size(200, 31);
            ul.Name = "ul";
            ul.Size = new System.Drawing.Size(50, 28);
            ul.Text = "<ul>";
            ul.Click += new EventHandler(this.ul_Click);
            // 
            // button43
            //
            Button ol = new Button();
            ol.Anchor = System.Windows.Forms.AnchorStyles.Left;
            ol.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            ol.Location = new System.Drawing.Point(611, 35);
            ol.MaximumSize = new System.Drawing.Size(200, 31);
            ol.Name = "ol";
            ol.Size = new System.Drawing.Size(49, 28);
            ol.Text = "<ol>";
            ol.Click += new EventHandler(this.ol_Click);
            // 
            // button11
            //
            Button bdo = new Button();
            bdo.Anchor = System.Windows.Forms.AnchorStyles.Left;
            bdo.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            bdo.Font = new System.Drawing.Font("Palatino Linotype", 8.25F);
            bdo.Location = new System.Drawing.Point(541, 35);
            bdo.MaximumSize = new System.Drawing.Size(200, 31);
            bdo.Name = "bdo";
            bdo.Size = new System.Drawing.Size(64, 29);
            bdo.Text = "<bdo>";
            bdo.Click += new System.EventHandler(this.bdo_Click);
            // 
            // button10
            //
            Button supBtn = new Button();
            supBtn.Anchor = System.Windows.Forms.AnchorStyles.Left;
            supBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            supBtn.Font = new System.Drawing.Font("Palatino Linotype", 8.25F);
            supBtn.Location = new System.Drawing.Point(499, 35);
            supBtn.MaximumSize = new System.Drawing.Size(200, 31);
            supBtn.Name = "subBtn";
            supBtn.Size = new System.Drawing.Size(36, 29);
            supBtn.Text = "X²";
            supBtn.Click += new System.EventHandler(this.supBtn_Click);
            // 
            // button8
            //
            Button xettBtn = new Button();
            xettBtn.Anchor = System.Windows.Forms.AnchorStyles.Left;
            xettBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            xettBtn.Font = new System.Drawing.Font("Palatino Linotype", 8.25F);
            xettBtn.Location = new System.Drawing.Point(384, 35);
            xettBtn.MaximumSize = new System.Drawing.Size(200, 31);
            xettBtn.Name = "xettBtn";
            xettBtn.Size = new System.Drawing.Size(67, 29);
            xettBtn.Text = "---";
            xettBtn.Click += new System.EventHandler(this.xettBtn_Click);
            // 
            // button9
            //
            Button subBtn = new Button();
            subBtn.Anchor = System.Windows.Forms.AnchorStyles.Left;
            subBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            subBtn.Font = new System.Drawing.Font("Palatino Linotype", 8.25F);
            subBtn.Location = new System.Drawing.Point(457, 35);
            subBtn.MaximumSize = new System.Drawing.Size(200, 31);
            subBtn.Name = "button9";
            subBtn.Size = new System.Drawing.Size(36, 29);
            subBtn.Text = "X₂";
            subBtn.Click += new System.EventHandler(this.subBtn_Click);
            // 
            // button6
            // 
            Button yeniSetirBtn = new Button();
            yeniSetirBtn.Anchor = System.Windows.Forms.AnchorStyles.Left;
            yeniSetirBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            yeniSetirBtn.Font = new System.Drawing.Font("Palatino Linotype", 8.25F);
            yeniSetirBtn.Location = new System.Drawing.Point(239, 35);
            yeniSetirBtn.MaximumSize = new System.Drawing.Size(200, 31);
            yeniSetirBtn.Name = "yeniSetirBtn";
            yeniSetirBtn.Size = new System.Drawing.Size(66, 29);
            yeniSetirBtn.Text = "<br>";
            yeniSetirBtn.Click += new System.EventHandler(this.yeniSetirBtn_Click);
            // 
            // button7
            // 
            Button spanButton = new Button();
            spanButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
            spanButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            spanButton.Font = new System.Drawing.Font("Palatino Linotype", 8.25F);
            spanButton.Location = new System.Drawing.Point(311, 35);
            spanButton.MaximumSize = new System.Drawing.Size(200, 31);
            spanButton.Name = "spanButton";
            spanButton.Size = new System.Drawing.Size(67, 29);
            spanButton.Text = "<span>";
            spanButton.Click += new System.EventHandler(this.spanButton_Click);
            // 
            // button3
            //
            Button eyriBtn = new Button();
            eyriBtn.Anchor = System.Windows.Forms.AnchorStyles.Left;
            eyriBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            eyriBtn.Font = new System.Drawing.Font("Palatino Linotype", 8.25F, System.Drawing.FontStyle.Italic);
            eyriBtn.Location = new System.Drawing.Point(84, 35);
            eyriBtn.MaximumSize = new System.Drawing.Size(200, 31);
            eyriBtn.Name = "eyriBtn";
            eyriBtn.Size = new System.Drawing.Size(35, 31);
            eyriBtn.Text = "I";
            eyriBtn.Click += new System.EventHandler(this.eyriBtn_Click);
            // 
            // button4
            //
            Button kesenxettBtn = new Button();
            kesenxettBtn.Anchor = System.Windows.Forms.AnchorStyles.Left;
            kesenxettBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            kesenxettBtn.Font = new System.Drawing.Font("Palatino Linotype", 8.25F, System.Drawing.FontStyle.Strikeout);
            kesenxettBtn.Location = new System.Drawing.Point(125, 35);
            kesenxettBtn.MaximumSize = new System.Drawing.Size(200, 31);
            kesenxettBtn.Name = "kesenxettBtn";
            kesenxettBtn.Size = new System.Drawing.Size(36, 31);
            kesenxettBtn.Text = "S";
            kesenxettBtn.Click += new System.EventHandler(this.kesenxettBtn_Click);
            // 
            // button2
            //
            Button altdanxettBtn = new Button();
            altdanxettBtn.Anchor = System.Windows.Forms.AnchorStyles.Left;
            altdanxettBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            altdanxettBtn.Font = new System.Drawing.Font("Palatino Linotype", 8.25F, System.Drawing.FontStyle.Underline);
            altdanxettBtn.Location = new System.Drawing.Point(42, 35);
            altdanxettBtn.MaximumSize = new System.Drawing.Size(200, 31);
            altdanxettBtn.Name = "altdanxettBtn";
            altdanxettBtn.Size = new System.Drawing.Size(36, 31);
            altdanxettBtn.Text = "U";
            altdanxettBtn.Click += new System.EventHandler(this.altdanxettBtn_Click);
            // 
            // button1
            //
            Button yagliBtn = new Button();
            yagliBtn.Anchor = System.Windows.Forms.AnchorStyles.Left;
            yagliBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            yagliBtn.Font = new System.Drawing.Font("Palatino Linotype", 8.25F, System.Drawing.FontStyle.Bold);
            yagliBtn.Location = new System.Drawing.Point(1, 35);
            yagliBtn.MaximumSize = new System.Drawing.Size(200, 31);
            yagliBtn.Name = "yagliBtn";
            yagliBtn.Size = new System.Drawing.Size(35, 31);
            yagliBtn.Text = "B";
            yagliBtn.Click += new System.EventHandler(this.yagliBtn_Click);
            // 
            // button5
            // 
            Button paraqrafBtn = new Button();
            paraqrafBtn.Anchor = System.Windows.Forms.AnchorStyles.Left;
            paraqrafBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            paraqrafBtn.Font = new System.Drawing.Font("Palatino Linotype", 8.25F);
            paraqrafBtn.Location = new System.Drawing.Point(167, 35);
            paraqrafBtn.MaximumSize = new System.Drawing.Size(200, 31);
            paraqrafBtn.Name = "paraqrafBtn";
            paraqrafBtn.Size = new System.Drawing.Size(66, 31);
            paraqrafBtn.Text = "<p>";
            paraqrafBtn.Click += new System.EventHandler(this.paraqrafBtn_Click);
            // 
            // menu
            // 
            // 
            // tableLayoutPanel1
            //
            TableLayoutPanel tableMenu = new TableLayoutPanel();
            tableMenu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            tableMenu.BackColor = System.Drawing.Color.Transparent;
            tableMenu.ColumnCount = 1;
            tableMenu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tableMenu.Location = new System.Drawing.Point(12, 29);
            tableMenu.Name = "tableMenu";
            tableMenu.RowCount = 1;
            tableMenu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tableMenu.Size = new System.Drawing.Size(978, 78);
            this.Controls.Add(tableMenu);


            TabPage tabPage7 = new TabPage();
            TabPage tabPage6 = new TabPage();
            TabPage tabPage5 = new TabPage();
            TabPage tabPage4 = new TabPage();
            TabPage tabPage3 = new TabPage();
            TabPage tabPage2 = new TabPage();
            TabPage tabPage1 = new TabPage();
            TabControl menu = new TabControl();
            menu.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            menu.Font = new System.Drawing.Font("Palatino Linotype", 8.25F);
            menu.ItemSize = new System.Drawing.Size(160, 21);
            menu.Location = new System.Drawing.Point(3, 3);
            menu.Name = "menu";
            menu.Size = new System.Drawing.Size(972, 72);
            menu.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            tableMenu.Controls.Add(menu, 0, 0);
            // 
            // tabPage7
            //
            tabPage7.Controls.Add(meterBtn);
            tabPage7.Controls.Add(timeBtn);
            tabPage7.Controls.Add(selectBtn);
            tabPage7.Controls.Add(dialogBtn);
            tabPage7.Controls.Add(figureBtn);
            tabPage7.Controls.Add(progressBtn);
            tabPage7.Controls.Add(metaBtn);
            tabPage7.Controls.Add(iframeBtn);
            tabPage7.Controls.Add(labelBtn);
            tabPage7.Controls.Add(navBtn);
            tabPage7.Controls.Add(fieldsetBtn);
            tabPage7.Location = new System.Drawing.Point(4, 25);
            tabPage7.Name = "tabPage7";
            tabPage7.Size = new System.Drawing.Size(964, 43);
            tabPage7.Text = "Other";
            // 
            // tabPage6
            //
            tabPage6.Controls.Add(datalistBtn);
            tabPage6.Controls.Add(sectionBtn);
            tabPage6.Controls.Add(asideBtn);
            tabPage6.Controls.Add(baseButton);
            tabPage6.Controls.Add(outputBtn);
            tabPage6.Controls.Add(markButton);
            tabPage6.Controls.Add(inputBtn);
            tabPage6.Controls.Add(menuButton);
            tabPage6.Controls.Add(article);
            tabPage6.Controls.Add(formBtn);
            tabPage6.Controls.Add(hiddenText);
            tabPage6.Location = new System.Drawing.Point(4, 25);
            tabPage6.Name = "tabPage6";
            tabPage6.Size = new System.Drawing.Size(964, 43);
            tabPage6.Text = "Data";
            // 
            // tabPage5
            // 
            tabPage5.Controls.Add(btn);
            tabPage5.Controls.Add(scriptBtn);
            tabPage5.Controls.Add(divBtn);
            tabPage5.Controls.Add(video);
            tabPage5.Controls.Add(linkBtn);
            tabPage5.Controls.Add(textAreaBtn);
            tabPage5.Controls.Add(youtube);
            tabPage5.Controls.Add(commentBtn);
            tabPage5.Controls.Add(audioBtn);
            tabPage5.Controls.Add(imgBtn);
            tabPage5.Controls.Add(sitatBtn);
            tabPage5.Controls.Add(abbreviature);
            tabPage5.Location = new System.Drawing.Point(4, 25);
            tabPage5.Name = "tabPage5";
            tabPage5.Size = new System.Drawing.Size(964, 43);
            tabPage5.Text = "Info";
            // 
            // tabPage4
            // 
            tabPage4.Controls.Add(tdBtn);
            tabPage4.Controls.Add(tableButton);
            tabPage4.Controls.Add(trBtn);
            tabPage4.Location = new System.Drawing.Point(4, 25);
            tabPage4.Name = "tabPage4";
            tabPage4.Size = new System.Drawing.Size(964, 43);
            tabPage4.Text = "Table";
            // 
            // tabPage3
            // 
            tabPage3.Controls.Add(h1);
            tabPage3.Controls.Add(h2);
            tabPage3.Controls.Add(h3);
            tabPage3.Controls.Add(h4);
            tabPage3.Controls.Add(h5);
            tabPage3.Controls.Add(h6);
            tabPage3.Location = new System.Drawing.Point(4, 25);
            tabPage3.Name = "tabPage3";
            tabPage3.Size = new System.Drawing.Size(964, 43);
            tabPage3.Text = "Headers";
            // 
            // tabPage1
            //
            tabPage1.BackColor = System.Drawing.Color.Transparent;
            tabPage1.Controls.Add(paraqrafBtn);
            tabPage1.Controls.Add(yagliBtn);
            tabPage1.Controls.Add(altdanxettBtn);
            tabPage1.Controls.Add(kesenxettBtn);
            tabPage1.Controls.Add(eyriBtn);
            tabPage1.Controls.Add(spanButton);
            tabPage1.Controls.Add(yeniSetirBtn);
            tabPage1.Controls.Add(subBtn);
            tabPage1.Controls.Add(xettBtn);
            tabPage1.Controls.Add(supBtn);
            tabPage1.Controls.Add(bdo);
            tabPage1.Controls.Add(ol);
            tabPage1.Controls.Add(ul);
            tabPage1.Location = new System.Drawing.Point(4, 25);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new System.Windows.Forms.Padding(3);
            tabPage1.Size = new System.Drawing.Size(964, 43);
            tabPage1.Text = "Text";

            menu.Controls.Add(tabPage1);
            menu.Controls.Add(tabPage3);
            menu.Controls.Add(tabPage4);
            menu.Controls.Add(tabPage5);
            menu.Controls.Add(tabPage6);
            menu.Controls.Add(tabPage7);

            listBox1.Visible = true;
            browserWindow.Visible = true;
            syntax.Text = "Syntax [HTML]";
        }
        private void phpTemplate()
        {
            TandB.ColumnCount = 1;
            TandB.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            TandB.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            for (int i = this.Controls.Count - 1; i >= 0; i--)
            {
                Button control = this.Controls[i] as Button;
                //ListBox control1 = this.Controls[i] as ListBox;

                if (control == null)// && control1 == null)
                    continue;
                control.Visible = false;
                control.Dispose();
                //control1.Dispose();
            }
            if (this.Controls.OfType<TableLayoutPanel>().FirstOrDefault(y => y.Name == "tableMenu") != null)
            {
                this.Controls.OfType<TableLayoutPanel>().FirstOrDefault(y => y.Name == "tableMenu").Dispose();
            }
            textArea.Clear();
            syntax.Text = "Syntax [PHP]";
            textArea.AppendText("<?php \necho \"Hello,world!\"; \n?>");
            browserWindow.Visible = false;
            TandB.Height = 563;
            TandB.Location = new Point(12, 50);
            textArea.Focus();
            var ctrl = (Control)this;
            var frm = ctrl.FindForm();
            Label label = null;
            ListBox lstbx = null;
            foreach (var ctr in frm.Controls)
            {
                if (ctr is ListBox)
                {
                    lstbx = (ListBox)ctr;
                    if (lstbx.Name == "listBox1")
                    {
                        lstbx.Visible = false;
                    }
                    else
                        if (lstbx.Name == "listTypes")
                    {
                        lstbx.Visible = false;
                    }
                }
                if (ctr is Label)
                {
                    label = (Label)ctr;
                    if (label.Name == "label1")
                    {
                        label.Visible = false;
                    }
                    else
                       if (label.Name == "lists")
                    {
                        label.Visible = false;
                    }
                    else
                       if (label.Name == "listTypes")
                    {
                        label.Visible = false;
                    }
                    else
                       if (label.Name == "label2")
                    {
                        label.Visible = false;
                    }
                    else
                       if (label.Name == "label3")
                    {
                        label.Visible = false;
                    }
                    else
                       if (label.Name == "label4")
                    {
                        label.Visible = false;
                    }
                    else
                       if (label.Name == "label6")
                    {
                        label.Visible = false;
                    }
                }
            }
            Button phpClass = new Button();
            phpClass.Text = "class";
            phpClass.Visible = true;
            phpClass.Size = new Size(45, 23);
            phpClass.Location = new Point(11, 25);
            phpClass.Click += new EventHandler(this.phpClass_Click);
            this.Controls.Add(phpClass);

            Button phpFunction = new Button();
            phpFunction.Text = "function";
            phpFunction.Visible = true;
            phpFunction.Size = new Size(65, 23);
            phpFunction.Location = new Point(56, 25);
            phpFunction.Click += new EventHandler(this.phpFunction_Click);
            this.Controls.Add(phpFunction);

            Button phpInclude = new Button();
            phpInclude.Text = "include";
            phpInclude.Visible = true;
            phpInclude.Size = new Size(65, 23);
            phpInclude.Location = new Point(121, 25);
            phpInclude.Click += new EventHandler(this.phpInclude_Click);
            this.Controls.Add(phpInclude);

            Button phpRequire = new Button();
            phpRequire.Text = "require";
            phpRequire.Visible = true;
            phpRequire.Size = new Size(65, 23);
            phpRequire.Location = new Point(186, 25);
            phpRequire.Click += new EventHandler(this.phpRequire_Click);
            this.Controls.Add(phpRequire);

            Button phpEcho = new Button();
            phpEcho.Text = "echo";
            phpEcho.Visible = true;
            phpEcho.Size = new Size(65, 23);
            phpEcho.Location = new Point(251, 25);
            phpEcho.Click += new EventHandler(this.phpEcho_Click);
            this.Controls.Add(phpEcho);

            Button phpClearWindow = new Button();
            phpClearWindow.Text = "clear";
            phpClearWindow.Visible = true;
            phpClearWindow.Size = new Size(50, 23);
            phpClearWindow.Location = new Point(941, 25);
            phpClearWindow.Click += new EventHandler(this.phpClearWindow_Click);
            this.Controls.Add(phpClearWindow);
        }
        private void phpClearWindow_Click(object sender, EventArgs e)
        {
            textArea.Clear();
            textArea.AppendText("<?php\n\n\n?>");
        }
        private void phpEcho_Click(object sender, EventArgs e)
        {
            Form phpEchoForm = new Form();
            phpEchoForm.Size = new Size(233, 100);
            phpEchoForm.StartPosition = FormStartPosition.CenterScreen;
            phpEchoForm.ShowIcon = false;
            phpEchoForm.ShowInTaskbar = false;
            phpEchoForm.Text = "echo";
            phpEchoForm.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            phpEchoForm.Show();

            Button phpEchoOk = new Button();
            phpEchoOk.Location = new System.Drawing.Point(117, 38);
            phpEchoOk.Size = new System.Drawing.Size(34, 23);
            phpEchoOk.Text = "OK";
            phpEchoOk.Click += new EventHandler(this.phpEchoOk_Click);
            phpEchoForm.Controls.Add(phpEchoOk);

            Button phpEchoCancel = new Button();
            phpEchoCancel.Location = new System.Drawing.Point(157, 38);
            phpEchoCancel.Size = new System.Drawing.Size(48, 23);
            phpEchoCancel.Text = "Cancel";
            phpEchoCancel.Click += new EventHandler(this.phpEchoCancel_Click);
            phpEchoForm.Controls.Add(phpEchoCancel);

            TextBox phpEchoText = new TextBox();
            phpEchoText.Location = new System.Drawing.Point(15, 12);
            phpEchoText.Name = "phpEchoText";
            phpEchoText.Size = new System.Drawing.Size(190, 20);
            phpEchoForm.Controls.Add(phpEchoText);
        }
        private void phpRequire_Click(object sender, EventArgs e)
        {
            Form phpRequireForm = new Form();
            phpRequireForm.Size = new Size(233, 120);
            phpRequireForm.StartPosition = FormStartPosition.CenterScreen;
            phpRequireForm.ShowIcon = false;
            phpRequireForm.ShowInTaskbar = false;
            phpRequireForm.Text = "require";
            phpRequireForm.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            phpRequireForm.Show();

            Button phpRequireOk = new Button();
            phpRequireOk.Location = new System.Drawing.Point(117, 58);
            phpRequireOk.Size = new System.Drawing.Size(34, 23);
            phpRequireOk.Text = "OK";
            phpRequireOk.Click += new EventHandler(this.phpRequireOk_Click);
            phpRequireForm.Controls.Add(phpRequireOk);

            Button phpRequireCancel = new Button();
            phpRequireCancel.Location = new System.Drawing.Point(157, 58);
            phpRequireCancel.Size = new System.Drawing.Size(48, 23);
            phpRequireCancel.Text = "Cancel";
            phpRequireCancel.Click += new EventHandler(this.phpRequireCancel_Click);
            phpRequireForm.Controls.Add(phpRequireCancel);

            TextBox requireURL = new TextBox();
            requireURL.Location = new System.Drawing.Point(68, 32);
            requireURL.Name = "requireURL";
            requireURL.Size = new System.Drawing.Size(137, 20);
            requireURL.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            phpRequireForm.Controls.Add(requireURL);

            CheckBox onceCheck = new CheckBox();
            onceCheck.Location = new System.Drawing.Point(155, 9);
            onceCheck.Name = "onceCheck";
            onceCheck.Size = new System.Drawing.Size(50, 17);
            onceCheck.Text = "once";
            phpRequireForm.Controls.Add(onceCheck);

            Label label1 = new Label();
            label1.Location = new System.Drawing.Point(12, 14);
            label1.Size = new System.Drawing.Size(20, 13);
            label1.Text = "file";
            phpRequireForm.Controls.Add(label1);

            Button requireSelect = new Button();
            requireSelect.Location = new System.Drawing.Point(12, 30);
            requireSelect.Size = new System.Drawing.Size(50, 23);
            requireSelect.Text = "Select";
            requireSelect.Click += new EventHandler(this.requireSelect_Click);
            phpRequireForm.Controls.Add(requireSelect);
        }
        private void phpInclude_Click(object sender, EventArgs e)
        {
            Form phpIncludeForm = new Form();
            phpIncludeForm.Size = new Size(233, 120);
            phpIncludeForm.StartPosition = FormStartPosition.CenterScreen;
            phpIncludeForm.ShowIcon = false;
            phpIncludeForm.ShowInTaskbar = false;
            phpIncludeForm.Text = "include";
            phpIncludeForm.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            phpIncludeForm.Show();

            Button phpIncludeOk = new Button();
            phpIncludeOk.Location = new System.Drawing.Point(117, 58);
            phpIncludeOk.Size = new System.Drawing.Size(34, 23);
            phpIncludeOk.Text = "OK";
            phpIncludeOk.Click += new EventHandler(this.phpIncludeOk_Click);
            phpIncludeForm.Controls.Add(phpIncludeOk);

            Button phpIncludeCancel = new Button();
            phpIncludeCancel.Location = new System.Drawing.Point(157, 58);
            phpIncludeCancel.Size = new System.Drawing.Size(48, 23);
            phpIncludeCancel.Text = "Cancel";
            phpIncludeCancel.Click += new EventHandler(this.phpIncludeCancel_Click);
            phpIncludeForm.Controls.Add(phpIncludeCancel);

            TextBox includeURL = new TextBox();
            includeURL.Location = new System.Drawing.Point(68, 32);
            includeURL.Name = "includeURL";
            includeURL.Size = new System.Drawing.Size(137, 20);
            includeURL.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            phpIncludeForm.Controls.Add(includeURL);

            CheckBox onceCheck = new CheckBox();
            onceCheck.Location = new System.Drawing.Point(155, 9);
            onceCheck.Name = "onceCheck";
            onceCheck.Size = new System.Drawing.Size(50, 17);
            onceCheck.Text = "once";
            phpIncludeForm.Controls.Add(onceCheck);

            Label label1 = new Label();
            label1.Location = new System.Drawing.Point(12, 14);
            label1.Size = new System.Drawing.Size(20, 13);
            label1.Text = "file";
            phpIncludeForm.Controls.Add(label1);

            Button includeSelect = new Button();
            includeSelect.Location = new System.Drawing.Point(12, 30);
            includeSelect.Size = new System.Drawing.Size(50, 23);
            includeSelect.Text = "Select";
            includeSelect.Click += new EventHandler(this.includeSelect_Click);
            phpIncludeForm.Controls.Add(includeSelect);
        }
        private void phpFunction_Click(object sender, EventArgs e)
        {
            Form phpFunctionForm = new Form();
            phpFunctionForm.Size = new Size(125, 125);
            phpFunctionForm.StartPosition = FormStartPosition.CenterScreen;
            phpFunctionForm.ShowIcon = false;
            phpFunctionForm.ShowInTaskbar = false;
            phpFunctionForm.Text = "function";
            phpFunctionForm.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            phpFunctionForm.Show();

            Button functionOK = new Button();
            functionOK.Location = new System.Drawing.Point(12, 58);
            functionOK.Size = new System.Drawing.Size(34, 23);
            functionOK.Text = "OK";
            functionOK.Click += new EventHandler(this.functionOK_Click);
            phpFunctionForm.Controls.Add(functionOK);

            Button functionCancel = new Button();
            functionCancel.Location = new System.Drawing.Point(52, 58);
            functionCancel.Size = new System.Drawing.Size(48, 23);
            functionCancel.Text = "Cancel";
            functionCancel.Click += new EventHandler(this.functionCancel_Click);
            phpFunctionForm.Controls.Add(functionCancel);

            TextBox functionName = new TextBox();
            functionName.Location = new System.Drawing.Point(12, 32);
            functionName.Name = "functionName";
            functionName.Size = new System.Drawing.Size(88, 20);
            functionName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            phpFunctionForm.Controls.Add(functionName);

            Label label1 = new Label();
            label1.Location = new System.Drawing.Point(12, 16);
            label1.Size = new System.Drawing.Size(105, 13);
            label1.Text = "function name";
            phpFunctionForm.Controls.Add(label1);
        }
        private void phpClass_Click(object sender, EventArgs e)
        {
            Form phpClassForm = new Form();
            phpClassForm.Size = new Size(125, 125);
            phpClassForm.StartPosition = FormStartPosition.CenterScreen;
            phpClassForm.ShowIcon = false;
            phpClassForm.ShowInTaskbar = false;
            phpClassForm.Text = "class";
            phpClassForm.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            phpClassForm.Show();

            Button classOK = new Button();
            classOK.Location = new System.Drawing.Point(12, 58);
            classOK.Size = new System.Drawing.Size(34, 23);
            classOK.Text = "OK";
            classOK.Click += new EventHandler(this.classOK_Click);
            phpClassForm.Controls.Add(classOK);

            Button classCancel = new Button();
            classCancel.Location = new System.Drawing.Point(52, 58);
            classCancel.Size = new System.Drawing.Size(48, 23);
            classCancel.Text = "Сancel";
            classCancel.Click += new EventHandler(this.classCancel_Click);
            phpClassForm.Controls.Add(classCancel);

            TextBox className = new TextBox();
            className.Location = new System.Drawing.Point(12, 32);
            className.Name = "phpclassName";
            className.Size = new System.Drawing.Size(88, 20);
            className.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            phpClassForm.Controls.Add(className);

            Label label1 = new Label();
            label1.Location = new System.Drawing.Point(12, 16);
            label1.Size = new System.Drawing.Size(60, 13);
            label1.Text = "class name";
            phpClassForm.Controls.Add(label1);
        }
        private void cssTemplate()
        {
            TandB.ColumnCount = 1;
            TandB.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            TandB.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            for (int i = this.Controls.Count - 1; i >= 0; i--)
            {
                Button control = this.Controls[i] as Button;
                if (control == null)
                    continue;
                control.Visible = false;
                control.Dispose();
            }
            textArea.Clear();
            syntax.Text = "Syntax [CSS]";
            textArea.AppendText("\t ");
            textArea.AppendText(" { \n\n");
            textArea.AppendText(" } \n");
            browserWindow.Visible = false;
            TandB.Height = 547;
            TandB.Location = new Point(12, 97);

            var ctrl = (Control)this;
            var frm = ctrl.FindForm();
            Label label = null;
            ListBox lstbx = null;
            foreach (var ctr in frm.Controls)
            {
                if (ctr is ListBox)
                {
                    lstbx = (ListBox)ctr;
                    if (lstbx.Name == "listBox1")
                    {
                        lstbx.Visible = false;
                    }
                    else
                        if (lstbx.Name == "listTypes")
                    {
                        lstbx.Visible = false;
                    }
                }
                if (ctr is Label)
                {
                    label = (Label)ctr;
                    if (label.Name == "label1")
                    {
                        label.Visible = false;
                    }
                    else
                        if (label.Name == "lists")
                    {
                        label.Visible = false;
                    }
                    else
                        if (label.Name == "listTypes")
                    {
                        label.Visible = false;
                    }
                    else
                        if (label.Name == "label2")
                    {
                        label.Visible = false;
                    }
                    else
                        if (label.Name == "label3")
                    {
                        label.Visible = false;
                    }
                    else
                        if (label.Name == "label4")
                    {
                        label.Visible = false;
                    }
                    else
                        if (label.Name == "label6")
                    {
                        label.Visible = false;
                    }
                }
            }

            Button newEntry = new Button();
            newEntry.Visible = true;
            newEntry.Text = "New entry";
            newEntry.Size = new Size(129, 23);
            newEntry.Location = new Point(863, 72);
            this.Controls.Add(newEntry);
            newEntry.Click += new System.EventHandler(this.newEntry_Click);

            Button setColor = new Button();
            setColor.Visible = true;
            setColor.Text = "color";
            setColor.Size = new Size(45, 23);
            setColor.Location = new Point(704, 72);
            this.Controls.Add(setColor);
            setColor.Click += new System.EventHandler(this.setColor_Click);

            Button text = new Button();
            text.Visible = true;
            text.Text = "text";
            text.Size = new Size(73, 23);
            text.Location = new Point(749, 72);
            this.Controls.Add(text);
            text.Click += new System.EventHandler(this.text_Click);

            Button setFont = new Button();
            setFont.Text = "font";
            setFont.Visible = true;
            setFont.Size = new Size(50, 23);
            setFont.Location = new Point(654, 72);
            this.Controls.Add(setFont);
            setFont.Click += new System.EventHandler(setFont_Click);

            Button showForm = new Button();
            showForm.Text = "margin";
            showForm.Visible = true;
            showForm.Size = new Size(50, 23);
            showForm.Location = new Point(604, 72);
            this.Controls.Add(showForm);
            showForm.Click += new System.EventHandler(showForm_Click);

            Button bgImg = new Button();
            bgImg.Text = "background";
            bgImg.Visible = true;
            bgImg.Size = new Size(75, 23);
            bgImg.Location = new Point(529, 72);
            this.Controls.Add(bgImg);
            bgImg.Click += new System.EventHandler(bgImg_Click);

            Button border = new Button();
            border.Text = "border";
            border.Visible = true;
            border.Size = new Size(51, 23);
            border.Location = new Point(478, 72);
            this.Controls.Add(border);
            border.Click += new System.EventHandler(border_Click);

            Button padding = new Button();
            padding.Text = "padding";
            padding.Visible = true;
            padding.Size = new Size(55, 23);
            padding.Location = new Point(423, 72);
            this.Controls.Add(padding);
            padding.Click += new System.EventHandler(padding_Click);

            Button position = new Button();
            position.Text = "position";
            position.Visible = true;
            position.Size = new Size(61, 23);
            position.Location = new Point(362, 72);
            this.Controls.Add(position);
            position.Click += new System.EventHandler(position_Click);

            Button opacity = new Button();
            opacity.Text = "opacity";
            opacity.Visible = true;
            opacity.Size = new Size(56, 23);
            opacity.Location = new Point(306, 72);
            this.Controls.Add(opacity);
            opacity.Click += new System.EventHandler(opacity_Click);

            Button textTransform = new Button();
            textTransform.Text = "text-transform";
            textTransform.Visible = true;
            textTransform.Size = new Size(85, 23);
            textTransform.Location = new Point(221, 72);
            textTransform.Click += new System.EventHandler(this.textTransform_Click);
            this.Controls.Add(textTransform);

            Button textShadow = new Button();
            textShadow.Text = "text-shadow";
            textShadow.Visible = true;
            textShadow.Size = new Size(75, 23);
            textShadow.Location = new Point(146, 72);
            textShadow.Click += new System.EventHandler(this.textShadow_Click);
            this.Controls.Add(textShadow);

            Button align = new Button();
            align.Text = "align-content";
            align.Visible = true;
            align.Size = new Size(80, 23);
            align.Location = new Point(66, 72);
            align.Click += new System.EventHandler(this.align_Click);
            this.Controls.Add(align);

            Button animate = new Button();
            animate.Text = "animate";
            animate.Visible = true;
            animate.Size = new Size(55, 23);
            animate.Location = new Point(11, 72);
            animate.Click += new EventHandler(this.animateClick);
            this.Controls.Add(animate);

            Button display = new Button();
            display.Text = "display";
            display.Visible = true;
            display.Size = new Size(55, 23);
            display.Location = new Point(11, 48);
            display.Click += new EventHandler(this.displayClick);
            this.Controls.Add(display);

            Button box = new Button();
            box.Text = "box-sizing";
            box.Visible = true;
            box.Size = new Size(80, 23);
            box.Location = new Point(66, 48);
            box.Click += new EventHandler(this.boxClick);
            this.Controls.Add(box);

            Button shadow = new Button();
            shadow.Text = "box-shadow";
            shadow.Size = new Size(80, 23);
            shadow.Location = new Point(146, 48);
            shadow.Click += new EventHandler(this.shadowClick);
            this.Controls.Add(shadow);

            Button listStyle = new Button();
            listStyle.Text = "list-style";
            listStyle.Size = new Size(70, 23);
            listStyle.Location = new Point(226, 48);
            listStyle.Click += new EventHandler(this.listStyle_Click);
            this.Controls.Add(listStyle);

            Button captionSide = new Button();
            captionSide.Text = "caption-side";
            captionSide.Size = new Size(80, 23);
            captionSide.Location = new Point(296, 48);
            captionSide.Click += new EventHandler(this.captionSide_Click);
            this.Controls.Add(captionSide);

            Button elementSizes = new Button();
            elementSizes.Text = "element-size";
            elementSizes.Size = new Size(80, 23);
            elementSizes.Location = new Point(376, 48);
            elementSizes.Click += new EventHandler(this.elementSizes_Click);
            this.Controls.Add(elementSizes);

            Button transition = new Button();
            transition.Text = "transition";
            transition.Size = new Size(80, 23);
            transition.Location = new Point(456, 48);
            transition.Click += new EventHandler(this.transition_Click);
            this.Controls.Add(transition);

            Button lrtb = new Button();
            lrtb.Text = "left-right-top-bottom";
            lrtb.Size = new Size(120, 23);
            lrtb.Location = new Point(591, 48);
            lrtb.Click += new EventHandler(this.lrtb_Click);
            this.Controls.Add(lrtb);

            Button filter = new Button();
            filter.Text = "filters";
            filter.Size = new Size(55, 23);
            filter.Location = new Point(536, 48);
            filter.Click += new EventHandler(this.filter_Click);
            this.Controls.Add(filter);

            Button columns = new Button();
            columns.Text = "column";
            columns.Size = new Size(110, 23);
            columns.Location = new Point(711, 48);
            columns.Click += new EventHandler(this.columns_Click);
            this.Controls.Add(columns);

            Button overflow = new Button();
            overflow.Text = "overflow";
            overflow.Size = new Size(65, 23);
            overflow.Location = new Point(11, 25);
            overflow.Click += new EventHandler(this.overflow_Click);
            this.Controls.Add(overflow);

            Button pageBreak = new Button();
            pageBreak.Text = "page-break";
            pageBreak.Size = new Size(70, 23);
            pageBreak.Location = new Point(76, 25);
            pageBreak.Click += new EventHandler(this.pageBreak_Click);
            this.Controls.Add(pageBreak);

            Button transform = new Button();
            transform.Text = "transform";
            transform.Size = new Size(65, 23);
            transform.Location = new Point(146, 25);
            transform.Click += new EventHandler(this.transform_Click);
            this.Controls.Add(transform);

            Button word = new Button();
            word.Text = "word";
            word.Size = new Size(45, 23);
            word.Location = new Point(211, 25);
            word.Click += new EventHandler(this.word_Click);
            this.Controls.Add(word);

            Button visibility = new Button();
            visibility.Text = "visibility";
            visibility.Size = new Size(60, 23);
            visibility.Location = new Point(256, 25);
            visibility.Click += new EventHandler(this.visibility_Click);
            this.Controls.Add(visibility);

            Button quotes = new Button();
            quotes.Text = "quotes";
            quotes.Size = new Size(50, 23);
            quotes.Location = new Point(316, 25);
            quotes.Click += new EventHandler(this.quotes_Click);
            this.Controls.Add(quotes);

            Button white = new Button();
            white.Text = "white";
            white.Size = new Size(45, 23);
            white.Location = new Point(366, 25);
            white.Click += new EventHandler(this.white_Click);
            this.Controls.Add(white);

            Button resize = new Button();
            resize.Text = "resize";
            resize.Size = new Size(50, 23);
            resize.Location = new Point(411, 25);
            resize.Click += new EventHandler(this.resize_Click);
            this.Controls.Add(resize);

            Button letterspacing = new Button();
            letterspacing.Text = "letter-spacing";
            letterspacing.Size = new Size(85, 23);
            letterspacing.Location = new Point(461, 25);
            letterspacing.Click += new EventHandler(this.letterspacing_Click);
            this.Controls.Add(letterspacing);

            Button cursor = new Button();
            cursor.Text = "cursor";
            cursor.Size = new Size(50, 23);
            cursor.Location = new Point(546, 25);
            cursor.Click += new EventHandler(this.cursor_Click);
            this.Controls.Add(cursor);

            Button clear = new Button();
            clear.Text = "clear";
            clear.Size = new Size(50, 23);
            clear.Location = new Point(596, 25);
            clear.Click += new EventHandler(this.clear_Click);
            this.Controls.Add(clear);

            Button objectfit = new Button();
            objectfit.Text = "object-fit";
            objectfit.Size = new Size(65, 23);
            objectfit.Location = new Point(646, 25);
            objectfit.Click += new EventHandler(this.objectfit_Click);
            this.Controls.Add(objectfit);

            Button content = new Button();
            content.Text = "content";
            content.Size = new Size(55, 23);
            content.Location = new Point(711, 25);
            content.Click += new EventHandler(this.content_Click);
            this.Controls.Add(content);

            Button counter = new Button();
            counter.Text = "counter";
            counter.Size = new Size(55, 23);
            counter.Location = new Point(766, 25);
            counter.Click += new EventHandler(this.counter_Click);
            this.Controls.Add(counter);
        }
        private void counter_Click(object sender, EventArgs e)
        {
            Form counterForm = new Form();
            counterForm.Size = new Size(189, 147);
            counterForm.StartPosition = FormStartPosition.CenterScreen;
            counterForm.ShowIcon = false;
            counterForm.ShowInTaskbar = false;
            counterForm.Text = "counter";
            counterForm.Name = "counterForm";
            counterForm.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            counterForm.Show();

            Button counterOK = new Button();
            counterOK.Location = new System.Drawing.Point(75, 78);
            counterOK.Size = new System.Drawing.Size(34, 23);
            counterOK.Text = "OK";
            counterOK.Click += new EventHandler(this.counterOK_Click);
            counterForm.Controls.Add(counterOK);

            Button counterCancel = new Button();
            counterCancel.Location = new System.Drawing.Point(115, 78);
            counterCancel.Size = new System.Drawing.Size(48, 23);
            counterCancel.Text = "Cancel";
            counterCancel.Click += new EventHandler(this.counterCancel_Click);
            counterForm.Controls.Add(counterCancel);

            ListBox counterType = new ListBox();
            counterType.Items.AddRange(new object[] {
            "none",
            "number",
            "variable"});
            counterType.Location = new System.Drawing.Point(12, 39);
            counterType.Name = "counterType";
            counterType.Size = new System.Drawing.Size(57, 43);
            counterType.SelectedIndexChanged += new System.EventHandler(this.counterType_SelectedIndexChanged);
            counterForm.Controls.Add(counterType);

            NumericUpDown counterNUD = new NumericUpDown();
            counterNUD.Location = new System.Drawing.Point(75, 49);
            counterNUD.Name = "counterNUD";
            counterNUD.Size = new System.Drawing.Size(88, 20);
            counterNUD.Maximum = 10000;
            counterNUD.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            counterForm.Controls.Add(counterNUD);

            TextBox counterVariable = new TextBox();
            counterVariable.Location = new System.Drawing.Point(75, 49);
            counterVariable.Name = "counterVariable";
            counterVariable.Size = new System.Drawing.Size(88, 20);
            counterVariable.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            counterForm.Controls.Add(counterVariable);

            ComboBox counters = new ComboBox();
            counters.Items.AddRange(new object[] {
            "counter-increment",
            "counter-reset"});
            counters.Location = new System.Drawing.Point(12, 12);
            counters.Name = "counters";
            counters.Size = new System.Drawing.Size(109, 21);
            counters.Text = "counter-increment";
            counterForm.Controls.Add(counters);
        }
        private void content_Click(object sender, EventArgs e)
        {
            Form contentForm = new Form();
            contentForm.Size = new Size(135, 148);
            contentForm.StartPosition = FormStartPosition.CenterScreen;
            contentForm.ShowIcon = false;
            contentForm.ShowInTaskbar = false;
            contentForm.Text = "content";
            contentForm.Name = "contentForm";
            contentForm.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            contentForm.Show();

            Button contentOK = new Button();
            contentOK.Location = new System.Drawing.Point(17, 85);
            contentOK.Name = "contentOK";
            contentOK.Size = new System.Drawing.Size(34, 23);
            contentOK.Text = "OK";
            contentOK.Click += new EventHandler(this.contentOK_Click);
            contentForm.Controls.Add(contentOK);

            Button contentCancel = new Button();
            contentCancel.Location = new System.Drawing.Point(57, 85);
            contentCancel.Name = "contentCancel";
            contentCancel.Size = new System.Drawing.Size(48, 23);
            contentCancel.Text = "Cancel";
            contentCancel.Click += new EventHandler(this.contentCancel_Click);
            contentForm.Controls.Add(contentCancel);

            Label label1 = new Label();
            label1.Location = new System.Drawing.Point(12, 9);
            label1.Size = new System.Drawing.Size(43, 13);
            label1.Text = "content";
            contentForm.Controls.Add(label1);

            ComboBox contentType = new ComboBox();
            contentType.Items.AddRange(new object[] {
            "url",
            "attr",
            "none",
            "string",
            "normal",
            "counter",
            "open-quote",
            "close-quote",
            "no-open-quote",
            "no-close-quote"});
            contentType.Location = new System.Drawing.Point(12, 25);
            contentType.Name = "contentType";
            contentType.Size = new System.Drawing.Size(93, 21);
            contentType.Text = "url";
            contentType.SelectedIndexChanged += new System.EventHandler(this.contentType_SelectedIndexChanged);
            contentForm.Controls.Add(contentType);

            TextBox contentTypeVal = new TextBox();
            contentTypeVal.Location = new System.Drawing.Point(12, 59);
            contentTypeVal.Name = "contentTypeVal";
            contentTypeVal.Size = new System.Drawing.Size(93, 20);
            contentForm.Controls.Add(contentTypeVal);
        }
        private void objectfit_Click(object sender, EventArgs e)
        {
            Form objectfitForm = new Form();
            objectfitForm.Size = new Size(120, 140);
            objectfitForm.StartPosition = FormStartPosition.CenterScreen;
            objectfitForm.ShowIcon = false;
            objectfitForm.ShowInTaskbar = false;
            objectfitForm.Text = "object-fit";
            objectfitForm.Name = "objectfitForm";
            objectfitForm.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            objectfitForm.MaximizeBox = false;
            objectfitForm.Show();

            Button objectOK = new Button();
            objectOK.Location = new System.Drawing.Point(16, 74);
            objectOK.Size = new System.Drawing.Size(34, 23);
            objectOK.Text = "OK";
            objectOK.Click += new EventHandler(this.objectOK_Click);
            objectfitForm.Controls.Add(objectOK);

            Button objectCancel = new Button();
            objectCancel.Location = new System.Drawing.Point(56, 74);
            objectCancel.Size = new System.Drawing.Size(48, 23);
            objectCancel.Text = "Cancel";
            objectCancel.Click += new EventHandler(this.objectCancel_Click);
            objectfitForm.Controls.Add(objectCancel);

            Label label1 = new Label();
            label1.Location = new System.Drawing.Point(12, 31);
            label1.Size = new System.Drawing.Size(40, 13);
            label1.Text = "type";
            objectfitForm.Controls.Add(label1);

            ListBox objectFitType = new ListBox();
            objectFitType.Items.AddRange(new object[] {
            "fill",
            "contain",
            "cover",
            "none"});
            objectFitType.Location = new System.Drawing.Point(52, 12);
            objectFitType.Name = "objectFitType";
            objectFitType.Size = new System.Drawing.Size(52, 56);
            objectfitForm.Controls.Add(objectFitType);
        }
        private void clear_Click(object sendere, EventArgs e)
        {
            Form clearForm = new Form();
            clearForm.Size = new Size(142, 133);
            clearForm.StartPosition = FormStartPosition.CenterScreen;
            clearForm.ShowIcon = false;
            clearForm.ShowInTaskbar = false;
            clearForm.Text = "clear";
            clearForm.Name = "clearForm";
            clearForm.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            clearForm.MaximizeBox = false;
            clearForm.Show();

            Button clearOK = new Button();
            clearOK.Location = new System.Drawing.Point(16, 62);
            clearOK.Size = new System.Drawing.Size(42, 23);
            clearOK.Text = "OK";
            clearOK.Click += new EventHandler(this.clearOK_Click);
            clearForm.Controls.Add(clearOK);

            Button clearCancel = new Button();
            clearCancel.Location = new System.Drawing.Point(64, 62);
            clearCancel.Size = new System.Drawing.Size(50, 23);
            clearCancel.Text = "Cancel";
            clearCancel.Click += new EventHandler(this.clearCancel_Click);
            clearForm.Controls.Add(clearCancel);

            ComboBox clearType = new ComboBox();
            clearType.Items.AddRange(new object[] {
            "none",
            "left",
            "right",
            "both"});
            clearType.Location = new System.Drawing.Point(14, 25);
            clearType.Name = "clearType";
            clearType.Size = new System.Drawing.Size(98, 21);
            clearForm.Controls.Add(clearType);

            Label label1 = new Label();
            label1.Location = new System.Drawing.Point(12, 9);
            label1.Size = new System.Drawing.Size(30, 13);
            label1.Text = "clear";
            clearForm.Controls.Add(label1);
        }
        private void cursor_Click(object sender, EventArgs e)
        {
            Form cursorForm = new Form();
            cursorForm.Size = new Size(142, 208);
            cursorForm.StartPosition = FormStartPosition.CenterScreen;
            cursorForm.ShowIcon = false;
            cursorForm.ShowInTaskbar = false;
            cursorForm.Text = "cursor";
            cursorForm.Name = "cursorForm";
            cursorForm.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            cursorForm.MaximizeBox = false;
            cursorForm.Show();

            Button cursorOK = new Button();
            cursorOK.Location = new System.Drawing.Point(14, 139);
            cursorOK.Size = new System.Drawing.Size(42, 23);
            cursorOK.Text = "OK";
            cursorOK.Click += new EventHandler(this.cursorOK_Click);
            cursorForm.Controls.Add(cursorOK);

            Button cursorCancel = new Button();
            cursorCancel.Location = new System.Drawing.Point(62, 139);
            cursorCancel.Size = new System.Drawing.Size(50, 23);
            cursorCancel.Text = "Cancel";
            cursorCancel.Click += new EventHandler(this.cursorCancel_Click);
            cursorForm.Controls.Add(cursorCancel);

            ComboBox systemcur = new ComboBox();
            systemcur.Items.AddRange(new object[] {
            "default",
            "context-menu",
            "help",
            "pointer",
            "progress",
            "wait",
            "cell",
            "crosshair",
            "text",
            "vertical-text",
            "alias",
            "copy",
            "move",
            "no-drop",
            "not-allowed",
            "all-scroll",
            "col-resize",
            "row-resize",
            "n-resize",
            "ne-resize",
            "e-resize",
            "se-resize",
            "s-resize",
            "sw-resize",
            "w-resize",
            "nw-resize",
            "nesw-resize",
            "nwse-resize",
            "zoom-in",
            "zoom-out",
            "grab",
            "grabbing"});
            systemcur.Location = new System.Drawing.Point(14, 25);
            systemcur.Name = "systemcur";
            systemcur.Size = new System.Drawing.Size(98, 21);
            systemcur.SelectedIndexChanged += new System.EventHandler(this.systemcur_SelectedIndexChanged);
            systemcur.TextChanged += new System.EventHandler(this.systemcur_TextChanged);
            cursorForm.Controls.Add(systemcur);

            Label label1 = new Label();
            label1.Location = new System.Drawing.Point(12, 9);
            label1.Size = new System.Drawing.Size(39, 13);
            label1.Text = "system";
            cursorForm.Controls.Add(label1);

            Label label2 = new Label();
            label2.Location = new System.Drawing.Point(12, 57);
            label2.Size = new System.Drawing.Size(41, 13);
            label2.Text = "custom";
            cursorForm.Controls.Add(label2);

            Button cursorSelect = new Button();
            cursorSelect.Location = new System.Drawing.Point(14, 73);
            cursorSelect.Size = new System.Drawing.Size(45, 23);
            cursorSelect.Text = "Select";
            cursorSelect.Click += new System.EventHandler(this.cursorSelect_Click);
            cursorForm.Controls.Add(cursorSelect);

            TextBox cursorURL = new TextBox();
            cursorURL.Location = new System.Drawing.Point(65, 75);
            cursorURL.Name = "cursorURL";
            cursorURL.Size = new System.Drawing.Size(47, 20);
            cursorURL.TextChanged += new System.EventHandler(this.cursorURL_TextChanged);
            cursorForm.Controls.Add(cursorURL);

            PictureBox cursorPic = new PictureBox();
            cursorPic.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            cursorPic.Location = new System.Drawing.Point(17, 101);
            cursorPic.Name = "cursorPic";
            cursorPic.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            cursorPic.Size = new System.Drawing.Size(93, 32);
            cursorForm.Controls.Add(cursorPic);
        }
        private void letterspacing_Click(object sender, EventArgs e)
        {
            Form letterspacingForm = new Form();
            letterspacingForm.Size = new Size(166, 121);
            letterspacingForm.StartPosition = FormStartPosition.CenterScreen;
            letterspacingForm.ShowIcon = false;
            letterspacingForm.ShowInTaskbar = false;
            letterspacingForm.Text = "letter-spacing";
            letterspacingForm.Name = "letterspacingForm";
            letterspacingForm.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            letterspacingForm.MaximizeBox = false;
            letterspacingForm.Show();

            Button letterOK = new Button();
            letterOK.Location = new System.Drawing.Point(49, 55);
            letterOK.Size = new System.Drawing.Size(42, 23);
            letterOK.Text = "OK";
            letterOK.Click += new EventHandler(this.letterOK_Click);
            letterspacingForm.Controls.Add(letterOK);

            Button letterCancel = new Button();
            letterCancel.Location = new System.Drawing.Point(97, 55);
            letterCancel.Size = new System.Drawing.Size(50, 23);
            letterCancel.Text = "Cancel";
            letterCancel.Click += new EventHandler(this.letterCancel_Click);
            letterspacingForm.Controls.Add(letterCancel);

            ComboBox spacingType = new ComboBox();
            spacingType.Items.AddRange(new object[] {
            "normal",
            "px",
            "%"});
            spacingType.Location = new System.Drawing.Point(13, 22);
            spacingType.Name = "spacingType";
            spacingType.Size = new System.Drawing.Size(56, 21);
            spacingType.SelectedIndexChanged += new EventHandler(this.spacingType_SelectedIndexChanged);
            letterspacingForm.Controls.Add(spacingType);

            NumericUpDown spacingValNUD = new NumericUpDown();
            spacingValNUD.Location = new System.Drawing.Point(76, 22);
            spacingValNUD.Maximum = 8192;
            spacingValNUD.Name = "spacingValNUD";
            spacingValNUD.Size = new System.Drawing.Size(46, 20);
            letterspacingForm.Controls.Add(spacingValNUD);

            Label label1 = new Label();
            label1.Location = new System.Drawing.Point(129, 25);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(18, 13);
            letterspacingForm.Controls.Add(label1);
        }
        private void resize_Click(object sender, EventArgs e)
        {
            Form resizeForm = new Form();
            resizeForm.Size = new Size(188, 136);
            resizeForm.StartPosition = FormStartPosition.CenterScreen;
            resizeForm.ShowIcon = false;
            resizeForm.ShowInTaskbar = false;
            resizeForm.Text = "white-space";
            resizeForm.Name = "resizeForm";
            resizeForm.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            resizeForm.MaximizeBox = false;
            resizeForm.Show();

            Button resizeOK = new Button();
            resizeOK.Location = new System.Drawing.Point(67, 73);
            resizeOK.Size = new System.Drawing.Size(42, 23);
            resizeOK.Text = "OK";
            resizeOK.Click += new EventHandler(this.resizeOK_Click);
            resizeForm.Controls.Add(resizeOK);

            Button resizeCancel = new Button();
            resizeCancel.Location = new System.Drawing.Point(115, 73);
            resizeCancel.Size = new System.Drawing.Size(50, 23);
            resizeCancel.Text = "Cancel";
            resizeCancel.Click += new EventHandler(this.resizeCancel_Click);
            resizeForm.Controls.Add(resizeCancel);

            Label label1 = new Label();
            label1.Location = new System.Drawing.Point(8, 31);
            label1.Size = new System.Drawing.Size(34, 13);
            label1.Text = "resize";
            resizeForm.Controls.Add(label1);

            ListBox resizeVal = new ListBox();
            resizeVal.Items.AddRange(new object[] {
            "none",
            "both",
            "horizontal",
            "vertical"});
            resizeVal.Location = new System.Drawing.Point(78, 19);
            resizeVal.Name = "resizeVal";
            resizeVal.Size = new System.Drawing.Size(87, 43);
            resizeForm.Controls.Add(resizeVal);
        }
        private void white_Click(object sender, EventArgs e)
        {
            Form whiteForm = new Form();
            whiteForm.Size = new Size(188, 136);
            whiteForm.StartPosition = FormStartPosition.CenterScreen;
            whiteForm.ShowIcon = false;
            whiteForm.ShowInTaskbar = false;
            whiteForm.Text = "white-space";
            whiteForm.Name = "whiteForm";
            whiteForm.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            whiteForm.MaximizeBox = false;
            whiteForm.Show();

            Button whiteOK = new Button();
            whiteOK.Location = new System.Drawing.Point(67, 73);
            whiteOK.Size = new System.Drawing.Size(42, 23);
            whiteOK.Text = "OK";
            whiteOK.Click += new EventHandler(this.whiteOK_Click);
            whiteForm.Controls.Add(whiteOK);

            Button whiteCancel = new Button();
            whiteCancel.Location = new System.Drawing.Point(115, 73);
            whiteCancel.Size = new System.Drawing.Size(50, 23);
            whiteCancel.Text = "Cancel";
            whiteCancel.Click += new EventHandler(this.whiteCancel_Click);
            whiteForm.Controls.Add(whiteCancel);

            Label label1 = new Label();
            label1.Location = new System.Drawing.Point(8, 31);
            label1.Size = new System.Drawing.Size(64, 13);
            label1.Text = "white-space";
            whiteForm.Controls.Add(label1);

            ListBox whiteType = new ListBox();
            whiteType.Items.AddRange(new object[] {
            "normal",
            "nowrap",
            "pre",
            "pre-line",
            "pre-wrap"});
            whiteType.Location = new System.Drawing.Point(78, 19);
            whiteType.Name = "whiteType";
            whiteType.Size = new System.Drawing.Size(87, 43);
            whiteForm.Controls.Add(whiteType);
        }
        public void quotes_Click(object sender, EventArgs e)
        {
            Form quotesForm = new Form();
            quotesForm.Size = new Size(193, 141);
            quotesForm.StartPosition = FormStartPosition.CenterScreen;
            quotesForm.ShowIcon = false;
            quotesForm.ShowInTaskbar = false;
            quotesForm.Text = "quotes";
            quotesForm.Name = "quotesForm";
            quotesForm.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            quotesForm.MaximizeBox = false;
            quotesForm.Show();

            Button quotesOK = new Button();
            quotesOK.Location = new System.Drawing.Point(67, 73);
            quotesOK.Size = new System.Drawing.Size(42, 23);
            quotesOK.Text = "OK";
            quotesOK.Click += new EventHandler(this.quotesOK_Click);
            quotesForm.Controls.Add(quotesOK);

            Button quotesCancel = new Button();
            quotesCancel.Location = new System.Drawing.Point(115, 73);
            quotesCancel.Size = new System.Drawing.Size(50, 23);
            quotesCancel.Text = "Cancel";
            quotesCancel.Click += new EventHandler(this.quotesCancel_Click);
            quotesForm.Controls.Add(quotesCancel);

            ListBox quotesType = new ListBox();
            quotesType.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            quotesType.FormattingEnabled = true;
            quotesType.ItemHeight = 25;
            quotesType.Items.AddRange(new object[] {
            "\" \"",
            "\' \'",
            "« »",
            "‘ ’",
            "“ ”"});
            quotesType.Location = new System.Drawing.Point(12, 11);
            quotesType.Name = "quotesType";
            quotesType.Size = new System.Drawing.Size(59, 54);
            quotesType.SelectedIndexChanged += new System.EventHandler(this.quotesType_SelectedIndexChanged);
            quotesForm.Controls.Add(quotesType);

            Label label1 = new Label();
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(81, 32);
            label1.Size = new System.Drawing.Size(35, 13);
            label1.Name = "label1";
            quotesForm.Controls.Add(label1);

            Label label2 = new Label();
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(130, 32);
            label2.Size = new System.Drawing.Size(35, 13);
            label2.Name = "label2";
            quotesForm.Controls.Add(label2);
        }
        private void visibility_Click(object sender, EventArgs e)
        {
            Form visibilityForm = new Form();
            visibilityForm.Size = new Size(136, 131);
            visibilityForm.StartPosition = FormStartPosition.CenterScreen;
            visibilityForm.ShowIcon = false;
            visibilityForm.ShowInTaskbar = false;
            visibilityForm.Text = "word";
            visibilityForm.Name = "visibilityForm";
            visibilityForm.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            visibilityForm.MaximizeBox = false;
            visibilityForm.Show();

            Label label1 = new Label();
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(12, 26);
            label1.Size = new System.Drawing.Size(42, 13);
            label1.Text = "visibility";
            visibilityForm.Controls.Add(label1);

            ListBox visibilityVal = new ListBox();
            visibilityVal.Items.AddRange(new object[] {
            "visible",
            "hidden",
            "collapse"});
            visibilityVal.Location = new System.Drawing.Point(60, 10);
            visibilityVal.Name = "visibilityVal";
            visibilityVal.Size = new System.Drawing.Size(50, 43);
            visibilityForm.Controls.Add(visibilityVal);

            Button visibilityOK = new Button();
            visibilityOK.Location = new System.Drawing.Point(16, 64);
            visibilityOK.Size = new System.Drawing.Size(42, 23);
            visibilityOK.Text = "OK";
            visibilityOK.Click += new EventHandler(this.visibilityOK_Click);
            visibilityForm.Controls.Add(visibilityOK);

            Button visibilityCancel = new Button();
            visibilityCancel.Location = new System.Drawing.Point(64, 64);
            visibilityCancel.Size = new System.Drawing.Size(50, 23);
            visibilityCancel.Text = "Cancel";
            visibilityCancel.Click += new EventHandler(this.visibilityCancel_Click);
            visibilityForm.Controls.Add(visibilityCancel);
        }
        private void word_Click(object sender, EventArgs e)
        {
            Form wordForm = new Form();
            wordForm.Size = new Size(173, 250);
            wordForm.StartPosition = FormStartPosition.CenterScreen;
            wordForm.ShowIcon = false;
            wordForm.ShowInTaskbar = false;
            wordForm.Text = "word";
            wordForm.Name = "wordForm";
            wordForm.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            wordForm.MaximizeBox = false;
            wordForm.Show();

            Button wordOK = new Button();
            wordOK.Location = new System.Drawing.Point(52, 181);
            wordOK.Size = new System.Drawing.Size(48, 23);
            wordOK.Text = "OK";
            wordOK.Click += new EventHandler(this.wordOK_Click);
            wordForm.Controls.Add(wordOK);

            Button wordCancel = new Button();
            wordCancel.Location = new System.Drawing.Point(106, 181);
            wordCancel.Size = new System.Drawing.Size(48, 23);
            wordCancel.Text = "Cancel";
            wordCancel.Click += new EventHandler(this.wordCancel_Click);
            wordForm.Controls.Add(wordCancel);

            Label label1 = new Label();
            label1.Location = new System.Drawing.Point(12, 9);
            label1.Size = new System.Drawing.Size(60, 13);
            label1.Text = "word-break";
            wordForm.Controls.Add(label1);

            RadioButton bNormal = new RadioButton();
            bNormal.Location = new System.Drawing.Point(17, 30);
            bNormal.Name = "bNormal";
            bNormal.Size = new System.Drawing.Size(56, 17);
            bNormal.Text = "normal";
            wordForm.Controls.Add(bNormal);

            RadioButton breakall = new RadioButton();
            breakall.Location = new System.Drawing.Point(17, 53);
            breakall.Name = "breakall";
            breakall.Size = new System.Drawing.Size(65, 17);
            breakall.Text = "break-all";
            wordForm.Controls.Add(breakall);

            RadioButton keepall = new RadioButton();
            keepall.Location = new System.Drawing.Point(87, 30);
            keepall.Name = "keepall";
            keepall.Size = new System.Drawing.Size(62, 17);
            keepall.Text = "keep-all";
            wordForm.Controls.Add(keepall);

            Label label2 = new Label();
            label2.Location = new System.Drawing.Point(12, 84);
            label2.Size = new System.Drawing.Size(70, 13);
            label2.Text = "word-spacing";
            wordForm.Controls.Add(label2);

            ComboBox wSpacingMeasure = new ComboBox();
            wSpacingMeasure.Items.AddRange(new object[] {
            "normal",
            "px",
            "%"});
            wSpacingMeasure.Location = new System.Drawing.Point(13, 103);
            wSpacingMeasure.Name = "wSpacingMeasure";
            wSpacingMeasure.Size = new System.Drawing.Size(53, 21);
            wSpacingMeasure.SelectedIndexChanged += new EventHandler(this.wSpacingMeasure_SelectedIndexChanged);
            wordForm.Controls.Add(wSpacingMeasure);

            Label label3 = new Label();
            label3.Location = new System.Drawing.Point(129, 105);
            label3.Size = new System.Drawing.Size(18, 13);
            label3.Name = "label3";
            label3.Text = "px";
            wordForm.Controls.Add(label3);

            NumericUpDown wSpacingNUD = new NumericUpDown();
            wSpacingNUD.Location = new System.Drawing.Point(72, 103);
            wSpacingNUD.Name = "wSpacingNUD";
            wSpacingNUD.Size = new System.Drawing.Size(51, 20);
            wSpacingNUD.Maximum = 8192;
            wordForm.Controls.Add(wSpacingNUD);

            Label label4 = new Label();
            label4.Location = new System.Drawing.Point(14, 148);
            label4.Size = new System.Drawing.Size(56, 13);
            label4.Text = "word-wrap";
            wordForm.Controls.Add(label4);

            ListBox wordWrapMeasure = new ListBox();
            wordWrapMeasure.Items.AddRange(new object[] {
            "normal",
            "break-word"});
            wordWrapMeasure.Location = new System.Drawing.Point(76, 140);
            wordWrapMeasure.Name = "wordWrapMeasure";
            wordWrapMeasure.Size = new System.Drawing.Size(73, 30);
            wordForm.Controls.Add(wordWrapMeasure);
        }
        private void transform_Click(object sender, EventArgs e)
        {
            Form transformForm = new Form();
            transformForm.Size = new Size(246, 460);
            transformForm.StartPosition = FormStartPosition.CenterScreen;
            transformForm.ShowIcon = false;
            transformForm.ShowInTaskbar = false;
            transformForm.Text = "transform";
            transformForm.Name = "transformForm";
            transformForm.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            transformForm.MaximizeBox = false;
            transformForm.Show();

            Button transformOK = new Button();
            transformOK.Location = new System.Drawing.Point(116, 392);
            transformOK.Size = new System.Drawing.Size(48, 23);
            transformOK.Text = "OK";
            transformOK.Click += new EventHandler(this.transformOK_Click);
            transformForm.Controls.Add(transformOK);

            Button transformCancel = new Button();
            transformCancel.Location = new System.Drawing.Point(172, 392);
            transformCancel.Size = new System.Drawing.Size(48, 23);
            transformCancel.Text = "Cancel";
            transformCancel.Click += new EventHandler(this.transformCancel_Click);
            transformForm.Controls.Add(transformCancel);

            GroupBox transform = new GroupBox();
            transform.Location = new System.Drawing.Point(12, 12);
            transform.Name = "transform";
            transform.Size = new System.Drawing.Size(208, 233);
            transform.Text = "transform";
            transformForm.Controls.Add(transform);

            CheckBox noTransformChk = new CheckBox();
            noTransformChk.AutoSize = true;
            noTransformChk.Location = new System.Drawing.Point(12, 20);
            noTransformChk.Name = "noTransformChk";
            noTransformChk.Size = new System.Drawing.Size(84, 17);
            noTransformChk.Text = "no transform";
            noTransformChk.CheckedChanged += new System.EventHandler(this.noTransformChk_CheckedChanged);
            transform.Controls.Add(noTransformChk);

            Label label13 = new Label();
            label13.Location = new System.Drawing.Point(170, 206);
            label13.Size = new System.Drawing.Size(18, 13);
            label13.Text = "px";
            transform.Controls.Add(label13);

            NumericUpDown translateYNUD = new NumericUpDown();
            translateYNUD.Location = new System.Drawing.Point(116, 204);
            translateYNUD.Maximum = 8192;
            translateYNUD.Name = "translateYNUD";
            translateYNUD.Size = new System.Drawing.Size(51, 20);
            translateYNUD.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            transform.Controls.Add(translateYNUD);

            Label label7 = new Label();
            label7.Location = new System.Drawing.Point(66, 206);
            label7.Size = new System.Drawing.Size(18, 13);
            label7.Text = "px";
            transform.Controls.Add(label7);

            NumericUpDown translateXNUD = new NumericUpDown();
            translateXNUD.Location = new System.Drawing.Point(12, 204);
            translateXNUD.Maximum = 8192;
            translateXNUD.Name = "translateXNUD";
            translateXNUD.Size = new System.Drawing.Size(51, 20);
            translateXNUD.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            transform.Controls.Add(translateXNUD);

            Label label11 = new Label();
            label11.Location = new System.Drawing.Point(163, 155);
            label11.Size = new System.Drawing.Size(25, 13);
            label11.Text = "deg";
            transform.Controls.Add(label11);

            Label label2 = new Label();
            label2.Location = new System.Drawing.Point(59, 155);
            label2.Size = new System.Drawing.Size(25, 13);
            label2.Text = "deg";
            transform.Controls.Add(label2);

            NumericUpDown skewYNUD = new NumericUpDown();
            skewYNUD.Location = new System.Drawing.Point(116, 153);
            skewYNUD.Maximum = 360;
            skewYNUD.Name = "skewYNUD";
            skewYNUD.Size = new System.Drawing.Size(41, 20);
            skewYNUD.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            transform.Controls.Add(skewYNUD);

            NumericUpDown skewXNUD = new NumericUpDown();
            skewXNUD.Location = new System.Drawing.Point(12, 153);
            skewXNUD.Maximum = 360;
            skewXNUD.Name = "skewXNUD";
            skewXNUD.Size = new System.Drawing.Size(41, 20);
            skewXNUD.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            transform.Controls.Add(skewXNUD);

            ListBox scaleYVal = new ListBox();
            scaleYVal.Items.AddRange(new object[] {
            "0.1",
            "0.2",
            "0.3",
            "0.4",
            "0.5",
            "0.6",
            "0.7",
            "0.8",
            "0.9",
            "1",
            "1.1",
            "1.2",
            "1.3",
            "1.4",
            "1.5",
            "1.6",
            "1.7",
            "1.8",
            "1.9",
            "2",
            "2.1",
            "2.2",
            "2.3",
            "2.4",
            "2.5",
            "2.6",
            "2.7",
            "2.8",
            "2.9",
            "3",
            "3.1",
            "3.2",
            "3.3",
            "3.4",
            "3.5",
            "3.6",
            "3.7",
            "3.8",
            "3.9",
            "4",
            "4.1",
            "4.2",
            "4.3",
            "4.4",
            "4.5",
            "4.6",
            "4.7",
            "4.8",
            "4.9",
            "5"});
            scaleYVal.Location = new System.Drawing.Point(116, 93);
            scaleYVal.Name = "scaleYVal";
            scaleYVal.Size = new System.Drawing.Size(41, 30);
            transform.Controls.Add(scaleYVal);

            ListBox scaleXVal = new ListBox();
            scaleXVal.FormattingEnabled = true;
            scaleXVal.Items.AddRange(new object[] {
            "0.1",
            "0.2",
            "0.3",
            "0.4",
            "0.5",
            "0.6",
            "0.7",
            "0.8",
            "0.9",
            "1",
            "1.1",
            "1.2",
            "1.3",
            "1.4",
            "1.5",
            "1.6",
            "1.7",
            "1.8",
            "1.9",
            "2",
            "2.1",
            "2.2",
            "2.3",
            "2.4",
            "2.5",
            "2.6",
            "2.7",
            "2.8",
            "2.9",
            "3",
            "3.1",
            "3.2",
            "3.3",
            "3.4",
            "3.5",
            "3.6",
            "3.7",
            "3.8",
            "3.9",
            "4",
            "4.1",
            "4.2",
            "4.3",
            "4.4",
            "4.5",
            "4.6",
            "4.7",
            "4.8",
            "4.9",
            "5"});
            scaleXVal.Location = new System.Drawing.Point(12, 93);
            scaleXVal.Name = "scaleXVal";
            scaleXVal.Size = new System.Drawing.Size(41, 30);
            transform.Controls.Add(scaleXVal);

            Label label12 = new Label();
            label12.Location = new System.Drawing.Point(163, 52);
            label12.Size = new System.Drawing.Size(25, 13);
            label12.Text = "deg";
            transform.Controls.Add(label12);

            NumericUpDown rotateNUD = new NumericUpDown();
            rotateNUD.Location = new System.Drawing.Point(116, 50);
            rotateNUD.Maximum = 360;
            rotateNUD.Name = "rotateNUD";
            rotateNUD.Size = new System.Drawing.Size(41, 20);
            rotateNUD.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            transform.Controls.Add(rotateNUD);

            Label label9 = new Label();
            label9.Location = new System.Drawing.Point(113, 187);
            label9.Size = new System.Drawing.Size(54, 13);
            label9.Text = "translateY";
            transform.Controls.Add(label9);

            Label label8 = new Label();
            label8.Location = new System.Drawing.Point(9, 187);
            label8.Size = new System.Drawing.Size(54, 13);
            label8.Text = "translateX";
            transform.Controls.Add(label8);

            Label label4 = new Label();
            label4.Location = new System.Drawing.Point(113, 77);
            label4.Size = new System.Drawing.Size(39, 13);
            label4.Text = "scaleY";
            transform.Controls.Add(label4);

            Label label3 = new Label();
            label3.Location = new System.Drawing.Point(9, 77);
            label3.Size = new System.Drawing.Size(39, 13);
            label3.Text = "scaleX";
            transform.Controls.Add(label3);

            Label label6 = new Label();
            label6.Location = new System.Drawing.Point(113, 137);
            label6.Size = new System.Drawing.Size(39, 13);
            label6.Text = "skewY";
            transform.Controls.Add(label6);

            Label label5 = new Label();
            label5.Location = new System.Drawing.Point(9, 137);
            label5.Size = new System.Drawing.Size(39, 13);
            label5.Text = "skewX";
            transform.Controls.Add(label5);

            Label label1 = new Label();
            label1.Location = new System.Drawing.Point(9, 52);
            label1.Size = new System.Drawing.Size(34, 13);
            label1.Text = "rotate";
            transform.Controls.Add(label1);

            Label label10 = new Label();
            label10.Location = new System.Drawing.Point(18, 257);
            label10.Size = new System.Drawing.Size(74, 13);
            label10.Text = "transform-style";
            transformForm.Controls.Add(label10);

            RadioButton flat = new RadioButton();
            flat.Location = new System.Drawing.Point(101, 256);
            flat.Name = "flat";
            flat.Size = new System.Drawing.Size(39, 17);
            flat.Text = "flat";
            transformForm.Controls.Add(flat);

            RadioButton preserve = new RadioButton();
            preserve.Location = new System.Drawing.Point(146, 256);
            preserve.Name = "preserve";
            preserve.Size = new System.Drawing.Size(81, 17);
            preserve.Text = "preserve-3d";
            transformForm.Controls.Add(preserve);

            GroupBox transformOrigin = new GroupBox();
            transformOrigin.Location = new System.Drawing.Point(12, 279);
            transformOrigin.Name = "transformOrigin";
            transformOrigin.Size = new System.Drawing.Size(208, 100);
            transformOrigin.Text = "transform-origin";
            transformForm.Controls.Add(transformOrigin);

            NumericUpDown originYNUD = new NumericUpDown();
            originYNUD.Location = new System.Drawing.Point(116, 47);
            originYNUD.Name = "originYNUD";
            originYNUD.Size = new System.Drawing.Size(63, 20);
            originYNUD.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            originYNUD.Maximum = 8192;
            transformOrigin.Controls.Add(originYNUD);

            NumericUpDown originXNUD = new NumericUpDown();
            originXNUD.Location = new System.Drawing.Point(116, 23);
            originXNUD.Name = "originXNUD";
            originXNUD.Size = new System.Drawing.Size(63, 20);
            originXNUD.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            originXNUD.Maximum = 8192;
            transformOrigin.Controls.Add(originXNUD);

            Label label19 = new Label();
            label19.Location = new System.Drawing.Point(184, 50);
            label19.Size = new System.Drawing.Size(18, 13);
            label19.Name = "label19";
            transformOrigin.Controls.Add(label19);

            Label label18 = new Label();
            label18.Location = new System.Drawing.Point(184, 25);
            label18.Size = new System.Drawing.Size(18, 13);
            label18.Name = "label18";
            transformOrigin.Controls.Add(label18);

            Label label17 = new Label();
            label17.Location = new System.Drawing.Point(184, 75);
            label17.Size = new System.Drawing.Size(18, 13);
            label17.Name = "label17";
            transformOrigin.Controls.Add(label17);

            NumericUpDown originZNUD = new NumericUpDown();
            originZNUD.Location = new System.Drawing.Point(116, 73);
            originZNUD.Maximum = 8192;
            originZNUD.Name = "originZNUD";
            originZNUD.Size = new System.Drawing.Size(62, 20);
            originZNUD.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            transformOrigin.Controls.Add(originZNUD);

            ComboBox originYMeasure = new ComboBox();
            originYMeasure.Items.AddRange(new object[] {
            "top",
            "center",
            "bottom",
            "px",
            "%"});
            originYMeasure.Location = new System.Drawing.Point(52, 47);
            originYMeasure.Name = "originYMeasure";
            originYMeasure.Size = new System.Drawing.Size(56, 21);
            originYMeasure.SelectedIndexChanged += new System.EventHandler(this.originYMeasure_SelectedIndexChanged);
            transformOrigin.Controls.Add(originYMeasure);

            ComboBox originXMeasure = new ComboBox();
            originXMeasure.Items.AddRange(new object[] {
            "left",
            "center",
            "right",
            "px",
            "%"});
            originXMeasure.Location = new System.Drawing.Point(52, 22);
            originXMeasure.Name = "originXMeasure";
            originXMeasure.Size = new System.Drawing.Size(56, 21);
            originXMeasure.SelectedIndexChanged += new System.EventHandler(this.originXMeasure_SelectedIndexChanged);
            transformOrigin.Controls.Add(originXMeasure);

            Label label16 = new Label();
            label16.Location = new System.Drawing.Point(9, 75);
            label16.Size = new System.Drawing.Size(14, 13);
            label16.Text = "Z";
            transformOrigin.Controls.Add(label16);

            Label label15 = new Label();
            label15.Location = new System.Drawing.Point(9, 50);
            label15.Size = new System.Drawing.Size(14, 13);
            label15.Text = "Y";
            transformOrigin.Controls.Add(label15);

            Label label14 = new Label();
            label14.Location = new System.Drawing.Point(9, 25);
            label14.Size = new System.Drawing.Size(14, 13);
            label14.Text = "X";
            transformOrigin.Controls.Add(label14);

            ComboBox originZMeasure = new ComboBox();
            originZMeasure.Items.AddRange(new object[] {
            "px",
            "%"});
            originZMeasure.Location = new System.Drawing.Point(52, 71);
            originZMeasure.Name = "originZMeasure";
            originZMeasure.Size = new System.Drawing.Size(56, 21);
            originZMeasure.SelectedIndexChanged += new System.EventHandler(this.originZMeasure_SelectedIndexChanged);
            transformOrigin.Controls.Add(originZMeasure);
        }
        private void linkBtn_Click(object sender, EventArgs e)
        {
            Form linkForm = new Form();
            linkForm.Size = new Size(339, 168);
            linkForm.StartPosition = FormStartPosition.CenterScreen;
            linkForm.ShowIcon = false;
            linkForm.Text = "Link";
            linkForm.Name = "linkForm";
            linkForm.ShowInTaskbar = false;
            linkForm.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            linkForm.MaximizeBox = false;
            linkForm.Show();

            Label linkLbl = new Label();
            linkLbl.Size = new Size(28, 13);
            linkLbl.Location = new Point(9, 9);
            linkLbl.Text = "link";
            linkForm.Controls.Add(linkLbl);

            TextBox linkVal = new TextBox();
            linkVal.Name = "linkVal";
            linkVal.Size = new Size(299, 22);
            linkVal.Location = new Point(12, 25);
            linkForm.Controls.Add(linkVal);

            Label NameLbl = new Label();
            NameLbl.Size = new Size(71, 13);
            NameLbl.Location = new Point(10, 51);
            NameLbl.Text = "name";
            linkForm.Controls.Add(NameLbl);

            TextBox NameVal = new TextBox();
            NameVal.Name = "NameVal";
            NameVal.Size = new Size(299, 22);
            NameVal.Location = new Point(12, 67);
            linkForm.Controls.Add(NameVal);

            Button linkOK = new Button();
            linkOK.Location = new Point(223, 95);
            linkOK.Size = new Size(35, 23);
            linkOK.Text = "OK";
            linkOK.Click += new System.EventHandler(this.linkOK_Click);
            linkForm.Controls.Add(linkOK);

            Button linkCancel = new Button();
            linkCancel.Location = new Point(263, 95);
            linkCancel.Size = new Size(50, 23);
            linkCancel.Text = "Cancel";
            linkCancel.Click += new System.EventHandler(this.linkCancel_Click);
            linkForm.Controls.Add(linkCancel);
        }
        private void audioBtn_Click(object sender, EventArgs e)
        {
            Form audioForm = new Form();
            audioForm.Size = new Size(205, 182);
            audioForm.StartPosition = FormStartPosition.CenterScreen;
            audioForm.ShowIcon = false;
            audioForm.Text = "audio";
            audioForm.Name = "AudioForm";
            audioForm.ShowInTaskbar = false;
            audioForm.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            audioForm.MaximizeBox = false;
            audioForm.Show();

            Label autostartLabel = new Label();
            autostartLabel.Size = new Size(109, 13);
            autostartLabel.Location = new Point(10, 13);
            autostartLabel.Text = "autostart";
            audioForm.Controls.Add(autostartLabel);

            CheckBox autoStart = new CheckBox();
            autoStart.Name = "autoStart";
            autoStart.Text = "";
            autoStart.Location = new Point(166, 13);
            autoStart.Size = new Size(15, 14);
            audioForm.Controls.Add(autoStart);

            Label loopLabel = new Label();
            loopLabel.Size = new Size(38, 13);
            loopLabel.Location = new Point(10, 39);
            loopLabel.Text = "repeat";
            audioForm.Controls.Add(loopLabel);

            CheckBox loop = new CheckBox();
            loop.Name = "loop";
            loop.Location = new Point(166, 39);
            loop.Size = new Size(15, 14);
            loop.Text = "";
            audioForm.Controls.Add(loop);

            Label audioFile = new Label();
            audioFile.Text = "file";
            audioFile.Size = new Size(27, 13);
            audioFile.Location = new Point(10, 65);
            audioForm.Controls.Add(audioFile);

            Button selectAUDIO = new Button();
            selectAUDIO.Size = new Size(45, 23);
            selectAUDIO.Location = new Point(11, 81);
            selectAUDIO.Text = "Select";
            audioForm.Controls.Add(selectAUDIO);
            selectAUDIO.Click += new System.EventHandler(this.selectAUDIO_Click);

            RichTextBox audioURL = new RichTextBox();
            audioURL.Size = new Size(124, 22);
            audioURL.Location = new Point(57, 82);
            audioURL.Name = "audioURL";
            audioURL.Multiline = false;
            audioForm.Controls.Add(audioURL);

            Button audioOK = new Button();
            audioOK.Size = new Size(30, 23);
            audioOK.Location = new Point(101, 110);
            audioOK.Text = "OK";
            audioOK.Click += new System.EventHandler(this.audioOK_Click);
            audioForm.Controls.Add(audioOK);

            Button audioCancel = new Button();
            audioCancel.Size = new Size(50, 23);
            audioCancel.Location = new Point(132, 110);
            audioCancel.Text = "Cancel";
            audioCancel.Click += new System.EventHandler(this.audioCancel_Click);
            audioForm.Controls.Add(audioCancel);
        }
        private void imgBtn_Click(object sender, EventArgs e)
        {
            Form imgForm = new Form();
            imgForm.Size = new Size(245, 262);
            imgForm.StartPosition = FormStartPosition.CenterScreen;
            imgForm.ShowIcon = false;
            imgForm.Text = "image";
            imgForm.Name = "imgForm";
            imgForm.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            imgForm.MaximizeBox = false;
            imgForm.ShowInTaskbar = false;
            imgForm.Show();

            Label altName = new Label();
            altName.Size = new Size(64, 13);
            altName.Location = new Point(12, 13);
            altName.Text = "name";
            imgForm.Controls.Add(altName);

            TextBox altNameVal = new TextBox();
            altNameVal.Name = "altNameVal";
            altNameVal.Size = new Size(112, 20);
            altNameVal.Location = new Point(101, 10);
            //altNameVal.TextAlign = HorizontalAlignment.Center;
            imgForm.Controls.Add(altNameVal);

            Label imgWidth = new Label();
            imgWidth.Text = "width";
            imgWidth.Size = new Size(82, 13);
            imgWidth.Location = new Point(12, 39);
            imgForm.Controls.Add(imgWidth);

            NumericUpDown imgWidthVal = new NumericUpDown();
            imgWidthVal.Size = new Size(87, 20);
            imgWidthVal.Location = new Point(101, 36);
            imgWidthVal.Name = "imgWidthVal";
            imgWidthVal.Maximum = 8192;
            imgWidthVal.TextAlign = HorizontalAlignment.Center;
            imgForm.Controls.Add(imgWidthVal);

            Label widthPx = new Label();
            widthPx.Location = new Point(194, 38);
            widthPx.Size = new Size(18, 13);
            widthPx.Text = "px";
            imgForm.Controls.Add(widthPx);

            Label heightPx = new Label();
            heightPx.Location = new Point(194, 65);
            heightPx.Size = new Size(18, 13);
            heightPx.Text = "px";
            imgForm.Controls.Add(heightPx);

            Label imgHeight = new Label();
            imgHeight.Size = new Size(53, 13);
            imgHeight.Location = new Point(12, 65);
            imgHeight.Text = "height";
            imgForm.Controls.Add(imgHeight);

            NumericUpDown imgHeightVal = new NumericUpDown();
            imgHeightVal.Size = new Size(87, 20);
            imgHeightVal.Location = new Point(101, 62);
            imgHeightVal.Name = "imgHeightVal";
            imgHeightVal.Maximum = 8192;
            imgHeightVal.TextAlign = HorizontalAlignment.Center;
            imgForm.Controls.Add(imgHeightVal);

            Label isMap = new Label();
            isMap.Size = new Size(87, 13);
            isMap.Location = new Point(12, 91);
            isMap.Text = "is map";
            imgForm.Controls.Add(isMap);

            CheckBox isMapCheck = new CheckBox();
            isMapCheck.Name = "isMapCheck";
            isMapCheck.Size = new Size(15, 15);
            isMapCheck.Location = new Point(198, 93);
            imgForm.Controls.Add(isMapCheck);

            Label mapID = new Label();
            mapID.Text = "map size";
            mapID.Location = new Point(12, 117);
            mapID.Size = new Size(114, 13);
            imgForm.Controls.Add(mapID);

            TextBox mapIDVal = new TextBox();
            mapIDVal.Name = "mapIDVal";
            mapIDVal.Location = new Point(132, 114);
            mapIDVal.Size = new Size(80, 20);
            imgForm.Controls.Add(mapIDVal);

            Label imgLbl = new Label();
            imgLbl.Size = new Size(26, 13);
            imgLbl.Location = new Point(12, 143);
            imgLbl.Text = "file";
            imgForm.Controls.Add(imgLbl);

            Button imgSelect = new Button();
            imgSelect.Size = new Size(50, 23);
            imgSelect.Location = new Point(15, 159);
            imgSelect.Text = "Select";
            imgSelect.Click += new System.EventHandler(this.imgSelect_Click);
            imgForm.Controls.Add(imgSelect);

            RichTextBox imgURL = new RichTextBox();
            imgURL.Name = "imgURL";
            imgURL.Size = new Size(112, 20);
            imgURL.Location = new Point(101, 161);
            imgURL.Multiline = false;
            imgForm.Controls.Add(imgURL);

            Button imgOK = new Button();
            imgOK.Text = "OK";
            imgOK.Size = new Size(40, 23);
            imgOK.Location = new Point(117, 189);
            imgOK.Click += new System.EventHandler(this.imgOK_Click);
            imgForm.Controls.Add(imgOK);

            Button imgCancel = new Button();
            imgCancel.Size = new Size(50, 23);
            imgCancel.Location = new Point(163, 189);
            imgCancel.Text = "Cancel";
            imgCancel.Click += new System.EventHandler(this.imgCancel_Click);
            imgForm.Controls.Add(imgCancel);
        }
        public void bgImg_Click(object sender, EventArgs e)
        {
            Form backgroundForm = new Form();
            backgroundForm.Size = new Size(342, 409);
            backgroundForm.StartPosition = FormStartPosition.CenterScreen;
            backgroundForm.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            backgroundForm.Name = "backgroundForm";
            backgroundForm.Text = "background";
            backgroundForm.ShowIcon = false;
            backgroundForm.ShowInTaskbar = false;
            backgroundForm.MaximizeBox = false;
            backgroundForm.Show();

            Button backgroundOK = new Button();
            backgroundOK.Location = new System.Drawing.Point(230, 337);
            backgroundOK.Size = new System.Drawing.Size(32, 23);
            backgroundOK.Text = "OK";
            backgroundOK.Click += new EventHandler(this.backgroundOK_Click);
            backgroundForm.Controls.Add(backgroundOK);

            Button backgroundCancel = new Button();
            backgroundCancel.Location = new System.Drawing.Point(265, 337);
            backgroundCancel.Size = new System.Drawing.Size(50, 23);
            backgroundCancel.Text = "Cancel";
            backgroundCancel.Click += new EventHandler(this.backgroundCancel_Click);
            backgroundForm.Controls.Add(backgroundCancel);

            Label bgColorLbl = new Label();
            bgColorLbl.Text = "color";
            bgColorLbl.Location = new Point(13, 15);
            bgColorLbl.Size = new Size(33, 13);
            backgroundForm.Controls.Add(bgColorLbl);

            Label label7 = new Label();
            label7.Location = new System.Drawing.Point(13, 145);
            label7.Size = new System.Drawing.Size(152, 13);
            label7.Text = "background-clip";
            backgroundForm.Controls.Add(label7);

            Label label6 = new Label();
            label6.Location = new System.Drawing.Point(13, 120);
            label6.Size = new System.Drawing.Size(128, 13);
            label6.Text = "background-origin";
            backgroundForm.Controls.Add(label6);

            Label label4 = new Label();
            label4.Location = new System.Drawing.Point(13, 93);
            label4.Size = new System.Drawing.Size(66, 13);
            label4.Text = "repeat";
            backgroundForm.Controls.Add(label4);

            Label label3 = new Label();
            label3.Location = new System.Drawing.Point(13, 67);
            label3.Size = new System.Drawing.Size(128, 13);
            label3.Text = "background-attachment";
            backgroundForm.Controls.Add(label3);


            Label label2 = new Label();
            label2.Location = new System.Drawing.Point(13, 41);
            label2.Size = new System.Drawing.Size(51, 13);
            label2.Text = "image";
            backgroundForm.Controls.Add(label2);

            Button backgroundColorSelect = new Button();
            backgroundColorSelect.Location = new System.Drawing.Point(140, 10);
            backgroundColorSelect.Size = new System.Drawing.Size(48, 23);
            backgroundColorSelect.Text = "Select";
            backgroundColorSelect.Name = "backgroundColorSelect";
            backgroundColorSelect.Click += new EventHandler(this.backgroundColorSelect_Click);
            backgroundForm.Controls.Add(backgroundColorSelect);

            TextBox backgroundColor = new TextBox();
            backgroundColor.Name = "backgroundColor";
            backgroundColor.Size = new Size(60, 20);
            backgroundColor.Location = new Point(191, 12);
            backgroundForm.Controls.Add(backgroundColor);

            CheckBox transparentChk = new CheckBox();
            transparentChk.Location = new System.Drawing.Point(255, 14);
            transparentChk.Name = "transparentChk";
            transparentChk.Size = new System.Drawing.Size(59, 17);
            transparentChk.Text = "limpid";
            transparentChk.CheckedChanged += new System.EventHandler(this.transparentChk_CheckedChanged);
            backgroundForm.Controls.Add(transparentChk);

            Button backgroundImgSelect = new Button();
            backgroundImgSelect.Location = new System.Drawing.Point(140, 36);
            backgroundImgSelect.Size = new System.Drawing.Size(48, 23);
            backgroundImgSelect.Text = "Select";
            backgroundImgSelect.Click += new EventHandler(this.backgroundImgSelect_Click);
            backgroundForm.Controls.Add(backgroundImgSelect);

            TextBox backgroundImgURL = new TextBox();
            backgroundImgURL.Location = new System.Drawing.Point(191, 38);
            backgroundImgURL.Name = "backgroundImgURL";
            backgroundImgURL.Size = new System.Drawing.Size(123, 20);
            backgroundForm.Controls.Add(backgroundImgURL);

            ComboBox backgroundScroll = new ComboBox();
            backgroundScroll.Items.AddRange(new object[] {
            "fixed",
            "scroll",
            "local"});
            backgroundScroll.Location = new System.Drawing.Point(191, 64);
            backgroundScroll.Name = "backgroundScroll";
            backgroundScroll.Size = new System.Drawing.Size(123, 21);
            backgroundForm.Controls.Add(backgroundScroll);

            ComboBox backgroudRepeat = new ComboBox();
            backgroudRepeat.Items.AddRange(new object[] {
            "repeat-x",
            "repeat-y",
            "repeat",
            "space",
            "round",
            "no-repeat"});
            backgroudRepeat.Location = new System.Drawing.Point(191, 90);
            backgroudRepeat.Name = "backgroudRepeat";
            backgroudRepeat.Size = new System.Drawing.Size(123, 21);
            backgroundForm.Controls.Add(backgroudRepeat);

            ComboBox backgroundClip = new ComboBox();
            backgroundClip.Items.AddRange(new object[] {
            "padding-box",
            "border-box",
            "content-box"});
            backgroundClip.Location = new System.Drawing.Point(191, 142);
            backgroundClip.Name = "backgroundClip";
            backgroundClip.Size = new System.Drawing.Size(124, 21);
            backgroundForm.Controls.Add(backgroundClip);

            ComboBox backgroundOrigin = new ComboBox();
            backgroundOrigin.Items.AddRange(new object[] {
            "padding-box",
            "border-box",
            "content-box"});
            backgroundOrigin.Location = new System.Drawing.Point(190, 117);
            backgroundOrigin.Name = "backgroundOrigin";
            backgroundOrigin.Size = new System.Drawing.Size(125, 21);
            backgroundForm.Controls.Add(backgroundOrigin);

            GroupBox bgImagePosition = new GroupBox();
            bgImagePosition.Location = new System.Drawing.Point(6, 169);
            bgImagePosition.Name = "bgImagePosition";
            bgImagePosition.Size = new System.Drawing.Size(310, 76);
            bgImagePosition.Text = "Image position";
            backgroundForm.Controls.Add(bgImagePosition);

            Label label17 = new Label();
            label17.Location = new System.Drawing.Point(6, 50);
            label17.Size = new System.Drawing.Size(40, 13);
            label17.Text = "sizes";
            bgImagePosition.Controls.Add(label17);

            Label label12 = new Label();
            label12.Location = new System.Drawing.Point(6, 24);
            label12.Size = new System.Drawing.Size(50, 13);
            label12.Text = "measure";
            bgImagePosition.Controls.Add(label12);

            ComboBox measureTypes = new ComboBox();
            measureTypes.Items.AddRange(new object[] {
            "constants[top,left and etc.]",
            "persents[%]",
            "pixels [px]"});
            measureTypes.Location = new System.Drawing.Point(182, 21);
            measureTypes.Name = "measureTypes";
            measureTypes.Size = new System.Drawing.Size(124, 21);
            measureTypes.SelectedIndexChanged += new System.EventHandler(this.measureTypes_SelectedIndexChanged);
            bgImagePosition.Controls.Add(measureTypes);

            Label label9 = new Label();
            label9.Location = new System.Drawing.Point(287, 50);
            label9.Size = new System.Drawing.Size(15, 13);
            label9.Text = "%";
            label9.Name = "label9";
            label9.Visible = false;
            bgImagePosition.Controls.Add(label9);

            NumericUpDown position2 = new NumericUpDown();
            position2.Location = new System.Drawing.Point(234, 48);
            position2.Name = "position2";
            position2.Size = new System.Drawing.Size(51, 20);
            position2.Visible = false;
            bgImagePosition.Controls.Add(position2);

            Label label8 = new Label();
            label8.Location = new System.Drawing.Point(213, 50);
            label8.Size = new System.Drawing.Size(15, 13);
            label8.Text = "%";
            label8.Name = "label8";
            label8.Visible = false;
            bgImagePosition.Controls.Add(label8);

            NumericUpDown position1 = new NumericUpDown();
            position1.Location = new System.Drawing.Point(161, 48);
            position1.Name = "position1";
            position1.Size = new System.Drawing.Size(48, 20);
            position1.Visible = false;
            bgImagePosition.Controls.Add(position1);

            ComboBox LCR1 = new ComboBox();
            LCR1.Items.AddRange(new object[] {
            "left",
            "center",
            "right"});
            LCR1.Location = new System.Drawing.Point(236, 47);
            LCR1.Name = "LCR1";
            LCR1.Size = new System.Drawing.Size(70, 21);
            bgImagePosition.Controls.Add(LCR1);

            ComboBox LCR2 = new ComboBox();
            LCR2.Items.AddRange(new object[] {
            "top",
            "center",
            "bottom"});
            LCR2.Location = new System.Drawing.Point(158, 47);
            LCR2.Name = "LCR2";
            LCR2.Size = new System.Drawing.Size(70, 21);
            bgImagePosition.Controls.Add(LCR2);

            GroupBox bgImageSize = new GroupBox();
            bgImageSize.Location = new System.Drawing.Point(5, 251);
            bgImageSize.Name = "bgImageSize";
            bgImageSize.Size = new System.Drawing.Size(310, 60);
            bgImageSize.Text = "image size";
            backgroundForm.Controls.Add(bgImageSize);

            Label label5 = new Label();
            label5.Location = new System.Drawing.Point(6, 51);
            label5.Size = new System.Drawing.Size(40, 13);
            label5.Text = "sizes";
            label5.Name = "label5";
            label5.Visible = false;
            bgImageSize.Controls.Add(label5);

            Label label10 = new Label();
            label10.Location = new System.Drawing.Point(6, 25);
            label10.Size = new System.Drawing.Size(45, 13);
            label10.Text = "types";
            bgImageSize.Controls.Add(label10);

            ComboBox sizeType = new ComboBox();
            sizeType.FormattingEnabled = true;
            sizeType.Items.AddRange(new object[] {
            "auto",
            "cover",
            "contain ",
            "persents[%]",
            "pixels [px]"});
            sizeType.Location = new System.Drawing.Point(183, 22);
            sizeType.Name = "sizeType";
            sizeType.Size = new System.Drawing.Size(124, 21);
            sizeType.SelectedIndexChanged += new System.EventHandler(this.sizeType_SelectedIndexChanged);
            bgImageSize.Controls.Add(sizeType);

            Label label13 = new Label();
            label13.Location = new System.Drawing.Point(288, 51);
            label13.Size = new System.Drawing.Size(15, 13);
            label13.Text = "%";
            label13.Name = "label13";
            label13.Visible = false;
            bgImageSize.Controls.Add(label13);

            NumericUpDown size2 = new NumericUpDown();
            size2.Location = new System.Drawing.Point(235, 49);
            size2.Name = "size2";
            size2.Size = new System.Drawing.Size(51, 20);
            size2.Visible = false;
            bgImageSize.Controls.Add(size2);

            Label label11 = new Label();
            label11.Location = new System.Drawing.Point(214, 51);
            label11.Size = new System.Drawing.Size(15, 13);
            label11.Text = "%";
            label11.Name = "label11";
            label11.Visible = false;
            bgImageSize.Controls.Add(label11);

            NumericUpDown size1 = new NumericUpDown();
            size1.Location = new System.Drawing.Point(159, 49);
            size1.Name = "size1";
            size1.Size = new System.Drawing.Size(51, 20);
            size1.Visible = false;
            bgImageSize.Controls.Add(size1);

        }
        public void showForm_Click(object sender, EventArgs e)
        {
            Form frm = new Form();
            frm.Size = new Size(173, 218);
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            frm.Name = "MarginSelector";
            frm.Text = "margin";
            frm.ShowIcon = false;
            frm.ShowInTaskbar = false;
            frm.MaximizeBox = false;
            frm.Show();

            Label marginTop = new Label();
            marginTop.Text = "top";
            marginTop.Size = new Size(36, 13);
            marginTop.Location = new Point(12, 13);
            frm.Controls.Add(marginTop);


            Label marginBtm = new Label();
            marginBtm.Text = "bottom";
            marginBtm.Size = new Size(36, 18);
            marginBtm.Location = new Point(12, 45);
            frm.Controls.Add(marginBtm);

            Label marginLeft = new Label();
            marginLeft.Text = "left";
            marginLeft.Size = new Size(24, 13);
            marginLeft.Location = new Point(12, 77);
            frm.Controls.Add(marginLeft);

            Label marginRight = new Label();
            marginRight.Text = "right";
            marginRight.Size = new Size(36, 18);
            marginRight.Location = new Point(12, 107);
            frm.Controls.Add(marginRight);

            NumericUpDown marginTopVal = new NumericUpDown();
            marginTopVal.Name = "top";
            marginTopVal.Location = new Point(88, 11);
            marginTopVal.Size = new Size(55, 20);
            frm.Controls.Add(marginTopVal);

            NumericUpDown marginBtmVal = new NumericUpDown();
            marginBtmVal.Name = "bottom";
            marginBtmVal.Location = new Point(88, 43);
            marginBtmVal.Size = new Size(55, 20);
            frm.Controls.Add(marginBtmVal);


            NumericUpDown marginLeftVal = new NumericUpDown();
            marginLeftVal.Name = "left";
            marginLeftVal.Location = new Point(88, 75);
            marginLeftVal.Size = new Size(55, 20);
            frm.Controls.Add(marginLeftVal);


            NumericUpDown marginRightVal = new NumericUpDown();
            marginRightVal.Name = "right";
            marginRightVal.Location = new Point(88, 105);
            marginRightVal.Size = new Size(55, 20);
            frm.Controls.Add(marginRightVal);


            Button OKBtn = new Button();
            OKBtn.Visible = true;
            OKBtn.Text = "OK";
            OKBtn.Size = new Size(32, 23);
            OKBtn.Location = new Point(58, 146);
            frm.Controls.Add(OKBtn);
            OKBtn.Click += new System.EventHandler(this.OKBtn_Click);

            Button CancelBtn = new Button();
            CancelBtn.Visible = true;
            CancelBtn.Text = "Cancel";
            CancelBtn.Size = new Size(50, 23);
            CancelBtn.Location = new Point(95, 146);
            frm.Controls.Add(CancelBtn);
            CancelBtn.Click += new System.EventHandler(this.CancelBtn_Click);
        }
        private void pageBreak_Click(object sender, EventArgs e)
        {
            Form pageBreakForm = new Form();
            pageBreakForm.Size = new Size(228, 153);
            pageBreakForm.StartPosition = FormStartPosition.CenterScreen;
            pageBreakForm.ShowIcon = false;
            pageBreakForm.ShowInTaskbar = false;
            pageBreakForm.Text = "page-break";
            pageBreakForm.Name = "pageBreakForm";
            pageBreakForm.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            pageBreakForm.MaximizeBox = false;
            pageBreakForm.Show();

            Button pageBreakOk = new Button();
            pageBreakOk.Location = new System.Drawing.Point(104, 87);
            pageBreakOk.Size = new System.Drawing.Size(48, 23);
            pageBreakOk.Text = "OK";
            pageBreakOk.Click += new EventHandler(this.pageBreakOk_Click);
            pageBreakForm.Controls.Add(pageBreakOk);

            Button pageBreakCancel = new Button();
            pageBreakCancel.Location = new System.Drawing.Point(155, 87);
            pageBreakCancel.Size = new System.Drawing.Size(48, 23);
            pageBreakCancel.Text = "Cancel";
            pageBreakCancel.Click += new EventHandler(this.pageBreakCancel_Click);
            pageBreakForm.Controls.Add(pageBreakCancel);

            Label label1 = new Label();
            label1.Location = new System.Drawing.Point(8, 41);
            label1.Size = new System.Drawing.Size(64, 13);
            label1.Text = "page-break-";
            pageBreakForm.Controls.Add(label1);

            ComboBox pagebreakType = new ComboBox();
            pagebreakType.Items.AddRange(new object[] {
            "after",
            "before",
            "inside"});
            pagebreakType.Location = new System.Drawing.Point(73, 38);
            pagebreakType.Name = "pagebreakType";
            pagebreakType.Size = new System.Drawing.Size(66, 21);
            pagebreakType.SelectedIndexChanged += new System.EventHandler(this.pagebreakType_SelectedIndexChanged);
            pageBreakForm.Controls.Add(pagebreakType);

            ListBox pagebreakVal = new ListBox();
            pagebreakVal.Items.AddRange(new object[] {
            "always",
            "auto",
            "avoid",
            "left",
            "right"});
            pagebreakVal.Location = new System.Drawing.Point(152, 12);
            pagebreakVal.Name = "pagebreakVal";
            pagebreakVal.Size = new System.Drawing.Size(48, 69);
            pageBreakForm.Controls.Add(pagebreakVal);
        }
        private void overflow_Click(object sender, EventArgs e)
        {
            Form overflowForm = new Form();
            overflowForm.Size = new Size(166, 142);
            overflowForm.StartPosition = FormStartPosition.CenterScreen;
            overflowForm.ShowIcon = false;
            overflowForm.ShowInTaskbar = false;
            overflowForm.Text = "overflow";
            overflowForm.Name = "overflowForm";
            overflowForm.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            overflowForm.MaximizeBox = false;
            overflowForm.Show();

            Button overflowOK = new Button();
            overflowOK.Location = new System.Drawing.Point(37, 71);
            overflowOK.Name = "overflowOK";
            overflowOK.Size = new System.Drawing.Size(45, 23);
            overflowOK.Text = "OK";
            overflowOK.Click += new EventHandler(this.overflowOK_Click);
            overflowForm.Controls.Add(overflowOK);

            Button overflowCancel = new Button();
            overflowCancel.Location = new System.Drawing.Point(88, 71);
            overflowCancel.Name = "overflowCancel";
            overflowCancel.Size = new System.Drawing.Size(48, 23);
            overflowCancel.Text = "Cancel";
            overflowCancel.Click += new EventHandler(this.overflowCancel_Click);
            overflowForm.Controls.Add(overflowCancel);

            ListBox overflows = new ListBox();
            overflows.Items.AddRange(new object[] {
            "overflow",
            "overflow-x",
            "overflow-y"});
            overflows.Location = new System.Drawing.Point(12, 12);
            overflows.Name = "overflows";
            overflows.Size = new System.Drawing.Size(59, 43);
            overflowForm.Controls.Add(overflows);

            ComboBox overflowData = new ComboBox();
            overflowData.Items.AddRange(new object[] {
            "auto",
            "hidden",
            "scroll",
            "visible"});
            overflowData.Location = new System.Drawing.Point(77, 23);
            overflowData.Name = "overflowData";
            overflowData.Size = new System.Drawing.Size(59, 21);
            overflowForm.Controls.Add(overflowData);
        }
        private void text_Click(object sender, EventArgs e)
        {
            Form textForm = new Form();
            textForm.Size = new Size(217, 422);
            textForm.StartPosition = FormStartPosition.CenterScreen;
            textForm.ShowIcon = false;
            textForm.ShowInTaskbar = false;
            textForm.Text = "text";
            textForm.Name = "textForm";
            textForm.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            textForm.MaximizeBox = false;
            textForm.Show();

            GroupBox textAlignGrpBox = new GroupBox();
            textAlignGrpBox.Location = new System.Drawing.Point(13, 13);
            textAlignGrpBox.Name = "textAlignGrpBox";
            textAlignGrpBox.Size = new System.Drawing.Size(177, 82);
            textAlignGrpBox.Text = "text-align";
            textForm.Controls.Add(textAlignGrpBox);

            ComboBox textAlignLastCmb = new ComboBox();
            textAlignLastCmb.Items.AddRange(new object[] {
            "start",
            "end",
            "left",
            "right",
            "center",
            "justify"});
            textAlignLastCmb.Location = new System.Drawing.Point(112, 50);
            textAlignLastCmb.Name = "textAlignLastCmb";
            textAlignLastCmb.Size = new System.Drawing.Size(59, 21);
            textAlignGrpBox.Controls.Add(textAlignLastCmb);

            ComboBox textAlignCmb = new ComboBox();
            textAlignCmb.Items.AddRange(new object[] {
            "center",
            "justify",
            "left",
            "right",
            "start",
            "end"});
            textAlignCmb.Location = new System.Drawing.Point(112, 17);
            textAlignCmb.Name = "textAlignCmb";
            textAlignCmb.Size = new System.Drawing.Size(59, 21);
            textAlignGrpBox.Controls.Add(textAlignCmb);

            Label label2 = new Label();
            label2.Location = new System.Drawing.Point(7, 53);
            label2.Size = new System.Drawing.Size(68, 13);
            label2.Text = "text-align-last";
            textAlignGrpBox.Controls.Add(label2);

            Label label1 = new Label();
            label1.Location = new System.Drawing.Point(7, 20);
            label1.Size = new System.Drawing.Size(49, 13);
            label1.Text = "text-align";
            textAlignGrpBox.Controls.Add(label1);

            Button textOK = new Button();
            textOK.Location = new System.Drawing.Point(91, 349);
            textOK.Size = new System.Drawing.Size(45, 23);
            textOK.Text = "OK";
            textOK.Click += new EventHandler(this.textOK_Click);
            textForm.Controls.Add(textOK);

            Button textCancel = new Button();
            textCancel.Location = new System.Drawing.Point(140, 349);
            textCancel.Size = new System.Drawing.Size(50, 23);
            textCancel.Text = "Cancel";
            textCancel.Click += new EventHandler(this.textCancel_Click);
            textForm.Controls.Add(textCancel);

            Label label3 = new Label();
            label3.Location = new System.Drawing.Point(20, 110);
            label3.Size = new System.Drawing.Size(56, 13);
            label3.Text = "text-indent";
            textForm.Controls.Add(label3);

            NumericUpDown textIndentNUD = new NumericUpDown();
            textIndentNUD.Location = new System.Drawing.Point(99, 108);
            textIndentNUD.Maximum = 8192;
            textIndentNUD.Name = "textIndentNUD";
            textIndentNUD.Size = new System.Drawing.Size(44, 20);
            textForm.Controls.Add(textIndentNUD);

            ComboBox textIndentMeasureCmb = new ComboBox();
            textIndentMeasureCmb.Items.AddRange(new object[] {
            "px",
            "%"});
            textIndentMeasureCmb.Location = new System.Drawing.Point(149, 107);
            textIndentMeasureCmb.Name = "textIndentMeasureCmb";
            textIndentMeasureCmb.Size = new System.Drawing.Size(41, 21);
            textIndentMeasureCmb.SelectedIndexChanged += new EventHandler(this.textIndentMeasureCmb_SelectedIndexChanged);
            textForm.Controls.Add(textIndentMeasureCmb);

            Label label4 = new Label();
            label4.Location = new System.Drawing.Point(20, 141);
            label4.Size = new System.Drawing.Size(67, 13);
            label4.Text = "text-overflow";
            textForm.Controls.Add(label4);

            RadioButton clip = new RadioButton();
            clip.Location = new System.Drawing.Point(149, 139);
            clip.Name = "clip";
            clip.Size = new System.Drawing.Size(41, 17);
            clip.Text = "clip";
            textForm.Controls.Add(clip);

            RadioButton ellipsis = new RadioButton();
            ellipsis.Location = new System.Drawing.Point(88, 139);
            ellipsis.Name = "ellipsis";
            ellipsis.Size = new System.Drawing.Size(55, 17);
            ellipsis.Text = "ellipsis";
            textForm.Controls.Add(ellipsis);

            GroupBox textShadowGrpBox = new GroupBox();
            textShadowGrpBox.Location = new System.Drawing.Point(12, 167);
            textShadowGrpBox.Name = "textShadowGrpBox";
            textShadowGrpBox.Size = new System.Drawing.Size(177, 164);
            textShadowGrpBox.Text = "text-shadow";
            textForm.Controls.Add(textShadowGrpBox);

            CheckBox noShadow = new CheckBox();
            noShadow.Location = new System.Drawing.Point(11, 20);
            noShadow.Name = "noShadow";
            noShadow.Size = new System.Drawing.Size(78, 17);
            noShadow.Text = "no shadow";
            noShadow.CheckedChanged += new EventHandler(this.noShadow_CheckedChanged);
            textShadowGrpBox.Controls.Add(noShadow);

            Label label5 = new Label();
            label5.Location = new System.Drawing.Point(8, 49);
            label5.Size = new System.Drawing.Size(50, 13);
            label5.Text = "text-color";
            textShadowGrpBox.Controls.Add(label5);

            Button textShadowSelect = new Button();
            textShadowSelect.Location = new System.Drawing.Point(58, 44);
            textShadowSelect.Size = new System.Drawing.Size(47, 23);
            textShadowSelect.Text = "Select";
            textShadowSelect.Name = "textShadowSelect";
            textShadowSelect.Click += new EventHandler(this.textShadowSelect_Click);
            textShadowGrpBox.Controls.Add(textShadowSelect);

            TextBox textShadowColor = new TextBox();
            textShadowColor.Location = new System.Drawing.Point(105, 46);
            textShadowColor.Name = "textShadowColor";
            textShadowColor.Size = new System.Drawing.Size(66, 20);
            textShadowColor.TextAlign = HorizontalAlignment.Center;
            textShadowGrpBox.Controls.Add(textShadowColor);

            Label label6 = new Label();
            label6.Location = new System.Drawing.Point(8, 77);
            label6.Size = new System.Drawing.Size(53, 13);
            label6.Text = "h-shadow";
            textShadowGrpBox.Controls.Add(label6);

            NumericUpDown hshadowNUD = new NumericUpDown();
            hshadowNUD.Location = new System.Drawing.Point(90, 75);
            hshadowNUD.Name = "hshadowNUD";
            hshadowNUD.Size = new System.Drawing.Size(57, 20);
            hshadowNUD.Maximum = 8192;
            textShadowGrpBox.Controls.Add(hshadowNUD);

            Label label7 = new Label();
            label7.Location = new System.Drawing.Point(153, 77);
            label7.Size = new System.Drawing.Size(18, 13);
            label7.Text = "px";
            textShadowGrpBox.Controls.Add(label7);

            Label label8 = new Label();
            label8.Location = new System.Drawing.Point(8, 103);
            label8.Size = new System.Drawing.Size(53, 13);
            label8.Text = "v-shadow";
            textShadowGrpBox.Controls.Add(label8);

            NumericUpDown vshadowNUD = new NumericUpDown();
            vshadowNUD.Location = new System.Drawing.Point(90, 101);
            vshadowNUD.Name = "vshadowNUD";
            vshadowNUD.Size = new System.Drawing.Size(57, 20);
            vshadowNUD.Maximum = 8192;
            textShadowGrpBox.Controls.Add(vshadowNUD);

            Label label9 = new Label();
            label9.Location = new System.Drawing.Point(153, 103);
            label9.Size = new System.Drawing.Size(18, 13);
            label9.Text = "px";
            textShadowGrpBox.Controls.Add(label9);

            Label label10 = new Label();
            label10.Location = new System.Drawing.Point(8, 129);
            label10.Size = new System.Drawing.Size(35, 13);
            label10.Text = "radius";
            textShadowGrpBox.Controls.Add(label10);

            NumericUpDown radiusNUD = new NumericUpDown();
            radiusNUD.Location = new System.Drawing.Point(90, 127);
            radiusNUD.Name = "radiusNUD";
            radiusNUD.Size = new System.Drawing.Size(57, 20);
            radiusNUD.Maximum = 8192;
            textShadowGrpBox.Controls.Add(radiusNUD);

            Label label11 = new Label();
            label11.Location = new System.Drawing.Point(153, 129);
            label11.Size = new System.Drawing.Size(18, 13);
            label11.Text = "px";
            textShadowGrpBox.Controls.Add(label11);
        }
        private void columns_Click(object sender, EventArgs e)
        {
            Form columnsForm = new Form();
            columnsForm.Size = new Size(290, 372);
            columnsForm.StartPosition = FormStartPosition.CenterScreen;
            columnsForm.ShowIcon = false;
            columnsForm.ShowInTaskbar = false;
            columnsForm.Text = "columns";
            columnsForm.Name = "columnsForm";
            columnsForm.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            columnsForm.MaximizeBox = false;
            columnsForm.Show();

            GroupBox columnGBox = new GroupBox();
            columnGBox.Location = new System.Drawing.Point(13, 13);
            columnGBox.Name = "columnGBox";
            columnGBox.Size = new System.Drawing.Size(248, 150);
            columnGBox.Text = "columns";
            columnsForm.Controls.Add(columnGBox);

            Label label1 = new Label();
            label1.Location = new System.Drawing.Point(7, 20);
            label1.Size = new System.Drawing.Size(69, 13);
            label1.Text = "column-width";
            columnGBox.Controls.Add(label1);

            Label label2 = new Label();
            label2.Location = new System.Drawing.Point(7, 53);
            label2.Size = new System.Drawing.Size(71, 13);
            label2.Text = "column-count";
            columnGBox.Controls.Add(label2);

            NumericUpDown columnwidthNUD = new NumericUpDown();
            columnwidthNUD.Location = new System.Drawing.Point(84, 18);
            columnwidthNUD.Name = "columnwidthNUD";
            columnwidthNUD.Size = new System.Drawing.Size(47, 20);
            columnwidthNUD.Maximum = 8192;
            columnGBox.Controls.Add(columnwidthNUD);

            ComboBox columnwidthMeasure = new ComboBox();
            columnwidthMeasure.Items.AddRange(new object[] {
            "px",
            "%"});
            columnwidthMeasure.Location = new System.Drawing.Point(137, 17);
            columnwidthMeasure.Name = "columnwidthMeasure";
            columnwidthMeasure.Size = new System.Drawing.Size(43, 21);
            columnwidthMeasure.SelectedIndexChanged += new EventHandler(this.columnwidthMeasure_SelectedIndexChanged);
            columnGBox.Controls.Add(columnwidthMeasure);

            CheckBox columnwidthAutoChk = new CheckBox();
            columnwidthAutoChk.Location = new System.Drawing.Point(186, 19);
            columnwidthAutoChk.Name = "columnwidthAutoChk";
            columnwidthAutoChk.Size = new System.Drawing.Size(47, 17);
            columnwidthAutoChk.Text = "auto";
            columnwidthAutoChk.CheckedChanged += new EventHandler(this.columnwidthAutoChk_CheckedChanged);
            columnGBox.Controls.Add(columnwidthAutoChk);

            NumericUpDown columncountNUD = new NumericUpDown();
            columncountNUD.Location = new System.Drawing.Point(84, 51);
            columncountNUD.Name = "columncountNUD";
            columncountNUD.Size = new System.Drawing.Size(47, 20);
            columncountNUD.Maximum = 100;
            columnGBox.Controls.Add(columncountNUD);

            CheckBox columncountAutoChk = new CheckBox();
            columncountAutoChk.Location = new System.Drawing.Point(137, 52);
            columncountAutoChk.Name = "columncountAutoChk";
            columncountAutoChk.Size = new System.Drawing.Size(47, 17);
            columncountAutoChk.Text = "auto";
            columncountAutoChk.CheckedChanged += new EventHandler(this.columncountAutoChk_CheckedChanged);
            columnGBox.Controls.Add(columncountAutoChk);

            Label label3 = new Label();
            label3.Location = new System.Drawing.Point(7, 86);
            label3.Size = new System.Drawing.Size(62, 13);
            label3.Text = "column-gap";
            columnGBox.Controls.Add(label3);

            CheckBox columngapNormalChk = new CheckBox();
            columngapNormalChk.Location = new System.Drawing.Point(186, 86);
            columngapNormalChk.Name = "columngapNormalChk";
            columngapNormalChk.Size = new System.Drawing.Size(57, 17);
            columngapNormalChk.Text = "normal";
            columngapNormalChk.CheckedChanged += new EventHandler(this.columngapNormalChk_CheckedChanged);
            columnGBox.Controls.Add(columngapNormalChk);

            ComboBox columnGapMeasure = new ComboBox();
            columnGapMeasure.Items.AddRange(new object[] {
            "px",
            "%"});
            columnGapMeasure.Location = new System.Drawing.Point(137, 84);
            columnGapMeasure.Name = "columnGapMeasure";
            columnGapMeasure.Size = new System.Drawing.Size(43, 21);
            columnGapMeasure.SelectedIndexChanged += new EventHandler(this.columnGapMeasure_SelectedIndexChanged);
            columnGBox.Controls.Add(columnGapMeasure);

            NumericUpDown columnGapNUD = new NumericUpDown();
            columnGapNUD.Location = new System.Drawing.Point(84, 85);
            columnGapNUD.Name = "columnGapNUD";
            columnGapNUD.Size = new System.Drawing.Size(47, 20);
            columnGapNUD.Maximum = 8192;
            columnGBox.Controls.Add(columnGapNUD);

            GroupBox columnRulEGBox = new GroupBox();
            columnRulEGBox.Location = new System.Drawing.Point(13, 169);
            columnRulEGBox.Name = "columnRulEGBox";
            columnRulEGBox.Size = new System.Drawing.Size(248, 118);
            columnRulEGBox.Text = "column-rule";
            columnsForm.Controls.Add(columnRulEGBox);

            Label label4 = new Label();
            label4.Location = new System.Drawing.Point(6, 20);
            label4.Size = new System.Drawing.Size(89, 13);
            label4.Text = "column-rule-width";
            columnRulEGBox.Controls.Add(label4);

            Label label5 = new Label();
            label5.Location = new System.Drawing.Point(6, 53);
            label5.Size = new System.Drawing.Size(85, 13);
            label5.Text = "column-rule-style";
            columnRulEGBox.Controls.Add(label5);

            Label label6 = new Label();
            label6.Location = new System.Drawing.Point(6, 86);
            label6.Size = new System.Drawing.Size(87, 13);
            label6.Text = "column-rule-color";
            columnRulEGBox.Controls.Add(label6);

            PictureBox columnrulePic = new PictureBox();
            columnrulePic.Location = new System.Drawing.Point(164, 43);
            columnrulePic.Name = "columnrulePic";
            columnrulePic.Size = new System.Drawing.Size(56, 34);
            columnrulePic.BackgroundImage = global::Loxie.Properties.Resources.center;
            columnrulePic.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            columnrulePic.Visible = false;
            columnRulEGBox.Controls.Add(columnrulePic);

            ComboBox columnrulestyle = new ComboBox();
            columnrulestyle.Items.AddRange(new object[] {
            "none",
            "hidden",
            "dotted",
            "dashed",
            "solid",
            "double",
            "groove",
            "ridge",
            "inset",
            "outset"});
            columnrulestyle.Location = new System.Drawing.Point(97, 50);
            columnrulestyle.Name = "columnrulestyle";
            columnrulestyle.Size = new System.Drawing.Size(61, 21);
            columnrulestyle.SelectedIndexChanged += new EventHandler(this.columnrulestyle_SelectedIndexChanged);
            columnRulEGBox.Controls.Add(columnrulestyle);

            Button columncolorSelect = new Button();
            columncolorSelect.Location = new System.Drawing.Point(97, 80);
            columncolorSelect.Size = new System.Drawing.Size(46, 23);
            columncolorSelect.Text = "Select";
            columncolorSelect.Click += new EventHandler(this.columncolorSelect_Click);
            columnRulEGBox.Controls.Add(columncolorSelect);

            TextBox columnColor = new TextBox();
            columnColor.Location = new System.Drawing.Point(164, 82);
            columnColor.Name = "columnColor";
            columnColor.Size = new System.Drawing.Size(77, 20);
            columnColor.TextAlign = HorizontalAlignment.Center;
            columnRulEGBox.Controls.Add(columnColor);

            ComboBox columnRuleWidthStyle = new ComboBox();
            columnRuleWidthStyle.FormattingEnabled = true;
            columnRuleWidthStyle.Items.AddRange(new object[] {
            "custom",
            "thin",
            "medium",
            "thick"});
            columnRuleWidthStyle.Location = new System.Drawing.Point(97, 17);
            columnRuleWidthStyle.Name = "columnRuleWidthStyle";
            columnRuleWidthStyle.Size = new System.Drawing.Size(61, 21);
            columnRuleWidthStyle.SelectedIndexChanged += new EventHandler(this.columnRuleWidthStyle_SelectedIndexChanged);
            columnRulEGBox.Controls.Add(columnRuleWidthStyle);

            NumericUpDown columnRuleWidthNUD = new NumericUpDown();
            columnRuleWidthNUD.Location = new System.Drawing.Point(164, 18);
            columnRuleWidthNUD.Name = "columnRuleWidthNUD";
            columnRuleWidthNUD.Size = new System.Drawing.Size(53, 20);
            columnRuleWidthNUD.Maximum = 8192;
            columnRulEGBox.Controls.Add(columnRuleWidthNUD);

            Label label7 = new Label();
            label7.Location = new System.Drawing.Point(223, 20);
            label7.Size = new System.Drawing.Size(18, 13);
            label7.Text = "px";
            columnRulEGBox.Controls.Add(label7);

            Label label8 = new Label();
            label8.Location = new System.Drawing.Point(7, 119);
            label8.Size = new System.Drawing.Size(67, 13);
            label8.Text = "column-span";
            columnGBox.Controls.Add(label8);

            RadioButton none = new RadioButton();
            none.Location = new System.Drawing.Point(84, 117);
            none.Name = "none";
            none.Size = new System.Drawing.Size(49, 17);
            none.Text = "none";
            columnGBox.Controls.Add(none);

            RadioButton all = new RadioButton();
            all.Location = new System.Drawing.Point(137, 117);
            all.Name = "all";
            all.Size = new System.Drawing.Size(35, 17);
            all.Text = "all";
            columnGBox.Controls.Add(all);

            Button columnOK = new Button();
            columnOK.Location = new System.Drawing.Point(162, 299);
            columnOK.Size = new System.Drawing.Size(45, 23);
            columnOK.Text = "OK";
            columnOK.Click += new EventHandler(this.columnOK_Click);
            columnsForm.Controls.Add(columnOK);

            Button columnCancel = new Button();
            columnCancel.Location = new System.Drawing.Point(214, 299);
            columnCancel.Size = new System.Drawing.Size(48, 23);
            columnCancel.Text = "Cancel";
            columnCancel.Click += new EventHandler(this.columnCancel_Click);
            columnsForm.Controls.Add(columnCancel);
        }
        private void filter_Click(object sender, EventArgs e)
        {
            Form filterForm = new Form();
            filterForm.Size = new Size(565, 341);
            filterForm.StartPosition = FormStartPosition.CenterScreen;
            filterForm.ShowIcon = false;
            filterForm.ShowInTaskbar = false;
            filterForm.Text = "filters";
            filterForm.Name = "filterForm";
            filterForm.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            filterForm.MaximizeBox = false;
            filterForm.Show();

            Button filterOK = new Button();
            filterOK.Location = new System.Drawing.Point(448, 271);
            filterOK.Size = new System.Drawing.Size(32, 23);
            filterOK.Text = "OK";
            filterOK.Click += new EventHandler(this.filterOK_Click);
            filterForm.Controls.Add(filterOK);

            Button filterCancel = new Button();
            filterCancel.Location = new System.Drawing.Point(483, 271);
            filterCancel.Size = new System.Drawing.Size(50, 23);
            filterCancel.Text = "Cancel";
            filterCancel.Click += new EventHandler(this.filterCanel_Click);
            filterForm.Controls.Add(filterCancel);

            Label label1 = new Label();
            label1.Location = new System.Drawing.Point(15, 48);
            label1.Size = new System.Drawing.Size(41, 13);
            label1.Text = "blur";
            filterForm.Controls.Add(label1);

            TrackBar blurTrck = new TrackBar();
            blurTrck.AutoSize = false;
            blurTrck.Location = new System.Drawing.Point(84, 45);
            blurTrck.Maximum = 20;
            blurTrck.Name = "blurTrck";
            blurTrck.Size = new System.Drawing.Size(109, 20);
            blurTrck.TickStyle = System.Windows.Forms.TickStyle.None;
            blurTrck.Scroll += new EventHandler(this.blurTrck_Scroll);
            filterForm.Controls.Add(blurTrck);

            Label label2 = new Label();
            label2.Location = new System.Drawing.Point(15, 82);
            label2.Size = new System.Drawing.Size(69, 13);
            label2.Text = "brightness";
            filterForm.Controls.Add(label2);

            Label label3 = new Label();
            label3.Location = new System.Drawing.Point(15, 116);
            label3.Size = new System.Drawing.Size(59, 13);
            label3.Text = "contrast";
            filterForm.Controls.Add(label3);

            Label label5 = new Label();
            label5.Location = new System.Drawing.Point(15, 150);
            label5.Size = new System.Drawing.Size(66, 13);
            label5.Text = "grayscale";
            filterForm.Controls.Add(label5);

            Label label6 = new Label();
            label6.Location = new System.Drawing.Point(280, 48);
            label6.Size = new System.Drawing.Size(79, 13);
            label6.Text = "hue-rotate";
            filterForm.Controls.Add(label6);

            Label label7 = new Label();
            label7.Location = new System.Drawing.Point(280, 87);
            label7.Size = new System.Drawing.Size(47, 13);
            label7.Text = "invert";
            filterForm.Controls.Add(label7);

            Label label8 = new Label();
            label8.Location = new System.Drawing.Point(280, 134);
            label8.Size = new System.Drawing.Size(55, 13);
            label8.Text = "opacity";
            filterForm.Controls.Add(label8);

            Label label9 = new Label();
            label9.Location = new System.Drawing.Point(280, 182);
            label9.Size = new System.Drawing.Size(59, 13);
            label9.Text = "saturate";
            filterForm.Controls.Add(label9);

            Label label10 = new Label();
            label10.Location = new System.Drawing.Point(280, 231);
            label10.Size = new System.Drawing.Size(46, 13);
            label10.Text = "sepia";
            filterForm.Controls.Add(label10);

            CheckBox inactive = new CheckBox();
            inactive.Location = new System.Drawing.Point(18, 12);
            inactive.Name = "inactive";
            inactive.Size = new System.Drawing.Size(73, 17);
            inactive.Text = "inactive";
            inactive.CheckedChanged += new EventHandler(this.inactiveFilter_CheckedChanged);
            filterForm.Controls.Add(inactive);

            CheckBox initial = new CheckBox();
            initial.Location = new System.Drawing.Point(283, 12);
            initial.Name = "initialCheck";
            initial.Size = new System.Drawing.Size(93, 17);
            initial.CheckedChanged += new EventHandler(this.initialCheck_CheckedChanged);
            initial.Text = "initial";
            filterForm.Controls.Add(initial);

            TrackBar brightnessTrck = new TrackBar();
            brightnessTrck.AutoSize = false;
            brightnessTrck.Location = new System.Drawing.Point(84, 79);
            brightnessTrck.Maximum = 100;
            brightnessTrck.Name = "brightnessTrck";
            brightnessTrck.Size = new System.Drawing.Size(109, 20);
            brightnessTrck.TickStyle = System.Windows.Forms.TickStyle.None;
            brightnessTrck.Scroll += new EventHandler(this.brightnessTrck_Scroll);
            filterForm.Controls.Add(brightnessTrck);

            TrackBar cotnrastTrck = new TrackBar();
            cotnrastTrck.AutoSize = false;
            cotnrastTrck.Location = new System.Drawing.Point(84, 113);
            cotnrastTrck.Maximum = 100;
            cotnrastTrck.Name = "cotnrastTrck";
            cotnrastTrck.Size = new System.Drawing.Size(109, 20);
            cotnrastTrck.TickStyle = System.Windows.Forms.TickStyle.None;
            cotnrastTrck.Scroll += new EventHandler(this.cotnrastTrck_Scroll);
            filterForm.Controls.Add(cotnrastTrck);

            TrackBar grayscaleTrck = new TrackBar();
            grayscaleTrck.AutoSize = false;
            grayscaleTrck.Location = new System.Drawing.Point(84, 147);
            grayscaleTrck.Maximum = 100;
            grayscaleTrck.Name = "grayscaleTrck";
            grayscaleTrck.Size = new System.Drawing.Size(109, 20);
            grayscaleTrck.TickStyle = System.Windows.Forms.TickStyle.None;
            grayscaleTrck.Scroll += new EventHandler(this.grayscaleTrck_Scroll);
            filterForm.Controls.Add(grayscaleTrck);

            TrackBar sepiaTrck = new TrackBar();
            sepiaTrck.AutoSize = false;
            sepiaTrck.Location = new System.Drawing.Point(365, 231);
            sepiaTrck.Maximum = 100;
            sepiaTrck.Name = "sepiaTrck";
            sepiaTrck.Size = new System.Drawing.Size(109, 20);
            sepiaTrck.TickStyle = System.Windows.Forms.TickStyle.None;
            sepiaTrck.Scroll += new EventHandler(this.sepiaTrck_Scroll);
            filterForm.Controls.Add(sepiaTrck);

            TrackBar saturateTrck = new TrackBar();
            saturateTrck.AutoSize = false;
            saturateTrck.Location = new System.Drawing.Point(365, 182);
            saturateTrck.Maximum = 100;
            saturateTrck.Name = "saturateTrck";
            saturateTrck.Size = new System.Drawing.Size(109, 20);
            saturateTrck.TickStyle = System.Windows.Forms.TickStyle.None;
            saturateTrck.Scroll += new EventHandler(this.saturateTrck_Scroll);
            filterForm.Controls.Add(saturateTrck);

            TrackBar opacityTrck = new TrackBar();
            opacityTrck.AutoSize = false;
            opacityTrck.Location = new System.Drawing.Point(365, 134);
            opacityTrck.Maximum = 100;
            opacityTrck.Name = "opacityTrck";
            opacityTrck.Size = new System.Drawing.Size(109, 20);
            opacityTrck.TickStyle = System.Windows.Forms.TickStyle.None;
            opacityTrck.Scroll += new EventHandler(this.filterOpacityTrck_Scroll);
            filterForm.Controls.Add(opacityTrck);

            TrackBar invertTrck = new TrackBar();
            invertTrck.AutoSize = false;
            invertTrck.Location = new System.Drawing.Point(365, 87);
            invertTrck.Maximum = 100;
            invertTrck.Name = "invertTrck";
            invertTrck.Size = new System.Drawing.Size(109, 20);
            invertTrck.TickStyle = System.Windows.Forms.TickStyle.None;
            invertTrck.Scroll += new EventHandler(this.invertTrck_Scroll);
            filterForm.Controls.Add(invertTrck);

            TrackBar huerotateTrck = new TrackBar();
            huerotateTrck.AutoSize = false;
            huerotateTrck.Location = new System.Drawing.Point(365, 48);
            huerotateTrck.Maximum = 360;
            huerotateTrck.Name = "huerotateTrck";
            huerotateTrck.Size = new System.Drawing.Size(109, 20);
            huerotateTrck.TickStyle = System.Windows.Forms.TickStyle.None;
            huerotateTrck.Scroll += new EventHandler(this.huerotateTrck_Scroll);
            filterForm.Controls.Add(huerotateTrck);

            NumericUpDown blurNUD = new NumericUpDown();
            blurNUD.Location = new System.Drawing.Point(199, 46);
            blurNUD.Maximum = 20;
            blurNUD.Name = "blurNUD";
            blurNUD.Size = new System.Drawing.Size(55, 20);
            blurNUD.ValueChanged += new EventHandler(this.blurNUD_ValueChanged);
            filterForm.Controls.Add(blurNUD);

            NumericUpDown brightnessNUD = new NumericUpDown();
            brightnessNUD.Location = new System.Drawing.Point(199, 80);
            brightnessNUD.Name = "brightnessNUD";
            brightnessNUD.Maximum = 100;
            brightnessNUD.Size = new System.Drawing.Size(55, 20);
            brightnessNUD.ValueChanged += new EventHandler(this.brightnessNUD_ValueChanged);
            filterForm.Controls.Add(brightnessNUD);

            NumericUpDown contrastNUD = new NumericUpDown();
            contrastNUD.Location = new System.Drawing.Point(200, 114);
            contrastNUD.Name = "contrastNUD";
            contrastNUD.Maximum = 100;
            contrastNUD.Size = new System.Drawing.Size(55, 20);
            contrastNUD.ValueChanged += new EventHandler(this.contrastNUD_ValueChanged);
            filterForm.Controls.Add(contrastNUD);

            NumericUpDown grayscaleNUD = new NumericUpDown();
            grayscaleNUD.Location = new System.Drawing.Point(200, 148);
            grayscaleNUD.Name = "grayscaleNUD";
            grayscaleNUD.Size = new System.Drawing.Size(55, 20);
            grayscaleNUD.Maximum = 100;
            grayscaleNUD.ValueChanged += new EventHandler(this.grayscaleNUD_ValueChanged);
            filterForm.Controls.Add(grayscaleNUD);

            NumericUpDown huerotateNUD = new NumericUpDown();
            huerotateNUD.Location = new System.Drawing.Point(478, 46);
            huerotateNUD.Name = "huerotateNUD";
            huerotateNUD.Size = new System.Drawing.Size(55, 20);
            huerotateNUD.Maximum = 360;
            huerotateNUD.ValueChanged += new EventHandler(this.huerotateNUD_ValueChanged);
            filterForm.Controls.Add(huerotateNUD);

            NumericUpDown invertNUD = new NumericUpDown();
            invertNUD.Location = new System.Drawing.Point(478, 85);
            invertNUD.Name = "invertNUD";
            invertNUD.Maximum = 100;
            invertNUD.Size = new System.Drawing.Size(55, 20);
            invertNUD.ValueChanged += new EventHandler(this.invertNUD_ValueChanged);
            filterForm.Controls.Add(invertNUD);

            NumericUpDown opacityNUD = new NumericUpDown();
            opacityNUD.Location = new System.Drawing.Point(478, 132);
            opacityNUD.Name = "opacityNUD";
            opacityNUD.Maximum = 100;
            opacityNUD.Size = new System.Drawing.Size(55, 20);
            opacityNUD.ValueChanged += new EventHandler(this.opacityNUD_ValueChanged);
            filterForm.Controls.Add(opacityNUD);

            NumericUpDown saturateNUD = new NumericUpDown();
            saturateNUD.Location = new System.Drawing.Point(478, 180);
            saturateNUD.Name = "saturateNUD";
            saturateNUD.Size = new System.Drawing.Size(55, 20);
            saturateNUD.Maximum = 100;
            saturateNUD.ValueChanged += new EventHandler(this.saturateNUD_ValueChanged);
            filterForm.Controls.Add(saturateNUD);

            NumericUpDown sepiaNUD = new NumericUpDown();
            sepiaNUD.Location = new System.Drawing.Point(478, 229);
            sepiaNUD.Name = "sepiaNUD";
            sepiaNUD.Size = new System.Drawing.Size(55, 20);
            sepiaNUD.Maximum = 100;
            sepiaNUD.ValueChanged += new EventHandler(this.sepiaNUD_ValueChanged);
            filterForm.Controls.Add(sepiaNUD);

            GroupBox dropshadow = new GroupBox();
            dropshadow.Location = new System.Drawing.Point(8, 182);
            dropshadow.Name = "dropshadow";
            dropshadow.Size = new System.Drawing.Size(254, 112);
            dropshadow.Text = "drop-shadow";
            filterForm.Controls.Add(dropshadow);

            TextBox colorCode = new TextBox();
            colorCode.Location = new System.Drawing.Point(176, 79);
            colorCode.Name = "colorCode";
            colorCode.Size = new System.Drawing.Size(70, 20);
            dropshadow.Controls.Add(colorCode);

            Button dropColorSelect = new Button();
            dropColorSelect.Location = new System.Drawing.Point(109, 78);
            dropColorSelect.Size = new System.Drawing.Size(50, 21);
            dropColorSelect.Text = "Select";
            dropColorSelect.Name = "dropColorSelect";
            dropColorSelect.Click += new EventHandler(this.dropColorSelect_Click);
            dropshadow.Controls.Add(dropColorSelect);

            NumericUpDown vshadowNUD = new NumericUpDown();
            vshadowNUD.Location = new System.Drawing.Point(191, 49);
            vshadowNUD.Name = "vshadowNUD";
            vshadowNUD.Size = new System.Drawing.Size(55, 20);
            vshadowNUD.Maximum = 8192;
            vshadowNUD.ValueChanged += new EventHandler(this.vshadowNUD_ValueChanged);
            dropshadow.Controls.Add(vshadowNUD);

            TrackBar vshadowTrck = new TrackBar();
            vshadowTrck.AutoSize = false;
            vshadowTrck.Location = new System.Drawing.Point(70, 49);
            vshadowTrck.Maximum = 8192;
            vshadowTrck.Name = "vshadowTrck";
            vshadowTrck.Size = new System.Drawing.Size(98, 20);
            vshadowTrck.TickStyle = System.Windows.Forms.TickStyle.None;
            vshadowTrck.Scroll += new EventHandler(this.vshadowTrck_Scroll);
            dropshadow.Controls.Add(vshadowTrck);

            NumericUpDown hshadowNUD = new NumericUpDown();
            hshadowNUD.Location = new System.Drawing.Point(191, 18);
            hshadowNUD.Name = "hshadowNUD";
            hshadowNUD.Size = new System.Drawing.Size(55, 20);
            hshadowNUD.Maximum = 8192;
            hshadowNUD.ValueChanged += new EventHandler(this.hshadowNUD_ValueChanged);
            dropshadow.Controls.Add(hshadowNUD);

            TrackBar hshadowTrck = new TrackBar();
            hshadowTrck.AutoSize = false;
            hshadowTrck.Location = new System.Drawing.Point(70, 18);
            hshadowTrck.Maximum = 8192;
            hshadowTrck.Name = "hshadowTrck";
            hshadowTrck.Size = new System.Drawing.Size(98, 20);
            hshadowTrck.TickStyle = System.Windows.Forms.TickStyle.None;
            hshadowTrck.Scroll += new EventHandler(this.hshadowTrck_Scroll);
            dropshadow.Controls.Add(hshadowTrck);

            Label label14 = new Label();
            label14.AutoSize = true;
            label14.Location = new System.Drawing.Point(7, 82);
            label14.Size = new System.Drawing.Size(33, 13);
            label14.Text = "color";
            dropshadow.Controls.Add(label14);

            Label label12 = new Label();
            label12.AutoSize = true;
            label12.Location = new System.Drawing.Point(6, 51);
            label12.Size = new System.Drawing.Size(53, 13);
            label12.Text = "v-shadow";
            dropshadow.Controls.Add(label12);

            Label label11 = new Label();
            label11.AutoSize = true;
            label11.Location = new System.Drawing.Point(7, 20);
            label11.Size = new System.Drawing.Size(53, 13);
            label11.Text = "h-shadow";
            dropshadow.Controls.Add(label11);
        }
        private void lrtb_Click(object sender, EventArgs e)
        {
            Form lrtbForm = new Form();
            lrtbForm.Size = new Size(190, 209);
            lrtbForm.StartPosition = FormStartPosition.CenterScreen;
            lrtbForm.ShowIcon = false;
            lrtbForm.ShowInTaskbar = false;
            lrtbForm.Text = "L-R-T-B";
            lrtbForm.Name = "lrtbForm";
            lrtbForm.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            lrtbForm.MaximizeBox = false;
            lrtbForm.Show();

            Button lrtbOK = new Button();
            lrtbOK.Location = new System.Drawing.Point(74, 144);
            lrtbOK.Size = new System.Drawing.Size(32, 23);
            lrtbOK.Text = "OK";
            lrtbOK.Click += new EventHandler(this.lrtbOK_Click);
            lrtbForm.Controls.Add(lrtbOK);

            Button lrtbCancel = new Button();
            lrtbCancel.Location = new System.Drawing.Point(110, 144);
            lrtbCancel.Size = new System.Drawing.Size(49, 23);
            lrtbCancel.Text = "Cancel";
            lrtbCancel.Click += new EventHandler(this.lrtbCancel_Click);
            lrtbForm.Controls.Add(lrtbCancel);

            Label label2 = new Label();
            label2.Location = new System.Drawing.Point(12, 25);
            label2.Size = new System.Drawing.Size(40, 13);
            label2.Text = "left";
            lrtbForm.Controls.Add(label2);

            NumericUpDown leftVal = new NumericUpDown();
            leftVal.Location = new System.Drawing.Point(55, 23);
            leftVal.Name = "leftVal";
            leftVal.Size = new System.Drawing.Size(51, 20);
            leftVal.Maximum = 1000;
            lrtbForm.Controls.Add(leftVal);

            ComboBox leftMeasure = new ComboBox();
            leftMeasure.Items.AddRange(new object[] {
            "px",
            "%"});
            leftMeasure.Location = new System.Drawing.Point(112, 23);
            leftMeasure.Name = "leftMeasure";
            leftMeasure.Size = new System.Drawing.Size(44, 21);
            leftMeasure.SelectedIndexChanged += new System.EventHandler(this.leftMeasure_SelectedIndexChanged);
            lrtbForm.Controls.Add(leftMeasure);

            ComboBox rightMeasure = new ComboBox();
            rightMeasure.Items.AddRange(new object[] {
            "px",
            "%"});
            rightMeasure.Location = new System.Drawing.Point(112, 50);
            rightMeasure.Name = "rightMeasure";
            rightMeasure.Size = new System.Drawing.Size(44, 21);
            rightMeasure.SelectedIndexChanged += new System.EventHandler(this.rightMeasure_SelectedIndexChanged);
            lrtbForm.Controls.Add(rightMeasure);

            NumericUpDown rightVal = new NumericUpDown();
            rightVal.Location = new System.Drawing.Point(55, 50);
            rightVal.Name = "rightVal";
            rightVal.Size = new System.Drawing.Size(51, 20);
            rightVal.Maximum = 1000;
            lrtbForm.Controls.Add(rightVal);

            Label label1 = new Label();
            label1.Location = new System.Drawing.Point(12, 52);
            label1.Size = new System.Drawing.Size(40, 13);
            label1.Text = "right";
            lrtbForm.Controls.Add(label1);

            ComboBox bottomMeasure = new ComboBox();
            bottomMeasure.Items.AddRange(new object[] {
            "px",
            "%"});
            bottomMeasure.Location = new System.Drawing.Point(112, 77);
            bottomMeasure.Name = "bottomMeasure";
            bottomMeasure.Size = new System.Drawing.Size(44, 21);
            bottomMeasure.SelectedIndexChanged += new System.EventHandler(this.bottomMeasure_SelectedIndexChanged);
            lrtbForm.Controls.Add(bottomMeasure);

            NumericUpDown bottomVal = new NumericUpDown();
            bottomVal.Location = new System.Drawing.Point(55, 77);
            bottomVal.Name = "bottomVal";
            bottomVal.Size = new System.Drawing.Size(51, 20);
            bottomVal.Maximum = 1000;
            lrtbForm.Controls.Add(bottomVal);

            Label label3 = new Label();
            label3.Location = new System.Drawing.Point(12, 79);
            label3.Size = new System.Drawing.Size(40, 13);
            label3.Text = "bottom";
            lrtbForm.Controls.Add(label3);

            ComboBox topMeasure = new ComboBox();
            topMeasure.FormattingEnabled = true;
            topMeasure.Items.AddRange(new object[] {
            "px",
            "%"});
            topMeasure.Location = new System.Drawing.Point(112, 102);
            topMeasure.Name = "topMeasure";
            topMeasure.Size = new System.Drawing.Size(44, 21);
            topMeasure.SelectedIndexChanged += new System.EventHandler(this.topMeasure_SelectedIndexChanged);
            lrtbForm.Controls.Add(topMeasure);

            NumericUpDown topVal = new NumericUpDown();
            topVal.Location = new System.Drawing.Point(55, 102);
            topVal.Name = "topVal";
            topVal.Size = new System.Drawing.Size(51, 20);
            topVal.Maximum = 1000;
            lrtbForm.Controls.Add(topVal);

            Label label4 = new Label();
            label4.Location = new System.Drawing.Point(12, 104);
            label4.Size = new System.Drawing.Size(36, 13);
            label4.Text = "top";
            lrtbForm.Controls.Add(label4);
        }
        private void transition_Click(object sender, EventArgs e)
        {
            Form transitionForm = new Form();
            transitionForm.Size = new Size(262, 222);
            transitionForm.StartPosition = FormStartPosition.CenterScreen;
            transitionForm.ShowIcon = false;
            transitionForm.ShowInTaskbar = false;
            transitionForm.Text = "transition";
            transitionForm.Name = "transitionForm";
            transitionForm.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            transitionForm.MaximizeBox = false;
            transitionForm.Show();

            Button transitionOK = new Button();
            transitionOK.Location = new System.Drawing.Point(150, 154);
            transitionOK.Size = new System.Drawing.Size(32, 23);
            transitionOK.Text = "OK";
            transitionOK.Click += new EventHandler(this.transitionOK_Click);
            transitionForm.Controls.Add(transitionOK);

            Button transitionCancel = new Button();
            transitionCancel.Location = new System.Drawing.Point(188, 154);
            transitionCancel.Size = new System.Drawing.Size(50, 23);
            transitionCancel.Text = "Cancel";
            transitionCancel.Click += new EventHandler(this.transitionCancel_Click);
            transitionForm.Controls.Add(transitionCancel);

            Label label1 = new Label();
            label1.Location = new System.Drawing.Point(12, 21);
            label1.Size = new System.Drawing.Size(59, 13);
            label1.Text = "name";
            transitionForm.Controls.Add(label1);

            Label label2 = new Label();
            label2.Location = new System.Drawing.Point(12, 54);
            label2.Size = new System.Drawing.Size(107, 13);
            label2.Text = "duration";
            transitionForm.Controls.Add(label2);

            Label label3 = new Label();
            label3.Location = new System.Drawing.Point(12, 87);
            label3.Size = new System.Drawing.Size(125, 13);
            label3.Text = "timing function";
            transitionForm.Controls.Add(label3);

            Label label4 = new Label();
            label4.Location = new System.Drawing.Point(12, 119);
            label4.Size = new System.Drawing.Size(88, 13);
            label4.Text = "delay";
            transitionForm.Controls.Add(label4);

            CheckBox propertyNone = new CheckBox();
            propertyNone.Location = new System.Drawing.Point(115, 20);
            propertyNone.Name = "propertyNone";
            propertyNone.Size = new System.Drawing.Size(50, 17);
            propertyNone.Text = "none";
            propertyNone.CheckedChanged += new System.EventHandler(this.propertyNone_CheckedChanged);
            transitionForm.Controls.Add(propertyNone);

            TextBox propertyVal = new TextBox();
            propertyVal.Location = new System.Drawing.Point(166, 18);
            propertyVal.Name = "propertyVal";
            propertyVal.Size = new System.Drawing.Size(68, 20);
            transitionForm.Controls.Add(propertyVal);

            NumericUpDown durationVal = new NumericUpDown();
            durationVal.Location = new System.Drawing.Point(166, 52);
            durationVal.Name = "durationVal";
            durationVal.Size = new System.Drawing.Size(51, 20);
            transitionForm.Controls.Add(durationVal);

            Label label5 = new Label();
            label5.Location = new System.Drawing.Point(223, 54);
            label5.Size = new System.Drawing.Size(12, 13);
            label5.Text = "s";
            transitionForm.Controls.Add(label5);

            ComboBox timingFunction = new ComboBox();
            timingFunction.FormattingEnabled = true;
            timingFunction.Items.AddRange(new object[] {
            "ease",
            "ease-in",
            "ease-out",
            "ease-in-out",
            "linear",
            "step-start",
            "step-end",
            "steps",
            "cubic-bezier"});
            timingFunction.Location = new System.Drawing.Point(166, 84);
            timingFunction.Name = "timingFunction";
            timingFunction.Size = new System.Drawing.Size(69, 21);
            transitionForm.Controls.Add(timingFunction);

            Label label6 = new Label();
            label6.Location = new System.Drawing.Point(223, 119);
            label6.Size = new System.Drawing.Size(12, 13);
            label6.Text = "s";
            transitionForm.Controls.Add(label6);

            NumericUpDown delayVal = new NumericUpDown();
            delayVal.Location = new System.Drawing.Point(166, 117);
            delayVal.Name = "delayVal";
            delayVal.Size = new System.Drawing.Size(51, 20);
            transitionForm.Controls.Add(delayVal);

        }
        private void elementSizes_Click(object sender, EventArgs e)
        {
            Form elementSizeForm = new Form();
            elementSizeForm.Size = new Size(255, 194);
            elementSizeForm.StartPosition = FormStartPosition.CenterScreen;
            elementSizeForm.ShowIcon = false;
            elementSizeForm.ShowInTaskbar = false;
            elementSizeForm.Text = "element size";
            elementSizeForm.Name = "elementSizeForm";
            elementSizeForm.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            elementSizeForm.MaximizeBox = false;
            elementSizeForm.Show();

            Button elementSizeOK = new Button();
            elementSizeOK.Location = new System.Drawing.Point(143, 125);
            elementSizeOK.Size = new System.Drawing.Size(32, 23);
            elementSizeOK.Text = "OK";
            elementSizeOK.Click += new EventHandler(this.elementSizeOK_Click);
            elementSizeForm.Controls.Add(elementSizeOK);

            Button elementSizeCancel = new Button();
            elementSizeCancel.Location = new System.Drawing.Point(181, 125);
            elementSizeCancel.Size = new System.Drawing.Size(50, 23);
            elementSizeCancel.Text = "Cancel";
            elementSizeCancel.Click += new EventHandler(this.elementSizeCancel_Click);
            elementSizeForm.Controls.Add(elementSizeCancel);

            Label label1 = new Label();
            label1.Location = new System.Drawing.Point(12, 9);
            label1.Size = new System.Drawing.Size(40, 13);
            label1.Text = "sizes";
            elementSizeForm.Controls.Add(label1);

            NumericUpDown heightVal = new NumericUpDown();
            heightVal.Location = new System.Drawing.Point(124, 39);
            heightVal.Name = "heightVal";
            heightVal.Size = new System.Drawing.Size(60, 20);
            heightVal.Maximum = 8192;
            elementSizeForm.Controls.Add(heightVal);

            ListBox heights = new ListBox();
            heights.Items.AddRange(new object[] {
            "height",
            "min-height",
            "max-height"});
            heights.Location = new System.Drawing.Point(12, 28);
            heights.Name = "heights";
            heights.Size = new System.Drawing.Size(105, 43);
            //heights.SelectedIndexChanged += new EventHandler(this.heights_SelectedIndexChanged);
            elementSizeForm.Controls.Add(heights);

            ListBox widths = new ListBox();
            widths.Items.AddRange(new object[] {
            "width",
            "min-width",
            "max-width"});
            widths.Location = new System.Drawing.Point(12, 77);
            widths.Name = "widths";
            widths.Size = new System.Drawing.Size(105, 43);
            //widths.SelectedIndexChanged += new EventHandler(this.widths_SelectedIndexChanged);
            elementSizeForm.Controls.Add(widths);

            NumericUpDown widthVal = new NumericUpDown();
            widthVal.Location = new System.Drawing.Point(124, 88);
            widthVal.Name = "widthVal";
            widthVal.Size = new System.Drawing.Size(60, 20);
            widthVal.Maximum = 8192;
            elementSizeForm.Controls.Add(widthVal);

            ComboBox heightM = new ComboBox();
            heightM.Location = new System.Drawing.Point(191, 88);
            heightM.Name = "heightM";
            heightM.Size = new System.Drawing.Size(37, 21);
            heightM.Items.AddRange(new object[] {
            "px",
            "%"});
            heightM.SelectedIndexChanged += new System.EventHandler(this.heightM_SelectedIndexChanged);
            elementSizeForm.Controls.Add(heightM);

            ComboBox widthM = new ComboBox();
            widthM.Location = new System.Drawing.Point(191, 39);
            widthM.Name = "widthM";
            widthM.Size = new System.Drawing.Size(37, 21);
            widthM.Items.AddRange(new object[] {
            "px",
            "%"});
            widthM.SelectedIndexChanged += new System.EventHandler(this.widthM_CheckedChanged);
            elementSizeForm.Controls.Add(widthM);
        }
        private void captionSide_Click(object sender, EventArgs e)
        {
            Form captionSideForm = new Form();
            captionSideForm.Size = new Size(123, 202);
            captionSideForm.StartPosition = FormStartPosition.CenterScreen;
            captionSideForm.ShowIcon = false;
            captionSideForm.ShowInTaskbar = false;
            captionSideForm.Text = "caption side";
            captionSideForm.Name = "captionSideForm";
            captionSideForm.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            captionSideForm.MaximizeBox = false;
            captionSideForm.Show();

            Button captionSideOK = new Button();
            captionSideOK.Location = new System.Drawing.Point(9, 133);
            captionSideOK.Size = new System.Drawing.Size(32, 23);
            captionSideOK.Text = "OK";
            captionSideOK.Click += new EventHandler(this.captionSideOK_Click);
            captionSideForm.Controls.Add(captionSideOK);

            Button captionSideCancel = new Button();
            captionSideCancel.Location = new System.Drawing.Point(50, 133);
            captionSideCancel.Size = new System.Drawing.Size(50, 23);
            captionSideCancel.Text = "Cancel";
            captionSideCancel.Click += new EventHandler(this.captionSideCancel_Click);
            captionSideForm.Controls.Add(captionSideCancel);

            RadioButton captionTop = new RadioButton();
            captionTop.Location = new System.Drawing.Point(15, 35);
            captionTop.Name = "captionTop";
            captionTop.Size = new System.Drawing.Size(66, 17);
            captionTop.Text = "top";
            captionSideForm.Controls.Add(captionTop);

            Label captionPositionLbl = new Label();
            captionPositionLbl.Location = new System.Drawing.Point(6, 9);
            captionPositionLbl.Size = new System.Drawing.Size(94, 13);
            captionPositionLbl.Text = "position";
            captionSideForm.Controls.Add(captionPositionLbl);

            RadioButton captionBottom = new RadioButton();
            captionBottom.Location = new System.Drawing.Point(15, 58);
            captionBottom.Name = "captionBottom";
            captionBottom.Size = new System.Drawing.Size(63, 17);
            captionBottom.Text = "bottom";
            captionSideForm.Controls.Add(captionBottom);

            RadioButton captionLeft = new RadioButton();
            captionLeft.Location = new System.Drawing.Point(15, 81);
            captionLeft.Name = "captionLeft";
            captionLeft.Size = new System.Drawing.Size(52, 17);
            captionLeft.Text = "left";
            captionSideForm.Controls.Add(captionLeft);

            RadioButton captionRight = new RadioButton();
            captionRight.Location = new System.Drawing.Point(15, 104);
            captionRight.Name = "captionRight";
            captionRight.Size = new System.Drawing.Size(56, 17);
            captionRight.Text = "right";
            captionSideForm.Controls.Add(captionRight);
        }
        private void listStyle_Click(object sender, EventArgs e)
        {
            Form listStyleForm = new Form();
            listStyleForm.Size = new Size(333, 200);
            listStyleForm.StartPosition = FormStartPosition.CenterScreen;
            listStyleForm.ShowIcon = false;
            listStyleForm.ShowInTaskbar = false;
            listStyleForm.Text = "list-style";
            listStyleForm.Name = "listStyleForm";
            listStyleForm.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            listStyleForm.MaximizeBox = false;
            listStyleForm.Show();

            Button listStyleOK = new Button();
            listStyleOK.Location = new System.Drawing.Point(222, 131);
            listStyleOK.Size = new System.Drawing.Size(32, 23);
            listStyleOK.Text = "OK";
            listStyleOK.Click += new EventHandler(this.listStyleOK_Click);
            listStyleForm.Controls.Add(listStyleOK);

            Button listStyleCancel = new Button();
            listStyleCancel.Location = new System.Drawing.Point(257, 131);
            listStyleCancel.Size = new System.Drawing.Size(50, 23);
            listStyleCancel.Text = "Cancel";
            listStyleCancel.Click += new EventHandler(this.listStyleCancel_Click);
            listStyleForm.Controls.Add(listStyleCancel);

            Label styleTypeLbl = new Label();
            styleTypeLbl.Location = new System.Drawing.Point(13, 13);
            styleTypeLbl.Size = new System.Drawing.Size(61, 13);
            styleTypeLbl.Text = "list-style";
            listStyleForm.Controls.Add(styleTypeLbl);

            ComboBox styleTypes = new ComboBox();
            styleTypes.Items.AddRange(new object[] {
            "circle",
            "disc",
            "square",
            "armenian",
            "decimal",
            "decimal-leading-zero",
            "georgian",
            "lower-alpha",
            "lower-greek",
            "lower-latin",
            "lower-roman",
            "upper-alpha",
            "upper-latin",
            "upper-roman"});
            styleTypes.Location = new System.Drawing.Point(186, 10);
            styleTypes.Name = "styleTypes";
            styleTypes.Size = new System.Drawing.Size(121, 21);
            listStyleForm.Controls.Add(styleTypes);

            CheckBox standartTypeChk = new CheckBox();
            standartTypeChk.Location = new System.Drawing.Point(85, 12);
            standartTypeChk.Name = "standartTypeChk";
            standartTypeChk.Size = new System.Drawing.Size(64, 17);
            standartTypeChk.Text = "standart";
            standartTypeChk.CheckedChanged += new System.EventHandler(this.standartTypeChk_CheckedChanged);
            listStyleForm.Controls.Add(standartTypeChk);

            Label pointerPosLbl = new Label();
            pointerPosLbl.Location = new System.Drawing.Point(13, 52);
            pointerPosLbl.Size = new System.Drawing.Size(110, 13);
            pointerPosLbl.Text = "pointer position";
            listStyleForm.Controls.Add(pointerPosLbl);

            RadioButton inside = new RadioButton();
            inside.Location = new System.Drawing.Point(184, 52);
            inside.Name = "inside";
            inside.Size = new System.Drawing.Size(58, 17);
            inside.Text = "inside";
            listStyleForm.Controls.Add(inside);

            RadioButton outside = new RadioButton();
            outside.Location = new System.Drawing.Point(248, 52);
            outside.Name = "outside";
            outside.Size = new System.Drawing.Size(59, 17);
            outside.Text = "outside";
            listStyleForm.Controls.Add(outside);

            Label pointerImgSizeLbl = new Label();
            pointerImgSizeLbl.Location = new System.Drawing.Point(13, 100);
            pointerImgSizeLbl.Size = new System.Drawing.Size(70, 13);
            pointerImgSizeLbl.Text = "pointer-image";
            listStyleForm.Controls.Add(pointerImgSizeLbl);

            CheckBox noImgChck = new CheckBox();
            noImgChck.Location = new System.Drawing.Point(85, 99);
            noImgChck.Name = "noImgChck";
            noImgChck.Size = new System.Drawing.Size(70, 17);
            noImgChck.Text = "no image";
            noImgChck.CheckedChanged += new System.EventHandler(this.noImgChck_CheckedChanged);
            listStyleForm.Controls.Add(noImgChck);

            Button pointerImgSelect = new Button();
            pointerImgSelect.Location = new System.Drawing.Point(158, 97);
            pointerImgSelect.Size = new System.Drawing.Size(47, 23);
            pointerImgSelect.Name = "pointerImgSelect";
            pointerImgSelect.Text = "Select";
            pointerImgSelect.Click += new EventHandler(this.pointerImgSelect_Click);
            listStyleForm.Controls.Add(pointerImgSelect);

            TextBox pointerImgURL = new TextBox();
            pointerImgURL.Location = new System.Drawing.Point(208, 97);
            pointerImgURL.Name = "pointerImgURL";
            pointerImgURL.Size = new System.Drawing.Size(99, 20);
            listStyleForm.Controls.Add(pointerImgURL);
        }
        private void shadowClick(object sender, EventArgs e)
        {
            Form shadowForm = new Form();
            shadowForm.Size = new Size(351, 304);
            shadowForm.StartPosition = FormStartPosition.CenterScreen;
            shadowForm.ShowIcon = false;
            shadowForm.ShowInTaskbar = false;
            shadowForm.Text = "shadow";
            shadowForm.Name = "shadowForm";
            shadowForm.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            shadowForm.MaximizeBox = false;
            shadowForm.Show();

            Button shadowOK = new Button();
            shadowOK.Location = new System.Drawing.Point(239, 235);
            shadowOK.Size = new System.Drawing.Size(32, 23);
            shadowOK.Text = "OK";
            shadowOK.Click += new EventHandler(shadowOK_Click);
            shadowForm.Controls.Add(shadowOK);

            Button shadowCancel = new Button();
            shadowCancel.Location = new System.Drawing.Point(274, 235);
            shadowCancel.Size = new System.Drawing.Size(50, 23);
            shadowCancel.Text = "Cancel";
            shadowCancel.Click += new EventHandler(this.shadowCancel_Click);
            shadowForm.Controls.Add(shadowCancel);

            Label label1 = new Label();
            label1.Location = new System.Drawing.Point(11, 13);
            label1.Size = new System.Drawing.Size(84, 13);
            label1.Text = "inactive";
            shadowForm.Controls.Add(label1);

            CheckBox inactiveChk = new CheckBox();
            inactiveChk.Location = new System.Drawing.Point(308, 13);
            inactiveChk.Name = "inactiveChk";
            inactiveChk.Size = new System.Drawing.Size(15, 14);
            inactiveChk.CheckedChanged += new System.EventHandler(this.inactiveChk_CheckedChanged);
            shadowForm.Controls.Add(inactiveChk);

            Label label2 = new Label();
            label2.Location = new System.Drawing.Point(11, 41);
            label2.Size = new System.Drawing.Size(80, 13);
            label2.Text = "inner shadow";
            shadowForm.Controls.Add(label2);

            CheckBox innerShadowChk = new CheckBox();
            innerShadowChk.Location = new System.Drawing.Point(308, 41);
            innerShadowChk.Name = "innerShadowChk";
            innerShadowChk.Size = new System.Drawing.Size(15, 14);
            shadowForm.Controls.Add(innerShadowChk);

            Label label3 = new Label();
            label3.Location = new System.Drawing.Point(12, 70);
            label3.Size = new System.Drawing.Size(130, 13);
            label3.Text = "shadow X";
            shadowForm.Controls.Add(label3);

            Label label4 = new Label();
            label4.Location = new System.Drawing.Point(11, 100);
            label4.Size = new System.Drawing.Size(136, 13);
            label4.Text = "shadow Y";
            shadowForm.Controls.Add(label4);

            TrackBar trackX = new TrackBar();
            trackX.AutoSize = false;
            trackX.Location = new System.Drawing.Point(256, 68);
            trackX.Name = "trackX";
            trackX.Maximum = 1000;
            trackX.Size = new System.Drawing.Size(74, 25);
            trackX.TickStyle = System.Windows.Forms.TickStyle.None;
            trackX.Scroll += new System.EventHandler(this.trackX_Scroll);
            shadowForm.Controls.Add(trackX);

            NumericUpDown trackXVal = new NumericUpDown();
            trackXVal.Location = new System.Drawing.Point(176, 68);
            trackXVal.Name = "trackXVal";
            trackXVal.Size = new System.Drawing.Size(64, 20);
            trackXVal.Maximum = 1000;
            shadowForm.Controls.Add(trackXVal);
            trackXVal.ValueChanged += new System.EventHandler(this.trackXVal_ValueChanged);

            NumericUpDown trackYVal = new NumericUpDown();
            trackYVal.Location = new System.Drawing.Point(176, 98);
            trackYVal.Name = "trackYVal";
            trackYVal.Maximum = 1000;
            trackYVal.Size = new System.Drawing.Size(64, 20);
            shadowForm.Controls.Add(trackYVal);
            trackYVal.ValueChanged += new System.EventHandler(this.trackYVal_ValueChanged);

            TrackBar trackY = new TrackBar();
            trackY.AutoSize = false;
            trackY.Location = new System.Drawing.Point(256, 98);
            trackY.Name = "trackY";
            trackY.Maximum = 1000;
            trackY.Size = new System.Drawing.Size(74, 25);
            trackY.TickStyle = System.Windows.Forms.TickStyle.None;
            trackY.Scroll += new EventHandler(this.trackY_Scroll);
            shadowForm.Controls.Add(trackY);

            Label label5 = new Label();
            label5.Location = new System.Drawing.Point(11, 131);
            label5.Size = new System.Drawing.Size(52, 13);
            label5.Text = "blur";
            shadowForm.Controls.Add(label5);

            NumericUpDown objBlurNUD = new NumericUpDown();
            objBlurNUD.Location = new System.Drawing.Point(176, 131);
            objBlurNUD.Name = "objBlurNUD";
            objBlurNUD.Maximum = 500;
            objBlurNUD.Size = new System.Drawing.Size(64, 20);
            objBlurNUD.ValueChanged += new System.EventHandler(this.objBlurNUD_ValueChanged);
            shadowForm.Controls.Add(objBlurNUD);

            TrackBar objBlurTrck = new TrackBar();
            objBlurTrck.AutoSize = false;
            objBlurTrck.Location = new System.Drawing.Point(256, 129);
            objBlurTrck.Name = "objBlurTrck";
            objBlurTrck.Maximum = 500;
            objBlurTrck.Size = new System.Drawing.Size(74, 25);
            objBlurTrck.TickStyle = System.Windows.Forms.TickStyle.None;
            objBlurTrck.Scroll += new EventHandler(this.objBlurTrck_Scroll);
            shadowForm.Controls.Add(objBlurTrck);

            Label label6 = new Label();
            label6.Location = new System.Drawing.Point(11, 163);
            label6.Size = new System.Drawing.Size(75, 13);
            label6.Text = "spread";
            shadowForm.Controls.Add(label6);

            TrackBar spreadTrck = new TrackBar();
            spreadTrck.AutoSize = false;
            spreadTrck.Location = new System.Drawing.Point(256, 160);
            spreadTrck.Name = "spreadTrck";
            spreadTrck.Maximum = 100;
            spreadTrck.Size = new System.Drawing.Size(74, 25);
            spreadTrck.TickStyle = System.Windows.Forms.TickStyle.None;
            spreadTrck.Scroll += new EventHandler(this.spreadTrck_Scroll);
            shadowForm.Controls.Add(spreadTrck);

            NumericUpDown spreadNUD = new NumericUpDown();
            spreadNUD.Location = new System.Drawing.Point(176, 161);
            spreadNUD.Name = "spreadNUD";
            spreadNUD.Maximum = 100;
            spreadNUD.Size = new System.Drawing.Size(64, 20);
            spreadNUD.ValueChanged += new System.EventHandler(this.spreadNUD_ValueChanged);
            shadowForm.Controls.Add(spreadNUD);

            Label label7 = new Label();
            label7.Location = new System.Drawing.Point(11, 198);
            label7.Size = new System.Drawing.Size(74, 13);
            label7.Text = "color";
            shadowForm.Controls.Add(label7);

            Button shadowColorBtn = new Button();
            shadowColorBtn.Location = new System.Drawing.Point(176, 193);
            shadowColorBtn.Size = new System.Drawing.Size(47, 23);
            shadowColorBtn.Text = "Select";
            shadowColorBtn.Name = "shadowColorBtn";
            shadowColorBtn.Click += new EventHandler(this.shadowColorBtn_Click);
            shadowForm.Controls.Add(shadowColorBtn);

            TextBox shadowColorVal = new TextBox();
            shadowColorVal.Location = new System.Drawing.Point(224, 195);
            shadowColorVal.Name = "shadowColorVal";
            shadowColorVal.Size = new System.Drawing.Size(100, 20);
            shadowForm.Controls.Add(shadowColorVal);
        }
        private void boxClick(object sender, EventArgs e)
        {
            Form boxForm = new Form();
            boxForm.Size = new Size(299, 131);
            boxForm.StartPosition = FormStartPosition.CenterScreen;
            boxForm.ShowIcon = false;
            boxForm.ShowInTaskbar = false;
            boxForm.Text = "box";
            boxForm.Name = "boxForm";
            boxForm.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            boxForm.MaximizeBox = false;
            boxForm.Show();

            Button boxOK = new Button();
            boxOK.Location = new System.Drawing.Point(186, 62);
            boxOK.Size = new System.Drawing.Size(32, 23);
            boxOK.Text = "OK";
            boxOK.Click += new EventHandler(this.boxOK_Click);
            boxForm.Controls.Add(boxOK);

            Button boxCancel = new Button();
            boxCancel.Location = new System.Drawing.Point(222, 62);
            boxCancel.Size = new System.Drawing.Size(50, 23);
            boxCancel.Text = "Cancel";
            boxCancel.Click += new EventHandler(this.boxCancel_Click);
            boxForm.Controls.Add(boxCancel);

            Label label3 = new Label();
            label3.Location = new System.Drawing.Point(10, 9);
            label3.Size = new System.Drawing.Size(131, 13);
            label3.Text = "content-box";
            boxForm.Controls.Add(label3);

            RadioButton contentBox = new RadioButton();
            contentBox.Location = new System.Drawing.Point(20, 37);
            contentBox.Name = "contentBox";
            contentBox.Size = new System.Drawing.Size(81, 17);
            contentBox.Text = "content-box";
            boxForm.Controls.Add(contentBox);

            RadioButton borderBox = new RadioButton();
            borderBox.Location = new System.Drawing.Point(107, 37);
            borderBox.Name = "borderBox";
            borderBox.Size = new System.Drawing.Size(75, 17);
            borderBox.Text = "border-box";
            boxForm.Controls.Add(borderBox);

            RadioButton paddingBox = new RadioButton();
            paddingBox.Location = new System.Drawing.Point(188, 37);
            paddingBox.Name = "paddingBox";
            paddingBox.Size = new System.Drawing.Size(83, 17);
            paddingBox.Text = "padding-box";
            boxForm.Controls.Add(paddingBox);
        }
        public void border_Click(object sender, EventArgs e)
        {
            Form frm1 = new Form();
            frm1.Size = new Size(288, 288);
            frm1.StartPosition = FormStartPosition.CenterScreen;
            frm1.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            frm1.Name = "borderSelector";
            frm1.Text = "border";
            frm1.ShowIcon = false;
            frm1.ShowInTaskbar = false;
            frm1.MaximizeBox = false;
            frm1.Show();

            Label serhedinStili = new Label();
            serhedinStili.Size = new Size(66, 13);
            serhedinStili.Location = new Point(4, 9);
            serhedinStili.Text = "style";
            serhedinStili.Visible = true;
            frm1.Controls.Add(serhedinStili);

            RadioButton dotted = new RadioButton();
            dotted.Name = "dotted";
            dotted.Size = new Size(60, 17);
            dotted.Location = new Point(7, 25);
            dotted.Text = "dotted";
            dotted.Visible = true;
            frm1.Controls.Add(dotted);

            RadioButton solid = new RadioButton();
            solid.Name = "solid";
            solid.Size = new Size(50, 17);
            solid.Location = new Point(73, 25);
            solid.Text = "solid";
            solid.Visible = true;
            frm1.Controls.Add(solid);

            RadioButton groove = new RadioButton();
            groove.Name = "groove";
            groove.Size = new Size(64, 17);
            groove.Location = new Point(136, 25);
            groove.Text = "groove";
            groove.Visible = true;
            frm1.Controls.Add(groove);

            RadioButton inset = new RadioButton();
            inset.Name = "inset";
            inset.Size = new Size(50, 17);
            inset.Location = new Point(203, 25);
            inset.Text = "inset";
            inset.Visible = true;
            frm1.Controls.Add(inset);

            PictureBox dottedImg = new PictureBox();
            dottedImg.Location = new Point(7, 48);
            dottedImg.Size = new Size(52, 31);
            dottedImg.Image = global::Loxie.Properties.Resources.dotted;
            dottedImg.Visible = true;
            frm1.Controls.Add(dottedImg);

            PictureBox solidImg = new PictureBox();
            solidImg.Location = new Point(73, 48);
            solidImg.Size = new Size(52, 31);
            solidImg.Image = global::Loxie.Properties.Resources.solid;
            solidImg.Visible = true;
            frm1.Controls.Add(solidImg);

            PictureBox grooveImg = new PictureBox();
            grooveImg.Location = new Point(136, 48);
            grooveImg.Size = new Size(54, 31);
            grooveImg.Image = global::Loxie.Properties.Resources.groove;
            grooveImg.Visible = true;
            frm1.Controls.Add(grooveImg);

            PictureBox insetImg = new PictureBox();
            insetImg.Location = new Point(203, 48);
            insetImg.Size = new Size(52, 31);
            insetImg.Image = global::Loxie.Properties.Resources.inset;
            insetImg.Visible = true;
            frm1.Controls.Add(insetImg);

            RadioButton dashed = new RadioButton();
            dashed.Name = "dashed";
            dashed.Size = new Size(65, 17);
            dashed.Location = new Point(7, 99);
            dashed.Text = "dashed";
            dashed.Visible = true;
            frm1.Controls.Add(dashed);

            RadioButton double1 = new RadioButton();
            double1.Name = "double";
            double1.Location = new Point(73, 99);
            double1.Size = new Size(63, 17);
            double1.Text = "double";
            double1.Visible = true;
            frm1.Controls.Add(double1);

            RadioButton ridge = new RadioButton();
            ridge.Name = "ridge";
            ridge.Location = new Point(136, 99);
            ridge.Size = new Size(52, 17);
            ridge.Text = "ridge";
            ridge.Visible = true;
            frm1.Controls.Add(ridge);

            RadioButton outset = new RadioButton();
            outset.Name = "outset";
            outset.Location = new Point(201, 99);
            outset.Size = new Size(59, 17);
            outset.Text = "outset";
            outset.Visible = true;
            frm1.Controls.Add(outset);

            PictureBox dashedImg = new PictureBox();
            dashedImg.Location = new Point(7, 122);
            dashedImg.Size = new Size(56, 34);
            dashedImg.Image = global::Loxie.Properties.Resources.dashed;
            dashedImg.Visible = true;
            frm1.Controls.Add(dashedImg);

            PictureBox doubleImg = new PictureBox();
            doubleImg.Location = new Point(73, 123);
            doubleImg.Size = new Size(53, 31);
            doubleImg.Image = global::Loxie.Properties.Resources._double;
            doubleImg.Visible = true;
            frm1.Controls.Add(doubleImg);

            PictureBox ridgeImg = new PictureBox();
            ridgeImg.Location = new Point(136, 123);
            ridgeImg.Size = new Size(52, 31);
            ridgeImg.Image = global::Loxie.Properties.Resources.ridge;
            ridgeImg.Visible = true;
            frm1.Controls.Add(ridgeImg);

            PictureBox outsetImg = new PictureBox();
            outsetImg.Location = new Point(201, 123);
            outsetImg.Size = new Size(59, 31);
            outsetImg.Image = global::Loxie.Properties.Resources.outset;
            outsetImg.Visible = true;
            frm1.Controls.Add(outsetImg);

            Label serhedinOlcusu = new Label();
            serhedinOlcusu.Size = new Size(83, 13);
            serhedinOlcusu.Location = new Point(4, 183);
            serhedinOlcusu.Text = "size";
            serhedinOlcusu.Visible = true;
            frm1.Controls.Add(serhedinOlcusu);

            NumericUpDown borderSize = new NumericUpDown();
            borderSize.Size = new Size(40, 20);
            borderSize.Location = new Point(93, 181);
            borderSize.Name = "borderSize";
            frm1.Controls.Add(borderSize);

            Button borderOk = new Button();
            borderOk.Location = new Point(165, 214);
            borderOk.Size = new Size(32, 23);
            borderOk.Text = "OK";
            frm1.Controls.Add(borderOk);
            borderOk.Click += new System.EventHandler(this.borderOk_Click);

            Button borderCancel = new Button();
            borderCancel.Location = new Point(209, 214);
            borderCancel.Size = new Size(52, 23);
            borderCancel.Text = "Cancel";
            frm1.Controls.Add(borderCancel);
            borderCancel.Click += new System.EventHandler(this.borderCancel_Click);

            Button setBorderColor = new Button();
            setBorderColor.Location = new Point(145, 179);
            setBorderColor.Size = new Size(43, 23);
            setBorderColor.Text = "color";
            frm1.Controls.Add(setBorderColor);
            setBorderColor.Click += new System.EventHandler(this.setBorderColor_Click);

            TextBox colorCode = new TextBox();
            colorCode.Size = new Size(66, 20);
            colorCode.Location = new Point(194, 180);
            frm1.Controls.Add(colorCode);
            colorCode.Name = "colorCode";
        }
        public void padding_Click(object sender, EventArgs e)
        {
            Form frm1 = new Form();
            frm1.Size = new Size(173, 218);
            frm1.StartPosition = FormStartPosition.CenterScreen;
            frm1.Name = "PaddingSelector";
            frm1.Text = "padding";
            frm1.ShowIcon = false;
            frm1.ShowInTaskbar = false;
            frm1.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            frm1.MaximizeBox = false;
            frm1.Show();

            Label paddingTop = new Label();
            paddingTop.Text = "top";
            paddingTop.Size = new Size(36, 13);
            paddingTop.Location = new Point(12, 13);
            frm1.Controls.Add(paddingTop);


            Label paddingBtm = new Label();
            paddingBtm.Text = "bottom";
            paddingBtm.Size = new Size(40, 18);
            paddingBtm.Location = new Point(12, 45);
            frm1.Controls.Add(paddingBtm);

            Label paddingLeft = new Label();
            paddingLeft.Text = "left";
            paddingLeft.Size = new Size(24, 13);
            paddingLeft.Location = new Point(12, 77);
            frm1.Controls.Add(paddingLeft);

            Label paddingRight = new Label();
            paddingRight.Text = "right";
            paddingRight.Size = new Size(36, 18);
            paddingRight.Location = new Point(12, 107);
            frm1.Controls.Add(paddingRight);

            NumericUpDown paddingTopVal = new NumericUpDown();
            paddingTopVal.Name = "top";
            paddingTopVal.Location = new Point(88, 11);
            paddingTopVal.Size = new Size(55, 20);
            frm1.Controls.Add(paddingTopVal);

            NumericUpDown paddingBtmVal = new NumericUpDown();
            paddingBtmVal.Name = "bottom";
            paddingBtmVal.Location = new Point(88, 43);
            paddingBtmVal.Size = new Size(55, 20);
            frm1.Controls.Add(paddingBtmVal);

            NumericUpDown paddingLeftVal = new NumericUpDown();
            paddingLeftVal.Name = "left";
            paddingLeftVal.Location = new Point(88, 75);
            paddingLeftVal.Size = new Size(55, 20);
            frm1.Controls.Add(paddingLeftVal);

            NumericUpDown paddingRightVal = new NumericUpDown();
            paddingRightVal.Name = "right";
            paddingRightVal.Location = new Point(88, 105);
            paddingRightVal.Size = new Size(55, 20);
            frm1.Controls.Add(paddingRightVal);

            Button OKPddngBtn = new Button();
            OKPddngBtn.Visible = true;
            OKPddngBtn.Text = "OK";
            OKPddngBtn.Size = new Size(32, 23);
            OKPddngBtn.Location = new Point(58, 146);
            frm1.Controls.Add(OKPddngBtn);
            OKPddngBtn.Click += new System.EventHandler(this.OKPddngBtn_Click);

            Button CancelPddngBtn = new Button();
            CancelPddngBtn.Visible = true;
            CancelPddngBtn.Text = "Cancel";
            CancelPddngBtn.Size = new Size(50, 23);
            CancelPddngBtn.Location = new Point(95, 146);
            frm1.Controls.Add(CancelPddngBtn);
            CancelPddngBtn.Click += new System.EventHandler(this.CancelPddngBtn_Click);
        }
        private void formBtn_Click(object sender, EventArgs e)
        {
            Form form_form = new Form();
            form_form.Size = new Size(281, 374);
            form_form.StartPosition = FormStartPosition.CenterScreen;
            form_form.Name = "FormCreator";
            form_form.Text = "form";
            form_form.ShowIcon = false;
            form_form.ShowInTaskbar = false;
            form_form.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            form_form.MaximizeBox = false;
            form_form.Show();

            Label formName = new Label();
            formName.Text = "name";
            formName.Location = new Point(12, 13);
            formName.Size = new Size(40, 13);
            form_form.Controls.Add(formName);

            TextBox formNameVal = new TextBox();
            formNameVal.Name = "formNameVal";
            formNameVal.Location = new Point(92, 10);
            formNameVal.Size = new Size(160, 20);
            formNameVal.TextAlign = HorizontalAlignment.Center;
            form_form.Controls.Add(formNameVal);

            Label autocomplete = new Label();
            autocomplete.Size = new Size(85, 13);
            autocomplete.Text = "autocomplete";
            autocomplete.Location = new Point(12, 48);
            form_form.Controls.Add(autocomplete);

            CheckBox autocompleteCheck = new CheckBox();
            autocompleteCheck.Name = "autocompleteCheck";
            autocompleteCheck.Location = new Point(237, 48);
            autocompleteCheck.Size = new Size(15, 15);
            autocompleteCheck.Text = "";
            form_form.Controls.Add(autocompleteCheck);

            Label enctype = new Label();
            enctype.Text = "enc-type";
            enctype.Location = new Point(12, 79);
            enctype.Size = new Size(70, 13);
            form_form.Controls.Add(enctype);

            RadioButton application = new RadioButton();
            application.Text = "application";
            application.Name = "application";
            application.Location = new Point(15, 105);
            application.Size = new Size(77, 17);
            form_form.Controls.Add(application);

            RadioButton text = new RadioButton();
            text.Name = "text";
            text.Text = "text";
            text.Location = new Point(98, 105);
            text.Size = new Size(44, 17);
            form_form.Controls.Add(text);

            RadioButton multipart = new RadioButton();
            multipart.Name = "multipart";
            multipart.Text = "multipart";
            multipart.Location = new Point(148, 105);
            multipart.Size = new Size(72, 17);
            form_form.Controls.Add(multipart);

            Label method = new Label();
            method.Text = "method";
            method.Size = new Size(87, 13);
            method.Location = new Point(12, 145);
            form_form.Controls.Add(method);

            RadioButton get = new RadioButton();
            get.Name = "get";
            get.Text = "get";
            get.Location = new Point(15, 164);
            get.Size = new Size(42, 17);
            form_form.Controls.Add(get);

            RadioButton post = new RadioButton();
            post.Name = "post";
            post.Text = "post";
            post.Location = new Point(94, 164);
            post.Size = new Size(48, 17);
            form_form.Controls.Add(post);

            Label action = new Label();
            action.Size = new Size(56, 13);
            action.Location = new Point(12, 198);
            action.Text = "action";
            form_form.Controls.Add(action);

            Button fileSelect = new Button();
            fileSelect.Size = new Size(45, 20);
            fileSelect.Location = new Point(27, 219);
            fileSelect.Text = "Select";
            fileSelect.Click += new System.EventHandler(this.fileSelect_Click);
            form_form.Controls.Add(fileSelect);

            TextBox actionFile = new TextBox();
            actionFile.Size = new Size(160, 20);
            actionFile.Location = new Point(92, 220);
            actionFile.Name = "actionFile";
            form_form.Controls.Add(actionFile);

            Label target = new Label();
            target.Size = new Size(38, 13);
            target.Location = new Point(12, 258);
            target.Text = "target";
            form_form.Controls.Add(target);


            RadioButton _self = new RadioButton();
            _self.Name = "_self";
            _self.Text = "_self";
            _self.Location = new Point(15, 274);
            _self.Size = new Size(48, 17);
            form_form.Controls.Add(_self);

            RadioButton _blank = new RadioButton();
            _blank.Name = "_blank";
            _blank.Text = "_blank";
            _blank.Location = new Point(69, 274);
            _blank.Size = new Size(59, 17);
            form_form.Controls.Add(_blank);

            RadioButton _parent = new RadioButton();
            _parent.Name = "_parent";
            _parent.Text = "_parent";
            _parent.Location = new Point(134, 274);
            _parent.Size = new Size(64, 17);
            form_form.Controls.Add(_parent);

            RadioButton _top = new RadioButton();
            _top.Name = "_top";
            _top.Text = "_top";
            _top.Location = new Point(204, 274);
            _top.Size = new Size(48, 17);
            form_form.Controls.Add(_top);

            Button formOK = new Button();
            formOK.Size = new Size(32, 23);
            formOK.Location = new Point(166, 301);
            formOK.Text = "OK";
            formOK.Click += new System.EventHandler(this.formOK_Click);
            form_form.Controls.Add(formOK);

            Button formCancel = new Button();
            formCancel.Size = new Size(50, 23);
            formCancel.Location = new Point(200, 301);
            formCancel.Text = "Cancel";
            formCancel.Click += new System.EventHandler(this.formCancel_Click);
            form_form.Controls.Add(formCancel);
        }
        private void displayClick(object sender, EventArgs e)
        {
            Form displayForm = new Form();
            displayForm.Size = new Size(304, 141);
            displayForm.StartPosition = FormStartPosition.CenterScreen;
            displayForm.ShowIcon = false;
            displayForm.ShowInTaskbar = false;
            displayForm.Text = "display";
            displayForm.Name = "displayForm";
            displayForm.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            displayForm.MaximizeBox = false;
            displayForm.Show();

            Label displayLbl = new Label();
            displayLbl.Text = "display";
            displayLbl.Size = new Size(50, 13);
            displayLbl.Location = new Point(16, 36);
            displayForm.Controls.Add(displayLbl);

            ComboBox displayTypes = new ComboBox();
            displayTypes.Items.AddRange(new object[] {
            "block",
            "inline",
            "inline-block",
            "inline-table",
            "list-item",
            "none ",
            "run-in",
            "table",
            "table-caption",
            "table-cell",
            "table-column-group",
            "table-column ",
            "table-footer-group",
            "table-header-group",
            "table-row",
            "table-row-group"});
            displayTypes.Location = new System.Drawing.Point(149, 33);
            displayTypes.Name = "displayTypes";
            displayTypes.Size = new System.Drawing.Size(123, 21);
            displayForm.Controls.Add(displayTypes);

            Button displayOK = new Button();
            displayOK.Location = new System.Drawing.Point(186, 72);
            displayOK.Size = new System.Drawing.Size(32, 23);
            displayOK.Text = "OK";
            displayOK.Click += new EventHandler(this.displayOK_Click);
            displayForm.Controls.Add(displayOK);

            Button displayCancel = new Button();
            displayCancel.Location = new System.Drawing.Point(221, 72);
            displayCancel.Size = new System.Drawing.Size(50, 23);
            displayCancel.Text = "Cancel";
            displayCancel.Click += new EventHandler(this.displayCancel_Click);
            displayForm.Controls.Add(displayCancel);
        }
        private void animateClick(object sender, EventArgs e)
        {
            Form animateForm = new Form();
            animateForm.Size = new Size(278, 297);
            animateForm.StartPosition = FormStartPosition.CenterScreen;
            animateForm.ShowIcon = false;
            animateForm.ShowInTaskbar = false;
            animateForm.Text = "animate";
            animateForm.Name = "animateForm";
            animateForm.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            animateForm.MaximizeBox = false;
            animateForm.Show();

            Button animateOK = new Button();
            animateOK.Location = new System.Drawing.Point(165, 225);
            animateOK.Size = new System.Drawing.Size(32, 23);
            animateOK.Text = "OK";
            animateOK.Click += new System.EventHandler(animateOK_Click);
            animateForm.Controls.Add(animateOK);

            Button animateCancel = new Button();
            animateCancel.Location = new System.Drawing.Point(200, 225);
            animateCancel.Size = new System.Drawing.Size(50, 23);
            animateCancel.Text = "Cancel";
            animateCancel.Click += new EventHandler(this.animateCancel_Click);
            animateForm.Controls.Add(animateCancel);

            Label animateNameLbl = new Label();
            animateNameLbl.Location = new System.Drawing.Point(13, 15);
            animateNameLbl.Size = new System.Drawing.Size(81, 13);
            animateNameLbl.Text = "animation-name";
            animateForm.Controls.Add(animateNameLbl);

            Label animateDurationLbl = new Label();
            animateDurationLbl.Location = new System.Drawing.Point(13, 41);
            animateDurationLbl.Size = new System.Drawing.Size(93, 13);
            animateDurationLbl.Text = "animation-duration";
            animateForm.Controls.Add(animateDurationLbl);

            Label animateTimingFLbl = new Label();
            animateTimingFLbl.Location = new System.Drawing.Point(13, 67);
            animateTimingFLbl.Size = new System.Drawing.Size(123, 13);
            animateTimingFLbl.Text = "animation-timing-function";
            animateForm.Controls.Add(animateTimingFLbl);

            Label animateDelayLbl = new Label();
            animateDelayLbl.Location = new System.Drawing.Point(13, 93);
            animateDelayLbl.Size = new System.Drawing.Size(80, 13);
            animateDelayLbl.Text = "animation-delay";
            animateForm.Controls.Add(animateDelayLbl);

            Label animateIterationLbl = new Label();
            animateIterationLbl.Location = new System.Drawing.Point(14, 119);
            animateIterationLbl.Size = new System.Drawing.Size(122, 13);
            animateIterationLbl.Text = "animation-iteration-count";
            animateForm.Controls.Add(animateIterationLbl);

            Label animateDirectionLbl = new Label();
            animateDirectionLbl.Location = new System.Drawing.Point(14, 145);
            animateDirectionLbl.Size = new System.Drawing.Size(95, 13);
            animateDirectionLbl.Text = "animation-direction";
            animateForm.Controls.Add(animateDirectionLbl);

            Label animationFillLbl = new Label();
            animationFillLbl.Location = new System.Drawing.Point(14, 171);
            animationFillLbl.Size = new System.Drawing.Size(93, 13);
            animationFillLbl.Text = "animation-fill-mode";
            animateForm.Controls.Add(animationFillLbl);

            Label animationPlaySLbl = new Label();
            animationPlaySLbl.Location = new System.Drawing.Point(13, 197);
            animationPlaySLbl.Size = new System.Drawing.Size(100, 13);
            animationPlaySLbl.Text = "animation-play-state";
            animateForm.Controls.Add(animationPlaySLbl);

            TextBox animateNameVal = new TextBox();
            animateNameVal.Location = new System.Drawing.Point(150, 12);
            animateNameVal.Name = "animateNameVal";
            animateNameVal.Size = new System.Drawing.Size(100, 20);
            animateForm.Controls.Add(animateNameVal);

            ComboBox animateTimingFunc = new ComboBox();
            animateTimingFunc.Items.AddRange(new object[] {
            "ease",
            "ease-in",
            "ease-out",
            "ease-in-out",
            "linear",
            "step-start",
            "step-end",
            "steps",
            "cubic-bezier"});
            animateTimingFunc.Location = new System.Drawing.Point(150, 64);
            animateTimingFunc.Name = "animateTimingFunc";
            animateTimingFunc.Size = new System.Drawing.Size(100, 21);
            animateForm.Controls.Add(animateTimingFunc);

            Label seconds1 = new Label();
            seconds1.Location = new System.Drawing.Point(238, 93);
            seconds1.Name = "label10";
            seconds1.Size = new System.Drawing.Size(12, 13);
            seconds1.Text = "s";
            animateForm.Controls.Add(seconds1);

            NumericUpDown animateDelay = new NumericUpDown();
            animateDelay.Location = new System.Drawing.Point(186, 91);
            animateDelay.Name = "animateDelay";
            animateDelay.Size = new System.Drawing.Size(46, 20);
            animateDelay.Maximum = 1000;
            animateForm.Controls.Add(animateDelay);

            CheckBox infiniteCheck = new CheckBox();
            infiniteCheck.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            infiniteCheck.Location = new System.Drawing.Point(218, 113);
            infiniteCheck.Name = "infiniteCheck";
            infiniteCheck.Size = new System.Drawing.Size(45, 29);
            infiniteCheck.Text = "∞";
            infiniteCheck.CheckedChanged += new System.EventHandler(this.infiniteCheck_CheckedChanged);
            animateForm.Controls.Add(infiniteCheck);

            NumericUpDown animateDuration = new NumericUpDown();
            animateDuration.Location = new System.Drawing.Point(186, 39);
            animateDuration.Name = "animateDuration";
            animateDuration.Size = new System.Drawing.Size(46, 20);
            animateDuration.Maximum = 1000;
            animateForm.Controls.Add(animateDuration);

            Label seconds2 = new Label();
            seconds2.Location = new System.Drawing.Point(238, 41);
            seconds2.Size = new System.Drawing.Size(12, 13);
            seconds2.Text = "s";
            animateForm.Controls.Add(seconds2);

            NumericUpDown animateIterationCount = new NumericUpDown();
            animateIterationCount.Location = new System.Drawing.Point(150, 118);
            animateIterationCount.Name = "animateIterationCount";
            animateIterationCount.Size = new System.Drawing.Size(46, 20);
            animateIterationCount.Maximum = 1000;
            animateForm.Controls.Add(animateIterationCount);

            ComboBox animateDirection = new ComboBox();
            animateDirection.Items.AddRange(new object[] {
            "normal",
            "alternate",
            "reverse",
            "alternate-reverse"});
            animateDirection.Location = new System.Drawing.Point(150, 143);
            animateDirection.Name = "animateDirection";
            animateDirection.Size = new System.Drawing.Size(100, 21);
            animateForm.Controls.Add(animateDirection);

            ComboBox animateFillMode = new ComboBox();
            animateFillMode.Items.AddRange(new object[] {
            "none",
            "forwards",
            "backwards",
            "both"});
            animateFillMode.Location = new System.Drawing.Point(150, 168);
            animateFillMode.Name = "animateFillMode";
            animateFillMode.Size = new System.Drawing.Size(100, 21);
            animateForm.Controls.Add(animateFillMode);

            ComboBox animatePlayState = new ComboBox();
            animatePlayState.Items.AddRange(new object[] {
            "running",
            "paused"});
            animatePlayState.Location = new System.Drawing.Point(150, 194);
            animatePlayState.Name = "animatePlayState";
            animatePlayState.Size = new System.Drawing.Size(100, 21);
            animateForm.Controls.Add(animatePlayState);
        }
        public void align_Click(object sender, EventArgs e)
        {
            Form alignForm = new Form();
            alignForm.Size = new Size(243, 401);
            alignForm.StartPosition = FormStartPosition.CenterScreen;
            alignForm.ShowIcon = false;
            alignForm.ShowInTaskbar = false;
            alignForm.Text = "align";
            alignForm.Name = "alignForm";
            alignForm.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            alignForm.MaximizeBox = false;
            alignForm.Show();

            GroupBox alignContentGpb = new GroupBox();
            alignContentGpb.Name = "alignContentGpb";
            alignContentGpb.Location = new Point(12, 12);
            alignContentGpb.Size = new Size(200, 100);
            alignContentGpb.Text = "align-content";
            alignForm.Controls.Add(alignContentGpb);

            ComboBox alignContentItems = new ComboBox();
            alignContentItems.Items.AddRange(new object[] {
            "flex-start",
            "flex-end",
            "center",
            "space-between",
            "space-around",
            "stretch"});
            alignContentItems.Location = new System.Drawing.Point(6, 41);
            alignContentItems.Name = "alignContentItems";
            alignContentItems.Size = new System.Drawing.Size(80, 21);
            alignContentItems.SelectedIndexChanged += new System.EventHandler(this.alignContentItems_SelectedIndexChanged);
            alignContentGpb.Controls.Add(alignContentItems);

            PictureBox alignContentView = new PictureBox();
            alignContentView.BackgroundImage = global::Loxie.Properties.Resources.center;
            alignContentView.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            alignContentView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            alignContentView.Location = new System.Drawing.Point(98, 19);
            alignContentView.Name = "alignContentView";
            alignContentView.Size = new System.Drawing.Size(96, 68);
            alignContentGpb.Controls.Add(alignContentView);

            GroupBox alignItemsGpb = new GroupBox();
            alignItemsGpb.Name = "alignItemsGpb";
            alignItemsGpb.Location = new Point(12, 118);
            alignItemsGpb.Size = new Size(200, 100);
            alignItemsGpb.Text = "align-items";
            alignForm.Controls.Add(alignItemsGpb);

            ComboBox alignItemsItems = new ComboBox();
            alignItemsItems.Items.AddRange(new object[] {
            "flex-start",
            "flex-end",
            "center",
            "baseline",
            "stretch"});
            alignItemsItems.Location = new System.Drawing.Point(6, 41);
            alignItemsItems.Name = "alignItemsItems";
            alignItemsItems.Size = new System.Drawing.Size(80, 21);
            alignItemsGpb.Controls.Add(alignItemsItems);
            alignItemsItems.SelectedIndexChanged += new System.EventHandler(this.alignItemsItems_SelectedIndexChanged);

            PictureBox alignItemsView = new PictureBox();
            alignItemsView.BackgroundImage = global::Loxie.Properties.Resources.center;
            alignItemsView.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            alignItemsView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            alignItemsView.Location = new System.Drawing.Point(98, 19);
            alignItemsView.Name = "alignItemsView";
            alignItemsView.Size = new System.Drawing.Size(96, 68);
            alignItemsGpb.Controls.Add(alignItemsView);

            GroupBox alignSelftGpb = new GroupBox();
            alignSelftGpb.Location = new System.Drawing.Point(12, 224);
            alignSelftGpb.Name = "alignSelftGpb";
            alignSelftGpb.Size = new System.Drawing.Size(200, 100);
            alignSelftGpb.Text = "align-self";
            alignForm.Controls.Add(alignSelftGpb);

            ComboBox alignSelfItems = new ComboBox();
            alignSelfItems.Items.AddRange(new object[] {
            "flex-start",
            "flex-end",
            "center",
            "baseline",
            "stretch"});
            alignSelfItems.Location = new System.Drawing.Point(6, 41);
            alignSelfItems.Name = "alignSelfItems";
            alignSelfItems.Size = new System.Drawing.Size(80, 21);
            alignSelfItems.SelectedIndexChanged += new System.EventHandler(this.alignSelfItems_SelectedIndexChanged);
            alignSelftGpb.Controls.Add(alignSelfItems);

            PictureBox alignSelfView = new PictureBox();
            alignSelfView.BackgroundImage = global::Loxie.Properties.Resources.center;
            alignSelfView.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            alignSelfView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            alignSelfView.Location = new System.Drawing.Point(98, 19);
            alignSelfView.Name = "alignSelfView";
            alignSelfView.Size = new System.Drawing.Size(96, 68);
            alignSelftGpb.Controls.Add(alignSelfView);

            Button alignOK = new Button();
            alignOK.Location = new System.Drawing.Point(123, 330);
            alignOK.Size = new System.Drawing.Size(32, 23);
            alignOK.Text = "OK";
            alignOK.Click += new System.EventHandler(this.alignOK_Click);
            alignForm.Controls.Add(alignOK);

            Button alignCancel = new Button();
            alignCancel.Location = new System.Drawing.Point(160, 330);
            alignCancel.Size = new System.Drawing.Size(50, 23);
            alignCancel.Text = "Cancel";
            alignCancel.Click += new System.EventHandler(this.alignCancel_Click);
            alignForm.Controls.Add(alignCancel);
        }
        private void meterBtn_Click(object sender, EventArgs e)
        {
            Form meterForm = new Form();
            meterForm.Size = new Size(169, 296);
            meterForm.StartPosition = FormStartPosition.CenterScreen;
            meterForm.ShowIcon = false;
            meterForm.ShowInTaskbar = false;
            meterForm.Text = "meter";
            meterForm.Name = "meterForm";
            meterForm.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            meterForm.MaximizeBox = false;
            meterForm.Show();

            Label valueLbl = new Label();
            valueLbl.Size = new Size(37, 13);
            valueLbl.Location = new Point(12, 15);
            valueLbl.Text = "value";
            meterForm.Controls.Add(valueLbl);

            Label minLbl = new Label();
            minLbl.Location = new Point(12, 48);
            minLbl.Size = new Size(54, 13);
            minLbl.Text = "minimum";
            meterForm.Controls.Add(minLbl);

            Label maxLbl = new Label();
            maxLbl.Location = new System.Drawing.Point(12, 79);
            maxLbl.Size = new System.Drawing.Size(63, 13);
            maxLbl.Text = "maximum";
            meterForm.Controls.Add(maxLbl);

            Label optimalLbl = new Label();
            optimalLbl.Location = new System.Drawing.Point(2, 105);
            optimalLbl.Size = new System.Drawing.Size(63, 34);
            optimalLbl.Text = "optimal value";
            optimalLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            meterForm.Controls.Add(optimalLbl);

            Label highLbl = new Label();
            highLbl.Location = new System.Drawing.Point(12, 149);
            highLbl.Size = new System.Drawing.Size(54, 36);
            highLbl.Text = "high";
            meterForm.Controls.Add(highLbl);

            Label lowLbl = new Label();
            lowLbl.Location = new System.Drawing.Point(12, 185);
            lowLbl.Size = new System.Drawing.Size(54, 36);
            lowLbl.Text = "low";
            meterForm.Controls.Add(lowLbl);

            NumericUpDown value = new NumericUpDown();
            value.Location = new System.Drawing.Point(87, 13);
            value.Name = "value";
            value.Size = new System.Drawing.Size(47, 20);
            value.Maximum = 1000;
            meterForm.Controls.Add(value);

            NumericUpDown min = new NumericUpDown();
            min.Location = new System.Drawing.Point(87, 46);
            min.Name = "min";
            min.Maximum = 1000;
            min.Size = new System.Drawing.Size(47, 20);
            meterForm.Controls.Add(min);

            NumericUpDown max = new NumericUpDown();
            max.Location = new System.Drawing.Point(87, 77);
            max.Name = "max";
            max.Size = new System.Drawing.Size(47, 20);
            max.Maximum = 1000;
            meterForm.Controls.Add(max);

            NumericUpDown optimal = new NumericUpDown();
            optimal.Location = new System.Drawing.Point(87, 112);
            optimal.Maximum = 1000;
            optimal.Name = "optimal";
            optimal.Size = new System.Drawing.Size(47, 20);
            meterForm.Controls.Add(optimal);

            NumericUpDown high = new NumericUpDown();
            high.Location = new System.Drawing.Point(86, 154);
            high.Maximum = 1000;
            high.Name = "high";
            high.Size = new System.Drawing.Size(47, 20);
            meterForm.Controls.Add(high);

            NumericUpDown low = new NumericUpDown();
            low.Location = new System.Drawing.Point(86, 187);
            low.Maximum = 1000;
            low.Name = "low";
            low.Size = new System.Drawing.Size(47, 20);
            meterForm.Controls.Add(low);

            Button meterOK = new Button();
            meterOK.Location = new System.Drawing.Point(49, 224);
            meterOK.Size = new System.Drawing.Size(32, 23);
            meterOK.Text = "OK";
            meterOK.Click += new EventHandler(this.meterOK_Click);
            meterForm.Controls.Add(meterOK);

            Button meterCancel = new Button();
            meterCancel.Location = new System.Drawing.Point(85, 224);
            meterCancel.Size = new System.Drawing.Size(50, 23);
            meterCancel.Text = "Cancel";
            meterCancel.Click += new EventHandler(this.meterCancel_Click);
            meterForm.Controls.Add(meterCancel);
        }
        private void timeBtn_Click(object sender, EventArgs e)
        {
            Form timeForm = new Form();
            timeForm.Size = new Size(179, 179);
            timeForm.StartPosition = FormStartPosition.CenterScreen;
            timeForm.ShowIcon = false;
            timeForm.Text = "time";
            timeForm.ShowInTaskbar = false;
            timeForm.Name = "timeForm";
            timeForm.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            timeForm.MaximizeBox = false;
            timeForm.Show();

            Label dateLbl = new Label();
            dateLbl.Size = new Size(30, 13);
            dateLbl.Location = new Point(12, 13);
            dateLbl.Text = "date";
            timeForm.Controls.Add(dateLbl);

            DateTimePicker date = new DateTimePicker();
            date.CustomFormat = "yyyy-M-d";
            date.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            date.Location = new System.Drawing.Point(48, 10);
            date.Name = "date";
            date.Size = new System.Drawing.Size(100, 20);
            timeForm.Controls.Add(date);

            Label timeLbl = new Label();
            timeLbl.Size = new Size(30, 13);
            timeLbl.Location = new Point(14, 48);
            timeLbl.Text = "time";
            timeForm.Controls.Add(timeLbl);

            TextBox time = new TextBox();
            time.Name = "time";
            time.Text = (date.Value.ToShortTimeString());
            time.ReadOnly = true;
            time.Size = new Size(100, 20);
            time.Location = new Point(48, 45);
            timeForm.Controls.Add(time);

            CheckBox timeCheck = new CheckBox();
            timeCheck.Name = "timeCheck";
            timeCheck.Size = new Size(91, 17);
            timeCheck.Text = "check time";
            timeCheck.Location = new Point(60, 71);
            timeCheck.CheckedChanged += new System.EventHandler(this.timeCheck_CheckedChanged);
            timeForm.Controls.Add(timeCheck);

            Button timeOK = new Button();
            timeOK.Text = "OK";
            timeOK.Size = new Size(32, 23);
            timeOK.Location = new Point(63, 104);
            timeOK.Click += new EventHandler(this.timeOK_Click);
            timeForm.Controls.Add(timeOK);

            Button timeCancel = new Button();
            timeCancel.Text = "Cancel";
            timeCancel.Size = new Size(50, 23);
            timeCancel.Location = new Point(98, 104);
            timeCancel.Click += new EventHandler(this.timeCancel_Click);
            timeForm.Controls.Add(timeCancel);
        }
        private void figureBtn_Click(object sender, EventArgs e)
        {
            Form figureForm = new Form();
            figureForm.Size = new Size(222, 116);
            figureForm.StartPosition = FormStartPosition.CenterScreen;
            figureForm.ShowIcon = false;
            figureForm.Text = "figure";
            figureForm.Name = "figureForm";
            figureForm.ShowInTaskbar = false;
            figureForm.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            figureForm.MaximizeBox = false;
            figureForm.Show();

            Label figureCaptionLbl = new Label();
            figureCaptionLbl.Size = new Size(74, 13);
            figureCaptionLbl.Location = new Point(12, 13);
            figureCaptionLbl.Text = "figure caption";
            figureForm.Controls.Add(figureCaptionLbl);

            TextBox figureCaption = new TextBox();
            figureCaption.Size = new Size(100, 10);
            figureCaption.Location = new Point(91, 10);
            figureCaption.Name = "figureCaption";
            figureForm.Controls.Add(figureCaption);

            Button figureOK = new Button();
            figureOK.Size = new Size(32, 23);
            figureOK.Text = "OK";
            figureOK.Location = new Point(106, 45);
            figureOK.Click += new EventHandler(this.figureOK_Click);
            figureForm.Controls.Add(figureOK);

            Button figureCancel = new Button();
            figureCancel.Size = new Size(50, 23);
            figureCancel.Text = "Cancel";
            figureCancel.Location = new Point(141, 45);
            figureCancel.Click += new EventHandler(this.figureCancel_Click);
            figureForm.Controls.Add(figureCancel);
        }
        private void progressBtn_Click(object sender, EventArgs e)
        {
            Form progressForm = new Form();
            progressForm.Size = new Size(171, 136);
            progressForm.StartPosition = FormStartPosition.CenterScreen;
            progressForm.ShowIcon = false;
            progressForm.Text = "progress";
            progressForm.ShowInTaskbar = false;
            progressForm.Name = "progressForm";
            progressForm.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            progressForm.MaximizeBox = false;
            progressForm.Show();

            Label progressValueLbl = new Label();
            progressValueLbl.Size = new Size(37, 13);
            progressValueLbl.Location = new Point(12, 13);
            progressValueLbl.Text = "value";
            progressForm.Controls.Add(progressValueLbl);

            Label maxLbl = new Label();
            maxLbl.Size = new Size(63, 13);
            maxLbl.Location = new Point(12, 43);
            maxLbl.Text = "maximum";
            progressForm.Controls.Add(maxLbl);

            NumericUpDown progressValue = new NumericUpDown();
            progressValue.Name = "progressValue";
            progressValue.Size = new Size(42, 20);
            progressValue.Location = new Point(94, 11);
            progressValue.Maximum = 100;
            progressForm.Controls.Add(progressValue);

            NumericUpDown maxValue = new NumericUpDown();
            maxValue.Name = "maxValue";
            maxValue.Size = new Size(42, 20);
            maxValue.Location = new Point(94, 38);
            progressForm.Controls.Add(maxValue);

            Button progressOK = new Button();
            progressOK.Size = new Size(32, 23);
            progressOK.Text = "OK";
            progressOK.Location = new Point(53, 66);
            progressOK.Click += new EventHandler(this.progressOK_Click);
            progressForm.Controls.Add(progressOK);

            Button progressCancel = new Button();
            progressCancel.Size = new Size(50, 23);
            progressCancel.Text = "Cancel";
            progressCancel.Location = new Point(91, 66);
            progressCancel.Click += new EventHandler(this.progressCancel_Click);
            progressForm.Controls.Add(progressCancel);
        }
        private void iframeBtn_Click(object sender, EventArgs e)
        {
            Form iframeForm = new Form();
            iframeForm.Size = new Size(247, 424);
            iframeForm.StartPosition = FormStartPosition.CenterScreen;
            iframeForm.ShowIcon = false;
            iframeForm.Text = "iframe";
            iframeForm.Name = "iframeForm";
            iframeForm.ShowInTaskbar = false;
            iframeForm.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            iframeForm.MaximizeBox = false;
            iframeForm.Show();

            Label iframeNameLbl = new Label();
            iframeNameLbl.Size = new Size(60, 13);
            iframeNameLbl.Location = new Point(12, 13);
            iframeNameLbl.Text = "name";
            iframeForm.Controls.Add(iframeNameLbl);

            Label iframeSandboxLbl = new Label();
            iframeSandboxLbl.Size = new Size(78, 13);
            iframeSandboxLbl.Location = new Point(12, 43);
            iframeSandboxLbl.Text = "sandbox";
            iframeForm.Controls.Add(iframeSandboxLbl);

            Label iframeFileLbl = new Label();
            iframeFileLbl.Size = new Size(26, 13);
            iframeFileLbl.Location = new Point(12, 83);
            iframeFileLbl.Text = "file";
            iframeForm.Controls.Add(iframeFileLbl);

            Label iframeHeightLbl = new Label();
            iframeHeightLbl.Size = new Size(61, 13);
            iframeHeightLbl.Location = new Point(12, 138);
            iframeHeightLbl.Text = "height";
            iframeForm.Controls.Add(iframeHeightLbl);

            Label iframeWidthLbl = new Label();
            iframeWidthLbl.Size = new Size(45, 13);
            iframeWidthLbl.Location = new Point(14, 170);
            iframeWidthLbl.Text = "width";
            iframeForm.Controls.Add(iframeWidthLbl);

            Label iframeObjectPrototypehLbl = new Label();
            iframeObjectPrototypehLbl.Size = new Size(96, 13);
            iframeObjectPrototypehLbl.Location = new Point(12, 210);
            iframeObjectPrototypehLbl.Text = "object prototype";
            iframeForm.Controls.Add(iframeObjectPrototypehLbl);

            TextBox iframeName = new TextBox();
            iframeName.Name = "iframeName";
            iframeName.Size = new Size(122, 20);
            iframeName.Location = new Point(96, 10);
            iframeForm.Controls.Add(iframeName);

            ComboBox iframeSandbox = new ComboBox();
            iframeSandbox.Name = "iframeSandbox";
            iframeSandbox.Size = new Size(122, 20);
            iframeSandbox.Location = new Point(96, 40);
            iframeSandbox.Items.Add("allow-same-origin");
            iframeSandbox.Items.Add("allow-top-navigation");
            iframeSandbox.Items.Add("allow-forms");
            iframeSandbox.Items.Add("allow-scripts");
            iframeForm.Controls.Add(iframeSandbox);

            CheckBox iframeSandboxChk = new CheckBox();
            iframeSandboxChk.Name = "iframeSandboxChk";
            iframeSandboxChk.Size = new Size(55, 17);
            iframeSandboxChk.Text = "all";
            iframeSandboxChk.CheckedChanged += new System.EventHandler(this.iframeSandboxChk_CheckedChanged);
            iframeSandboxChk.Location = new Point(167, 67);
            iframeForm.Controls.Add(iframeSandboxChk);

            Button iframeFileSelectBtn = new Button();
            iframeFileSelectBtn.Location = new Point(18, 99);
            iframeFileSelectBtn.Size = new Size(45, 23);
            iframeFileSelectBtn.Text = "Select";
            iframeFileSelectBtn.Click += new System.EventHandler(this.iframeFileSelectBtn_Click);
            iframeForm.Controls.Add(iframeFileSelectBtn);

            TextBox iframeFileURL = new TextBox();
            iframeFileURL.Name = "iframeFileURL";
            iframeFileURL.Size = new Size(122, 20);
            iframeFileURL.Location = new Point(96, 101);
            iframeForm.Controls.Add(iframeFileURL);

            TrackBar iframeHeightVal = new TrackBar();
            iframeHeightVal.AutoSize = false;
            iframeHeightVal.Name = "iframeHeightVal";
            iframeHeightVal.Size = new Size(77, 25);
            iframeHeightVal.Location = new Point(96, 136);
            iframeHeightVal.Maximum = 1000;
            iframeHeightVal.Value = 500;
            iframeHeightVal.TickStyle = TickStyle.None;
            iframeHeightVal.Scroll += new System.EventHandler(this.iframeHeightVal_Scroll);
            iframeForm.Controls.Add(iframeHeightVal);

            TrackBar iframeWidthVal = new TrackBar();
            iframeWidthVal.AutoSize = false;
            iframeWidthVal.Name = "iframeWidthVal";
            iframeWidthVal.Size = new Size(77, 25);
            iframeWidthVal.Location = new Point(96, 167);
            iframeWidthVal.Maximum = 1000;
            iframeWidthVal.Value = 500;
            iframeWidthVal.TickStyle = TickStyle.None;
            iframeWidthVal.Scroll += new System.EventHandler(this.iframeWidthVal_Scroll);
            iframeForm.Controls.Add(iframeWidthVal);

            TextBox iframeHeightText = new TextBox();
            iframeHeightText.Name = "iframeHeightText";
            iframeHeightText.Size = new Size(38, 20);
            iframeHeightText.Location = new Point(180, 138);
            iframeForm.Controls.Add(iframeHeightText);

            TextBox iframeWidthText = new TextBox();
            iframeWidthText.Name = "iframeWidthText";
            iframeWidthText.Size = new Size(38, 20);
            iframeWidthText.Location = new Point(180, 172);
            iframeForm.Controls.Add(iframeWidthText);

            Label iframeObjPrototypeLbl = new Label();
            iframeObjPrototypeLbl.Size = new Size(96, 13);
            iframeObjPrototypeLbl.Location = new Point(12, 210);
            iframeForm.Controls.Add(iframeObjPrototypeLbl);

            FlowLayoutPanel iframeObjPrototype = new FlowLayoutPanel();
            iframeObjPrototype.Name = "iframeObjPrototype";
            iframeObjPrototype.Size = new Size(200, 118);
            iframeObjPrototype.Location = new Point(18, 226);
            iframeObjPrototype.BorderStyle = BorderStyle.FixedSingle;
            iframeObjPrototype.Paint += new PaintEventHandler(this.iframeObjPrototype_Paint);
            iframeForm.Controls.Add(iframeObjPrototype);

            Button iframeOK = new Button();
            iframeOK.Size = new Size(32, 23);
            iframeOK.Location = new Point(134, 350);
            iframeOK.Text = "OK";
            iframeOK.Click += new EventHandler(this.iframeOK_Click);
            iframeForm.Controls.Add(iframeOK);

            Button iframeCancel = new Button();
            iframeCancel.Size = new Size(50, 23);
            iframeCancel.Location = new Point(172, 350);
            iframeCancel.Text = "Cancel";
            iframeCancel.Click += new EventHandler(this.iframeCancel_Click);
            iframeForm.Controls.Add(iframeCancel);
        }
        private void selectBtn_Click(object sender, EventArgs e)
        {
            Form selectForm = new Form();
            selectForm.Size = new Size(227, 285);
            selectForm.StartPosition = FormStartPosition.CenterScreen;
            selectForm.ShowIcon = false;
            selectForm.Text = "select";
            selectForm.Name = "selectForm";
            selectForm.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            selectForm.MaximizeBox = false;
            selectForm.ShowInTaskbar = false;
            selectForm.Show();

            Label selectFormIDLbl = new Label();
            selectFormIDLbl.Size = new Size(70, 13);
            selectFormIDLbl.Location = new Point(12, 13);
            selectFormIDLbl.Text = "form id";
            selectForm.Controls.Add(selectFormIDLbl);

            Label selectNameLbl = new Label();
            selectNameLbl.Size = new Size(70, 13);
            selectNameLbl.Location = new Point(12, 42);
            selectNameLbl.Text = "name";
            selectForm.Controls.Add(selectNameLbl);

            Label selectSizeLbl = new Label();
            selectSizeLbl.Size = new Size(87, 13);
            selectSizeLbl.Location = new Point(12, 68);
            selectSizeLbl.Text = "size";
            selectForm.Controls.Add(selectSizeLbl);

            Label selectAutofocusLbl = new Label();
            selectAutofocusLbl.Size = new Size(55, 13);
            selectAutofocusLbl.Location = new Point(12, 95);
            selectAutofocusLbl.Text = "autofocus";
            selectForm.Controls.Add(selectAutofocusLbl);

            Label selectDisabledLbl = new Label();
            selectDisabledLbl.Size = new Size(55, 13);
            selectDisabledLbl.Location = new Point(12, 124);
            selectDisabledLbl.Text = "disabled";
            selectForm.Controls.Add(selectDisabledLbl);

            Label selectMultipleLbl = new Label();
            selectMultipleLbl.Size = new Size(65, 13);
            selectMultipleLbl.Location = new Point(12, 151);
            selectMultipleLbl.Text = "multiple";
            selectForm.Controls.Add(selectMultipleLbl);

            Label selectRequiredLbl = new Label();
            selectRequiredLbl.Size = new Size(99, 13);
            selectRequiredLbl.Location = new Point(12, 180);
            selectRequiredLbl.Text = "required";
            selectForm.Controls.Add(selectRequiredLbl);

            TextBox selectFormID = new TextBox();
            selectFormID.Name = "selectFormID";
            selectFormID.Size = new Size(76, 20);
            selectFormID.Location = new Point(122, 10);
            selectForm.Controls.Add(selectFormID);

            TextBox selectName = new TextBox();
            selectName.Name = "selectName";
            selectName.Size = new Size(76, 20);
            selectName.Location = new Point(122, 39);
            selectForm.Controls.Add(selectName);

            NumericUpDown selectSize = new NumericUpDown();
            selectSize.Name = "selectSize";
            selectSize.Size = new Size(45, 20);
            selectSize.Location = new Point(152, 66);
            selectSize.Maximum = 1000;
            selectForm.Controls.Add(selectSize);

            CheckBox selectAutofocusChk = new CheckBox();
            selectAutofocusChk.Name = "selectAutofocusChk";
            selectAutofocusChk.Size = new Size(15, 15);
            selectAutofocusChk.Location = new Point(184, 95);
            selectForm.Controls.Add(selectAutofocusChk);

            CheckBox selectDisabledChk = new CheckBox();
            selectDisabledChk.Name = "selectDisabledChk";
            selectDisabledChk.Size = new Size(15, 15);
            selectDisabledChk.Location = new Point(184, 124);
            selectForm.Controls.Add(selectDisabledChk);

            CheckBox selectMultipleChk = new CheckBox();
            selectMultipleChk.Name = "selectMultipleChk";
            selectMultipleChk.Size = new Size(15, 15);
            selectMultipleChk.Location = new Point(184, 151);
            selectForm.Controls.Add(selectMultipleChk);

            CheckBox selectRequiredChk = new CheckBox();
            selectRequiredChk.Name = "selectRequiredChk";
            selectRequiredChk.Size = new Size(15, 15);
            selectRequiredChk.Location = new Point(184, 180);
            selectForm.Controls.Add(selectRequiredChk);

            Button selectCancel = new Button();
            selectCancel.Location = new Point(150, 211);
            selectCancel.Size = new Size(50, 23);
            selectCancel.Text = "Cancel";
            selectCancel.Click += new System.EventHandler(this.selectCancel_Click);
            selectForm.Controls.Add(selectCancel);

            Button selectOK = new Button();
            selectOK.Location = new Point(113, 211);
            selectOK.Size = new Size(32, 23);
            selectOK.Text = "OK";
            selectOK.Click += new System.EventHandler(this.selectOK_Click);
            selectForm.Controls.Add(selectOK);
        }
        private void metaBtn_Click(object sender, EventArgs e)
        {
            Form metaForm = new Form();
            metaForm.Size = new Size(227, 196);
            metaForm.StartPosition = FormStartPosition.CenterScreen;
            metaForm.ShowIcon = false;
            metaForm.Text = "meta";
            metaForm.Name = "metaForm";
            metaForm.ShowInTaskbar = false;
            metaForm.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            metaForm.MaximizeBox = false;
            metaForm.Show();

            Label metaCharsetLbl = new Label();
            metaCharsetLbl.Size = new Size(102, 13);
            metaCharsetLbl.Location = new Point(12, 13);
            metaCharsetLbl.Text = "meta charset";
            metaForm.Controls.Add(metaCharsetLbl);

            Label metaContentLbl = new Label();
            metaContentLbl.Size = new Size(80, 13);
            metaContentLbl.Location = new Point(12, 42);
            metaContentLbl.Text = "meta content";
            metaForm.Controls.Add(metaContentLbl);

            Label metaNameLbl = new Label();
            metaNameLbl.Size = new Size(71, 13);
            metaNameLbl.Location = new Point(12, 71);
            metaNameLbl.Text = "meta name";
            metaForm.Controls.Add(metaNameLbl);

            Label metaHTTPEquivLbl = new Label();
            metaHTTPEquivLbl.Size = new Size(90, 13);
            metaHTTPEquivLbl.Location = new Point(12, 100);
            metaHTTPEquivLbl.Text = "meta http";
            metaForm.Controls.Add(metaHTTPEquivLbl);

            TextBox metaCharset = new TextBox();
            metaCharset.Name = "metaCharset";
            metaCharset.Size = new Size(76, 20);
            metaCharset.Location = new Point(122, 10);
            metaCharset.TextChanged += new System.EventHandler(this.metaCharset_TextChanged);
            metaForm.Controls.Add(metaCharset);

            TextBox metaContent = new TextBox();
            metaContent.Name = "metaContent";
            metaContent.Size = new Size(76, 20);
            metaContent.Location = new Point(122, 39);
            metaForm.Controls.Add(metaContent);

            TextBox metaName = new TextBox();
            metaName.Name = "metaName";
            metaName.Size = new Size(76, 20);
            metaName.Location = new Point(122, 68);
            metaName.TextChanged += new System.EventHandler(this.metaName_TextChanged);
            metaForm.Controls.Add(metaName);


            TextBox metaHTTPEquiv = new TextBox();
            metaHTTPEquiv.Name = "metaHTTPEquiv";
            metaHTTPEquiv.Size = new Size(76, 20);
            metaHTTPEquiv.Location = new Point(122, 97);
            metaHTTPEquiv.TextChanged += new System.EventHandler(this.metaHTTPEquiv_TextChanged);
            metaForm.Controls.Add(metaHTTPEquiv);

            Button metaOK = new Button();
            metaOK.Location = new Point(110, 127);
            metaOK.Size = new Size(32, 23);
            metaOK.Text = "OK";
            metaOK.Click += new System.EventHandler(this.metaOK_Click);
            metaForm.Controls.Add(metaOK);

            Button metaCancel = new Button();
            metaCancel.Location = new Point(148, 127);
            metaCancel.Size = new Size(50, 23);
            metaCancel.Text = "Cancel";
            metaCancel.Click += new System.EventHandler(this.metaCancel_Click);
            metaForm.Controls.Add(metaCancel);

        }
        private void fieldsetBtn_Click(object sender, EventArgs e)
        {
            Form fieldsetForm = new Form();
            fieldsetForm.Size = new Size(225, 109);
            fieldsetForm.StartPosition = FormStartPosition.CenterScreen;
            fieldsetForm.ShowIcon = false;
            fieldsetForm.Text = "fieldset";
            fieldsetForm.ShowInTaskbar = false;
            fieldsetForm.Name = "fieldsetForm";
            fieldsetForm.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            fieldsetForm.MaximizeBox = false;
            fieldsetForm.Show();

            Label legendLbl = new Label();
            legendLbl.Size = new Size(40, 13);
            legendLbl.Location = new Point(13, 13);
            legendLbl.Text = "legend";
            fieldsetForm.Controls.Add(legendLbl);

            TextBox legend = new TextBox();
            legend.Name = "legend";
            legend.Size = new Size(143, 20);
            legend.Location = new Point(54, 10);
            fieldsetForm.Controls.Add(legend);

            Button fieldsetOK = new Button();
            fieldsetOK.Text = "OK";
            fieldsetOK.Name = "fieldsetOK";
            fieldsetOK.Size = new Size(47, 23);
            fieldsetOK.Location = new Point(97, 36);
            fieldsetOK.Click += new System.EventHandler(this.fieldsetOK_Click);
            fieldsetForm.Controls.Add(fieldsetOK);

            Button fieldsetCancel = new Button();
            fieldsetCancel.Text = "Cancel";
            fieldsetCancel.Name = "fieldsetCancel";
            fieldsetCancel.Size = new Size(50, 23);
            fieldsetCancel.Location = new Point(148, 36);
            fieldsetCancel.Click += new System.EventHandler(this.fieldsetCancel_Click);
            fieldsetForm.Controls.Add(fieldsetCancel);
        }
        private void datalistBtn_Click(object sender, EventArgs e)
        {
            Form datalistForm = new Form();
            datalistForm.Size = new Size(282, 138);
            datalistForm.StartPosition = FormStartPosition.CenterScreen;
            datalistForm.ShowIcon = false;
            datalistForm.Text = "datalist";
            datalistForm.Name = "datalist";
            datalistForm.ShowInTaskbar = false;
            datalistForm.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            datalistForm.MaximizeBox = false;
            datalistForm.Show();

            Label inputListIDlbl = new Label();
            inputListIDlbl.Size = new Size(73, 13);
            inputListIDlbl.Location = new Point(13, 13);
            inputListIDlbl.Text = "list id";
            datalistForm.Controls.Add(inputListIDlbl);

            TextBox inputListID = new TextBox();
            inputListID.Name = "inputListID";
            inputListID.Size = new Size(90, 20);
            inputListID.Location = new Point(107, 10);
            datalistForm.Controls.Add(inputListID);

            Button addItem = new Button();
            addItem.Text = "+";
            addItem.Name = "addItem";
            addItem.Size = new Size(19, 22);
            addItem.Location = new Point(203, 10);
            addItem.Click += new System.EventHandler(this.addItem_Click);
            datalistForm.Controls.Add(addItem);

            Button removeItem = new Button();
            removeItem.Text = "-";
            removeItem.Name = "removeItem";
            removeItem.Size = new Size(19, 22);
            removeItem.Location = new Point(228, 10);
            removeItem.Click += new System.EventHandler(this.removeItem_Click);
            datalistForm.Controls.Add(removeItem);

            Label optionNameLbl = new Label();
            optionNameLbl.Size = new Size(77, 13);
            optionNameLbl.Location = new Point(13, 39);
            optionNameLbl.Text = "option name";
            optionNameLbl.Name = "optionNameLbl";
            datalistForm.Controls.Add(optionNameLbl);

            TextBox optionName = new TextBox();
            optionName.Name = "optionName";
            optionName.Size = new Size(140, 20);
            optionName.Location = new Point(107, 36);
            datalistForm.Controls.Add(optionName);

            Button datalistOK = new Button();
            datalistOK.Text = "OK";
            datalistOK.Name = "datalistOK";
            datalistOK.Size = new Size(45, 23);
            datalistOK.Location = new Point(150, 62);
            datalistOK.Click += new System.EventHandler(this.datalistOK_Click);
            datalistForm.Controls.Add(datalistOK);

            Button datalistCancel = new Button();
            datalistCancel.Text = "Cancel";
            datalistCancel.Name = "datalistCancel";
            datalistCancel.Size = new Size(50, 23);
            datalistCancel.Location = new Point(200, 62);
            datalistCancel.Click += new System.EventHandler(this.datalistCancel_Click);
            datalistForm.Controls.Add(datalistCancel);
        }
        private void outputBtn_Click(object sender, EventArgs e)
        {
            Form outputForm = new Form();
            outputForm.Size = new Size(228, 137);
            outputForm.StartPosition = FormStartPosition.CenterScreen;
            outputForm.ShowIcon = false;
            outputForm.Text = "output";
            outputForm.Name = "outputForm";
            outputForm.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            outputForm.ShowInTaskbar = false;
            outputForm.MaximizeBox = false;
            outputForm.Show();

            Label outputFormNameLbl = new Label();
            outputFormNameLbl.Size = new Size(70, 13);
            outputFormNameLbl.Location = new Point(13, 13);
            outputFormNameLbl.Text = "output form";
            outputForm.Controls.Add(outputFormNameLbl);

            Label outputNameLbl = new Label();
            outputNameLbl.Size = new Size(70, 13);
            outputNameLbl.Location = new Point(13, 39);
            outputNameLbl.Text = "name";
            outputForm.Controls.Add(outputNameLbl);

            TextBox outputFormNameVal = new TextBox();
            outputFormNameVal.Name = "outputFormNameVal";
            outputFormNameVal.Size = new Size(100, 20);
            outputFormNameVal.Location = new Point(97, 10);
            outputForm.Controls.Add(outputFormNameVal);

            TextBox outputNameVal = new TextBox();
            outputNameVal.Name = "outputNameVal";
            outputNameVal.Size = new Size(100, 20);
            outputNameVal.Location = new Point(97, 36);
            outputForm.Controls.Add(outputNameVal);

            Button outputFormOK = new Button();
            outputFormOK.Text = "OK";
            outputFormOK.Size = new Size(32, 23);
            outputFormOK.Location = new Point(110, 65);
            outputFormOK.Click += new System.EventHandler(this.outputFormOK_Click);
            outputForm.Controls.Add(outputFormOK);

            Button outputFormCancel = new Button();
            outputFormCancel.Text = "Cancel";
            outputFormCancel.Size = new Size(50, 23);
            outputFormCancel.Location = new Point(147, 65);
            outputFormCancel.Click += new System.EventHandler(this.outputFormCancel_Click);
            outputForm.Controls.Add(outputFormCancel);
        }
        private void inputBtn_Click(object sender, EventArgs e)
        {
            Form inputForm = new Form();
            inputForm.Size = new Size(470, 470);
            inputForm.StartPosition = FormStartPosition.CenterScreen;
            inputForm.ShowIcon = false;
            inputForm.Text = "input";
            inputForm.Name = "inputForm";
            inputForm.ShowInTaskbar = false;
            inputForm.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            inputForm.MaximizeBox = false;
            inputForm.Show();

            Label inputName = new Label();
            inputName.Size = new Size(35, 13);
            inputName.Location = new Point(7, 13);
            inputName.Text = "name";
            inputForm.Controls.Add(inputName);

            Label fileType = new Label();
            fileType.Size = new Size(42, 13);
            fileType.Location = new Point(7, 42);
            fileType.Text = "file type";
            inputForm.Controls.Add(fileType);

            TextBox inputNameVal = new TextBox();
            inputNameVal.Name = "inputNameVal";
            inputNameVal.Size = new Size(112, 20);
            inputNameVal.Location = new Point(79, 10);
            inputForm.Controls.Add(inputNameVal);

            TextBox fileTypeVal = new TextBox();
            fileTypeVal.Name = "fileTypeVal";
            fileTypeVal.Size = new Size(112, 20);
            fileTypeVal.Location = new Point(79, 39);
            inputForm.Controls.Add(fileTypeVal);

            GroupBox images = new GroupBox();
            images.Name = "images";
            images.BackColor = Color.Transparent;
            images.Size = new Size(181, 100);
            images.Text = "images";
            images.Location = new Point(10, 64);
            inputForm.Controls.Add(images);

            Label imgFile = new Label();
            imgFile.Size = new Size(26, 13);
            imgFile.Location = new Point(6, 23);
            imgFile.Text = "file";
            images.Controls.Add(imgFile);

            Button inputImgSelect = new Button();
            inputImgSelect.Size = new Size(58, 20);
            inputImgSelect.Location = new Point(9, 40);
            inputImgSelect.Text = "Select";
            inputImgSelect.Click += new System.EventHandler(this.inputImgSelect_Click);
            images.Controls.Add(inputImgSelect);

            TextBox inputImgURL = new TextBox();
            inputImgURL.Name = "inputImgURL";
            inputImgURL.Size = new Size(93, 20);
            inputImgURL.Location = new Point(82, 40);
            images.Controls.Add(inputImgURL);

            Label inputImgAlt = new Label();
            inputImgAlt.Size = new Size(53, 13);
            inputImgAlt.Location = new Point(10, 67);
            inputImgAlt.Text = "image alt";
            images.Controls.Add(inputImgAlt);

            TextBox inputImgAltVal = new TextBox();
            inputImgAltVal.Name = "inputImgAltVal";
            inputImgAltVal.Size = new Size(92, 20);
            inputImgAltVal.Location = new Point(82, 64);
            images.Controls.Add(inputImgAltVal);

            GroupBox inputForms = new GroupBox();
            inputForms.Name = "inputForms";
            inputForms.Size = new Size(229, 151);
            inputForms.Text = "form";
            inputForms.BackColor = Color.Transparent;
            inputForms.Location = new Point(210, 13);
            inputForm.Controls.Add(inputForms);

            Label inputFormID = new Label();
            inputFormID.Size = new Size(77, 13);
            inputFormID.Location = new Point(6, 22);
            inputFormID.Text = "form id";
            inputForms.Controls.Add(inputFormID);

            TextBox inputFormIDVal = new TextBox();
            inputFormIDVal.Name = "inputFormIDVal";
            inputFormIDVal.Size = new Size(88, 20);
            inputFormIDVal.Location = new Point(135, 19);
            inputForms.Controls.Add(inputFormIDVal);

            Label inputFormURL = new Label();
            inputFormURL.Size = new Size(83, 13);
            inputFormURL.Location = new Point(6, 47);
            inputFormURL.Text = "form URL";
            inputForms.Controls.Add(inputFormURL);

            Button inputFormFileSelect = new Button();
            inputFormFileSelect.Size = new Size(64, 23);
            inputFormFileSelect.Location = new Point(9, 61);
            inputFormFileSelect.Text = "Select";
            inputFormFileSelect.Click += new System.EventHandler(this.inputFormFileSelect_Click);
            inputForms.Controls.Add(inputFormFileSelect);

            TextBox inputFormFileURL = new TextBox();
            inputFormFileURL.Name = "inputFormFileURL";
            inputFormFileURL.Size = new Size(88, 20);
            inputFormFileURL.Location = new Point(135, 63);
            inputForms.Controls.Add(inputFormFileURL);

            Label inputFormType = new Label();
            inputFormType.Size = new Size(69, 13);
            inputFormType.Location = new Point(6, 95);
            inputFormType.Text = "form type";
            inputForms.Controls.Add(inputFormType);

            ComboBox inputFormTypeVal = new ComboBox();
            inputFormTypeVal.Name = "inputFormTypes";
            inputFormTypeVal.Size = new Size(88, 21);
            inputFormTypeVal.Location = new Point(135, 92);
            inputFormTypeVal.Items.Add("application/x-www-form-urlencoded");
            inputFormTypeVal.Items.Add("multipart/form-data");
            inputFormTypeVal.Items.Add("text/plain");
            inputForms.Controls.Add(inputFormTypeVal);

            Label inputFormTarget = new Label();
            inputFormTarget.Size = new Size(92, 13);
            inputFormTarget.Location = new Point(6, 119);
            inputFormTarget.Text = "form target";
            inputForms.Controls.Add(inputFormTarget);

            ComboBox inputFormTargetVal = new ComboBox();
            inputFormTargetVal.Name = "inputFormTargetVal";
            inputFormTargetVal.Size = new Size(88, 21);
            inputFormTargetVal.Location = new Point(135, 116);
            inputFormTargetVal.Items.Add("_self");
            inputFormTargetVal.Items.Add("_blank");
            inputFormTargetVal.Items.Add("_parent");
            inputFormTargetVal.Items.Add("_top");
            inputForms.Controls.Add(inputFormTargetVal);

            Label placeholder = new Label();
            placeholder.Size = new Size(70, 13);
            placeholder.Location = new Point(7, 173);
            placeholder.Text = "placeholder";
            inputForm.Controls.Add(placeholder);

            TextBox placeholderVal = new TextBox();
            placeholderVal.Name = "placeholderVal";
            placeholderVal.Size = new Size(90, 20);
            placeholderVal.Location = new Point(101, 170);
            inputForm.Controls.Add(placeholderVal);

            Label inputSize = new Label();
            inputSize.Size = new Size(87, 13);
            inputSize.Location = new Point(7, 199);
            inputSize.Text = "input size";
            inputForm.Controls.Add(inputSize);

            NumericUpDown inputSizeVal = new NumericUpDown();
            inputSizeVal.Name = "inputSizeVal";
            inputSizeVal.Size = new Size(41, 20);
            inputSizeVal.Location = new Point(150, 197);
            inputSizeVal.Maximum = 1000;
            inputForm.Controls.Add(inputSizeVal);

            Label MaxSymbols = new Label();
            MaxSymbols.Size = new Size(130, 13);
            MaxSymbols.Location = new Point(7, 229);
            MaxSymbols.Text = "maximum symbols";
            inputForm.Controls.Add(MaxSymbols);

            NumericUpDown MaxSymbolsVal = new NumericUpDown();
            MaxSymbolsVal.Name = "MaxSymbolsVal";
            MaxSymbolsVal.Size = new Size(41, 20);
            MaxSymbolsVal.Location = new Point(150, 227);
            MaxSymbolsVal.Maximum = 1000;
            inputForm.Controls.Add(MaxSymbolsVal);

            Label inputValText = new Label();
            inputValText.Size = new Size(88, 13);
            inputValText.Location = new Point(7, 260);
            inputValText.Text = "value";
            inputForm.Controls.Add(inputValText);

            TextBox inputVal = new TextBox();
            inputVal.Name = "inputVal";
            inputVal.Size = new Size(90, 20);
            inputVal.Location = new Point(101, 257);
            inputForm.Controls.Add(inputVal);

            Label inputAutofocusLbl = new Label();
            inputAutofocusLbl.Size = new Size(55, 13);
            inputAutofocusLbl.Location = new Point(7, 291);
            inputAutofocusLbl.Text = "autofocus";
            inputForm.Controls.Add(inputAutofocusLbl);

            CheckBox inputAutofocus = new CheckBox();
            inputAutofocus.Name = "inputAutofocus";
            inputAutofocus.Size = new Size(15, 15);
            inputAutofocus.Location = new Point(176, 291);
            inputForm.Controls.Add(inputAutofocus);

            Label inputCheckedLbl = new Label();
            inputCheckedLbl.Size = new Size(66, 13);
            inputCheckedLbl.Location = new Point(7, 317);
            inputCheckedLbl.Text = "checked";
            inputForm.Controls.Add(inputCheckedLbl);

            CheckBox inputChecked = new CheckBox();
            inputChecked.Name = "inputChecked";
            inputChecked.Size = new Size(15, 15);
            inputChecked.Location = new Point(176, 317);
            inputForm.Controls.Add(inputChecked);

            Label inputMultipleLbl = new Label();
            inputMultipleLbl.Size = new Size(65, 13);
            inputMultipleLbl.Location = new Point(7, 344);
            inputMultipleLbl.Text = "multiple";
            inputForm.Controls.Add(inputMultipleLbl);

            CheckBox inputMultiple = new CheckBox();
            inputMultiple.Name = "inputMultiple";
            inputMultiple.Size = new Size(15, 15);
            inputMultiple.Location = new Point(176, 344);
            inputForm.Controls.Add(inputMultiple);

            Label inputRequiredLbl = new Label();
            inputRequiredLbl.Size = new Size(100, 13);
            inputRequiredLbl.Location = new Point(7, 369);
            inputRequiredLbl.Text = "required";
            inputForm.Controls.Add(inputRequiredLbl);

            CheckBox inputRequired = new CheckBox();
            inputRequired.Name = "inputRequired";
            inputRequired.Size = new Size(15, 15);
            inputRequired.Location = new Point(176, 369);
            inputForm.Controls.Add(inputRequired);

            Label inputListLbl = new Label();
            inputListLbl.Size = new Size(35, 13);
            inputListLbl.Location = new Point(207, 173);
            inputListLbl.Text = "list";
            inputForm.Controls.Add(inputListLbl);

            TextBox inputListName = new TextBox();
            inputListName.Name = "inputListName";
            inputListName.Size = new Size(90, 20);
            inputListName.Location = new Point(349, 170);
            inputForm.Controls.Add(inputListName);

            Label inputQueryTypeLbl = new Label();
            inputQueryTypeLbl.Size = new Size(88, 13);
            inputQueryTypeLbl.Location = new Point(207, 199);
            inputQueryTypeLbl.Text = "input query";
            inputForm.Controls.Add(inputQueryTypeLbl);

            ComboBox inputQueryType = new ComboBox();
            inputQueryType.Name = "inputQueryType";
            inputQueryType.Size = new Size(90, 21);
            inputQueryType.Location = new Point(349, 196);
            inputQueryType.Items.Add("get");
            inputQueryType.Items.Add("post");
            inputForm.Controls.Add(inputQueryType);

            Label inputTemplateLbl = new Label();
            inputTemplateLbl.Size = new Size(48, 13);
            inputTemplateLbl.Location = new Point(207, 229);
            inputTemplateLbl.Text = "template";
            inputForm.Controls.Add(inputTemplateLbl);

            TextBox inputTemplate = new TextBox();
            inputTemplate.Name = "inputTemplate";
            inputTemplate.Size = new Size(90, 20);
            inputTemplate.Location = new Point(349, 226);
            inputForm.Controls.Add(inputTemplate);

            Label inputTypeLbl = new Label();
            inputTypeLbl.Size = new Size(69, 13);
            inputTypeLbl.Location = new Point(207, 260);
            inputTypeLbl.Text = "input type";
            inputForm.Controls.Add(inputTypeLbl);

            ComboBox inputType = new ComboBox();
            inputType.Name = "inputType";
            inputType.Size = new Size(90, 21);
            inputType.Location = new Point(349, 257);
            inputType.Items.Add("button");
            inputType.Items.Add("checkbox");
            inputType.Items.Add("file");
            inputType.Items.Add("hidden");
            inputType.Items.Add("image");
            inputType.Items.Add("password");
            inputType.Items.Add("radio");
            inputType.Items.Add("reset");
            inputType.Items.Add("submit");
            inputType.Items.Add("text");
            inputType.Items.Add("color");
            inputType.Items.Add("date");
            inputType.Items.Add("datetime");
            inputType.Items.Add("email");
            inputType.Items.Add("number");
            inputType.Items.Add("range");
            inputType.Items.Add("search");
            inputType.Items.Add("tel");
            inputType.Items.Add("time");
            inputType.Items.Add("url");
            inputType.Items.Add("month");
            inputType.Items.Add("week");
            inputForm.Controls.Add(inputType);

            Label inputFormNoValidateLbl = new Label();
            inputFormNoValidateLbl.Size = new Size(123, 13);
            inputFormNoValidateLbl.Location = new Point(207, 291);
            inputFormNoValidateLbl.Text = "form novalidate";
            inputForm.Controls.Add(inputFormNoValidateLbl);

            CheckBox inputFormNoValidate = new CheckBox();
            inputFormNoValidate.Name = "inputFormNoValidate";
            inputFormNoValidate.Size = new Size(15, 15);
            inputFormNoValidate.Location = new Point(424, 291);
            inputForm.Controls.Add(inputFormNoValidate);

            Label inputFormDisabledLbl = new Label();
            inputFormDisabledLbl.Size = new Size(55, 13);
            inputFormDisabledLbl.Location = new Point(207, 317);
            inputFormDisabledLbl.Text = "disabled";
            inputForm.Controls.Add(inputFormDisabledLbl);

            CheckBox inputFormDisabled = new CheckBox();
            inputFormDisabled.Name = "inputFormDisabled";
            inputFormDisabled.Size = new Size(15, 15);
            inputFormDisabled.Location = new Point(424, 317);
            inputForm.Controls.Add(inputFormDisabled);

            Label inputReadOnlyLbl = new Label();
            inputReadOnlyLbl.Size = new Size(78, 13);
            inputReadOnlyLbl.Location = new Point(206, 344);
            inputReadOnlyLbl.Text = "read-only";
            inputForm.Controls.Add(inputReadOnlyLbl);

            CheckBox inputReadOnly = new CheckBox();
            inputReadOnly.Name = "inputReadOnly";
            inputReadOnly.Size = new Size(15, 15);
            inputReadOnly.Location = new Point(424, 344);
            inputForm.Controls.Add(inputReadOnly);

            Label inputAutocompleteLbl = new Label();
            inputAutocompleteLbl.Size = new Size(112, 13);
            inputAutocompleteLbl.Location = new Point(207, 369);
            inputAutocompleteLbl.Text = "autocomplete";
            inputForm.Controls.Add(inputAutocompleteLbl);

            CheckBox inputAutoComplete = new CheckBox();
            inputAutoComplete.Name = "inputAutoComplete";
            inputAutoComplete.Size = new Size(15, 15);
            inputAutoComplete.Location = new Point(424, 369);
            inputForm.Controls.Add(inputAutoComplete);

            Button inputOK = new Button();
            inputOK.Size = new Size(54, 23);
            inputOK.Location = new Point(320, 398);
            inputOK.Text = "OK";
            inputForm.Controls.Add(inputOK);
            inputOK.Click += new System.EventHandler(this.inputOK_Click);

            Button inputCancel = new Button();
            inputCancel.Size = new Size(59, 23);
            inputCancel.Location = new Point(380, 398);
            inputCancel.Text = "Cancel";
            inputForm.Controls.Add(inputCancel);
            inputCancel.Click += new System.EventHandler(this.inputCancel_Click);
        }
        private void bdo_Click(object sender, EventArgs e)
        {
            Form bdoForm = new Form();
            bdoForm.Size = new Size(339, 175);
            bdoForm.StartPosition = FormStartPosition.CenterScreen;
            bdoForm.ShowIcon = false;
            bdoForm.Text = "bdo";
            bdoForm.Name = "bdoForm";
            bdoForm.ShowInTaskbar = false;
            bdoForm.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            bdoForm.MaximizeBox = false;
            bdoForm.Show();

            Label bdoName = new Label();
            bdoName.Text = "direction";
            bdoName.Size = new Size(97, 13);
            bdoName.Location = new Point(8, 9);
            bdoForm.Controls.Add(bdoName);

            RichTextBox text = new RichTextBox();
            text.Name = "text";
            text.Size = new Size(209, 67);
            text.Location = new Point(102, 33);
            bdoForm.Controls.Add(text);


            RadioButton rtl = new RadioButton();
            rtl.Name = "rtl";
            rtl.Text = "rtl";
            rtl.Location = new Point(9, 44);
            rtl.Size = new Size(88, 17);
            bdoForm.Controls.Add(rtl);

            RadioButton ltr = new RadioButton();
            ltr.Name = "ltr";
            ltr.Text = "ltr";
            ltr.Location = new Point(9, 73);
            ltr.Size = new Size(88, 17);
            bdoForm.Controls.Add(ltr);

            Label editableText = new Label();
            editableText.Size = new Size(31, 13);
            editableText.Location = new Point(280, 9);
            editableText.Text = "text";
            bdoForm.Controls.Add(editableText);

            Button bdoOK = new Button();
            bdoOK.Text = "OK";
            bdoOK.Size = new Size(75, 23);
            bdoOK.Location = new Point(236, 106);
            bdoForm.Controls.Add(bdoOK);
            bdoOK.Click += new System.EventHandler(this.bdoOK_Click);
        }
        private void video_Click(object sender, EventArgs e)
        {
            Form videoForm = new Form();
            videoForm.Size = new Size(490, 312);
            videoForm.StartPosition = FormStartPosition.CenterScreen;
            videoForm.ShowIcon = false;
            videoForm.Text = "video";
            videoForm.Name = "VideoForm";
            videoForm.ShowInTaskbar = false;
            videoForm.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            videoForm.MaximizeBox = false;
            videoForm.Show();

            Label autostartLabel = new Label();
            autostartLabel.Size = new Size(101, 13);
            autostartLabel.Location = new Point(12, 9);
            autostartLabel.Text = "autostart";
            videoForm.Controls.Add(autostartLabel);

            CheckBox autoStart = new CheckBox();
            autoStart.Name = "autoStart";
            autoStart.Text = "";
            autoStart.Location = new Point(218, 9);
            autoStart.Size = new Size(15, 14);
            videoForm.Controls.Add(autoStart);

            Label videoWidth = new Label();
            videoWidth.Size = new Size(69, 13);
            videoWidth.Location = new Point(13, 41);
            videoWidth.Text = "height";
            videoForm.Controls.Add(videoWidth);

            TrackBar videoWidthVal = new TrackBar();
            videoWidthVal.TickFrequency = 1;
            videoWidthVal.TickStyle = TickStyle.None;
            videoWidthVal.Minimum = 0;
            videoWidthVal.Maximum = 1000;
            videoWidthVal.Location = new Point(145, 38);
            videoWidthVal.Size = new Size(90, 25);
            videoWidthVal.AutoSize = false;
            videoWidthVal.Name = "videoWidthVal";
            videoWidthVal.Scroll += new System.EventHandler(this.videoWidthVal_Scroll);
            videoForm.Controls.Add(videoWidthVal);

            TextBox videoWidthTxtVal = new TextBox();
            videoWidthTxtVal.Name = "videoWidthTxtVal";
            videoWidthTxtVal.Size = new Size(44, 20);
            videoWidthTxtVal.Location = new Point(88, 38);
            videoWidthTxtVal.ReadOnly = true;
            videoWidthTxtVal.TextAlign = HorizontalAlignment.Center;
            videoForm.Controls.Add(videoWidthTxtVal);

            Label videoHeight = new Label();
            videoHeight.Size = new Size(59, 13);
            videoHeight.Location = new Point(12, 69);
            videoHeight.Text = "width";
            videoForm.Controls.Add(videoHeight);

            TrackBar videoHeightVal = new TrackBar();
            videoHeightVal.TickFrequency = 1;
            videoHeightVal.TickStyle = TickStyle.None;
            videoHeightVal.Minimum = 0;
            videoHeightVal.Maximum = 1000;
            videoHeightVal.Location = new Point(145, 68);
            videoHeightVal.Size = new Size(90, 25);
            videoHeightVal.Name = "videoHeightVal";
            videoHeightVal.AutoSize = false;
            videoHeightVal.Scroll += new System.EventHandler(this.videoHeightVal_Scroll);
            videoForm.Controls.Add(videoHeightVal);

            TextBox videoHeightTxtVal = new TextBox();
            videoHeightTxtVal.Name = "videoHeightTxtVal";
            videoHeightTxtVal.Size = new Size(44, 20);
            videoHeightTxtVal.Location = new Point(88, 66);
            videoHeightTxtVal.ReadOnly = true;
            videoHeightTxtVal.TextAlign = HorizontalAlignment.Center;
            videoForm.Controls.Add(videoHeightTxtVal);

            Label repeat = new Label();
            repeat.Size = new Size(38, 13);
            repeat.Location = new Point(13, 103);
            repeat.Text = "repeat";
            videoForm.Controls.Add(repeat);

            CheckBox repeatCheck = new CheckBox();
            repeatCheck.Size = new Size(15, 14);
            repeatCheck.Location = new Point(218, 103);
            repeatCheck.Name = "repeatCheck";
            videoForm.Controls.Add(repeatCheck);

            Label videoPrototype = new Label();
            videoPrototype.Size = new Size(170, 13);
            videoPrototype.Location = new Point(275, 9);
            videoPrototype.Text = "preview prototype";
            videoForm.Controls.Add(videoPrototype);

            Label poster = new Label();
            poster.Size = new Size(40, 13);
            poster.Location = new Point(12, 130);
            poster.Text = "poster";
            videoForm.Controls.Add(poster);

            Button posterSelect = new Button();
            posterSelect.Size = new Size(45, 23);
            posterSelect.Location = new Point(12, 147);
            posterSelect.Text = "Select";
            posterSelect.Click += new System.EventHandler(this.posterSelect_Click);
            videoForm.Controls.Add(posterSelect);

            TextBox posterURL = new TextBox();
            posterURL.Name = "posterURL";
            posterURL.Size = new Size(173, 20);
            posterURL.Location = new Point(60, 149);
            videoForm.Controls.Add(posterURL);

            Label video = new Label();
            video.Text = "file";
            video.Location = new Point(13, 185);
            video.Size = new Size(28, 13);
            videoForm.Controls.Add(video);

            RichTextBox videoURL = new RichTextBox();
            videoURL.Name = "videoURL";
            videoURL.Size = new Size(173, 20);
            videoURL.Location = new Point(60, 204);
            videoForm.Controls.Add(videoURL);

            Button videoSelect = new Button();
            videoSelect.Text = "Select";
            videoSelect.Size = new Size(45, 23);
            videoSelect.Location = new Point(12, 203);
            videoForm.Controls.Add(videoSelect);
            videoSelect.Click += new System.EventHandler(this.videoSelect_Click);

            Button videoOK = new Button();
            videoOK.Size = new Size(34, 23);
            videoOK.Location = new Point(374, 238);
            videoOK.Text = "OK";
            videoForm.Controls.Add(videoOK);
            videoOK.Click += new System.EventHandler(this.videoOK_Click);

            Button videoCancel = new Button();
            videoCancel.Size = new Size(48, 23);
            videoCancel.Location = new Point(410, 238);
            videoCancel.Text = "Cancel";
            videoForm.Controls.Add(videoCancel);
            videoCancel.Click += new System.EventHandler(this.videoCancel_Click);


            FlowLayoutPanel videoPrototypeObj = new FlowLayoutPanel();
            videoPrototypeObj.Name = "videoPrototypeObj";
            videoPrototypeObj.Size = new Size(218, 198);
            videoPrototypeObj.BorderStyle = BorderStyle.FixedSingle;
            videoPrototypeObj.Location = new Point(239, 34);
            videoPrototypeObj.Paint += new PaintEventHandler(this.videoPrototype_Paint);
            videoForm.Controls.Add(videoPrototypeObj);
        }
        private void hiddenText_Click(object sender, EventArgs e)
        {
            Form hiddenText = new Form();
            hiddenText.Size = new Size(215, 328);
            hiddenText.StartPosition = FormStartPosition.CenterScreen;
            hiddenText.ShowIcon = false;
            hiddenText.Text = "hidden text";
            hiddenText.Name = "hiddenText";
            hiddenText.ShowInTaskbar = false;
            hiddenText.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            hiddenText.MaximizeBox = false;
            hiddenText.Show();

            Label textLbl = new Label();
            textLbl.Size = new Size(77, 13);
            textLbl.Location = new Point(9, 9);
            textLbl.Text = "text label";
            hiddenText.Controls.Add(textLbl);

            TextBox hiddenName = new TextBox();
            hiddenName.Size = new Size(175, 22);
            hiddenName.Location = new Point(12, 25);
            hiddenName.TextAlign = HorizontalAlignment.Center;
            hiddenName.Name = "hiddenName";
            hiddenText.Controls.Add(hiddenName);

            Label hiddenTextLbl = new Label();
            hiddenTextLbl.Size = new Size(87, 13);
            hiddenTextLbl.Location = new Point(9, 55);
            hiddenTextLbl.Text = "hidden text";
            hiddenText.Controls.Add(hiddenTextLbl);

            RichTextBox hiddenTextVal = new RichTextBox();
            hiddenTextVal.Location = new Point(12, 71);
            hiddenTextVal.Size = new Size(175, 179);
            hiddenTextVal.Name = "hiddenTextVal";
            hiddenText.Controls.Add(hiddenTextVal);

            Button hiddenOK = new Button();
            hiddenOK.Text = "OK";
            hiddenOK.Size = new Size(32, 23);
            hiddenOK.Location = new Point(104, 256);
            hiddenText.Controls.Add(hiddenOK);
            hiddenOK.Click += new System.EventHandler(this.hiddenOK_Click);

            Button hiddenCancel = new Button();
            hiddenCancel.Text = "Cancel";
            hiddenCancel.Size = new Size(50, 23);
            hiddenCancel.Location = new Point(136, 256);
            hiddenText.Controls.Add(hiddenCancel);
            hiddenCancel.Click += new System.EventHandler(this.hiddenCancel_Click);
        }
        private void baseButton_Click(object sender, EventArgs e)
        {
            Form baseForm = new Form();
            baseForm.Size = new Size(339, 128);
            baseForm.Text = "base";
            baseForm.MaximizeBox = false;
            baseForm.ShowIcon = false;
            baseForm.ShowInTaskbar = false;
            baseForm.StartPosition = FormStartPosition.CenterScreen;
            baseForm.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            baseForm.Name = "baseForm";
            baseForm.Show();

            Label baseLabel = new Label();
            baseLabel.Size = new Size(101, 13);
            baseLabel.Location = new Point(8, 9);
            baseLabel.Text = "base link";
            baseForm.Controls.Add(baseLabel);

            TextBox baseVal = new TextBox();
            baseVal.Name = "baseVal";
            baseVal.Size = new Size(300, 22);
            baseVal.Location = new Point(12, 25);
            baseForm.Controls.Add(baseVal);

            Button OKBaseBtn = new Button();
            OKBaseBtn.Text = "OK";
            OKBaseBtn.Size = new Size(38, 23);
            OKBaseBtn.Location = new Point(219, 53);
            OKBaseBtn.Click += new System.EventHandler(this.OKBaseBtn_Click);
            baseForm.Controls.Add(OKBaseBtn);

            Button CancelBaseBtn = new Button();
            CancelBaseBtn.Text = "Cancel";
            CancelBaseBtn.Size = new Size(48, 23);
            CancelBaseBtn.Location = new Point(265, 53);
            CancelBaseBtn.Click += new System.EventHandler(this.CancelBaseBtn_Click);
            baseForm.Controls.Add(CancelBaseBtn);
        }
        private void btn_Click(object sender, EventArgs e)
        {
            Form btnFrm = new Form();
            btnFrm.Size = new Size(260, 414);
            btnFrm.Text = "button";
            btnFrm.MaximizeBox = false;
            btnFrm.ShowIcon = false;
            btnFrm.ShowInTaskbar = false;
            btnFrm.StartPosition = FormStartPosition.CenterScreen;
            btnFrm.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            btnFrm.Name = "btnFrm";
            btnFrm.Show();

            Label btnName = new Label();
            btnName.Text = "button name";
            btnName.Size = new Size(78, 13);
            btnName.Location = new Point(12, 9);
            btnFrm.Controls.Add(btnName);

            TextBox btnNameVal = new TextBox();
            btnNameVal.Size = new Size(68, 22);
            btnNameVal.Location = new Point(158, 6);
            btnNameVal.Name = "btnNameVal";
            btnNameVal.TextAlign = HorizontalAlignment.Center;
            btnFrm.Controls.Add(btnNameVal);

            Label autoFocus = new Label();
            autoFocus.Size = new Size(59, 13);
            autoFocus.Location = new Point(12, 35);
            autoFocus.Text = "autofocus";
            btnFrm.Controls.Add(autoFocus);

            CheckBox autoFocusCheck = new CheckBox();
            autoFocusCheck.Location = new Point(211, 34);
            autoFocusCheck.Size = new Size(15, 15);
            autoFocusCheck.Name = "autoFocusCheck";
            btnFrm.Controls.Add(autoFocusCheck);

            Label disabled = new Label();
            disabled.Size = new Size(60, 13);
            disabled.Location = new Point(12, 61);
            disabled.Text = "disabled";
            btnFrm.Controls.Add(disabled);

            CheckBox disabledCheck = new CheckBox();
            disabledCheck.Location = new Point(211, 60);
            disabledCheck.Size = new Size(15, 15);
            disabledCheck.Name = "disabledCheck";
            btnFrm.Controls.Add(disabledCheck);

            TextBox formIDVal = new TextBox();
            formIDVal.Name = "formIDVal";
            formIDVal.Size = new Size(68, 22);
            formIDVal.TextAlign = HorizontalAlignment.Center;
            formIDVal.Location = new Point(158, 85);
            btnFrm.Controls.Add(formIDVal);

            Label formID = new Label();
            formID.Size = new Size(85, 13);
            formID.Location = new Point(12, 88);
            formID.Text = "form ID";
            btnFrm.Controls.Add(formID);

            Label formURL = new Label();
            formURL.Size = new Size(89, 13);
            formURL.Location = new Point(12, 115);
            formURL.Text = "form URL";
            btnFrm.Controls.Add(formURL);

            TextBox formURLVal = new TextBox();
            formURLVal.Name = "formURLVal";
            formURLVal.Size = new Size(68, 22);
            formURLVal.Location = new Point(158, 112);
            btnFrm.Controls.Add(formURLVal);

            Button selectURL = new Button();
            selectURL.Text = "Select";
            selectURL.Size = new Size(51, 23);
            selectURL.Location = new Point(103, 110);
            selectURL.Click += new EventHandler(this.selectURL_Click);
            btnFrm.Controls.Add(selectURL);

            Label formType = new Label();
            formType.Location = new Point(12, 142);
            formType.Size = new Size(79, 13);
            formType.Text = "form type";
            btnFrm.Controls.Add(formType);

            RadioButton applicationFrm = new RadioButton();
            applicationFrm.Name = "application";
            applicationFrm.Size = new Size(83, 17);
            applicationFrm.Location = new Point(14, 159);
            applicationFrm.Text = "application";
            btnFrm.Controls.Add(applicationFrm);

            RadioButton multipartFrm = new RadioButton();
            multipartFrm.Name = "multipart";
            multipartFrm.Size = new Size(79, 17);
            multipartFrm.Location = new Point(103, 159);
            multipartFrm.Text = "multipart";
            btnFrm.Controls.Add(multipartFrm);

            RadioButton textFrm = new RadioButton();
            textFrm.Name = "text";
            textFrm.Size = new Size(44, 17);
            textFrm.Location = new Point(182, 159);
            textFrm.Text = "text";
            btnFrm.Controls.Add(textFrm);

            Label formmethod = new Label();
            formmethod.Text = "form method";
            formmethod.Size = new Size(135, 13);
            formmethod.Location = new Point(12, 189);
            btnFrm.Controls.Add(formmethod);

            ComboBox formmethodVal = new ComboBox();
            formmethodVal.Location = new Point(159, 186);
            formmethodVal.Size = new Size(67, 21);
            formmethodVal.Name = "formmethodVal";
            formmethodVal.Items.Add("get");
            formmethodVal.Items.Add("post");
            btnFrm.Controls.Add(formmethodVal);

            Label formnovalidate = new Label();
            formnovalidate.Text = "form no-validate";
            formnovalidate.Size = new Size(127, 13);
            formnovalidate.Location = new Point(12, 216);
            btnFrm.Controls.Add(formnovalidate);

            CheckBox formnovalidateVal = new CheckBox();
            formnovalidateVal.Location = new Point(211, 216);
            formnovalidateVal.Size = new Size(15, 15);
            formnovalidateVal.Name = "formnovalidateVal";
            btnFrm.Controls.Add(formnovalidateVal);

            Label value = new Label();
            value.Size = new Size(41, 13);
            value.Location = new Point(12, 242);
            value.Text = "value";
            btnFrm.Controls.Add(value);

            TextBox valueVal = new TextBox();
            valueVal.Name = "valueVal";
            valueVal.Location = new Point(158, 239);
            valueVal.Size = new Size(68, 21);
            btnFrm.Controls.Add(valueVal);
            valueVal.TextAlign = HorizontalAlignment.Center;

            Label btnType = new Label();
            btnType.Size = new Size(70, 13);
            btnType.Location = new Point(11, 274);
            btnType.Text = "button type";
            btnFrm.Controls.Add(btnType);

            ComboBox btnTypeVal = new ComboBox();
            btnTypeVal.Location = new Point(159, 271);
            btnTypeVal.Size = new Size(67, 21);
            btnTypeVal.Name = "btnTypeVal";
            btnTypeVal.Items.Add("button");
            btnTypeVal.Items.Add("reset");
            btnTypeVal.Items.Add("submit");
            btnFrm.Controls.Add(btnTypeVal);

            Label formtarget = new Label();
            formtarget.Size = new Size(115, 13);
            formtarget.Location = new Point(11, 306);
            formtarget.Text = "form target";
            btnFrm.Controls.Add(formtarget);

            ComboBox formtargetVal = new ComboBox();
            formtargetVal.Size = new Size(67, 20);
            formtargetVal.Name = "formtargetVal";
            formtargetVal.Location = new Point(158, 303);
            formtargetVal.Items.Add("_blank");
            formtargetVal.Items.Add("_self");
            formtargetVal.Items.Add("_parent");
            formtargetVal.Items.Add("_top");
            btnFrm.Controls.Add(formtargetVal);

            Button btnFrmOk = new Button();
            btnFrmOk.Location = new Point(140, 340);
            btnFrmOk.Size = new Size(32, 23);
            btnFrmOk.Text = "OK";
            btnFrmOk.Click += new System.EventHandler(this.btnFrmOk_Click);
            btnFrm.Controls.Add(btnFrmOk);

            Button btnFrmCancel = new Button();
            btnFrmCancel.Location = new Point(172, 340);
            btnFrmCancel.Size = new Size(50, 23);
            btnFrmCancel.Text = "Cancel";
            btnFrmCancel.Click += new System.EventHandler(this.btnFrmCancel_Click);
            btnFrm.Controls.Add(btnFrmCancel);
        }
        private void textShadow_Click(object sender, EventArgs e)
        {
            Form textShadow = new Form();
            textShadow.Size = new Size(280, 250);
            textShadow.Name = "txtShadow";
            textShadow.Text = "text-shadow";
            textShadow.ShowInTaskbar = false;
            textShadow.MaximizeBox = false;
            textShadow.ShowIcon = false;
            textShadow.StartPosition = FormStartPosition.CenterScreen;
            textShadow.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            textShadow.Show();

            Label shadowColor = new Label();
            shadowColor.Text = "shadow color";
            shadowColor.Size = new Size(85, 13);
            shadowColor.Location = new Point(13, 13);
            textShadow.Controls.Add(shadowColor);

            Button colorSelect = new Button();
            colorSelect.Text = "Select";
            colorSelect.Size = new Size(75, 23);
            colorSelect.Location = new Point(16, 29);
            textShadow.Controls.Add(colorSelect);
            colorSelect.Visible = true;
            colorSelect.Click += new System.EventHandler(this.colorSelect_Click);

            TextBox colorVal = new TextBox();
            colorVal.Size = new Size(100, 22);
            colorVal.Location = new Point(144, 29);
            colorVal.Name = "colorVal";
            textShadow.Controls.Add(colorVal);
            colorVal.TextAlign = HorizontalAlignment.Center;

            Label shadowX = new Label();
            shadowX.Text = "shadow X";
            shadowX.Size = new Size(154, 13);
            shadowX.Location = new Point(13, 70);
            textShadow.Controls.Add(shadowX);

            NumericUpDown shadowXVal = new NumericUpDown();
            shadowXVal.Name = "shadowXVal";
            shadowXVal.Location = new Point(195, 68);
            shadowXVal.Size = new Size(49, 22);
            shadowXVal.TextAlign = HorizontalAlignment.Center;
            textShadow.Controls.Add(shadowXVal);

            Label shadowY = new Label();
            shadowY.Text = "shadow Y";
            shadowY.Size = new Size(153, 13);
            shadowY.Location = new Point(13, 104);
            textShadow.Controls.Add(shadowY);

            NumericUpDown shadowYVal = new NumericUpDown();
            shadowYVal.Name = "shadowYVal";
            shadowYVal.Location = new Point(195, 102);
            shadowYVal.Size = new Size(49, 22);
            shadowYVal.TextAlign = HorizontalAlignment.Center;
            textShadow.Controls.Add(shadowYVal);

            Label radius = new Label();
            radius.Text = "shadow radius";
            radius.Size = new Size(143, 13);
            radius.Location = new Point(13, 138);
            textShadow.Controls.Add(radius);

            NumericUpDown radiusVal = new NumericUpDown();
            radiusVal.Name = "radiusVal";
            radiusVal.Location = new Point(195, 136);
            radiusVal.Size = new Size(49, 22);
            radiusVal.TextAlign = HorizontalAlignment.Center;
            textShadow.Controls.Add(radiusVal);

            Button textShadowOK = new Button();
            textShadowOK.Text = "OK";
            textShadowOK.Size = new Size(32, 23);
            textShadowOK.Location = new Point(152, 176);
            textShadowOK.Click += new System.EventHandler(this.textShadowOK_Click);
            textShadow.Controls.Add(textShadowOK);

            Button textShadowCancel = new Button();
            textShadowCancel.Text = "Cancel";
            textShadowCancel.Size = new Size(52, 23);
            textShadowCancel.Location = new Point(193, 176);
            textShadowCancel.Click += new System.EventHandler(this.textShadowCancel_Click);
            textShadow.Controls.Add(textShadowCancel);
        }
        private void textTransform_Click(object sender, EventArgs e)
        {
            Form textTransformForm = new Form();
            textTransformForm.Name = "textTransform";
            textTransformForm.Text = "text transform";
            textTransformForm.MaximizeBox = false;
            textTransformForm.StartPosition = FormStartPosition.CenterScreen;
            textTransformForm.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            textTransformForm.ShowIcon = false;
            textTransformForm.ShowInTaskbar = false;
            textTransformForm.Size = new Size(198, 143);
            textTransformForm.Show();

            Label transformEffect = new Label();
            transformEffect.Size = new Size(55, 13);
            transformEffect.Location = new Point(11, 9);
            transformEffect.Text = "effect";
            textTransformForm.Controls.Add(transformEffect);

            RadioButton capitalize = new RadioButton();
            capitalize.Name = "capitalize";
            capitalize.Text = "Text";
            capitalize.Size = new Size(64, 17);
            capitalize.Location = new Point(14, 30);
            textTransformForm.Controls.Add(capitalize);

            RadioButton lowercase = new RadioButton();
            lowercase.Name = "lowercase";
            lowercase.Text = "text";
            lowercase.Size = new Size(60, 17);
            lowercase.Location = new Point(113, 30);
            textTransformForm.Controls.Add(lowercase);

            RadioButton uppercase = new RadioButton();
            uppercase.Name = "uppercase";
            uppercase.Text = "TEXT";
            uppercase.Size = new Size(78, 17);
            uppercase.Location = new Point(14, 53);
            textTransformForm.Controls.Add(uppercase);

            RadioButton none = new RadioButton();
            none.Name = "none";
            none.Text = "text";
            none.Location = new Point(113, 53);
            none.Size = new Size(78, 17);
            textTransformForm.Controls.Add(none);

            Button textTransformOK = new Button();
            textTransformOK.Text = "OK";
            textTransformOK.Location = new Point(76, 76);
            textTransformOK.Size = new Size(32, 23);
            textTransformOK.Click += new System.EventHandler(this.textTransformOK_Click);
            textTransformForm.Controls.Add(textTransformOK);

            Button textTransformCancel = new Button();
            textTransformCancel.Text = "Cancel";
            textTransformCancel.Location = new Point(118, 76);
            textTransformCancel.Size = new Size(52, 23);
            textTransformCancel.Click += new System.EventHandler(this.textTransformCancel_Click);
            textTransformForm.Controls.Add(textTransformCancel);
        }
        private void opacity_Click(object sender, EventArgs e)
        {
            Form opacityForm = new Form();
            opacityForm.Name = "opacityForm";
            opacityForm.Text = "opacity";
            opacityForm.Size = new Size(184, 226);
            opacityForm.MaximizeBox = false;
            opacityForm.ShowInTaskbar = false;
            opacityForm.StartPosition = FormStartPosition.CenterScreen;
            opacityForm.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            opacityForm.ShowIcon = false;
            opacityForm.Show();

            Label opacityText = new Label();
            opacityText.Size = new Size(106, 13);
            opacityText.Location = new Point(16, 9);
            opacityText.Text = "element opacity";
            opacityForm.Controls.Add(opacityText);

            TrackBar opacityTrck = new TrackBar();
            opacityTrck.Name = "opacityTrck";
            opacityTrck.Location = new Point(16, 25);
            opacityTrck.Size = new Size(104, 25);
            opacityTrck.AutoSize = false;
            opacityTrck.TickStyle = TickStyle.None;
            opacityTrck.Maximum = 10;
            opacityTrck.Minimum = 0;
            opacityTrck.Value = 10;
            opacityTrck.RightToLeft = RightToLeft.Yes;
            opacityTrck.TickFrequency = 1;
            opacityForm.Controls.Add(opacityTrck);
            opacityTrck.Scroll += new System.EventHandler(this.opacityTrck_Scroll);

            TextBox opacityVal = new TextBox();
            opacityVal.Size = new Size(24, 22);
            opacityVal.Location = new Point(126, 25);
            opacityVal.Name = "opacityVal";
            opacityForm.Controls.Add(opacityVal);

            FlowLayoutPanel opacityView = new FlowLayoutPanel();
            opacityView.Name = "opacityView";
            opacityView.BorderStyle = BorderStyle.FixedSingle;
            opacityView.Size = new Size(134, 100);
            opacityView.Location = new Point(16, 53);
            opacityForm.Controls.Add(opacityView);
            opacityView.Paint += new System.Windows.Forms.PaintEventHandler(this.opacityView_Paint);

            Button opacityOK = new Button();
            opacityOK.Text = "OK";
            opacityOK.Size = new Size(32, 23);
            opacityOK.Location = new Point(67, 159);
            opacityOK.Visible = true;
            opacityForm.Controls.Add(opacityOK);
            opacityOK.Click += new System.EventHandler(this.opacityOK_Click);

            Button opacityCancel = new Button();
            opacityCancel.Text = "Cancel";
            opacityCancel.Size = new Size(52, 23);
            opacityCancel.Location = new Point(100, 159);
            opacityCancel.Visible = true;
            opacityForm.Controls.Add(opacityCancel);
            opacityCancel.Click += new System.EventHandler(this.opacityCancel_Click);
        }
        private void position_Click(object sender, EventArgs e)
        {
            Form positionForm = new Form();
            positionForm.Name = "position";
            positionForm.Text = "position";
            positionForm.ShowInTaskbar = false;
            positionForm.Size = new Size(348, 137);
            positionForm.StartPosition = FormStartPosition.CenterScreen;
            positionForm.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            positionForm.ShowIcon = false;
            positionForm.MaximizeBox = false;
            positionForm.Show();

            Label elementPos = new Label();
            elementPos.Size = new Size(150, 13);
            elementPos.AutoSize = false;
            elementPos.Location = new Point(9, 9);
            elementPos.Text = "element position";
            positionForm.Controls.Add(elementPos);

            RadioButton absolute = new RadioButton();
            absolute.Name = "absolute";
            absolute.Text = "absolute";
            absolute.Size = new Size(70, 17);
            absolute.Location = new Point(12, 32);
            positionForm.Controls.Add(absolute);

            RadioButton fixed1 = new RadioButton();
            fixed1.Name = "fixed";
            fixed1.Text = "fixed";
            fixed1.Size = new Size(50, 17);
            fixed1.Location = new Point(88, 32);
            positionForm.Controls.Add(fixed1);

            RadioButton relative = new RadioButton();
            relative.Name = "relative";
            relative.Text = "relative";
            relative.Size = new Size(62, 17);
            relative.Location = new Point(144, 32);
            positionForm.Controls.Add(relative);

            RadioButton static1 = new RadioButton();
            static1.Name = "static";
            static1.Text = "static";
            static1.Size = new Size(52, 17);
            static1.Location = new Point(212, 32);
            positionForm.Controls.Add(static1);

            RadioButton inherit = new RadioButton();
            inherit.Name = "inherit";
            inherit.Text = "inherit";
            inherit.Size = new Size(59, 17);
            inherit.Location = new Point(270, 32);
            positionForm.Controls.Add(inherit);

            Button positionOK = new Button();
            positionOK.Size = new Size(32, 23);
            positionOK.Location = new Point(228, 64);
            positionOK.Text = "OK";
            positionForm.Controls.Add(positionOK);
            positionOK.Click += new System.EventHandler(this.positionOK_Click);

            Button positionCancel = new Button();
            positionCancel.Size = new Size(52, 23);
            positionCancel.Location = new Point(268, 64);
            positionCancel.Text = "Cancel";
            positionForm.Controls.Add(positionCancel);
            positionCancel.Click += new System.EventHandler(this.positionCancel_Click);
        }
        private void youtube_Click(object sender, EventArgs e)
        {
            Form embedFrm = new Form();
            embedFrm.Size = new Size(501, 183);
            embedFrm.StartPosition = FormStartPosition.CenterScreen;
            embedFrm.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            embedFrm.ShowIcon = false;
            embedFrm.Name = "EmbedYouTube";
            embedFrm.Text = "YouTube";
            embedFrm.MaximizeBox = false;
            embedFrm.ShowInTaskbar = false;
            embedFrm.Show();

            Label objectWidth = new Label();
            objectWidth.Size = new Size(73, 13);
            objectWidth.Location = new Point(12, 19);
            objectWidth.Text = "object width";
            embedFrm.Controls.Add(objectWidth);

            TrackBar widthValTrack = new TrackBar();
            widthValTrack.Location = new Point(125, 17);
            widthValTrack.Size = new Size(105, 30);
            widthValTrack.AutoSize = false;
            widthValTrack.LargeChange = 10;
            widthValTrack.SmallChange = 1;
            widthValTrack.Maximum = 1000;
            widthValTrack.Value = 500;
            widthValTrack.TickStyle = System.Windows.Forms.TickStyle.None;
            widthValTrack.Name = "widthValTrack";
            widthValTrack.Scroll += new System.EventHandler(this.widthValTrack_Scroll);
            embedFrm.Controls.Add(widthValTrack);

            TextBox widthVal = new TextBox();
            widthVal.Size = new Size(62, 22);
            widthVal.Location = new Point(236, 17);
            widthVal.Name = "widthVal";
            embedFrm.Controls.Add(widthVal);

            Label objectHeight = new Label();
            objectHeight.Size = new Size(107, 13);
            objectHeight.Location = new Point(12, 49);
            objectHeight.Text = "object height";
            embedFrm.Controls.Add(objectHeight);

            TrackBar heightValTrack = new TrackBar();
            heightValTrack.Location = new Point(125, 48);
            heightValTrack.AutoSize = false;
            heightValTrack.Size = new Size(105, 28);
            heightValTrack.LargeChange = 10;
            heightValTrack.SmallChange = 1;
            heightValTrack.Maximum = 1000;
            heightValTrack.Value = 500;
            heightValTrack.TickStyle = System.Windows.Forms.TickStyle.None;
            heightValTrack.Scroll += new System.EventHandler(this.heightValTrack_Scroll);
            heightValTrack.Name = "heightValTrack";
            embedFrm.Controls.Add(heightValTrack);

            TextBox heigthVal = new TextBox();
            heigthVal.Size = new Size(62, 22);
            heigthVal.Location = new Point(236, 44);
            heigthVal.Name = "heigthVal";
            embedFrm.Controls.Add(heigthVal);

            Label labelYoutube = new Label();
            labelYoutube.Size = new Size(76, 13);
            labelYoutube.Text = "YouTube link";
            labelYoutube.Location = new Point(13, 80);
            embedFrm.Controls.Add(labelYoutube);

            RichTextBox ytbLink = new RichTextBox();
            ytbLink.Size = new Size(173, 22);
            ytbLink.Location = new Point(125, 77);
            ytbLink.Name = "ytbLink";
            ytbLink.TextChanged += new System.EventHandler(this.ytbLink_Changed);
            embedFrm.Controls.Add(ytbLink);

            FlowLayoutPanel objectPrototype = new FlowLayoutPanel();
            objectPrototype.Location = new Point(347, 12);
            objectPrototype.Size = new Size(126, 115);
            objectPrototype.Name = "objectPrototype";
            objectPrototype.BorderStyle = BorderStyle.FixedSingle;
            objectPrototype.Paint += new System.Windows.Forms.PaintEventHandler(this.objectPrototype_Paint);
            embedFrm.Controls.Add(objectPrototype);

            Button youtubeCancel = new Button();
            youtubeCancel.Size = new Size(48, 23);
            youtubeCancel.Location = new Point(250, 114);
            youtubeCancel.Text = "Cancel";
            embedFrm.Controls.Add(youtubeCancel);
            youtubeCancel.Click += new EventHandler(this.youtubeCancel_Click);

            Button youtubeOK = new Button();
            youtubeOK.Location = new Point(207, 114);
            youtubeOK.Size = new Size(32, 23);
            youtubeOK.Visible = true;
            youtubeOK.Text = "OK";
            embedFrm.Controls.Add(youtubeOK);
            youtubeOK.Click += new System.EventHandler(this.youtubeOK_Click);
        }
        private void divBtn_Click(object sender, EventArgs e)
        {
            Form divForm = new Form();
            divForm.Size = new Size(230, 205);
            divForm.Name = "DIV";
            divForm.Text = "div";
            divForm.ShowInTaskbar = false;
            divForm.StartPosition = FormStartPosition.CenterScreen;
            divForm.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            divForm.ShowIcon = false;
            divForm.MaximizeBox = false;
            divForm.Show();

            Label divLocation = new Label();
            divLocation.Text = "location";
            divLocation.Size = new Size(72, 13);
            divLocation.Location = new Point(13, 13);
            divForm.Controls.Add(divLocation);

            RadioButton right = new RadioButton();
            right.Name = "right";
            right.Text = "right";
            right.Location = new Point(16, 40);
            right.Size = new Size(56, 17);
            divForm.Controls.Add(right);

            RadioButton center = new RadioButton();
            center.Name = "center";
            center.Text = "center";
            center.Location = new Point(76, 40);
            center.Size = new Size(76, 17);
            divForm.Controls.Add(center);

            RadioButton left = new RadioButton();
            left.Name = "left";
            left.Text = "left";
            left.Location = new Point(153, 40);
            left.Size = new Size(56, 17);
            divForm.Controls.Add(left);

            Label divName = new Label();
            divName.Location = new Point(13, 73);
            divName.Size = new Size(42, 13);
            divName.Text = "title";
            divForm.Controls.Add(divName);

            TextBox divNameVal = new TextBox();
            divNameVal.Size = new Size(122, 20);
            divNameVal.Location = new Point(76, 69);
            divNameVal.Name = "divNameVal";
            divForm.Controls.Add(divNameVal);

            Label className = new Label();
            className.Location = new Point(12, 102);
            className.Size = new Size(60, 13);
            className.Text = "class name";
            divForm.Controls.Add(className);

            TextBox classNameVal = new TextBox();
            classNameVal.Size = new Size(122, 20);
            classNameVal.Location = new Point(76, 99);
            classNameVal.Name = "classNameVal";
            divForm.Controls.Add(classNameVal);

            Button divOK = new Button();
            divOK.Size = new Size(32, 23);
            divOK.Location = new Point(117, 136);
            divOK.Text = "OK";
            divForm.Controls.Add(divOK);
            divOK.Click += new System.EventHandler(this.divOK_Click);

            Button divCancel = new Button();
            divCancel.Size = new Size(50, 23);
            divCancel.Location = new Point(150, 136);
            divCancel.Text = "Cancel";
            divForm.Controls.Add(divCancel);
            divCancel.Click += new System.EventHandler(this.divCancel_Click);
        }
        private void tableButton_Click(object sender, EventArgs e)
        {
            Form frm1 = new Form();
            frm1.Size = new Size(242, 377);
            frm1.StartPosition = FormStartPosition.CenterScreen;
            frm1.Name = "TableAdd";
            frm1.Text = "table";
            frm1.ShowIcon = false;
            frm1.MaximizeBox = false;
            frm1.ShowInTaskbar = false;
            frm1.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            frm1.Show();

            Label tableNameLbl = new Label();
            tableNameLbl.Size = new Size(70, 13);
            tableNameLbl.Location = new Point(9, 9);
            tableNameLbl.Text = "table name";
            frm1.Controls.Add(tableNameLbl);

            TextBox tableName = new TextBox();
            tableName.Name = "tableName";
            tableName.Location = new Point(114, 6);
            tableName.Size = new Size(100, 22);
            frm1.Controls.Add(tableName);

            Label alignTable = new Label();
            alignTable.Location = new Point(9, 29);
            alignTable.Size = new Size(73, 13);
            alignTable.Text = "align table";
            frm1.Controls.Add(alignTable);

            RadioButton right = new RadioButton();
            right.Text = "right";
            right.Location = new Point(12, 45);
            right.Size = new Size(56, 17);
            right.Name = "right";
            frm1.Controls.Add(right);

            RadioButton center = new RadioButton();
            center.Text = "center";
            center.Location = new Point(74, 46);
            center.Size = new Size(74, 17);
            center.Name = "center";
            frm1.Controls.Add(center);

            RadioButton left = new RadioButton();
            left.Text = "left";
            left.Size = new Size(53, 17);
            left.Location = new Point(161, 46);
            left.Name = "left";
            frm1.Controls.Add(left);

            Label bgLbl = new Label();
            bgLbl.Location = new Point(9, 70);
            bgLbl.Size = new Size(65, 13);
            bgLbl.Text = "background";
            frm1.Controls.Add(bgLbl);

            Button selectBGImg = new Button();
            selectBGImg.Location = new Point(12, 86);
            selectBGImg.Size = new Size(45, 23);
            selectBGImg.Text = "Select";
            frm1.Controls.Add(selectBGImg);
            selectBGImg.Click += new System.EventHandler(this.selectBGImg_Click); //ne napisal click sobitie eshe

            TextBox bgImgFileName = new TextBox();
            bgImgFileName.Location = new Point(103, 88);
            bgImgFileName.Size = new Size(111, 22);
            bgImgFileName.Name = "bgImgFileName";
            frm1.Controls.Add(bgImgFileName);

            Label bgColor = new Label();
            bgColor.Text = "background color";
            bgColor.Size = new Size(85, 13);
            bgColor.Location = new Point(9, 120);
            frm1.Controls.Add(bgColor);

            Button tableColor = new Button();
            tableColor.Size = new Size(45, 23);
            tableColor.Location = new Point(12, 136);
            tableColor.Text = "Select";
            frm1.Controls.Add(tableColor);
            tableColor.Click += new System.EventHandler(this.tableColor_Click);

            TextBox tableColorCode = new TextBox();
            tableColorCode.Size = new Size(111, 22);
            tableColorCode.Location = new Point(103, 137);
            tableColorCode.Name = "tableColorCode";
            frm1.Controls.Add(tableColorCode);

            Label tableBorderSize = new Label();
            tableBorderSize.Text = "border size";
            tableBorderSize.Size = new Size(90, 13);
            tableBorderSize.Location = new Point(9, 172);
            frm1.Controls.Add(tableBorderSize);

            NumericUpDown tableBorderSizeVal = new NumericUpDown();
            tableBorderSizeVal.Name = "tableBorderSizeVal"; //border=""
            tableBorderSizeVal.Size = new Size(33, 22);
            tableBorderSizeVal.Location = new Point(181, 170);
            frm1.Controls.Add(tableBorderSizeVal);

            Label tableBorderColor = new Label();
            tableBorderColor.Size = new Size(83, 13);
            tableBorderColor.Location = new Point(9, 202);
            tableBorderColor.Text = "border color";
            frm1.Controls.Add(tableBorderColor);

            Button tableBorderColorSet = new Button();
            tableBorderColorSet.Size = new Size(45, 23);
            tableBorderColorSet.Location = new Point(12, 218);
            tableBorderColorSet.Text = "Select";
            frm1.Controls.Add(tableBorderColorSet);
            tableBorderColorSet.Click += new System.EventHandler(tableBorderColorSet_Click);

            TextBox tableBorderColorCode = new TextBox();
            tableBorderColorCode.Name = "tableBorderColorCode";
            tableBorderColorCode.Size = new Size(111, 22);
            tableBorderColorCode.Location = new Point(103, 218);
            frm1.Controls.Add(tableBorderColorCode);

            Label tableCellPadding = new Label();
            tableCellPadding.Size = new Size(170, 13);
            tableCellPadding.Location = new Point(9, 257);
            tableCellPadding.Text = "cellpadding";
            frm1.Controls.Add(tableCellPadding);

            NumericUpDown tableCellPaddingVal = new NumericUpDown();
            tableCellPaddingVal.Name = "tabCellPaddingVal";
            tableCellPaddingVal.Size = new Size(33, 22);
            tableCellPaddingVal.Location = new Point(181, 255);
            frm1.Controls.Add(tableCellPaddingVal);

            Label tableCellSpacing = new Label();
            tableCellSpacing.Size = new Size(108, 13);
            tableCellSpacing.Location = new Point(9, 287);
            tableCellSpacing.Text = "cellspacing";
            frm1.Controls.Add(tableCellSpacing);

            NumericUpDown tableCellSpacingVal = new NumericUpDown();
            tableCellSpacingVal.Size = new Size(33, 22);
            tableCellSpacingVal.Location = new Point(181, 285);
            tableCellSpacingVal.Name = "tableCellSpacingVal";
            frm1.Controls.Add(tableCellSpacingVal);

            Button tableOK = new Button();
            tableOK.Text = "OK";
            tableOK.Size = new Size(31, 23);
            tableOK.Location = new Point(135, 310);
            frm1.Controls.Add(tableOK);
            tableOK.Click += new System.EventHandler(tableOK_Click);

            Button tableCancel = new Button();
            tableCancel.Text = "Cancel";
            tableCancel.Size = new Size(50, 23);
            tableCancel.Location = new Point(170, 310);
            frm1.Controls.Add(tableCancel);
            tableCancel.Click += new System.EventHandler(tableCancel_Click);
        }
        private void achTSMI_Click(object sender, EventArgs e)
        {
            Form saveForm = new Form();
            saveForm.Size = new Size(138, 119);
            saveForm.StartPosition = FormStartPosition.CenterScreen;
            saveForm.Name = "saveForm";
            saveForm.Text = "Save file";
            saveForm.ShowIcon = false;
            saveForm.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            saveForm.MaximizeBox = false;
            saveForm.Show();

            Label label1 = new Label();
            label1.Location = new System.Drawing.Point(12, 18);
            label1.Size = new System.Drawing.Size(74, 13);
            label1.Text = "Save the file?";
            saveForm.Controls.Add(label1);

            Button saveYes = new Button();
            saveYes.Location = new System.Drawing.Point(27, 45);
            saveYes.Name = "saveYes";
            saveYes.Click += new EventHandler(this.saveFile_Click);
            saveYes.Size = new System.Drawing.Size(38, 23);
            saveYes.Text = "Yes";
            saveForm.Controls.Add(saveYes);

            Button saveNo = new Button();
            saveNo.Location = new System.Drawing.Point(71, 45);
            saveNo.Name = "saveNo";
            saveNo.Click += new EventHandler(this.saveNo_Click);
            saveNo.Size = new System.Drawing.Size(38, 23);
            saveNo.Text = "No";
            saveForm.Controls.Add(saveNo);
        }
        private void abbreviature_Click(object sender, EventArgs e)
        {
            Form abbrevForm = new Form();
            abbrevForm.Size = new Size(213, 136);
            abbrevForm.StartPosition = FormStartPosition.CenterScreen;
            abbrevForm.Name = "AbbrevForm";
            abbrevForm.Text = "abbreviature";
            abbrevForm.ShowIcon = false;
            abbrevForm.ShowInTaskbar = false;
            abbrevForm.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            abbrevForm.MaximizeBox = false;
            abbrevForm.Show();

            Label abbrvText = new Label();
            abbrvText.Text = "abbreviature";
            abbrvText.Location = new Point(6, 13);
            abbrvText.Size = new Size(67, 13);
            abbrevForm.Controls.Add(abbrvText);

            Label fullText = new Label();
            fullText.Text = "meaning";
            fullText.Location = new Point(6, 39);
            fullText.Size = new Size(58, 13);
            abbrevForm.Controls.Add(fullText);

            TextBox abbrvTextVal = new TextBox();
            abbrvTextVal.Name = "abbrvTextVal";
            abbrvTextVal.Location = new Point(74, 10);
            abbrvTextVal.Size = new Size(112, 22);
            abbrevForm.Controls.Add(abbrvTextVal);

            TextBox fullTextVal = new TextBox();
            fullTextVal.Name = "fullTextVal";
            fullTextVal.Location = new Point(74, 36);
            fullTextVal.Size = new Size(112, 22);
            abbrevForm.Controls.Add(fullTextVal);

            Button abbrvOK = new Button();
            abbrvOK.Size = new Size(40, 23);
            abbrvOK.Location = new Point(95, 65);
            abbrvOK.Text = "OK";
            abbrvOK.Click += new System.EventHandler(this.abbrvOK_Click);
            abbrevForm.Controls.Add(abbrvOK);

            Button abbrvCancel = new Button();
            abbrvCancel.Size = new Size(50, 23);
            abbrvCancel.Location = new Point(141, 65);
            abbrvCancel.Text = "Cancel";
            abbrvCancel.Click += new System.EventHandler(this.abbrvCancel_Click);
            abbrevForm.Controls.Add(abbrvCancel);
        }
        private void haqqindaTSMI_Click(object sender, EventArgs e)
        {
            Form about = new Form();
            about.Size = new Size(482, 141);
            about.Name = "about";
            about.Text = "About";
            about.ShowInTaskbar = false;
            about.MaximizeBox = false;
            about.ShowIcon = false;
            about.StartPosition = FormStartPosition.CenterScreen;
            about.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            about.Show();

            Panel aboutPanel = new Panel();
            aboutPanel.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            aboutPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            aboutPanel.Location = new System.Drawing.Point(0, 0);
            aboutPanel.Size = new System.Drawing.Size(466, 103);
            about.Controls.Add(aboutPanel);

            PictureBox aboutImage = new PictureBox();
            aboutImage.Image = global::Loxie.Properties.Resources.loxie_cover;
            aboutImage.Location = new System.Drawing.Point(-1, -1);
            aboutImage.Size = new System.Drawing.Size(236, 103);
            aboutImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            aboutImage.Click += new System.EventHandler(this.aboutImage_Click);
            aboutPanel.Controls.Add(aboutImage);

            Label label1 = new Label();
            label1.Font = new System.Drawing.Font("Palatino Linotype", 9F);
            label1.Location = new System.Drawing.Point(252, 3);
            label1.Size = new System.Drawing.Size(38, 17);
            label1.Text = "Loxie";
            aboutPanel.Controls.Add(label1);

            Label label2 = new Label();
            label2.Font = new System.Drawing.Font("Palatino Linotype", 9F);
            label2.Location = new System.Drawing.Point(252, 33);
            label2.Size = new System.Drawing.Size(199, 17);
            label2.Text = "Version 0.0.0.1 prealpha (build 423)";
            aboutPanel.Controls.Add(label2);

            Label label3 = new Label();
            label3.Font = new System.Drawing.Font("Palatino Linotype", 9F);
            label3.Location = new System.Drawing.Point(254, 64);
            label3.Size = new System.Drawing.Size(122, 17);
            label3.Text = "©2015-2016 AhmCho";
            aboutPanel.Controls.Add(label3);
        }
        private void ol_Click(object sender, EventArgs e)
        {
            Form olForm = new Form();
            olForm.Size = new Size(271, 98);
            olForm.StartPosition = FormStartPosition.CenterScreen;
            olForm.ShowIcon = false;
            olForm.Text = "ordered list";
            olForm.Name = "olForm";
            olForm.ShowInTaskbar = false;
            olForm.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            olForm.MaximizeBox = false;
            olForm.Show();

            Button addListItem = new Button();
            addListItem.Location = new System.Drawing.Point(76, 7);
            addListItem.Name = "addListItem";
            addListItem.Size = new System.Drawing.Size(28, 22);
            addListItem.Text = "+";
            addListItem.Click += new System.EventHandler(this.addListItem_Click);
            olForm.Controls.Add(addListItem);

            Button removeListItem = new Button();
            removeListItem.Location = new System.Drawing.Point(110, 7);
            removeListItem.Name = "removeListItem";
            removeListItem.Size = new System.Drawing.Size(28, 22);
            removeListItem.Text = "-";
            removeListItem.Click += new EventHandler(this.removeListItem_Click);
            olForm.Controls.Add(removeListItem);

            Button olOk = new Button();
            olOk.Location = new System.Drawing.Point(126, 35);
            olOk.Name = "olOk";
            olOk.Size = new System.Drawing.Size(37, 23);
            olOk.Text = "OK";
            olOk.Click += new EventHandler(this.olOk_Click);
            olForm.Controls.Add(olOk);

            Button olCancel = new Button();
            olCancel.Location = new System.Drawing.Point(169, 35);
            olCancel.Name = "olCancel";
            olCancel.Size = new System.Drawing.Size(75, 23);
            olCancel.Text = "Cancel";
            olCancel.Click += new EventHandler(this.olCancel_Click);
            olForm.Controls.Add(olCancel);

            Label label1 = new Label();
            label1.Location = new System.Drawing.Point(12, 12);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(50, 13);
            label1.Text = "list item";
            olForm.Controls.Add(label1);

            TextBox listItem = new TextBox();
            listItem.Location = new System.Drawing.Point(144, 9);
            listItem.Name = "listItem";
            listItem.Size = new System.Drawing.Size(100, 20);
            olForm.Controls.Add(listItem);
        }
        private void ul_Click(object sender, EventArgs e)
        {
            Form ulForm = new Form();
            ulForm.Size = new Size(271, 98);
            ulForm.StartPosition = FormStartPosition.CenterScreen;
            ulForm.ShowIcon = false;
            ulForm.Text = "unordered list";
            ulForm.Name = "ulForm";
            ulForm.ShowInTaskbar = false;
            ulForm.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            ulForm.MaximizeBox = false;
            ulForm.Show();

            Button addListItemU = new Button();
            addListItemU.Location = new System.Drawing.Point(76, 7);
            addListItemU.Name = "addListItemU";
            addListItemU.Size = new System.Drawing.Size(28, 22);
            addListItemU.Text = "+";
            addListItemU.Click += new System.EventHandler(this.addListItemU_Click);
            ulForm.Controls.Add(addListItemU);

            Button removeListItemU = new Button();
            removeListItemU.Location = new System.Drawing.Point(110, 7);
            removeListItemU.Name = "removeListItemU";
            removeListItemU.Size = new System.Drawing.Size(28, 22);
            removeListItemU.Text = "-";
            removeListItemU.Click += new EventHandler(this.removeListItemU_Click);
            ulForm.Controls.Add(removeListItemU);

            Button ulOk = new Button();
            ulOk.Location = new System.Drawing.Point(126, 35);
            ulOk.Name = "ulOk";
            ulOk.Size = new System.Drawing.Size(37, 23);
            ulOk.Text = "OK";
            ulOk.Click += new EventHandler(this.ulOk_Click);
            ulForm.Controls.Add(ulOk);

            Button ulCancel = new Button();
            ulCancel.Location = new System.Drawing.Point(169, 35);
            ulCancel.Name = "ulCancel";
            ulCancel.Size = new System.Drawing.Size(75, 23);
            ulCancel.Text = "Cancel";
            ulCancel.Click += new EventHandler(this.olCancel_Click);
            ulForm.Controls.Add(ulCancel);

            Label label1 = new Label();
            label1.Location = new System.Drawing.Point(12, 12);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(50, 13);
            label1.Text = "list item";
            ulForm.Controls.Add(label1);

            TextBox listItem = new TextBox();
            listItem.Location = new System.Drawing.Point(144, 9);
            listItem.Name = "listItem";
            listItem.Size = new System.Drawing.Size(100, 20);
            ulForm.Controls.Add(listItem);
        }
        private void h1_Click(object sender, EventArgs e)
        {
            Form h1Form = new Form();
            h1Form.Size = new Size(269, 123);
            h1Form.StartPosition = FormStartPosition.CenterScreen;
            h1Form.ShowIcon = false;
            h1Form.Text = "h1 header";
            h1Form.Name = "h1Form";
            h1Form.ShowInTaskbar = false;
            h1Form.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            h1Form.MaximizeBox = false;
            h1Form.Show();

            Button h1Ok = new Button();
            h1Ok.Location = new System.Drawing.Point(127, 54);
            h1Ok.Name = "h1Ok";
            h1Ok.Size = new System.Drawing.Size(37, 23);
            h1Ok.Text = "OK";
            h1Ok.Click += new EventHandler(this.h1Ok_Click);
            h1Form.Controls.Add(h1Ok);

            Button h1Cancel = new Button();
            h1Cancel.Location = new System.Drawing.Point(170, 54);
            h1Cancel.Name = "h1Cancel";
            h1Cancel.Size = new System.Drawing.Size(75, 23);
            h1Cancel.Text = "Cancel";
            h1Cancel.Click += new EventHandler(this.h1Cancel_Click);
            h1Form.Controls.Add(h1Cancel);

            Label label1 = new Label();
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(12, 12);
            label1.Size = new System.Drawing.Size(60, 13);
            label1.Text = "header text";
            h1Form.Controls.Add(label1);

            TextBox headerName = new TextBox();
            headerName.Location = new System.Drawing.Point(12, 28);
            headerName.Name = "headerName";
            headerName.Size = new System.Drawing.Size(233, 20);
            h1Form.Controls.Add(headerName);
        }
        private void h2_Click(object sender, EventArgs e)
        {
            Form h2Form = new Form();
            h2Form.Size = new Size(269, 123);
            h2Form.StartPosition = FormStartPosition.CenterScreen;
            h2Form.ShowIcon = false;
            h2Form.Text = "h2 header";
            h2Form.Name = "h2Form";
            h2Form.ShowInTaskbar = false;
            h2Form.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            h2Form.MaximizeBox = false;
            h2Form.Show();

            Button h2Ok = new Button();
            h2Ok.Location = new System.Drawing.Point(127, 54);
            h2Ok.Name = "h2Ok";
            h2Ok.Size = new System.Drawing.Size(37, 23);
            h2Ok.Text = "OK";
            h2Ok.Click += new EventHandler(this.h2Ok_Click);
            h2Form.Controls.Add(h2Ok);

            Button h2Cancel = new Button();
            h2Cancel.Location = new System.Drawing.Point(170, 54);
            h2Cancel.Name = "h2Cancel";
            h2Cancel.Size = new System.Drawing.Size(75, 23);
            h2Cancel.Text = "Cancel";
            h2Cancel.Click += new EventHandler(this.h2Cancel_Click);
            h2Form.Controls.Add(h2Cancel);

            Label label1 = new Label();
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(12, 12);
            label1.Size = new System.Drawing.Size(60, 13);
            label1.Text = "header text";
            h2Form.Controls.Add(label1);

            TextBox headerName = new TextBox();
            headerName.Location = new System.Drawing.Point(12, 28);
            headerName.Name = "headerName";
            headerName.Size = new System.Drawing.Size(233, 20);
            h2Form.Controls.Add(headerName);
        }
        private void h3_Click(object sender, EventArgs e)
        {
            Form h3Form = new Form();
            h3Form.Size = new Size(269, 123);
            h3Form.StartPosition = FormStartPosition.CenterScreen;
            h3Form.ShowIcon = false;
            h3Form.Text = "h3 header";
            h3Form.Name = "h3Form";
            h3Form.ShowInTaskbar = false;
            h3Form.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            h3Form.MaximizeBox = false;
            h3Form.Show();

            Button h3Ok = new Button();
            h3Ok.Location = new System.Drawing.Point(127, 54);
            h3Ok.Name = "h3Ok";
            h3Ok.Size = new System.Drawing.Size(37, 23);
            h3Ok.Text = "OK";
            h3Ok.Click += new EventHandler(this.h3Ok_Click);
            h3Form.Controls.Add(h3Ok);

            Button h3Cancel = new Button();
            h3Cancel.Location = new System.Drawing.Point(170, 54);
            h3Cancel.Name = "h3Cancel";
            h3Cancel.Size = new System.Drawing.Size(75, 23);
            h3Cancel.Text = "Cancel";
            h3Cancel.Click += new EventHandler(this.h3Cancel_Click);
            h3Form.Controls.Add(h3Cancel);

            Label label1 = new Label();
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(12, 12);
            label1.Size = new System.Drawing.Size(60, 13);
            label1.Text = "header text";
            h3Form.Controls.Add(label1);

            TextBox headerName = new TextBox();
            headerName.Location = new System.Drawing.Point(12, 28);
            headerName.Name = "headerName";
            headerName.Size = new System.Drawing.Size(233, 20);
            h3Form.Controls.Add(headerName);
        }
        private void h4_Click(object sender, EventArgs e)
        {
            Form h4Form = new Form();
            h4Form.Size = new Size(269, 123);
            h4Form.StartPosition = FormStartPosition.CenterScreen;
            h4Form.ShowIcon = false;
            h4Form.Text = "h4 header";
            h4Form.Name = "h4Form";
            h4Form.ShowInTaskbar = false;
            h4Form.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            h4Form.MaximizeBox = false;
            h4Form.Show();

            Button h4Ok = new Button();
            h4Ok.Location = new System.Drawing.Point(127, 54);
            h4Ok.Name = "h4Ok";
            h4Ok.Size = new System.Drawing.Size(37, 23);
            h4Ok.Text = "OK";
            h4Ok.Click += new EventHandler(this.h4Ok_Click);
            h4Form.Controls.Add(h4Ok);

            Button h4Cancel = new Button();
            h4Cancel.Location = new System.Drawing.Point(170, 54);
            h4Cancel.Name = "h4Cancel";
            h4Cancel.Size = new System.Drawing.Size(75, 23);
            h4Cancel.Text = "Cancel";
            h4Cancel.Click += new EventHandler(this.h4Cancel_Click);
            h4Form.Controls.Add(h4Cancel);

            Label label1 = new Label();
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(12, 12);
            label1.Size = new System.Drawing.Size(60, 13);
            label1.Text = "header text";
            h4Form.Controls.Add(label1);

            TextBox headerName = new TextBox();
            headerName.Location = new System.Drawing.Point(12, 28);
            headerName.Name = "headerName";
            headerName.Size = new System.Drawing.Size(233, 20);
            h4Form.Controls.Add(headerName);
        }
        private void h5_Click(object sender,EventArgs e)
        {
            Form h5Form = new Form();
            h5Form.Size = new Size(269, 123);
            h5Form.StartPosition = FormStartPosition.CenterScreen;
            h5Form.ShowIcon = false;
            h5Form.Text = "h5 header";
            h5Form.Name = "h5Form";
            h5Form.ShowInTaskbar = false;
            h5Form.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            h5Form.MaximizeBox = false;
            h5Form.Show();

            Button h5Ok = new Button();
            h5Ok.Location = new System.Drawing.Point(127, 54);
            h5Ok.Name = "h5Ok";
            h5Ok.Size = new System.Drawing.Size(37, 23);
            h5Ok.Text = "OK";
            h5Ok.Click += new EventHandler(this.h5Ok_Click);
            h5Form.Controls.Add(h5Ok);

            Button h5Cancel = new Button();
            h5Cancel.Location = new System.Drawing.Point(170, 54);
            h5Cancel.Name = "h5Cancel";
            h5Cancel.Size = new System.Drawing.Size(75, 23);
            h5Cancel.Text = "Cancel";
            h5Cancel.Click += new EventHandler(this.h5Cancel_Click);
            h5Form.Controls.Add(h5Cancel);

            Label label1 = new Label();
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(12, 12);
            label1.Size = new System.Drawing.Size(60, 13);
            label1.Text = "header text";
            h5Form.Controls.Add(label1);

            TextBox headerName = new TextBox();
            headerName.Location = new System.Drawing.Point(12, 28);
            headerName.Name = "headerName";
            headerName.Size = new System.Drawing.Size(233, 20);
            h5Form.Controls.Add(headerName);
        }
        private void h6_Click(object sender,EventArgs e)
        {
            Form h6Form = new Form();
            h6Form.Size = new Size(269, 123);
            h6Form.StartPosition = FormStartPosition.CenterScreen;
            h6Form.ShowIcon = false;
            h6Form.Text = "h6 header";
            h6Form.Name = "h6Form";
            h6Form.ShowInTaskbar = false;
            h6Form.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            h6Form.MaximizeBox = false;
            h6Form.Show();

            Button h6Ok = new Button();
            h6Ok.Location = new System.Drawing.Point(127, 54);
            h6Ok.Name = "h6Ok";
            h6Ok.Size = new System.Drawing.Size(37, 23);
            h6Ok.Text = "OK";
            h6Ok.Click += new EventHandler(this.h6Ok_Click);
            h6Form.Controls.Add(h6Ok);

            Button h6Cancel = new Button();
            h6Cancel.Location = new System.Drawing.Point(170, 54);
            h6Cancel.Name = "h6Cancel";
            h6Cancel.Size = new System.Drawing.Size(75, 23);
            h6Cancel.Text = "Cancel";
            h6Cancel.Click += new EventHandler(this.h6Cancel_Click);
            h6Form.Controls.Add(h6Cancel);

            Label label1 = new Label();
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(12, 12);
            label1.Size = new System.Drawing.Size(60, 13);
            label1.Text = "header text";
            h6Form.Controls.Add(label1);

            TextBox headerName = new TextBox();
            headerName.Location = new System.Drawing.Point(12, 28);
            headerName.Name = "headerName";
            headerName.Size = new System.Drawing.Size(233, 20);
            h6Form.Controls.Add(headerName);
        }
        //=======================================UserInterface================================================//
        //=======================================Button Clicks===============================================//
        private void h6Ok_Click(object sender, EventArgs e)
        {
            var ctrl = (Control)sender;
            var frm = ctrl.FindForm();
            textArea.SelectedText = string.Format("<h6>{0}</h6>\n", frm.Controls.OfType<TextBox>().FirstOrDefault(y => y.Name == "headerName").Text);
            frm.Close();
        }
        private void h6Cancel_Click(object sender,EventArgs e)
        {
            var ctrl = (Control)sender;
            var frm = ctrl.FindForm();
            frm.Close();
        }
        private void h5Ok_Click(object sender,EventArgs e)
        {
            var ctrl = (Control)sender;
            var frm = ctrl.FindForm();
            textArea.SelectedText = string.Format("<h5>{0}</h5>\n", frm.Controls.OfType<TextBox>().FirstOrDefault(y => y.Name == "headerName").Text);
            frm.Close();
        }
        private void h5Cancel_Click(object sender,EventArgs e)
        {
            var ctrl = (Control)sender;
            var frm = ctrl.FindForm();
            frm.Close();
        }
        private void h4Ok_Click(object sender,EventArgs e)
        {
            var ctrl = (Control)sender;
            var frm = ctrl.FindForm();
            textArea.SelectedText = string.Format("<h4>{0}</h4>\n", frm.Controls.OfType<TextBox>().FirstOrDefault(y => y.Name == "headerName").Text);
            frm.Close();
        }
        private void h4Cancel_Click(object sender,EventArgs e)
        {
            var ctrl = (Control)sender;
            var frm = ctrl.FindForm();
            frm.Close();
        }
        private void h3Ok_Click(object sender,EventArgs e)
        {
            var ctrl = (Control)sender;
            var frm = ctrl.FindForm();
            textArea.SelectedText = string.Format("<h3>{0}</h3>\n", frm.Controls.OfType<TextBox>().FirstOrDefault(y => y.Name == "headerName").Text);
            frm.Close();
        }
        private void h3Cancel_Click(object sender,EventArgs e)
        {
            var ctrl = (Control)sender;
            var frm = ctrl.FindForm();
            frm.Close();
        }
        private void h2Ok_Click(object sender,EventArgs e)
        {
            var ctrl = (Control)sender;
            var frm = ctrl.FindForm();
            textArea.SelectedText = string.Format("<h2>{0}</h2>\n", frm.Controls.OfType<TextBox>().FirstOrDefault(y => y.Name == "headerName").Text);
            frm.Close();
        }
        private void h2Cancel_Click(object sender,EventArgs e)
        {
            var ctrl = (Control)sender;
            var frm = ctrl.FindForm();
            frm.Close();
        }
        private void h1Ok_Click(object sender,EventArgs e)
        {
            var ctrl = (Control)sender;
            var frm = ctrl.FindForm();
            textArea.SelectedText = string.Format("<h1>{0}</h1>\n", frm.Controls.OfType<TextBox>().FirstOrDefault(y => y.Name == "headerName").Text);
            frm.Close();
        }
        private void h1Cancel_Click(object sender,EventArgs e)
        {
            var ctrl = (Control)sender;
            var frm = ctrl.FindForm();
            frm.Close();
        }
        int index2 = 1;
        private void removeListItemU_Click(object sender,EventArgs e)
        {
            var ctrl = (Control)sender;
            var frm = ctrl.FindForm();
            if (index2 > 1)
            {
                frm.Controls.OfType<Button>().FirstOrDefault(y => y.Name == "addListItemU").Enabled = true;
                frm.Controls.OfType<Button>().FirstOrDefault(y => y.Name == "ulOk").Location = new Point(frm.Controls.OfType<Button>().FirstOrDefault(y => y.Name == "ulOk").Location.X, frm.Controls.OfType<Button>().FirstOrDefault(y => y.Name == "ulOk").Location.Y - 30);
                frm.Controls.OfType<Button>().FirstOrDefault(y => y.Name == "ulCancel").Location = new Point(frm.Controls.OfType<Button>().FirstOrDefault(y => y.Name == "ulCancel").Location.X, frm.Controls.OfType<Button>().FirstOrDefault(y => y.Name == "ulCancel").Location.Y - 30);
                index2--;
                frm.Controls.RemoveByKey("txt" + index2);
                frm.Controls.RemoveByKey("lbl" + index2);
                frm.Height -= 30;
            }
            if (index2 == 1)
            {
                frm.Controls.OfType<Button>().FirstOrDefault(y => y.Name == "removeListItemU").Enabled = false;
            }
        }
        private void addListItemU_Click(object sender,EventArgs e)
        {
            var ctrl = (Control)sender;
            var frm = ctrl.FindForm();
            frm.StartPosition = FormStartPosition.CenterParent;
            string lbldflt = "list item";
            Label l = new Label();
            TextBox t = new TextBox();
            frm.Controls.OfType<Button>().FirstOrDefault(y => y.Name == "removeListItemU").Enabled = true;
            frm.Controls.OfType<Button>().FirstOrDefault(y => y.Name == "ulOk").Location = new Point(frm.Controls.OfType<Button>().FirstOrDefault(y => y.Name == "ulOk").Location.X, frm.Controls.OfType<Button>().FirstOrDefault(y => y.Name == "ulOk").Location.Y + 30);
            frm.Controls.OfType<Button>().FirstOrDefault(y => y.Name == "ulCancel").Location = new Point(frm.Controls.OfType<Button>().FirstOrDefault(y => y.Name == "ulCancel").Location.X, frm.Controls.OfType<Button>().FirstOrDefault(y => y.Name == "ulCancel").Location.Y + 30);
            l.Text = lbldflt + " " + index2;
            l.Width = frm.Controls.OfType<Label>().FirstOrDefault(y => y.Name == "label1").Width + 15;
            l.Location = new Point(frm.Controls.OfType<Label>().FirstOrDefault(y => y.Name == "label1").Location.X, frm.Controls.OfType<Label>().FirstOrDefault(y => y.Name == "label1").Location.Y + 30 * index2);
            l.Name = "lbl" + index2;
            t.Name = "txt" + index2;
            t.Width = frm.Controls.OfType<TextBox>().FirstOrDefault(y => y.Name == "listItem").Width;
            t.Location = new Point(frm.Controls.OfType<TextBox>().FirstOrDefault(y => y.Name == "listItem").Location.X, frm.Controls.OfType<TextBox>().FirstOrDefault(y => y.Name == "listItem").Location.Y + 30 * index2);
            index2++;
            if (index2 > 9)
            {
                frm.Controls.OfType<Button>().FirstOrDefault(y => y.Name == "addListItemU").Enabled = false;
            }
            frm.Controls.Add(l);
            frm.Controls.Add(t);
            frm.Height += 30;
        }
        private void ulOk_Click(object sender,EventArgs e)
        {
            var ctrl = (Control)sender;
            var frm = ctrl.FindForm();
            textArea.SelectionLength = 0;
            textArea.SelectedText = "<ul>\n";
            if (frm.Controls.OfType<TextBox>().FirstOrDefault(y => y.Name == "listItem").Text != String.Empty)
            {
                textArea.SelectedText = string.Format("<li>{0}</li>\n", frm.Controls.OfType<TextBox>().FirstOrDefault(y => y.Name == "listItem").Text);
            }
            if (frm.Controls.ContainsKey("txt1") && frm.Controls.OfType<TextBox>().FirstOrDefault(y => y.Name == "txt1").Text != String.Empty)
            {
                textArea.SelectedText = string.Format("<li>{0}</li>\n", frm.Controls.OfType<TextBox>().FirstOrDefault(y => y.Name == "txt1").Text);
            }
            if (frm.Controls.ContainsKey("txt2") && frm.Controls.OfType<TextBox>().FirstOrDefault(y => y.Name == "txt2").Text != String.Empty)
            {
                textArea.SelectedText = string.Format("<li>{0}</li>\n", frm.Controls.OfType<TextBox>().FirstOrDefault(y => y.Name == "txt2").Text);
            }
            if (frm.Controls.ContainsKey("txt3") && frm.Controls.OfType<TextBox>().FirstOrDefault(y => y.Name == "txt3").Text != String.Empty)
            {
                textArea.SelectedText = string.Format("<li>{0}</li>\n", frm.Controls.OfType<TextBox>().FirstOrDefault(y => y.Name == "txt3").Text);
            }
            if (frm.Controls.ContainsKey("txt4") && frm.Controls.OfType<TextBox>().FirstOrDefault(y => y.Name == "txt4").Text != String.Empty)
            {
                textArea.SelectedText = string.Format("<li>{0}</li>\n", frm.Controls.OfType<TextBox>().FirstOrDefault(y => y.Name == "txt4").Text);
            }
            if (frm.Controls.ContainsKey("txt5") && frm.Controls.OfType<TextBox>().FirstOrDefault(y => y.Name == "txt5").Text != String.Empty)
            {
                textArea.SelectedText = string.Format("<li>{0}</li>\n", frm.Controls.OfType<TextBox>().FirstOrDefault(y => y.Name == "txt5").Text);
            }
            if (frm.Controls.ContainsKey("txt6") && frm.Controls.OfType<TextBox>().FirstOrDefault(y => y.Name == "txt6").Text != String.Empty)
            {
                textArea.SelectedText = string.Format("<li>{0}</li>\n", frm.Controls.OfType<TextBox>().FirstOrDefault(y => y.Name == "txt6").Text);
            }
            if (frm.Controls.ContainsKey("txt7") && frm.Controls.OfType<TextBox>().FirstOrDefault(y => y.Name == "txt7").Text != String.Empty)
            {
                textArea.SelectedText = string.Format("<li>{0}</li>\n", frm.Controls.OfType<TextBox>().FirstOrDefault(y => y.Name == "txt7").Text);
            }
            if (frm.Controls.ContainsKey("txt8") && frm.Controls.OfType<TextBox>().FirstOrDefault(y => y.Name == "txt8").Text != String.Empty)
            {
                textArea.SelectedText = string.Format("<li>{0}</li>\n", frm.Controls.OfType<TextBox>().FirstOrDefault(y => y.Name == "txt8").Text);
            }
            if (frm.Controls.ContainsKey("txt9") && frm.Controls.OfType<TextBox>().FirstOrDefault(y => y.Name == "txt9").Text != String.Empty)
            {
                textArea.SelectedText = string.Format("<li>{0}</li>\n", frm.Controls.OfType<TextBox>().FirstOrDefault(y => y.Name == "txt9").Text);
            }
            frm.Close();
            textArea.SelectedText = "</ul>\n";
        }
        private void olOk_Click(object sender,EventArgs e)
        {
            var ctrl = (Control)sender;
            var frm = ctrl.FindForm();
            textArea.SelectionLength = 0;
            textArea.SelectedText = "<ol>\n";
                    if (frm.Controls.OfType<TextBox>().FirstOrDefault(y => y.Name == "listItem").Text != String.Empty)
                    {
                        textArea.SelectedText = string.Format("<li>{0}</li>\n", frm.Controls.OfType<TextBox>().FirstOrDefault(y => y.Name == "listItem").Text);
                    }
                    if (frm.Controls.ContainsKey("txt1") && frm.Controls.OfType<TextBox>().FirstOrDefault(y => y.Name == "txt1").Text != String.Empty)
                    {
                        textArea.SelectedText = string.Format("<li>{0}</li>\n", frm.Controls.OfType<TextBox>().FirstOrDefault(y => y.Name == "txt1").Text);
                    }
                    if (frm.Controls.ContainsKey("txt2") && frm.Controls.OfType<TextBox>().FirstOrDefault(y => y.Name == "txt2").Text != String.Empty)
                    {
                        textArea.SelectedText = string.Format("<li>{0}</li>\n", frm.Controls.OfType<TextBox>().FirstOrDefault(y => y.Name == "txt2").Text);
                    }
                    if (frm.Controls.ContainsKey("txt3") && frm.Controls.OfType<TextBox>().FirstOrDefault(y => y.Name == "txt3").Text != String.Empty)
                    {
                        textArea.SelectedText = string.Format("<li>{0}</li>\n", frm.Controls.OfType<TextBox>().FirstOrDefault(y => y.Name == "txt3").Text);
                    }
                    if (frm.Controls.ContainsKey("txt4") && frm.Controls.OfType<TextBox>().FirstOrDefault(y => y.Name == "txt4").Text != String.Empty)
                    {
                        textArea.SelectedText = string.Format("<li>{0}</li>\n", frm.Controls.OfType<TextBox>().FirstOrDefault(y => y.Name == "txt4").Text);
                    }
                    if (frm.Controls.ContainsKey("txt5") && frm.Controls.OfType<TextBox>().FirstOrDefault(y => y.Name == "txt5").Text != String.Empty)
                    {
                        textArea.SelectedText = string.Format("<li>{0}</li>\n", frm.Controls.OfType<TextBox>().FirstOrDefault(y => y.Name == "txt5").Text);
                    }
                    if (frm.Controls.ContainsKey("txt6") && frm.Controls.OfType<TextBox>().FirstOrDefault(y => y.Name == "txt6").Text != String.Empty)
                    {
                        textArea.SelectedText = string.Format("<li>{0}</li>\n", frm.Controls.OfType<TextBox>().FirstOrDefault(y => y.Name == "txt6").Text);
                    }
                    if (frm.Controls.ContainsKey("txt7") && frm.Controls.OfType<TextBox>().FirstOrDefault(y => y.Name == "txt7").Text != String.Empty)
                    {
                        textArea.SelectedText = string.Format("<li>{0}</li>\n", frm.Controls.OfType<TextBox>().FirstOrDefault(y => y.Name == "txt7").Text);
                    }
                    if (frm.Controls.ContainsKey("txt8") && frm.Controls.OfType<TextBox>().FirstOrDefault(y => y.Name == "txt8").Text != String.Empty)
                    {
                        textArea.SelectedText = string.Format("<li>{0}</li>\n", frm.Controls.OfType<TextBox>().FirstOrDefault(y => y.Name == "txt8").Text);
                    }
                    if (frm.Controls.ContainsKey("txt9") && frm.Controls.OfType<TextBox>().FirstOrDefault(y => y.Name == "txt9").Text != String.Empty)
                    {
                        textArea.SelectedText = string.Format("<li>{0}</li>\n", frm.Controls.OfType<TextBox>().FirstOrDefault(y => y.Name == "txt9").Text);
                    }
            frm.Close();
            textArea.SelectedText = "</ol>\n";
        }
        private void olCancel_Click(object sender,EventArgs e)
        {
            var ctrl = (Control)sender;
            var frm = ctrl.FindForm();
            frm.Close();
        }
        int indexO=1;
        private void addListItem_Click(object sender,EventArgs e)
        {
            var ctrl = (Control)sender;
            var frm = ctrl.FindForm();
            string lbldflt = "list item";
            Label l = new Label();
            TextBox t = new TextBox();
            frm.Controls.OfType<Button>().FirstOrDefault(y => y.Name == "removeListItem").Enabled = true;
            frm.Controls.OfType<Button>().FirstOrDefault(y => y.Name == "olOk").Location = new Point(frm.Controls.OfType<Button>().FirstOrDefault(y => y.Name == "olOk").Location.X, frm.Controls.OfType<Button>().FirstOrDefault(y => y.Name == "olOk").Location.Y + 30);
            frm.Controls.OfType<Button>().FirstOrDefault(y => y.Name == "olCancel").Location = new Point(frm.Controls.OfType<Button>().FirstOrDefault(y => y.Name == "olCancel").Location.X, frm.Controls.OfType<Button>().FirstOrDefault(y => y.Name == "olCancel").Location.Y + 30);
            l.Text = lbldflt + " " + indexO;
            l.Width = frm.Controls.OfType<Label>().FirstOrDefault(y => y.Name == "label1").Width + 15;
            l.Location = new Point(frm.Controls.OfType<Label>().FirstOrDefault(y => y.Name == "label1").Location.X, frm.Controls.OfType<Label>().FirstOrDefault(y => y.Name == "label1").Location.Y + 30 * indexO);
            l.Name = "lbl" + indexO;
            t.Name = "txt" + indexO;
            t.Width = frm.Controls.OfType<TextBox>().FirstOrDefault(y => y.Name == "listItem").Width;
            t.Location = new Point(frm.Controls.OfType<TextBox>().FirstOrDefault(y => y.Name == "listItem").Location.X, frm.Controls.OfType<TextBox>().FirstOrDefault(y => y.Name == "listItem").Location.Y + 30 * indexO);
            indexO++;
            if (indexO > 9)
            {
                frm.Controls.OfType<Button>().FirstOrDefault(y => y.Name == "addListItem").Enabled = false;
            }
            frm.Controls.Add(l);
            frm.Controls.Add(t);
            frm.Height += 30;
        }
        private void removeListItem_Click(object sender,EventArgs e)
        {
            var ctrl = (Control)sender;
            var frm = ctrl.FindForm();
            if (indexO > 1)
            {
                frm.Controls.OfType<Button>().FirstOrDefault(y => y.Name == "addListItem").Enabled = true;
                frm.Controls.OfType<Button>().FirstOrDefault(y => y.Name == "olOk").Location = new Point(frm.Controls.OfType<Button>().FirstOrDefault(y => y.Name == "olOk").Location.X, frm.Controls.OfType<Button>().FirstOrDefault(y => y.Name == "olOk").Location.Y - 30);
                frm.Controls.OfType<Button>().FirstOrDefault(y => y.Name == "olCancel").Location = new Point(frm.Controls.OfType<Button>().FirstOrDefault(y => y.Name == "olCancel").Location.X, frm.Controls.OfType<Button>().FirstOrDefault(y => y.Name == "olCancel").Location.Y - 30);
                indexO--;
                frm.Controls.RemoveByKey("txt" + indexO);
                frm.Controls.RemoveByKey("lbl" + indexO);
                frm.Height -= 30;
            }
            if (indexO == 1)
            {
                frm.Controls.OfType<Button>().FirstOrDefault(y => y.Name == "removeListItem").Enabled = false;
            }
        }
        private void aboutImage_Click(object sender,EventArgs e)
        {
            var ctrl = (Control)sender;
            var frm = ctrl.FindForm();
            frm.Close();
        }
        private void phpEchoOk_Click(object sender,EventArgs e)
        {
            var ctrl = (Control)sender;
            var frm = ctrl.FindForm();
            textArea.SelectedText = string.Format("echo \"{0}\";\n", frm.Controls.OfType<TextBox>().FirstOrDefault(y => y.Name == "phpEchoText").Text);
            frm.Close();
        }
        private void phpEchoCancel_Click(object sender,EventArgs e)
        {
            var ctrl = (Control)sender;
            var frm = ctrl.FindForm();
            frm.Close();
        }
        private void phpRequireCancel_Click(object sender,EventArgs e)
        {
            var ctrl = (Control)sender;
            var frm = ctrl.FindForm();
            frm.Close();
        }
        private void requireSelect_Click(object sender,EventArgs e)
        {
            var ctrl = (Control)sender;
            var frm = ctrl.FindForm();
            OpenFileDialog url_open = new OpenFileDialog();
            url_open.Filter = ("PHP files | *.php");
            url_open.Title = "Select file to require";
            url_open.ShowDialog();
            string urlName = url_open.FileName;
            frm.Controls.OfType<TextBox>().FirstOrDefault(y => y.Name == "requireURL").Text = urlName;
        }
        private void phpRequireOk_Click(object sender,EventArgs e)
        {
            var ctrl = (Control)sender;
            var frm = ctrl.FindForm();
            if (frm.Controls.OfType<TextBox>().FirstOrDefault(y => y.Name == "requireURL").Text != String.Empty)
            {
                if (textArea.Find("<?php") != -1)
                {
                    StringBuilder sb1 = new StringBuilder("<?php");
                    if (frm.Controls.OfType<CheckBox>().FirstOrDefault(y => y.Name == "onceCheck").Checked)//onceCheck)
                    {
                        sb1.Insert(5, string.Format("\nrequire_once '{0}';\n", frm.Controls.OfType<TextBox>().FirstOrDefault(y => y.Name == "requireURL").Text));
                    }
                    else
                    {
                        sb1.Insert(5, string.Format("\nrequire '{0}';\n", frm.Controls.OfType<TextBox>().FirstOrDefault(y => y.Name == "requireURL").Text));
                    }
                    textArea.SelectedText = sb1.ToString();
                }
                frm.Close();
            }
            else
            {
                MessageBox.Show("Select file!", "Warning!");
            }
        }
        private void phpIncludeOk_Click(object sender, EventArgs e)
        {
            var ctrl = (Control)sender;
            var frm = ctrl.FindForm();
            if (frm.Controls.OfType<TextBox>().FirstOrDefault(y => y.Name == "includeURL").Text != String.Empty )
            {
              if (textArea.Find("<?php") != -1)
                    {
                        StringBuilder sb1 = new StringBuilder("<?php");
                        if(frm.Controls.OfType<CheckBox>().FirstOrDefault(y => y.Name == "onceCheck").Checked)//onceCheck)
                        {
                            sb1.Insert(5, string.Format("\ninclude_once '{0}';\n", frm.Controls.OfType<TextBox>().FirstOrDefault(y => y.Name == "includeURL").Text));
                        }
                        else
                        {
                            sb1.Insert(5, string.Format("\ninclude '{0}';\n", frm.Controls.OfType<TextBox>().FirstOrDefault(y => y.Name == "includeURL").Text));
                        }
                        textArea.SelectedText = sb1.ToString();
                    }
                    frm.Close();
            }
            else
            {
                MessageBox.Show("Select file!","Warning!");
            }
        }
        private void includeSelect_Click(object sender,EventArgs e)
        {
            var ctrl = (Control)sender;
            var frm = ctrl.FindForm();
            OpenFileDialog url_open = new OpenFileDialog();
            url_open.Filter = ("PHP files | *.php");
            url_open.Title = "Select file to include";
            url_open.ShowDialog();
            string urlName = url_open.FileName;
            frm.Controls.OfType<TextBox>().FirstOrDefault(y => y.Name == "includeURL").Text= urlName;
        }
        private void phpIncludeCancel_Click(object sender,EventArgs e)
        {
            var ctrl = (Control)sender;
            var frm = ctrl.FindForm();
            frm.Close();
        }
        private void functionOK_Click(object sender,EventArgs e)
        {
            var ctrl = (Control)sender;
            var frm = ctrl.FindForm();
            textArea.SelectedText = string.Format("function {0}() {{\n\n}}", frm.Controls.OfType<TextBox>().FirstOrDefault(y => y.Name == "functionName").Text);
            frm.Close();
        }
        private void functionCancel_Click(object sender,EventArgs e)
        {
            var ctrl = (Control)sender;
            var frm = ctrl.FindForm();
            frm.Close();
        }
        private void classOK_Click(object sender,EventArgs e)
        {
            var ctrl = (Control)sender;
            var frm = ctrl.FindForm();
            textArea.SelectedText = string.Format("class {0} {{\n\n}}", frm.Controls.OfType<TextBox>().FirstOrDefault(y => y.Name == "phpclassName").Text);
            frm.Close();
        }
        private void classCancel_Click(object sender,EventArgs e)
        {
            var ctrl = (Control)sender;
            var frm = ctrl.FindForm();
            frm.Close();
        }
        private void counterType_SelectedIndexChanged(object sender,EventArgs e)
        {
            var ctrl = (Control)sender;
            var frm = ctrl.FindForm();
            int index = frm.Controls.OfType<ListBox>().FirstOrDefault(y => y.Name == "counterType").SelectedIndex;
            switch (index)
            {
                case 0:
                    frm.Controls.OfType<TextBox>().FirstOrDefault(y => y.Name == "counterVariable").Enabled = false;
                    frm.Controls.OfType<NumericUpDown>().FirstOrDefault(y => y.Name == "counterNUD").Enabled = false;
                    break;
                case 1:
                    frm.Controls.OfType<TextBox>().FirstOrDefault(y => y.Name == "counterVariable").Enabled = false;
                    frm.Controls.OfType<TextBox>().FirstOrDefault(y => y.Name == "counterVariable").Visible = false;
                    frm.Controls.OfType<NumericUpDown>().FirstOrDefault(y => y.Name == "counterNUD").Enabled = true;
                    frm.Controls.OfType<NumericUpDown>().FirstOrDefault(y => y.Name == "counterNUD").Visible = true;
                    break;
                case 2:
                    frm.Controls.OfType<TextBox>().FirstOrDefault(y => y.Name == "counterVariable").Enabled = true;
                    frm.Controls.OfType<TextBox>().FirstOrDefault(y => y.Name == "counterVariable").Visible = true;
                    frm.Controls.OfType<NumericUpDown>().FirstOrDefault(y => y.Name == "counterNUD").Enabled = false;
                    frm.Controls.OfType<NumericUpDown>().FirstOrDefault(y => y.Name == "counterNUD").Visible = false;
                    break;
            }
        }
        private void counterOK_Click(object sender,EventArgs e)
        {
            var ctrl = (Control)sender;
            var frm = ctrl.FindForm();
            int index1 = frm.Controls.OfType<ComboBox>().FirstOrDefault(y => y.Name == "counters").SelectedIndex;
            string value = string.Empty;
            switch (index1)
            {
                case 0:
                    value = frm.Controls.OfType<ComboBox>().FirstOrDefault(y => y.Name == "counters").SelectedItem.ToString();
                    break;
                case 1:
                    value = frm.Controls.OfType<ComboBox>().FirstOrDefault(y => y.Name == "counters").SelectedItem.ToString();
                    break;
            }
            int index2 = frm.Controls.OfType<ListBox>().FirstOrDefault(y => y.Name == "counterType").SelectedIndex;
            switch (index2)
            {
                case 0:
                    textArea.SelectedText = string.Format("{0}: {1};\n",value, frm.Controls.OfType<ListBox>().FirstOrDefault(y => y.Name == "counterType").SelectedItem);
                    break;
                case 1:
                    textArea.SelectedText = string.Format("{0}: {1};\n", value, frm.Controls.OfType<NumericUpDown>().FirstOrDefault(y => y.Name == "counterNUD").Value);
                    break;
                case 2:
                    textArea.SelectedText = string.Format("{0}: {1};\n", value, frm.Controls.OfType<TextBox>().FirstOrDefault(y => y.Name == "counterVariable").Text);
                    break;
            }
            frm.Close();
        }
        private void counterCancel_Click(object sender,EventArgs e)
        {
            var ctrl = (Control)sender;
            var frm = ctrl.FindForm();
            frm.Close();
        }
        private void contentOK_Click(object sender,EventArgs e)
        {
            var ctrl = (Control)sender;
            var frm = ctrl.FindForm();
            int index = frm.Controls.OfType<ComboBox>().FirstOrDefault(y => y.Name == "contentType").SelectedIndex;
            switch (index)
            {
                case 0:
                    textArea.SelectedText = string.Format("content: url({0});\n", frm.Controls.OfType<TextBox>().FirstOrDefault(y => y.Name == "contentTypeVal").Text);
                    break;
                case 1:
                    textArea.SelectedText = string.Format("content: attr({0});\n", frm.Controls.OfType<TextBox>().FirstOrDefault(y => y.Name == "contentTypeVal").Text);
                    break;
                case 2:
                    textArea.SelectedText = string.Format("content: {0};\n", frm.Controls.OfType<ComboBox>().FirstOrDefault(y => y.Name == "contentType").SelectedItem);
                    break;
                case 3:
                    textArea.SelectedText = string.Format("content: \"{0}\";\n", frm.Controls.OfType<TextBox>().FirstOrDefault(y => y.Name == "contentTypeVal").Text);
                    break;
                case 4:
                    textArea.SelectedText = string.Format("content: {0};\n", frm.Controls.OfType<ComboBox>().FirstOrDefault(y => y.Name == "contentType").SelectedItem);
                    break;
                case 5:
                    textArea.SelectedText = string.Format("content: counter({0});\n", frm.Controls.OfType<TextBox>().FirstOrDefault(y => y.Name == "contentTypeVal").Text);
                    break;
                case 6:
                    textArea.SelectedText = string.Format("content: {0};\n", frm.Controls.OfType<ComboBox>().FirstOrDefault(y => y.Name == "contentType").SelectedItem);
                    break;
                case 7:
                    textArea.SelectedText = string.Format("content: {0};\n", frm.Controls.OfType<ComboBox>().FirstOrDefault(y => y.Name == "contentType").SelectedItem);
                    break;
                case 8:
                    textArea.SelectedText = string.Format("content: {0};\n", frm.Controls.OfType<ComboBox>().FirstOrDefault(y => y.Name == "contentType").SelectedItem);
                    break;
                case 9:
                    textArea.SelectedText = string.Format("content: {0};\n", frm.Controls.OfType<ComboBox>().FirstOrDefault(y => y.Name == "contentType").SelectedItem);
                    break;
            }
            frm.Close();
        }
        private void contentType_SelectedIndexChanged(object sender,EventArgs e)
        {
            var ctrl = (Control)sender;
            var frm = ctrl.FindForm();
            int index = frm.Controls.OfType<ComboBox>().FirstOrDefault(y => y.Name == "contentType").SelectedIndex;
            switch (index)
            {
                case 0:
                    frm.Height = 148;
                    frm.Controls.OfType<Button>().FirstOrDefault(y => y.Name == "contentOK").Location = new Point(17, 85);
                    frm.Controls.OfType<Button>().FirstOrDefault(y => y.Name == "contentCancel").Location = new Point(57, 85);
                    frm.Controls.OfType<TextBox>().FirstOrDefault(y => y.Name == "contentTypeVal").Visible = true;
                    break;
                case 1:
                    frm.Height = 148;
                    frm.Controls.OfType<Button>().FirstOrDefault(y => y.Name == "contentOK").Location = new Point(17, 85);
                    frm.Controls.OfType<Button>().FirstOrDefault(y => y.Name == "contentCancel").Location = new Point(57, 85);
                    frm.Controls.OfType<TextBox>().FirstOrDefault(y => y.Name == "contentTypeVal").Visible = true;
                    break;
                case 2:
                    frm.Height = 121;
                    frm.Controls.OfType<Button>().FirstOrDefault(y => y.Name == "contentOK").Location = new Point(17, 55);
                    frm.Controls.OfType<Button>().FirstOrDefault(y => y.Name == "contentCancel").Location = new Point(57, 55);
                    frm.Controls.OfType<TextBox>().FirstOrDefault(y => y.Name == "contentTypeVal").Visible = false;
                    break;
                case 3:
                    frm.Height = 148;
                    frm.Controls.OfType<Button>().FirstOrDefault(y => y.Name == "contentOK").Location = new Point(17, 85);
                    frm.Controls.OfType<Button>().FirstOrDefault(y => y.Name == "contentCancel").Location = new Point(57, 85);
                    frm.Controls.OfType<TextBox>().FirstOrDefault(y => y.Name == "contentTypeVal").Visible = true;
                    break;
                case 4:
                    frm.Height = 121;
                    frm.Controls.OfType<Button>().FirstOrDefault(y => y.Name == "contentOK").Location = new Point(17, 55);
                    frm.Controls.OfType<Button>().FirstOrDefault(y => y.Name == "contentCancel").Location = new Point(57, 55);
                    frm.Controls.OfType<TextBox>().FirstOrDefault(y => y.Name == "contentTypeVal").Visible = false;
                    break;
                case 5:
                    frm.Height = 148;
                    frm.Controls.OfType<Button>().FirstOrDefault(y => y.Name == "contentOK").Location = new Point(17, 85);
                    frm.Controls.OfType<Button>().FirstOrDefault(y => y.Name == "contentCancel").Location = new Point(57, 85);
                    frm.Controls.OfType<TextBox>().FirstOrDefault(y => y.Name == "contentTypeVal").Visible = true;
                    break;
                case 6:
                    frm.Height = 121;
                    frm.Controls.OfType<Button>().FirstOrDefault(y => y.Name == "contentOK").Location = new Point(17, 55);
                    frm.Controls.OfType<Button>().FirstOrDefault(y => y.Name == "contentCancel").Location = new Point(57, 55);
                    frm.Controls.OfType<TextBox>().FirstOrDefault(y => y.Name == "contentTypeVal").Visible = false;
                    break;
                case 7:
                    frm.Height = 121;
                    frm.Controls.OfType<Button>().FirstOrDefault(y => y.Name == "contentOK").Location = new Point(17, 55);
                    frm.Controls.OfType<Button>().FirstOrDefault(y => y.Name == "contentCancel").Location = new Point(57, 55);
                    frm.Controls.OfType<TextBox>().FirstOrDefault(y => y.Name == "contentTypeVal").Visible = false;
                    break;
                case 8:
                    frm.Height = 121;
                    frm.Controls.OfType<Button>().FirstOrDefault(y => y.Name == "contentOK").Location = new Point(17, 55);
                    frm.Controls.OfType<Button>().FirstOrDefault(y => y.Name == "contentCancel").Location = new Point(57, 55);
                    frm.Controls.OfType<TextBox>().FirstOrDefault(y => y.Name == "contentTypeVal").Visible = false;
                    break;
                case 9:
                    frm.Height = 121;
                    frm.Controls.OfType<Button>().FirstOrDefault(y => y.Name == "contentOK").Location = new Point(17, 55);
                    frm.Controls.OfType<Button>().FirstOrDefault(y => y.Name == "contentCancel").Location = new Point(57, 55);
                    frm.Controls.OfType<TextBox>().FirstOrDefault(y => y.Name == "contentTypeVal").Visible = false;
                    break;
            }
        }
        private void contentCancel_Click(object sender,EventArgs e)
        {
            var ctrl = (Control)sender;
            var frm = ctrl.FindForm();
            frm.Close();
        }
        private void objectOK_Click(object sender,EventArgs e)
        {
            var ctrl = (Control)sender;
            var frm = ctrl.FindForm();
            textArea.SelectedText = string.Format("object-fit: {0};\n", frm.Controls.OfType<ListBox>().FirstOrDefault(y => y.Name == "objectFitType").SelectedItem);
            frm.Close();
        }
        private void objectCancel_Click(object sender,EventArgs e)
        {
            var ctrl = (Control)sender;
            var frm = ctrl.FindForm();
            frm.Close();
        }
        private void clearOK_Click(object sender,EventArgs e)
        {
            var ctrl = (Control)sender;
            var frm = ctrl.FindForm();
            textArea.SelectedText = string.Format("clear: {0};\n", frm.Controls.OfType<ComboBox>().FirstOrDefault(y => y.Name == "clearType").SelectedItem);
            frm.Close();
        }
        private void clearCancel_Click(object sender,EventArgs e)
        {
            var ctrl = (Control)sender;
            var frm = ctrl.FindForm();
            frm.Close();
        }
        private void cursorOK_Click(object sender,EventArgs e)
        {
            var ctrl = (Control)sender;
            var frm = ctrl.FindForm();
            if (frm.Controls.OfType<ComboBox>().FirstOrDefault(y => y.Name == "systemcur").Enabled == true)
            {
                textArea.SelectedText = string.Format("cursor: {0};\n", frm.Controls.OfType<ComboBox>().FirstOrDefault(y => y.Name == "systemcur").SelectedItem);
            }
            if(frm.Controls.OfType<TextBox>().FirstOrDefault(y => y.Name == "cursorURL").Enabled == true)
            {
                textArea.SelectedText = string.Format("cursor: url({0});\n", frm.Controls.OfType<TextBox>().FirstOrDefault(y => y.Name == "cursorURL").Text);
            }
            frm.Close();
        }
        private void systemcur_TextChanged(object sender,EventArgs e)
        {
            var ctrl = (Control)sender;
            var frm = ctrl.FindForm();
            if (frm.Controls.OfType<ComboBox>().FirstOrDefault(y => y.Name == "systemcur").Text == "")
            {
                frm.Controls.OfType<TextBox>().FirstOrDefault(y => y.Name == "cursorURL").Enabled = true;
            }
            else
            {
                frm.Controls.OfType<TextBox>().FirstOrDefault(y => y.Name == "cursorURL").Enabled = false;
            }
        }
        private void systemcur_SelectedIndexChanged(object sender,EventArgs e)
        {
            var ctrl = (Control)sender;
            var frm = ctrl.FindForm();
            if (frm.Controls.OfType<ComboBox>().FirstOrDefault(y => y.Name == "systemcur").SelectedIndex > 0)
            {
                frm.Controls.OfType<TextBox>().FirstOrDefault(y => y.Name == "cursorURL").Enabled = false;
            }
            int index = frm.Controls.OfType<ComboBox>().FirstOrDefault(y => y.Name == "systemcur").SelectedIndex;
            switch (index)
            {
                case 0:
                    frm.Controls.OfType<PictureBox>().FirstOrDefault(y => y.Name == "cursorPic").Image = global::Loxie.Properties.Resources.cur__1_;
                    break;
                case 1:
                    frm.Controls.OfType<PictureBox>().FirstOrDefault(y => y.Name == "cursorPic").Image = global::Loxie.Properties.Resources.cur__2_;
                    break;
                case 2:
                    frm.Controls.OfType<PictureBox>().FirstOrDefault(y => y.Name == "cursorPic").Image = global::Loxie.Properties.Resources.cur__3_;
                    break;
                case 3:
                    frm.Controls.OfType<PictureBox>().FirstOrDefault(y => y.Name == "cursorPic").Image = global::Loxie.Properties.Resources.cur__4_;
                    break;
                case 4:
                    frm.Controls.OfType<PictureBox>().FirstOrDefault(y => y.Name == "cursorPic").Image = global::Loxie.Properties.Resources.cur__5_;
                    break;
                case 5:
                    frm.Controls.OfType<PictureBox>().FirstOrDefault(y => y.Name == "cursorPic").Image = global::Loxie.Properties.Resources.cur__6_;
                    break;
                case 6:
                    frm.Controls.OfType<PictureBox>().FirstOrDefault(y => y.Name == "cursorPic").Image = global::Loxie.Properties.Resources.cur__7_;
                    break;
                case 7:
                    frm.Controls.OfType<PictureBox>().FirstOrDefault(y => y.Name == "cursorPic").Image = global::Loxie.Properties.Resources.cur__8_;
                    break;
                case 8:
                    frm.Controls.OfType<PictureBox>().FirstOrDefault(y => y.Name == "cursorPic").Image = global::Loxie.Properties.Resources.cur__9_;
                    break;
                case 9:
                    frm.Controls.OfType<PictureBox>().FirstOrDefault(y => y.Name == "cursorPic").Image = global::Loxie.Properties.Resources.cur__10_;
                    break;
                case 10:
                    frm.Controls.OfType<PictureBox>().FirstOrDefault(y => y.Name == "cursorPic").Image = global::Loxie.Properties.Resources.cur__11_;
                    break;
                case 11:
                    frm.Controls.OfType<PictureBox>().FirstOrDefault(y => y.Name == "cursorPic").Image = global::Loxie.Properties.Resources.cur__12_;
                    break;
                case 12:
                    frm.Controls.OfType<PictureBox>().FirstOrDefault(y => y.Name == "cursorPic").Image = global::Loxie.Properties.Resources.cur__13_;
                    break;
                case 13:
                    frm.Controls.OfType<PictureBox>().FirstOrDefault(y => y.Name == "cursorPic").Image = global::Loxie.Properties.Resources.cur__14_;
                    break;
                case 14:
                    frm.Controls.OfType<PictureBox>().FirstOrDefault(y => y.Name == "cursorPic").Image = global::Loxie.Properties.Resources.cur__15_;
                    break;
                case 15:
                    frm.Controls.OfType<PictureBox>().FirstOrDefault(y => y.Name == "cursorPic").Image = global::Loxie.Properties.Resources.cur__16_;
                    break;
                case 16:
                    frm.Controls.OfType<PictureBox>().FirstOrDefault(y => y.Name == "cursorPic").Image = global::Loxie.Properties.Resources.cur__17_;
                    break;
                case 17:
                    frm.Controls.OfType<PictureBox>().FirstOrDefault(y => y.Name == "cursorPic").Image = global::Loxie.Properties.Resources.cur__18_;
                    break;
                case 18:
                    frm.Controls.OfType<PictureBox>().FirstOrDefault(y => y.Name == "cursorPic").Image = global::Loxie.Properties.Resources.cur__19_;
                    break;
                case 19:
                    frm.Controls.OfType<PictureBox>().FirstOrDefault(y => y.Name == "cursorPic").Image = global::Loxie.Properties.Resources.cur__20_;
                    break;
                case 20:
                    frm.Controls.OfType<PictureBox>().FirstOrDefault(y => y.Name == "cursorPic").Image = global::Loxie.Properties.Resources.cur__21_;
                    break;
                case 21:
                    frm.Controls.OfType<PictureBox>().FirstOrDefault(y => y.Name == "cursorPic").Image = global::Loxie.Properties.Resources.cur__22_;
                    break;
                case 22:
                    frm.Controls.OfType<PictureBox>().FirstOrDefault(y => y.Name == "cursorPic").Image = global::Loxie.Properties.Resources.cur__23_;
                    break;
                case 23:
                    frm.Controls.OfType<PictureBox>().FirstOrDefault(y => y.Name == "cursorPic").Image = global::Loxie.Properties.Resources.cur__24_;
                    break;
                case 24:
                    frm.Controls.OfType<PictureBox>().FirstOrDefault(y => y.Name == "cursorPic").Image = global::Loxie.Properties.Resources.cur__25_;
                    break;
                case 25:
                    frm.Controls.OfType<PictureBox>().FirstOrDefault(y => y.Name == "cursorPic").Image = global::Loxie.Properties.Resources.cur__26_;
                    break;
                case 26:
                    frm.Controls.OfType<PictureBox>().FirstOrDefault(y => y.Name == "cursorPic").Image = global::Loxie.Properties.Resources.cur__27_;
                    break;
                case 27:
                    frm.Controls.OfType<PictureBox>().FirstOrDefault(y => y.Name == "cursorPic").Image = global::Loxie.Properties.Resources.cur__28_;
                    break;
                case 28:
                    frm.Controls.OfType<PictureBox>().FirstOrDefault(y => y.Name == "cursorPic").Image = global::Loxie.Properties.Resources.cur__29_;
                    break;
                case 29:
                    frm.Controls.OfType<PictureBox>().FirstOrDefault(y => y.Name == "cursorPic").Image = global::Loxie.Properties.Resources.cur__30_;
                    break;
                case 30:
                    frm.Controls.OfType<PictureBox>().FirstOrDefault(y => y.Name == "cursorPic").Image = global::Loxie.Properties.Resources.cur__31_;
                    break;
                case 31:
                    frm.Controls.OfType<PictureBox>().FirstOrDefault(y => y.Name == "cursorPic").Image = global::Loxie.Properties.Resources.cur__32_;
                    break;
            }
        }
        private void cursorSelect_Click(object sender,EventArgs e)
        {
            OpenFileDialog cursorOpen = new OpenFileDialog();
            cursorOpen.Filter = ("Cursor files | *.cur;*.gif;*.png;*.jpg");
            cursorOpen.Title = "Select cursor file";
            if (cursorOpen.ShowDialog() != DialogResult.Cancel)
            {
                string cursorURL = cursorOpen.FileName;
                var ctrl = (Control)sender;
                var frm = ctrl.FindForm();
                frm.Controls.OfType<TextBox>().FirstOrDefault(y => y.Name == "cursorURL").Text = cursorURL;
                frm.Controls.OfType<TextBox>().FirstOrDefault(y => y.Name == "cursorURL").Enabled = true;
                frm.Controls.OfType<PictureBox>().FirstOrDefault(y => y.Name == "cursorPic").Load(cursorURL);
            }
        }
        private void cursorURL_TextChanged(object sender,EventArgs e)
        {
            var ctrl = (Control)sender;
            var frm = ctrl.FindForm();
            if (frm.Controls.OfType<TextBox>().FirstOrDefault(y => y.Name == "cursorURL").Text != String.Empty)
            {
                frm.Controls.OfType<ComboBox>().FirstOrDefault(y => y.Name == "systemcur").Enabled = false;
            }
            else
            {
                frm.Controls.OfType<ComboBox>().FirstOrDefault(y => y.Name == "systemcur").Enabled = true;
            }
        }
        private void cursorCancel_Click(object sender,EventArgs e)
        {
            var ctrl = (Control)sender;
            var frm = ctrl.FindForm();
            frm.Close();
        }
        private void letterOK_Click(object sender,EventArgs e)
        {
            var ctrl = (Control)sender;
            var frm = ctrl.FindForm();
            int Index = frm.Controls.OfType<ComboBox>().FirstOrDefault(y => y.Name == "spacingType").SelectedIndex;
            switch (Index)
            {
                case 0:
                    textArea.SelectedText = "letter-spacing: normal;\n";
                    break;
                case 1:
                    textArea.SelectedText = string.Format("letter-spascing: {0}px;\n", frm.Controls.OfType<NumericUpDown>().FirstOrDefault(y => y.Name == "spacingValNUD").Value);
                    break;
                case 2:
                    textArea.SelectedText = string.Format("letter-spascing: {0}%;\n", frm.Controls.OfType<NumericUpDown>().FirstOrDefault(y => y.Name == "spacingValNUD").Value);
                    break;
            }
            frm.Close();
        }
        private void spacingType_SelectedIndexChanged(object sender,EventArgs e)
        {
            var ctrl = (Control)sender;
            var frm = ctrl.FindForm();
            int Index = frm.Controls.OfType<ComboBox>().FirstOrDefault(y => y.Name == "spacingType").SelectedIndex;
            switch (Index)
            {
                case 0:
                    frm.Controls.OfType<NumericUpDown>().FirstOrDefault(y => y.Name == "spacingValNUD").Enabled = false;
                    frm.Controls.OfType<Label>().FirstOrDefault(y => y.Name == "label1").Text = "";
                    break;
                case 1:
                    frm.Controls.OfType<NumericUpDown>().FirstOrDefault(y => y.Name == "spacingValNUD").Enabled = true;
                    frm.Controls.OfType<NumericUpDown>().FirstOrDefault(y => y.Name == "spacingValNUD").Maximum = 8192;
                    frm.Controls.OfType<Label>().FirstOrDefault(y => y.Name == "label1").Text = "px";
                    break;
                case 2:
                    frm.Controls.OfType<NumericUpDown>().FirstOrDefault(y => y.Name == "spacingValNUD").Enabled = true;
                    frm.Controls.OfType<NumericUpDown>().FirstOrDefault(y => y.Name == "spacingValNUD").Maximum = 100;
                    frm.Controls.OfType<Label>().FirstOrDefault(y => y.Name == "label1").Text = "%";
                    break;
            }
        }
        private void letterCancel_Click(object sender,EventArgs e)
        {
            var ctrl = (Control)sender;
            var frm = ctrl.FindForm();
            frm.Close();
        }
        private void resizeOK_Click(object sender,EventArgs e)
        {
            var ctrl = (Control)sender;
            var frm = ctrl.FindForm();
            textArea.SelectedText = string.Format("resize: {0};\n", frm.Controls.OfType<ListBox>().FirstOrDefault(y => y.Name == "resizeVal").SelectedItem);
            frm.Close();
        }
        private void resizeCancel_Click(object sender,EventArgs e)
        {
            var ctrl = (Control)sender;
            var frm = ctrl.FindForm();
            frm.Close();
        }
        public void whiteOK_Click(object sender,EventArgs e)
        {
            var ctrl = (Control)sender;
            var frm = ctrl.FindForm();
            textArea.SelectedText = string.Format("white-space: {0};\n", frm.Controls.OfType<ListBox>().FirstOrDefault(y => y.Name == "whiteType").SelectedItem);
            frm.Close();    
        }
        public void whiteCancel_Click(object sender,EventArgs e)
        {
            var ctrl = (Control)sender;
            var frm = ctrl.FindForm();
            frm.Close();
        }
        private void quotesOK_Click(object sender,EventArgs e)
        {
            var ctrl = (Control)sender;
            var frm = ctrl.FindForm();
            int index = frm.Controls.OfType<ListBox>().FirstOrDefault(y => y.Name == "quotesType").SelectedIndex;
            switch (index)
            {
                case 0:
                    textArea.SelectedText = string.Format("quotes : \"{0}\" \"{1}\";\n", frm.Controls.OfType<Label>().FirstOrDefault(y => y.Name == "label1").Text, frm.Controls.OfType<Label>().FirstOrDefault(y => y.Name == "label2").Text);
                    break;
                case 1:
                    textArea.SelectedText = string.Format("quotes : \"{0}\" \"{1}\";\n", frm.Controls.OfType<Label>().FirstOrDefault(y => y.Name == "label1").Text, frm.Controls.OfType<Label>().FirstOrDefault(y => y.Name == "label2").Text);
                    break;
                case 2:
                    textArea.SelectedText = string.Format("quotes : \"{0}\" \"{1}\";\n", frm.Controls.OfType<Label>().FirstOrDefault(y => y.Name == "label1").Text, frm.Controls.OfType<Label>().FirstOrDefault(y => y.Name == "label2").Text);
                    break;
                case 3:
                    textArea.SelectedText = string.Format("quotes : \"{0}\" \"{1}\";\n", frm.Controls.OfType<Label>().FirstOrDefault(y => y.Name == "label1").Text, frm.Controls.OfType<Label>().FirstOrDefault(y => y.Name == "label2").Text);
                    break;
                case 4:
                    textArea.SelectedText = string.Format("quotes : \"{0}\" \"{1}\";\n", frm.Controls.OfType<Label>().FirstOrDefault(y => y.Name == "label1").Text, frm.Controls.OfType<Label>().FirstOrDefault(y => y.Name == "label2").Text);
                    break;
            }
            frm.Close();
        }
        private void quotesType_SelectedIndexChanged(object sender,EventArgs e)
        {
            var ctrl = (Control)sender;
            var frm = ctrl.FindForm();
            int index = frm.Controls.OfType<ListBox>().FirstOrDefault(y => y.Name == "quotesType").SelectedIndex;
            switch (index)
            {
                case 0:
                    frm.Controls.OfType<Label>().FirstOrDefault(y => y.Name == "label1").Text = "\\0022";
                    frm.Controls.OfType<Label>().FirstOrDefault(y => y.Name == "label2").Text = "\\0022";
                    break;
                case 1:
                    frm.Controls.OfType<Label>().FirstOrDefault(y => y.Name == "label1").Text = "\\0027";
                    frm.Controls.OfType<Label>().FirstOrDefault(y => y.Name == "label2").Text = "\\0027";
                    break;
                case 2:
                    frm.Controls.OfType<Label>().FirstOrDefault(y => y.Name == "label1").Text = "\\00ab";
                    frm.Controls.OfType<Label>().FirstOrDefault(y => y.Name == "label2").Text = "\\00bb";
                    break;
                case 3:
                    frm.Controls.OfType<Label>().FirstOrDefault(y => y.Name == "label1").Text = "\\2018";
                    frm.Controls.OfType<Label>().FirstOrDefault(y => y.Name == "label2").Text = "\\2019";
                    break;
                case 4:
                    frm.Controls.OfType<Label>().FirstOrDefault(y => y.Name == "label1").Text = "\\201c";
                    frm.Controls.OfType<Label>().FirstOrDefault(y => y.Name == "label2").Text = "\\201d";
                    break;
            }
        }
        private void quotesCancel_Click(object sender,EventArgs e)
        {
            var ctrl = (Control)sender;
            var frm = ctrl.FindForm();
            frm.Close();
        }
        private void visibilityOK_Click(object sender,EventArgs e)
        {
            var ctrl = (Control)sender;
            var frm = ctrl.FindForm();
            textArea.SelectedText = string.Format("visibility: {0};\n",frm.Controls.OfType<ListBox>().FirstOrDefault(y => y.Name == "visibilityVal").SelectedItem);
            frm.Close();
        }
        private void visibilityCancel_Click(object sender,EventArgs e)
        {
            var ctrl = (Control)sender;
            var frm = ctrl.FindForm();
            frm.Close();
        }
        private void wordOK_Click(object sender, EventArgs e)
        {
            var ctrl = (Control)sender;
            var frm = ctrl.FindForm();
            if (frm.Controls.OfType<RadioButton>().FirstOrDefault(y => y.Name == "bNormal").Checked == true)
            {
                textArea.SelectedText = string.Format("word-break: normal;\n", frm.Controls.OfType<RadioButton>().FirstOrDefault(y => y.Name == "bNormal").Text);
            }
            if (frm.Controls.OfType<RadioButton>().FirstOrDefault(y => y.Name == "breakall").Checked == true)
            {
                textArea.SelectedText = string.Format("word-break: break-all;\n", frm.Controls.OfType<RadioButton>().FirstOrDefault(y => y.Name == "breakall").Text);
            }
            if (frm.Controls.OfType<RadioButton>().FirstOrDefault(y => y.Name == "keepall").Checked == true)
            {
                textArea.SelectedText = string.Format("word-break: keep-all;\n", frm.Controls.OfType<RadioButton>().FirstOrDefault(y => y.Name == "keepall").Text);
            }
            int Index = frm.Controls.OfType<ComboBox>().FirstOrDefault(y => y.Name == "wSpacingMeasure").SelectedIndex;
            switch (Index)
            {
                case 0:
                    textArea.SelectedText = "word-spacing: normal;\n";
                    break;
                case 1:
                    textArea.SelectedText = string.Format("word-spacing: {0}px;\n", frm.Controls.OfType<NumericUpDown>().FirstOrDefault(y => y.Name == "wSpacingNUD").Value);
                    break;
                case 2:
                    textArea.SelectedText = string.Format("word-spacing: {0}%;\n", frm.Controls.OfType<NumericUpDown>().FirstOrDefault(y => y.Name == "wSpacingNUD").Value);
                    break;
            }
            int i_index = frm.Controls.OfType<ListBox>().FirstOrDefault(y => y.Name == "wordWrapMeasure").SelectedIndex;
            switch (i_index)
            {
                case 0:
                    textArea.SelectedText = string.Format("word-wrap: {0};\n", frm.Controls.OfType<ListBox>().FirstOrDefault(y => y.Name == "wordWrapMeasure").SelectedItem);
                    break;
                case 1:
                    textArea.SelectedText = string.Format("word-wrap: {0};\n", frm.Controls.OfType<ListBox>().FirstOrDefault(y => y.Name == "wordWrapMeasure").SelectedItem);
                    break;
            }
            frm.Close();
        }
        private void wordCancel_Click(object sender,EventArgs e)
        {
            var ctrl = (Control)sender;
            var frm = ctrl.FindForm();
            frm.Close();
        }
        private void wSpacingMeasure_SelectedIndexChanged(object sender, EventArgs e)
        {
            var ctrl = (Control)sender;
            var frm = ctrl.FindForm();
            int Index = frm.Controls.OfType<ComboBox>().FirstOrDefault(y => y.Name == "wSpacingMeasure").SelectedIndex;
            switch (Index)
            {
                case 0:
                    frm.Controls.OfType<NumericUpDown>().FirstOrDefault(y => y.Name == "wSpacingNUD").Enabled = false;
                    frm.Controls.OfType<Label>().FirstOrDefault(y => y.Name == "label3").Text = "";
                    break;
                case 1:
                    frm.Controls.OfType<NumericUpDown>().FirstOrDefault(y => y.Name == "wSpacingNUD").Enabled = true;
                    frm.Controls.OfType<NumericUpDown>().FirstOrDefault(y => y.Name == "wSpacingNUD").Maximum = 8192;
                    frm.Controls.OfType<Label>().FirstOrDefault(y => y.Name == "label3").Text = "px";
                    break;
                case 2:
                    frm.Controls.OfType<NumericUpDown>().FirstOrDefault(y => y.Name == "wSpacingNUD").Enabled = true;
                    frm.Controls.OfType<NumericUpDown>().FirstOrDefault(y => y.Name == "wSpacingNUD").Maximum = 100;
                    frm.Controls.OfType<Label>().FirstOrDefault(y => y.Name == "label3").Text = "%";
                    break;
            }
        }
        private void originZMeasure_SelectedIndexChanged(object sender, EventArgs e)
        {
            var ctrl = (Control)sender;
            var frm = ctrl.FindForm();
            int Index = frm.Controls.OfType<GroupBox>().FirstOrDefault(y => y.Name == "transformOrigin").Controls.OfType<ComboBox>().FirstOrDefault(y => y.Name == "originZMeasure").SelectedIndex;
            switch (Index)
            {
                case 0:
                    frm.Controls.OfType<GroupBox>().FirstOrDefault(y => y.Name == "transformOrigin").Controls.OfType<NumericUpDown>().FirstOrDefault(y => y.Name == "originZNUD").Maximum = 8192;
                    frm.Controls.OfType<GroupBox>().FirstOrDefault(y => y.Name == "transformOrigin").Controls.OfType<Label>().FirstOrDefault(y => y.Name == "label17").Text = "px";
                    break;
                case 1:
                    frm.Controls.OfType<GroupBox>().FirstOrDefault(y => y.Name == "transformOrigin").Controls.OfType<NumericUpDown>().FirstOrDefault(y => y.Name == "originZNUD").Maximum = 100;
                    frm.Controls.OfType<GroupBox>().FirstOrDefault(y => y.Name == "transformOrigin").Controls.OfType<Label>().FirstOrDefault(y => y.Name == "label17").Text = "%";
                    break;
            }
        }
        private void transformOK_Click(object sender,EventArgs e)
        {
            var ctrl = (Control)sender;
            var frm = ctrl.FindForm();
            if(frm.Controls.OfType<GroupBox>().FirstOrDefault(y => y.Name == "transform").Controls.OfType<NumericUpDown>().FirstOrDefault(y => y.Name == "rotateNUD").Enabled == true && frm.Controls.OfType<GroupBox>().FirstOrDefault(y => y.Name == "transform").Controls.OfType<NumericUpDown>().FirstOrDefault(y => y.Name == "rotateNUD").Value != 0)
            {
                textArea.SelectedText = string.Format("transform: rotate({0}deg);\n", frm.Controls.OfType<GroupBox>().FirstOrDefault(y => y.Name == "transform").Controls.OfType<NumericUpDown>().FirstOrDefault(y => y.Name == "rotateNUD").Value);
            }
            if(frm.Controls.OfType<GroupBox>().FirstOrDefault(y => y.Name == "transform").Controls.OfType<ListBox>().FirstOrDefault(y => y.Name == "scaleXVal").Enabled == true && frm.Controls.OfType<GroupBox>().FirstOrDefault(y => y.Name == "transform").Controls.OfType<ListBox>().FirstOrDefault(y => y.Name == "scaleXVal").SelectedItem != null)
            {
                textArea.SelectedText = string.Format("transform: scaleX({0});\n", frm.Controls.OfType<GroupBox>().FirstOrDefault(y => y.Name == "transform").Controls.OfType<ListBox>().FirstOrDefault(y => y.Name == "scaleXVal").SelectedItem);
            }
            if(frm.Controls.OfType<GroupBox>().FirstOrDefault(y => y.Name == "transform").Controls.OfType<ListBox>().FirstOrDefault(y => y.Name == "scaleYVal").Enabled == true && frm.Controls.OfType<GroupBox>().FirstOrDefault(y => y.Name == "transform").Controls.OfType<ListBox>().FirstOrDefault(y => y.Name == "scaleYVal").SelectedItem != null)
            {
                textArea.SelectedText = string.Format("transform: scaleY({0});\n", frm.Controls.OfType<GroupBox>().FirstOrDefault(y => y.Name == "transform").Controls.OfType<ListBox>().FirstOrDefault(y => y.Name == "scaleYVal").SelectedItem);
            }
            if(frm.Controls.OfType<GroupBox>().FirstOrDefault(y => y.Name == "transform").Controls.OfType<NumericUpDown>().FirstOrDefault(y => y.Name == "skewXNUD").Enabled == true && frm.Controls.OfType<GroupBox>().FirstOrDefault(y => y.Name == "transform").Controls.OfType<NumericUpDown>().FirstOrDefault(y => y.Name == "skewXNUD").Value != 0)
            {
                textArea.SelectedText = string.Format("transform: skewX({0}deg);\n", frm.Controls.OfType<GroupBox>().FirstOrDefault(y => y.Name == "transform").Controls.OfType<NumericUpDown>().FirstOrDefault(y => y.Name == "skewXNUD").Value);
            }
            if (frm.Controls.OfType<GroupBox>().FirstOrDefault(y => y.Name == "transform").Controls.OfType<NumericUpDown>().FirstOrDefault(y => y.Name == "skewYNUD").Enabled == true && frm.Controls.OfType<GroupBox>().FirstOrDefault(y => y.Name == "transform").Controls.OfType<NumericUpDown>().FirstOrDefault(y => y.Name == "skewYNUD").Value != 0)
            {
                textArea.SelectedText = string.Format("transform: skewY({0}deg);\n", frm.Controls.OfType<GroupBox>().FirstOrDefault(y => y.Name == "transform").Controls.OfType<NumericUpDown>().FirstOrDefault(y => y.Name == "skewYNUD").Value);
            }
            if (frm.Controls.OfType<GroupBox>().FirstOrDefault(y => y.Name == "transform").Controls.OfType<NumericUpDown>().FirstOrDefault(y => y.Name == "translateXNUD").Enabled == true && frm.Controls.OfType<GroupBox>().FirstOrDefault(y => y.Name == "transform").Controls.OfType<NumericUpDown>().FirstOrDefault(y => y.Name == "translateXNUD").Value != 0)
            {
                textArea.SelectedText = string.Format("transform: translateX({0}px);\n", frm.Controls.OfType<GroupBox>().FirstOrDefault(y => y.Name == "transform").Controls.OfType<NumericUpDown>().FirstOrDefault(y => y.Name == "translateXNUD").Value);
            }
            if (frm.Controls.OfType<GroupBox>().FirstOrDefault(y => y.Name == "transform").Controls.OfType<NumericUpDown>().FirstOrDefault(y => y.Name == "translateYNUD").Enabled == true && frm.Controls.OfType<GroupBox>().FirstOrDefault(y => y.Name == "transform").Controls.OfType<NumericUpDown>().FirstOrDefault(y => y.Name == "translateYNUD").Value != 0)
            {
                textArea.SelectedText = string.Format("transform: translateY({0}px);\n", frm.Controls.OfType<GroupBox>().FirstOrDefault(y => y.Name == "transform").Controls.OfType<NumericUpDown>().FirstOrDefault(y => y.Name == "translateYNUD").Value);
            }
            if(frm.Controls.OfType<GroupBox>().FirstOrDefault(y => y.Name == "transform").Controls.OfType<CheckBox>().FirstOrDefault(y => y.Name == "noTransformChk").Checked == true)
            {
                textArea.SelectedText = "transform: none;\n";
            }
            if(frm.Controls.OfType<RadioButton>().FirstOrDefault(y=>y.Name== "flat").Checked==true)
            {
                textArea.SelectedText = "transform-style: flat;\n";
            }
            if (frm.Controls.OfType<RadioButton>().FirstOrDefault(y => y.Name == "preserve").Checked == true)
            {
                textArea.SelectedText = "transform-style: preserve-3d;\n";
            }
            string oX = null;
            string oY = null;
            string oZ = null;
            int Index1 = frm.Controls.OfType<GroupBox>().FirstOrDefault(y => y.Name == "transformOrigin").Controls.OfType<ComboBox>().FirstOrDefault(y => y.Name == "originXMeasure").SelectedIndex;
            switch (Index1)
            {
                case 0:
                    oX = frm.Controls.OfType<GroupBox>().FirstOrDefault(y => y.Name == "transformOrigin").Controls.OfType<ComboBox>().FirstOrDefault(y => y.Name == "originXMeasure").SelectedItem.ToString();
                    break;
                case 1:
                    oX = frm.Controls.OfType<GroupBox>().FirstOrDefault(y => y.Name == "transformOrigin").Controls.OfType<ComboBox>().FirstOrDefault(y => y.Name == "originXMeasure").SelectedItem.ToString();
                    break;
                case 2:
                    oX = frm.Controls.OfType<GroupBox>().FirstOrDefault(y => y.Name == "transformOrigin").Controls.OfType<ComboBox>().FirstOrDefault(y => y.Name == "originXMeasure").SelectedItem.ToString();
                    break;
                case 3:
                    oX = frm.Controls.OfType<GroupBox>().FirstOrDefault(y => y.Name == "transformOrigin").Controls.OfType<NumericUpDown>().FirstOrDefault(y => y.Name == "originXNUD").Value+"px";
                    break;
                case 4:
                    oX = frm.Controls.OfType<GroupBox>().FirstOrDefault(y => y.Name == "transformOrigin").Controls.OfType<NumericUpDown>().FirstOrDefault(y => y.Name == "originXNUD").Value+"%";
                    break;
            }
            int Index2 = frm.Controls.OfType<GroupBox>().FirstOrDefault(y => y.Name == "transformOrigin").Controls.OfType<ComboBox>().FirstOrDefault(y => y.Name == "originYMeasure").SelectedIndex;
            switch (Index2)
            {
                case 0:
                    oY = frm.Controls.OfType<GroupBox>().FirstOrDefault(y => y.Name == "transformOrigin").Controls.OfType<ComboBox>().FirstOrDefault(y => y.Name == "originYMeasure").SelectedItem.ToString();
                    break;
                case 1:
                    oY = frm.Controls.OfType<GroupBox>().FirstOrDefault(y => y.Name == "transformOrigin").Controls.OfType<ComboBox>().FirstOrDefault(y => y.Name == "originYMeasure").SelectedItem.ToString();
                    break;
                case 2:
                    oY = frm.Controls.OfType<GroupBox>().FirstOrDefault(y => y.Name == "transformOrigin").Controls.OfType<ComboBox>().FirstOrDefault(y => y.Name == "originYMeasure").SelectedItem.ToString();
                    break;
                case 3:
                    oY = frm.Controls.OfType<GroupBox>().FirstOrDefault(y => y.Name == "transformOrigin").Controls.OfType<NumericUpDown>().FirstOrDefault(y => y.Name == "originYNUD").Value+"px";
                    break;
                case 4:
                    oY = frm.Controls.OfType<GroupBox>().FirstOrDefault(y => y.Name == "transformOrigin").Controls.OfType<NumericUpDown>().FirstOrDefault(y => y.Name == "originYNUD").Value + "%";
                    break;
            }
            int Index3 = frm.Controls.OfType<GroupBox>().FirstOrDefault(y => y.Name == "transformOrigin").Controls.OfType<ComboBox>().FirstOrDefault(y => y.Name == "originZMeasure").SelectedIndex;
            switch (Index3)
            {
                case 0:
                    oZ = frm.Controls.OfType<GroupBox>().FirstOrDefault(y => y.Name == "transformOrigin").Controls.OfType<NumericUpDown>().FirstOrDefault(y => y.Name == "originZNUD").Value+"px";
                    break;
                case 1:
                    oZ = frm.Controls.OfType<GroupBox>().FirstOrDefault(y => y.Name == "transformOrigin").Controls.OfType<NumericUpDown>().FirstOrDefault(y => y.Name == "originZNUD").Value+"%";
                    break;
            }
            if (oX != null && oY != null && oZ != null)
            {
                textArea.SelectedText = string.Format("transform-origin: {0} {1} {2};\n", oX, oY, oZ);
            }
            frm.Close();
        }
        private void originXMeasure_SelectedIndexChanged(object sender,EventArgs e)
        {
            var ctrl = (Control)sender;
            var frm = ctrl.FindForm();
            int Index = frm.Controls.OfType<GroupBox>().FirstOrDefault(y => y.Name == "transformOrigin").Controls.OfType<ComboBox>().FirstOrDefault(y => y.Name == "originXMeasure").SelectedIndex;
            switch (Index)
            {
                case 0:
                    frm.Controls.OfType<GroupBox>().FirstOrDefault(y => y.Name == "transformOrigin").Controls.OfType<NumericUpDown>().FirstOrDefault(y => y.Name == "originXNUD").Enabled = false;
                    frm.Controls.OfType<GroupBox>().FirstOrDefault(y => y.Name == "transformOrigin").Controls.OfType<Label>().FirstOrDefault(y => y.Name == "label18").Text = "";
                    break;
                case 1:
                    frm.Controls.OfType<GroupBox>().FirstOrDefault(y => y.Name == "transformOrigin").Controls.OfType<NumericUpDown>().FirstOrDefault(y => y.Name == "originXNUD").Enabled = false;
                    frm.Controls.OfType<GroupBox>().FirstOrDefault(y => y.Name == "transformOrigin").Controls.OfType<Label>().FirstOrDefault(y => y.Name == "label18").Text = "";
                    break;
                case 2:
                    frm.Controls.OfType<GroupBox>().FirstOrDefault(y => y.Name == "transformOrigin").Controls.OfType<NumericUpDown>().FirstOrDefault(y => y.Name == "originXNUD").Enabled = false;
                    frm.Controls.OfType<GroupBox>().FirstOrDefault(y => y.Name == "transformOrigin").Controls.OfType<Label>().FirstOrDefault(y => y.Name == "label18").Text = "";
                    break;
                case 3:
                    frm.Controls.OfType<GroupBox>().FirstOrDefault(y => y.Name == "transformOrigin").Controls.OfType<NumericUpDown>().FirstOrDefault(y => y.Name == "originXNUD").Enabled = true;
                    frm.Controls.OfType<GroupBox>().FirstOrDefault(y => y.Name == "transformOrigin").Controls.OfType<NumericUpDown>().FirstOrDefault(y => y.Name == "originXNUD").Maximum = 8192;
                    frm.Controls.OfType<GroupBox>().FirstOrDefault(y => y.Name == "transformOrigin").Controls.OfType<Label>().FirstOrDefault(y => y.Name == "label18").Text = "px";
                    break;
                case 4:
                    frm.Controls.OfType<GroupBox>().FirstOrDefault(y => y.Name == "transformOrigin").Controls.OfType<NumericUpDown>().FirstOrDefault(y => y.Name == "originXNUD").Enabled = true;
                    frm.Controls.OfType<GroupBox>().FirstOrDefault(y => y.Name == "transformOrigin").Controls.OfType<NumericUpDown>().FirstOrDefault(y => y.Name == "originXNUD").Maximum = 100;
                    frm.Controls.OfType<GroupBox>().FirstOrDefault(y => y.Name == "transformOrigin").Controls.OfType<Label>().FirstOrDefault(y => y.Name == "label18").Text = "%";
                    break;
            }
        }
        private void originYMeasure_SelectedIndexChanged(object sender,EventArgs e)
        {
            var ctrl = (Control)sender;
            var frm = ctrl.FindForm();
            int Index = frm.Controls.OfType<GroupBox>().FirstOrDefault(y => y.Name == "transformOrigin").Controls.OfType<ComboBox>().FirstOrDefault(y => y.Name == "originYMeasure").SelectedIndex;
            switch (Index)
            {
                case 0:
                    frm.Controls.OfType<GroupBox>().FirstOrDefault(y => y.Name == "transformOrigin").Controls.OfType<NumericUpDown>().FirstOrDefault(y => y.Name == "originYNUD").Enabled = false;
                    frm.Controls.OfType<GroupBox>().FirstOrDefault(y => y.Name == "transformOrigin").Controls.OfType<Label>().FirstOrDefault(y => y.Name == "label19").Text = "";
                    break;
                case 1:
                    frm.Controls.OfType<GroupBox>().FirstOrDefault(y => y.Name == "transformOrigin").Controls.OfType<NumericUpDown>().FirstOrDefault(y => y.Name == "originYNUD").Enabled = false;
                    frm.Controls.OfType<GroupBox>().FirstOrDefault(y => y.Name == "transformOrigin").Controls.OfType<Label>().FirstOrDefault(y => y.Name == "label19").Text = "";
                    break;
                case 2:
                    frm.Controls.OfType<GroupBox>().FirstOrDefault(y => y.Name == "transformOrigin").Controls.OfType<NumericUpDown>().FirstOrDefault(y => y.Name == "originYNUD").Enabled = false;
                    frm.Controls.OfType<GroupBox>().FirstOrDefault(y => y.Name == "transformOrigin").Controls.OfType<Label>().FirstOrDefault(y => y.Name == "label19").Text = "";
                    break;
                case 3:
                    frm.Controls.OfType<GroupBox>().FirstOrDefault(y => y.Name == "transformOrigin").Controls.OfType<NumericUpDown>().FirstOrDefault(y => y.Name == "originYNUD").Enabled = true;
                    frm.Controls.OfType<GroupBox>().FirstOrDefault(y => y.Name == "transformOrigin").Controls.OfType<NumericUpDown>().FirstOrDefault(y => y.Name == "originYNUD").Maximum = 8192;
                    frm.Controls.OfType<GroupBox>().FirstOrDefault(y => y.Name == "transformOrigin").Controls.OfType<Label>().FirstOrDefault(y => y.Name == "label19").Text = "px";
                    break;
                case 4:
                    frm.Controls.OfType<GroupBox>().FirstOrDefault(y => y.Name == "transformOrigin").Controls.OfType<NumericUpDown>().FirstOrDefault(y => y.Name == "originYNUD").Enabled = true;
                    frm.Controls.OfType<GroupBox>().FirstOrDefault(y => y.Name == "transformOrigin").Controls.OfType<NumericUpDown>().FirstOrDefault(y => y.Name == "originYNUD").Maximum = 100;
                    frm.Controls.OfType<GroupBox>().FirstOrDefault(y => y.Name == "transformOrigin").Controls.OfType<Label>().FirstOrDefault(y => y.Name == "label19").Text = "%";
                    break;
            }
        }
        private void noTransformChk_CheckedChanged(object sender,EventArgs e)
        {
            var ctrl = (Control)sender;
            var frm = ctrl.FindForm();
            if(frm.Controls.OfType<GroupBox>().FirstOrDefault(y => y.Name == "transform").Controls.OfType<CheckBox>().FirstOrDefault(y => y.Name == "noTransformChk").Checked == true)
            {
                frm.Controls.OfType<GroupBox>().FirstOrDefault(y => y.Name == "transform").Controls.OfType<NumericUpDown>().FirstOrDefault(y => y.Name == "translateYNUD").Enabled = false;
                frm.Controls.OfType<GroupBox>().FirstOrDefault(y => y.Name == "transform").Controls.OfType<NumericUpDown>().FirstOrDefault(y => y.Name == "translateXNUD").Enabled = false;
                frm.Controls.OfType<GroupBox>().FirstOrDefault(y => y.Name == "transform").Controls.OfType<NumericUpDown>().FirstOrDefault(y => y.Name == "skewYNUD").Enabled = false;
                frm.Controls.OfType<GroupBox>().FirstOrDefault(y => y.Name == "transform").Controls.OfType<NumericUpDown>().FirstOrDefault(y => y.Name == "skewXNUD").Enabled = false;
                frm.Controls.OfType<GroupBox>().FirstOrDefault(y => y.Name == "transform").Controls.OfType<ListBox>().FirstOrDefault(y => y.Name == "scaleYVal").Enabled = false;
                frm.Controls.OfType<GroupBox>().FirstOrDefault(y => y.Name == "transform").Controls.OfType<ListBox>().FirstOrDefault(y => y.Name == "scaleXVal").Enabled = false;
                frm.Controls.OfType<GroupBox>().FirstOrDefault(y => y.Name == "transform").Controls.OfType<NumericUpDown>().FirstOrDefault(y => y.Name == "rotateNUD").Enabled = false;
            }
            else
            {
                frm.Controls.OfType<GroupBox>().FirstOrDefault(y => y.Name == "transform").Controls.OfType<NumericUpDown>().FirstOrDefault(y => y.Name == "translateYNUD").Enabled = true;
                frm.Controls.OfType<GroupBox>().FirstOrDefault(y => y.Name == "transform").Controls.OfType<NumericUpDown>().FirstOrDefault(y => y.Name == "translateXNUD").Enabled = true;
                frm.Controls.OfType<GroupBox>().FirstOrDefault(y => y.Name == "transform").Controls.OfType<NumericUpDown>().FirstOrDefault(y => y.Name == "skewYNUD").Enabled = true;
                frm.Controls.OfType<GroupBox>().FirstOrDefault(y => y.Name == "transform").Controls.OfType<NumericUpDown>().FirstOrDefault(y => y.Name == "skewXNUD").Enabled = true;
                frm.Controls.OfType<GroupBox>().FirstOrDefault(y => y.Name == "transform").Controls.OfType<ListBox>().FirstOrDefault(y => y.Name == "scaleYVal").Enabled = true;
                frm.Controls.OfType<GroupBox>().FirstOrDefault(y => y.Name == "transform").Controls.OfType<ListBox>().FirstOrDefault(y => y.Name == "scaleXVal").Enabled = true;
                frm.Controls.OfType<GroupBox>().FirstOrDefault(y => y.Name == "transform").Controls.OfType<NumericUpDown>().FirstOrDefault(y => y.Name == "rotateNUD").Enabled = true;
            }
        }
        private void transformCancel_Click(object sender,EventArgs e)
        {
            var ctrl = (Control)sender;
            var frm = ctrl.FindForm();
            frm.Close();
        }
        private void pageBreakOk_Click(object sender,EventArgs e)
        {
            var ctrl = (Control)sender;
            var frm = ctrl.FindForm();
            if (frm.Controls.OfType<ComboBox>().FirstOrDefault(y => y.Name == "pagebreakType").SelectedItem != null && frm.Controls.OfType<ListBox>().FirstOrDefault(y => y.Name == "pagebreakVal").SelectedItem != null)
            {
                textArea.SelectedText = string.Format("page-break-{0}: {1};\n", frm.Controls.OfType<ComboBox>().FirstOrDefault(y => y.Name == "pagebreakType").SelectedItem, frm.Controls.OfType<ListBox>().FirstOrDefault(y => y.Name == "pagebreakVal").SelectedItem);
            }
            frm.Close();
        }
        private void pageBreakCancel_Click(object sender,EventArgs e)
        {
            var ctrl = (Control)sender;
            var frm = ctrl.FindForm();
            frm.Close();
        }
        private void pagebreakType_SelectedIndexChanged(object sender,EventArgs e)
        {
            var ctrl = (Control)sender;
            var frm = ctrl.FindForm();
            int Index = frm.Controls.OfType<ComboBox>().FirstOrDefault(y => y.Name == "pagebreakType").SelectedIndex;
            switch (Index)
            {
                case 0:
                    frm.Controls.OfType<ListBox>().FirstOrDefault(y => y.Name == "pagebreakVal").Location = new Point(152, 12);
                    frm.Controls.OfType<ListBox>().FirstOrDefault(y => y.Name == "pagebreakVal").Size = new Size(48, 70);
                    if (frm.Controls.OfType<ListBox>().FirstOrDefault(y => y.Name == "pagebreakVal").FindString("always", -1) != -1)
                    {
                        frm.Focus();
                    }
                    else
                    {
                        frm.Controls.OfType<ListBox>().FirstOrDefault(y => y.Name == "pagebreakVal").Items.Add("always");
                        frm.Controls.OfType<ListBox>().FirstOrDefault(y => y.Name == "pagebreakVal").Items.Add("left");
                        frm.Controls.OfType<ListBox>().FirstOrDefault(y => y.Name == "pagebreakVal").Items.Add("right");
                    }
                    break;
                case 1:
                    frm.Controls.OfType<ListBox>().FirstOrDefault(y => y.Name == "pagebreakVal").Location = new Point(152, 12);
                    frm.Controls.OfType<ListBox>().FirstOrDefault(y => y.Name == "pagebreakVal").Size = new Size(48, 70);
                    if (frm.Controls.OfType<ListBox>().FirstOrDefault(y => y.Name == "pagebreakVal").FindString("always", -1) != -1)
                    {
                        frm.Focus();
                    }
                    else
                    {
                        frm.Controls.OfType<ListBox>().FirstOrDefault(y => y.Name == "pagebreakVal").Items.Add("always");
                        frm.Controls.OfType<ListBox>().FirstOrDefault(y => y.Name == "pagebreakVal").Items.Add("left");
                        frm.Controls.OfType<ListBox>().FirstOrDefault(y => y.Name == "pagebreakVal").Items.Add("right");
                    }
                    break;
                case 2:
                    frm.Controls.OfType<ListBox>().FirstOrDefault(y => y.Name == "pagebreakVal").Location = new Point(152, 35);
                    frm.Controls.OfType<ListBox>().FirstOrDefault(y => y.Name == "pagebreakVal").Size = new Size(40, 30);
                    frm.Controls.OfType<ListBox>().FirstOrDefault(y => y.Name == "pagebreakVal").Items.Remove("always");
                    frm.Controls.OfType<ListBox>().FirstOrDefault(y => y.Name == "pagebreakVal").Items.Remove("left");
                    frm.Controls.OfType<ListBox>().FirstOrDefault(y => y.Name == "pagebreakVal").Items.Remove("right");
                    break;
            }
        }
        private void overflowOK_Click(object sender,EventArgs e)
        {
            var ctrl = (Control)sender;
            var frm = ctrl.FindForm();
            if (frm.Controls.OfType<ListBox>().FirstOrDefault(y => y.Name == "overflows").SelectedItem != null && frm.Controls.OfType<ComboBox>().FirstOrDefault(y => y.Name == "overflowData").SelectedItem != null)
            {
              textArea.SelectedText = string.Format("{0}: {1};\n", frm.Controls.OfType<ListBox>().FirstOrDefault(y => y.Name == "overflows").SelectedItem, frm.Controls.OfType<ComboBox>().FirstOrDefault(y => y.Name == "overflowData").SelectedItem);
            }
            frm.Close();
        }
        private void overflowCancel_Click(object sender,EventArgs e)
        {
            var ctrl = (Control)sender;
            var frm = ctrl.FindForm();
            frm.Close();
        }
        private void textOK_Click(object sender,EventArgs e)
        {
            var ctrl = (Control)sender;
            var frm = ctrl.FindForm();
            int aIndex = frm.Controls.OfType<GroupBox>().FirstOrDefault(y => y.Name == "textAlignGrpBox").Controls.OfType<ComboBox>().FirstOrDefault(y => y.Name == "textAlignLastCmb").SelectedIndex;
            if (frm.Controls.OfType<GroupBox>().FirstOrDefault(y => y.Name == "textAlignGrpBox").Controls.OfType<ComboBox>().FirstOrDefault(y => y.Name == "textAlignLastCmb").Enabled == true)
            {
                switch (aIndex)
                {
                    case 0:
                        textArea.SelectedText = string.Format("text-align-last: {0};\n", frm.Controls.OfType<GroupBox>().FirstOrDefault(y => y.Name == "textAlignGrpBox").Controls.OfType<ComboBox>().FirstOrDefault(y => y.Name == "textAlignLastCmb").SelectedItem);
                        break;
                    case 1:
                        textArea.SelectedText = string.Format("text-align-last: {0};\n", frm.Controls.OfType<GroupBox>().FirstOrDefault(y => y.Name == "textAlignGrpBox").Controls.OfType<ComboBox>().FirstOrDefault(y => y.Name == "textAlignLastCmb").SelectedItem);
                        break;
                    case 2:
                        textArea.SelectedText = string.Format("text-align-last: {0};\n", frm.Controls.OfType<GroupBox>().FirstOrDefault(y => y.Name == "textAlignGrpBox").Controls.OfType<ComboBox>().FirstOrDefault(y => y.Name == "textAlignLastCmb").SelectedItem);
                        break;
                    case 3:
                        textArea.SelectedText = string.Format("text-align-last: {0};\n", frm.Controls.OfType<GroupBox>().FirstOrDefault(y => y.Name == "textAlignGrpBox").Controls.OfType<ComboBox>().FirstOrDefault(y => y.Name == "textAlignLastCmb").SelectedItem);
                        break;
                    case 4:
                        textArea.SelectedText = string.Format("text-align-last: {0};\n", frm.Controls.OfType<GroupBox>().FirstOrDefault(y => y.Name == "textAlignGrpBox").Controls.OfType<ComboBox>().FirstOrDefault(y => y.Name == "textAlignLastCmb").SelectedItem);
                        break;
                    case 5:
                        textArea.SelectedText = string.Format("text-align-last: {0};\n", frm.Controls.OfType<GroupBox>().FirstOrDefault(y => y.Name == "textAlignGrpBox").Controls.OfType<ComboBox>().FirstOrDefault(y => y.Name == "textAlignLastCmb").SelectedItem);
                        break;
                }
            }
            if (frm.Controls.OfType<GroupBox>().FirstOrDefault(y => y.Name == "textShadowGrpBox").Controls.OfType<CheckBox>().FirstOrDefault(y => y.Name == "noShadow").Checked)
            {
                textArea.SelectedText = string.Format("text-shadow: none;\n");
            }
            int bIndex = frm.Controls.OfType<GroupBox>().FirstOrDefault(y => y.Name == "textAlignGrpBox").Controls.OfType<ComboBox>().FirstOrDefault(y => y.Name == "textAlignCmb").SelectedIndex;
            if (frm.Controls.OfType<GroupBox>().FirstOrDefault(y => y.Name == "textAlignGrpBox").Controls.OfType<ComboBox>().FirstOrDefault(y => y.Name == "textAlignCmb").Enabled == true)
            {
                switch (bIndex)
                {
                    case 0:
                        textArea.SelectedText = string.Format("text-align: {0};\n", frm.Controls.OfType<GroupBox>().FirstOrDefault(y => y.Name == "textAlignGrpBox").Controls.OfType<ComboBox>().FirstOrDefault(y => y.Name == "textAlignCmb").SelectedItem);
                        break;
                    case 1:
                        textArea.SelectedText = string.Format("text-align: {0};\n", frm.Controls.OfType<GroupBox>().FirstOrDefault(y => y.Name == "textAlignGrpBox").Controls.OfType<ComboBox>().FirstOrDefault(y => y.Name == "textAlignCmb").SelectedItem);
                        break;
                    case 2:
                        textArea.SelectedText = string.Format("text-align: {0};\n", frm.Controls.OfType<GroupBox>().FirstOrDefault(y => y.Name == "textAlignGrpBox").Controls.OfType<ComboBox>().FirstOrDefault(y => y.Name == "textAlignCmb").SelectedItem);
                        break;
                    case 3:
                        textArea.SelectedText = string.Format("text-align: {0};\n", frm.Controls.OfType<GroupBox>().FirstOrDefault(y => y.Name == "textAlignGrpBox").Controls.OfType<ComboBox>().FirstOrDefault(y => y.Name == "textAlignCmb").SelectedItem);
                        break;
                    case 4:
                        textArea.SelectedText = string.Format("text-align: {0};\n", frm.Controls.OfType<GroupBox>().FirstOrDefault(y => y.Name == "textAlignGrpBox").Controls.OfType<ComboBox>().FirstOrDefault(y => y.Name == "textAlignCmb").SelectedItem);
                        break;
                    case 5:
                        textArea.SelectedText = string.Format("text-align: {0};\n", frm.Controls.OfType<GroupBox>().FirstOrDefault(y => y.Name == "textAlignGrpBox").Controls.OfType<ComboBox>().FirstOrDefault(y => y.Name == "textAlignCmb").SelectedItem);
                        break;
                }
            }
            int cIndex = frm.Controls.OfType<ComboBox>().FirstOrDefault(y => y.Name == "textIndentMeasureCmb").SelectedIndex;
            if (frm.Controls.OfType<ComboBox>().FirstOrDefault(y => y.Name == "textIndentMeasureCmb").Enabled == true && frm.Controls.OfType<ComboBox>().FirstOrDefault(y => y.Name == "textIndentMeasureCmb").SelectedItem != null)
            {
                switch (cIndex)
                {
                    case 0:
                        textArea.SelectedText = string.Format("text-indent: {0}{1};\n", frm.Controls.OfType<NumericUpDown>().FirstOrDefault(y => y.Name == "textIndentNUD").Value, frm.Controls.OfType<ComboBox>().FirstOrDefault(y => y.Name == "textIndentMeasureCmb").SelectedItem);
                        break;
                    case 1:
                        textArea.SelectedText = string.Format("text-indent: {0}{1};\n", frm.Controls.OfType<NumericUpDown>().FirstOrDefault(y => y.Name == "textIndentNUD").Value, frm.Controls.OfType<ComboBox>().FirstOrDefault(y => y.Name == "textIndentMeasureCmb").SelectedItem);
                        break;
                    case 2:
                        textArea.SelectedText = string.Format("text-indent: {0}{1};\n", frm.Controls.OfType<NumericUpDown>().FirstOrDefault(y => y.Name == "textIndentNUD").Value, frm.Controls.OfType<ComboBox>().FirstOrDefault(y => y.Name == "textIndentMeasureCmb").SelectedItem);
                        break;
                    case 3:
                        textArea.SelectedText = string.Format("text-indent: {0}{1};\n", frm.Controls.OfType<NumericUpDown>().FirstOrDefault(y => y.Name == "textIndentNUD").Value, frm.Controls.OfType<ComboBox>().FirstOrDefault(y => y.Name == "textIndentMeasureCmb").SelectedItem);
                        break;
                    case 4:
                        textArea.SelectedText = string.Format("text-indent: {0}{1};\n", frm.Controls.OfType<NumericUpDown>().FirstOrDefault(y => y.Name == "textIndentNUD").Value, frm.Controls.OfType<ComboBox>().FirstOrDefault(y => y.Name == "textIndentMeasureCmb").SelectedItem);
                        break;
                    case 5:
                        textArea.SelectedText = string.Format("text-indent: {0}{1};\n", frm.Controls.OfType<NumericUpDown>().FirstOrDefault(y => y.Name == "textIndentNUD").Value, frm.Controls.OfType<ComboBox>().FirstOrDefault(y => y.Name == "textIndentMeasureCmb").SelectedItem);
                        break;
                }
            }
            decimal radius = 0;
            if (frm.Controls.OfType<GroupBox>().FirstOrDefault(y => y.Name == "textShadowGrpBox").Controls.OfType<NumericUpDown>().FirstOrDefault(y => y.Name == "radiusNUD").Enabled == true && frm.Controls.OfType<GroupBox>().FirstOrDefault(y => y.Name == "textShadowGrpBox").Controls.OfType<NumericUpDown>().FirstOrDefault(y => y.Name == "radiusNUD").Value != 0)
            {
                radius = frm.Controls.OfType<GroupBox>().FirstOrDefault(y => y.Name == "textShadowGrpBox").Controls.OfType<NumericUpDown>().FirstOrDefault(y => y.Name == "radiusNUD").Value;
            }
            decimal hshadow = 0;
            if (frm.Controls.OfType<GroupBox>().FirstOrDefault(y => y.Name == "textShadowGrpBox").Controls.OfType<NumericUpDown>().FirstOrDefault(y => y.Name == "hshadowNUD").Enabled == true && frm.Controls.OfType<GroupBox>().FirstOrDefault(y => y.Name == "textShadowGrpBox").Controls.OfType<NumericUpDown>().FirstOrDefault(y => y.Name == "hshadowNUD").Value != 0)
            {
                hshadow = frm.Controls.OfType<GroupBox>().FirstOrDefault(y => y.Name == "textShadowGrpBox").Controls.OfType<NumericUpDown>().FirstOrDefault(y => y.Name == "hshadowNUD").Value;
            }
            decimal vshadow = 0;
            if (frm.Controls.OfType<GroupBox>().FirstOrDefault(y => y.Name == "textShadowGrpBox").Controls.OfType<NumericUpDown>().FirstOrDefault(y => y.Name == "vshadowNUD").Enabled == true && frm.Controls.OfType<GroupBox>().FirstOrDefault(y => y.Name == "textShadowGrpBox").Controls.OfType<NumericUpDown>().FirstOrDefault(y => y.Name == "vshadowNUD").Value != 0)
            {
                vshadow = frm.Controls.OfType<GroupBox>().FirstOrDefault(y => y.Name == "textShadowGrpBox").Controls.OfType<NumericUpDown>().FirstOrDefault(y => y.Name == "vshadowNUD").Value;
            }
            string color = null;
            if (frm.Controls.OfType<GroupBox>().FirstOrDefault(y => y.Name == "textShadowGrpBox").Controls.OfType<TextBox>().FirstOrDefault(y => y.Name == "textShadowColor").Enabled == true && frm.Controls.OfType<GroupBox>().FirstOrDefault(y => y.Name == "textShadowGrpBox").Controls.OfType<TextBox>().FirstOrDefault(y => y.Name == "textShadowColor").Text != String.Empty)
            {
                color = frm.Controls.OfType<GroupBox>().FirstOrDefault(y => y.Name == "textShadowGrpBox").Controls.OfType<TextBox>().FirstOrDefault(y => y.Name == "textShadowColor").Text;
            }
            if (radius!=0 && hshadow!=0 && vshadow!=0 && color != String.Empty)
            {
                textArea.SelectedText = string.Format("text-shadow: {0}px {1}px {2}px {3};\n", hshadow, vshadow, radius, color);
            }
            if (frm.Controls.OfType<RadioButton>().FirstOrDefault(y => y.Name == "clip").Enabled && frm.Controls.OfType<RadioButton>().FirstOrDefault(y => y.Name == "clip").Checked==true)
            {
                textArea.SelectedText = string.Format("text-overflow: {0};\n", frm.Controls.OfType<RadioButton>().FirstOrDefault(y => y.Name == "clip").Text);
            }
           if (frm.Controls.OfType<RadioButton>().FirstOrDefault(y => y.Name == "ellipsis").Enabled && frm.Controls.OfType<RadioButton>().FirstOrDefault(y => y.Name == "ellipsis").Checked == true)
            {
                textArea.SelectedText = string.Format("text-overflow: {0};\n", frm.Controls.OfType<RadioButton>().FirstOrDefault(y => y.Name == "ellipsis").Text);
            }
            frm.Close();
        }
        private void textCancel_Click(object sender,EventArgs e)
        {
            var ctrl = (Control)sender;
            var frm = ctrl.FindForm();
            frm.Close();
        }
        private void textShadowSelect_Click(object sender,EventArgs e)
        {
            var ctrl = (Control)sender;
            var frm = ctrl.FindForm();
            ColorDialog textShadowColorSet = new ColorDialog();
            textShadowColorSet.ShowHelp = true;
            if (textShadowColorSet.ShowDialog() != DialogResult.Cancel)
            {
                Color textShadowColor = textShadowColorSet.Color;
                frm.Controls.OfType<GroupBox>().FirstOrDefault(y => y.Name == "textShadowGrpBox").Controls.OfType<TextBox>().FirstOrDefault(y => y.Name == "textShadowColor").Text = string.Format("#{0:X2}{1:X2}{2:X2}", textShadowColor.R, textShadowColor.G, textShadowColor.B);
            }
        }
        private void textIndentMeasureCmb_SelectedIndexChanged(object sender,EventArgs e)
        {
            var ctrl = (Control)sender;
            var frm = ctrl.FindForm();
            int itemIndex = frm.Controls.OfType<ComboBox>().FirstOrDefault(y => y.Name == "textIndentMeasureCmb").SelectedIndex;
            switch (itemIndex)
            {
                case 0:
                    frm.Controls.OfType<NumericUpDown>().FirstOrDefault(y => y.Name == "textIndentNUD").Maximum = 8192;
                    break;
                case 1:
                    frm.Controls.OfType<NumericUpDown>().FirstOrDefault(y => y.Name == "textIndentNUD").Maximum = 100;
                    break;
            }
        }
        private void noShadow_CheckedChanged(object sender,EventArgs e)
        {
            var ctrl = (Control)sender;
            var frm = ctrl.FindForm();
            if (frm.Controls.OfType<GroupBox>().FirstOrDefault(y => y.Name == "textShadowGrpBox").Controls.OfType<CheckBox>().FirstOrDefault(y => y.Name == "noShadow").Checked)
            {
                frm.Controls.OfType<GroupBox>().FirstOrDefault(y => y.Name == "textShadowGrpBox").Controls.OfType<Button>().FirstOrDefault(y => y.Name == "textShadowSelect").Enabled = false;
                frm.Controls.OfType<GroupBox>().FirstOrDefault(y => y.Name == "textShadowGrpBox").Controls.OfType<TextBox>().FirstOrDefault(y => y.Name == "textShadowColor").Enabled = false;
                frm.Controls.OfType<GroupBox>().FirstOrDefault(y => y.Name == "textShadowGrpBox").Controls.OfType<NumericUpDown>().FirstOrDefault(y => y.Name == "hshadowNUD").Enabled = false;
                frm.Controls.OfType<GroupBox>().FirstOrDefault(y => y.Name == "textShadowGrpBox").Controls.OfType<NumericUpDown>().FirstOrDefault(y => y.Name == "vshadowNUD").Enabled = false;
                frm.Controls.OfType<GroupBox>().FirstOrDefault(y => y.Name == "textShadowGrpBox").Controls.OfType<NumericUpDown>().FirstOrDefault(y => y.Name == "radiusNUD").Enabled = false;
            }
            else
            {
                frm.Controls.OfType<GroupBox>().FirstOrDefault(y => y.Name == "textShadowGrpBox").Controls.OfType<Button>().FirstOrDefault(y => y.Name == "textShadowSelect").Enabled = true;
                frm.Controls.OfType<GroupBox>().FirstOrDefault(y => y.Name == "textShadowGrpBox").Controls.OfType<TextBox>().FirstOrDefault(y => y.Name == "textShadowColor").Enabled = true;
                frm.Controls.OfType<GroupBox>().FirstOrDefault(y => y.Name == "textShadowGrpBox").Controls.OfType<NumericUpDown>().FirstOrDefault(y => y.Name == "hshadowNUD").Enabled = true;
                frm.Controls.OfType<GroupBox>().FirstOrDefault(y => y.Name == "textShadowGrpBox").Controls.OfType<NumericUpDown>().FirstOrDefault(y => y.Name == "vshadowNUD").Enabled = true;
                frm.Controls.OfType<GroupBox>().FirstOrDefault(y => y.Name == "textShadowGrpBox").Controls.OfType<NumericUpDown>().FirstOrDefault(y => y.Name == "radiusNUD").Enabled = true;
            }
        }
        private void columnOK_Click(object sender,EventArgs e)
        {
            var ctrl = (Control)sender;
            var frm = ctrl.FindForm();
            int aIndex = frm.Controls.OfType<GroupBox>().FirstOrDefault(y => y.Name == "columnGBox").Controls.OfType<ComboBox>().FirstOrDefault(y => y.Name == "columnwidthMeasure").SelectedIndex;
            if (frm.Controls.OfType<GroupBox>().FirstOrDefault(y => y.Name == "columnGBox").Controls.OfType<ComboBox>().FirstOrDefault(y => y.Name == "columnwidthMeasure").Enabled == true)
            {
                switch(aIndex)
                {
                    case 0:
                        textArea.SelectedText = string.Format("column-width: {0}{1};\n", frm.Controls.OfType<GroupBox>().FirstOrDefault(y => y.Name == "columnGBox").Controls.OfType<NumericUpDown>().FirstOrDefault(y => y.Name == "columnwidthNUD").Value, frm.Controls.OfType<GroupBox>().FirstOrDefault(y => y.Name == "columnGBox").Controls.OfType<ComboBox>().FirstOrDefault(y => y.Name == "columnwidthMeasure").SelectedItem);
                        break;
                    case 1:
                        textArea.SelectedText = string.Format("column-width: {0}{1};\n", frm.Controls.OfType<GroupBox>().FirstOrDefault(y => y.Name == "columnGBox").Controls.OfType<NumericUpDown>().FirstOrDefault(y => y.Name == "columnwidthNUD").Value, frm.Controls.OfType<GroupBox>().FirstOrDefault(y => y.Name == "columnGBox").Controls.OfType<ComboBox>().FirstOrDefault(y => y.Name == "columnwidthMeasure").SelectedItem);
                        break;
                }
            }
            if (frm.Controls.OfType<GroupBox>().FirstOrDefault(y => y.Name == "columnGBox").Controls.OfType<CheckBox>().FirstOrDefault(y => y.Name == "columnwidthAutoChk").Checked)
            {
                textArea.SelectedText = string.Format("column-width: auto;\n");
            }
            if (frm.Controls.OfType<GroupBox>().FirstOrDefault(y => y.Name == "columnGBox").Controls.OfType<NumericUpDown>().FirstOrDefault(y => y.Name == "columncountNUD").Enabled && frm.Controls.OfType<GroupBox>().FirstOrDefault(y => y.Name == "columnGBox").Controls.OfType<NumericUpDown>().FirstOrDefault(y => y.Name == "columncountNUD").Value > 0)
            {
                textArea.SelectedText = string.Format("column-count: {0};\n", frm.Controls.OfType<GroupBox>().FirstOrDefault(y => y.Name == "columnGBox").Controls.OfType<NumericUpDown>().FirstOrDefault(y => y.Name == "columncountNUD").Value);
            }
            if (frm.Controls.OfType<GroupBox>().FirstOrDefault(y => y.Name == "columnGBox").Controls.OfType<CheckBox>().FirstOrDefault(y => y.Name == "columncountAutoChk").Checked)
            {
                textArea.SelectedText = string.Format("column-count: auto;\n");
            }
            int bIndex = frm.Controls.OfType<GroupBox>().FirstOrDefault(y => y.Name == "columnGBox").Controls.OfType<ComboBox>().FirstOrDefault(y => y.Name == "columnGapMeasure").SelectedIndex;
            if (frm.Controls.OfType<GroupBox>().FirstOrDefault(y => y.Name == "columnGBox").Controls.OfType<ComboBox>().FirstOrDefault(y => y.Name == "columnGapMeasure").Enabled == true)
            {
                switch (bIndex)
                {
                    case 0:
                        textArea.SelectedText = string.Format("column-gap: {0}{1};\n", frm.Controls.OfType<GroupBox>().FirstOrDefault(y => y.Name == "columnGBox").Controls.OfType<NumericUpDown>().FirstOrDefault(y => y.Name == "columnGapNUD").Value, frm.Controls.OfType<GroupBox>().FirstOrDefault(y => y.Name == "columnGBox").Controls.OfType<ComboBox>().FirstOrDefault(y => y.Name == "columnGapMeasure").SelectedItem);
                        break;
                    case 1:
                        textArea.SelectedText = string.Format("column-gap: {0}{1};\n", frm.Controls.OfType<GroupBox>().FirstOrDefault(y => y.Name == "columnGBox").Controls.OfType<NumericUpDown>().FirstOrDefault(y => y.Name == "columnGapNUD").Value, frm.Controls.OfType<GroupBox>().FirstOrDefault(y => y.Name == "columnGBox").Controls.OfType<ComboBox>().FirstOrDefault(y => y.Name == "columnGapMeasure").SelectedItem);
                        break;
                }
            }
            if (frm.Controls.OfType<GroupBox>().FirstOrDefault(y => y.Name == "columnGBox").Controls.OfType<CheckBox>().FirstOrDefault(y => y.Name == "columngapNormalChk").Checked)
            {
                textArea.SelectedText = string.Format("column-gap: normal;\n");
            }
            if (frm.Controls.OfType<GroupBox>().FirstOrDefault(y => y.Name == "columnGBox").Controls.OfType<RadioButton>().FirstOrDefault(y => y.Name == "none").Checked)
            {
                textArea.SelectedText = string.Format("column-span: none;\n");
            }
            if (frm.Controls.OfType<GroupBox>().FirstOrDefault(y => y.Name == "columnGBox").Controls.OfType<RadioButton>().FirstOrDefault(y => y.Name == "all").Checked)
            {
                textArea.SelectedText = string.Format("column-span: all;\n");
            }
            int cIndex = frm.Controls.OfType<GroupBox>().FirstOrDefault(y => y.Name == "columnRulEGBox").Controls.OfType<ComboBox>().FirstOrDefault(y => y.Name == "columnRuleWidthStyle").SelectedIndex;
            switch (cIndex)
                {
                    case 0:
                        textArea.SelectedText = string.Format("column-rule-width: {0}px;\n", frm.Controls.OfType<GroupBox>().FirstOrDefault(y => y.Name == "columnRulEGBox").Controls.OfType<NumericUpDown>().FirstOrDefault(y => y.Name == "columnRuleWidthNUD").Value);
                        break;
                    case 1:
                        textArea.SelectedText = string.Format("column-rule-width: {0};\n", frm.Controls.OfType<GroupBox>().FirstOrDefault(y => y.Name == "columnRulEGBox").Controls.OfType<ComboBox>().FirstOrDefault(y => y.Name == "columnRuleWidthStyle").SelectedItem);
                        break;
                    case 2:
                        textArea.SelectedText = string.Format("column-rule-width: {0};\n", frm.Controls.OfType<GroupBox>().FirstOrDefault(y => y.Name == "columnRulEGBox").Controls.OfType<ComboBox>().FirstOrDefault(y => y.Name == "columnRuleWidthStyle").SelectedItem);
                        break;
                    case 3:
                        textArea.SelectedText = string.Format("column-rule-width: {0};\n", frm.Controls.OfType<GroupBox>().FirstOrDefault(y => y.Name == "columnRulEGBox").Controls.OfType<ComboBox>().FirstOrDefault(y => y.Name == "columnRuleWidthStyle").SelectedItem);
                        break;
               }
            if(frm.Controls.OfType<GroupBox>().FirstOrDefault(y => y.Name == "columnRulEGBox").Controls.OfType<ComboBox>().FirstOrDefault(y => y.Name == "columnrulestyle").SelectedItem != null)
            {
                textArea.SelectedText = string.Format("column-rule-style: {0};\n", frm.Controls.OfType<GroupBox>().FirstOrDefault(y => y.Name == "columnRulEGBox").Controls.OfType<ComboBox>().FirstOrDefault(y => y.Name == "columnrulestyle").SelectedItem);
            }
            if(frm.Controls.OfType<GroupBox>().FirstOrDefault(y => y.Name == "columnRulEGBox").Controls.OfType<TextBox>().FirstOrDefault(y => y.Name == "columnColor").Text != String.Empty)
            {
                textArea.SelectedText = string.Format("column-rule-color: {0};\n", frm.Controls.OfType<GroupBox>().FirstOrDefault(y => y.Name == "columnRulEGBox").Controls.OfType<TextBox>().FirstOrDefault(y => y.Name == "columnColor").Text);
            }
            frm.Close();
        }
        private void columnCancel_Click(object sender,EventArgs e)
        {
            var ctrl = (Control)sender;
            var frm = ctrl.FindForm();
            frm.Close();
        }
        private void columnrulestyle_SelectedIndexChanged(object sender,EventArgs e)
        {
            var ctrl = (Control)sender;
            var frm = ctrl.FindForm();
            int itemIndex = frm.Controls.OfType<GroupBox>().FirstOrDefault(y => y.Name == "columnRulEGBox").Controls.OfType<ComboBox>().FirstOrDefault(y => y.Name == "columnrulestyle").SelectedIndex;
            switch (itemIndex)
            {
                case 0:
                    frm.Controls.OfType<GroupBox>().FirstOrDefault(y => y.Name == "columnRulEGBox").Controls.OfType<PictureBox>().FirstOrDefault(y => y.Name == "columnrulePic").Visible = false;
                    break;
                case 1:
                    frm.Controls.OfType<GroupBox>().FirstOrDefault(y => y.Name == "columnRulEGBox").Controls.OfType<PictureBox>().FirstOrDefault(y => y.Name == "columnrulePic").Visible = false;
                    break;
                case 2:
                    frm.Controls.OfType<GroupBox>().FirstOrDefault(y => y.Name == "columnRulEGBox").Controls.OfType<PictureBox>().FirstOrDefault(y => y.Name == "columnrulePic").Visible = true;
                    frm.Controls.OfType<GroupBox>().FirstOrDefault(y => y.Name == "columnRulEGBox").Controls.OfType<PictureBox>().FirstOrDefault(y => y.Name == "columnrulePic").BackgroundImage = global::Loxie.Properties.Resources.dotted;
                    break;
                case 3:
                    frm.Controls.OfType<GroupBox>().FirstOrDefault(y => y.Name == "columnRulEGBox").Controls.OfType<PictureBox>().FirstOrDefault(y => y.Name == "columnrulePic").Visible = true;
                    frm.Controls.OfType<GroupBox>().FirstOrDefault(y => y.Name == "columnRulEGBox").Controls.OfType<PictureBox>().FirstOrDefault(y => y.Name == "columnrulePic").BackgroundImage = global::Loxie.Properties.Resources.dashed;
                    break;
                case 4:
                    frm.Controls.OfType<GroupBox>().FirstOrDefault(y => y.Name == "columnRulEGBox").Controls.OfType<PictureBox>().FirstOrDefault(y => y.Name == "columnrulePic").Visible = true;
                    frm.Controls.OfType<GroupBox>().FirstOrDefault(y => y.Name == "columnRulEGBox").Controls.OfType<PictureBox>().FirstOrDefault(y => y.Name == "columnrulePic").BackgroundImage = global::Loxie.Properties.Resources.solid;
                    break;
                case 5:
                    frm.Controls.OfType<GroupBox>().FirstOrDefault(y => y.Name == "columnRulEGBox").Controls.OfType<PictureBox>().FirstOrDefault(y => y.Name == "columnrulePic").Visible = true;
                    frm.Controls.OfType<GroupBox>().FirstOrDefault(y => y.Name == "columnRulEGBox").Controls.OfType<PictureBox>().FirstOrDefault(y => y.Name == "columnrulePic").BackgroundImage = global::Loxie.Properties.Resources._double;
                    break;
                case 6:
                    frm.Controls.OfType<GroupBox>().FirstOrDefault(y => y.Name == "columnRulEGBox").Controls.OfType<PictureBox>().FirstOrDefault(y => y.Name == "columnrulePic").Visible = true;
                    frm.Controls.OfType<GroupBox>().FirstOrDefault(y => y.Name == "columnRulEGBox").Controls.OfType<PictureBox>().FirstOrDefault(y => y.Name == "columnrulePic").BackgroundImage = global::Loxie.Properties.Resources.groove;
                    break;
                case 7:
                    frm.Controls.OfType<GroupBox>().FirstOrDefault(y => y.Name == "columnRulEGBox").Controls.OfType<PictureBox>().FirstOrDefault(y => y.Name == "columnrulePic").Visible = true;
                    frm.Controls.OfType<GroupBox>().FirstOrDefault(y => y.Name == "columnRulEGBox").Controls.OfType<PictureBox>().FirstOrDefault(y => y.Name == "columnrulePic").BackgroundImage = global::Loxie.Properties.Resources.ridge;
                    break;
                case 8:
                    frm.Controls.OfType<GroupBox>().FirstOrDefault(y => y.Name == "columnRulEGBox").Controls.OfType<PictureBox>().FirstOrDefault(y => y.Name == "columnrulePic").Visible = true;
                    frm.Controls.OfType<GroupBox>().FirstOrDefault(y => y.Name == "columnRulEGBox").Controls.OfType<PictureBox>().FirstOrDefault(y => y.Name == "columnrulePic").BackgroundImage = global::Loxie.Properties.Resources.inset;
                    break;
                case 9:
                    frm.Controls.OfType<GroupBox>().FirstOrDefault(y => y.Name == "columnRulEGBox").Controls.OfType<PictureBox>().FirstOrDefault(y => y.Name == "columnrulePic").Visible = true;
                    frm.Controls.OfType<GroupBox>().FirstOrDefault(y => y.Name == "columnRulEGBox").Controls.OfType<PictureBox>().FirstOrDefault(y => y.Name == "columnrulePic").BackgroundImage = global::Loxie.Properties.Resources.outset;
                    break;
            }
        }
        private void columncolorSelect_Click(object sender,EventArgs e)
        {
            var ctrl = (Control)sender;
            var frm = ctrl.FindForm();
            ColorDialog dropColorSet = new ColorDialog();
            dropColorSet.ShowHelp = true;
            if (dropColorSet.ShowDialog() != DialogResult.Cancel)
            {
                Color dropColor = dropColorSet.Color;
                frm.Controls.OfType<GroupBox>().FirstOrDefault(y => y.Name == "columnRulEGBox").Controls.OfType<TextBox>().FirstOrDefault(y => y.Name == "columnColor").Text = string.Format("#{0:X2}{1:X2}{2:X2}", dropColor.R, dropColor.G, dropColor.B);
            }
        }
        private void columnRuleWidthStyle_SelectedIndexChanged(object sender, EventArgs e)
        {
            var ctrl = (Control)sender;
            var frm = ctrl.FindForm();
            if (frm.Controls.OfType<GroupBox>().FirstOrDefault(y => y.Name == "columnRulEGBox").Controls.OfType<ComboBox>().FirstOrDefault(y => y.Name == "columnRuleWidthStyle").SelectedIndex == 0)
            {
                frm.Controls.OfType<GroupBox>().FirstOrDefault(y => y.Name == "columnRulEGBox").Controls.OfType<NumericUpDown>().FirstOrDefault(y => y.Name == "columnRuleWidthNUD").Enabled = true;
            }
            if (frm.Controls.OfType<GroupBox>().FirstOrDefault(y => y.Name == "columnRulEGBox").Controls.OfType<ComboBox>().FirstOrDefault(y => y.Name == "columnRuleWidthStyle").SelectedIndex != 0)
            {
                frm.Controls.OfType<GroupBox>().FirstOrDefault(y => y.Name == "columnRulEGBox").Controls.OfType<NumericUpDown>().FirstOrDefault(y => y.Name == "columnRuleWidthNUD").Enabled = false;
            }
        }
        private void columnGapMeasure_SelectedIndexChanged(object sender,EventArgs e)
        {
            var ctrl = (Control)sender;
            var frm = ctrl.FindForm();
            int itemIndex = frm.Controls.OfType<GroupBox>().FirstOrDefault(y => y.Name == "columnGBox").Controls.OfType<ComboBox>().FirstOrDefault(y => y.Name == "columnGapMeasure").SelectedIndex;
            switch (itemIndex)
            {
                case 0:
                    frm.Controls.OfType<GroupBox>().FirstOrDefault(y => y.Name == "columnGBox").Controls.OfType<NumericUpDown>().FirstOrDefault(y => y.Name == "columnGapNUD").Maximum = 8192;
                    break;
                case 1:
                    frm.Controls.OfType<GroupBox>().FirstOrDefault(y => y.Name == "columnGBox").Controls.OfType<NumericUpDown>().FirstOrDefault(y => y.Name == "columnGapNUD").Maximum = 100;
                    break;
            }
        }
        private void columngapNormalChk_CheckedChanged(object sender,EventArgs e)
        {
            var ctrl = (Control)sender;
            var frm = ctrl.FindForm();
            if (frm.Controls.OfType<GroupBox>().FirstOrDefault(y => y.Name == "columnGBox").Controls.OfType<CheckBox>().FirstOrDefault(y => y.Name == "columngapNormalChk").Checked == true)
            {
                frm.Controls.OfType<GroupBox>().FirstOrDefault(y => y.Name == "columnGBox").Controls.OfType<ComboBox>().FirstOrDefault(y => y.Name == "columnGapMeasure").Enabled = false;
                frm.Controls.OfType<GroupBox>().FirstOrDefault(y => y.Name == "columnGBox").Controls.OfType<NumericUpDown>().FirstOrDefault(y => y.Name == "columnGapNUD").Enabled = false;
            }
            if (frm.Controls.OfType<GroupBox>().FirstOrDefault(y => y.Name == "columnGBox").Controls.OfType<CheckBox>().FirstOrDefault(y => y.Name == "columngapNormalChk").Checked == false)
            {
                frm.Controls.OfType<GroupBox>().FirstOrDefault(y => y.Name == "columnGBox").Controls.OfType<ComboBox>().FirstOrDefault(y => y.Name == "columnGapMeasure").Enabled = true;
                frm.Controls.OfType<GroupBox>().FirstOrDefault(y => y.Name == "columnGBox").Controls.OfType<NumericUpDown>().FirstOrDefault(y => y.Name == "columnGapNUD").Enabled = true;
            }
        }
        private void columncountAutoChk_CheckedChanged(object sender,EventArgs e)
        {
            var ctrl = (Control)sender;
            var frm = ctrl.FindForm();
            if (frm.Controls.OfType<GroupBox>().FirstOrDefault(y => y.Name == "columnGBox").Controls.OfType<CheckBox>().FirstOrDefault(y => y.Name == "columncountAutoChk").Checked == true)
            {
                frm.Controls.OfType<GroupBox>().FirstOrDefault(y => y.Name == "columnGBox").Controls.OfType<NumericUpDown>().FirstOrDefault(y => y.Name == "columncountNUD").Enabled = false;
            }
            if (frm.Controls.OfType<GroupBox>().FirstOrDefault(y => y.Name == "columnGBox").Controls.OfType<CheckBox>().FirstOrDefault(y => y.Name == "columncountAutoChk").Checked == false)
            {
                frm.Controls.OfType<GroupBox>().FirstOrDefault(y => y.Name == "columnGBox").Controls.OfType<NumericUpDown>().FirstOrDefault(y => y.Name == "columncountNUD").Enabled = true;
            }
        }
        private void columnwidthMeasure_SelectedIndexChanged(object sender,EventArgs e)
        {
            var ctrl = (Control)sender;
            var frm = ctrl.FindForm();
            int itemIndex = frm.Controls.OfType<GroupBox>().FirstOrDefault(y => y.Name == "columnGBox").Controls.OfType<ComboBox>().FirstOrDefault(y => y.Name == "columnwidthMeasure").SelectedIndex;
            switch (itemIndex)
            {
                case 0:
                    frm.Controls.OfType<GroupBox>().FirstOrDefault(y => y.Name == "columnGBox").Controls.OfType<NumericUpDown>().FirstOrDefault(y => y.Name == "columnwidthNUD").Maximum = 8192;
                    break;
                case 1:
                    frm.Controls.OfType<GroupBox>().FirstOrDefault(y => y.Name == "columnGBox").Controls.OfType<NumericUpDown>().FirstOrDefault(y => y.Name == "columnwidthNUD").Maximum = 100;
                    break;
            }
        }
        private void columnwidthAutoChk_CheckedChanged(object sender, EventArgs e)
        {
            var ctrl = (Control)sender;
            var frm = ctrl.FindForm();
            if (frm.Controls.OfType<GroupBox>().FirstOrDefault(y => y.Name == "columnGBox").Controls.OfType<CheckBox>().FirstOrDefault(y => y.Name == "columnwidthAutoChk").Checked == true)
            {
                frm.Controls.OfType<GroupBox>().FirstOrDefault(y => y.Name == "columnGBox").Controls.OfType<ComboBox>().FirstOrDefault(y => y.Name == "columnwidthMeasure").Enabled = false;
                frm.Controls.OfType<GroupBox>().FirstOrDefault(y => y.Name == "columnGBox").Controls.OfType<NumericUpDown>().FirstOrDefault(y => y.Name == "columnwidthNUD").Enabled = false;
            }
            if (frm.Controls.OfType<GroupBox>().FirstOrDefault(y => y.Name == "columnGBox").Controls.OfType<CheckBox>().FirstOrDefault(y => y.Name == "columnwidthAutoChk").Checked == false)
            {
                frm.Controls.OfType<GroupBox>().FirstOrDefault(y => y.Name == "columnGBox").Controls.OfType<ComboBox>().FirstOrDefault(y => y.Name == "columnwidthMeasure").Enabled = true;
                frm.Controls.OfType<GroupBox>().FirstOrDefault(y => y.Name == "columnGBox").Controls.OfType<NumericUpDown>().FirstOrDefault(y => y.Name == "columnwidthNUD").Enabled = true;
            }
        }
        private void filterOK_Click(object sender, EventArgs e)
        {
            var ctrl = (Control)sender;
            var frm = ctrl.FindForm();
            textArea.SelectedText = "filter:";
            if (frm.Controls.OfType<CheckBox>().FirstOrDefault(y => y.Name == "inactive").Checked == true)
            {
                textArea.SelectedText = " none;\n";
            }
            if (frm.Controls.OfType<CheckBox>().FirstOrDefault(y => y.Name == "initialCheck").Checked == true)
            {
                textArea.SelectedText = " initial;\n";
            }
            if(frm.Controls.OfType<NumericUpDown>().FirstOrDefault(y => y.Name == "blurNUD").Value != 0)
            {
                textArea.SelectedText = string.Format(" blur({0}px) ", frm.Controls.OfType<NumericUpDown>().FirstOrDefault(y => y.Name == "blurNUD").Value);
            }
            if (frm.Controls.OfType<NumericUpDown>().FirstOrDefault(y => y.Name == "brightnessNUD").Value != 0)
            {
                textArea.SelectedText = string.Format(" brightness({0}%) ", frm.Controls.OfType<NumericUpDown>().FirstOrDefault(y => y.Name == "brightnessNUD").Value);
            }
            if (frm.Controls.OfType<NumericUpDown>().FirstOrDefault(y => y.Name == "contrastNUD").Value != 0)
            {
                textArea.SelectedText = string.Format(" contrast({0}%) ", frm.Controls.OfType<NumericUpDown>().FirstOrDefault(y => y.Name == "contrastNUD").Value);
            }
            if (frm.Controls.OfType<NumericUpDown>().FirstOrDefault(y => y.Name == "grayscaleNUD").Value != 0)
            {
                textArea.SelectedText = string.Format(" grayscale({0}%) ", frm.Controls.OfType<NumericUpDown>().FirstOrDefault(y => y.Name == "grayscaleNUD").Value);
            }
            if (frm.Controls.OfType<NumericUpDown>().FirstOrDefault(y => y.Name == "huerotateNUD").Value != 0)
            {
                textArea.SelectedText = string.Format(" hue-rotate({0}deg) ", frm.Controls.OfType<NumericUpDown>().FirstOrDefault(y => y.Name == "huerotateNUD").Value);
            }
            if (frm.Controls.OfType<NumericUpDown>().FirstOrDefault(y => y.Name == "invertNUD").Value != 0)
            {
                textArea.SelectedText = string.Format(" invert({0}%) ", frm.Controls.OfType<NumericUpDown>().FirstOrDefault(y => y.Name == "invertNUD").Value);
            }
            if (frm.Controls.OfType<NumericUpDown>().FirstOrDefault(y => y.Name == "opacityNUD").Value != 0)
            {
                textArea.SelectedText = string.Format(" opacity({0}%) ", frm.Controls.OfType<NumericUpDown>().FirstOrDefault(y => y.Name == "opacityNUD").Value);
            }
            if (frm.Controls.OfType<NumericUpDown>().FirstOrDefault(y => y.Name == "saturateNUD").Value != 0)
            {
                textArea.SelectedText = string.Format(" saturate({0}%) ", frm.Controls.OfType<NumericUpDown>().FirstOrDefault(y => y.Name == "saturateNUD").Value);
            }
            if (frm.Controls.OfType<NumericUpDown>().FirstOrDefault(y => y.Name == "sepiaNUD").Value != 0)
            {
                textArea.SelectedText = string.Format(" sepia({0}%) ", frm.Controls.OfType<NumericUpDown>().FirstOrDefault(y => y.Name == "sepiaNUD").Value);
            }
            if (frm.Controls.OfType<GroupBox>().FirstOrDefault(y => y.Name == "dropshadow").Controls.OfType<TextBox>().FirstOrDefault(y => y.Name == "colorCode").Text != String.Empty && frm.Controls.OfType<GroupBox>().FirstOrDefault(y => y.Name == "dropshadow").Controls.OfType<NumericUpDown>().FirstOrDefault(y => y.Name == "vshadowNUD").Value != 0 && frm.Controls.OfType<GroupBox>().FirstOrDefault(y => y.Name == "dropshadow").Controls.OfType<NumericUpDown>().FirstOrDefault(y => y.Name == "hshadowNUD").Value != 0)
            {
                textArea.SelectedText = string.Format(" drop-shadow({0}px {1}px 10px {2}) ", frm.Controls.OfType<GroupBox>().FirstOrDefault(y => y.Name == "dropshadow").Controls.OfType<NumericUpDown>().FirstOrDefault(y => y.Name == "hshadowNUD").Value, frm.Controls.OfType<GroupBox>().FirstOrDefault(y => y.Name == "dropshadow").Controls.OfType<NumericUpDown>().FirstOrDefault(y => y.Name == "vshadowNUD").Value, frm.Controls.OfType<GroupBox>().FirstOrDefault(y => y.Name == "dropshadow").Controls.OfType<TextBox>().FirstOrDefault(y => y.Name == "colorCode").Text);
            }
            textArea.SelectedText = ";\n";
            frm.Close();
        }
        private void hshadowTrck_Scroll(object sender,EventArgs e)
        {
            var ctrl = (Control)sender;
            var frm = ctrl.FindForm();
            string value = frm.Controls.OfType<GroupBox>().FirstOrDefault(y => y.Name == "dropshadow").Controls.OfType<TrackBar>().FirstOrDefault(y => y.Name == "hshadowTrck").Value.ToString();
            frm.Controls.OfType<GroupBox>().FirstOrDefault(y => y.Name == "dropshadow").Controls.OfType<NumericUpDown>().FirstOrDefault(y => y.Name == "hshadowNUD").Value = int.Parse(value);
        }
        private void hshadowNUD_ValueChanged(object sender,EventArgs e)
        {
            var ctrl = (Control)sender;
            var frm = ctrl.FindForm();
            string value = frm.Controls.OfType<GroupBox>().FirstOrDefault(y => y.Name == "dropshadow").Controls.OfType<NumericUpDown>().FirstOrDefault(y => y.Name == "hshadowNUD").Value.ToString();
            frm.Controls.OfType<GroupBox>().FirstOrDefault(y => y.Name == "dropshadow").Controls.OfType<TrackBar>().FirstOrDefault(y => y.Name == "hshadowTrck").Value = int.Parse(value);
        }
        private void vshadowTrck_Scroll(object sender,EventArgs e)
        {
            var ctrl = (Control)sender;
            var frm = ctrl.FindForm();
            string value = frm.Controls.OfType<GroupBox>().FirstOrDefault(y => y.Name == "dropshadow").Controls.OfType<TrackBar>().FirstOrDefault(y => y.Name == "vshadowTrck").Value.ToString();
            frm.Controls.OfType<GroupBox>().FirstOrDefault(y => y.Name == "dropshadow").Controls.OfType<NumericUpDown>().FirstOrDefault(y => y.Name == "vshadowNUD").Value = int.Parse(value);
        }
        private void vshadowNUD_ValueChanged(object sender,EventArgs e)
        {
            var ctrl = (Control)sender;
            var frm = ctrl.FindForm();
            string value = frm.Controls.OfType<GroupBox>().FirstOrDefault(y => y.Name == "dropshadow").Controls.OfType<NumericUpDown>().FirstOrDefault(y => y.Name == "vshadowNUD").Value.ToString();
            frm.Controls.OfType<GroupBox>().FirstOrDefault(y => y.Name == "dropshadow").Controls.OfType<TrackBar>().FirstOrDefault(y => y.Name == "vshadowTrck").Value = int.Parse(value);
        }
        private void dropColorSelect_Click(object sender,EventArgs e)
        {
            var ctrl = (Control)sender;
            var frm = ctrl.FindForm();
            ColorDialog dropColorSet = new ColorDialog();
            dropColorSet.ShowHelp = true;
            if (dropColorSet.ShowDialog() != DialogResult.Cancel)
            {
                Color dropColor = dropColorSet.Color;
                frm.Controls.OfType<GroupBox>().FirstOrDefault(y => y.Name == "dropshadow").Controls.OfType<TextBox>().FirstOrDefault(y => y.Name == "colorCode").Text = string.Format("#{0:X2}{1:X2}{2:X2}", dropColor.R, dropColor.G, dropColor.B);
            }
        }
        private void brightnessTrck_Scroll(object sender,EventArgs e)
        {
            var ctrl = (Control)sender;
            var frm = ctrl.FindForm();
            string value = frm.Controls.OfType<TrackBar>().FirstOrDefault(y => y.Name == "brightnessTrck").Value.ToString();
            frm.Controls.OfType<NumericUpDown>().FirstOrDefault(y => y.Name == "brightnessNUD").Value = int.Parse(value);
        }
        private void cotnrastTrck_Scroll(object sender,EventArgs e)
        {
            var ctrl = (Control)sender;
            var frm = ctrl.FindForm();
            string value = frm.Controls.OfType<TrackBar>().FirstOrDefault(y => y.Name == "cotnrastTrck").Value.ToString();
            frm.Controls.OfType<NumericUpDown>().FirstOrDefault(y => y.Name == "contrastNUD").Value = int.Parse(value);
        }
        private void grayscaleTrck_Scroll(object sender,EventArgs e)
        {
            var ctrl = (Control)sender;
            var frm = ctrl.FindForm();
            string value = frm.Controls.OfType<TrackBar>().FirstOrDefault(y => y.Name == "grayscaleTrck").Value.ToString();
            frm.Controls.OfType<NumericUpDown>().FirstOrDefault(y => y.Name == "grayscaleNUD").Value = int.Parse(value);
        }
        private void sepiaTrck_Scroll(object sender,EventArgs e)
        {
            var ctrl = (Control)sender;
            var frm = ctrl.FindForm();
            string value = frm.Controls.OfType<TrackBar>().FirstOrDefault(y => y.Name == "sepiaTrck").Value.ToString();
            frm.Controls.OfType<NumericUpDown>().FirstOrDefault(y => y.Name == "sepiaNUD").Value = int.Parse(value);
        }
        private void saturateTrck_Scroll(object sender,EventArgs e)
        {
            var ctrl = (Control)sender;
            var frm = ctrl.FindForm();
            string value = frm.Controls.OfType<TrackBar>().FirstOrDefault(y => y.Name == "saturateTrck").Value.ToString();
            frm.Controls.OfType<NumericUpDown>().FirstOrDefault(y => y.Name == "saturateNUD").Value = int.Parse(value);
        }
        private void filterOpacityTrck_Scroll(object sender,EventArgs e)
        {
            var ctrl = (Control)sender;
            var frm = ctrl.FindForm();
            string value = frm.Controls.OfType<TrackBar>().FirstOrDefault(y => y.Name == "opacityTrck").Value.ToString();
            frm.Controls.OfType<NumericUpDown>().FirstOrDefault(y => y.Name == "opacityNUD").Value = int.Parse(value);
        }
        private void invertTrck_Scroll(object sender,EventArgs e)
        {
            var ctrl = (Control)sender;
            var frm = ctrl.FindForm();
            string value = frm.Controls.OfType<TrackBar>().FirstOrDefault(y => y.Name == "invertTrck").Value.ToString();
            frm.Controls.OfType<NumericUpDown>().FirstOrDefault(y => y.Name == "invertNUD").Value = int.Parse(value);
        }
        private void huerotateTrck_Scroll(object sender,EventArgs e)
        {
            var ctrl = (Control)sender;
            var frm = ctrl.FindForm();
            string value = frm.Controls.OfType<TrackBar>().FirstOrDefault(y => y.Name == "huerotateTrck").Value.ToString();
            frm.Controls.OfType<NumericUpDown>().FirstOrDefault(y => y.Name == "huerotateNUD").Value = int.Parse(value);
        }
        private void brightnessNUD_ValueChanged(object sender,EventArgs e)
        {
            var ctrl = (Control)sender;
            var frm = ctrl.FindForm();
            string value = frm.Controls.OfType<NumericUpDown>().FirstOrDefault(y => y.Name == "brightnessNUD").Value.ToString();
            frm.Controls.OfType<TrackBar>().FirstOrDefault(y => y.Name == "brightnessTrck").Value = int.Parse(value);
        }
        private void contrastNUD_ValueChanged(object sender,EventArgs e)
        {
            var ctrl = (Control)sender;
            var frm = ctrl.FindForm();
            string value = frm.Controls.OfType<NumericUpDown>().FirstOrDefault(y => y.Name == "contrastNUD").Value.ToString();
            frm.Controls.OfType<TrackBar>().FirstOrDefault(y => y.Name == "cotnrastTrck").Value = int.Parse(value);
        }
        private void grayscaleNUD_ValueChanged(object sender,EventArgs e)
        {
            var ctrl = (Control)sender;
            var frm = ctrl.FindForm();
            string value = frm.Controls.OfType<NumericUpDown>().FirstOrDefault(y => y.Name == "grayscaleNUD").Value.ToString();
            frm.Controls.OfType<TrackBar>().FirstOrDefault(y => y.Name == "grayscaleTrck").Value = int.Parse(value);
        }
        private void huerotateNUD_ValueChanged(object sender,EventArgs e)
        {
            var ctrl = (Control)sender;
            var frm = ctrl.FindForm();
            string value = frm.Controls.OfType<NumericUpDown>().FirstOrDefault(y => y.Name == "huerotateNUD").Value.ToString();
            frm.Controls.OfType<TrackBar>().FirstOrDefault(y => y.Name == "huerotateTrck").Value = int.Parse(value);
        }
        private void invertNUD_ValueChanged(object sender,EventArgs e)
        {
            var ctrl = (Control)sender;
            var frm = ctrl.FindForm();
            string value = frm.Controls.OfType<NumericUpDown>().FirstOrDefault(y => y.Name == "invertNUD").Value.ToString();
            frm.Controls.OfType<TrackBar>().FirstOrDefault(y => y.Name == "invertTrck").Value = int.Parse(value);
        }
        private void opacityNUD_ValueChanged(object sender,EventArgs e)
        {
            var ctrl = (Control)sender;
            var frm = ctrl.FindForm();
            string value = frm.Controls.OfType<NumericUpDown>().FirstOrDefault(y => y.Name == "opacityNUD").Value.ToString();
            frm.Controls.OfType<TrackBar>().FirstOrDefault(y => y.Name == "opacityTrck").Value = int.Parse(value);
        }
        private void saturateNUD_ValueChanged(object sender,EventArgs e)
        {
            var ctrl = (Control)sender;
            var frm = ctrl.FindForm();
            string value = frm.Controls.OfType<NumericUpDown>().FirstOrDefault(y => y.Name == "saturateNUD").Value.ToString();
            frm.Controls.OfType<TrackBar>().FirstOrDefault(y => y.Name == "saturateTrck").Value = int.Parse(value);
        }
        private void sepiaNUD_ValueChanged(object sender,EventArgs e)
        {
            var ctrl = (Control)sender;
            var frm = ctrl.FindForm();
            string value = frm.Controls.OfType<NumericUpDown>().FirstOrDefault(y => y.Name == "sepiaNUD").Value.ToString();
            frm.Controls.OfType<TrackBar>().FirstOrDefault(y => y.Name == "sepiaTrck").Value = int.Parse(value);
        }
        private void initialCheck_CheckedChanged(object sender,EventArgs e)
        {
            var ctrl = (Control)sender;
            var frm = ctrl.FindForm();
            if (frm.Controls.OfType<CheckBox>().FirstOrDefault(y => y.Name == "initialCheck").Checked == true)
            {
                frm.Controls.OfType<TrackBar>().FirstOrDefault(y => y.Name == "blurTrck").Enabled = false;
                frm.Controls.OfType<CheckBox>().FirstOrDefault(y => y.Name == "inactive").Enabled = false;
                frm.Controls.OfType<TrackBar>().FirstOrDefault(y => y.Name == "brightnessTrck").Enabled = false;
                frm.Controls.OfType<TrackBar>().FirstOrDefault(y => y.Name == "cotnrastTrck").Enabled = false;
                frm.Controls.OfType<TrackBar>().FirstOrDefault(y => y.Name == "grayscaleTrck").Enabled = false;
                frm.Controls.OfType<TrackBar>().FirstOrDefault(y => y.Name == "sepiaTrck").Enabled = false;
                frm.Controls.OfType<TrackBar>().FirstOrDefault(y => y.Name == "saturateTrck").Enabled = false;
                frm.Controls.OfType<TrackBar>().FirstOrDefault(y => y.Name == "opacityTrck").Enabled = false;
                frm.Controls.OfType<TrackBar>().FirstOrDefault(y => y.Name == "invertTrck").Enabled = false;
                frm.Controls.OfType<TrackBar>().FirstOrDefault(y => y.Name == "huerotateTrck").Enabled = false;
                frm.Controls.OfType<NumericUpDown>().FirstOrDefault(y => y.Name == "blurNUD").Enabled = false;
                frm.Controls.OfType<NumericUpDown>().FirstOrDefault(y => y.Name == "brightnessNUD").Enabled = false;
                frm.Controls.OfType<NumericUpDown>().FirstOrDefault(y => y.Name == "contrastNUD").Enabled = false;
                frm.Controls.OfType<NumericUpDown>().FirstOrDefault(y => y.Name == "grayscaleNUD").Enabled = false;
                frm.Controls.OfType<NumericUpDown>().FirstOrDefault(y => y.Name == "huerotateNUD").Enabled = false;
                frm.Controls.OfType<NumericUpDown>().FirstOrDefault(y => y.Name == "invertNUD").Enabled = false;
                frm.Controls.OfType<NumericUpDown>().FirstOrDefault(y => y.Name == "opacityNUD").Enabled = false;
                frm.Controls.OfType<NumericUpDown>().FirstOrDefault(y => y.Name == "saturateNUD").Enabled = false;
                frm.Controls.OfType<NumericUpDown>().FirstOrDefault(y => y.Name == "sepiaNUD").Enabled = false;
                frm.Controls.OfType<GroupBox>().FirstOrDefault(y => y.Name == "dropshadow").Controls.OfType<TextBox>().FirstOrDefault(y => y.Name == "colorCode").Enabled = false;
                frm.Controls.OfType<GroupBox>().FirstOrDefault(y => y.Name == "dropshadow").Controls.OfType<Button>().FirstOrDefault(y => y.Name == "dropColorSelect").Enabled = false;
                frm.Controls.OfType<GroupBox>().FirstOrDefault(y => y.Name == "dropshadow").Controls.OfType<NumericUpDown>().FirstOrDefault(y => y.Name == "vshadowNUD").Enabled = false;
                frm.Controls.OfType<GroupBox>().FirstOrDefault(y => y.Name == "dropshadow").Controls.OfType<NumericUpDown>().FirstOrDefault(y => y.Name == "hshadowNUD").Enabled = false;
                frm.Controls.OfType<GroupBox>().FirstOrDefault(y => y.Name == "dropshadow").Controls.OfType<TrackBar>().FirstOrDefault(y => y.Name == "vshadowTrck").Enabled = false;
                frm.Controls.OfType<GroupBox>().FirstOrDefault(y => y.Name == "dropshadow").Controls.OfType<TrackBar>().FirstOrDefault(y => y.Name == "hshadowTrck").Enabled = false;
            }
            else
            {
                frm.Controls.OfType<TrackBar>().FirstOrDefault(y => y.Name == "blurTrck").Enabled = true;
                frm.Controls.OfType<CheckBox>().FirstOrDefault(y => y.Name == "inactive").Enabled = true;
                frm.Controls.OfType<TrackBar>().FirstOrDefault(y => y.Name == "brightnessTrck").Enabled = true;
                frm.Controls.OfType<TrackBar>().FirstOrDefault(y => y.Name == "cotnrastTrck").Enabled = true;
                frm.Controls.OfType<TrackBar>().FirstOrDefault(y => y.Name == "grayscaleTrck").Enabled = true;
                frm.Controls.OfType<TrackBar>().FirstOrDefault(y => y.Name == "sepiaTrck").Enabled = true;
                frm.Controls.OfType<TrackBar>().FirstOrDefault(y => y.Name == "saturateTrck").Enabled = true;
                frm.Controls.OfType<TrackBar>().FirstOrDefault(y => y.Name == "opacityTrck").Enabled = true;
                frm.Controls.OfType<TrackBar>().FirstOrDefault(y => y.Name == "invertTrck").Enabled = true;
                frm.Controls.OfType<TrackBar>().FirstOrDefault(y => y.Name == "huerotateTrck").Enabled = true;
                frm.Controls.OfType<NumericUpDown>().FirstOrDefault(y => y.Name == "blurNUD").Enabled = true;
                frm.Controls.OfType<NumericUpDown>().FirstOrDefault(y => y.Name == "brightnessNUD").Enabled = true;
                frm.Controls.OfType<NumericUpDown>().FirstOrDefault(y => y.Name == "contrastNUD").Enabled = true;
                frm.Controls.OfType<NumericUpDown>().FirstOrDefault(y => y.Name == "grayscaleNUD").Enabled = true;
                frm.Controls.OfType<NumericUpDown>().FirstOrDefault(y => y.Name == "huerotateNUD").Enabled = true;
                frm.Controls.OfType<NumericUpDown>().FirstOrDefault(y => y.Name == "invertNUD").Enabled = true;
                frm.Controls.OfType<NumericUpDown>().FirstOrDefault(y => y.Name == "opacityNUD").Enabled = true;
                frm.Controls.OfType<NumericUpDown>().FirstOrDefault(y => y.Name == "saturateNUD").Enabled = true;
                frm.Controls.OfType<NumericUpDown>().FirstOrDefault(y => y.Name == "sepiaNUD").Enabled = true;
                frm.Controls.OfType<GroupBox>().FirstOrDefault(y => y.Name == "dropshadow").Controls.OfType<TextBox>().FirstOrDefault(y => y.Name == "colorCode").Enabled = true;
                frm.Controls.OfType<GroupBox>().FirstOrDefault(y => y.Name == "dropshadow").Controls.OfType<Button>().FirstOrDefault(y => y.Name == "dropColorSelect").Enabled = true;
                frm.Controls.OfType<GroupBox>().FirstOrDefault(y => y.Name == "dropshadow").Controls.OfType<NumericUpDown>().FirstOrDefault(y => y.Name == "vshadowNUD").Enabled = true;
                frm.Controls.OfType<GroupBox>().FirstOrDefault(y => y.Name == "dropshadow").Controls.OfType<NumericUpDown>().FirstOrDefault(y => y.Name == "hshadowNUD").Enabled = true;
                frm.Controls.OfType<GroupBox>().FirstOrDefault(y => y.Name == "dropshadow").Controls.OfType<TrackBar>().FirstOrDefault(y => y.Name == "vshadowTrck").Enabled = true;
                frm.Controls.OfType<GroupBox>().FirstOrDefault(y => y.Name == "dropshadow").Controls.OfType<TrackBar>().FirstOrDefault(y => y.Name == "hshadowTrck").Enabled = true;
            }
        }
        private void inactiveFilter_CheckedChanged(object sender,EventArgs e)
        {
            var ctrl = (Control)sender;
            var frm = ctrl.FindForm();
            if (frm.Controls.OfType<CheckBox>().FirstOrDefault(y => y.Name == "inactive").Checked == true)
            {
                frm.Controls.OfType<TrackBar>().FirstOrDefault(y => y.Name == "blurTrck").Enabled = false;
                frm.Controls.OfType<CheckBox>().FirstOrDefault(y => y.Name == "initialCheck").Enabled = false;
                frm.Controls.OfType<TrackBar>().FirstOrDefault(y => y.Name == "brightnessTrck").Enabled = false;
                frm.Controls.OfType<TrackBar>().FirstOrDefault(y => y.Name == "cotnrastTrck").Enabled = false;
                frm.Controls.OfType<TrackBar>().FirstOrDefault(y => y.Name == "grayscaleTrck").Enabled = false;
                frm.Controls.OfType<TrackBar>().FirstOrDefault(y => y.Name == "sepiaTrck").Enabled = false;
                frm.Controls.OfType<TrackBar>().FirstOrDefault(y => y.Name == "saturateTrck").Enabled = false;
                frm.Controls.OfType<TrackBar>().FirstOrDefault(y => y.Name == "opacityTrck").Enabled = false;
                frm.Controls.OfType<TrackBar>().FirstOrDefault(y => y.Name == "invertTrck").Enabled = false;
                frm.Controls.OfType<TrackBar>().FirstOrDefault(y => y.Name == "huerotateTrck").Enabled = false;
                frm.Controls.OfType<NumericUpDown>().FirstOrDefault(y => y.Name == "blurNUD").Enabled = false;
                frm.Controls.OfType<NumericUpDown>().FirstOrDefault(y => y.Name == "brightnessNUD").Enabled = false;
                frm.Controls.OfType<NumericUpDown>().FirstOrDefault(y => y.Name == "contrastNUD").Enabled = false;
                frm.Controls.OfType<NumericUpDown>().FirstOrDefault(y => y.Name == "grayscaleNUD").Enabled = false;
                frm.Controls.OfType<NumericUpDown>().FirstOrDefault(y => y.Name == "huerotateNUD").Enabled = false;
                frm.Controls.OfType<NumericUpDown>().FirstOrDefault(y => y.Name == "invertNUD").Enabled = false;
                frm.Controls.OfType<NumericUpDown>().FirstOrDefault(y => y.Name == "opacityNUD").Enabled = false;
                frm.Controls.OfType<NumericUpDown>().FirstOrDefault(y => y.Name == "saturateNUD").Enabled = false;
                frm.Controls.OfType<NumericUpDown>().FirstOrDefault(y => y.Name == "sepiaNUD").Enabled = false;
                frm.Controls.OfType<GroupBox>().FirstOrDefault(y => y.Name == "dropshadow").Controls.OfType<TextBox>().FirstOrDefault(y => y.Name == "colorCode").Enabled = false;
                frm.Controls.OfType<GroupBox>().FirstOrDefault(y => y.Name == "dropshadow").Controls.OfType<Button>().FirstOrDefault(y => y.Name == "dropColorSelect").Enabled = false;
                frm.Controls.OfType<GroupBox>().FirstOrDefault(y => y.Name == "dropshadow").Controls.OfType<NumericUpDown>().FirstOrDefault(y => y.Name == "vshadowNUD").Enabled = false;
                frm.Controls.OfType<GroupBox>().FirstOrDefault(y => y.Name == "dropshadow").Controls.OfType<NumericUpDown>().FirstOrDefault(y => y.Name == "hshadowNUD").Enabled = false;
                frm.Controls.OfType<GroupBox>().FirstOrDefault(y => y.Name == "dropshadow").Controls.OfType<TrackBar>().FirstOrDefault(y => y.Name == "vshadowTrck").Enabled = false;
                frm.Controls.OfType<GroupBox>().FirstOrDefault(y => y.Name == "dropshadow").Controls.OfType<TrackBar>().FirstOrDefault(y => y.Name == "hshadowTrck").Enabled = false;
            }
            else
            {
                frm.Controls.OfType<TrackBar>().FirstOrDefault(y => y.Name == "blurTrck").Enabled = true;
                frm.Controls.OfType<CheckBox>().FirstOrDefault(y => y.Name == "initialCheck").Enabled = true;
                frm.Controls.OfType<TrackBar>().FirstOrDefault(y => y.Name == "brightnessTrck").Enabled = true;
                frm.Controls.OfType<TrackBar>().FirstOrDefault(y => y.Name == "cotnrastTrck").Enabled = true;
                frm.Controls.OfType<TrackBar>().FirstOrDefault(y => y.Name == "grayscaleTrck").Enabled = true;
                frm.Controls.OfType<TrackBar>().FirstOrDefault(y => y.Name == "sepiaTrck").Enabled = true;
                frm.Controls.OfType<TrackBar>().FirstOrDefault(y => y.Name == "saturateTrck").Enabled = true;
                frm.Controls.OfType<TrackBar>().FirstOrDefault(y => y.Name == "opacityTrck").Enabled = true;
                frm.Controls.OfType<TrackBar>().FirstOrDefault(y => y.Name == "invertTrck").Enabled = true;
                frm.Controls.OfType<TrackBar>().FirstOrDefault(y => y.Name == "huerotateTrck").Enabled = true;
                frm.Controls.OfType<NumericUpDown>().FirstOrDefault(y => y.Name == "blurNUD").Enabled = true;
                frm.Controls.OfType<NumericUpDown>().FirstOrDefault(y => y.Name == "brightnessNUD").Enabled = true;
                frm.Controls.OfType<NumericUpDown>().FirstOrDefault(y => y.Name == "contrastNUD").Enabled = true;
                frm.Controls.OfType<NumericUpDown>().FirstOrDefault(y => y.Name == "grayscaleNUD").Enabled = true;
                frm.Controls.OfType<NumericUpDown>().FirstOrDefault(y => y.Name == "huerotateNUD").Enabled = true;
                frm.Controls.OfType<NumericUpDown>().FirstOrDefault(y => y.Name == "invertNUD").Enabled = true;
                frm.Controls.OfType<NumericUpDown>().FirstOrDefault(y => y.Name == "opacityNUD").Enabled = true;
                frm.Controls.OfType<NumericUpDown>().FirstOrDefault(y => y.Name == "saturateNUD").Enabled = true;
                frm.Controls.OfType<NumericUpDown>().FirstOrDefault(y => y.Name == "sepiaNUD").Enabled = true;
                frm.Controls.OfType<GroupBox>().FirstOrDefault(y => y.Name == "dropshadow").Controls.OfType<TextBox>().FirstOrDefault(y => y.Name == "colorCode").Enabled = true;
                frm.Controls.OfType<GroupBox>().FirstOrDefault(y => y.Name == "dropshadow").Controls.OfType<Button>().FirstOrDefault(y => y.Name == "dropColorSelect").Enabled = true;
                frm.Controls.OfType<GroupBox>().FirstOrDefault(y => y.Name == "dropshadow").Controls.OfType<NumericUpDown>().FirstOrDefault(y => y.Name == "vshadowNUD").Enabled = true;
                frm.Controls.OfType<GroupBox>().FirstOrDefault(y => y.Name == "dropshadow").Controls.OfType<NumericUpDown>().FirstOrDefault(y => y.Name == "hshadowNUD").Enabled = true;
                frm.Controls.OfType<GroupBox>().FirstOrDefault(y => y.Name == "dropshadow").Controls.OfType<TrackBar>().FirstOrDefault(y => y.Name == "vshadowTrck").Enabled = true;
                frm.Controls.OfType<GroupBox>().FirstOrDefault(y => y.Name == "dropshadow").Controls.OfType<TrackBar>().FirstOrDefault(y => y.Name == "hshadowTrck").Enabled = true;
            }
        }
        private void blurTrck_Scroll(object sender,EventArgs e)
        {
            var ctrl = (Control)sender;
            var frm = ctrl.FindForm();
            string value = frm.Controls.OfType<TrackBar>().FirstOrDefault(y => y.Name == "blurTrck").Value.ToString();
            frm.Controls.OfType<NumericUpDown>().FirstOrDefault(y => y.Name == "blurNUD").Value = int.Parse(value);
        }
        private void blurNUD_ValueChanged(object sender,EventArgs e)
        {
            var ctrl = (Control)sender;
            var frm = ctrl.FindForm();
            string value = frm.Controls.OfType<NumericUpDown>().FirstOrDefault(y => y.Name == "blurNUD").Value.ToString();
            frm.Controls.OfType<TrackBar>().FirstOrDefault(y => y.Name == "blurTrck").Value = int.Parse(value);
        }
        private void filterCanel_Click(object sender,EventArgs e)
        {
            var ctrl = (Control)sender;
            var frm = ctrl.FindForm();
            frm.Close();
        }
        private void lrtbOK_Click(object sender,EventArgs e)
        {
            var ctrl = (Control)sender;
            var frm = ctrl.FindForm();
            switch(frm.Controls.OfType<ComboBox>().FirstOrDefault(y => y.Name == "leftMeasure").SelectedIndex)
            {
                case 0:
                    if (frm.Controls.OfType<NumericUpDown>().FirstOrDefault(y => y.Name == "leftVal").Value != 0)
                    {
                        textArea.SelectedText = string.Format("left: {0}px;\n", frm.Controls.OfType<NumericUpDown>().FirstOrDefault(y => y.Name == "leftVal").Value);
                    }
                    break;
                case 1:
                    if (frm.Controls.OfType<NumericUpDown>().FirstOrDefault(y => y.Name == "leftVal").Value != 0)
                    {
                        textArea.SelectedText = string.Format("left: {0}%;\n", frm.Controls.OfType<NumericUpDown>().FirstOrDefault(y => y.Name == "leftVal").Value);
                    }
                    break;
            }
            switch (frm.Controls.OfType<ComboBox>().FirstOrDefault(y => y.Name == "rightMeasure").SelectedIndex)
            {
                case 0:
                    if (frm.Controls.OfType<NumericUpDown>().FirstOrDefault(y => y.Name == "rightVal").Value != 0)
                    {
                        textArea.SelectedText = string.Format("right: {0}px;\n", frm.Controls.OfType<NumericUpDown>().FirstOrDefault(y => y.Name == "rightVal").Value);
                    }
                    break;
                case 1:
                    if (frm.Controls.OfType<NumericUpDown>().FirstOrDefault(y => y.Name == "rightVal").Value != 0)
                    {
                        textArea.SelectedText = string.Format("right: {0}%;\n", frm.Controls.OfType<NumericUpDown>().FirstOrDefault(y => y.Name == "rightVal").Value);
                    }
                    break;
            }
            switch (frm.Controls.OfType<ComboBox>().FirstOrDefault(y => y.Name == "topMeasure").SelectedIndex)
            {
                case 0:
                    if (frm.Controls.OfType<NumericUpDown>().FirstOrDefault(y => y.Name == "topVal").Value != 0)
                    {
                        textArea.SelectedText = string.Format("top: {0}px;\n", frm.Controls.OfType<NumericUpDown>().FirstOrDefault(y => y.Name == "topVal").Value);
                    }
                    break;
                case 1:
                    if (frm.Controls.OfType<NumericUpDown>().FirstOrDefault(y => y.Name == "topVal").Value != 0)
                    {
                        textArea.SelectedText = string.Format("top: {0}%;\n", frm.Controls.OfType<NumericUpDown>().FirstOrDefault(y => y.Name == "topVal").Value);
                    }
                    break;
            }
            switch (frm.Controls.OfType<ComboBox>().FirstOrDefault(y => y.Name == "bottomMeasure").SelectedIndex)
            {
                case 0:
                    if (frm.Controls.OfType<NumericUpDown>().FirstOrDefault(y => y.Name == "bottomVal").Value != 0)
                    {
                        textArea.SelectedText = string.Format("bottom: {0}px;\n", frm.Controls.OfType<NumericUpDown>().FirstOrDefault(y => y.Name == "bottomVal").Value);
                    }
                    break;
                case 1:
                    if (frm.Controls.OfType<NumericUpDown>().FirstOrDefault(y => y.Name == "bottomVal").Value != 0)
                    {
                        textArea.SelectedText = string.Format("bottom: {0}%;\n", frm.Controls.OfType<NumericUpDown>().FirstOrDefault(y => y.Name == "bottomVal").Value);
                    }
                    break;
            }
            frm.Close();
        }
        private void topMeasure_SelectedIndexChanged(object sender,EventArgs e)
        {
            var ctrl = (Control)sender;
            var frm = ctrl.FindForm();
            int itemIndex = frm.Controls.OfType<ComboBox>().FirstOrDefault(y => y.Name == "topMeasure").SelectedIndex;
            switch (itemIndex)
            {
                case 0:
                    frm.Controls.OfType<NumericUpDown>().FirstOrDefault(y => y.Name == "topVal").Maximum = 8192;
                    break;
                case 1:
                    frm.Controls.OfType<NumericUpDown>().FirstOrDefault(y => y.Name == "topVal").Maximum = 100;
                    break;
            }
        }
        private void bottomMeasure_SelectedIndexChanged(object sender,EventArgs e)
        {
            var ctrl = (Control)sender;
            var frm = ctrl.FindForm();
            int itemIndex = frm.Controls.OfType<ComboBox>().FirstOrDefault(y => y.Name == "bottomMeasure").SelectedIndex;
            switch (itemIndex)
            {
                case 0:
                    frm.Controls.OfType<NumericUpDown>().FirstOrDefault(y => y.Name == "bottomVal").Maximum = 8192;
                    break;
                case 1:
                    frm.Controls.OfType<NumericUpDown>().FirstOrDefault(y => y.Name == "bottomVal").Maximum = 100;
                    break;
            }
        }
        private void rightMeasure_SelectedIndexChanged(object sender, EventArgs e)
        {
            var ctrl = (Control)sender;
            var frm = ctrl.FindForm();
            int itemIndex = frm.Controls.OfType<ComboBox>().FirstOrDefault(y => y.Name == "rightMeasure").SelectedIndex;
            switch (itemIndex)
            {
                case 0:
                    frm.Controls.OfType<NumericUpDown>().FirstOrDefault(y => y.Name == "rightVal").Maximum = 8192;
                    break;
                case 1:
                    frm.Controls.OfType<NumericUpDown>().FirstOrDefault(y => y.Name == "rightVal").Maximum = 100;
                    break;
            }
        }
        private void leftMeasure_SelectedIndexChanged(object sender,EventArgs e)
        {
            var ctrl = (Control)sender;
            var frm = ctrl.FindForm();
            int itemIndex = frm.Controls.OfType<ComboBox>().FirstOrDefault(y => y.Name == "leftMeasure").SelectedIndex;
            switch (itemIndex)
            {
                case 0:
                    frm.Controls.OfType<NumericUpDown>().FirstOrDefault(y => y.Name == "leftVal").Maximum = 8192;
                    break;
                case 1:
                    frm.Controls.OfType<NumericUpDown>().FirstOrDefault(y => y.Name == "leftVal").Maximum = 100;
                    break;
            }
        }
        private void lrtbCancel_Click(object sender,EventArgs e)
        {
            var ctrl = (Control)sender;
            var frm = ctrl.FindForm();
            frm.Close();
        }
        private void transitionOK_Click(object sender,EventArgs e)
        {
            var ctrl = (Control)sender;
            var frm = ctrl.FindForm();
            if (frm.Controls.OfType<CheckBox>().FirstOrDefault(y => y.Name == "propertyNone").Checked == true)
            {
                textArea.SelectedText = "transition-property: none;\n";
            }
            if (frm.Controls.OfType<TextBox>().FirstOrDefault(y => y.Name == "propertyVal").Text != String.Empty)
            {
                textArea.SelectedText = string.Format("transition-property: {0};\n", frm.Controls.OfType<TextBox>().FirstOrDefault(y => y.Name == "propertyVal").Text);
            }
            if (frm.Controls.OfType<NumericUpDown>().FirstOrDefault(y => y.Name == "durationVal").Value != 0)
            {
                textArea.SelectedText = string.Format("transition-duration: {0}s;\n", frm.Controls.OfType<NumericUpDown>().FirstOrDefault(y => y.Name == "durationVal").Value);
            }
            if (frm.Controls.OfType<ComboBox>().FirstOrDefault(y => y.Name == "timingFunction").SelectedItem != null)
            {
                textArea.SelectedText = string.Format("transition-timing-function: {0};\n", frm.Controls.OfType<ComboBox>().FirstOrDefault(y => y.Name == "timingFunction").SelectedItem);
            }
            if (frm.Controls.OfType<NumericUpDown>().FirstOrDefault(y => y.Name == "delayVal").Value != 0)
            {
                textArea.SelectedText = string.Format("transition-delay: {0}s;\n", frm.Controls.OfType<NumericUpDown>().FirstOrDefault(y => y.Name == "delayVal").Value);
            }
            frm.Close();
        } 
        private void transitionCancel_Click(object sender,EventArgs e)
        {
            var ctrl = (Control)sender;
            var frm = ctrl.FindForm();
            frm.Close();
        }
        private void propertyNone_CheckedChanged(object sender,EventArgs e)
        {
            var ctrl = (Control)sender;
            var frm = ctrl.FindForm();
            if (frm.Controls.OfType<CheckBox>().FirstOrDefault(y => y.Name == "propertyNone").Checked == true)
            {
                frm.Controls.OfType<TextBox>().FirstOrDefault(y => y.Name == "propertyVal").Enabled = false;
            }
            else
            {
                frm.Controls.OfType<TextBox>().FirstOrDefault(y => y.Name == "propertyVal").Enabled = true;
            }
        }
        private void elementSizeOK_Click(object sender,EventArgs e)
        {
            var ctrl = (Control)sender;
            var frm = ctrl.FindForm();
            object selectedHeight = frm.Controls.OfType<ListBox>().FirstOrDefault(y => y.Name == "heights").SelectedItem;
            object selectedWeight = frm.Controls.OfType<ListBox>().FirstOrDefault(y => y.Name == "widths").SelectedItem;
            decimal number1 = frm.Controls.OfType<NumericUpDown>().FirstOrDefault(y => y.Name == "heightVal").Value;
            decimal number2 = frm.Controls.OfType<NumericUpDown>().FirstOrDefault(y => y.Name == "widthVal").Value;
            string measure1 = null;
            string measure2 = null;
            if(frm.Controls.OfType<ComboBox>().FirstOrDefault(y => y.Name == "heightM").SelectedIndex == 0)
            {
                measure1 = "px";   
            }
            if (frm.Controls.OfType<ComboBox>().FirstOrDefault(y => y.Name == "heightM").SelectedIndex == 1)
            {
                measure1 = "%";
            }
            if (frm.Controls.OfType<ComboBox>().FirstOrDefault(y => y.Name == "widthM").SelectedIndex == 0)
            {
                measure2 = "px";
            }
            if (frm.Controls.OfType<ComboBox>().FirstOrDefault(y => y.Name == "widthM").SelectedIndex == 1)
            {
                measure2 = "%";
            }
            if (selectedHeight != null && selectedWeight != null)
            {
                textArea.SelectedText = string.Format("{0}: {1}{2};\n", selectedHeight, number1, measure1);
                textArea.SelectedText = string.Format("{0}: {1}{2};\n", selectedWeight, number2, measure2);
            }
            frm.Close();
        }
        private void heightM_SelectedIndexChanged(object sender,EventArgs e)
        {
            var ctrl = (Control)sender;
            var frm = ctrl.FindForm();
            int itemIndex = frm.Controls.OfType<ComboBox>().FirstOrDefault(y => y.Name == "heightM").SelectedIndex;
            switch (itemIndex)
            {
                case 0:
                    frm.Controls.OfType<NumericUpDown>().FirstOrDefault(y => y.Name == "heightVal").Maximum = 8192;
                    break;
                case 1:
                    frm.Controls.OfType<NumericUpDown>().FirstOrDefault(y => y.Name == "heightVal").Maximum = 100;
                    break;
            }
        }
        private void widthM_CheckedChanged(object sender,EventArgs e)
        {
            var ctrl = (Control)sender;
            var frm = ctrl.FindForm();
            int itemIndex = frm.Controls.OfType<ComboBox>().FirstOrDefault(y => y.Name == "widthM").SelectedIndex;
            switch (itemIndex)
            {
                case 0:
                    frm.Controls.OfType<NumericUpDown>().FirstOrDefault(y => y.Name == "widthVal").Maximum = 8192;
                    break;
                case 1:
                    frm.Controls.OfType<NumericUpDown>().FirstOrDefault(y => y.Name == "widthVal").Maximum = 100;
                    break;
            }
        }
        private void elementSizeCancel_Click(object sender,EventArgs e)
        {
            var ctrl = (Control)sender;
            var frm = ctrl.FindForm();
            frm.Close();
        }
        private void captionSideOK_Click(object sender,EventArgs e)
        {
            var ctrl = (Control)sender;
            var frm = ctrl.FindForm();
            if (frm.Controls.OfType<RadioButton>().FirstOrDefault(y => y.Name == "captionTop").Checked == true)
            {
                textArea.SelectedText = "caption-side: top;\n";
            }
            if (frm.Controls.OfType<RadioButton>().FirstOrDefault(y => y.Name == "captionBottom").Checked == true)
            {
                textArea.SelectedText = "caption-side: bottom;\n";
            }
            if (frm.Controls.OfType<RadioButton>().FirstOrDefault(y => y.Name == "captionLeft").Checked == true)
            {
                textArea.SelectedText = "caption-side: left;\n";
            }
            if (frm.Controls.OfType<RadioButton>().FirstOrDefault(y => y.Name == "captionRight").Checked == true)
            {
                textArea.SelectedText = "caption-side: right;\n";
            }
            frm.Close();
        }
        private void captionSideCancel_Click(object sender,EventArgs e)
        {
            var ctrl = (Control)sender;
            var frm = ctrl.FindForm();
            frm.Close();
        }
        private void listStyleOK_Click(object sender,EventArgs e)
        {
            string[] data = new string[6];
            var ctrl = (Control)sender;
            var frm = ctrl.FindForm();
            if (frm.Controls.OfType<CheckBox>().FirstOrDefault(y => y.Name == "noImgChck").Checked == true)
            {
                textArea.SelectedText = "list-style-image: none;\n";
            }
            if (frm.Controls.OfType<CheckBox>().FirstOrDefault(y => y.Name == "standartTypeChk").Checked == true)
            {
                textArea.SelectedText = "list-style-type: none;\n";
            }
            if (frm.Controls.OfType<RadioButton>().FirstOrDefault(y => y.Name == "inside").Checked == true)
            {
                textArea.SelectedText = "list-style-position: inside;\n";
            }
            if (frm.Controls.OfType<RadioButton>().FirstOrDefault(y => y.Name == "outside").Checked == true)
            {
                textArea.SelectedText = "list-style-position: outside;\n";
            }
            if (frm.Controls.OfType<ComboBox>().FirstOrDefault(y => y.Name == "styleTypes").SelectedItem != null && frm.Controls.OfType<ComboBox>().FirstOrDefault(y => y.Name == "styleTypes").Enabled==true)
            {
                textArea.SelectedText = string.Format("list-style-type: {0};\n", frm.Controls.OfType<ComboBox>().FirstOrDefault(y => y.Name == "styleTypes").SelectedItem);
            }
            if (frm.Controls.OfType<TextBox>().FirstOrDefault(y => y.Name == "pointerImgURL").Enabled == true && frm.Controls.OfType<TextBox>().FirstOrDefault(y => y.Name == "pointerImgURL").Text != String.Empty)
            {
                textArea.SelectedText = string.Format("list-style-image: url({0});\n", frm.Controls.OfType<TextBox>().FirstOrDefault(y => y.Name == "pointerImgURL").Text);
            }
            frm.Close();
        }
        private void pointerImgSelect_Click(object sender,EventArgs e)
        {
            imageOpen.ShowDialog();
            var ctrl = (Control)sender;
            var frm = ctrl.FindForm();
            frm.Controls.OfType<TextBox>().FirstOrDefault(y => y.Name == "pointerImgURL").Text = imageOpen.FileName;
        }
        private void noImgChck_CheckedChanged(object sender,EventArgs e)
        {
            var ctrl = (Control)sender;
            var frm = ctrl.FindForm();
            if (frm.Controls.OfType<CheckBox>().FirstOrDefault(y => y.Name == "noImgChck").Checked == true)
            {
                frm.Controls.OfType<TextBox>().FirstOrDefault(y => y.Name == "pointerImgURL").Enabled = false;
                frm.Controls.OfType<Button>().FirstOrDefault(y => y.Name == "pointerImgSelect").Enabled = false;
            }
            else
            {
                frm.Controls.OfType<TextBox>().FirstOrDefault(y => y.Name == "pointerImgURL").Enabled = true;
                frm.Controls.OfType<Button>().FirstOrDefault(y => y.Name == "pointerImgSelect").Enabled = true;
            }
        }
        private void standartTypeChk_CheckedChanged(object sender,EventArgs e)
        {
            var ctrl = (Control)sender;
            var frm = ctrl.FindForm();
            if (frm.Controls.OfType<CheckBox>().FirstOrDefault(y=>y.Name== "standartTypeChk").Checked == true)
            {
                frm.Controls.OfType<ComboBox>().FirstOrDefault(y => y.Name == "styleTypes").Enabled = false;
            }
            else
            {
                frm.Controls.OfType<ComboBox>().FirstOrDefault(y => y.Name == "styleTypes").Enabled = true;
            }
        }
        private void listStyleCancel_Click(object sender,EventArgs e)
        {
            var ctrl = (Control)sender;
            var frm = ctrl.FindForm();
            frm.Close();
        }
        private void shadowOK_Click(object sender, EventArgs e)
        {
            var ctrl = (Control)sender;
            var frm = ctrl.FindForm();
            string data1 = null;
            string data2 = null;
            string data3 = null;
            string data4 = null;
            string data5 = null;
            textArea.SelectedText = "box-shadow: ";
            data1 = frm.Controls.OfType<NumericUpDown>().FirstOrDefault(y => y.Name == "trackXVal").Value.ToString();
            data2 = frm.Controls.OfType<NumericUpDown>().FirstOrDefault(y => y.Name == "trackYVal").Value.ToString();
            data3 = frm.Controls.OfType<NumericUpDown>().FirstOrDefault(y => y.Name == "objBlurNUD").Value.ToString();
            data4 = frm.Controls.OfType<NumericUpDown>().FirstOrDefault(y => y.Name == "spreadNUD").Value.ToString();
            data5 = frm.Controls.OfType<TextBox>().FirstOrDefault(y => y.Name == "shadowColorVal").Text;
            if (frm.Controls.OfType<CheckBox>().FirstOrDefault(y => y.Name == "innerShadowChk").Checked == true)
            {
                 textArea.SelectedText = "inset ";
            }
            if (frm.Controls.OfType<CheckBox>().FirstOrDefault(y => y.Name == "inactiveChk").Checked == false)
            {
                textArea.SelectedText = string.Format("{0} {1} {2}px {3} {4};\n", data1, data2, data3, data4, data5);
            }
            if (frm.Controls.OfType<CheckBox>().FirstOrDefault(y => y.Name == "inactiveChk").Checked == true)
            {
                textArea.SelectedText = "none;\n";
            }
            frm.Close();
        }
        private void inactiveChk_CheckedChanged(object sender,EventArgs e)
        {
            var ctrl = (Control)sender;
            var frm = ctrl.FindForm();
            CheckBox checkB = null;
            foreach (var ctr in frm.Controls)
            {
                if (ctr is CheckBox)
                {
                    checkB = (CheckBox)ctr;
                    if (checkB.Name == "inactiveChk" && checkB.Checked == true)
                    {
                        frm.Controls.OfType<TrackBar>().FirstOrDefault(y => y.Name == "trackX").Enabled = false;
                        frm.Controls.OfType<NumericUpDown>().FirstOrDefault(y => y.Name == "trackXVal").Enabled = false;
                        frm.Controls.OfType<NumericUpDown>().FirstOrDefault(y => y.Name == "trackYVal").Enabled = false;
                        frm.Controls.OfType<TrackBar>().FirstOrDefault(y => y.Name == "trackY").Enabled = false;
                        frm.Controls.OfType<NumericUpDown>().FirstOrDefault(y => y.Name == "objBlurNUD").Enabled = false;
                        frm.Controls.OfType<TrackBar>().FirstOrDefault(y => y.Name == "objBlurTrck").Enabled = false;
                        frm.Controls.OfType<TrackBar>().FirstOrDefault(y => y.Name == "spreadTrck").Enabled = false;
                        frm.Controls.OfType<NumericUpDown>().FirstOrDefault(y => y.Name == "spreadNUD").Enabled = false;
                        frm.Controls.OfType<Button>().FirstOrDefault(y => y.Name == "shadowColorBtn").Enabled = false;
                        frm.Controls.OfType<TextBox>().FirstOrDefault(y => y.Name == "shadowColorVal").Enabled = false;
                    }
                    if (checkB.Name == "inactiveChk" && checkB.Checked == false)
                    {
                        frm.Controls.OfType<TrackBar>().FirstOrDefault(y => y.Name == "trackX").Enabled = true;
                        frm.Controls.OfType<NumericUpDown>().FirstOrDefault(y => y.Name == "trackXVal").Enabled = true;
                        frm.Controls.OfType<NumericUpDown>().FirstOrDefault(y => y.Name == "trackYVal").Enabled = true;
                        frm.Controls.OfType<TrackBar>().FirstOrDefault(y => y.Name == "trackY").Enabled = true;
                        frm.Controls.OfType<NumericUpDown>().FirstOrDefault(y => y.Name == "objBlurNUD").Enabled = true;
                        frm.Controls.OfType<TrackBar>().FirstOrDefault(y => y.Name == "objBlurTrck").Enabled = true;
                        frm.Controls.OfType<TrackBar>().FirstOrDefault(y => y.Name == "spreadTrck").Enabled = true;
                        frm.Controls.OfType<NumericUpDown>().FirstOrDefault(y => y.Name == "spreadNUD").Enabled = true;
                        frm.Controls.OfType<Button>().FirstOrDefault(y => y.Name == "shadowColorBtn").Enabled = true;
                        frm.Controls.OfType<TextBox>().FirstOrDefault(y => y.Name == "shadowColorVal").Enabled = true;
                    }
                }
            }
        }
        private void shadowColorBtn_Click(object sender,EventArgs e)
        {
            System.Windows.Forms.ColorDialog shadowColorSet = new ColorDialog();
            shadowColorSet.ShowHelp = true;
            if (shadowColorSet.ShowDialog() != DialogResult.Cancel)
            {
                Color sColor = shadowColorSet.Color;
                var ctrl = (Control)sender;
                var frm = ctrl.FindForm();
                TextBox txt1 = null;
                foreach (var ctr in frm.Controls)
                {
                    if (ctr is TextBox)
                    {
                        txt1 = (TextBox)ctr;
                        if (txt1.Name == "shadowColorVal")
                        {
                            txt1.Text = string.Format("#{0:X2}{1:X2}{2:X2}", sColor.R, sColor.G, sColor.B);
                        }
                    }
                }
            }
        }
        private void spreadNUD_ValueChanged(object sender,EventArgs e)
        {
            var ctrl = (Control)sender;
            var frm = ctrl.FindForm();
            NumericUpDown nud1 = null;
            foreach (var ctr in frm.Controls)
            {
                if (ctr is NumericUpDown)
                {
                    nud1 = (NumericUpDown)ctr;
                    if (nud1.Name == "spreadNUD")
                    {
                        string val1 = nud1.Value.ToString();
                        frm.Controls.OfType<TrackBar>().FirstOrDefault(y => y.Name == "spreadTrck").Value = int.Parse(val1);
                    }
                }

            }
        }
        private void spreadTrck_Scroll(object sender,EventArgs e)
        {
            var ctrl = (Control)sender;
            var frm = ctrl.FindForm();
            TrackBar trck2 = null;
            foreach (var ctr in frm.Controls)
            {
                if (ctr is TrackBar)
                {
                    trck2 = (TrackBar)ctr;
                    if (trck2.Name == "spreadTrck")
                    {
                        string val1 = trck2.Value.ToString();
                        frm.Controls.OfType<NumericUpDown>().FirstOrDefault(y => y.Name == "spreadNUD").Value = decimal.Parse(val1);
                    }
                }

            }
        }
        private void objBlurTrck_Scroll(object sender, EventArgs e)
        {
            var ctrl = (Control)sender;
            var frm = ctrl.FindForm();
            TrackBar trck2 = null;
            foreach (var ctr in frm.Controls)
            {
                if (ctr is TrackBar)
                {
                    trck2 = (TrackBar)ctr;
                    if (trck2.Name == "objBlurTrck")
                    {
                        string val1 = trck2.Value.ToString();
                        frm.Controls.OfType<NumericUpDown>().FirstOrDefault(y => y.Name == "objBlurNUD").Value = decimal.Parse(val1);
                    }
                }

            }
        }
        private void objBlurNUD_ValueChanged(object sender, EventArgs e)
        {
            var ctrl = (Control)sender;
            var frm = ctrl.FindForm();
            NumericUpDown nud1 = null;
            foreach (var ctr in frm.Controls)
            {
                if (ctr is NumericUpDown)
                {
                    nud1 = (NumericUpDown)ctr;
                    if (nud1.Name == "objBlurNUD")
                    {
                        string val1 = nud1.Value.ToString();
                        frm.Controls.OfType<TrackBar>().FirstOrDefault(y => y.Name == "objBlurTrck").Value = int.Parse(val1);
                    }
                }

            }
        }
        private void trackY_Scroll(object sender,EventArgs e)
        {
            var ctrl = (Control)sender;
            var frm = ctrl.FindForm();
            TrackBar trck2 = null;
            foreach (var ctr in frm.Controls)
            {
                if (ctr is TrackBar)
                {
                    trck2 = (TrackBar)ctr;
                    if (trck2.Name == "trackY")
                    {
                        string val1 = trck2.Value.ToString();
                        frm.Controls.OfType<NumericUpDown>().FirstOrDefault(y => y.Name == "trackYVal").Value = decimal.Parse(val1);
                    }
                }

            }
        }
        private void trackYVal_ValueChanged(object sender,EventArgs e)
        {
            var ctrl = (Control)sender;
            var frm = ctrl.FindForm();
            NumericUpDown nud1 = null;
            foreach (var ctr in frm.Controls)
            {
                if (ctr is NumericUpDown)
                {
                    nud1 = (NumericUpDown)ctr;
                    if (nud1.Name == "trackYVal")
                    {
                        string val1 = nud1.Value.ToString();
                        frm.Controls.OfType<TrackBar>().FirstOrDefault(y => y.Name == "trackY").Value = int.Parse(val1);
                    }
                }

            }
        }
        private void trackX_Scroll(object sender,EventArgs e)
        {
            var ctrl = (Control)sender;
            var frm = ctrl.FindForm();
            TrackBar trck2 = null;
            foreach (var ctr in frm.Controls)
            {
                if (ctr is TrackBar)
                {
                    trck2 = (TrackBar)ctr;
                    if (trck2.Name == "trackX")
                    {
                        string val1 = trck2.Value.ToString();
                        frm.Controls.OfType<NumericUpDown>().FirstOrDefault(y => y.Name == "trackXVal").Value = decimal.Parse(val1);
                    }
                }

            }
        }
        private void trackXVal_ValueChanged(object sender,EventArgs e)
        {
            var ctrl = (Control)sender;
            var frm = ctrl.FindForm();
            NumericUpDown nud1 = null;
            foreach(var ctr in frm.Controls)
            {
                if(ctr is NumericUpDown)
                {
                    nud1 = (NumericUpDown)ctr;
                    if(nud1.Name== "trackXVal")
                    {
                        string val1 = nud1.Value.ToString();
                        frm.Controls.OfType<TrackBar>().FirstOrDefault(y => y.Name == "trackX").Value = int.Parse(val1);
                    }
                }
                
            }
        }
        private void shadowCancel_Click(object sender,EventArgs e)
        {
            var ctrl = (Control)sender;
            var frm = ctrl.FindForm();
            frm.Close();
        }
        private void boxOK_Click(object sender, EventArgs e)
        {
            var ctrl = (Control)sender;
            var frm = ctrl.FindForm();
            RadioButton boxRbtn;
            foreach (var ctr in frm.Controls)
            {
                if (ctr is RadioButton)
                {
                    boxRbtn = (RadioButton)ctr;
                    if (boxRbtn.Name == "contentBox" && boxRbtn.Checked)
                    {
                        textArea.SelectedText = string.Format("box-sizing: {0};\n",boxRbtn.Text);
                    }
                    if (boxRbtn.Name == "borderBox" && boxRbtn.Checked)
                    {
                        textArea.SelectedText = string.Format("box-sizing: {0};\n", boxRbtn.Text);
                    }
                    if (boxRbtn.Name == "paddingBox" && boxRbtn.Checked)
                    {
                        textArea.SelectedText = string.Format("box-sizing: {0};\n", boxRbtn.Text);
                    }
                }
            }
            frm.Close();
        }
        private void boxCancel_Click(object sender,EventArgs e)
        {
            var ctrl = (Control)sender;
            var frm = ctrl.FindForm();
            frm.Close();
        }
        private void displayOK_Click(object sender,EventArgs e)
        {
            var ctrl = (Control)sender;
            var frm = ctrl.FindForm();
            ComboBox displayCmb = null;
            foreach (var ctr in frm.Controls)
            {
                
                if (ctr is ComboBox)
                {
                    displayCmb = (ComboBox)ctr;
                    object selectedItem = displayCmb.SelectedItem;
                    if (displayCmb.Name == "displayTypes" && selectedItem != null)
                    {
                        textArea.SelectedText = string.Format("display: {0};\n", selectedItem);
                    }
                }
            }
            frm.Close();
        }
        private void displayCancel_Click(object sender,EventArgs e)
        {
            var ctrl = (Control)sender;
            var frm = ctrl.FindForm();
            frm.Close();
        }
        private void animateOK_Click(object sender, EventArgs e)
        {
            var ctrl = (Control)sender;
            var frm = ctrl.FindForm();
            TextBox animateText = null;
            NumericUpDown animateNud = null;
            CheckBox animateChk = null;
            ComboBox animateCmb = null;
            foreach (var ctr in frm.Controls)
            {
                if (ctr is TextBox)
                {
                    animateText = (TextBox)ctr;
                    if (animateText.Name == "animateNameVal" && animateText.Text != String.Empty)
                    {
                        textArea.SelectedText = string.Format("animation-name: {0};\n", animateText.Text);
                    }
                }
                if (ctr is NumericUpDown)
                {
                    animateNud = (NumericUpDown)ctr;
                    if(animateNud.Name == "animateDelay" && animateNud.Value != 0)
                    {
                        textArea.SelectedText = string.Format("animation-delay: {0}s;\n", animateNud.Value);
                    }
                    if (animateNud.Name == "animateDuration" && animateNud.Value != 0)
                    {
                        textArea.SelectedText = string.Format("animation-duration: {0}s;\n", animateNud.Value);
                    }
                    if (animateNud.Name == "animateIterationCount" && animateNud.Value != 0 && animateNud.Enabled == true)
                    {
                        textArea.SelectedText = string.Format("animation-iteration-count: {0};\n", animateNud.Value);
                    }
                }
                if (ctr is CheckBox)
                {
                    animateChk = (CheckBox)ctr;
                    if (animateChk.Name == "infiniteCheck" && animateChk.Checked == true)
                    {
                        textArea.SelectedText = "animation-iteration-count: infinite;\n";
                    }
                }
                if(ctr is ComboBox)
                {
                    animateCmb = (ComboBox)ctr;
                    object selectedItem = animateCmb.SelectedItem;
                     if(animateCmb.Name == "animateTimingFunc" && animateCmb.SelectedItem != null)
                        {
                            textArea.SelectedText = string.Format("animation-timing-function: {0};\n", selectedItem);
                        }
                    if (animateCmb.Name == "animateDirection" && animateCmb.SelectedItem != null)
                    {
                        textArea.SelectedText = string.Format("animation-direction: {0};\n", selectedItem);
                    }
                    if (animateCmb.Name == "animateFillMode" && animateCmb.SelectedItem != null)
                    {
                        textArea.SelectedText = string.Format("animation-fill-mode: {0};\n", selectedItem);
                    }
                    if (animateCmb.Name == "animatePlayState" && animateCmb.SelectedItem != null)
                    {
                        textArea.SelectedText = string.Format("animation-play-state: {0};\n", selectedItem);
                    }
                }
            }
            frm.Close();
        }
        private void infiniteCheck_CheckedChanged(object sender,EventArgs e)
        {
            var ctrl = (Control)sender;
            var frm = ctrl.FindForm();
            NumericUpDown infiNud = null;
            foreach (var ctr in frm.Controls)
            {
                if (ctr is NumericUpDown)
                {
                    infiNud = (NumericUpDown)ctr;
                    if (frm.Controls.OfType<CheckBox>().FirstOrDefault(y => y.Name == "infiniteCheck").Checked == false)
                    {
                        if (infiNud.Name == "animateIterationCount")
                        {
                            infiNud.Enabled = true;
                        }
                    }
                    else
                        if (frm.Controls.OfType<CheckBox>().FirstOrDefault(y => y.Name == "infiniteCheck").Checked == true)
                    {
                        if (infiNud.Name == "animateIterationCount")
                        {
                            infiNud.Enabled = false;
                        }
                    }
                }
            }

        }
        private void animateCancel_Click(object sender,EventArgs e)
        {
            var ctrl = (Control)sender;
            var frm = ctrl.FindForm();
            frm.Close();
        }
        private void alignCancel_Click(object sender,EventArgs e)
        {
            var ctrl = (Control)sender;
            var frm = ctrl.FindForm();
            frm.Close();
        }
        private void alignOK_Click(object sender, EventArgs e)
        {
            var ctrl = (Control)sender;
            var frm = ctrl.FindForm();
            ComboBox cmbx = null;
            GroupBox grobx = null;
            foreach (var ctr in frm.Controls)
            {
              if (ctr is GroupBox)
                {
                    grobx = (GroupBox)ctr;
                    foreach (Control controlSS in grobx.Controls)
                    {
                        if (controlSS is ComboBox)
                        {
                            cmbx = (ComboBox)controlSS;
                            object selectedItem = cmbx.SelectedItem;
                            if (cmbx.Name == "alignContentItems" && cmbx.SelectedItem != null)
                            {
                                textArea.SelectedText = string.Format("align-content: {0};\n",selectedItem);
                            }
                            if (cmbx.Name == "alignItemsItems" && cmbx.SelectedItem != null)
                                {
                                 textArea.SelectedText = string.Format("align-items: {0};\n", selectedItem);
                                }
                            if (cmbx.Name == "alignSelfItems" && cmbx.SelectedItem != null)
                            {
                                textArea.SelectedText = string.Format("align-self: {0};\n", selectedItem);
                            }
                        }
                    }
                }
            }
            frm.Close();
        }
        private void alignSelfItems_SelectedIndexChanged(object sender,EventArgs e)
        {
            var ctrl = (Control)sender;
            var frm = ctrl.FindForm();
            PictureBox pctbx = null;
            GroupBox grobx = null;
            foreach (var ctr in frm.Controls)
            {

                if (ctr is GroupBox)
                {
                    grobx = (GroupBox)ctr;
                    foreach (Control controlSS in grobx.Controls)
                    {
                        if (controlSS is PictureBox)
                        {
                            pctbx = (PictureBox)controlSS;
                            if (pctbx.Name == "alignSelfView")
                            {
                                int header = grobx.Controls.OfType<ComboBox>().FirstOrDefault(y => y.Name == "alignSelfItems").SelectedIndex;
                                switch (header)
                                {
                                    case 0:
                                        pctbx.BackgroundImage = global::Loxie.Properties.Resources.flex_start1;
                                        break;
                                    case 1:
                                        pctbx.BackgroundImage = global::Loxie.Properties.Resources.flex_end1;
                                        break;
                                    case 2:
                                        pctbx.BackgroundImage = global::Loxie.Properties.Resources.center;
                                        break;
                                    case 3:
                                        pctbx.BackgroundImage = global::Loxie.Properties.Resources.baseline;
                                        break;
                                    case 4:
                                        pctbx.BackgroundImage = global::Loxie.Properties.Resources.stretch;
                                        break;
                                    default:
                                        pctbx.BackgroundImage = global::Loxie.Properties.Resources.flex_start;
                                        break;
                                }
                            }
                        }
                    }
                }
            }
        }
        private void alignItemsItems_SelectedIndexChanged(object sender,EventArgs e)
        {
            var ctrl = (Control)sender;
            var frm = ctrl.FindForm();
            PictureBox pctbx = null;
            GroupBox grobx = null;
            foreach (var ctr in frm.Controls)
            {

                if (ctr is GroupBox)
                {
                    grobx = (GroupBox)ctr;
                    foreach (Control controlSS in grobx.Controls)
                    {
                        if (controlSS is PictureBox)
                        {
                            pctbx = (PictureBox)controlSS;
                            if (pctbx.Name == "alignItemsView")
                            {
                                int header = grobx.Controls.OfType<ComboBox>().FirstOrDefault(y => y.Name == "alignItemsItems").SelectedIndex;
                                switch (header)
                                {
                                    case 0:
                                        pctbx.BackgroundImage = global::Loxie.Properties.Resources.flex_start1;
                                        break;
                                    case 1:
                                        pctbx.BackgroundImage = global::Loxie.Properties.Resources.flex_end1;
                                        break;
                                    case 2:
                                        pctbx.BackgroundImage = global::Loxie.Properties.Resources.center;
                                        break;
                                    case 3:
                                        pctbx.BackgroundImage = global::Loxie.Properties.Resources.baseline;
                                        break;
                                    case 4:
                                        pctbx.BackgroundImage = global::Loxie.Properties.Resources.stretch;
                                        break;
                                    default:
                                        pctbx.BackgroundImage = global::Loxie.Properties.Resources.flex_start;
                                        break;
                                }
                            }
                        }
                    }
                }
            }
        }
        private void alignContentItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            var ctrl = (Control)sender;
            var frm = ctrl.FindForm();
            PictureBox pctbx = null;
            GroupBox grobx = null;
            foreach (var ctr in frm.Controls)
            {

                if (ctr is GroupBox)
                {
                    grobx = (GroupBox)ctr;
                    foreach (Control controlSS in grobx.Controls)
                    {
                        if (controlSS is PictureBox)
                        {
                            pctbx = (PictureBox)controlSS;
                            if (pctbx.Name == "alignContentView")
                            {
                                int header = grobx.Controls.OfType<ComboBox>().FirstOrDefault(y => y.Name == "alignContentItems").SelectedIndex;
                                switch (header)
                                {
                                    case 0:
                                        pctbx.BackgroundImage = global::Loxie.Properties.Resources.flex_start1;
                                        break;
                                    case 1:
                                        pctbx.BackgroundImage = global::Loxie.Properties.Resources.flex_end1;
                                        break;
                                    case 2:
                                        pctbx.BackgroundImage = global::Loxie.Properties.Resources.center;
                                        break;
                                    case 3:
                                        pctbx.BackgroundImage = global::Loxie.Properties.Resources.space_between;
                                        break;
                                    case 4:
                                        pctbx.BackgroundImage = global::Loxie.Properties.Resources.space_around;
                                        break;
                                    case 5:
                                        pctbx.BackgroundImage = global::Loxie.Properties.Resources.stretch;
                                        break;
                                    default:
                                        pctbx.BackgroundImage = global::Loxie.Properties.Resources.flex_start;
                                        break;
                                }
                            }
                        }
                    }
                }
            }
        } 
        private void meterOK_Click(object sender, EventArgs e)
        {
            textArea.SelectedText = "<meter";
            var ctrl = (Control)sender;
            var frm = ctrl.FindForm();
            NumericUpDown meterNUD = null;
            foreach (var ctr in frm.Controls)
            {
                if (ctr is NumericUpDown)
                {
                    meterNUD = (NumericUpDown)ctr;
                    if (meterNUD.Name == "value" && meterNUD.Value != 0)
                    {
                        textArea.SelectedText = string.Format(" value=\"{0}\" ", meterNUD.Value);
                    }
                    if (meterNUD.Name == "min" && meterNUD.Value != 0)
                    {
                        textArea.SelectedText = string.Format(" min=\"{0}\" ", meterNUD.Value);
                    }
                    if (meterNUD.Name == "max" && meterNUD.Value != 0)
                    {
                        textArea.SelectedText = string.Format(" max=\"{0}\" ", meterNUD.Value);
                    }
                    if (meterNUD.Name == "low" && meterNUD.Value != 0)
                    {
                        textArea.SelectedText = string.Format(" low=\"{0}\" ", meterNUD.Value);
                    }
                    if (meterNUD.Name == "high" && meterNUD.Value != 0)
                    {
                        textArea.SelectedText = string.Format(" high=\"{0}\" ", meterNUD.Value);
                    }
                    if (meterNUD.Name == "optimal" && meterNUD.Value != 0)
                    {
                        textArea.SelectedText = string.Format(" optimum=\"{0}\" ", meterNUD.Value);
                    }
                }
            }
            textArea.SelectedText = ">\n\n</meter>\n";
            frm.Close();
        }
        private void meterCancel_Click(object sender, EventArgs e)
        {
            var ctrl = (Control)sender;
            var frm = ctrl.FindForm();
            frm.Close();
        }
        private void timeOK_Click(object sender, EventArgs e)
        {
            textArea.SelectedText = "<time ";
            var ctrl = (Control)sender;
            var frm = ctrl.FindForm();
            DateTimePicker timeDTP = null;
            TextBox timeTXT = null;
            foreach (var ctr in frm.Controls)
            {
                if (ctr is DateTimePicker)
                {
                    timeDTP = (DateTimePicker)ctr;
                    if (timeDTP.Name == "date" && timeDTP.Value != null)
                    {
                        textArea.SelectedText = string.Format(" datetime=\"{0}\">{0} ", timeDTP.Value.ToString("yyyy-M-d"));
                    }
                }
                if (ctr is TextBox)
                {
                    timeTXT = (TextBox)ctr;
                    if (timeTXT.Name == "time" && timeTXT.ReadOnly == false)
                    {
                        textArea.SelectedText = string.Format("{0}", timeTXT.Text);
                    }

                }
            }
            textArea.SelectedText = "</time>\n";
            frm.Close();
        }
        private void timeCheck_CheckedChanged(object sender, EventArgs e)
        {
            var ctrl = (Control)sender;
            var frm = ctrl.FindForm();
            TextBox timeTXT = null;
            foreach (var ctr in frm.Controls)
            {
                if (ctr is TextBox)
                {
                    timeTXT = (TextBox)ctr;
                    if (frm.Controls.OfType<CheckBox>().FirstOrDefault(y => y.Name == "timeCheck").Checked == false)
                    {
                        if (timeTXT.Name == "time")
                        {
                            timeTXT.ReadOnly = true;
                        }
                    }
                    else
                        if (frm.Controls.OfType<CheckBox>().FirstOrDefault(y => y.Name == "timeCheck").Checked == true)
                    {
                        if (timeTXT.Name == "time")
                        {
                            timeTXT.ReadOnly = false;
                        }
                    }
                }
            }
        }
        private void timeCancel_Click(object sender, EventArgs e)
        {
            var ctrl = (Control)sender;
            var frm = ctrl.FindForm();
            frm.Close();
        }
        private void dialogBtn_Click(object sender, EventArgs e)
        {
            textArea.SelectedText = string.Format("<dialog>\n{0}\n</dialog>\n", textArea.SelectedText);
        }
        private void figureOK_Click(object sender, EventArgs e)
        {
            string selected = textArea.SelectedText;
            textArea.SelectedText = string.Format("<figure>\n{0}\n", selected);
            var ctrl = (Control)sender;
            var frm = ctrl.FindForm();
            TextBox figureTxt = null;
            foreach (var ctr in frm.Controls)
            {
                if (ctr is TextBox)
                {

                    figureTxt = (TextBox)ctr;
                    if (figureTxt.Name == "figureCaption" && figureTxt.Text != String.Empty)
                    {
                        textArea.SelectedText = string.Format("<figcaption>{0}</figcaption>\n", figureTxt.Text);
                    }
                }
            }
            textArea.SelectedText = "</figure>\n";
            frm.Close();
        }
        private void figureCancel_Click(object sender, EventArgs e)
        {
            var ctrl = (Control)sender;
            var frm = ctrl.FindForm();
            frm.Close();
        }
        private void progressOK_Click(object sender, EventArgs e)
        {
            string selected = textArea.SelectedText;
            textArea.SelectedText = "<progress";
            var ctrl = (Control)sender;
            var frm = ctrl.FindForm();
            NumericUpDown progressNUD = null;
            foreach (var ctr in frm.Controls)
            {
                if (ctr is NumericUpDown)
                {

                    progressNUD = (NumericUpDown)ctr;
                    if (progressNUD.Name == "progressValue" && progressNUD.Value != 0)
                    {
                        textArea.SelectedText = string.Format(" value=\"{0}\" ", progressNUD.Value);
                    }
                    if (progressNUD.Name == "maxValue" && progressNUD.Value != 0)
                    {
                        textArea.SelectedText = string.Format(" max=\"{0}\" ", progressNUD.Value);
                    }
                }
            }
            textArea.SelectedText = string.Format(">\n{0}\n</progress>\n", selected);
            frm.Close();
        }
        private void progressCancel_Click(object sender, EventArgs e)
        {
            var ctrl = (Control)sender;
            var frm = ctrl.FindForm();
            frm.Close();
        }
        private void iframeOK_Click(object sender, EventArgs e)
        {
            textArea.SelectedText = "<iframe";
            var ctrl = (Control)sender;
            var frm = ctrl.FindForm();
            TextBox iframeTextbox = null;
            ComboBox iframeCombobox = null;
            CheckBox iframeCheckbox = null;
            foreach (var ctr in frm.Controls)
            {
                if (ctr is TextBox)
                {

                    iframeTextbox = (TextBox)ctr;
                    if (iframeTextbox.Name == "iframeHeightVal" && iframeTextbox.Text != String.Empty)
                    {
                        textArea.SelectedText = string.Format(" name=\"{0}\" ", iframeTextbox.Text);
                    }
                    if (iframeTextbox.Name == "iframeFileURL" && iframeTextbox.Text != String.Empty)
                    {
                        textArea.SelectedText = string.Format(" src=\"{0}\" ", iframeTextbox.Text);
                    }
                    if (iframeTextbox.Name == "iframeHeightText" && iframeTextbox.Text != String.Empty)
                    {
                        textArea.SelectedText = string.Format(" height=\"{0}\" ", iframeTextbox.Text);
                    }
                    if (iframeTextbox.Name == "iframeWidthText" && iframeTextbox.Text != String.Empty)
                    {
                        textArea.SelectedText = string.Format(" width=\"{0}\" ", iframeTextbox.Text);
                    }
                }
                if (ctr is ComboBox)
                {
                    iframeCombobox = (ComboBox)ctr;
                    object selectedItem = iframeCombobox.SelectedItem;
                    if (iframeCombobox.Name == "iframeSandbox" && iframeCombobox.SelectedItem != null)
                    {
                        textArea.SelectedText = string.Format(" sandbox=\"{0}\" ", selectedItem);
                    }
                }
                if (ctr is CheckBox)
                {
                    iframeCheckbox = (CheckBox)ctr;
                    if (iframeCheckbox.Name == "iframeSandboxChk" && iframeCheckbox.Checked)
                    {
                        textArea.SelectedText = " sandbox ";
                    }
                }
            }
            textArea.SelectedText = "></iframe>\n";
            frm.Close();
        }
        private void iframeObjPrototype_Paint(object sender, PaintEventArgs e)
        {
            int val3 = 0;
            int val4 = 0;
            var ctrl = (Control)sender;
            var frm = ctrl.FindForm();
            TrackBar trackbarX = null;
            foreach (var ctr in frm.Controls)
            {
                if (ctr is TrackBar)
                {

                    trackbarX = (TrackBar)ctr;
                    if (trackbarX.Name == "iframeHeightVal")
                    {
                        val3 = trackbarX.Value;
                    }
                    else
                        if (trackbarX.Name == "iframeWidthVal")
                    {
                        val4 = trackbarX.Value;
                    }

                    //  flowLayoutPanel1.Invalidate();
                }

            }

            Pen blackPen = new Pen(Color.Black, 3);
            Rectangle rect = new Rectangle(50, 8, val4 / 10, val3 / 10);
            e.Graphics.DrawRectangle(blackPen, rect);
        }
        private void iframeWidthVal_Scroll(object sender, EventArgs e)
        {
            var ctrl = (Control)sender;
            var frm = ctrl.FindForm();
            TextBox iText = null;
            FlowLayoutPanel iPanel = null;
            TrackBar iTrack = null;
            string trck = null;
            foreach (var ctr in frm.Controls)
            {
                if (ctr is TrackBar)
                {
                    iTrack = (TrackBar)ctr;
                    if (iTrack.Name == "iframeWidthVal")
                    {
                        trck = iTrack.Value.ToString();
                    }
                }
                if (ctr is TextBox)
                {
                    iText = (TextBox)ctr;
                    if (iText.Name == "iframeWidthText")
                    {
                        iText.Text = trck;
                    }

                }
                if (ctr is FlowLayoutPanel)
                {
                    iPanel = (FlowLayoutPanel)ctr;
                    if (iPanel.Name == "iframeObjPrototype")
                    {
                        iPanel.Invalidate();
                    }
                }
            }
        }
        private void iframeHeightVal_Scroll(object sender, EventArgs e)
        {
            var ctrl = (Control)sender;
            var frm = ctrl.FindForm();
            TextBox iText = null;
            FlowLayoutPanel iPanel = null;
            TrackBar iTrack = null;
            string trck = null;
            foreach (var ctr in frm.Controls)
            {
                if (ctr is TrackBar)
                {
                    iTrack = (TrackBar)ctr;
                    if (iTrack.Name == "iframeHeightVal")
                    {
                        trck = iTrack.Value.ToString();
                    }
                }
                if (ctr is TextBox)
                {
                    iText = (TextBox)ctr;
                    if (iText.Name == "iframeHeightText")
                    {
                        iText.Text = trck;
                    }

                }
                if (ctr is FlowLayoutPanel)
                {
                    iPanel = (FlowLayoutPanel)ctr;
                    if (iPanel.Name == "iframeObjPrototype")
                    {
                        iPanel.Invalidate();
                    }
                }
            }
        }
        private void iframeSandboxChk_CheckedChanged(object sender, EventArgs e)
        {

            var ctrl = (Control)sender;
            var frm = ctrl.FindForm();
            ComboBox cmbbx = null;
            foreach (var ctr in frm.Controls)
            {
                if (ctr is ComboBox)
                {
                    cmbbx = (ComboBox)ctr;
                    if (cmbbx.Name == "iframeSandbox")
                    {
                        cmbbx.Enabled = false;
                    }
                    if (frm.Controls.OfType<CheckBox>().FirstOrDefault(y => y.Name == "iframeSandboxChk").Checked == false)
                    {
                        cmbbx.Enabled = true;
                    }
                }
            }
        }
        private void iframeFileSelectBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog url_open = new OpenFileDialog();
            url_open.Filter = ("Web files | *.css;*.php;*.html;*.asp;*.htm");
            url_open.Title = "Select file";
            url_open.ShowDialog();
            string urlName = url_open.FileName;
            var ctrl = (Control)sender;
            var frm = ctrl.FindForm();
            TextBox iframeURL = null;
            foreach (var ctr in frm.Controls)
            {
                if (ctr is TextBox)
                {
                    iframeURL = (TextBox)ctr;
                    if (iframeURL.Name == "iframeFileURL")
                    {
                        iframeURL.Text = urlName;
                    }

                }
            }
        }
        private void iframeCancel_Click(object sender, EventArgs e)
        {
            var ctrl = (Control)sender;
            var frm = ctrl.FindForm();
            frm.Close();
        }
        private void selectOK_Click(object sender, EventArgs e)
        {
            string selectedtext = textArea.SelectedText;
            textArea.SelectedText = "<select";
            var ctrl = (Control)sender;
            var frm = ctrl.FindForm();
            TextBox selectTxt = null;
            CheckBox selectChk = null;
            NumericUpDown selectNud = null;

            foreach (var ctr in frm.Controls)
            {
                if (ctr is TextBox)
                {
                    selectTxt = (TextBox)ctr;
                    if (selectTxt.Name == "selectFormID" && selectTxt.Text != String.Empty)
                    {
                        textArea.SelectedText = string.Format(" form=\"{0}\" ", selectTxt.Text);
                    }
                    else
                        if (selectTxt.Name == "selectName" && selectTxt.Text != String.Empty)
                    {
                        textArea.SelectedText = string.Format(" name=\"{0}\" ", selectTxt.Text);
                    }
                }
                if (ctr is CheckBox)
                {
                    selectChk = (CheckBox)ctr;
                    if (selectChk.Name == "selectAutofocusChk" && selectChk.Checked)
                    {
                        textArea.SelectedText = " autofocus ";
                    }
                    else
                        if (selectChk.Name == "selectDisabledChk" && selectChk.Checked)
                    {
                        textArea.SelectedText = " disabled ";
                    }
                    else
                        if (selectChk.Name == "selectMultipleChk" && selectChk.Checked)
                    {
                        textArea.SelectedText = " multiple ";
                    }
                    else
                        if (selectChk.Name == "selectRequiredChk" && selectChk.Checked)
                    {
                        textArea.SelectedText = " required ";
                    }
                }
                if (ctr is NumericUpDown)
                {
                    selectNud = (NumericUpDown)ctr;
                    if (selectNud.Name == "selectSize" && selectNud.Value != 0)
                    {
                        textArea.SelectedText = string.Format(" size=\"{0}\" ", selectNud.Value);
                    }
                }
            }
            frm.Close();
            textArea.SelectedText = string.Format(">{0}</select>\n", selectedtext);
        }
        private void selectCancel_Click(object sender, EventArgs e)
        {
            var ctrl = (Control)sender;
            var frm = ctrl.FindForm();
            frm.Close();
        }
        private void metaCharset_TextChanged(object sender, EventArgs e)
        {
            var ctrl = (Control)sender;
            var frm = ctrl.FindForm();

            TextBox metaTxt = null;
            foreach (var ctr in frm.Controls)
            {
                if (ctr is TextBox)
                {
                    metaTxt = (TextBox)ctr;
                    if (metaTxt.Name == "metaName")
                    {
                        metaTxt.Enabled = false;
                    }
                    if (metaTxt.Name == "metaContent")
                    {
                        metaTxt.Enabled = false;
                    }
                    if (metaTxt.Name == "metaHTTPEquiv")
                    {
                        metaTxt.Enabled = false;
                    }
                    if (frm.Controls.OfType<TextBox>().FirstOrDefault(y => y.Name == "metaCharset").Text == String.Empty)
                    {
                        frm.Controls.OfType<TextBox>().FirstOrDefault(y => y.Name == "metaName").Enabled = true;
                        frm.Controls.OfType<TextBox>().FirstOrDefault(y => y.Name == "metaContent").Enabled = true;
                        frm.Controls.OfType<TextBox>().FirstOrDefault(y => y.Name == "metaHTTPEquiv").Enabled = true;
                    }
                }
            }
        }
        private void metaCancel_Click(object sender, EventArgs e)
        {
            var ctrl = (Control)sender;
            var frm = ctrl.FindForm();
            frm.Close();
        }
        private void metaOK_Click(object sender, EventArgs e)
        {
            var ctrl = (Control)sender;
            var frm = ctrl.FindForm();
            string content = null;
            TextBox metaTxt = null;
            foreach (var ctr in frm.Controls)
            {
                if (ctr is TextBox)
                {
                    metaTxt = (TextBox)ctr;
                    if (metaTxt.Name == "metaCharset" && metaTxt.Text != String.Empty)
                    {
                        textArea.SelectedText = string.Format("<meta charset=\"{0}\">\n", metaTxt.Text);
                    }
                    if (metaTxt.Name == "metaContent" && metaTxt.Text != String.Empty)
                    {
                        content = metaTxt.Text;
                    }
                    if (metaTxt.Name == "metaName" && metaTxt.Text != String.Empty)
                    {
                        textArea.SelectedText = string.Format("<meta name=\"{0}\" content=\"{1}\">\n", metaTxt.Text, content);
                    }
                    if (metaTxt.Name == "metaHTTPEquiv" && metaTxt.Text != String.Empty)
                    {
                        textArea.SelectedText = string.Format("<meta http-equiv=\"{0}\" content=\"{1}\">\n", metaTxt.Text, content);
                    }
                }
            }
            frm.Close();
        }
        private void metaName_TextChanged(object sender, EventArgs e)
        {
            var ctrl = (Control)sender;
            var frm = ctrl.FindForm();

            TextBox metaTxt = null;
            foreach (var ctr in frm.Controls)
            {
                if (ctr is TextBox)
                {
                    metaTxt = (TextBox)ctr;
                    if (metaTxt.Name == "metaHTTPEquiv")
                    {
                        metaTxt.Enabled = false;
                    }
                    if (metaTxt.Name == "metaCharset")
                    {
                        metaTxt.Enabled = false;
                    }
                    if (frm.Controls.OfType<TextBox>().FirstOrDefault(y => y.Name == "metaName").Text == String.Empty)
                    {
                        frm.Controls.OfType<TextBox>().FirstOrDefault(y => y.Name == "metaHTTPEquiv").Enabled = true;
                        frm.Controls.OfType<TextBox>().FirstOrDefault(y => y.Name == "metaCharset").Enabled = true;
                    }
                }
            }
        }
        private void metaHTTPEquiv_TextChanged(object sender, EventArgs e)
        {
            var ctrl = (Control)sender;
            var frm = ctrl.FindForm();

            TextBox metaTxt = null;
            foreach (var ctr in frm.Controls)
            {
                if (ctr is TextBox)
                {
                    metaTxt = (TextBox)ctr;
                    if (metaTxt.Name == "metaName")
                    {
                        metaTxt.Enabled = false;
                    }
                    if (metaTxt.Name == "metaCharset")
                    {
                        metaTxt.Enabled = false;
                    }
                    if (frm.Controls.OfType<TextBox>().FirstOrDefault(x => x.Name == "metaHTTPEquiv").Text == String.Empty)
                    {
                        frm.Controls.OfType<TextBox>().FirstOrDefault(x => x.Name == "metaName").Enabled = true;
                        frm.Controls.OfType<TextBox>().FirstOrDefault(y => y.Name == "metaCharset").Enabled = true;
                    }
                }
            }
        }
        private void labelBtn_Click(object sender, EventArgs e)
        {
            textArea.SelectedText = string.Format("<label>{0}</label>\n", textArea.SelectedText);
        }
        private void navBtn_Click(object sender, EventArgs e)
        {
            textArea.SelectedText = string.Format("<nav>{0}</nav>\n", textArea.SelectedText);
        }
        private void fieldsetOK_Click(object sender, EventArgs e)
        {
            string allText = textArea.SelectedText;
            textArea.SelectedText = "<fieldset>\n";
            var ctrl = (Control)sender;
            var frm = ctrl.FindForm();
            TextBox fieldsetTxt = null;

            foreach (var ctr in frm.Controls)
            {
                if (ctr is TextBox)
                {
                    fieldsetTxt = (TextBox)ctr;
                    if (fieldsetTxt.Name == "legend" && fieldsetTxt.Text != String.Empty)
                    {
                        textArea.SelectedText = string.Format("<legend>{0}</legend>\n", fieldsetTxt.Text);
                    }

                }
            }
            textArea.SelectedText = string.Format("{0}\n</fieldset>\n", allText);
            frm.Close();
        }
        private void fieldsetCancel_Click(object sender, EventArgs e)
        {
            var ctrl = (Control)sender;
            var frm = ctrl.FindForm();
            frm.Close();
        }
        int index = 1;
        private void datalistOK_Click(object sender, EventArgs e)
        {
            textArea.SelectionLength = 0;
            textArea.SelectedText = "<datalist";
            var ctrl = (Control)sender;
            var frm = ctrl.FindForm();
            TextBox dataTxt = null;

            foreach (var ctr in frm.Controls)
            {
                if (ctr is TextBox)
                {
                    dataTxt = (TextBox)ctr;
                    if (dataTxt.Name == "inputListID")
                    {
                        textArea.SelectedText = string.Format(" id=\"{0}\">\n", dataTxt.Text);
                    }
                    else
                    if (dataTxt.Name == "optionName" && dataTxt.Text != String.Empty)
                    {
                        textArea.SelectedText = string.Format("<option value=\"{0}\">{0}</option>\n", dataTxt.Text);
                    }
                    else
                    if (dataTxt.Name == "txt1" && dataTxt.Text != String.Empty)
                    {
                        textArea.SelectedText = string.Format("<option value=\"{0}\">{0}</option>\n", dataTxt.Text);
                    }
                    else
                    if (dataTxt.Name == "txt2" && dataTxt.Text != String.Empty)
                    {
                        textArea.SelectedText = string.Format("<option value=\"{0}\">{0}</option>\n", dataTxt.Text);
                    }
                    else
                    if (dataTxt.Name == "txt3" && dataTxt.Text != String.Empty)
                    {
                        textArea.SelectedText = string.Format("<option value=\"{0}\">{0}</option>\n", dataTxt.Text);
                    }
                    else
                    if (dataTxt.Name == "txt4" && dataTxt.Text != String.Empty)
                    {
                        textArea.SelectedText = string.Format("<option value=\"{0}\">{0}</option>\n", dataTxt.Text);
                    }
                    else
                    if (dataTxt.Name == "txt5" && dataTxt.Text != String.Empty)
                    {
                        textArea.SelectedText = string.Format("<option value=\"{0}\">{0}</option>\n", dataTxt.Text);
                    }
                    else
                    if (dataTxt.Name == "txt6" && dataTxt.Text != String.Empty)
                    {
                        textArea.SelectedText = string.Format("<option value=\"{0}\">{0}</option>\n", dataTxt.Text);
                    }
                    else
                    if (dataTxt.Name == "txt7" && dataTxt.Text != String.Empty)
                    {
                        textArea.SelectedText = string.Format("<option value=\"{0}\">{0}</option>\n", dataTxt.Text);
                    }
                    else
                    if (dataTxt.Name == "txt8" && dataTxt.Text != String.Empty)
                    {
                        textArea.SelectedText = string.Format("<option value=\"{0}\">{0}</option>\n", dataTxt.Text);
                    }
                    else
                    if (dataTxt.Name == "txt9" && dataTxt.Text != String.Empty)
                    {
                        textArea.SelectedText = string.Format("<option value=\"{0}\">{0}</option>\n", dataTxt.Text);
                    }
                }

            }
            frm.Close();
            textArea.SelectedText = "</datalist>\n";
        }
        private void addItem_Click(object sender, EventArgs e)
        {
            var ctrl = (Control)sender;
            var frm = ctrl.FindForm();
            TextBox addTxt = null;
            Label addLbl = null;
            Button addBtn = null;
            Label l = new Label();
            TextBox t = new TextBox();
            t.Name = "txt" + index;
            foreach (var ctr in frm.Controls)
            {
                if (ctr is Button)
                {
                    addBtn = (Button)ctr;
                    if (addBtn.Name == "removeItem")
                    {
                        addBtn.Enabled = true;
                    }
                    else
                        if (addBtn.Name == "addItem")
                    {
                        if (index > 8)
                        {
                            addBtn.Enabled = false;
                        }
                    }
                    else
                        if (addBtn.Name == "datalistOK")
                        {
                            addBtn.Location = new Point(addBtn.Location.X, addBtn.Location.Y + 30);
                        }
                    else
                        if (addBtn.Name == "datalistCancel")
                    {
                        addBtn.Location = new Point(addBtn.Location.X, addBtn.Location.Y + 30);
                    }
                }
                if (ctr is Label)
                {
                    addLbl = (Label)ctr;
                    if (addLbl.Name == "optionNameLbl")
                    {
                        l.Text = addLbl.Text + " " + index;
                        l.Width = addLbl.Width + 15;
                        l.Location = new Point(addLbl.Location.X, addLbl.Location.Y + 30 * index);
                    }
                }
                if (ctr is TextBox)
                {
                    addTxt = (TextBox)ctr;
                    if (addTxt.Name == "optionName")
                    {
                        t.Width = addTxt.Width;
                        t.Location = new Point(addTxt.Location.X, addTxt.Location.Y + 30 * index);
                    }
                }
            }
            l.Name = "lbl" + index;
            frm.Controls.Add(l);
            frm.Controls.Add(t);
            frm.Height += 30;
            index++;
        }
        private void removeItem_Click(object sender, EventArgs e)
        {
            var ctrl = (Control)sender;
            var frm = ctrl.FindForm();
            Button removeBtn = null;
            if (index > 1)
            {
                foreach (var ctr in frm.Controls)
                {
                    if (ctr is Button)
                    {
                        removeBtn = (Button)ctr;
                        if (removeBtn.Name == "addItem")
                        {
                            removeBtn.Enabled = true;
                        }
                        else
                        if (removeBtn.Name == "datalistOK")
                        {
                            removeBtn.Location = new Point(removeBtn.Location.X, removeBtn.Location.Y - 30);
                        }
                        else
                        if (removeBtn.Name == "datalistCancel")
                        {
                            removeBtn.Location = new Point(removeBtn.Location.X, removeBtn.Location.Y - 30);
                        }
                    }
                }
                index--;
                frm.Controls.RemoveByKey("txt" + index);
                frm.Controls.RemoveByKey("lbl" + index);
                frm.Height -= 30;
            }
            if (index == 1)
            {
                foreach (var ctr in frm.Controls)
                {
                    if (ctr is Button)
                    {
                        removeBtn = (Button)ctr;
                        if (removeBtn.Name == "removeItem")
                        {
                            removeBtn.Enabled = false;
                        }
                    }
                }
            }
        }
        private void datalistCancel_Click(object sender, EventArgs e)
        {
            var ctrl = (Control)sender;
            var frm = ctrl.FindForm();
            frm.Close();
        }
        private void asideBtn_Click(object sender, EventArgs e)
        {
            textArea.SelectedText = string.Format("<aside>\n{0}\n</aside>\n", textArea.SelectedText);
        }
        private void sectionBtn_Click(object sender, EventArgs e)
        {
            textArea.SelectedText = string.Format("<section>\n{0}\n</section>\n", textArea.SelectedText);
        }
        private void outputFormCancel_Click(object sender, EventArgs e)
        {
            var ctrl = (Control)sender;
            var frm = ctrl.FindForm();
            frm.Close();
        }
        private void outputFormOK_Click(object sender, EventArgs e)
        {
            textArea.SelectionLength = 0;
            textArea.SelectedText = "<output ";
            var ctrl = (Control)sender;
            var frm = ctrl.FindForm();
            TextBox outputTxt = null;
            foreach (var ctr in frm.Controls)
            {
                if (ctr is TextBox)
                {
                    outputTxt = (TextBox)ctr;
                    if (outputTxt.Name == "outputFormNameVal" && outputTxt.Text != "")
                    {
                        textArea.SelectedText = string.Format(" form=\"{0}\" ", outputTxt.Text);
                    }
                    else
                        if (outputTxt.Name == "outputNameVal" && outputTxt.Text != "")
                    {
                        textArea.SelectedText = string.Format(" name=\"{0}\" ", outputTxt.Text);
                    }
                }
            }
            textArea.SelectedText = "></output>\n";
            frm.Close();
        }
        private void inputCancel_Click(object sender, EventArgs e)
        {
            var ctrl = (Control)sender;
            var frm = ctrl.FindForm();
            frm.Close();
        }
        private void inputOK_Click(object sender, EventArgs e)
        {
            textArea.SelectionLength = 0;
            textArea.SelectedText = "<input";
            var ctrl = (Control)sender;
            var frm = ctrl.FindForm();
            TextBox inputTxt = null;
            GroupBox inputGrp = null;
            ComboBox inputCmb = null;
            NumericUpDown inputNud = null;
            CheckBox inputChck = null;

            foreach (var ctr in frm.Controls)
            {
                if (ctr is TextBox)
                {
                    inputTxt = (TextBox)ctr;
                    if (inputTxt.Name == "inputNameVal" && inputTxt.Text != "")
                    {
                        textArea.SelectedText = string.Format(" name=\"{0}\" ", inputTxt.Text);
                    }
                    else
                        if (inputTxt.Name == "fileTypeVal" && inputTxt.Text != "")
                    {
                        textArea.SelectedText = string.Format(" accept=\"{0}\" ", inputTxt.Text);
                    }
                    else
                        if (inputTxt.Name == "placeholderVal" && inputTxt.Text != "")
                    {
                        textArea.SelectedText = string.Format(" placeholder=\"{0}\" ", inputTxt.Text);
                    }
                    else
                        if (inputTxt.Name == "inputVal" && inputTxt.Text != "")
                    {
                        textArea.SelectedText = string.Format(" value=\"{0}\" ", inputTxt.Text);
                    }
                    else
                        if (inputTxt.Name == "inputListName" && inputTxt.Text != "")
                    {
                        textArea.SelectedText = string.Format(" list=\"{0}\" ", inputTxt.Text);
                    }
                    else
                        if (inputTxt.Name == "inputTemplate" && inputTxt.Text != "")
                    {
                        textArea.SelectedText = string.Format(" pattern=\"{0}\" ", inputTxt.Text);
                    }
                }
                if (ctr is ComboBox)
                {
                    inputCmb = (ComboBox)ctr;
                    object selectedItem = inputCmb.SelectedItem;
                    if (inputCmb.Name == "inputType" && inputCmb.SelectedItem != null)
                    {
                        textArea.SelectedText = string.Format(" type=\"{0}\" ", selectedItem);
                    }
                    else
                        if (inputCmb.Name == "inputQueryType" && inputCmb.SelectedItem != null)
                    {
                        textArea.SelectedText = string.Format(" formmethod=\"{0}\" ", selectedItem);
                    }
                }
                if (ctr is NumericUpDown)
                {
                    inputNud = (NumericUpDown)ctr;
                    if (inputNud.Name == "inputSizeVal" && inputNud.Value > 0)
                    {
                        textArea.SelectedText = string.Format(" size=\"{0}\" ", inputNud.Value);
                    }
                    else
                        if (inputNud.Name == "MaxSymbolsVal" && inputNud.Value > 0)
                    {
                        textArea.SelectedText = string.Format(" maxlength=\"{0}\" ", inputNud.Value);
                    }
                }
                if (ctr is CheckBox)
                {
                    inputChck = (CheckBox)ctr;
                    if (inputChck.Name == "inputChecked" && inputChck.Checked)
                    {
                        textArea.SelectedText = " checked ";
                    }
                    else
                        if (inputChck.Name == "inputRequired" && inputChck.Checked)
                    {
                        textArea.SelectedText = " required ";
                    }
                    else
                        if (inputChck.Name == "inputMultiple" && inputChck.Checked)
                    {
                        textArea.SelectedText = " multiple ";
                    }
                    else
                        if (inputChck.Name == "inputAutofocus" && inputChck.Checked)
                    {
                        textArea.SelectedText = " autofocus ";
                    }
                    else
                        if (inputChck.Name == "inputFormNoValidate" && inputChck.Checked)
                    {
                        textArea.SelectedText = " formnovalidate ";
                    }
                    else
                        if (inputChck.Name == "inputFormDisabled" && inputChck.Checked)
                    {
                        textArea.SelectedText = " disabled ";
                    }
                    else
                        if (inputChck.Name == "inputReadOnly" && inputChck.Checked)
                    {
                        textArea.SelectedText = " readonly ";
                    }
                    else
                        if (inputChck.Name == "inputAutoComplete" && inputChck.Checked)
                    {
                        textArea.SelectedText = " autocomplete ";
                    }
                }
                if (ctr is GroupBox)
                {
                    inputGrp = (GroupBox)ctr;
                    foreach (Control controlSS in inputGrp.Controls)
                    {
                        if (controlSS is TextBox)
                        {
                            inputTxt = (TextBox)controlSS;
                            if (inputTxt.Name == "inputImgURL" && inputTxt.Text != "")
                            {
                                textArea.SelectedText = string.Format(" src=\"{0}\" ", inputTxt.Text);
                            }
                            else
                                if (inputTxt.Name == "inputImgAltVal" && inputTxt.Text != "")
                            {
                                textArea.SelectedText = string.Format(" alt=\"{0}\" ", inputTxt.Text);
                            }
                            else
                                if (inputTxt.Name == "inputFormIDVal" && inputTxt.Text != "")
                            {
                                textArea.SelectedText = string.Format(" form=\"{0}\" ", inputTxt.Text);
                            }
                            else
                                if (inputTxt.Name == "inputFormFileURL" && inputTxt.Text != "")
                            {
                                textArea.SelectedText = string.Format(" formaction=\"{0}\" ", inputTxt.Text);
                            }
                        }
                        if (controlSS is ComboBox)
                        {
                            inputCmb = (ComboBox)controlSS;
                            object selectedComboItem = inputCmb.SelectedItem;
                            if (inputCmb.Name == "inputFormTypes" && inputCmb.SelectedItem != null)
                            {
                                textArea.SelectedText = string.Format(" formenctype=\"{0}\" ", selectedComboItem);
                            }
                            else
                                if (inputCmb.Name == "inputFormTargetVal" && inputCmb.SelectedItem != null)
                            {
                                textArea.SelectedText = string.Format(" formtarget=\"{0}\" ", selectedComboItem);
                            }
                            else
                                if (inputCmb.Name == "inputQueryType" && inputCmb.SelectedItem != null)
                            {
                                textArea.SelectedText = string.Format(" formmethod=\"{0}\" ", selectedComboItem);
                            }

                        }
                    }
                }

            }
            frm.Close();
            textArea.SelectedText = ">\n";
        }
        private void inputFormFileSelect_Click(object sender, EventArgs e)
        {
            //inputFormFileURL
            OpenFileDialog url_open = new OpenFileDialog();
            url_open.Filter = ("Web files | *.css;*.php;*.html;*.asp;*.htm");
            url_open.Title = "Select file";
            url_open.ShowDialog();
            string urlName = url_open.FileName;
            var ctrl = (Control)sender;
            var frm = ctrl.FindForm();
            TextBox urlselector1 = null;
            foreach (var ctr in frm.Controls)
            {
                foreach (Control grpbox in frm.Controls)
                {
                    if (grpbox is GroupBox)
                    {
                        foreach (Control textx in grpbox.Controls)
                        {
                            if (textx is TextBox)
                            {
                                urlselector1 = (TextBox)textx;
                                if (urlselector1.Name == "inputFormFileURL")
                                {
                                    urlselector1.Text = urlName;
                                }
                            }
                        }
                    }
                }

            }

        }
        private void inputImgSelect_Click(object sender, EventArgs e)
        {
            if(imageOpen.ShowDialog()!= DialogResult.Cancel)
            {
                System.IO.StreamReader OpenFile = new System.IO.StreamReader(imageOpen.FileName);
                string imagepath = imageOpen.FileName;
                OpenFile.Close();
                var ctrl = (Control)sender;
                var frm = ctrl.FindForm();
                TextBox inputTxt = null;
                foreach (var ctr in frm.Controls)
                {
                    foreach (Control grpbox in frm.Controls)
                    {
                        if (grpbox is GroupBox)
                        {
                            foreach (Control textx in grpbox.Controls)
                            {
                                if (textx is TextBox)
                                {
                                    inputTxt = (TextBox)textx;
                                    if (inputTxt.Name == "inputImgURL")
                                    {
                                        inputTxt.Text = imagepath;
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        private void bdoOK_Click(object sender, EventArgs e)
        {
            string a = null;
            string c = null;
            var ctrl = (Control)sender;
            var frm = ctrl.FindForm();
            RadioButton radio = null;
            RichTextBox rtbx = null;
            foreach (var ctr in frm.Controls)
            {
                if (ctr is RadioButton)
                {
                    radio = (RadioButton)ctr;
                    if (radio.Name == "rtl" && radio.Checked)
                    {
                        a = "<bdo dir=\"rtl\">";
                    }
                    else
                        if (radio.Name == "ltr" && radio.Checked)
                    {
                        a = "<bdo dir=\"ltr\">";
                    }
                }
                if (ctr is RichTextBox)
                {
                    rtbx = (RichTextBox)ctr;
                    if (rtbx.Name == "text")
                    {
                        c = string.Format("{0}", rtbx.Text);
                    }
                }
            }

            textArea.SelectedText = string.Format("{0}{1}</bdo>\n", a, c);
            frm.Close();
        }
        private void article_Click(object sender, EventArgs e)
        {
            textArea.SelectedText = string.Format("<article>{0}</article> \n", textArea.SelectedText);
        }
        private void hiddenCancel_Click(object sender, EventArgs e)
        {
            var ctrl = (Control)sender;
            var frm = ctrl.FindForm();
            frm.Close();
        }
        private void hiddenOK_Click(object sender, EventArgs e)
        {
            textArea.SelectionLength = 0;
            textArea.SelectedText = "<details>\n";
            var ctrl = (Control)sender;
            var frm = ctrl.FindForm();
            TextBox hiddentext = null;
            RichTextBox hiddenrich = null;
            foreach (var ctr in frm.Controls)
            {
                if (ctr is TextBox)
                {
                    hiddentext = (TextBox)ctr;
                    if (hiddentext.Name == "hiddenName" && hiddentext.Text != String.Empty)
                    {
                        textArea.SelectionLength = 0;
                        textArea.SelectedText = string.Format("<summary>{0}</summary>\n", hiddentext.Text);
                    }
                }
                if (ctr is RichTextBox)
                {
                    hiddenrich = (RichTextBox)ctr;
                    if (hiddenrich.Name == "hiddenTextVal" && hiddenrich.Text != String.Empty)
                    {
                        textArea.SelectionLength = 0;
                        textArea.SelectedText = string.Format("<p>{0}</p>\n", hiddenrich.Text);
                    }
                }
            }
            frm.Close();
            textArea.SelectionLength = 0;
            textArea.SelectedText = "</details>\n";
        }
        private void videoCancel_Click(object sender, EventArgs e)
        {
            var ctrl = (Control)sender;
            var frm = ctrl.FindForm();
            frm.Close();
        }
        private void videoOK_Click(object sender, EventArgs e)
        {
            textArea.SelectionLength = 0;
            textArea.SelectedText = "<video controls";
            var ctrl = (Control)sender;
            var frm = ctrl.FindForm();
            RichTextBox sometext = null;
            TextBox sometext2 = null;
            CheckBox somecheck = null;
            foreach (var ctr in frm.Controls)
            {
                if (ctr is CheckBox)
                {
                    somecheck = (CheckBox)ctr;
                    if (somecheck.Name == "autoStart" && somecheck.Checked)
                    {
                        textArea.SelectionLength = 0;
                        textArea.SelectedText = " autoplay";

                    }
                    else
                        if (somecheck.Name == "repeatCheck" && somecheck.Checked)
                    {
                        textArea.SelectionLength = 0;
                        textArea.SelectedText = " loop ";
                    }
                }
                if (ctr is TextBox)
                {
                    sometext2 = (TextBox)ctr;
                    if (sometext2.Name == "videoWidthTxtVal" && sometext2.Text != String.Empty)
                    {
                        textArea.SelectionLength = 0;
                        textArea.SelectedText = string.Format(" height=\"{0}\" ", sometext2.Text);
                    }
                    else
                        if (sometext2.Name == "videoHeightTxtVal" && sometext2.Text != String.Empty)
                    {
                        textArea.SelectionLength = 0;
                        textArea.SelectedText = string.Format(" width=\"{0}\" ", sometext2.Text);
                    }
                    else
                         if (sometext2.Name == "posterURL" && sometext2.Text != String.Empty)
                    {
                        textArea.SelectionLength = 0;
                        textArea.SelectedText = string.Format(" poster=\"{0}\" ", sometext2.Text);
                    }
                }

            }
            textArea.SelectionLength = 0;
            textArea.SelectedText = ">\n";
            foreach (var ctr in frm.Controls)
            {
                if (ctr is RichTextBox)
                {
                    sometext = (RichTextBox)ctr;
                    if (sometext.Name == "videoURL" && sometext.Text != String.Empty)
                    {
                        if (sometext.Find(".mp4") != -1)
                        {
                            textArea.SelectionLength = 0;
                            textArea.SelectedText = string.Format("<source src=\"{0}\" type='video/mp4' codecs=\"avc1.42E01E, mp4a.40.2\" '> \n", sometext.Text);
                        }
                        else
                            if (sometext.Find(".webm") != -1)
                        {
                            textArea.SelectionLength = 0;
                            textArea.SelectedText = string.Format("<source src=\"{0}\" type='video/webm'; codecs=\"vp8, vorbis\" '> \n", sometext.Text);
                        }
                        else
                            if (sometext.Find(".ogv") != -1)
                        {
                            textArea.SelectionLength = 0;
                            textArea.SelectedText = string.Format("<source src=\"{0}\" type='video/ogg'; codecs=\"theora, vorbis\" '> \n", sometext.Text);
                        }
                    }
                }
            }
            frm.Close();
            textArea.SelectionLength = 0;
            textArea.SelectedText = "</video>\n";
        }
        private void videoSelect_Click(object sender, EventArgs e)
        {
            OpenFileDialog videoOpen = new OpenFileDialog();
            videoOpen.Filter = ("Videofiles (*.mp4,*.webm,*.ogv)|*.mp4;*.webm;*.ogv");
            videoOpen.Title = "Select videofile";
            if(videoOpen.ShowDialog() != DialogResult.Cancel)
            {
                StreamReader OpenFile = new StreamReader(videoOpen.FileName);
                OpenFile.Close();
                string videopath = videoOpen.FileName;
                var ctrl = (Control)sender;
                var frm = ctrl.FindForm();
                RichTextBox txt = null;
                foreach (var ctr in frm.Controls)
                {
                    if (ctr is RichTextBox)
                    {
                        txt = (RichTextBox)ctr;
                        if (txt.Name == "videoURL")
                        {
                            txt.Text = videopath;
                        }
                    }
                }
            }
        }
        private void posterSelect_Click(object sender, EventArgs e)
        {
            imageOpen.ShowDialog();
            string fullpath = imageOpen.FileName;

            var ctrl = (Control)sender;
            var frm = ctrl.FindForm();
            TextBox txt = null;
            foreach (var ctr in frm.Controls)
            {
                if (ctr is TextBox)
                {
                    txt = (TextBox)ctr;
                    if (txt.Name == "posterURL")
                    {
                        txt.Text = fullpath;
                    }
                }
            }

        }
        private void videoWidthVal_Scroll(object sender, EventArgs e)
        {
            string val1 = null;
            var ctrl = (Control)sender;
            var frm = ctrl.FindForm();
            TrackBar widthTrack = null;
            FlowLayoutPanel videoLayout = null;
            TextBox widthtrackval = null;
            foreach (var ctr in frm.Controls)
            {
                if (ctr is TrackBar)
                {

                    widthTrack = (TrackBar)ctr;
                    if (widthTrack.Name == "videoWidthVal")
                    {
                        val1 = widthTrack.Value.ToString();
                    }

                    //  flowLayoutPanel1.Invalidate();
                }
                if (ctr is TextBox)
                {
                    widthtrackval = (TextBox)ctr;
                    if (widthtrackval.Name == "videoWidthTxtVal")
                    {
                        widthtrackval.Text = val1;

                    }
                }
                if (ctr is FlowLayoutPanel)
                {
                    videoLayout = (FlowLayoutPanel)ctr;
                    if (videoLayout.Name == "videoPrototypeObj")
                    {
                        videoLayout.Invalidate();
                    }
                }
            }
        }
        private void videoHeightVal_Scroll(object sender, EventArgs e)
        {
            string val2 = null;
            var ctrl = (Control)sender;
            var frm = ctrl.FindForm();
            TrackBar heightTrack = null;
            FlowLayoutPanel videoLayout = null;
            TextBox heighttrackval = null;
            foreach (var ctr in frm.Controls)
            {
                if (ctr is TrackBar)
                {

                    heightTrack = (TrackBar)ctr;
                    if (heightTrack.Name == "videoHeightVal")
                    {
                        val2 = heightTrack.Value.ToString();
                    }

                    //  flowLayoutPanel1.Invalidate();
                }
                if (ctr is TextBox)
                {
                    heighttrackval = (TextBox)ctr;
                    if (heighttrackval.Name == "videoHeightTxtVal")
                    {
                        heighttrackval.Text = val2;

                    }
                }
                if (ctr is FlowLayoutPanel)
                {
                    videoLayout = (FlowLayoutPanel)ctr;
                    if (videoLayout.Name == "videoPrototypeObj")
                    {
                        videoLayout.Invalidate();
                    }
                }
            }
        }
        private void videoPrototype_Paint(object sender, PaintEventArgs e)
        {
            int val3 = 0;
            int val4 = 0;
            var ctrl = (Control)sender;
            var frm = ctrl.FindForm();
            TrackBar trackbarX = null;
            foreach (var ctr in frm.Controls)
            {
                if (ctr is TrackBar)
                {

                    trackbarX = (TrackBar)ctr;
                    if (trackbarX.Name == "videoWidthVal")
                    {
                        val3 = trackbarX.Value;
                    }
                    else
                        if (trackbarX.Name == "videoHeightVal")
                    {
                        val4 = trackbarX.Value;
                    }

                    //  flowLayoutPanel1.Invalidate();
                }

            }

            Pen blackPen = new Pen(Color.Black, 3);
            Rectangle rect = new Rectangle(55, 50, val4 / 10, val3 / 10);
            e.Graphics.DrawRectangle(blackPen, rect);
        }
        private void menuButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This feature is still in development!", "Warning!");
        }
        private void markButton_Click(object sender, EventArgs e)
        {
            textArea.SelectedText = string.Format("<mark>{0}</mark>\n", textArea.SelectedText);
        }
        private void OKBaseBtn_Click(object sender, EventArgs e)
        {
            var ctrl = (Control)sender;
            var frm = ctrl.FindForm();
            TextBox basetextbox = null;

            foreach (var ctr in frm.Controls)
            {
                if (ctr is TextBox)
                {
                    basetextbox = (TextBox)ctr;
                    if (basetextbox.Name == "baseVal")
                    {
                        if (textArea.Find("<head>") != -1)
                        {
                            StringBuilder sb1 = new StringBuilder("<head>");
                            sb1.Insert(6, string.Format("\n<base target=\"{0}\">", basetextbox.Text));
                            textArea.SelectedText = sb1.ToString();
                        }
                    }
                }
            }

            frm.Close();
        }
        private void CancelBaseBtn_Click(object sender, EventArgs e)
        {
            var ctrl = (Control)sender;
            var frm = ctrl.FindForm();
            frm.Close();
        }
        private void btnFrmCancel_Click(object sender, EventArgs e)
        {
            var ctrl = (Control)sender;
            var frm = ctrl.FindForm();
            frm.Close();
        }
        private void btnFrmOk_Click(object sender, EventArgs e)
        {
            textArea.SelectionLength = 0;
            textArea.SelectedText = "<button ";
            var ctrl = (Control)sender;
            var frm = ctrl.FindForm();
            TextBox resultextbox = null;
            CheckBox resultcheckbox = null;
            RadioButton resultradiobutton = null;
            ComboBox resultcombobox = null;

            foreach (var ctr in frm.Controls)
            {
                if (ctr is TextBox)
                {
                    resultextbox = (TextBox)ctr;
                    if (resultextbox.Name == "btnNameVal" && resultextbox.Text != String.Empty)
                    {
                        textArea.SelectionLength = 0;
                        textArea.SelectedText = string.Format("name=\"{0}\" ", resultextbox.Text);
                    }
                    else
                        if (resultextbox.Name == "valueVal" && resultextbox.Text != String.Empty)
                    {
                        textArea.SelectionLength = 0;
                        textArea.SelectedText = string.Format("value=\"{0}\" ", resultextbox.Text);
                    }
                    else
                        if (resultextbox.Name == "formIDVal" && resultextbox.Text != String.Empty)
                    {
                        textArea.SelectionLength = 0;
                        textArea.SelectedText = string.Format("form=\"{0}\" ", resultextbox.Text);
                    }
                    else
                        if (resultextbox.Name == "formURLVal" && resultextbox.Text != String.Empty)
                    {
                        textArea.SelectionLength = 0;
                        textArea.SelectedText = string.Format("formaction=\"{0}\" ", resultextbox.Text);
                    }
                }
                if (ctr is RadioButton)
                {
                    resultradiobutton = (RadioButton)ctr;
                    if (resultradiobutton.Name == "application" && resultradiobutton.Checked)
                    {
                        textArea.SelectionLength = 0;
                        textArea.SelectedText = "formenctype=\"application/x-www-form-urlencoded\" ";
                    }
                    else
                        if (resultradiobutton.Name == "multipart" && resultradiobutton.Checked)
                    {
                        textArea.SelectionLength = 0;
                        textArea.SelectedText = "formenctype=\"multipart/form-data\" ";
                    }
                    else
                        if (resultradiobutton.Name == "text" && resultradiobutton.Checked)
                    {
                        textArea.SelectionLength = 0;
                        textArea.SelectedText = "formenctype=\"text/plain\" ";
                    }
                }
                if (ctr is CheckBox)
                {
                    resultcheckbox = (CheckBox)ctr;
                    if (resultcheckbox.Name == "formnovalidateVal" && resultcheckbox.Checked)
                    {
                        textArea.SelectionLength = 0;
                        textArea.SelectedText = "formnovalidate ";
                    }
                    else
                        if (resultcheckbox.Name == "autoFocusCheck" && resultcheckbox.Checked)
                    {
                        textArea.SelectionLength = 0;
                        textArea.SelectedText = "autofocus ";
                    }
                    else
                        if (resultcheckbox.Name == "disabledCheck" && resultcheckbox.Checked)
                    {
                        textArea.SelectionLength = 0;
                        textArea.SelectedText = "disabled ";
                    }
                }
                if (ctr is ComboBox)
                {

                    resultcombobox = (ComboBox)ctr;
                    object selectedItem = resultcombobox.SelectedItem;
                    if (resultcombobox.Name == "formmethodVal" && resultcombobox.SelectedItem != null)
                    {
                        textArea.SelectionLength = 0;
                        textArea.SelectedText = string.Format("formmethod=\"{0}\" ", selectedItem);
                    }
                    else
                        if (resultcombobox.Name == "btnTypeVal" && resultcombobox.SelectedItem != null)
                    {
                        textArea.SelectionLength = 0;
                        textArea.SelectedText = string.Format("type=\"{0}\" ", selectedItem);
                    }
                    else
                        if (resultcombobox.Name == "formtargetVal" && resultcombobox.SelectedItem != null)
                    {
                        textArea.SelectionLength = 0;
                        textArea.SelectedText = string.Format("formtarget=\"{0}\" ", selectedItem);
                    }
                }
            }
            frm.Close();
            textArea.SelectionLength = 0;
            textArea.SelectedText = ">Çık</button>";
        }
        private void selectURL_Click(object sender, EventArgs e)
        {
            OpenFileDialog url_open = new OpenFileDialog();
            url_open.Filter = ("Web files | *.css;*.php;*.html;*.asp;*.htm");
            url_open.Title = "Open style file";
            url_open.ShowDialog();
            string urlName = url_open.FileName;
            var ctrl = (Control)sender;
            var frm = ctrl.FindForm();
            TextBox urlselector = null;
            foreach (var ctr in frm.Controls)
            {
                if (ctr is TextBox)
                {
                    urlselector = (TextBox)ctr;
                    if (urlselector.Name == "formURLVal")
                    {
                        urlselector.Text = urlName;
                    }
                }
            }
        }
        private void textShadowCancel_Click(object sender, EventArgs e)
        {
            var ctrl = (Control)sender;
            var frm = ctrl.FindForm();
            frm.Close();
        }
        private void textShadowOK_Click(object sender, EventArgs e)
        {
            textArea.SelectionLength = 0;
            textArea.SelectedText = "text-shadow: ";
            var ctrl = (Control)sender;
            var frm = ctrl.FindForm();
            TextBox smtX = null;
            NumericUpDown smnX = null;
            foreach (var ctr in frm.Controls)
            {
                if (ctr is TextBox)
                {
                    smtX = (TextBox)ctr;
                    if (smtX.Name == "colorVal" && smtX.Text != String.Empty)
                    {
                        textArea.SelectionLength = 0;
                        textArea.SelectedText = string.Format("{0} ", smtX.Text);
                    }
                }
                if (ctr is NumericUpDown)
                {
                    smnX = (NumericUpDown)ctr;
                    if (smnX.Name == "shadowXVal")
                    {
                        textArea.SelectionLength = 0;
                        textArea.SelectedText = string.Format("{0}px ", smnX.Value);
                    }
                    else
                        if (smnX.Name == "shadowYVal")
                    {
                        textArea.SelectionLength = 0;
                        textArea.SelectedText = string.Format("{0}px ", smnX.Value);
                    }
                    else
                        if (smnX.Name == "radiusVal")
                    {
                        textArea.SelectionLength = 0;
                        textArea.SelectedText = string.Format("{0}px ", smnX.Value);
                    }
                }
            }
            textArea.SelectionLength = 0;
            textArea.SelectedText = ";\n";
            frm.Close();
        }
        private void colorSelect_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.ColorDialog shadowColorSet = new ColorDialog();
            shadowColorSet.ShowHelp = true;
            if (shadowColorSet.ShowDialog() != DialogResult.Cancel)
            {
                Color tableColor = shadowColorSet.Color;
                var ctrl = (Control)sender;
                var frm = ctrl.FindForm();
                TextBox txt1 = null;
                foreach (var ctr in frm.Controls)
                {
                    if (ctr is TextBox)
                    {
                        txt1 = (TextBox)ctr;
                        if (txt1.Name == "colorVal")
                        {
                            txt1.Text = string.Format("#{0:X2}{1:X2}{2:X2}", tableColor.R, tableColor.G, tableColor.B);
                        }
                    }
                }
            }
        }
        private void textTransformCancel_Click(object sender, EventArgs e)
        {
            var ctrl = (Control)sender;
            var frm = ctrl.FindForm();
            frm.Close();
        }
        private void textTransformOK_Click(object sender, EventArgs e)
        {
            var ctrl = (Control)sender;
            var frm = ctrl.FindForm();
            RadioButton radioTransform = null;
            foreach (var ctr in frm.Controls)
            {
                if (ctr is RadioButton)
                {
                    radioTransform = (RadioButton)ctr;
                    if (radioTransform.Name == "capitalize" && radioTransform.Checked)
                    {
                        textArea.SelectionLength = 0;
                        textArea.SelectedText = string.Format("text-transform : {0}; \n", radioTransform.Name);
                    }
                    else
                        if (radioTransform.Name == "uppercase" && radioTransform.Checked)
                    {
                        textArea.SelectionLength = 0;
                        textArea.SelectedText = string.Format("text-transform : {0}; \n", radioTransform.Name);
                    }
                    else
                        if (radioTransform.Name == "lowercase" && radioTransform.Checked)
                    {
                        textArea.SelectionLength = 0;
                        textArea.SelectedText = string.Format("text-transform : {0}; \n", radioTransform.Name);
                    }
                    else
                        if (radioTransform.Name == "none" && radioTransform.Checked)
                    {
                        textArea.SelectionLength = 0;
                        textArea.SelectedText = string.Format("text-transform : {0}; \n", radioTransform.Name);
                    }
                }
            }
            frm.Close();
        }
        private void opacityCancel_Click(object sender, EventArgs e)
        {
            var ctrl = (Control)sender;
            var frm = ctrl.FindForm();
            frm.Close();
        }
        private void opacityOK_Click(object sender, EventArgs e)
        {
            var ctrl = (Control)sender;
            var frm = ctrl.FindForm();
            TextBox textBoxOpacity = null;
            foreach (var ctr in frm.Controls)
            {
                if (ctr is TextBox)
                {
                    textBoxOpacity = (TextBox)ctr;
                    if (textBoxOpacity.Name == "opacityVal" && textBoxOpacity.Text != String.Empty)
                    {

                        double val = double.Parse(textBoxOpacity.Text);

                        textArea.SelectionLength = 0;

                        textArea.SelectedText = string.Format("opacity : {0};", val * 0.1);
                    }
                }
            }
            if (textArea.Find("opacity : 0,1;") != -1)
            {
                textArea.SelectedText = ("opacity : 0.1;\n");
            }
            else
                if (textArea.Find("opacity : 0,2;") != -1)
            {
                textArea.SelectedText = ("opacity : 0.2;\n");
            }
            else
                if (textArea.Find("opacity : 0,3;") != -1)
            {
                textArea.SelectedText = ("opacity : 0.3;\n");
            }
            else
                if (textArea.Find("opacity : 0,4;") != -1)
            {
                textArea.SelectedText = ("opacity : 0.4;\n");
            }
            else
                if (textArea.Find("opacity : 0,5;") != -1)
            {
                textArea.SelectedText = ("opacity : 0.5;\n");
            }
            else
                if (textArea.Find("opacity : 0,6;") != -1)
            {
                textArea.SelectedText = ("opacity : 0.6;\n");
            }
            else
                if (textArea.Find("opacity : 0,7;") != -1)
            {
                textArea.SelectedText = ("opacity : 0.7;\n");
            }
            else
                if (textArea.Find("opacity : 0,8;") != -1)
            {
                textArea.SelectedText = ("opacity : 0.8;\n");
            }
            else
                if (textArea.Find("opacity : 0,9;") != -1)
            {
                textArea.SelectedText = ("opacity : 0.9;\n");
            }
            frm.Close();
        }
        private void opacityTrck_Scroll(object sender, EventArgs e)
        {
            string trckXYZ = null;
            var ctrl = (Control)sender;
            var frm = ctrl.FindForm();
            TrackBar trackbarXYZ = null;
            TextBox textBoxXYZ = null;
            FlowLayoutPanel flpXYZ = null;
            foreach (var ctr in frm.Controls)
            {
                if (ctr is TrackBar)
                {

                    trackbarXYZ = (TrackBar)ctr;
                    if (trackbarXYZ.Name == "opacityTrck")
                    {
                        trckXYZ = trackbarXYZ.Value.ToString();
                    }
                }
                if (ctr is TextBox)
                {
                    textBoxXYZ = (TextBox)ctr;
                    if (textBoxXYZ.Name == "opacityVal")
                    {
                        textBoxXYZ.Text = trckXYZ;
                    }
                }
                if (ctr is FlowLayoutPanel)
                {
                    flpXYZ = (FlowLayoutPanel)ctr;
                    if (flpXYZ.Name == "opacityView")
                    {
                        flpXYZ.Invalidate();
                    }
                }

            }
        }
        private void opacityView_Paint(object sender, PaintEventArgs e)
        {
            int trckOp = 0;
            var ctrl = (Control)sender;
            var frm = ctrl.FindForm();
            TrackBar trackbarX = null;
            foreach (var ctr in frm.Controls)
            {
                if (ctr is TrackBar)
                {

                    trackbarX = (TrackBar)ctr;
                    if (trackbarX.Name == "opacityTrck")
                    {
                        trckOp = trackbarX.Value;
                    }

                }
            }
            SolidBrush semiTransBrush = new SolidBrush(Color.FromArgb(trackbarX.Value * (51 / 2), 0, 0, 255));
            e.Graphics.FillEllipse(semiTransBrush, 30, 30, 45, 30);
        }
        private void positionCancel_Click(object sender, EventArgs e)
        {
            var ctrl = (Control)sender;
            var frm = ctrl.FindForm();
            frm.Close();
        }
        private void positionOK_Click(object sender, EventArgs e)
        {
            var ctrl = (Control)sender;
            var frm = ctrl.FindForm();
            RadioButton posRad = null;
            foreach (var ctr in frm.Controls)
            {
                if (ctr is RadioButton)
                {

                    posRad = (RadioButton)ctr;
                    if (posRad.Name == "absolute" && posRad.Checked)
                    {
                        textArea.SelectionLength = 0;
                        textArea.SelectedText = string.Format("position: {0};\n",posRad.Name);
                    }
                    else 
                        if(posRad.Name == "fixed" && posRad.Checked)
                    {
                        textArea.SelectionLength = 0;
                        textArea.SelectedText = string.Format("position: {0};\n", posRad.Name);
                    }
                    else 
                        if(posRad.Name == "relative" && posRad.Checked)
                    {
                        textArea.SelectionLength = 0;
                        textArea.SelectedText = string.Format("position: {0};\n", posRad.Name);
                    }
                    else 
                        if(posRad.Name == "static" && posRad.Checked)
                    {
                        textArea.SelectionLength = 0;
                        textArea.SelectedText = string.Format("position: {0};\n", posRad.Name);
                    }
                    else
                        if(posRad.Name == "inherit" && posRad.Checked)
                    {
                        textArea.SelectionLength = 0;
                        textArea.SelectedText = string.Format("position: {0};\n", posRad.Name);
                    }
                }
            }
            frm.Close();
        }
        private void heightValTrack_Scroll(object sender, EventArgs e)
        {
            string trck2 = null;
            var ctrl = (Control)sender;
            var frm = ctrl.FindForm();
            TrackBar trackbarX2 = null;
            TextBox textBoxX2 = null;
            FlowLayoutPanel flpY = null;
            foreach (var ctr in frm.Controls)
            {
                if (ctr is TrackBar)
                {

                    trackbarX2 = (TrackBar)ctr;
                    if (trackbarX2.Name == "heightValTrack")
                    {
                        trck2 = trackbarX2.Value.ToString();
                    }

                    //  flowLayoutPanel1.Invalidate();
                }
                if (ctr is TextBox)
                {
                    textBoxX2 = (TextBox)ctr;
                    if (textBoxX2.Name == "heigthVal")
                    {
                        textBoxX2.Text = trck2;
                    }
                }
                if (ctr is FlowLayoutPanel)
                {
                    flpY = (FlowLayoutPanel)ctr;
                    if (flpY.Name == "objectPrototype")
                    {
                        flpY.Invalidate();
                    }
                }

            }
        }
        private void widthValTrack_Scroll(object sender, EventArgs e)
        {
            string trck1 = null;
            var ctrl = (Control)sender;
            var frm = ctrl.FindForm();
            TrackBar trackbarX = null;
            FlowLayoutPanel flpX = null;
            TextBox textBoxX1 = null;
            foreach (var ctr in frm.Controls)
            {
                if (ctr is TrackBar)
                {
                    
                    trackbarX = (TrackBar)ctr;
                    if (trackbarX.Name == "widthValTrack")
                    {
                         trck1 = trackbarX.Value.ToString();
                    }
                    
                    //  flowLayoutPanel1.Invalidate();
                }
                if (ctr is TextBox)
                {
                    textBoxX1 = (TextBox)ctr;
                    if (textBoxX1.Name =="widthVal")
                    {
                        textBoxX1.Text = trck1;

                    }
                 }
                if (ctr is FlowLayoutPanel)
                {
                    flpX = (FlowLayoutPanel)ctr;
                    if (flpX.Name == "objectPrototype")
                    {
                        flpX.Invalidate();
                    }
                }
            }
        }
        private void youtubeOK_Click(object sender, EventArgs e)
        {
            textArea.SelectionLength = 0;
            textArea.SelectedText = "<iframe ";

            var ctrl = (Control)sender;
            var frm = ctrl.FindForm();
            TextBox textBoxZ = null;
            RichTextBox ytblink = null;
            foreach (var ctr in frm.Controls)
            {
                if (ctr is TextBox)
                {
                    textBoxZ = (TextBox)ctr;
                    if (textBoxZ.Name == "widthVal" && textBoxZ.Text != String.Empty) 
                    {
                        textArea.SelectionLength = 0;
                        textArea.SelectedText = string.Format(" height=\"{0}\" ",textBoxZ.Text);
                     }
                    else
                        if(textBoxZ.Name =="heigthVal" && textBoxZ.Text != String.Empty)
                    {
                        textArea.SelectionLength = 0;
                        textArea.SelectedText = string.Format(" weight=\"{0}\" ",textBoxZ.Text);
                    }
                    
                }
                if (ctr is RichTextBox)
                {
                    ytblink = (RichTextBox)ctr;
                    if(ytblink.Name == "ytbLink" && ytblink.Text != String.Empty)
                    {
                        
                            textArea.SelectionLength = 0;
                            textArea.SelectedText = string.Format(" src=\"{0}\" ", ytblink.Text);
                    }
                }
            }
            frm.Close();
            textArea.SelectionLength = 0;
            textArea.SelectedText = " frameborder=\"0\" allowfullscreen></iframe> \n";
        }
        private void youtubeCancel_Click(object sender,EventArgs e)
        {
            var ctrl = (Control)sender;
            var frm = ctrl.FindForm();
            frm.Close();
        }
        private void ytbLink_Changed(object sender, EventArgs e)
        {
            var ctrl = (Control)sender;
            var frm = ctrl.FindForm();
            RichTextBox ytb = null;
            foreach (var ctr in frm.Controls)
            {
                if (ctr is RichTextBox)
                {

                    ytb = (RichTextBox)ctr;
                    if (ytb.Name == "ytbLink")
                    {
                        if (ytb.Find("watch?v=") != -1)
                        {
                            StringBuilder sb1 = new StringBuilder("embed/");
                            sb1.Insert(1, "");
                            //textArea.SelectionLength = 0;
                            ytb.SelectedText = string.Format("{0}",sb1.ToString());
                        } 
                        else
                            if(ytb.Find(".be") != -1)
                        {
                            StringBuilder sb1 = new StringBuilder("be.com/embed/");
                            sb1.Insert(1, "");
                            //textArea.SelectionLength = 0;
                            ytb.SelectedText = string.Format("{0}", sb1.ToString());
                        }
                     }
                }
            }
        }
        private void objectPrototype_Paint(object sender, PaintEventArgs e)
        {

            int trck3=0;
            int trck4=0;
            var ctrl = (Control)sender;
            var frm = ctrl.FindForm();
            TrackBar trackbarX = null;
            foreach (var ctr in frm.Controls)
            {
                if (ctr is TrackBar)
                {
                    trackbarX = (TrackBar)ctr;
                    if (trackbarX.Name == "widthValTrack")
                    {
                        trck3 = trackbarX.Value;
                    }
                    else
                        if(trackbarX.Name =="heightValTrack")
                    {
                        trck4 = trackbarX.Value;
                    }
                }
            }
            Pen blackPen = new Pen(Color.Black, 3);
            Rectangle rect = new Rectangle(11, 6, trck4 / 10,  trck3/10);
            e.Graphics.DrawRectangle(blackPen, rect);
        }
        private void textAreaBtn_Click(object sender, EventArgs e)
        {
            textArea.SelectionLength = 0;
            textArea.SelectedText = "<textarea name=\"name1\" autofocus>A lot of text</textarea> \n";
        }
        private void paraqrafBtn_Click(object sender, EventArgs e)
        {
            textArea.SelectedText = string.Format("<p>{0}</p>",textArea.SelectedText);
        }
        private void yeniSetirBtn_Click(object sender, EventArgs e)
        {
            textArea.SelectionLength = 0;
            textArea.SelectedText = "<br>";
        }
        private void horizontalXettBtn_Click(object sender, EventArgs e)
        {
            textArea.SelectionLength = 0;
            textArea.SelectedText = "<hr>";
        }
        private void divCancel_Click(object sender,EventArgs e)
        {
            var ctrl = (Control)sender;
            var frm = ctrl.FindForm();
            frm.Close();
        }
        private void divOK_Click(object sender, EventArgs e)
        {
            textArea.SelectionLength = 0;
            textArea.SelectedText = "<div ";
            var ctrl = (Control)sender;
            var frm = ctrl.FindForm();
            TextBox txtBOX = null;
            RadioButton radioBTN = null;
            foreach (var ctr in frm.Controls)
            {
                if (ctr is TextBox)
                {
                    txtBOX = (TextBox)ctr;
                    if (txtBOX.Name == "divNameVal" && txtBOX.Text != String.Empty)
                    {
                        textArea.SelectionLength = 0;
                        textArea.SelectedText = string.Format(" title=\"{0}\" ",txtBOX.Text);
                    }
                    else 
                        if(txtBOX.Name == "classNameVal" && txtBOX.Text != String.Empty)
                    {
                        textArea.SelectionLength = 0;
                        textArea.SelectedText = string.Format(" class=\"{0}\" ",txtBOX.Text);
                    }
                }
                if (ctr is RadioButton)
                {
                    radioBTN = (RadioButton)ctr;
                    if(radioBTN.Name == "right" && radioBTN.Checked)
                    {
                        textArea.SelectionLength = 0;
                        textArea.SelectedText = string.Format(" align=\"{0}\" ",radioBTN.Name);
                    }
                    else 
                        if (radioBTN.Name == "left" && radioBTN.Checked)
                    {
                        textArea.SelectionLength = 0;
                        textArea.SelectedText = string.Format(" align=\"{0}\" ",radioBTN.Name);
                    }
                    else
                        if(radioBTN.Name == "center" && radioBTN.Checked)
                    {
                        textArea.SelectionLength = 0;
                        textArea.SelectedText = string.Format(" align=\"{0}\" ", radioBTN.Name);
                    }
                }
            }
            frm.Close();
            textArea.SelectionLength = 0;
            textArea.SelectedText = "> </div>";
        }
        private void spanButton_Click(object sender, EventArgs e)
        {
            textArea.SelectedText = string.Format("<span>{0}</span>", textArea.SelectedText);
        }
        private void aboutOK_Click(object sender,EventArgs e)
        {
            var ctrl = (Control)sender;
            var frm = ctrl.FindForm();
            frm.Close();
        }
        private void əlaqəToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clipboard.SetText("mcafeahmed@gmail.com");
            MessageBox.Show("Email copied to clipboard!","Contact");
            //System.Diagnostics.Process.Start("mailto:mcafeahmed@gmail.com");
        }
        private void kesenxettBtn_Click(object sender, EventArgs e)
        {
            textArea.SelectedText = string.Format("<strike>{0}</strike> \n", textArea.SelectedText);
        }
        private void tableCancel_Click(object sender,EventArgs e)
        {
            var ctrl = (Control)sender;
            var frm = ctrl.FindForm();
            frm.Close();
        }
        private void tableOK_Click(object sender, EventArgs e)
        {
            textArea.SelectionLength = 0;
            textArea.SelectedText = "<table ";
            var ctrl = (Control)sender;
            var frm = ctrl.FindForm();
            NumericUpDown nud4 = null;
            TextBox txt4 = null;
            RadioButton rbtn2 = null;
            foreach (var ctr in frm.Controls)
            {
                if (ctr is TextBox)
                {
                    txt4 = (TextBox)ctr;
                    if (txt4.Name == "bgImgFileName" && txt4.Text != String.Empty)
                    {
                        textArea.SelectionLength = 0;
                        textArea.SelectedText = string.Format(" background=\"{0}\" ", txt4.Text);
                    }
                    else
                    if (txt4.Name == "tableColorCode" && txt4.Text != String.Empty)
                    {
                        textArea.SelectionLength = 0;
                        textArea.SelectedText = string.Format(" bgcolor=\"{0}\" ", txt4.Text);
                    }
                    else
                    if (txt4.Name == "tableBorderColorCode" && txt4.Text != String.Empty)
                    {
                        textArea.SelectionLength = 0;
                        textArea.SelectedText = string.Format(" bordercolor=\"{0}\" ", txt4.Text);
                    }
                }
                if (ctr is RadioButton)
                {
                    rbtn2 = (RadioButton)ctr;
                    if (rbtn2.Name == "right" && rbtn2.Checked)
                    {
                        textArea.SelectionLength = 0;
                        textArea.SelectedText = string.Format(" align=\"{0}\" ", rbtn2.Name);
                    }
                    else
                        if (rbtn2.Name == "center" && rbtn2.Checked)
                    {
                        textArea.SelectionLength = 0;
                        textArea.SelectedText = string.Format(" align=\"{0}\" ", rbtn2.Name);
                    }
                    else
                        if (rbtn2.Name == "left" && rbtn2.Checked)
                    {
                        textArea.SelectionLength = 0;
                        textArea.SelectedText = string.Format(" align=\"{0}\" ", rbtn2.Name);
                    }
                }
                if (ctr is NumericUpDown)
                {
                    nud4 = (NumericUpDown)ctr;
                    if (nud4.Name == "tableBorderSizeVal" && nud4.Value != 0)
                    {
                        textArea.SelectionLength = 0;
                        textArea.SelectedText = string.Format(" border =\"{0}\" ", nud4.Value);
                    }
                    else
                        if (nud4.Name == "tabCellPaddingVal" && nud4.Value != 0)
                    {
                        textArea.SelectionLength = 0;
                        textArea.SelectedText = string.Format(" cellpadding=\"{0}\" ", nud4.Value);
                    }
                    else
                        if (nud4.Name == "tableCellSpacingVal" && nud4.Value != 0)
                    {
                        textArea.SelectionLength = 0;
                        textArea.SelectedText = string.Format(" cellspacing=\"{0}\" ", nud4.Value);
                    }
                }

            }
            textArea.SelectionLength = 0;
            textArea.SelectedText = ">";
            TextBox txt5 = null;
            foreach (var ctr in frm.Controls)
            {
                if (ctr is TextBox)
                {
                    txt5 = (TextBox)ctr;
                    if (txt5.Name == "tableName" && txt5.Text != String.Empty)
                    {
                        textArea.SelectionLength = 0;
                        textArea.SelectedText = string.Format("<caption>{0}</caption>\n", txt5.Text);
                    }
                }
            }
            textArea.SelectionLength = 0;
            textArea.SelectedText = "</table>";
            frm.Close();
        }
        private void tableBorderColorSet_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.ColorDialog tableColorSet = new ColorDialog();
            tableColorSet.ShowHelp = true;
            if (tableColorSet.ShowDialog() != DialogResult.Cancel)
            {
                Color tableColor = tableColorSet.Color;
                var ctrl = (Control)sender;
                var frm = ctrl.FindForm();
                TextBox txt1 = null;
                foreach (var ctr in frm.Controls)
                {
                    if (ctr is TextBox)
                    {
                        txt1 = (TextBox)ctr;
                        if (txt1.Name == "tableBorderColorCode")
                        {
                            txt1.Text = string.Format("#{0:X2}{1:X2}{2:X2}", tableColor.R, tableColor.G, tableColor.B);
                        }
                    }
                }
            }


        }
        private void tableColor_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.ColorDialog tableColorSet = new ColorDialog();
            tableColorSet.ShowHelp = true;
            if (tableColorSet.ShowDialog() != DialogResult.Cancel)
            {
                Color tableColor = tableColorSet.Color;
                var ctrl = (Control)sender;
                var frm = ctrl.FindForm();
                TextBox txt1 = null;
                foreach (var ctr in frm.Controls)
                {
                    if (ctr is TextBox)
                    {
                        txt1 = (TextBox)ctr;
                        if (txt1.Name == "tableColorCode")
                        {
                            txt1.Text = string.Format("#{0:X2}{1:X2}{2:X2}", tableColor.R, tableColor.G, tableColor.B);
                        }
                    }
                }
            }
        }
        private void selectBGImg_Click(object sender, EventArgs e)
        {
            if (imageOpen.ShowDialog() != DialogResult.Cancel)
            {
                System.IO.StreamReader OpenFile = new System.IO.StreamReader(imageOpen.FileName);
            }
            string fullpath = imageOpen.FileName;
            var ctrl = (Control)sender;
            var frm = ctrl.FindForm();
            TextBox txt = null;
            foreach (var ctr in frm.Controls)
            {
                if (ctr is TextBox)
                {
                    txt = (TextBox)ctr;
                    if (txt.Name == "bgImgFileName")
                    {
                        txt.Text = fullpath;
                    }
                }
            }

        }
        private void trBtn_Click(object sender, EventArgs e)
        {
            textArea.SelectedText = "<tr> </tr>";
        }
        private void tdBtn_Click(object sender, EventArgs e)
        {
            textArea.SelectionLength = 0;
            textArea.SelectedText = "<td> Simple text </td>";
        }
        private void chapTSMI_Click(object sender, EventArgs e)
        {
            System.Drawing.Printing.PrintDocument prntDoc = new System.Drawing.Printing.PrintDocument();
        }
        private void chixishTSMI_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void geriTSMI_Click(object sender, EventArgs e)
        {
            textArea.Undo();
        }
        private void ireliTSMI_Click(object sender, EventArgs e)
        {
            textArea.Undo();
        }
        private void kesTSMI_Click(object sender, EventArgs e)
        {
            textArea.Cut();
        }
        private void kopyalaTSMI_Click(object sender, EventArgs e)
        {
            textArea.Copy();
        }
        private void daxilTSMI_Click(object sender, EventArgs e)
        {
            textArea.Paste();
        }
        private void hamsiTSMI_Click(object sender, EventArgs e)
        {
            textArea.SelectAll();
        }
        private void setirTSMİ_Click(object sender, EventArgs e)
        {
            textArea.WordWrap = setirTSMİ.Checked;
        }
        private void yagliBtn_Click(object sender, EventArgs e)
        {
            textArea.SelectedText = string.Format("<b>{0}</b>", textArea.SelectedText);
        }
        private void eyriBtn_Click(object sender, EventArgs e)
        {
            textArea.SelectedText = string.Format("<i>{0}</i>", textArea.SelectedText);
        }
        private void altdanxettBtn_Click(object sender, EventArgs e)
        {
            textArea.SelectedText = string.Format("<u>{0}</u>", textArea.SelectedText);
        }
        private void yaddashTSMI_Click(object sender, EventArgs e)
        {
            if (textArea.Find("<html>") != -1)
            {
                htmlSave.ShowDialog();
                System.IO.StreamWriter HTMLSAVE = new System.IO.StreamWriter(htmlSave.FileName);
                HTMLSAVE.WriteLine(textArea.Text);
                htmlSave.DefaultExt = "html";
                htmlSave.FileName = "new.html";
                htmlSave.RestoreDirectory = true;
                HTMLSAVE.Close();
            }
            else
                    if (textArea.Find("<?php") != -1)
            {
                phpSave.ShowDialog();
                System.IO.StreamWriter PHPSAVE = new System.IO.StreamWriter(phpSave.FileName);
                PHPSAVE.WriteLine(textArea.Text);
                phpSave.Filter = "PHP files (*.php)|*.php*";
                phpSave.DefaultExt = "php";
                phpSave.FileName = "new.php";
                phpSave.RestoreDirectory = true;
                PHPSAVE.Close();

            }
            else
                        if (textArea.Find("{") != -1)
            {
                cssSave.ShowDialog();
                System.IO.StreamWriter CSSSAVE = new System.IO.StreamWriter(cssSave.FileName);
                CSSSAVE.WriteLine(textArea.Text);
                cssSave.Filter = "CSS files (*.css)|*.css*";
                cssSave.DefaultExt = "css";
                cssSave.FileName = "new.css";
                cssSave.RestoreDirectory = true;
                CSSSAVE.Close();

            }
        }
        private void saveFile_Click(object sender, EventArgs e)
        {
            var ctrl = (Control)sender;
            var frm = ctrl.FindForm();
            yaddashTSMI_Click(sender, e);

            Stream myStream = null;
            OpenFileDialog theDialog = new OpenFileDialog();
            theDialog.Title = "Open file";
            theDialog.Filter = "HTML files|*.HTML|HTM files|*.htm|PHP files|*.php|CSS files|*.css";
            if (theDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if ((myStream = theDialog.OpenFile()) != null)
                    {
                        using (myStream)
                        {
                            string file = File.ReadAllText(theDialog.FileName);
                            textArea.Text = file;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
            this.Text = string.Format("Loxie - [{0}]", theDialog.FileName);
            frm.Close();
        }
        private void saveNo_Click(object sender, EventArgs e)
        {
            var ctrl = (Control)sender;
            var frm = ctrl.FindForm();
            Stream myStream = null;
            OpenFileDialog theDialog = new OpenFileDialog();
            theDialog.Title = "Open file";
            theDialog.Filter = "HTML files|*.HTML|HTM files|*.htm|PHP files|*.php|CSS files|*.css";
            if (theDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if ((myStream = theDialog.OpenFile()) != null)
                    {
                        using (myStream)
                        {
                            string file = File.ReadAllText(theDialog.FileName);
                            textArea.Text = file;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
            this.Text = string.Format("Loxie - [{0}]", theDialog.FileName);
            frm.Close();
        }
        private void abbrvOK_Click(object sender, EventArgs e)
        {
            string val1 = null;
            string val2 = null;
            textArea.SelectionLength = 0;
            textArea.SelectedText = "<abbr";
            var ctrl = (Control)sender;
            var frm = ctrl.FindForm();
            TextBox abbrvTxt = null;
            foreach (var ctr in frm.Controls)
            {
                if (ctr is TextBox)
                {
                    abbrvTxt = (TextBox)ctr;
                    if (abbrvTxt.Name == "fullTextVal")
                    {
                        val1 = string.Format(" title=\"{0}\"",abbrvTxt.Text);
                    }
                    else 
                        if(abbrvTxt.Name == "abbrvTextVal")
                    {
                        val2 = string.Format("{0}",abbrvTxt.Text);
                    }
                }
            }
            frm.Close();
            textArea.SelectedText = string.Format("{0}>{1}</abbr>\n", val1,val2);
        }
        private void abbrvCancel_Click(object sender,EventArgs e)
        {
            var ctrl = (Control)sender;
            var frm = ctrl.FindForm();
            frm.Close();
        }
        private void formCancel_Click(object sender,EventArgs e)
        {
            var ctrl = (Control)sender;
            var frm = ctrl.FindForm();
            frm.Close();
        }
        public void formOK_Click(object sender, EventArgs e)
        {
            textArea.SelectionLength = 0;
            textArea.SelectedText = "<form ";
            var ctrl = (Control)sender;
            var frm = ctrl.FindForm();
            CheckBox checkBoxX = null;
            TextBox textboxX = null;
            RadioButton radiobuttonX = null;
            foreach (var ctr in frm.Controls)
            {
                if (ctr is TextBox)
                {
                    textboxX = (TextBox)ctr;
                    if (textboxX.Name == "formNameVal" && textboxX.Text != String.Empty)
                    {
                        textArea.SelectionLength = 0;
                        textArea.SelectedText = string.Format(" name=\"{0}\" ", textboxX.Text);
                    }
                    else
                    if (textboxX.Name == "actionFile" && textboxX.Text != String.Empty)
                    {
                        textArea.SelectionLength = 0;
                        textArea.SelectedText = string.Format(" action=\"{0}\" ", textboxX.Text);
                    }
                    
                }
                if (ctr is CheckBox)
                {
                    checkBoxX = (CheckBox)ctr;
                    bool check_state = checkBoxX.Checked;
                    if (checkBoxX.Name == "autocompleteCheck" && check_state == true)
                    {
                        textArea.SelectionLength = 0;
                        textArea.SelectedText = "autocomplete=\"on\" ";
                    }
                    else 
                        if(checkBoxX.Name=="autocompleteCheck" && check_state == false)
                    {
                        textArea.SelectionLength = 0;
                        textArea.SelectedText = "autocomplete=\"off\" ";
                    }
                }
                if (ctr is RadioButton)
                {
                    radiobuttonX = (RadioButton)ctr;
                    if (radiobuttonX.Name == "application" && radiobuttonX.Checked)
                    {
                        textArea.SelectionLength = 0;
                        textArea.SelectedText = " enctype=\"application/x-www-form-urlencoded\" ";
                    }
                    else
                        if (radiobuttonX.Name == "text" && radiobuttonX.Checked)
                    {
                        textArea.SelectionLength = 0;
                        textArea.SelectedText = " enctype=\"multipart/form-data\" ";
                    }
                    else
                        if (radiobuttonX.Name == "text" && radiobuttonX.Checked)
                    {
                        textArea.SelectionLength = 0;
                        textArea.SelectedText = " enctype=\"text/plain\" ";
                    }
                    else
                        if (radiobuttonX.Name == "get" && radiobuttonX.Checked)
                    {
                        textArea.SelectionLength = 0;
                        textArea.SelectedText = string.Format(" method=\"{0}\" ",radiobuttonX.Name);
                    }
                    else 
                        if(radiobuttonX.Name == "post" && radiobuttonX.Checked)
                    {
                        textArea.SelectionLength = 0;
                        textArea.SelectedText = string.Format(" method=\"{0}\" ", radiobuttonX.Name);
                    }
                    else 
                        if(radiobuttonX.Name =="_self" && radiobuttonX.Checked)
                    {
                        textArea.SelectionLength = 0;
                        textArea.SelectedText = string.Format(" target=\"{0}\" ", radiobuttonX.Name);
                    }
                    else
                        if(radiobuttonX.Name == "_blank" && radiobuttonX.Checked)
                    {
                        textArea.SelectionLength = 0;
                        textArea.SelectedText = string.Format(" target=\"{0}\" ", radiobuttonX.Name);
                    }
                    else 
                        if(radiobuttonX.Name == "_parent" && radiobuttonX.Checked)
                    {
                        textArea.SelectionLength = 0;
                        textArea.SelectedText = string.Format(" target=\"{0}\" ", radiobuttonX.Name);
                    }
                    else 
                        if(radiobuttonX.Name == "_top" && radiobuttonX.Checked)
                    {
                        textArea.SelectionLength = 0;
                        textArea.SelectedText = string.Format(" target=\"{0}\" ", radiobuttonX.Name);
                    }
                
                }
            }
            textArea.SelectionLength = 0;
            textArea.SelectedText = "> \n";
            textArea.SelectedText = "</form>";
            frm.Close();
        }
        public void fileSelect_Click(object sender, EventArgs e)
        {
            OpenFileDialog action_open = new OpenFileDialog();
            action_open.Filter = ("PHP files | *.php");
            action_open.Title = "Select PHP file";
            action_open.ShowDialog();
            string actionName = action_open.FileName;

            var ctrl = (Control)sender;
            var frm = ctrl.FindForm();
            TextBox txt = null;
            foreach (var ctr in frm.Controls)
            {
                if (ctr is TextBox)
                {
                    txt = (TextBox)ctr;
                    if (txt.Name == "actionFile")
                    {
                        txt.Text = actionName;
                    }
                }
            }
          
        }
        private void CancelPddngBtn_Click(object sender,EventArgs e)
        {
            var ctrl = (Control)sender;
            var frm = ctrl.FindForm();
            frm.Close();
        }
        public void OKPddngBtn_Click(object sender, EventArgs e)
        {
            var ctrl = (Control)sender;
            var frm = ctrl.FindForm();
            NumericUpDown nud = null;
            foreach (var ctr in frm.Controls)
            {
                if (ctr is NumericUpDown)
                {
                    nud = (NumericUpDown)ctr;
                    if (nud.Name == "top")
                    {
                        textArea.SelectionLength = 0;
                        textArea.SelectedText = string.Format("padding-top: {0}%; \n", nud.Value);
                    }
                    else
                        if (nud.Name == "bottom")
                    {
                        textArea.SelectionLength = 0;
                        textArea.SelectedText = string.Format("padding-bottom: {0}%; \n", nud.Value);
                    }
                    else
                        if (nud.Name == "left")
                    {
                        textArea.SelectionLength = 0;
                        textArea.SelectedText = string.Format("padding-left: {0}%; \n", nud.Value);
                    }
                    else
                        if (nud.Name == "right")
                    {
                        textArea.SelectionLength = 0;
                        textArea.SelectedText = string.Format("padding-right: {0}%; \n", nud.Value);
                    }
                }
            }
            frm.Close();
        }
        public void loadStyle_Click(object sender,EventArgs e)
        {
            OpenFileDialog style_open = new OpenFileDialog();
            style_open.Filter = ("CSS Files | *.css");
            style_open.Title = "Select style files";
            if (style_open.ShowDialog() != DialogResult.Cancel)
            {
                System.IO.StreamReader OpenFile = new System.IO.StreamReader(style_open.FileName);
                string loadstyle = style_open.FileName;
                if (textArea.Find("<head>") != -1)
                {
                    StringBuilder sb1 = new StringBuilder("<head>");
                    sb1.Insert(6, string.Format("\n<link rel=\"stylesheet\" href=\"{0}\">", loadstyle));
                    textArea.SelectedText = sb1.ToString();
                }
            }
        }
        public void borderCancel_Click(object sender,EventArgs e)
        {
            var ctrl = (Control)sender;
            var frm = ctrl.FindForm();
            frm.Close();
        }
        public void setBorderColor_Click(object sender,EventArgs e)
        {
            System.Windows.Forms.ColorDialog borderColorSet = new ColorDialog();
            borderColorSet.ShowHelp = true;
            if (borderColorSet.ShowDialog() != DialogResult.Cancel)
            {
                Color borderColor = borderColorSet.Color;
                var ctrl = (Control)sender;
                var frm = ctrl.FindForm();
                TextBox txt1 = null;
                foreach (var ctr in frm.Controls)
                {
                    if (ctr is TextBox)
                    {
                        txt1 = (TextBox)ctr;
                        if(txt1.Name == "colorCode")
                        {
                            txt1.Text = string.Format("#{0:X2}{1:X2}{2:X2}", borderColor.R, borderColor.G, borderColor.B);
                        }
                    }
                }
               // textArea.SelectedText = "color: " + String.Format("#{0:X2}{1:X2}{2:X2} ; \n", someColor.R, someColor.G, someColor.B);
            }
        }
        public void borderOk_Click(object sender, EventArgs e)
        {
            var ctrl= (Control)sender;
            var frm = ctrl.FindForm();
            NumericUpDown nud1 = null;
            RadioButton rbtn1 = null;
            TextBox txt1 = null;
            foreach (var ctr in frm.Controls)
            {

                if (ctr is RadioButton)
                {
                    rbtn1 = (RadioButton)ctr;
                    if (rbtn1.Name == "ridge" && rbtn1.Checked)
                    {
                        textArea.SelectionLength = 0;
                        textArea.SelectedText = string.Format("border-style : {0} ; \n", rbtn1.Name);
                    }
                    else
                        if(rbtn1.Name == "dotted" && rbtn1.Checked)
                    {
                        textArea.SelectionLength = 0;
                        textArea.SelectedText = string.Format("border-style : {0} ; \n", rbtn1.Name);
                    }
                    else
                        if (rbtn1.Name == "solid" && rbtn1.Checked)
                    {
                        textArea.SelectionLength = 0;
                        textArea.SelectedText = string.Format("border-style : {0} ; \n", rbtn1.Name);
                    }
                    else
                        if (rbtn1.Name == "groove" && rbtn1.Checked)
                    {
                        textArea.SelectionLength = 0;
                        textArea.SelectedText = string.Format("border-style : {0} ; \n", rbtn1.Name);
                    }
                    else
                        if (rbtn1.Name == "inset" && rbtn1.Checked)
                    {
                        textArea.SelectionLength = 0;
                        textArea.SelectedText = string.Format("border-style : {0} ; \n", rbtn1.Name);
                    }
                    else if (rbtn1.Name == "dashed" && rbtn1.Checked)
                    {
                        textArea.SelectionLength = 0;
                        textArea.SelectedText = string.Format("border-style : {0} ; \n", rbtn1.Name);
                    }
                    else
                        if(rbtn1.Name == "double" && rbtn1.Checked)
                    {
                        textArea.SelectionLength = 0;
                        textArea.SelectedText = string.Format("border-style : {0} ; \n", rbtn1.Name);
                    }
                    else 
                        if(rbtn1.Name =="outset" && rbtn1.Checked)
                    {
                        textArea.SelectionLength = 0;
                        textArea.SelectedText = string.Format("border-style : {0} ; \n", rbtn1.Name);
                    }
                }
                if (ctr is NumericUpDown)
               {
                    nud1 = (NumericUpDown)ctr;
                    if (nud1.Name == "borderSize")
                    {
                        textArea.SelectionLength = 0;
                        textArea.SelectedText = string.Format("border-width: {0}px; \n",nud1.Value);
                    }
                    
                }
                if (ctr is TextBox)
                {
                    txt1 = (TextBox)ctr;
                    if (txt1.Name == "colorCode" && txt1.Text != String.Empty)
                    {
                        textArea.SelectedText = string.Format("border-color: {0}; \n",txt1.Text);
                    }
                }

            }

            frm.Close();
        }
        private void backgroundOK_Click(object sender, EventArgs e)
        {
            var ctrl = (Control)sender;
            var frm = ctrl.FindForm();
            TextBox backTxt = null;
            CheckBox backChk = null;
            ComboBox backCmb = null;
            GroupBox backGrb = null;
            NumericUpDown backNud = null;
            string value1 = String.Empty;
            string value2 = String.Empty;
            foreach (var ctr in frm.Controls)
            {
                if (ctr is TextBox)
                {
                    backTxt = (TextBox)ctr;
                    if (backTxt.Name == "backgroundColor" && backTxt.Enabled == true && backTxt.Text != String.Empty)
                    {
                        textArea.SelectedText = string.Format("background-color: {0};\n", backTxt.Text);
                    }
                    if (backTxt.Name == "backgroundImgURL" && backTxt.Text != String.Empty)
                    {
                        textArea.SelectedText = string.Format("background-image: url({0});\n", backTxt.Text);
                    }
                }
                if (ctr is CheckBox)
                {
                    backChk = (CheckBox)ctr;
                    if (backChk.Name == "transparentChk" && backChk.Checked == true)
                    {
                        textArea.SelectedText = string.Format("background-color: transparent;\n");
                    }
                }
                if (ctr is ComboBox)
                {
                    backCmb = (ComboBox)ctr;
                    object selectedItem = backCmb.SelectedItem;
                    if (backCmb.Name == "backgroundScroll" && backCmb.SelectedItem != null)
                    {
                        textArea.SelectedText = string.Format("background-attachment: {0};\n", selectedItem);
                    }
                    if (backCmb.Name == "backgroundRepeat" && backCmb.SelectedItem != null)
                    {
                        textArea.SelectedText = string.Format("background-repeat: {0};\n", selectedItem);
                    }
                    if (backCmb.Name == "backgroundOrigin" && backCmb.SelectedItem != null)
                    {
                        textArea.SelectedText = string.Format("background-origin: {0};\n", selectedItem);
                    }
                    if (backCmb.Name == "backgroundClip" && backCmb.SelectedItem != null)
                    {
                        textArea.SelectedText = string.Format("background-clip: {0};\n", selectedItem);
                    }

                }
                if (ctr is GroupBox)
                {
                    backGrb = (GroupBox)ctr;
                    if (backGrb.Name == "bgImageSize")
                    {
                        foreach (Control controlSS in backGrb.Controls)
                        {
                            if (controlSS is ComboBox)
                            {
                                backCmb = (ComboBox)controlSS;
                                if (backCmb.Name == "sizeType")
                                {
                                    int sItem = backCmb.SelectedIndex;
                                    object selected = backCmb.SelectedItem;
                                    switch (sItem)
                                    {
                                        case 0:
                                            textArea.SelectedText = string.Format("background-size: {0};\n", selected.ToString());
                                            break;
                                        case 1:
                                            textArea.SelectedText = string.Format("background-size: {0};\n", selected.ToString());
                                            break;
                                        case 2:
                                            textArea.SelectedText = string.Format("background-size: {0};\n", selected.ToString());
                                            break;
                                        case 3:
                                            if (backGrb.Controls.OfType<NumericUpDown>().FirstOrDefault(x => x.Name == "size1").Value != 0 && backGrb.Controls.OfType<NumericUpDown>().FirstOrDefault(x => x.Name == "size2").Value != 0)
                                            {
                                                textArea.SelectedText = string.Format("background-size: {0}%  {1}%;\n", backGrb.Controls.OfType<NumericUpDown>().FirstOrDefault(x => x.Name == "size1").Value, backGrb.Controls.OfType<NumericUpDown>().FirstOrDefault(x => x.Name == "size2").Value);
                                            }
                                            break;
                                        case 4:
                                            if (backGrb.Controls.OfType<NumericUpDown>().FirstOrDefault(x => x.Name == "size1").Value != 0 && backGrb.Controls.OfType<NumericUpDown>().FirstOrDefault(x => x.Name == "size2").Value != 0)
                                            {
                                                textArea.SelectedText = string.Format("background-size: {0}px  {1}px;\n", backGrb.Controls.OfType<NumericUpDown>().FirstOrDefault(x => x.Name == "size1").Value, backGrb.Controls.OfType<NumericUpDown>().FirstOrDefault(x => x.Name == "size2").Value);
                                            }
                                            break;
                                    }
                                }
                            }
                        }
                    }
                    if (backGrb.Name == "bgImagePosition")
                    {
                        foreach (Control controlSS in backGrb.Controls)
                        {
                            if (controlSS is ComboBox)
                            {
                                backCmb = (ComboBox)controlSS;
                                object selItem = backCmb.SelectedItem;
                                if (backCmb.Name == "LCR1" && backCmb.Visible == true && backCmb.SelectedItem != null && backGrb.Controls.OfType<ComboBox>().FirstOrDefault(x => x.Name == "LCR2").Visible == true && backGrb.Controls.OfType<ComboBox>().FirstOrDefault(x => x.Name == "LCR2").SelectedItem != null)
                                {
                                    textArea.SelectedText = string.Format("background-position: {0} {1};\n", backGrb.Controls.OfType<ComboBox>().FirstOrDefault(x => x.Name == "LCR1").SelectedItem,backGrb.Controls.OfType<ComboBox>().FirstOrDefault(x => x.Name == "LCR2").SelectedItem);
                                }
                            }
                            if (controlSS is NumericUpDown)
                            {
                                backNud = (NumericUpDown)controlSS;
                                if (backNud.Name == "position1" && backNud.Visible == true && backNud.Value != 0 && backGrb.Controls.OfType<NumericUpDown>().FirstOrDefault(x => x.Name == "position2").Visible == true  && backGrb.Controls.OfType<NumericUpDown>().FirstOrDefault(x => x.Name == "position2").Value != 0 && backGrb.Controls.OfType<Label>().FirstOrDefault(x => x.Name == "label8").Text == "%")
                                {
                                    textArea.SelectedText = string.Format("background-position: {0}% {1}%;\n", backGrb.Controls.OfType<NumericUpDown>().FirstOrDefault(x => x.Name == "position1").Value, backGrb.Controls.OfType<NumericUpDown>().FirstOrDefault(x => x.Name == "position2").Value);
                                }
                            }
                            if (controlSS is NumericUpDown)
                            {
                                backNud = (NumericUpDown)controlSS;
                                if (backNud.Name == "position1" && backNud.Visible == true && backNud.Value != 0 && backGrb.Controls.OfType<NumericUpDown>().FirstOrDefault(x => x.Name == "position2").Visible == true && backGrb.Controls.OfType<NumericUpDown>().FirstOrDefault(x => x.Name == "position2").Value != 0 && backGrb.Controls.OfType<Label>().FirstOrDefault(x => x.Name == "label8").Text == "px")
                                {
                                    textArea.SelectedText = string.Format("background-position: {0}px {1}px;\n", backGrb.Controls.OfType<NumericUpDown>().FirstOrDefault(x => x.Name == "position1").Value, backGrb.Controls.OfType<NumericUpDown>().FirstOrDefault(x => x.Name == "position2").Value);
                                }
                            }
                        }
                    }
                }
            }
            frm.Close();
        }
        private void sizeType_SelectedIndexChanged(object sender, EventArgs e)
        {
            var ctrl = (Control)sender;
            var frm = ctrl.FindForm();
            ComboBox msrCmb = null;
            GroupBox grobx = null;
            foreach (var ctr in frm.Controls)
            {
                if (ctr is GroupBox)
                {
                    grobx = (GroupBox)ctr;
                    if (grobx.Name == "bgImageSize")
                    {
                        foreach (Control controlSS in grobx.Controls)
                        {
                            if (controlSS is ComboBox)
                            {
                                msrCmb = (ComboBox)controlSS;
                                if (msrCmb.Name == "sizeType")
                                {
                                    int header = msrCmb.SelectedIndex;
                                    switch (header)
                                    {
                                        case 0:
                                            grobx.Controls.OfType<NumericUpDown>().FirstOrDefault(x => x.Name == "size1").Visible = false;
                                            grobx.Controls.OfType<NumericUpDown>().FirstOrDefault(x => x.Name == "size2").Visible = false;
                                            grobx.Controls.OfType<Label>().FirstOrDefault(x => x.Name == "label11").Visible = false;
                                            grobx.Controls.OfType<Label>().FirstOrDefault(x => x.Name == "label13").Visible = false;
                                            grobx.Controls.OfType<Label>().FirstOrDefault(x => x.Name == "label5").Visible = false;
                                            grobx.Height = 60;
                                            break;
                                        case 1:
                                            grobx.Controls.OfType<NumericUpDown>().FirstOrDefault(x => x.Name == "size1").Visible = false;
                                            grobx.Controls.OfType<NumericUpDown>().FirstOrDefault(x => x.Name == "size2").Visible = false;
                                            grobx.Controls.OfType<Label>().FirstOrDefault(x => x.Name == "label11").Visible = false;
                                            grobx.Controls.OfType<Label>().FirstOrDefault(x => x.Name == "label13").Visible = false;
                                            grobx.Controls.OfType<Label>().FirstOrDefault(x => x.Name == "label5").Visible = false;
                                            grobx.Height = 60;
                                            break;
                                        case 2:
                                            grobx.Controls.OfType<NumericUpDown>().FirstOrDefault(x => x.Name == "size1").Visible = false;
                                            grobx.Controls.OfType<NumericUpDown>().FirstOrDefault(x => x.Name == "size2").Visible = false;
                                            grobx.Controls.OfType<Label>().FirstOrDefault(x => x.Name == "label11").Visible = false;
                                            grobx.Controls.OfType<Label>().FirstOrDefault(x => x.Name == "label13").Visible = false;
                                            grobx.Controls.OfType<Label>().FirstOrDefault(x => x.Name == "label5").Visible = false;
                                            grobx.Height = 60;
                                            break;
                                        case 3:
                                            grobx.Controls.OfType<NumericUpDown>().FirstOrDefault(x => x.Name == "size1").Visible = true;
                                            grobx.Controls.OfType<NumericUpDown>().FirstOrDefault(x => x.Name == "size2").Visible = true;
                                            grobx.Controls.OfType<NumericUpDown>().FirstOrDefault(x => x.Name == "size1").Maximum = 100;
                                            grobx.Controls.OfType<NumericUpDown>().FirstOrDefault(x => x.Name == "size2").Maximum = 100;
                                            grobx.Controls.OfType<Label>().FirstOrDefault(x => x.Name == "label11").Visible = true;
                                            grobx.Controls.OfType<Label>().FirstOrDefault(x => x.Name == "label11").Width = 15;
                                            grobx.Controls.OfType<Label>().FirstOrDefault(x => x.Name == "label13").Width = 15;
                                            grobx.Controls.OfType<Label>().FirstOrDefault(x => x.Name == "label11").Text = "%";
                                            grobx.Controls.OfType<Label>().FirstOrDefault(x => x.Name == "label13").Text = "%";
                                            grobx.Controls.OfType<Label>().FirstOrDefault(x => x.Name == "label13").Visible = true;
                                            grobx.Controls.OfType<Label>().FirstOrDefault(x => x.Name == "label5").Visible = true;
                                            grobx.Height = 76;
                                            break;
                                        case 4:
                                            grobx.Controls.OfType<NumericUpDown>().FirstOrDefault(x => x.Name == "size1").Visible = true;
                                            grobx.Controls.OfType<NumericUpDown>().FirstOrDefault(x => x.Name == "size2").Visible = true;
                                            grobx.Controls.OfType<NumericUpDown>().FirstOrDefault(x => x.Name == "size1").Maximum = 1000;
                                            grobx.Controls.OfType<NumericUpDown>().FirstOrDefault(x => x.Name == "size2").Maximum = 1000;
                                            grobx.Controls.OfType<Label>().FirstOrDefault(x => x.Name == "label11").Visible = true;
                                            grobx.Controls.OfType<Label>().FirstOrDefault(x => x.Name == "label11").Width = 18;
                                            grobx.Controls.OfType<Label>().FirstOrDefault(x => x.Name == "label13").Width = 18;
                                            grobx.Controls.OfType<Label>().FirstOrDefault(x => x.Name == "label11").Text = "px";
                                            grobx.Controls.OfType<Label>().FirstOrDefault(x => x.Name == "label13").Text = "px";
                                            grobx.Controls.OfType<Label>().FirstOrDefault(x => x.Name == "label13").Visible = true;
                                            grobx.Controls.OfType<Label>().FirstOrDefault(x => x.Name == "label5").Visible = true;
                                            grobx.Height = 76;
                                            break;
                                        default:
                                            break;
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        private void measureTypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            var ctrl = (Control)sender;
            var frm = ctrl.FindForm();
            ComboBox msrCmb = null;
            GroupBox grobx = null;
            foreach (var ctr in frm.Controls)
            {
                if (ctr is GroupBox)
                {
                    grobx = (GroupBox)ctr;
                    if (grobx.Name == "bgImagePosition")
                    { 
                     foreach (Control controlSS in grobx.Controls)
                    {
                        if (controlSS is ComboBox)
                        {
                                msrCmb = (ComboBox)controlSS;
                                if (msrCmb.Name == "measureTypes")
                                {
                                    int header = msrCmb.SelectedIndex;
                                    switch (header)
                                    {
                                        case 0:
                                            grobx.Controls.OfType<ComboBox>().FirstOrDefault(x => x.Name == "LCR1").Visible = true;
                                            grobx.Controls.OfType<ComboBox>().FirstOrDefault(x => x.Name == "LCR2").Visible = true;
                                            grobx.Controls.OfType<NumericUpDown>().FirstOrDefault(x => x.Name == "position1").Visible = false;
                                            grobx.Controls.OfType<NumericUpDown>().FirstOrDefault(x => x.Name == "position2").Visible = false;
                                            grobx.Controls.OfType<Label>().FirstOrDefault(x => x.Name == "label8").Visible = false;
                                            grobx.Controls.OfType<Label>().FirstOrDefault(x => x.Name == "label9").Visible = false;
                                            break;
                                        case 1:
                                            grobx.Controls.OfType<ComboBox>().FirstOrDefault(x => x.Name == "LCR1").Visible = false;
                                            grobx.Controls.OfType<ComboBox>().FirstOrDefault(x => x.Name == "LCR2").Visible = false;
                                            grobx.Controls.OfType<NumericUpDown>().FirstOrDefault(x => x.Name == "position1").Visible = true;
                                            grobx.Controls.OfType<NumericUpDown>().FirstOrDefault(x => x.Name == "position2").Visible = true;
                                            grobx.Controls.OfType<NumericUpDown>().FirstOrDefault(x => x.Name == "position1").Maximum = 100;
                                            grobx.Controls.OfType<NumericUpDown>().FirstOrDefault(x => x.Name == "position2").Maximum = 100;
                                            grobx.Controls.OfType<Label>().FirstOrDefault(x => x.Name == "label8").Visible = true;
                                            grobx.Controls.OfType<Label>().FirstOrDefault(x => x.Name == "label8").Width = 15;
                                            grobx.Controls.OfType<Label>().FirstOrDefault(x => x.Name == "label9").Width = 15;
                                            grobx.Controls.OfType<Label>().FirstOrDefault(x => x.Name == "label8").Text = "%";
                                            grobx.Controls.OfType<Label>().FirstOrDefault(x => x.Name == "label9").Text = "%";
                                            grobx.Controls.OfType<Label>().FirstOrDefault(x => x.Name == "label9").Visible = true;
                                            break;
                                        case 2:
                                            grobx.Controls.OfType<ComboBox>().FirstOrDefault(x => x.Name == "LCR1").Visible = false;
                                            grobx.Controls.OfType<ComboBox>().FirstOrDefault(x => x.Name == "LCR2").Visible = false;
                                            grobx.Controls.OfType<NumericUpDown>().FirstOrDefault(x => x.Name == "position1").Visible = true;
                                            grobx.Controls.OfType<NumericUpDown>().FirstOrDefault(x => x.Name == "position2").Visible = true;
                                            grobx.Controls.OfType<NumericUpDown>().FirstOrDefault(x => x.Name == "position1").Maximum = 1000;
                                            grobx.Controls.OfType<NumericUpDown>().FirstOrDefault(x => x.Name == "position2").Maximum = 1000;
                                            grobx.Controls.OfType<Label>().FirstOrDefault(x => x.Name == "label8").Visible = true;
                                            grobx.Controls.OfType<Label>().FirstOrDefault(x => x.Name == "label8").Width = 18;
                                            grobx.Controls.OfType<Label>().FirstOrDefault(x => x.Name == "label9").Width = 18;
                                            grobx.Controls.OfType<Label>().FirstOrDefault(x => x.Name == "label8").Text = "px";
                                            grobx.Controls.OfType<Label>().FirstOrDefault(x => x.Name == "label9").Text = "px";
                                            grobx.Controls.OfType<Label>().FirstOrDefault(x => x.Name == "label9").Visible = true;
                                            break;
                                        default:
                                            break;
                                    }
                                }
                            }
                         }
                        }
                    }
                }
            }
        private void backgroundImgSelect_Click(object sender,EventArgs e)
        {
            if(imageOpen.ShowDialog() != DialogResult.Cancel)
            {
                System.IO.StreamReader OpenImage = new System.IO.StreamReader(imageOpen.FileName);
                OpenImage.Close();
                string fullpath = imageOpen.FileName;
                var ctrl = (Control)sender;
                var frm = ctrl.FindForm();
                TextBox bgTxt = null;
                foreach (var ctr in frm.Controls)
                {
                    if (ctr is TextBox)
                    {
                        bgTxt = (TextBox)ctr;
                        if (bgTxt.Name == "backgroundImgURL")
                        {
                            bgTxt.Text = fullpath;

                        }
                    }
                }
            }
        }
        private void backgroundColorSelect_Click(object sender,EventArgs e)
        {
            ColorDialog rengSech = new ColorDialog();
            if (rengSech.ShowDialog() != DialogResult.Cancel)
            {
                Color someColor = rengSech.Color;
                var ctrl = (Control)sender;
                var frm = ctrl.FindForm();
                TextBox clrTxt = null;
                foreach(var ctr in frm.Controls)
                {
                    if(ctr is TextBox)
                    {
                        clrTxt = (TextBox)ctr;
                        if(clrTxt.Name == "backgroundColor")
                        {
                            clrTxt.Text = String.Format("#{0:X2}{1:X2}{2:X2}", someColor.R, someColor.G, someColor.B);
                        }
                    }
                }
                
            }
        }
        private void backgroundCancel_Click(object sender,EventArgs e)
        {
            var ctrl = (Control)sender;
            var frm = ctrl.FindForm();
            frm.Close();
        }
        private void transparentChk_CheckedChanged(object sender, EventArgs e)
        {
            var ctrl = (Control)sender;
            var frm = ctrl.FindForm();
            TextBox bgTxt = null;
            foreach (var ctr in frm.Controls)
            {
                if (ctr is TextBox)
                {
                    bgTxt = (TextBox)ctr;
                    if (frm.Controls.OfType<CheckBox>().FirstOrDefault(y => y.Name == "transparentChk").Checked == false)
                    {
                        if(bgTxt.Name == "backgroundColor")
                        {
                            bgTxt.Enabled = true;
                        }
                        frm.Controls.OfType<Button>().FirstOrDefault(y => y.Name == "backgroundColorSelect").Enabled = true;

                    }
                    if (frm.Controls.OfType<CheckBox>().FirstOrDefault(y => y.Name == "transparentChk").Checked == true)
                    {
                        if (bgTxt.Name == "backgroundColor")
                        {
                            bgTxt.Enabled = false;
                        }
                        frm.Controls.OfType<Button>().FirstOrDefault(y => y.Name == "backgroundColorSelect").Enabled = false;
                    }
                }
            }
        }
        private void CancelBtn_Click(object sender,EventArgs e)
        {
            var ctrl = (Control)sender;
            var frm = ctrl.FindForm();
            frm.Close();
        }
        public void OKBtn_Click(object sender, EventArgs e)
        {
            
            var ctrl = (Control)sender;
            var frm = ctrl.FindForm();
            NumericUpDown nud = null;
            foreach (var ctr in frm.Controls)
            {
                if (ctr is NumericUpDown)
                {
                    nud = (NumericUpDown)ctr;
                    if (nud.Name == "top")
                    {
                        textArea.SelectionLength = 0;
                        textArea.SelectedText = string.Format("margin-top: {0}% ; \n", nud.Value);
                    }
                    else
                        if (nud.Name == "bottom")
                    {
                        textArea.SelectionLength = 0;
                        textArea.SelectedText = string.Format("margin-bottom: {0}% ; \n", nud.Value);
                    }
                    else
                        if(nud.Name == "left")
                    {
                        textArea.SelectionLength = 0;
                        textArea.SelectedText = string.Format("margin-left: {0}% ; \n", nud.Value);
                    }
                    else
                        if(nud.Name == "right")
                    {
                        textArea.SelectionLength = 0;
                        textArea.SelectedText = string.Format("margin-right: {0}% ; \n", nud.Value);
                    }
                }
            }
                frm.Close();
        }
        private void setFont_Click(object sender,EventArgs e)
        {
            FontDialog font = new FontDialog();
            font.ShowEffects = true;
            if (font.ShowDialog() == DialogResult.OK)
            {
                textArea.SelectedText = string.Format("font-family: '{0}' ;\n", font.Font.Name);
                textArea.SelectedText = string.Format("font-size: {0}pt ;\n", font.Font.Size);
            }
        }
        private void setColor_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.ColorDialog rengSech = new ColorDialog();
            rengSech.ShowHelp = true;
            if (rengSech.ShowDialog() != DialogResult.Cancel)
            {
                Color someColor = rengSech.Color;
                textArea.SelectionLength = 0;
                textArea.SelectedText = "color: "+ String.Format("#{0:X2}{1:X2}{2:X2} ;\n", someColor.R, someColor.G, someColor.B);
            }
        }
        private void commentBtn_Click(object sender, EventArgs e)
        {
            textArea.SelectionLength = 0;
            textArea.SelectedText = "<!-- -->";
        }
        private void sitatBtn_Click(object sender, EventArgs e)
        {
            textArea.SelectionLength = 0;
            textArea.SelectedText = "<q> </q>";
        }
        private void scriptBtn_Click(object sender, EventArgs e)
        {
            textArea.SelectionLength = 0;
            textArea.SelectedText = "<script type=\"text/javascript\""+"> "+ "</script>";
        }
        private void imgOK_Click(object sender,EventArgs e)
        {
            textArea.SelectionLength = 0;
            textArea.SelectedText = "<img ";

            var ctrl = (Control)sender;
            var frm = ctrl.FindForm();
            RichTextBox imgRTB = null;
            NumericUpDown imgNUD = null;
            CheckBox imgCHCK = null;
            TextBox imgTXT = null;

            foreach (var ctr in frm.Controls)
            {

                if (ctr is RichTextBox)
                {
                    imgRTB = (RichTextBox)ctr;
                    if (imgRTB.Name == "imgURL")
                    {
                        textArea.SelectedText = string.Format("src=\"{0}\" ", imgRTB.Text);
                    }
                }
                if (ctr is TextBox)
                {
                    imgTXT = (TextBox)ctr;
                    if (imgTXT.Name == "altNameVal")
                    {
                        textArea.SelectedText = string.Format("alt=\"{0}\" ",imgTXT.Text);
                    }
                    else
                        if(imgTXT.Name == "mapIDVal" && imgTXT.Text != "")
                    {
                        textArea.SelectedText = string.Format("usemap=\"#{0}\" ", imgTXT.Text);
                    }
                }
                
                if (ctr is NumericUpDown)
                {
                    imgNUD = (NumericUpDown)ctr;
                    if (imgNUD.Name == "imgWidthVal" && imgNUD.Value != 0)
                    {
                        textArea.SelectedText = string.Format("width=\"{0}\" ",imgNUD.Value);
                    }
                    else
                        if(imgNUD.Name =="imgHeightVal" && imgNUD.Value != 0)
                    {
                        textArea.SelectedText = string.Format("height=\"{0}\" ", imgNUD.Value);
                    }
                }
                if (ctr is CheckBox)
                {
                    imgCHCK = (CheckBox)ctr;
                    if (imgCHCK.Name == "isMapCheck"&& imgCHCK.Checked)
                    {
                        textArea.SelectedText = "ismap ";
                    }
                }
            }
            frm.Close();
            textArea.SelectedText = ">\n";
        }
        private void imgCancel_Click(object sender,EventArgs e)
        {
            var ctrl = (Control)sender;
            var frm = ctrl.FindForm();
            frm.Close();
        }
        private void imgSelect_Click(object sender,EventArgs e)
        {
            if (imageOpen.ShowDialog() != DialogResult.Cancel)
            {
                System.IO.StreamReader OpenImage = new System.IO.StreamReader(imageOpen.FileName);
                string fullpath = imageOpen.FileName;
                var ctrl = (Control)sender;
                var frm = ctrl.FindForm();
                RichTextBox imgrtb = null;
                foreach (var ctr in frm.Controls)
                {
                    if (ctr is RichTextBox)
                    {
                        imgrtb = (RichTextBox)ctr;
                        if (imgrtb.Name == "imgURL")
                        {
                            imgrtb.Text = fullpath;

                        }
                    }
                }
                OpenImage.Close();
            }
        }
        private void createHtmlTSMI_Click(object sender, EventArgs e)
        {
            htmlTemplate();
         }
        private void createPhpTSMI_Click(object sender, EventArgs e)
        {
            phpTemplate();
        }
        private void audioCancel_Click(object sender,EventArgs e)
        {
            var ctrl = (Control)sender;
            var frm = ctrl.FindForm();
            frm.Close();
        }
        private void selectAUDIO_Click(object sender,EventArgs e)
        {
            OpenFileDialog selectAudio = new OpenFileDialog();
            selectAudio.Filter = "MP3 files (*.mp3)|*.mp3|WAV files (*.wav)|*.wav|OGG files (*.ogg)|*.ogg|AAC files (*.aac)|*.aac";
            if(selectAudio.ShowDialog() != DialogResult.Cancel)
            { 
                System.IO.StreamReader OpenFile = new System.IO.StreamReader(selectAudio.FileName);
                OpenFile.Close();
                string fullpath = selectAudio.FileName;
                var ctrl = (Control)sender;
                var frm = ctrl.FindForm();
                RichTextBox audiotext = null;
                foreach (var ctr in frm.Controls)
                {
                    if (ctr is RichTextBox)
                    {
                        audiotext = (RichTextBox)ctr;
                        if (audiotext.Name == "audioURL")
                        {
                            audiotext.Text = fullpath;
                        
                        }
                    }
                }
            }
        }
        private void audioOK_Click(object sender,EventArgs e)
        {
            textArea.SelectionLength = 0;
            textArea.SelectedText = "<audio controls";
            var ctrl = (Control)sender;
            var frm = ctrl.FindForm();
            RichTextBox sometext = null;
            CheckBox somecheck = null;
            foreach (var ctr in frm.Controls)
            {
                if (ctr is CheckBox)
                {
                    somecheck = (CheckBox)ctr;
                    if (somecheck.Name == "autoStart" && somecheck.Checked)
                    {
                        textArea.SelectionLength = 0;
                        textArea.SelectedText = " autoplay";

                    }
                    else 
                        if(somecheck.Name =="loop" && somecheck.Checked)
                    {
                        textArea.SelectionLength = 0;
                        textArea.SelectedText = " loop ";
                    }
                }
               
            }
            textArea.SelectionLength = 0;
            textArea.SelectedText = ">\n";
            foreach (var ctr in frm.Controls)
            {
                if (ctr is RichTextBox)
                {
                    sometext = (RichTextBox)ctr;
                    if (sometext.Name == "audioURL")
                    {
                        if (sometext.Find(".mp3") != -1)
                        {
                            textArea.SelectionLength = 0;
                            textArea.SelectedText = string.Format("<source src=\"{0}\" type=\"audio/mpeg\"> \n", sometext.Text);
                        }
                        else
                            if (sometext.Find(".ogg") != -1)
                        {
                            textArea.SelectionLength = 0;
                            textArea.SelectedText = string.Format("<source src=\"{0}\" type=\"audio/ogg ; codecs=vorbis\"> \n", sometext.Text);
                        }
                        else
                            if (sometext.Find(".aac") != -1)
                        {
                            textArea.SelectionLength = 0;
                            textArea.SelectedText = string.Format("<source src=\"{0}\" type=\"video/mp4\"> \n", sometext.Text);
                        }
                        else
                            if (sometext.Find(".wav") != -1)
                        {
                            textArea.SelectionLength = 0;
                            textArea.SelectedText = string.Format("<source src=\"{0}\" type=\"audio/wav\"> \n", sometext.Text);
                        }
                    }
                }
            }
            frm.Close();
            textArea.SelectionLength = 0;
            textArea.SelectedText = "</audio>\n";
        }
        private void xettBtn_Click(object sender, EventArgs e)
        {
            textArea.SelectionLength = 0;
            textArea.SelectedText = "<hr>\n";
        }
        private void linkCancel_Click(object sender,EventArgs e)
        {
            var ctrl = (Control)sender;
            var frm = ctrl.FindForm();
            frm.Close();
        }
        private void linkOK_Click(object sender, EventArgs e)
        {
            textArea.SelectionLength = 0;
            textArea.SelectedText = "<a href=";
            var ctrl = (Control)sender;
            var frm = ctrl.FindForm();
            TextBox linktext = null;

            foreach (var ctr in frm.Controls)
            {
                if (ctr is TextBox)
                {
                    linktext = (TextBox)ctr;
                    if (linktext.Name == "linkVal")
                    {
                        textArea.SelectedText = string.Format("\"http://{0}/\">", linktext.Text);
                    }
                    if (linktext.Name == "NameVal")
                    {
                        textArea.SelectedText = string.Format("{0}",linktext.Text);
                    }
                }
            }
            frm.Close();
            textArea.SelectionLength = 0;
            textArea.SelectedText = "</a>\n";
        }
        private void blackBgTSMI_Click(object sender, EventArgs e)
        {
            textArea.BackColor = Color.Black;
            textArea.ForeColor = Color.White;
            fileToolStripMenuItem1.ForeColor = System.Drawing.Color.DarkGray;
            yeniTSMI.BackColor= System.Drawing.Color.Black;
            yeniTSMI.ForeColor = System.Drawing.Color.DarkGray;
            createHtmlTSMI.BackColor = System.Drawing.Color.Black;
            createHtmlTSMI.ForeColor = System.Drawing.Color.DarkGray;
            createCssTSMI.BackColor = System.Drawing.Color.Black;
            createCssTSMI.ForeColor = System.Drawing.Color.DarkGray;
            createPhpTSMI.BackColor = System.Drawing.Color.Black;
            createPhpTSMI.ForeColor = System.Drawing.Color.DarkGray;
            achTSMI.BackColor = System.Drawing.Color.Black;
            achTSMI.ForeColor = System.Drawing.Color.DarkGray;
            yaddashTSMI.BackColor = System.Drawing.Color.Black;
            yaddashTSMI.ForeColor = System.Drawing.Color.DarkGray;
            chapTSMI.BackColor = System.Drawing.Color.Black;
            chapTSMI.ForeColor = System.Drawing.Color.DarkGray;
            chixishTSMI.BackColor = System.Drawing.Color.Black;
            chixishTSMI.ForeColor = System.Drawing.Color.DarkGray;
            editToolStripMenuItem.ForeColor = System.Drawing.Color.DarkGray;
            geriTSMI.BackColor = System.Drawing.Color.Black;
            geriTSMI.ForeColor = System.Drawing.Color.DarkGray;
            ireliTSMI.BackColor = System.Drawing.Color.Black;
            ireliTSMI.ForeColor = System.Drawing.Color.DarkGray;
            kesTSMI.BackColor = System.Drawing.Color.Black;
            kesTSMI.ForeColor = System.Drawing.Color.DarkGray;
            kopyalaTSMI.BackColor = System.Drawing.Color.Black;
            kopyalaTSMI.ForeColor = System.Drawing.Color.DarkGray;
            daxilTSMI.BackColor = System.Drawing.Color.Black;
            daxilTSMI.ForeColor = System.Drawing.Color.DarkGray;
            hamsiTSMI.BackColor = System.Drawing.Color.Black;
            hamsiTSMI.ForeColor = System.Drawing.Color.DarkGray;
            toolsToolStripMenuItem.ForeColor = System.Drawing.Color.DarkGray;
            deyishTSMI.BackColor = System.Drawing.Color.Black;
            deyishTSMI.ForeColor = System.Drawing.Color.DarkGray;
            secenekTSMI.BackColor = System.Drawing.Color.Black;
            secenekTSMI.ForeColor = System.Drawing.Color.DarkGray;
            setirTSMİ.BackColor = System.Drawing.Color.Black;
            setirTSMİ.ForeColor = System.Drawing.Color.DarkGray;
            bgColorTSMI.BackColor = System.Drawing.Color.Black;
            bgColorTSMI.ForeColor = System.Drawing.Color.DarkGray;
            blackBgTSMI.BackColor = System.Drawing.Color.Black;
            blackBgTSMI.ForeColor = System.Drawing.Color.DarkGray;
            whiteBgTSMI.BackColor = System.Drawing.Color.Black;
            whiteBgTSMI.ForeColor = System.Drawing.Color.DarkGray;
            helpToolStripMenuItem.ForeColor = System.Drawing.Color.DarkGray;
            haqqindaTSMI.BackColor = System.Drawing.Color.Black;
            haqqindaTSMI.ForeColor = System.Drawing.Color.DarkGray;
            əlaqəToolStripMenuItem.BackColor = System.Drawing.Color.Black;
            əlaqəToolStripMenuItem.ForeColor = System.Drawing.Color.DarkGray;

            var ctrl = (Control)this;
            var frm = ctrl.FindForm();
            Label label = null;
            foreach (var ctr in frm.Controls)
            {
                if (ctr is Label)
                {
                    label = (Label)ctr;
                    if (label.Name == "label1")
                    {
                        label.ForeColor = System.Drawing.Color.DarkGray;
                    }
                    else
                        if (label.Name == "lists")
                    {
                        label.ForeColor = System.Drawing.Color.DarkGray;
                    }
                    else
                        if (label.Name == "label2")
                    {
                        label.ForeColor = System.Drawing.Color.DarkGray;
                    }
                    else
                        if (label.Name == "label3")
                    {
                        label.ForeColor = System.Drawing.Color.DarkGray;
                    }
                    else
                        if (label.Name == "label4")
                    {
                        label.ForeColor = System.Drawing.Color.DarkGray;
                    }
                    else
                        if (label.Name == "label6")
                    {
                        label.ForeColor = System.Drawing.Color.DarkGray;
                    }
                }
            }
            
            this.BackgroundImage = global::Loxie.Properties.Resources.oavv3DC;
            this.menuStrip1.BackgroundImage = global::Loxie.Properties.Resources.oavv3DC;
        }
        private void whiteBgTSMI_Click(object sender, EventArgs e)
        {
            textArea.BackColor = Color.White;
            textArea.ForeColor = Color.Black;
            this.BackgroundImage = global::Loxie.Properties.Resources._2Nrxex6;
            this.menuStrip1.BackgroundImage = global::Loxie.Properties.Resources._2Nrxex6;
            fileToolStripMenuItem1.ForeColor = System.Drawing.Color.Black;
            yeniTSMI.BackColor = System.Drawing.Color.Transparent;
            yeniTSMI.ForeColor = System.Drawing.Color.Black;
            createHtmlTSMI.BackColor = System.Drawing.Color.Transparent;
            createHtmlTSMI.ForeColor = System.Drawing.Color.Black;
            createPhpTSMI.BackColor = System.Drawing.Color.Transparent;
            createPhpTSMI.ForeColor = System.Drawing.Color.Black;
            createCssTSMI.BackColor = System.Drawing.Color.Transparent;
            createCssTSMI.ForeColor = System.Drawing.Color.Black;
            achTSMI.BackColor = System.Drawing.Color.Transparent;
            achTSMI.ForeColor = System.Drawing.Color.Black;
            yaddashTSMI.BackColor = System.Drawing.Color.Transparent;
            yaddashTSMI.ForeColor = System.Drawing.Color.Black;
            chapTSMI.BackColor = System.Drawing.Color.Transparent;
            chapTSMI.ForeColor = System.Drawing.Color.Black;
            chixishTSMI.BackColor = System.Drawing.Color.Transparent;
            chixishTSMI.ForeColor = System.Drawing.Color.Black;
            editToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            geriTSMI.BackColor = System.Drawing.Color.Transparent;
            geriTSMI.ForeColor = System.Drawing.Color.Black;
            ireliTSMI.BackColor = System.Drawing.Color.Transparent;
            ireliTSMI.ForeColor = System.Drawing.Color.Black;
            kesTSMI.BackColor = System.Drawing.Color.Transparent;
            kesTSMI.ForeColor = System.Drawing.Color.Black;
            kopyalaTSMI.BackColor = System.Drawing.Color.Transparent;
            kopyalaTSMI.ForeColor = System.Drawing.Color.Black;
            daxilTSMI.BackColor = System.Drawing.Color.Transparent;
            daxilTSMI.ForeColor = System.Drawing.Color.Black;
            hamsiTSMI.BackColor = System.Drawing.Color.Transparent;
            hamsiTSMI.ForeColor = System.Drawing.Color.Black;
            toolsToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            deyishTSMI.BackColor = System.Drawing.Color.Transparent;
            deyishTSMI.ForeColor = System.Drawing.Color.Black;
            secenekTSMI.BackColor = System.Drawing.Color.Transparent;
            secenekTSMI.ForeColor = System.Drawing.Color.Black;
            setirTSMİ.BackColor = System.Drawing.Color.Transparent;
            setirTSMİ.ForeColor = System.Drawing.Color.Black;
            bgColorTSMI.BackColor = System.Drawing.Color.Transparent;
            bgColorTSMI.ForeColor = System.Drawing.Color.Black;
            blackBgTSMI.BackColor = System.Drawing.Color.Transparent;
            blackBgTSMI.ForeColor = System.Drawing.Color.Black;
            whiteBgTSMI.BackColor = System.Drawing.Color.Transparent;
            whiteBgTSMI.ForeColor = System.Drawing.Color.Black;
            helpToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            haqqindaTSMI.BackColor = System.Drawing.Color.Transparent;
            haqqindaTSMI.ForeColor = System.Drawing.Color.Black;
            əlaqəToolStripMenuItem.BackColor = System.Drawing.Color.Transparent;
            əlaqəToolStripMenuItem.ForeColor = System.Drawing.Color.Black;

            var ctrl = (Control)this;
            var frm = ctrl.FindForm();
            Label label = null;
            foreach (var ctr in frm.Controls)
            {
                if (ctr is Label)
                {
                    label = (Label)ctr;
                    if (label.Name == "label1")
                    {
                        label.ForeColor = System.Drawing.Color.Black;
                    }
                    else
                        if (label.Name == "lists")
                    {
                        label.ForeColor = System.Drawing.Color.Black;
                    }
                    else
                        if (label.Name == "label2")
                    {
                        label.ForeColor = System.Drawing.Color.Black;
                    }
                    else
                        if (label.Name == "label3")
                    {
                        label.ForeColor = System.Drawing.Color.Black;
                    }
                    else
                        if (label.Name == "label4")
                    {
                        label.ForeColor = System.Drawing.Color.Black;
                    }
                    else
                        if (label.Name == "label6")
                    {
                        label.ForeColor = System.Drawing.Color.Black;
                    }
                }
            }

         }
        private void subBtn_Click(object sender, EventArgs e)
        {
            textArea.SelectedText = string.Format("<sub>{0}</sub> \n", textArea.SelectedText);
        }
        private void supBtn_Click(object sender, EventArgs e)
        {
            textArea.SelectedText = string.Format("<sup>{0}</sup> \n",textArea.SelectedText);
        }
        private void cSSFaylToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cssTemplate();
        }
        private void newEntry_Click(object sender, EventArgs e)
        {
            textArea.AppendText("\t{\n\n}\n"); 
        }
        private void textArea_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (listShow2 == true)
            {
                keyword2 += e.KeyChar;
                count++;
                Point point = this.textArea.GetPositionFromCharIndex(textArea.SelectionStart);
                point.Y += (int)Math.Ceiling(this.textArea.Font.GetHeight()) + 190; //13 is the .y postion of the richtectbox
                point.X += 10; //105 is the .x postion of the richtectbox
                listBox2.Location = point;
                listBox2.Show();
                listBox2.SelectedIndex = 0;
                listBox2.SelectedIndex = listBox2.FindString(keyword2);
            }
            if (listShow1 == true)
            {
                keyword1 += e.KeyChar;
                count++;
                Point point = this.textArea.GetPositionFromCharIndex(textArea.SelectionStart);
                point.Y += (int)Math.Ceiling(this.textArea.Font.GetHeight()) + 190; //13 is the .y postion of the richtectbox
                point.X += 10; //105 is the .x postion of the richtectbox
                listBox1.Location = point;
                listBox1.Show();
                listBox1.SelectedIndex = 0;
                listBox1.SelectedIndex = listBox1.FindString(keyword1);
            }
            if (e.KeyChar == ':')
            {
                int i1 = textArea.SelectionStart;
                if (textArea.Find("<?php") == 0 || textArea.Find("<html>") == 0)
                {
                    textArea.DeselectAll();
                    textArea.SelectionStart = i1;
                }
                else
                {
                    listShow1 = true;
                    listBox1.Focus();
                    Point point = this.textArea.GetPositionFromCharIndex(textArea.SelectionStart);
                    point.Y += (int)Math.Ceiling(this.textArea.Font.GetHeight()) + 190; //13 is the .y postion of the richtectbox
                    point.X += 10; //105 is the .x postion of the richtectbox
                    listBox1.Location = point;
                    count++;
                    listBox1.Show();
                    listBox1.SelectedIndex = 0;
                    listBox1.SelectedIndex = listBox1.FindString(keyword1);
                }
                
            }
            if (e.KeyChar == '@')
            {
                int i2 = textArea.SelectionStart;
                if (textArea.Find("<?php") == 0 || textArea.Find("<html>") == 0)
                {
                    textArea.DeselectAll();
                    textArea.SelectionStart = i2;
                }
                else
                {
                    listShow2 = true;
                    listBox2.Focus();
                    Point point = this.textArea.GetPositionFromCharIndex(textArea.SelectionStart);
                    point.Y += (int)Math.Ceiling(this.textArea.Font.GetHeight()) + 190; //13 is the .y postion of the richtectbox
                    point.X += 10; //105 is the .x postion of the richtectbox
                    listBox2.Location = point;
                    count++;
                    listBox2.Show();
                    listBox2.SelectedIndex = 0;
                }
            }
        }
        private void textArea_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                count = 0;
                keyword1 = ":";
                keyword2 = "@";
                listShow1 = false;
                listShow2 = false;
                listBox1.Hide();
                listBox2.Hide();
            }
            if (e.KeyCode == Keys.Back)
            {
                count = 0;
                keyword1 = ":";
                keyword2 = "@";
                listShow1 = false;
                listShow2 = false;
                listBox1.Hide();
                listBox2.Hide();
            }
            if (e.KeyCode == Keys.Space)
            {
                count = 0;
                keyword1 = ":";
                keyword2 = "@";
                listShow1 = false;
                listShow2 = false;
                listBox1.Hide();
                listBox2.Hide();
            }
            if (listShow2==true)
            {
                listBox2.Focus();
                if (e.KeyCode == Keys.Up)
                {
                    listBox2.Focus();
                    if (listBox2.SelectedIndex != 0)
                    {
                        listBox2.SelectedIndex -= 1;
                    }
                    else
                    {
                        listBox2.SelectedIndex = 0;
                    }
                }
                else if (e.KeyCode == Keys.Down)
                {
                    listBox2.Focus();
                    try
                    {
                        listBox2.SelectedIndex += 1;
                    }
                    catch
                    {
                    }
                }

                if (e.KeyCode == Keys.Tab)
                {
                    string autoText2 = listBox2.SelectedItem.ToString();
                    int beginPlace = textArea.SelectionStart - count;
                    textArea.Select(beginPlace, count);
                    textArea.SelectedText = "";
                    textArea.Text += autoText2;
                    textArea.Focus();
                    listShow2 = false;
                    listBox2.Hide();
                    int endPlace = autoText2.Length + beginPlace;
                    textArea.SelectionStart = endPlace;
                    count = 0;
                }
            }
            if (listShow1 == true)
            {
                listBox1.Focus();
                if (e.KeyCode == Keys.Up)
                {
                    listBox1.Focus();
                    if (listBox1.SelectedIndex != 0)
                    {
                        listBox1.SelectedIndex -= 1;
                    }
                    else
                    {
                        listBox1.SelectedIndex = 0;
                    }
                }
                else if (e.KeyCode == Keys.Down)
                {
                    listBox1.Focus();
                    try
                    {
                        listBox1.SelectedIndex += 1;
                    }
                    catch
                    {
                    }
                }

                if (e.KeyCode == Keys.Tab)
                {
                    string autoText1 = listBox1.SelectedItem.ToString();
                    int beginPlace = textArea.SelectionStart - count;
                    textArea.Select(beginPlace, count);
                    textArea.SelectedText = "";
                    textArea.Text += autoText1;
                    textArea.Focus();
                    listShow1 = false;
                    listBox1.Hide();
                    int endPlace = autoText1.Length + beginPlace;
                    textArea.SelectionStart = endPlace;
                    count = 0;
                }
            }
        }
        private void listBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string autoText = listBox1.SelectedItem.ToString();
                int beginPlace = textArea.SelectionStart - count;
                textArea.Select(beginPlace, count);
                textArea.SelectedText = "";
                textArea.SelectedText += ":"+autoText;
                listShow1 = false;
                listBox1.Hide();
                int endPlace = autoText.Length + beginPlace;
                textArea.SelectionStart = endPlace;
                count = 0;
            }
        }
        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            string autoText = listBox1.SelectedItem.ToString();
            int beginPlace = textArea.SelectionStart - count;
            textArea.Select(beginPlace, count);
            textArea.SelectedText = "";
            textArea.SelectedText += ":" + autoText;
            listShow1 = false;
            listBox1.Hide();
            int endPlace = autoText.Length + beginPlace;
            textArea.SelectionStart = endPlace;
            count = 0;
        }
        private void listBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string autoText2 = listBox2.SelectedItem.ToString();
                int beginPlace = textArea.SelectionStart - count;
                textArea.Select(beginPlace, count);
                textArea.SelectedText = "";
                textArea.SelectedText += "@" + autoText2;
                listShow2 = false;
                listBox2.Hide();
                int endPlace = autoText2.Length + beginPlace;
                textArea.SelectionStart = endPlace;
                count = 0;
            }
        }
        private void listBox2_DoubleClick(object sender, EventArgs e)
        {
            string autoText2 = listBox2.SelectedItem.ToString();
            int beginPlace = textArea.SelectionStart - count;
            textArea.Select(beginPlace, count);
            textArea.SelectedText = "";
            textArea.SelectedText += "@" + autoText2;
            listShow2 = false;
            listBox2.Hide();
            int endPlace = autoText2.Length + beginPlace;
            textArea.SelectionStart = endPlace;
            count = 0;
        }

        private void loadStyleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog style_open = new OpenFileDialog();
            style_open.Filter = ("CSS Files | *.css");
            style_open.Title = "Select style files";
            if (style_open.ShowDialog() != DialogResult.Cancel)
            {
                System.IO.StreamReader OpenFile = new System.IO.StreamReader(style_open.FileName);
                string loadstyle = style_open.FileName;
                if (textArea.Find("<head>") != -1)
                {
                    textArea.DeselectAll();
                    StringBuilder sb1 = new StringBuilder("<head>");
                    sb1.Insert(6, string.Format("\n<link rel=\"stylesheet\" href=\"{0}\">", loadstyle));
                    textArea.SelectedText = sb1.ToString();
                }
            }
        }

        //=========================================Button Clicks===============================================//

    }
}