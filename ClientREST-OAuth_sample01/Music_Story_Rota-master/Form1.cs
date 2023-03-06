using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Net.Http.Json;
using OAuth;
using System.Windows.Forms;
using System.Diagnostics;
using RestSharp;
using RestSharp.Authenticators;
using RestSharp.Serializers.Xml;

namespace Music_Story_Rota
{
    public partial class Form1 : Form
    {
        private HTTPClient Client = new HTTPClient("http://api.music-story.com");
        public Form1()
        {
            InitializeComponent();

        }
        private void button1_Click(object sender, EventArgs e)
        {
            
            string ConsumerKey = "a406b97e8c4536f215d8610e5aed3e36c0825cca";
            string ConsumerSecret = "d4558644cdb6e8db2287627751bfa7e9eea577ed";
            string AccessToken = "1afcbd4add8503ab72afa2068957cfab4df2bbbc";
            string TokenSecret = "4e42f541ce1a634e26ca8590ccc778d75d281b7e";

            string baseURL = "http://api.music-story.com/artist/";
            string getSubURL = "search?name=Bob Marley";
        
            System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12;
            var client = new RestClient(baseURL);
            client.Authenticator = OAuth1Authenticator.ForAccessToken(ConsumerKey, ConsumerSecret, AccessToken, TokenSecret, RestSharp.Authenticators.OAuth.OAuthSignatureMethod.HmacSha1);
            var request = new RestRequest(getSubURL, Method.Get);

       
            RestResponse response = client.Execute(request);

            //visualizzo la risposta raw
            MessageBox.Show(response.Content);

            //trasformo la risposta in oggetto della classe root
            //creata a immagine e somiglianza dell'XML restituito
            //secondo le classi definite
            var dotNetXmlDeserializer = new DotNetXmlDeserializer();
            root risposta =
             dotNetXmlDeserializer.Deserialize<root>(response);

            MessageBox.Show(risposta.count+"");



        }
    }
    public class HTTPClient
    {
        static RestClient http;
        private string URL;
        private string ConsumerKey;
        private string ConsumerSecret;
        private string AccessToken;
        private string TokenSecret;
        private OAuth1Authenticator sign;

        public HTTPClient(string URL)
        {
            http = new RestClient();
            this.URL = URL;
            ConsumerKey = "a406b97e8c4536f215d8610e5aed3e36c0825cca";
            ConsumerSecret = "d4558644cdb6e8db2287627751bfa7e9eea577ed";
            AccessToken = "1afcbd4add8503ab72afa2068957cfab4df2bbbc";
            TokenSecret = "4e42f541ce1a634e26ca8590ccc778d75d281b7e";
            sign = OAuth1Authenticator.ForProtectedResource(ConsumerKey, ConsumerSecret, AccessToken, TokenSecret);

        }
        
    }


    // NOTA: con il codice generato potrebbe essere richiesto almeno .NET Framework 4.5 o .NET Core/Standard 2.0.
    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class root
    {

        private decimal versionField;

        private byte codeField;

        private byte countField;

        private byte pageCountField;

        private byte currentPageField;

        private rootItem[] dataField;

        /// <remarks/>
        public decimal version
        {
            get
            {
                return this.versionField;
            }
            set
            {
                this.versionField = value;
            }
        }

        /// <remarks/>
        public byte code
        {
            get
            {
                return this.codeField;
            }
            set
            {
                this.codeField = value;
            }
        }

        /// <remarks/>
        public byte count
        {
            get
            {
                return this.countField;
            }
            set
            {
                this.countField = value;
            }
        }

        /// <remarks/>
        public byte pageCount
        {
            get
            {
                return this.pageCountField;
            }
            set
            {
                this.pageCountField = value;
            }
        }

        /// <remarks/>
        public byte currentPage
        {
            get
            {
                return this.currentPageField;
            }
            set
            {
                this.currentPageField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("item", IsNullable = false)]
        public rootItem[] data
        {
            get
            {
                return this.dataField;
            }
            set
            {
                this.dataField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class rootItem
    {

        private uint idField;

        private string nameField;

        private object ipiField;

        private string typeField;

        private string urlField;

        private string firstnameField;

        private string lastnameField;

        private byte coeff_actuField;

        private string update_dateField;

        private string creation_dateField;

        private rootItemSearch_scores search_scoresField;

        /// <remarks/>
        public uint id
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }

        /// <remarks/>
        public string name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

        /// <remarks/>
        public object ipi
        {
            get
            {
                return this.ipiField;
            }
            set
            {
                this.ipiField = value;
            }
        }

        /// <remarks/>
        public string type
        {
            get
            {
                return this.typeField;
            }
            set
            {
                this.typeField = value;
            }
        }

        /// <remarks/>
        public string url
        {
            get
            {
                return this.urlField;
            }
            set
            {
                this.urlField = value;
            }
        }

        /// <remarks/>
        public string firstname
        {
            get
            {
                return this.firstnameField;
            }
            set
            {
                this.firstnameField = value;
            }
        }

        /// <remarks/>
        public string lastname
        {
            get
            {
                return this.lastnameField;
            }
            set
            {
                this.lastnameField = value;
            }
        }

        /// <remarks/>
        public byte coeff_actu
        {
            get
            {
                return this.coeff_actuField;
            }
            set
            {
                this.coeff_actuField = value;
            }
        }

        /// <remarks/>
        public string update_date
        {
            get
            {
                return this.update_dateField;
            }
            set
            {
                this.update_dateField = value;
            }
        }

        /// <remarks/>
        public string creation_date
        {
            get
            {
                return this.creation_dateField;
            }
            set
            {
                this.creation_dateField = value;
            }
        }

        /// <remarks/>
        public rootItemSearch_scores search_scores
        {
            get
            {
                return this.search_scoresField;
            }
            set
            {
                this.search_scoresField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class rootItemSearch_scores
    {

        private byte nameField;

        /// <remarks/>
        public byte name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }
    }



}
