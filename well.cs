using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace wella
{
    public class Well()
    {
//properties *********************************************

        string _createdBy = "";
        public string CreatedBy
        {
            get { return _createdBy; }
            //set { _createdBy = value; }
        }

        string _createdOn ="";
        public string CreatedOn
        {
            get {return _createdOn;}
            //set { _createdOn = value; }
        }

        string _version;
        public string Version
            { get {return _version;} 
        }

        Dictionary<string, string> _wellInfo = new Dictionary<string, string>();
        public Dictionary<string, string> WellInfo
        {
            get { return _wellInfo; }
            set { _wellInfo = value; }
        }


        Dictionary<string, string>  _curveInfo = new Dictionary<string, string>();
        public Dictionary<string, string> CurveInfo
        {
            get { return _curveInfo; }
            set { _curveInfo = value; }
        }

        List<List<float>> _curves = new List<List<float>>();
        public List<List<float>> Curves
        {
            get { return _curves; }
            set { _curves = value; }
        }



        //methods *******************************************

        public void parseHeader(string lasFileName)
        {
            FileStream fs = new FileStream(lasFileName, FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            Boolean quit = false;
            while (!sr.EndOfStream) 
            {
                string line = sr.ReadLine();
                if (line.Contains("Created on")) { _createdOn = line.Split(':')[1].Trim().Trim('\t'); }
                if (line.Contains("version")) { _version = line.Split("-")[1].Trim(); }
                if (line == "~WELL INFORMATION")
                {
                    sr.ReadLine();sr.ReadLine();
                    line = sr.ReadLine();
                    string col1 = "";
                    string col2="";
                    while (line != "~CURVE INFORMATION")
                    {
                        col1 = line.Split(" ")[0];
                        try
                        {
                            col2 = line.Split(":")[0].Split(" ", StringSplitOptions.RemoveEmptyEntries)[2];
                        }
                        catch (Exception)
                        {
                            col2 = "";
                        }
                        
                        _wellInfo.Add(col1, col2);
                        line = sr.ReadLine().Trim();
                    }
                    quit=true; 
                }
                if (quit)
                {
                    if (line == "~CURVE INFORMATION" ) { sr.ReadLine(); sr.ReadLine(); }
                    line = sr.ReadLine();

                    while (!line.Contains("~A"))
                    {
                        string c1 = "";
                        string c2 = "";
                        c1 = line.Split(" ")[0];
                        _curveInfo.Add(c1, "");
                        line = sr.ReadLine();
                    }
                    if (line.Contains("~A")) return;
                }
            }
        }

        
        public void parsLogs(string lasfilename)
        {
            FileStream fs = new FileStream(lasfilename, FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            string line = sr.ReadLine();
            while(!line.Contains("~A")) 
            { 
                sr.ReadLine();
                line = sr.ReadLine();
            }
            List<float>[] columns = new List<float>[this.CurveInfo.Count];
            for (int i = 0; i < this.CurveInfo.Count; i++)
            {
                columns[i]=new List<float>();
            }
            while (!sr.EndOfStream)
            {
                string[] cols = new string[this.CurveInfo.Count];
                line = sr.ReadLine();
                cols = line.Split(' ', StringSplitOptions.RemoveEmptyEntries); 
                
                for (int i = 0; i < cols.Length; i++)
                {
                    columns[i].Add(Convert.ToSingle(cols[i], System.Globalization.CultureInfo.InvariantCulture));
                }
            }
            for (int i = 0; i < columns.Length; i++)
            {
                _curves.Add(columns[i]);
            }
        }
    }
}
