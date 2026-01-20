using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using wella;
using System.Windows.Forms;
using System.Globalization;
using System.Threading;
using System.Text.RegularExpressions;

namespace wella
{
    public class LayerPairs
    {
        public float depth;
        public string desc;

        public string toString()
        {
            string s;
            s=depth.ToString(System.Globalization.CultureInfo.InvariantCulture) + ";" + desc.ToString(System.Globalization.CultureInfo.InvariantCulture);
            return s;
        }
    }

    public class Wells
    {
        public Wells() { }

        public Wells(string FileName) { }

        //properties *********************************************

        List<LayerPairs> _intervalls = new List<LayerPairs>();
        [CategoryAttribute("Well data"), DefaultValueAttribute(true)]
        public List<LayerPairs> Intervals 
        { 
            get { return _intervalls; } 
            set { _intervalls = value; }
        }


        string _createdBy = "";
        [CategoryAttribute("Survey data"), DefaultValueAttribute(true)]
        public string CreatedBy
        {
            get { return _createdBy; }
            set { _createdBy = value; }
        }

        string _createdOn = "";
        [CategoryAttribute("Survey data"), DefaultValueAttribute(true)]
        public string CreatedOn
        {
            get { return _createdOn; }
            set { _createdOn = value; }
        }

        string _version;
        [CategoryAttribute("Survey data"), DefaultValueAttribute(true)]
        public string Version
        {
            get { return _version; }
            set { _version = value; }
        }

        Dictionary<string, string> _wellInfo = new Dictionary<string, string>();
        [CategoryAttribute("Well data"), DefaultValueAttribute(true)]
        public Dictionary<string, string> WellInfo
        {
            get { return _wellInfo; }
            set { _wellInfo = value; }
        }


        Dictionary<string, string> _curveInfo = new Dictionary<string, string>();
        [CategoryAttribute("Well data"), DefaultValueAttribute(true)]
        public Dictionary<string, string> CurveInfo
        {
            get { return _curveInfo; }
            set { _curveInfo = value; }
        }


        List<List<float>> _curves = new List<List<float>>();
        [CategoryAttribute("Well data"), DefaultValueAttribute(true)]
        public List<List<float>> Curves
        {
            get { return _curves; }
            set { _curves = value; }
        }

        List<string> _descWellInfo = new List<string>();
        [CategoryAttribute("Well data"), DefaultValueAttribute(true)]
        public List<string> DescWellInfo
        {
            get { return _descWellInfo; }
            set { _descWellInfo = value; }
        }



        //methods *******************************************

        public void init()
        {
            this.WellInfo.Clear();
            this.CurveInfo.Clear();
            this.Curves.Clear();
        }

        public void parseHeader(string lasFileName)
        {
            using(FileStream fs = new FileStream(lasFileName, FileMode.Open, FileAccess.Read))
            {
                StreamReader sr = new StreamReader(fs);
                Boolean quit = false;
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    if (line.Contains("Created on")) { _createdOn = line.Split(':')[1].Trim().Trim('\t'); }
                    if (line.Contains("version")) { _version = line.Split('-')[1].Trim().Split(' ')[1]; }
                    if (line == "~WELL INFORMATION")
                    {
                        sr.ReadLine(); sr.ReadLine();
                        line = sr.ReadLine();
                        string col1 = "";
                        string col2 = "";
                        //string[] c;
                        while (line != "~CURVE INFORMATION")
                        {
                            col1 = line.Split(' ')[0];
                            try
                            { 
                                col2=line.Split(':')[0].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)[2];
                            }
                            catch (Exception)
                            {
                                col2 = "";
                            }

                            _wellInfo.Add(col1, col2);
                            string linemod = Regex.Replace(line, @"\s+", " ");
                            _descWellInfo.Add(linemod);
                            line = sr.ReadLine().Trim();
                        }
                        quit = true;
                    }
                    if (quit)
                    {
                        if (line == "~CURVE INFORMATION") { sr.ReadLine(); sr.ReadLine(); }
                        line = sr.ReadLine();

                        while (!line.Contains("~A"))
                        {
                            string c1 = "";
                            string c2 = "";
                            c1 = line.Split(' ')[0];
                            //if (line.Split('.').Length < 1 )
                            {
                                c2 = line.Split('.')[1].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)[0];
                                _curveInfo.Add(c1, c2);
                            }

                            line = sr.ReadLine();
                        }
                        if (line.Contains("~A")) return;
                    }
                }
            }         
        }

        public void parseIntervals(string lasfilename)
        {
            FileStream fs = new FileStream(lasfilename, FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            bool intervallSection = false;
            string line = "";
            while ((line = sr.ReadLine()) != null)
            {
                line = line.Trim();

                if (line == "#Intervalls")
                {
                    intervallSection = true;
                    //Console.WriteLine(line);
                    continue; // lépj tovább a következő sorra
                }

                if (line == "#End" && intervallSection)
                {
                    break; // kilépünk a ciklusból
                }

                if (intervallSection)
                {
                    Console.WriteLine(line); // csak az intervallumon belüli sorokat írjuk ki
                    LayerPairs layerp= new LayerPairs();
                    string[] lp = line.Split(':');
                    string desc = lp[1];
                    string dp = lp[0];
                    float d = Convert.ToSingle(dp,CultureInfo.InvariantCulture);
                    layerp.depth = d;
                    layerp.desc = desc;
                    this.Intervals.Add(layerp);
                }
            }
            //string s = sr.ReadLine();
            //while(s != "#Intervalls")
            //{
            //    s = sr.ReadLine();
            //    Console.WriteLine(s);
            //    if (s == "#Intervalls")
            //    {
            //        s = sr.ReadLine();
            //        while (s != "#End")
            //        {                       
            //            Console.WriteLine(s);
            //        }
            //    }
            //}
        }


        public void parsLogs(string lasfilename)
        {
            FileStream fs = new FileStream(lasfilename, FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            string line = sr.ReadLine();
            //if (line == null)
            while (!line.Contains("~A"))
            {
                sr.ReadLine();
                line = sr.ReadLine();
                if (line == null) return;
            }
            List<float>[] columns = new List<float>[this.CurveInfo.Count];
            for (int i = 0; i < this.CurveInfo.Count; i++)
            {
                columns[i] = new List<float>();
            }
            while (!sr.EndOfStream)
            {
                string[] cols = new string[this.CurveInfo.Count];
                line = sr.ReadLine();
                cols = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

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

        public void save2WlaFormat(String filePath)
        {
            using (FileStream fs = new FileStream(filePath, FileMode.Create, FileAccess.ReadWrite))
            {
                StreamWriter sw = new StreamWriter(fs);
                sw.WriteLine("Well log data in Wella native format (.wla)" + Environment.NewLine + "--- Do not edit this file because it can be harmed ---");
                sw.WriteLine("Created by:" + this.CreatedBy);
                sw.WriteLine("Created on:" + this.CreatedOn);
                sw.WriteLine("LAS file version:" + this.Version);

                sw.WriteLine("#Well description");
                {
                    foreach (string d in DescWellInfo)
                    {
                        sw.WriteLine(d);
                    }
                }
                sw.WriteLine("#End");
                sw.WriteLine("#Well parameters");
                foreach (var wi in _wellInfo)
                {
                    sw.WriteLine(wi.Key + ":" + wi.Value);
                }
                sw.WriteLine("#End");
                sw.WriteLine("#Available log names and units");
                foreach (var ln in this.CurveInfo)
                {
                    sw.WriteLine(ln.Key + ":" + ln.Value);
                }
                //sw.WriteLine("#End");
                //sw.WriteLine("#Intervalls");
                //foreach (var iv in this.Intervals)
                //{
                //    string d = Convert.ToString(iv.depth, CultureInfo.InvariantCulture);
                //    sw.WriteLine(d + ":" + iv.desc);
                //}
                sw.WriteLine("#End");               
                sw.WriteLine("Number of depth points:" + this.Curves[0].Count);
                sw.WriteLine("#Available log");
                for (int j=0; j <_curveInfo.Count; j++)
                {
                    sw.WriteLine(this._curveInfo.ElementAt(j).Key);
                    for (int i = 0; i < this.Curves[0].Count; i++)
                    {
                        string value = Curves[j][i].ToString(CultureInfo.InvariantCulture);
                        sw.WriteLine(value, System.Globalization.CultureInfo.InvariantCulture);
                    }
                }
                sw.WriteLine("#Intervalls");  //writing intervals
                foreach (var iv in this.Intervals)
                {
                    string d = Convert.ToString(iv.depth, CultureInfo.InvariantCulture);
                    sw.WriteLine(d + ":" + iv.desc);
                }
                sw.WriteLine("#End");
                sw.Flush();
            }
        }

        public Wells openWlaFile(string path)
        {
            Wells wls = new Wells();
            using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                using (StreamReader sr = new StreamReader(fs))
                {
                    sr.ReadLine();
                    sr.ReadLine();
                    wls._createdBy = sr.ReadLine().Split(':')[1];
                    wls.CreatedOn = sr.ReadLine().Split(':')[1];
                    wls.Version = sr.ReadLine().Split(':')[1];
                    sr.ReadLine();
                    string s= sr.ReadLine();
                    while (s != "#End") // reading well description
                    {
                        wls.DescWellInfo.Add(s/*s.Split(':')[0], s.Split(':')[1]*/);
                        s = sr.ReadLine();
                    }
                    sr.ReadLine();
                    s = sr.ReadLine();
                    while (s != "#End") // reading well parameters
                    {
                        wls.WellInfo.Add(s.Split(':')[0], s.Split(':')[1]);
                        s=sr.ReadLine();
                    }
                    sr.ReadLine();
                    s = sr.ReadLine();
                    while (s != "#End")  // reading curve parameters
                    {
                        wls.CurveInfo.Add(s.Split(':')[0], s.Split(':')[1]);
                        s = sr.ReadLine();
                    }
                    s= sr.ReadLine();
                    int numofDepthPoints = int.Parse(s.Split(':')[1]);
                    sr.ReadLine();     
                    sr.ReadLine(); 

                    for (int i = 0; i < wls.CurveInfo.Count; i++)  // reading curves
                    {
                        //string ss = s; 
                        string ss = sr.ReadLine();
                        wls.Curves.Add(new List<float>());
                        for (int j = 0; j < numofDepthPoints; j++)
                        {
                            
                            wls.Curves[i].Add(Convert.ToSingle(ss, CultureInfo.InvariantCulture));
                            ss = sr.ReadLine().Trim();
                        }

                    }

                    //while (s != "#End") // reading intervall parameters
                    //{
                    //    //if (s.Contains("Number of depth points"))
                    //    //{
                    //    //    numofDepthPoints = int.Parse(s.Split(':')[1]);
                    //    //    s = sr.ReadLine();
                    //    //}
                    //    //else  //reading curves
                    //    //{
                    //    //    //wls.Curves = new List<List<float>>();
                    //        for (int i = 0; i < wls.CurveInfo.Count; i++)
                    //        {
                    //            string ss; // = sr.ReadLine();
                    //            wls.Curves.Add(new List<float>());
                    //            for (int j = 0; j < numofDepthPoints; j++)
                    //            {
                    //                ss = sr.ReadLine().Trim();
                    //                wls.Curves[i].Add(Convert.ToSingle(ss, CultureInfo.InvariantCulture));

                    //            }
                    //            ss=sr.ReadLine();

                    //        }

                    //    //}
                    //}

                }
            }            
            return wls;
        }

    }
}

