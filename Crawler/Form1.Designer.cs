namespace Crawler
{
    public partial class Form1 : Form
    {
        String Rstring;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            WebRequest myWebRequest;
            WebResponse myWebResponse;
            String URL = textBox1.Text;

            myWebRequest = WebRequest.Create(URL);
            myWebResponse = myWebRequest.GetResponse();//Returns a response from an Internet resource

            Stream streamResponse = myWebResponse.GetResponseStream();//return the data stream from the internet
                                                                      //and save it in the stream

            StreamReader sreader = new StreamReader(streamResponse);//reads the data stream
            Rstring = sreader.ReadToEnd();//reads it to the end
            String Links = GetContent(Rstring);//gets the links only

            textBox2.Text = Rstring;
            textBox3.Text = Links;
            streamResponse.Close();
            sreader.Close();
            myWebResponse.Close();




        }

        private String GetContent(String Rstring)
        {
            String sString = "";
            HTMLDocument d = new HTMLDocument();
            IHTMLDocument2 doc = (IHTMLDocument2)d;
            doc.write(Rstring);

            IHTMLElementCollection L = doc.links;

            foreach (IHTMLElement links in L)
            {
                sString += links.getAttribute("href", 0);
                sString += "/n";
            }
            return sString;
        }
    }
}

