using System;
using System.Net.Http;
using System.Threading;
using System.Windows.Forms;
using DAL;
using System.IO;
using AngleSharp.Html.Parser;
using AngleSharp.Html.Dom;
using System.Collections.Generic;
using AngleSharp.Dom;
using AngleSharp.Text;
using System.Linq;
using System.Text;
using ADO;
using HtmlAgilityPack;
using System.Net;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        
        public static string searchLine = "https://shop.super-pharm.co.il/cosmetics/facial-makeup/makeup/c/20181100";
        //  Class2 class2 = new Class2();
        public static Material material = new Material();
        public Form1()
        {

            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var r = ScrapeWebsite();
        }
        //פונקציה שלוקחת את הלינק של האתר שאותו היא צריכה להוריד ומורידה את הדף
        public static async Task<List<string>> ScrapeWebsite()
        {
            CancellationTokenSource cancellationToken = new CancellationTokenSource();
            HttpClient httpClient = new HttpClient();
            var request = Task.Run(() => httpClient.GetAsync(searchLine));
            cancellationToken.Token.ThrowIfCancellationRequested();

            Stream response = await request.Result.Content.ReadAsStreamAsync();
            cancellationToken.Token.ThrowIfCancellationRequested();

            HtmlParser parser = new HtmlParser();
            IHtmlDocument document = parser.ParseDocument(response);

            return GetScrapeResults(document);

        }
        public static List<string> GetScrapeResults(IHtmlDocument document)
        {
           //מביא את כל האלמנטים שמכילים את המייקאפ עפ"י שם האלמט
           //במקרה הזה לקחתי רק את הראשון כדי שיהיה לי קל לסנן את כל הפרטםי שאני צריכה
           // את הפשוט תצטרכי לעשות לולאה על כל מה שנכנס ולחלץ מהם את הפרטים
           var articleLink = document.All.Where(x => x.ClassName == "title-wrap").ToList()[0];
            //הפכתי את התוכן של האלמנט שיצא לי בתור טסקט ומכאן משתמשים בפונקציות לניתוח טקסט
                var b = articleLink.InnerHtml.ToString();
                var detials = b.Split('>');

        //מחלצת את השם של חברת המייקאפ, המחיר העכשווי, המחיר הקודם וכו... 
                material.nameCOmpany = detials[2].Replace("</h4", " ").ToString();
                material.discraption = detials[4].Replace("</p", " ").ToString();
                material.mil = detials[7].Replace("</span", " ");
                material.oldPrice = detials[36].Replace("</span", " ");
                material.price = detials[44].Replace("</span", " ");

            // את צריכה לחלץ גם את הינק שיוביל אותך לדף הבא וזה קצת מסובך
            //תדברי איתי מחר אני יגיד לך איך ניסיתי שתשבי על זה עוד ותנסי לעשות
            //אם יהיה לי זמן אני גם ינסה :)
            MessageBox.Show("חברה :" + " " + material.nameCOmpany);

            MessageBox.Show( "מחיר קודם: " + "" + material.oldPrice , "מחיר עכשו :  " + " " + material.price);

            MessageBox.Show(  "סוג  המייקאפ : " + material.discraption);

            
            return null;
        }

       
    }
}

