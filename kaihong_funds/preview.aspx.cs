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
using System.Data;

namespace kaihong_funds
{
    public partial class billPDF : System.Web.UI.Page
    {
        public BaseFont base_font;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
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
            catch
            {

            }

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
                publicClass.bill bill = new publicClass.bill(Convert.ToInt32(cmd[0]));
                publicClass.Dep dep = new publicClass.Dep(bill.Payfrom);
                publicClass.dep_no dep_no = new publicClass.dep_no(bill.Payfrom_no);
                publicClass.exc_dep edep = new publicClass.exc_dep();
                if (bill.Bill_type==2)
                {
                    edep = new publicClass.exc_dep(bill.Payto);
                }
                if (cmd[1].ToString() == "1")
                {
                    //publicClass.sig sig = new publicClass.sig(1);
                    string url = "http://" + Request.Url.Host + ":" + Request.Url.Port + "/billmodel/cd.pdf";
                    publicClass.Uer maker = new publicClass.Uer(bill.Maker);
                    PdfReader rd = new PdfReader(url);
                    MemoryStream ms = new MemoryStream();
                    PdfStamper st = new PdfStamper(rd, ms);
                    PdfContentByte cb = st.GetOverContent(1);
                    
                    //iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance(publicClass.Sigformat.ToImage(sig.Sig_word), new BaseColor(255, 255, 255));
                    //img.Transparency = new int[] { 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF };
                    //img.SetAbsolutePosition(100, 100);
                    //img.ScaleToFit(100f, 100f);
                    //cb.AddImage(img);
                    //cb.AddImage(img);
                    BaseFont font = BaseFont.CreateFont("c:\\windows\\fonts\\STSONG.TTF", BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
                    AcroFields f1 = st.AcroFields;
                    foreach( string x in f1.Fields.Keys)
                    {
                        f1.SetFieldProperty(x, "textfont", font, null);
                    }
                    
                    f1.SetField("ckdw", dep.DeName);                    
                    f1.SetField("kprq", bill.Make_date.ToShortDateString().ToString());
                    f1.SetField("jexx", "￥"+ bill.Amount.ToString());
                    
                    f1.SetField("jedx","人民币： " +publicClass.formatamount.format(bill.Amount));
                    f1.SetField("ckzh",dep_no.No);
                    f1.SetField("bz","开户银行：" +dep_no.No_name+"\n说明："+bill.Summary);
                    f1.SetField("zdr", maker.Uname);
                    string newstr = publicClass.str2base64.to64(publicClass.str2base64.tostr(bill.Secret) + "Pd:" + DateTime.Now.ToShortDateString());
                    f1.SetField("mm", newstr);
                    f1.SetField("pjbh", bill.Bill_id_head + "-" + bill.Bill_id_body);
                    f1.SetField("kprq", string.Format("{0}年{1}月{2}日", bill.Make_date.Year, bill.Make_date.Month, bill.Make_date.Day));
                    f1.SetField("dycs", bill.Prnt.ToString());
                    f1.SetField("dyrq", string.Format("{0}年{1}月{2}日", DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day));
                    InsertImg(cb, bill.Bill_id, f1);
                    st.Writer.CloseStream = false;
                    st.Close();
                    ms_out = ms;
                }
                else
                {
                    string url = "http://" + Request.Url.Host + ":" + Request.Url.Port + "/billmodel/zp.pdf";
                    publicClass.Uer maker = new publicClass.Uer(bill.Maker);
                    PdfReader rd = new PdfReader(url);
                    MemoryStream ms = new MemoryStream();
                    PdfStamper st = new PdfStamper(rd, ms);
                    PdfContentByte cb = st.GetOverContent(1);
                    
                    BaseFont font = BaseFont.CreateFont("c:\\windows\\fonts\\STSONG.TTF", BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
                    AcroFields f1 = st.AcroFields;
                    foreach (string x in f1.Fields.Keys)
                    {
                        f1.SetFieldProperty(x, "textfont", font, null);
                    }
                    f1.SetField("fkdw", dep.DeName);
                    f1.SetField("kprq", bill.Make_date.ToShortDateString().ToString());
                    f1.SetField("fkzh", dep_no.No);
                    f1.SetField("skdw", edep.Edep_name);
                    f1.SetField("skzh", edep.Edep_no);
                    f1.SetField("ckzh", dep_no.No);
                    f1.SetField("xxje", "￥"+ bill.Amount.ToString());
                    
                    f1.SetField("dxje", "人民币： "+ publicClass.formatamount.format(bill.Amount));
                    f1.SetField("bz", "开户银行：" + dep_no.No_name + "\n说明：" + bill.Summary);
                    f1.SetField("zdr", maker.Uname);
                    string newstr = publicClass.str2base64.to64(publicClass.str2base64.tostr(bill.Secret) +"Pd:"+ DateTime.Now.ToShortDateString());
                    f1.SetField("mm", newstr);
                    f1.SetField("pjph", bill.Bill_id_head + "-" + bill.Bill_id_body);
                    f1.SetField("kprq", string.Format("{0}年{1}月{2}日", bill.Make_date.Year,bill.Make_date.Month,bill.Make_date.Day));
                    f1.SetField("dycs", bill.Prnt.ToString());
                    f1.SetField("dyrq", string.Format("{0}年{1}月{2}日", DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day));
                    InsertImg(cb, bill.Bill_id,f1);
                    st.Writer.CloseStream = false;
                    st.Close();
                    ms_out = ms;

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

        private void InsertImg(PdfContentByte cb,int b_id, AcroFields f1)
        {
            try
            {
                string cmd_op_list = "select * from op  where bill_id=" + b_id;
                publicClass.Dosql ds = new publicClass.Dosql();
                publicClass.sig sig = null;
                ds.DoRe(cmd_op_list);
                string oper = "审批人：\n  ";
                foreach (DataRow r in ds.DtOut.Rows)
                {
                    if (Convert.ToInt16(r["lvl"]) <= 2)
                    {
                        sig = new publicClass.sig(Convert.ToInt32( r["sig_id"]));
                        iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance(publicClass.Sigformat.ToImage(sig.Sig_word), new BaseColor(255, 255, 255));
                        img.Transparency = new int[] { 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF };
                        if (Convert.ToInt16(r["lvl"]) == 1)
                        {
                            img.SetAbsolutePosition(100, 80);
                            img.ScaleToFit(100f, 100f);
                        }
                        else
                        {
                            img.SetAbsolutePosition(200, 100);
                            img.ScaleToFit(80f, 80f);
                        }
                        
                        cb.AddImage(img);
                        cb.AddImage(img);
                    }
                    else
                    {
                       
                    }
                    oper += new publicClass.Uer(Convert.ToInt32(r["uer_id"])).Uname + "\n ";
                }
                f1.SetField("sp", oper);
            }
            catch
            {

            }
        }
    }
}