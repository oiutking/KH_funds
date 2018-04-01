using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace kaihong_funds
{
    public partial class billPDF : System.Web.UI.Page
    {
        public BaseFont base_font;
        protected void Page_Load(object sender, EventArgs e)
        {
            MemoryStream ms = new MemoryStream();
            ms = creatpdf();


            Response.Clear();
            //Response.AddHeader("Content-Disposition", "attachment;FileName=out.pdf");
            //Response.ContentType = ("application/octet-stream");
            Response.ContentType = ("application/pdf");
            Response.OutputStream.Write(ms.GetBuffer(), 0, ms.GetBuffer().Length);
            Response.OutputStream.Flush();
            Response.OutputStream.Close();
            Response.Flush();
            Response.End();

        }

        protected MemoryStream creatpdf()
        {
           string[] cmd =new string[2];
           if (Session["bill_preview"]==null)
            {
               
            }
           else
            {
                string billcmd = Session["bill_preview"].ToString();
                cmd = billcmd.Split(',');
            }
            MemoryStream ms_out = new MemoryStream();
            try
            {
                if (cmd[1].ToString() == "1")
                {
                    publicClass.bill bill = new publicClass.bill(Convert.ToInt32(cmd[0]));
                    publicClass.Dep dep = new publicClass.Dep(bill.Payfrom);
                    publicClass.dep_no dep_no = new publicClass.dep_no(bill.Payfrom_no);
                    string url = "http://" + Request.Url.Host + ":" + Request.Url.Port + "/billmodel/cd.pdf";
                    publicClass.Uer maker = new publicClass.Uer(bill.Maker);
                    PdfReader rd = new PdfReader(url);
                    MemoryStream ms = new MemoryStream();
                    PdfStamper st = new PdfStamper(rd, ms);
                    PdfContentByte cb = st.GetOverContent(1);
                    //iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance("https://www.baidu.com/img/pcindex_small.png");
                    //img.SetAbsolutePosition(100, 100);
                    //cb.AddImage(img);
                    BaseFont font = BaseFont.CreateFont("c:\\windows\\fonts\\STSONG.TTF", BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
                    AcroFields f1 = st.AcroFields;
                    foreach( string x in f1.Fields.Keys)
                    {
                        f1.SetFieldProperty(x, "textfont", font, null);
                    }
                    
                    f1.SetField("ckdw", dep.DeName);                    
                    f1.SetField("kprq", bill.Make_date.ToShortDateString().ToString());
                    f1.SetField("jexx", bill.Amount.ToString());
                    f1.SetField("dycs", "0");
                    f1.SetField("jedx", publicClass.formatamount.format(bill.Amount));
                    f1.SetField("ckzh",dep_no.No);
                    f1.SetField("bz","开户银行：" +dep_no.No_name+"\n 说明："+bill.Summary);
                    f1.SetField("zdr", maker.Uname);
                    st.Writer.CloseStream = false;
                    st.Close();
                    ms_out = ms;
                }else
                {

                }
            }
            catch
            {
                base_font  = BaseFont.CreateFont(Server.MapPath("\\billmodel\\hwst.ttf"), BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
                Font font = new Font(base_font);
                Document doc = new Document(PageSize.A5.Rotate());
                PdfWriter wr = PdfWriter.GetInstance(doc, ms_out);
                doc.Open();
                doc.Add(new Paragraph("单据加载错误!", font));
                doc.Close();
            }

            return ms_out;
                        
        }
    }
}