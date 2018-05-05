using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace kaihong_funds
{
    public partial class UserEdit : System.Web.UI.Page
    {
        publicClass.Uer _uer;
        protected void Page_Load(object sender, EventArgs e)
        {
            _uer = new publicClass.Uer(Convert.ToInt32(Session["uer_id"]));

        }

        protected void save_Click(object sender, EventArgs e)
        {
            _uer = new publicClass.Uer(Convert.ToInt32(Session["uer_id"]));
            if(this.oldpsw.Text!=_uer.Upsw)
            {
                publicClass.calljs.alert(this, "原始密码核对失败！");
            }
            else
            {
                if(new_psw.Text!=new_psw1.Text)
                {
                    publicClass.calljs.alert(this, "两次输入的新密码不一致！");
                }
                else
                {
                    if (new_psw.Text.Length<6)
                    {
                        publicClass.calljs.alert(this, "新密码不能小于6位！");
                    }
                    else
                    {
                        _uer.Upsw = new_psw.Text;
                        _uer.Save();
                        publicClass.calljs.alert(this, "密码修改成功！");
                    }
                }
            }

        }

        protected override void OnLoadComplete(EventArgs e)
        {
            base.OnLoadComplete(e);
            this.menu.Isadmin(_uer.Ulvl == 7 ? true : false);
        }
    }
}